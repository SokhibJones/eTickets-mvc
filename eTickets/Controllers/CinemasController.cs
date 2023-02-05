using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CinemasController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var cinemas = await dbContext.Cinemas.ToListAsync();
            return View(cinemas);
        }
    }
}
