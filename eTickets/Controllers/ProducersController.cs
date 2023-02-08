using eTickets.Data.Services;
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

        public async Task<IActionResult> IndexAsync()
        {
            var producers = await producerService.GetAllAsync();
            return View(producers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var producer = await producerService.GetByIdAsync(id);
            if (producer is null)
            {
                return View("NotFound");
            }

            return View(producer);
        }
    }
}
