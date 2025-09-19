using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GuessThatAsciiMon.Models;
using SixLabors.ImageSharp;

namespace GuessThatAsciiMon.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Pokemon> GetRandomPokemonAsync()
        {
            int randomId = Random.Shared.Next(1, 1025);
            return await GetPokemonByIdAsync(randomId);
        }
        public async Task<Pokemon> GetPokemonByIdAsync(int id)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(responseBody);
                return pokemon;
            }
            else
            {
                throw new HttpRequestException($"An Error Occurred: {response.StatusCode}");
            }
        }

        public async Task<byte[]> DownloadImageAsync(string imageUrl)
        {
            return await _httpClient.GetByteArrayAsync(imageUrl);
        }
    }
}