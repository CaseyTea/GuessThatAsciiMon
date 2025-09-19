namespace GuessThatAsciiMon.Models;

public class GameResult
{
    public bool IsCorrect { get; set; }
    public string UserGuess { get; set; } = string.Empty;
    public string CorrectAnswer { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime GuessedAt { get; set; } = DateTime.Now;
}