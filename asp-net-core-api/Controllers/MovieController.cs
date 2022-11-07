
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_core_api.Contexts;
using asp_net_core_shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace asp_net_core_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly ILogger<MovieController> _logger;
        private readonly MovieContext _movieContext;

        public MovieController(ILogger<MovieController> logger, MovieContext movieContext)
        {
            _logger = logger;
            _movieContext = movieContext;
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _movieContext.Movies.ToList();
        }

        [HttpPost]
        public async Task<Movie> Post(Movie movie)
        {
            Console.WriteLine("Creating Movie: " + movie.Name);
            movie.Id = Guid.NewGuid().ToString();
            await _movieContext.Movies.AddAsync(movie);
            await _movieContext.SaveChangesAsync();
            return movie;
        }

        [HttpDelete]
        public async Task Delete(Movie movie)
        {
            _movieContext.Movies.Remove(movie);
            _movieContext.Movies.Remove(movie);
            await _movieContext.SaveChangesAsync();
        }
    }
}
