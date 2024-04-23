using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace SwiftMart.Data
{
    public class Emailsender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            message.From = new MailAddress("noreply@greenshift.nl");
            message.To.Add(email);
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = htmlMessage;

            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("abdimalikmf7@gmail.com", "wakz avdo iysw avzc");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;



            await smtpClient.SendMailAsync(message);
        }
    }
}
