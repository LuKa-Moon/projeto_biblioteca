using src.Adaptadores;
using src.Nucleo.Modelos;

namespace src.Nucleo.Repositorios
{
    public class ReservaRepository : Repository<Reserva>
    {
        public ReservaRepository(BDAdapter contexto)
            : base(contexto)
        {
        }
    }
}