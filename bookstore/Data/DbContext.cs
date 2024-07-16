using bookstore.models;
using Microsoft.EntityFrameworkCore;

public class BookStoreContext : DbContext
{
    public DbSet<Books> Books { get; set; }

    public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       //Exemplo para MySQL
       optionsBuilder.UseMySql("Server=bookstore.cve68ca8cubo.us-east-1.rds.amazonaws.com;port=3306;database=Bookstore;user=dpernasc;password=Dce81125;", 
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
}
