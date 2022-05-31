using System.ComponentModel.DataAnnotations;

namespace CinemaCity.Models
{
    public class MoviesActorsPremiere
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public int ActorId { get; set; }

        [Required]
        public int PremiereId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Actor Actor { get; set; }

        public virtual Premiere Premiere { get; set; }
    }
}
