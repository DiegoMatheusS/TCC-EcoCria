using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TCCEcoCria.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task EnviarEmailAsync(string destinatario, string assunto, string corpo)
        {
            try
            {
                // Recupera as configurações do appsettings.json
                var smtpServer = _configuration["EmailSettings:Host"];
                var smtpPort = int.Parse(_configuration["EmailSettings:Port"]);
                var smtpUser = _configuration["EmailSettings:Username"];
                var smtpPassword = _configuration["EmailSettings:Password"];

                using (var cliente = new SmtpClient(smtpServer, smtpPort))
                {
                    cliente.Credentials = new NetworkCredential(smtpUser, smtpPassword);
                    cliente.EnableSsl = true; // Ativa o SSL para uma conexão segura

                    // Cria a mensagem de e-mail
                    var mensagem = new MailMessage
                    {
                        From = new MailAddress(smtpUser), // E-mail do remetente
                        Subject = assunto, // Assunto do e-mail
                        Body = corpo, // Corpo do e-mail
                        IsBodyHtml = true, // Define que o corpo é em HTML
                    };

                    mensagem.To.Add(destinatario); // Adiciona o destinatário

                    // Envia o e-mail de forma assíncrona
                    await cliente.SendMailAsync(mensagem);
                }
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro ao enviar o e-mail, lança uma exceção com a mensagem de erro
                throw new InvalidOperationException("Erro ao enviar o e-mail", ex);
            }
        }
    }
}
