using src.Nucleo.Modelos;
using src.Nucleo.IServicos;

namespace src.Nucleo.Controllers
{
    public class ReservaController
    {
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        public async Task<Reserva?> GetReserva(string id)
        {
            if (!int.TryParse(id, out int idReserva))
                return null;

            return await _reservaService.BuscarReservaId(idReserva);
        }

        public async Task<ResultadoReserva> ReservarLivro(
            string grr,
            string idLivro)
        {
            if (!int.TryParse(idLivro, out int id))
                return ResultadoReserva.EstudanteOuLivroNaoEncontrado;

            return await _reservaService.ReservarLivro(grr, id);
        }
    }
}