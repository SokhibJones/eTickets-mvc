using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public MoviesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var movies = await dbContext.Movies.ToListAsync();
            return View(movies);
        }
    }
}
