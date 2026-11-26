namespace src.Portas
{
    public interface BDPort
    {
        Task<T?> Get<T>(object id) where T : class;
        Task<IEnumerable<T>> GetAll<T>() where T : class;

        Task<T?> GetComRelacionamentos<T>(object id)
            where T : class;

        Task<IEnumerable<T>> GetTodosComRelacionamentos<T>()
            where T : class;
            
        Task Criar<T>(T entidade) where T : class;
        Task Atualizar<T>(T entidade) where T : class;
        Task Remover<T>(T entidade) where T : class;
    }
}