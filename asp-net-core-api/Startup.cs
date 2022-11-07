using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_core_api.Contexts;
using asp_net_core_shared;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal.TypeHandlers;

namespace asp_net_core_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var host = Environment.GetEnvironmentVariable("DB_CONNECTION_HOST");
            var username = Environment.GetEnvironmentVariable("DB_CONNECTION_USERNAME");
            var password = Environment.GetEnvironmentVariable(("DB_CONNECTION_PASSWORD"));
            var database = Environment.GetEnvironmentVariable(("DB_CONNECTION_DATABASE"));
            var connectionString = $"Host={host};Database={database};Username={username};Password={password}";
            services.AddDbContext<MovieContext>(options =>
                options.UseNpgsql(connectionString));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Use the dependency injection framework to get access to the MovieContext
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MovieContext>();
                // Call migrate to make sure the database is up to date.
                context.Database.Migrate();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Console.WriteLine("Finished configuring api server");
        }
    }
}
