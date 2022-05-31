using Microsoft.EntityFrameworkCore;

namespace CinemaCity.Models
{
    public class CinemaCityAPIContext : DbContext
    { 
        public virtual DbSet<Premiere> Premieres { get; set; }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Actor> Actors { get; set; }

        public virtual DbSet<MoviesGenre> MoviesGenres { get; set; }

        public virtual DbSet<MoviesActorsPremiere> MoviesActorsPremieres { get; set; }

        public CinemaCityAPIContext(DbContextOptions<CinemaCityAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
