using designsoftware.nucleo.modelos;
using Microsoft.EntityFrameworkCore;

namespace designSoftware.Dados
{
    public class LivrosContexto : DbContext
    {
        public LivrosContexto(DbContextOptions<LivrosContexto> options)
            : base(options) {}

        public DbSet<Livro> Livros {get; set;}
    }
}