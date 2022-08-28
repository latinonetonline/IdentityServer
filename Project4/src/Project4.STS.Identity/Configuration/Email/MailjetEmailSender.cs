using Mailjet.Client;
using Mailjet.Client.Resources;

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json.Linq;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project4.STS.Identity.Configuration.Email
{
    public class MailjetEmailSender : IEmailSender
    {
        private readonly ILogger<MailjetEmailSender> _logger;

        private readonly MailjetConfiguration _configuration;

        private readonly IMailjetClient _client;

        public MailjetEmailSender(ILogger<MailjetEmailSender> logger, MailjetConfiguration configuration, IMailjetClient client)
        {
            _logger = logger;
            _configuration = configuration;
            _client = client;
        }



        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            List<JObject> emails = new();
            emails.Add(new JObject {

                             { "Email", email}
                         });




            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
               .Property(Send.FromEmail, "no-reply@latinonet.online")
               .Property(Send.FromName, "Usuarios | Latino .NET Online")
               .Property(Send.Subject, subject)
               .Property(Send.TextPart, htmlMessage)
               .Property(Send.HtmlPart, htmlMessage)
               .Property(Send.Recipients, new JArray(emails.ToArray()));


            MailjetResponse response = await _client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                _logger.LogInformation(response.GetData().ToString());
            }
            else
            {
                _logger.LogInformation(string.Format("StatusCode: {0}\n", response.StatusCode));
                _logger.LogInformation(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                _logger.LogInformation(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));

            }

        }
    }
}
