using src.nucleo.modelos;
using Microsoft.EntityFrameworkCore;

namespace src.Dados
{
    public class LivrosContexto : DbContext
    {
        public LivrosContexto(DbContextOptions<LivrosContexto> options)
            : base(options) {}

        public DbSet<Livro> Livros {get; set;}
    }
}