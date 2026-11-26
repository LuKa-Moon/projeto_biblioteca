using src.Adaptadores;
using src.Nucleo.Modelos;

namespace src.Nucleo.Repositorios
{
    public class LivroRepository : Repository<Livro>
    {
        public LivroRepository(BDAdapter contexto)
            : base(contexto)
        {
        }
    }
}