using System.Net.Mail;
using Microsoft.Extensions.Options;
using NvkInWay.Api.Settings;

namespace NvkInWay.Api.Utils.Impl;

public class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> logger;
    private readonly EmailConfigurationOptions configuration;
    private readonly MailAddress senderAddress;

    public EmailSender(IOptions<EmailConfigurationOptions> options, ILogger<EmailSender> logger)
    {
        this.logger = logger;
        configuration = options.Value;

        if (!MailAddress.TryCreate(configuration.EmailAddress, out var myAddress))
        {
            logger.LogCritical("Error creating sender email address '{Email}'", configuration.EmailAddress);
            throw new ArgumentException("Not Valid EmailAddress");
        }
        senderAddress = myAddress;
    }

    public async Task<bool> SendAsync(string toEmail, string subject, string htmlContent)
    {
        var email = new MailMessage();
        email.From = senderAddress;
        email.To.Add(new MailAddress(toEmail));
        email.Subject = subject;
        email.Body = htmlContent;

        try
        {
            using var smtp = new SmtpClient(configuration.EmailHost, configuration.EmailHostPort);

            await smtp.SendMailAsync(email);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error sending mail message to '{Email}'", email.To);
            return false;
        }

        return true;
    }
}