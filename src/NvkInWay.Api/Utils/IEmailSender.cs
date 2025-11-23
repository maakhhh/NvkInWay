namespace NvkInWay.Api.Utils;

public interface IEmailSender
{
    public Task<bool> SendAsync(string toEmail, string subject,
        string htmlContent);
}