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

        public override async Task<IEnumerable<Livro>> GetAll()
        {
            return await _dbSet
                .Include(l => l.Exemplares)
                .ToListAsync();
        }

        public override async Task<Livro?> Get(object id)
        {
            return await _dbSet
                .Include(l => l.Exemplares)
                .FirstOrDefaultAsync(l => l.Id == (int)id);
        }
    }
}