using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);
        }
        public DbSet<Filme> filmes { get; set; }
        public DbSet<Cinema> cinemas { get; set; }
        public DbSet<Endereco> enderecos { get; set; }
    }
}
