using src.nucleo.modelos;
using Microsoft.AspNetCore.Mvc;

namespace src.Portas
{
    public interface UsuarioPort
    {
        Task<ActionResult<Reserva>> CriaReserva(string grr, string idLivro);

        // Outras acoes vindas do usuario
    }
}