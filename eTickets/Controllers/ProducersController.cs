using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ProducersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var producers = await dbContext.Producers.ToListAsync();
            return View(producers);
        }
    }
}
