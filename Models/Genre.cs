using System.ComponentModel.DataAnnotations;

namespace CinemaCity.Models
{
    public class Genre
    {
        public Genre()
        {
            MoviesGenres = new HashSet<MoviesGenre>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<MoviesGenre> MoviesGenres { get; set; }
    }
}
