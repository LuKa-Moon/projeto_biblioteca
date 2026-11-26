using Microsoft.EntityFrameworkCore;
using src.Adaptadores;

namespace src.Nucleo.Repositorios
{
    public abstract class Repository<T> where T : class
    {
        protected readonly BDAdapter _contexto;
        protected readonly DbSet<T> _dbSet;

        protected Repository(BDAdapter contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<T>();
        }

        public virtual async Task<T?> Get(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task Criar(T entidade)
        {
            await _dbSet.AddAsync(entidade);
            await _contexto.SaveChangesAsync();
        }

        public virtual async Task Atualizar(T entidade)
        {
            _dbSet.Update(entidade);
            await _contexto.SaveChangesAsync();
        }

        public virtual async Task Remover(T entidade)
        {
            _dbSet.Remove(entidade);
            await _contexto.SaveChangesAsync();
        }
    }
}