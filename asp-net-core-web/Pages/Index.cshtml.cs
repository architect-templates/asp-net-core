using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using asp_net_core_shared;

namespace asp_net_core_web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public IEnumerable<Movie>? MovieList { get; set; }

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnPost()
        {
            var httpClient = _httpClientFactory.CreateClient("api");
            JsonContent content = JsonContent.Create(new Movie
            {
                Name = Request.Form["MovieName"],
                Rating = int.Parse(Request.Form["MovieRating"])
            });
            await httpClient.PostAsync("/movie", content);
            await OnGet();
        }

        public async Task OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("api");

            var httpMovieResponse = await httpClient.GetAsync("/movie");
            if (httpMovieResponse.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpMovieResponse.Content.ReadAsStreamAsync();

                MovieList = await JsonSerializer.DeserializeAsync
                    <IEnumerable<Movie>>(contentStream, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
