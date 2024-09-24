namespace UberSystem.Domain.Interfaces.Services;

public interface IEmailService
{
    Task SendVerificationEmailAsync(string email, string verificationLink);
}