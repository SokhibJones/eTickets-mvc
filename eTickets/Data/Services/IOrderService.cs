using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> shoppingCartItems, string userId, string userEmail);
        Task<List<Order>> GetUserOrdersAsync(string userId);
    }
}
