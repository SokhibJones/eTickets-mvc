using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Order>> GetUserOrdersAsync(string userId)
        {
            return await dbContext.Orders.Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> shoppingCartItems, string userId, string userEmail)
        {
            var order = new Order
            {
                UserId = userId,
                Email = userEmail
            };

            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();

            shoppingCartItems.ForEach(async item =>
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    MovieId = item.MovieId,
                    Amount = item.Amount,
                    Price = item.Movie.Price
                };

                await dbContext.AddAsync(orderItem);
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
