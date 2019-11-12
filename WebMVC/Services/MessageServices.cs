using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
namespace WebMVC.Services
{
    public class MessageServices: IEmailSender, ISmsSender
    { 
        private readonly string host;
        private readonly int port;
        private readonly bool enableSsl;
        private readonly string userName;
        private readonly string password;
        private readonly string senderEmail;

        public MessageServices(string host, int port, bool enableSSL, string userName, string password, string senderEmail)
        {
            this.host = host;
            this.port = port;
            this.enableSsl = enableSSL;
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

        public Task SendSmsAsync(string number, string message)
        {
            return Task.FromResult(0);
        }
    }
}
