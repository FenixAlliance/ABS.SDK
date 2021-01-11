using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FenixAlliance.ABS.SDK.Helpers
{
    public class EmailHelpers
    {
        private readonly IConfiguration _configuration;

        public EmailHelpers(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message, string name, bool markedForRevision)
        {
            await Execute(subject, message, email, name, markedForRevision);
        }

        public async Task Execute(string subject, string message, string email, string name, bool markedForRevision)
        {
            var SendgridConfig = _configuration.GetSection("Sendgrid");
            var apiKey = SendgridConfig.GetValue<string>("ApiKey");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            if (markedForRevision)
            {
                msg.From = new EmailAddress("support@fenix-alliance.com", "[Andy AI] Alliance ID Support Team | Fenix Alliance Group");
                msg.Subject = subject;
                msg.PlainTextContent = message;
                msg.HtmlContent = message;
            }
            else
            {
                msg.From = new EmailAddress("andy@fenix-alliance.com", "[Andy AI] Alliance ID Support Team | Fenix Alliance Group");
                msg.Subject = subject;
                msg.PlainTextContent = message;
                msg.HtmlContent = message;
                msg.AddTo(new EmailAddress(email, name));
            }
            msg.AddTo(new EmailAddress("support@fenix-alliance.com", "Alliance ID Support Team | Fenix Alliance Group"));
            msg.AddTo(new EmailAddress("ceo@fenix-alliance.com", "Alliance ID Support Team | Fenix Alliance Group"));
            await client.SendEmailAsync(msg);
        }
    }
}