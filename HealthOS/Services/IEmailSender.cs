using System.Threading.Tasks;

namespace HealthOS.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
