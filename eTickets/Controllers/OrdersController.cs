using eTickets.Data.Cart;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace eTickets.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMovieService movieService;
        private readonly ShoppingCart shoppingCart;
        private readonly IOrderService orderService;

        public OrdersController(IMovieService movieService, ShoppingCart shoppingCart, IOrderService orderService)
        {
            this.movieService = movieService;
            this.shoppingCart = shoppingCart;
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = string.Empty;
            var orders = await orderService.GetUserOrdersAsync(userId);
            
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            shoppingCart.ShoppingCartItems = shoppingCart.GetShoppingCartItems();
            var response = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddToCartFromHome(int id)
        {
            bool inCart = shoppingCart.GetShoppingCartItems().Exists(i => i.MovieId == id);
            if (!inCart)
            {
                var movie = await movieService.GetByIdAsync(id);
                if (movie != null)
                {
                    await shoppingCart.AddItemToCartAsync(movie);
                }
            }

            return RedirectToAction("Index", "Movies");
        }

        public async Task<IActionResult> AddItemToShoppingCartAsync(int id)
        {
            var movie = await movieService.GetByIdAsync(id);
            if (movie != null)
            {
                await shoppingCart.AddItemToCartAsync(movie);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCartAsync(int id)
        {
            var movie = await movieService.GetByIdAsync(id);
            if (movie != null)
            {
                await shoppingCart.RemoveItemFromCart(movie);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrderAsync()
        {
            var items = shoppingCart.GetShoppingCartItems();
            string userId = string.Empty;
            string userEmail = string.Empty;

            await orderService.StoreOrderAsync(items, userId, userEmail);

            // Payment using Stripe
            var domain = "https://localhost:7134";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>(),
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                Mode = "payment",
                SuccessUrl = domain + "/Orders/OrderConfirmation",
                CancelUrl = domain + "/Orders/ShoppingCart"
            };

            items.ForEach(item =>
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Movie.Price * 100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Movie.Name
                        }
                    },
                    Quantity = item.Amount
                };

                options.LineItems.Add(sessionLineItem);
            });

            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);

            return new StatusCodeResult(303);
        }

        public async Task<IActionResult> OrderConfirmation()
        {
            await shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
    }
}
