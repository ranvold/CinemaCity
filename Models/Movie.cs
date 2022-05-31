using System.ComponentModel.DataAnnotations;

namespace CinemaCity.Models
{
    public class Movie
    {
        public Movie()
        {
            MoviesGenres = new HashSet<MoviesGenre>();
            MoviesActorsPremieres = new HashSet<MoviesActorsPremiere>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public virtual ICollection<MoviesGenre> MoviesGenres { get; set; }
        public virtual ICollection<MoviesActorsPremiere> MoviesActorsPremieres { get; set; }
    }
}

