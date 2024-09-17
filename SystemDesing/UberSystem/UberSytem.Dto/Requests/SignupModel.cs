namespace UberSytem.Dto.Requests
{
    public class SignupModel
    {
        public long Id { get; set; }

        public int Role { get; set; }

        public string? UserName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
