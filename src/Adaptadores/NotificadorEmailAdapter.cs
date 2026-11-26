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

                await smtp.AuthenticateAsync(
                    Environment.GetEnvironmentVariable("EMAIL_USER"),
                    Environment.GetEnvironmentVariable("EMAIL_PASSWORD")
                );

                await smtp.SendAsync(
                    new SmtpSendRequest(email)
                );

                await smtp.DisconnectAsync(true);
            }
        }
    }
}