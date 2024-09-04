using System.Threading.Tasks;

namespace EfficientTaskManager.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string emailAddress, string subject, string message);
    }

    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string emailAddress, string subject, string message)
        {
            // Implement email sending logic
            return Task.CompletedTask;
        }
    }
}
