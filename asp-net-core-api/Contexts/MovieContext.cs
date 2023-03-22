

using System;
using asp_net_core_shared;
using Microsoft.EntityFrameworkCore;

namespace asp_net_core_api.Contexts
{
    public class MovieContext : DbContext
    {
            public DbSet<Movie> Movies { get; set; }

            public MovieContext(DbContextOptions<MovieContext> options)
                : base(options)
            {

            }
    }
}
