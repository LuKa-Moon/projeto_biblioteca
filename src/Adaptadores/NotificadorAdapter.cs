using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace designSoftware.Adaptadores
{
    public class NotificadorAdapter
    {
        public void NotificaEmail(string destinatario, string endereco, string msg)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Biblioteca", "deoferreira.gustavo@gmail.com"));
            email.To.Add(new MailboxAddress(destinatario, endereco));

            email.Subject = "Testing out email sending";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { 
                Text = msg
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);
                smtp.Authenticate("smtp_username", "smtp_password");

                smtp.Send(email);
                smtp.Disconnect(true);
            }
    }
  }
}