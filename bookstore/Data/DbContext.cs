using bookstore.models;
using Microsoft.EntityFrameworkCore;

public class BookStoreContext : DbContext
{
<<<<<<< HEAD
    public class BookstoreDbContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
        : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;database=bookstore;user=dnasc;password=81125;",
                new MySqlServerVersion(new Version(8, 0, 21)));
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(b => b.ID);
                entity.OwnsOne(b => b.Capa, cb =>
                {
                    cb.Property(c => c.ImagemNome).HasColumnName("ImagemNome");
                    cb.Property(c => c.ImagemTipo).HasColumnName("ImagemTipo");
                    cb.Property(c => c.ImagemTamanho).HasColumnName("ImagemTamanho");
                    cb.Property(c => c.Base64).HasColumnName("Base64");
                });
            });
        }

=======
    public DbSet<Books> Books { get; set; }

    public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       //Exemplo para MySQL
       optionsBuilder.UseMySql("Server=localhost;port=3306;database=bookstore;user=dnasc;password=81125;", 
        new MySqlServerVersion(new Version(8, 0, 21)));
>>>>>>> a84e7b30727f784cac4959528ad35dc87342afda

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Books>(entity =>
        {
            entity.HasKey(b => b.ID);
            entity.OwnsOne(b => b.Capa, cb =>
            {
                cb.Property(c => c.ImagemNome).HasColumnName("ImagemNome");
                cb.Property(c => c.ImagemTipo).HasColumnName("ImagemTipo");
                cb.Property(c => c.ImagemTamanho).HasColumnName("ImagemTamanho");
                cb.Property(c => c.Base64).HasColumnName("Base64");
            });
        });
    }
}
