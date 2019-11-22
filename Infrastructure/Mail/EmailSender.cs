using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private readonly string host;
        private readonly int port;
        private readonly bool enableSsl;
        private readonly string userName;
        private readonly string password;
        private readonly string senderEmail;

        public EmailSender(string host, int port, bool enableSsl, string userName, string password, string senderEmail)
        {
            this.host = host;
            this.port = port;
            this.enableSsl = enableSsl;
            this.userName = userName;
            this.password = password;
            this.senderEmail = senderEmail;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSsl
            };

            await client.SendMailAsync(new MailMessage(senderEmail, email, subject, message) { IsBodyHtml = true });
        }
    }
}
