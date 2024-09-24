using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using UberSystem.Domain.Entities;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace UberSystem.Service;
public class TokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user, IList<string> roles)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = new JwtSecurityToken(
            _configuration["JwtSettings:Issuer"],
            _configuration["JwtSettings:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:DurationInMinutes"])),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /// <summary>
    /// Extract and return the role from the claims
    /// </summary>
    /// <param name="claims"></param>
    /// <returns></returns>
    public string GetRoleFromClaims(IList<Claim> claims) 
    { 
        var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
        if (roleClaim is not null)
            return roleClaim.Value;

        return string.Empty;    // function error
    } 

}