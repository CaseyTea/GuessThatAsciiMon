
using GuessThatAsciiMon.Models;

namespace GuessThatAsciiMon.Services
{
    public interface IPokemonService
    {
        Task<Pokemon> GetRandomPokemonAsync();
        Task<Pokemon> GetPokemonByIdAsync(int id);
        Task<byte[]> DownloadImageAsync(string imageUrl); 
    }
}