using src.Portas;

namespace src.Adaptadores
{
    public class NotificadorFakeAdapter : NotificadorPort
    {
        public Task Notifica(
            string destinatario,
            string endereco,
            string msg)
        {
            Console.WriteLine("============= NOTIFICAÇÃO =============");
            Console.WriteLine($"Destinatário: {destinatario}");
            Console.WriteLine($"Endereço: {endereco}");
            Console.WriteLine($"Mensagem: {msg}");
            Console.WriteLine("=======================================");

            return Task.CompletedTask;
        }
    }
}