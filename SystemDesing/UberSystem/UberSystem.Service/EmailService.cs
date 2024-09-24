using MailKit.Net.Smtp;
using MimeKit;
using UberSystem.Domain.Interfaces.Services;

namespace UberSystem.Service;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;

    public EmailService(SmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
    }
    
    public async Task SendVerificationEmailAsync(string email, string verificationLink)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Denticare", "denticare.hcm@outlook.com"));
        message.To.Add(new MailboxAddress("", email));
        message.Subject = "Verify your email";

        // Email body (plain text)
        message.Body = new TextPart("plain")
        {
            Text = $"Please verify your email by clicking on this link: {verificationLink}"
        };
        await _smtpClient.SendAsync(message);
    }
}