using src.nucleo.modelos;
using Microsoft.AspNetCore.Mvc;
using src.Portas;

namespace src.Adaptadores
{
    [ApiController]
    [Route("usuario/[controller]")]
    public class WebAdapter : ControllerBase, UsuarioPort
    {
        private readonly BDAdapter _contexto;
        private readonly NotificadorAdapter _notificador; //vai sumir dps

        public WebAdapter(BDAdapter contexto, NotificadorAdapter notificador)
        {
            _contexto = contexto;
            _notificador = notificador;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(string id)
        {
            Reserva? reserva = await _contexto.Reservas.FindAsync(id);
            if(reserva == null)
                return NotFound();

            return reserva;
        }

        [HttpPost]
        public async Task<ActionResult<Reserva>> CriaReserva(string grr, string idLivro)
        {
            Estudante? estudante = await _contexto.Estudantes.FindAsync(grr);
            Livro? livro = await _contexto.Livros.FindAsync(idLivro);
            if(estudante == null || livro == null)
                return NotFound();

            if(!estudante.PodeReservarLivro())
                return Conflict("O estudante não pode realizar uma nova reserva no momento.");
            
            if(livro.Disponiveis().Count == 0)
                return Conflict("Não há exemplares do livro disponíveis no momento.");

            Reserva novaReserva = new Reserva(livro, estudante);

            _contexto.Reservas.Add(novaReserva);
            await _contexto.SaveChangesAsync();

            _notificador.NotificaEmail(estudante.Nome, estudante.Email, "Reserva feita chefia ;)");

            return CreatedAtAction(nameof(GetReserva), new {id = novaReserva.Id}, novaReserva);
        }
    }
}