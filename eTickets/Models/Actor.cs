using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        public string Bio { get; set; } = string.Empty;
    }
}
