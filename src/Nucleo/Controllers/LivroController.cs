using src.Nucleo.Modelos;
using src.Nucleo.Repositorios;

namespace src.Nucleo.Controllers
{
    public class LivroController
    {
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<IEnumerable<Livro>> GetLivros()
        {
            return await _livroRepository.GetAll();
        }
    }
}