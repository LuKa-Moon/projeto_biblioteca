using src.nucleo.modelos;
using Microsoft.EntityFrameworkCore;

namespace src.Dados
{
    public class EstudantesContexto : DbContext
    {
        public EstudantesContexto(DbContextOptions<EstudantesContexto> options)
            : base(options) {}

        public DbSet<Estudante> Estudantes {get; set;}
    }
}