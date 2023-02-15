using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Cart
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext dbContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddItemToCartAsync(Movie movie)
        {
            var shoppingCartItem = await dbContext.ShoppingCartItems.FirstOrDefaultAsync(i => i.MovieId == movie.Id && i.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    MovieId = movie.Id,
                    Movie = movie,
                    Amount = 1,
                    ShoppingCartId = ShoppingCartId
                };

                await dbContext.ShoppingCartItems.AddAsync(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount += 1;
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = await dbContext.ShoppingCartItems.FirstOrDefaultAsync(i => i.MovieId == movie.Id && i.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount -= 1;
                }
                else
                {
                    dbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            await dbContext.SaveChangesAsync();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return (ShoppingCartItems = dbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).ToList());
        }

        public decimal GetShoppingCartTotal()
        {
            return dbContext.ShoppingCartItems
                    .Where(i => i.ShoppingCartId == ShoppingCartId)
                    .Sum(i => i.Movie.Price * i.Amount);
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await dbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).ToListAsync();
            dbContext.ShoppingCartItems.RemoveRange(items);
            await dbContext.SaveChangesAsync();
        }
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

    }
}
