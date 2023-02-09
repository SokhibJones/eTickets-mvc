using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService cinemaService;

        public CinemasController(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            var cinemas = await cinemaService.GetAllAsync();
            return View(cinemas);
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            var cinema = await cinemaService.GetByIdAsync(id);
            if (cinema is null)
            {
                return View("NotFound");
            }

            return View(cinema);
        }
    }
}
