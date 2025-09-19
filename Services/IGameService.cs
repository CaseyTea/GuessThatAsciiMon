
using GuessThatAsciiMon.Models;

namespace GuessThatAsciiMon.Services
{
    public interface IGameService
    {
        bool CheckGuess(string guess, string pokemonName);
        GameResult ProcessGuess(string guess, Pokemon pokemon);
    }
}