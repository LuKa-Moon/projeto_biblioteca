using src.Nucleo.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace src.Portas
{
    public interface LivroPort
    {
        Task<ActionResult<IEnumerable<Livro>>> GetLivros();

        // Outras acoes para livro
    }
}