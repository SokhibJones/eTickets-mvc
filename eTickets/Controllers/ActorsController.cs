using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService actorService;

        public ActorsController(IActorService actorService)
        {
            this.actorService = actorService;
        }

        public async Task<IActionResult> Index()
        {
            var actors = await actorService.GetAllAsync();
            return View(actors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([Bind("ProfilePictureUrl,FullName,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await actorService.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            var actor = await actorService.GetByIdAsync(id);
            if (actor is null)
            {
                return View("NotFound");
            }

            return View(actor);
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            var actor = await actorService.GetByIdAsync(id);
            if (actor is null)
            {
                return View("NotFound");
            }

            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await actorService.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var actor = await actorService.GetByIdAsync(id);
            if (actor is null)
            {
                return View("NotFound");
            }

            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            await actorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
