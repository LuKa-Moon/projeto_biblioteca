using src.Nucleo.Modelos;
using src.Nucleo.Portas;
using Microsoft.EntityFrameworkCore;

namespace src.Adaptadores
{
    public class BDAdapter : DbContext, BDPort
    {
        public BDAdapter(DbContextOptions<BDAdapter> options)
            : base(options) {}

        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Exemplar> Exemplares { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        // Buscar por ID
        public async Task<T?> Get<T>(object id) where T : class
        {
            return await Set<T>().FindAsync(id);
        }

        // Buscar todos
        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            return await Set<T>().ToListAsync();
        }

        // Criar
        public async Task Criar<T>(T entidade) where T : class
        {
            await Set<T>().AddAsync(entidade);
            await SaveChangesAsync();
        }

        // Atualizar
        public async Task Atualizar<T>(T entidade) where T : class
        {
            Set<T>().Update(entidade);
            await SaveChangesAsync();
        }

        // Remover
        public async Task Remover<T>(T entidade) where T : class
        {
            Set<T>().Remove(entidade);
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudante>()
                .HasKey(e => e.Grr);

            modelBuilder.Entity<Livro>()
                .HasMany(l => l.Exemplares)
                .WithOne(e => e.LivroBase)
                .HasForeignKey(e => e.LivroId)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}