using Microsoft.EntityFrameworkCore;
using BooksApplication.Models;
namespace BooksApplication
{
    public class CollectionContext:DbContext
    {
        public DbSet<Book>books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string config = @"server=localhost;port=3306;user=root;password=root123;database=dotnet";
            optionsBuilder.UseMySQL(config);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>(e =>
            {
                e.HasKey(e=> e.Id);
                e.Property(e=>e.Title).IsRequired();
                e.Property(e => e.Author).IsRequired();
                e.Property(e => e.Price).IsRequired();

            });
            modelBuilder.Entity<Book>().ToTable("books");
        }
    }
}
