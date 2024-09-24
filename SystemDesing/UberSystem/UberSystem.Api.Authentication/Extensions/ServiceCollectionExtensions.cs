using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Interfaces;
using UberSystem.Domain.Interfaces.Services;
using UberSystem.Infrastructure;
using UberSystem.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using UberSytem.Dto;
namespace UberSystem.Api.Authentication.Extensions
{
    public static class ServiceCollectionExtensions
	{
    	/// <summary>
    	/// Add needed instances for database
    	/// </summary>
    	/// <param name="services"></param>
    	/// <param name="configuration"></param>
    	/// <returns></returns>
    	public static IServiceCollection AddDatabase(this IServiceCollection services,ConfigurationManager  configuration)
    	{
        	// Configure DbContext with Scoped lifetime  
            services.AddDbContext<UberSystemDbContext>(options =>
            	{
                    options.UseSqlServer(configuration.GetConnectionString("Default"),
                    	sqlOptions => sqlOptions.CommandTimeout(120));
                    // options.UseLazyLoadingProxies();
            	}
        	);
 
        	services.AddScoped<Func<UberSystemDbContext>>((provider) => () => provider.GetService<UberSystemDbContext>());
            services.AddScoped<DbFactory>();
        	services.AddScoped<IUnitOfWork, UnitOfWork>();
    //        services.AddIdentity<User, IdentityRole>()
				//.AddEntityFrameworkStores<UberSystemDbContext>()
				//.AddDefaultTokenProviders();
			// Configure JWT authentication
			var jwtSettings = configuration.GetSection("JwtSettings");
			var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

            // AutoMapper
            services.AddAutoMapper(typeof(MappingProfileExtension));
        	return services;
    	}
 
    	/// <summary>
    	/// Add instances of in-use services
    	/// </summary>
    	/// <param name="services"></param>
    	/// <returns></returns>
    	public static IServiceCollection AddServices(this IServiceCollection services)
    	{
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddTransient<SmtpClient>(provider =>
            {
	            var smtpClient = new SmtpClient();
	            smtpClient.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
	            smtpClient.Authenticate("your-email", "your-password");
	            return smtpClient;
            });
            services.AddScoped(typeof(TokenService));

            return services;
    	}
	}
}