

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
            
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                
                modelBuilder.Entity<Movie>().HasData(new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "The Prestige",
                    Rating = 10
                });
            }
    }
}
