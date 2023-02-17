using eTickets.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Cinema Logo")]
        public string Logo { get; set; }

        [Required]
        [DisplayName("Cinema Name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
