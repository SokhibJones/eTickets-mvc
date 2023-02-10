using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([Bind("Logo", "Name", "Description")]Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await cinemaService.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
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

        public async Task<IActionResult> EditAsync(int id)
        {
            var cinema = await cinemaService.GetByIdAsync(id);
            if (cinema is null)
            {
                return View("NotFound");
            }

            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, Cinema cinema)
        {
            if (!ModelState.IsValid || id != cinema.Id)
            {
                return View(cinema);
            }

            await cinemaService.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var cinema = await cinemaService.GetByIdAsync(id);
            if (cinema is null)
            {
                return View("NotFound");
            }

            return View(cinema);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmationAsync(int id)
        {
            var cinema = await cinemaService.GetByIdAsync(id);
            if (cinema is null)
            {
                return View("NotFound");
            }

            await cinemaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
