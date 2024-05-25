// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using KeuzeWijzerApi.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendGrid.Helpers.Mail.Model;
using System;
using System.Threading.Tasks;

namespace KeuzeWijzerApi.Services
{
    public class MailService
    {
        /// <summary>
        /// <para>Allows you to send mails from the hbo-ict.dev domain using the Sendgrid API. </para>
        /// <para>Important! Don't modify the from address as it's linked to Sendgrid and will fail/bounce all our emails if it does not match.</para>
        /// </summary>
        /// <param name="to">An EmailAddress object that takes 1. the email address and 2. the displayname you choose</param>
        /// <param name="subject">Title for your email</param>
        /// <param name="plainTextContent">Plain text content for the body, always goes first in the email but can be an empty string</param>
        /// <param name="htmlContent">HTML rich content for the body</param>
        /// <returns>A bool based on a succesful statuscode that is returned when emailing</returns>
        public static async Task<bool> SendEmail(EmailAddress to, 
                                          string subject,
                                          string plainTextContent, 
                                          string htmlContent)
        {
            var apikey = Environment.GetEnvironmentVariable("SENDGRID_KEY");
            var client = new SendGridClient(apikey);
            var from = new EmailAddress("noreply@hbo-ict.dev", "Info  | Keuzewijzer");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return response.IsSuccessStatusCode;
        }
    }
}