namespace eTickets.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        // RelationShips
        public List<ActorMovie> ActorMovies { get; set; }
    }
}
