using src.Nucleo.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace src.Portas
{
    public interface NotificadorPort
    {
        Task Notifica(string destinatario, string endereco, string msg);

        // Outras acoes para notificador
    }
}