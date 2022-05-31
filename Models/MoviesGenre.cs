using System.ComponentModel.DataAnnotations;

namespace CinemaCity.Models
{
    public class MoviesGenre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public int GenreId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
