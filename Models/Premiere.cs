using System.ComponentModel.DataAnnotations;

namespace CinemaCity.Models
{
    public class Premiere
    {
        public Premiere()
        {
            MoviesActorsPremieres = new HashSet<MoviesActorsPremiere>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartPremiere { get; set; }

        [Required]
        public DateTime EndPremiere { get; set; }

        public virtual ICollection<MoviesActorsPremiere> MoviesActorsPremieres { get; set; }
    }
}
