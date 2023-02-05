using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ActorsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var actors = await dbContext.Actors.ToListAsync();
            return View(actors);
        }
    }
}
