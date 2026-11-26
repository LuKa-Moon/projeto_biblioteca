using src.Nucleo.IServicos;
using src.Nucleo.Modelos;
using src.Nucleo.Repositorios;

namespace src.Nucleo.Servicos
{
    public class LivroService : ILivroService
    {
        private readonly LivroRepository _livroRepository;

        public LivroService(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<IEnumerable<Livro>> BuscarLivros()
        {
            return await _livroRepository.GetAll();
        }

        public async Task<Livro?> BuscarLivroId(int id)
        {
            return await _livroRepository.Get(id);
        }
    }
}