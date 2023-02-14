using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await movieService.GetAllAsync();
            return View(movies);
        }

        public async Task<IActionResult> SearchAsync(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return RedirectToAction(nameof(Index));
            }

            var allMovies = await movieService.GetAllAsync();
            var filteredResult = allMovies.Where(m => m.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase) || m.Description.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
            return View(nameof(Index), filteredResult);
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            var movie = await movieService.GetByIdAsync(id);
            if (movie is null)
            {
                return View("NotFound");
            }

            return View(movie);
        }

        public async Task<IActionResult> CreateAsync()
        {
            var movieDropdownsData = await movieService.GetMovieDropdownsAsync();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.MovieCategories = new SelectList(movieDropdownsData.MovieCategories, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(MovieViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await movieService.GetMovieDropdownsAsync();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.MovieCategories = new SelectList(movieDropdownsData.MovieCategories, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await movieService.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            var movie = await movieService.GetByIdAsync(id);
            if (movie is null)
            {
                return View("NotFound");
            }

            var response = new MovieViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                Price = movie.Price,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                ImageUrl = movie.ImageUrl,
                MovieCategoryId = movie.MovieCategoryId,
                CinemaId = movie.CinemaId,
                ProducerId = movie.ProducerId,
                ActorIds = movie.ActorMovies.Select(m => m.ActorId).ToList()
            };

            var movieDropdownsData = await movieService.GetMovieDropdownsAsync();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.MovieCategories = new SelectList(movieDropdownsData.MovieCategories, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, MovieViewModel movie)
        {
            if (id != movie.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await movieService.GetMovieDropdownsAsync();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.MovieCategories = new SelectList(movieDropdownsData.MovieCategories, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await movieService.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
