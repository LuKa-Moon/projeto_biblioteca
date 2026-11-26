using src.Nucleo.Modelos;
using src.Portas;

namespace src.Nucleo.Repositorios
{
    public class LivroRepository : Repository<Livro>
    {
        public LivroRepository(BDPort bdPort)
            : base(bdPort)
        {
        }

        public override async Task<IEnumerable<Livro>> GetAll()
        {
            return await _bdPort.GetTodosComRelacionamentos<Livro>();
        }

        public override async Task<Livro?> Get(object id)
        {
            return await _bdPort.GetComRelacionamentos<Livro>(id);
        }
    }
}