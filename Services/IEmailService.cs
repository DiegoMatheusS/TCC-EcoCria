using System.Threading.Tasks;

namespace TCCEcoCria.Services
{
    public interface IEmailService
    {
        Task EnviarEmailAsync(string toEmail, string subject, string body);
    }

}
