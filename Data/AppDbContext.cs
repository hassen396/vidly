using Microsoft.EntityFrameworkCore;
using vidly.Models;

namespace vidly.Data
{
    public class AppDbContext : DbContext
    {
        //constructor for dbcontext that takes options
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Genre)
            .WithMany() // Assuming Genre doesn't have a collection of Movies
            .HasForeignKey(m => m.GenreId);

        // Other configurations...
    }

    }
}