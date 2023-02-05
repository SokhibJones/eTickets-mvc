namespace eTickets.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Relationships
        // MovieCategory relationship
        public int MovieCategoryId { get; set; }
        public virtual MovieCategory MovieCategory { get; set; }
        
        // Cinema relationship
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }
        
        // Producer relationship
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }

        public virtual List<ActorMovie> ActorMovies { get; set; }
    }
}
