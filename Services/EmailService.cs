using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TCCEcoCria.Services
{
    public class EmailService : IEmailService
    {
        // Parâmetros de configuração do servidor SMTP
        private readonly string _smtpServer = "smtp.exemplo.com"; // Exemplo de servidor SMTP (substitua com o real)
        private readonly int _smtpPort = 587; // Porta do servidor SMTP
        private readonly string _smtpUser = "ecocria2024@gmail.com"; // Seu e-mail (substitua com o real)
        private readonly string _smtpPassword = "Eco2024cria"; // Sua senha de e-mail (substitua com a real)

        public async Task EnviarEmailAsync(string destinatario, string assunto, string corpo)
        {
            try
            {
                // Configura o cliente SMTP com as credenciais e o servidor
                using (var cliente = new SmtpClient(_smtpServer, _smtpPort))
                {
                    cliente.Credentials = new NetworkCredential(_smtpUser, _smtpPassword);
                    cliente.EnableSsl = true; // Ativa o SSL para uma conexão segura

                    // Cria a mensagem de e-mail
                    var mensagem = new MailMessage
                    {
                        From = new MailAddress(_smtpUser), // E-mail do remetente
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
