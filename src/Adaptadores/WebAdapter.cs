using src.nucleo.modelos;
using src.Dados;
using Microsoft.AspNetCore.Mvc;
using src.Portas;

namespace src.Adaptadores
{
    [ApiController]
    [Route("usuario/[controller]")]
    public class WebAdapter : ControllerBase, UsuarioPort
    {
        private readonly EstudantesContexto _estudantesContexto;
        private readonly LivrosContexto _livrosContexto;

        public WebAdapter(EstudantesContexto estudantesContexto, 
                          LivrosContexto livrosContexto)
        {
            _estudantesContexto = estudantesContexto;
            _livrosContexto = livrosContexto;
        }

        public async Task<ActionResult<Reserva>> CriaReserva(string grr, string idLivro)
        {
            Estudante? estudante = await _estudantesContexto.Estudantes.FindAsync(grr);
            Livro? livro = await _livrosContexto.Livros.FindAsync(idLivro);
            if(estudante == null || livro == null)
                return NotFound();

            if(!estudante.PodeReservarLivro())
                return Conflict("O estudante não pode realizar uma nova reserva no momento.");
            
            if(livro.Disponiveis().Count == 0)
                return Conflict("Não há exemplares do livro disponíveis no momento.");

            //cria reserva
            //persiste
            //notifica
            //retorna
        }
    }
}