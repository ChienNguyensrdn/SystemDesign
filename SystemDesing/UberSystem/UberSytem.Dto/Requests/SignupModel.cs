using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UberSytem.Dto.Requests
{
    public class SignupModel
    {
        public long Id { get; set; }

        public int Role { get; set; }

        public string? UserName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        
        [JsonIgnore]
        public string? EmailVerifiedToken { get; set; } 
    }
}
