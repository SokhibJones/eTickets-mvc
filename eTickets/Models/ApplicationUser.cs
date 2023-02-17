using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Full Name")]
        [StringLength(256)]
        public string FullName { get; set; }
    }
}
