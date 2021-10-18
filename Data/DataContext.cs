using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Entities;

namespace Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roleAdmin = new IdentityRole()
            {
                Id = "",
                Name = "admin",
                NormalizedName = "admin"
            };

            modelBuilder.Entity<IdentityRole>().HasData(roleAdmin);
            
            modelBuilder.Entity<MovieCharacter>()
                .HasKey(x => new { x.MovieId, x.CharacterId });
            
            modelBuilder.Entity<MovieGenre>()
                .HasKey(x => new { x.MovieId, x.GenreId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieCharacter> MovieCharacters { get; set; }
    }
}
