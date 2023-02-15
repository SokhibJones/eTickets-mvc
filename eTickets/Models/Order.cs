namespace eTickets.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
