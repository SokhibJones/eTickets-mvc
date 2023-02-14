using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
        Task<MovieDropdownsViewModel> GetMovieDropdownsAsync();
        Task AddNewMovieAsync(MovieViewModel movie);
        Task UpdateMovieAsync(MovieViewModel movie);
    }
}
