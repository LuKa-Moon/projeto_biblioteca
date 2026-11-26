using src.Nucleo.Modelos;

namespace src.Nucleo.IServicos
{
    public interface ILivroService
    {
        Task<IEnumerable<Livro>> BuscarLivros();
        Task<Livro?> BuscarLivroId(int id);
    }
}