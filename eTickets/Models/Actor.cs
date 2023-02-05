using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Bio { get; set; }

        // RelationShips
        public virtual List<ActorMovie> ActorMovies { get; set; }
    }
}
