using designsoftware.nucleo.modelos;
using Microsoft.EntityFrameworkCore;

namespace designSoftware.Dados
{
    public class EstudantesContexto : DbContext
    {
        public EstudantesContexto(DbContextOptions<EstudantesContexto> options)
            : base(options) {}

        public DbSet<Estudante> Estudantes {get; set;}
    }
}