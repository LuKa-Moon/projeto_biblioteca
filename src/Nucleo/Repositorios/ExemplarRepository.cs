using src.Adaptadores;
using src.Nucleo.Modelos;

namespace src.Nucleo.Repositorios
{
    public class ExemplarRepository : Repository<Exemplar>
    {
        public ExemplarRepository(BDAdapter contexto)
            : base(contexto)
        {
        }
    }
}