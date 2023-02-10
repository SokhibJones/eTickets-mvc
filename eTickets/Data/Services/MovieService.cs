﻿using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        public MovieService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
