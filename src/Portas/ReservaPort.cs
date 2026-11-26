using src.Nucleo.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace src.Portas
{
    public interface ReservaPort
    {
        Task<ActionResult<Reserva>> ReservarLivro(string grr, string idLivro);
        Task<ActionResult<Reserva>> GetReserva(string id);

        // Outras acoes para reserva
    }
}