using AppMobileChuckNorris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileChuckNorris.Services
{
    public interface IChuckService
    {
        Task<ChuckNorris> GetRandomJokeAsync();
    }

    public class ChuckService : IChuckService
    {
        private readonly HttpClient _httpClient;

        public ChuckService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ChuckNorris> GetRandomJokeAsync()
        {
            try
            {   
                var response = await _httpClient.GetAsync("https://api.chucknorris.io/jokes/random");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<ChuckNorris>(content);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
