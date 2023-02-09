using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService producerService;

        public ProducersController(IProducerService producerService)
        {
            this.producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var producers = await producerService.GetAllAsync();
            return View(producers);
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            var producer = await producerService.GetByIdAsync(id);
            if (producer is null)
            {
                return View("NotFound");
            }

            return View(producer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreateAsync([Bind("ProfilePictureUrl", "FullName", "Bio")]Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await producerService.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            var producer = await producerService.GetByIdAsync(id);
            return producer is not null ? View(producer) : View("NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            if (id == producer.Id)
            {
                await producerService.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }

            return View(producer);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var producer = await producerService.GetByIdAsync(id);
            return producer is not null ? View(producer) : View("NotFound");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmationAsync(int id)
        {
            var producer = await producerService.GetByIdAsync(id);
            if (producer is null)
            {
                return View("NotFound");
            }

            await producerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
