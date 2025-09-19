
using GuessThatAsciiMon.Models;

namespace GuessThatAsciiMon.Services
{
    public class GameService : IGameService
    {
        public GameResult ProcessGuess(string guess, Pokemon pokemon)
        {
            bool isCorrect = guess.ToLower() == pokemon.Name?.ToLower();

            return new GameResult
            {
                IsCorrect = isCorrect,
                UserGuess = guess,
                CorrectAnswer = pokemon.Name ?? "Nothing?",
                Message = isCorrect ? "Correct!" : $"Wrong, It's actually {pokemon.Name}"
            };
        }

        public bool CheckGuess(string guess, string pokemonName)
        {
            return guess.ToLower() == pokemonName.ToLower();
        }
    }
}