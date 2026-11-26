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

        public override async Task<IEnumerable<Estudante>> GetAll()
        {
            return await _dbSet
                .Include(e => e.Reservas)
                .ToListAsync();
        }

        public override async Task<Estudante?> Get(object id)
        {
            return await _dbSet
                .Include(e => e.Reservas)
                .FirstOrDefaultAsync(e => e.Id == (int)id);
        }
    }
}