using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using src.Portas;

namespace src.Adaptadores
{
    public class NotificadorEmailAdapter : NotificadorPort
    {
        public async Task Notifica(
            string destinatario,
            string endereco,
            string msg)
        {
            var email = new MimeMessage();

            email.From.Add(
                new MailboxAddress(
                    "Biblioteca",
                    Environment.GetEnvironmentVariable("EMAIL_USER")
                )
            );

            email.To.Add(
                new MailboxAddress(destinatario, endereco)
            );

            email.Subject = "Reserva realizada!";

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = msg
            };

            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(
                    "smtp.gmail.com",
                    587,
                    SecureSocketOptions.StartTls
                );

                string usuario = Environment.GetEnvironmentVariable("EMAIL_USER")
                    ?? throw new InvalidOperationException("EMAIL_USER não configurado.");

                string senha = Environment.GetEnvironmentVariable("EMAIL_PASSWORD")
                    ?? throw new InvalidOperationException("EMAIL_PASSWORD não configurado.");

                await smtp.AuthenticateAsync(usuario, senha);

                await smtp.SendAsync(
                    new SmtpSendRequest(email)
                );

                await smtp.DisconnectAsync(true);
            }
        }
    }
}