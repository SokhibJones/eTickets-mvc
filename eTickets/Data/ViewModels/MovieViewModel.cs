using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Movie Description")]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        [Display(Name = "Movie Poster Url")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Select movie category")]
        public int MovieCategoryId { get; set; }

        [Required]
        [Display(Name = "Select cinema")]
        public int CinemaId { get; set; }

        [Required]
        [Display(Name = "Select movie producer")]
        public int ProducerId { get; set; }

        [Required]
        [Display(Name = "Select actor(s)")]
        public List<int> ActorIds { get; set; }
    }
}
