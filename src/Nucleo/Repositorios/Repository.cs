using src.Nucleo.Portas;

namespace src.Nucleo.Repositorios
{
    public abstract class Repository<T> where T : class
    {
        protected readonly IBDPort _bdPort;

        protected Repository(IBDPort bdPort)
        {
            _bdPort = bdPort;
        }

        public virtual async Task<T?> Get(object id)
        {
            return await _bdPort.Get<T>(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _bdPort.GetAll<T>();
        }

        public virtual async Task Criar(T entidade)
        {
            await _bdPort.Criar(entidade);
        }

        public virtual async Task Atualizar(T entidade)
        {
            await _bdPort.Atualizar(entidade);
        }

        public virtual async Task Remover(T entidade)
        {
            await _bdPort.Remover(entidade);
        }
    }
}