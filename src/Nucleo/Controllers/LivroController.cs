using src.Nucleo.Modelos;
using src.Nucleo.IServicos;

namespace src.Nucleo.Controllers
{
    public class LivroController
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        public async Task<IEnumerable<Livro>> GetLivros()
        {
            return await _livroService.BuscarLivros();
        }
    }
}