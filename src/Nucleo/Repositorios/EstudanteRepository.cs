using src.Nucleo.Modelos;
using src.Portas;

namespace src.Nucleo.Repositorios
{
    public class EstudanteRepository : Repository<Estudante>
    {
        public EstudanteRepository(BDPort bdPort)
            : base(bdPort)
        {
        }

        public override async Task<IEnumerable<Estudante>> GetAll()
        {
            return await _bdPort.GetTodosComRelacionamentos<Estudante>();
        }

        public override async Task<Estudante?> Get(object id)
        {
            return await _bdPort.GetComRelacionamentos<Estudante>(id);
        }
    }
}