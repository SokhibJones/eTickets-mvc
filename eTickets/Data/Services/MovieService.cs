using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace eTickets.Data.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly ApplicationDbContext dbContext;

        public MovieService(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddNewMovieAsync(MovieViewModel movie)
        {
            var newMovie = new Movie
            {
                Name = movie.Name,
                Description = movie.Description,
                Price = movie.Price,
                ImageUrl = movie.ImageUrl,
                CinemaId = movie.CinemaId,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                MovieCategoryId = movie.MovieCategoryId,
                ProducerId = movie.ProducerId
            };

            await dbContext.AddAsync(newMovie);
            await dbContext.SaveChangesAsync();

            // Adding movie actors
            movie.ActorIds.ForEach(async actorId => await dbContext.ActorsMovies.AddAsync(
                new ActorMovie
                {
                    ActorId = actorId,
                    MovieId = newMovie.Id
                }));
            await dbContext.SaveChangesAsync();
        }

        public async Task<MovieDropdownsViewModel> GetMovieDropdownsAsync()
        {
            var result = new MovieDropdownsViewModel
            {
                Actors = await dbContext.Actors.OrderBy(a => a.FullName).ToListAsync(),
                Cinemas = await dbContext.Cinemas.OrderBy(c => c.Name).ToListAsync(),
                MovieCategories = await dbContext.MovieCategories.OrderBy(c => c.Name).ToListAsync(),
                Producers = await dbContext.Producers.OrderBy(p => p.FullName).ToListAsync()
            };

            return result;
        }

        public async Task UpdateMovieAsync(MovieViewModel movie)
        {
            var updatingMovie = await dbContext.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);
            if (updatingMovie != null)
            {
                updatingMovie.Name = movie.Name;
                updatingMovie.Description = movie.Description;
                updatingMovie.Price = movie.Price;
                updatingMovie.ImageUrl = movie.ImageUrl;
                updatingMovie.CinemaId = movie.CinemaId;
                updatingMovie.StartDate = movie.StartDate;
                updatingMovie.EndDate = movie.EndDate;
                updatingMovie.MovieCategoryId = movie.MovieCategoryId;
                updatingMovie.ProducerId = movie.ProducerId;

                await dbContext.SaveChangesAsync();
            }

            // Remove existing actors of the movie
            var existingActors = dbContext.ActorsMovies.Where(m => m.MovieId == movie.Id);
            dbContext.ActorsMovies.RemoveRange(existingActors);
            await dbContext.SaveChangesAsync();

            // Add new movie actors
            movie.ActorIds.ForEach(async actorId => await dbContext.ActorsMovies.AddAsync(
                new ActorMovie
                {
                    ActorId = actorId,
                    MovieId = movie.Id
                }));
            await dbContext.SaveChangesAsync();
        }
    }
}
