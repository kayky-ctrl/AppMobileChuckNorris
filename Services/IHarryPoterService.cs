using AppMobileChuckNorris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileChuckNorris.Services
{
    public interface IHarryPoterService
    {
        Task<HarryPotterCharacter?> GetRandomCharacterAsync();
    }

    public class HarryPoterService : IHarryPoterService
    {
        private readonly HttpClient _httpClient;

        public HarryPoterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HarryPotterCharacter?> GetRandomCharacterAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<HarryPotterCharacter>("https://potterapi-fedeperin.vercel.app/en/characters/random");
            }
            catch
            {
                return null;
            }
        }
    }
}
