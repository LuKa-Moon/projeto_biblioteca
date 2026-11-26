using src.Adaptadores;
using src.Nucleo.Modelos;

namespace src.Nucleo.Repositorios
{
    public class EstudanteRepository : Repository<Estudante>
    {
        public EstudanteRepository(BDAdapter contexto)
            : base(contexto)
        {
        }
    }
}