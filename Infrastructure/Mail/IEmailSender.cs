using System.Threading.Tasks;

namespace Infrastructure.Mail
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
