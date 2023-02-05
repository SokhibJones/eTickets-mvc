﻿using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer
    {
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Bio { get; set; }

        // Relationships
        public virtual List<Movie> Movies { get; set; }
    }
}
