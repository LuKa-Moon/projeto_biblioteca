using src.Nucleo.Modelos;
using Microsoft.EntityFrameworkCore;

namespace src.Adaptadores
{
    public class BDAdapter : DbContext
    {
        public BDAdapter(DbContextOptions<BDAdapter> options)
            : base(options) {}

        public DbSet<Estudante> Estudantes {get; set;}
        public DbSet<Livro> Livros {get; set;}
        public DbSet<Exemplar> Exemplares {get; set;}
        public DbSet<Reserva> Reservas {get; set;}

        // Emprestimos, Arquivistas, Assistentes...

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudante>()
                .HasKey(e => e.Grr);
            
            modelBuilder.Entity<Livro>()
                .HasMany(e => e.Exemplares)
                .WithOne(e => e.LivroBase)
                .HasForeignKey(e => e.LivroId)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}