using src.Nucleo.Modelos;
using Microsoft.AspNetCore.Mvc;
using src.Portas;
using src.Nucleo.Controllers;
using src.Nucleo.IServicos;

namespace src.Adaptadores
{
    [ApiController]
    [Route("/")]
    public class WebAdapter : ControllerBase, ReservaPort, LivroPort
    {
        private readonly ReservaController _reservaController;
        private readonly LivroController _livroController;

    public WebAdapter(ReservaController reservaController,
                      LivroController livroController)
    {
        _reservaController = reservaController;
        _livroController = livroController;
    }

        [HttpGet("livros")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            return Ok(await _livroController.GetLivros());
        }

        [HttpGet("reservas/{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(string id)
        {
            Reserva? reserva = await _reservaController.GetReserva(id);
            if (reserva == null)
                return NotFound();

            return Ok(reserva);
        }

        [HttpPost("reservas")]
        public async Task<ActionResult<Reserva>> ReservarLivro(
            [FromQuery] string grr,
            [FromQuery] string idLivro)
        {
            ResultadoReserva resultado = await _reservaController.ReservarLivro(grr, idLivro);

            switch(resultado)
            {
                case ResultadoReserva.Sucesso:
                    return Ok();
                case ResultadoReserva.EstudanteOuLivroNaoEncontrado:
                    return NotFound("Estudante ou livro não encontrado.");
                case ResultadoReserva.EstudanteNaoPodeReservar:
                    return Conflict("O estudante não pode realizar uma nova reserva no momento.");
                case ResultadoReserva.LivroIndisponivel:
                    return Conflict("Não há exemplares do livro disponíveis no momento.");
                default:
                    return StatusCode(500);
            }
        }
    }
}