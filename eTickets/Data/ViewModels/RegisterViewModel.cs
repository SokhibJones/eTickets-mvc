using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
