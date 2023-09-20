using ExampleGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleGraphQL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(s => s.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m => m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Director>()
                .HasMany(s => s.Videos)
                .WithOne(m => m.Director)
                .HasForeignKey(m => m.DirectorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        // DbSet es una colección de entidades que se pueden consultar, crear, actualizar y eliminar
        public virtual DbSet<Director> Directores { get; set; }
        public virtual DbSet<Streamer> Streamers { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
    }
}
