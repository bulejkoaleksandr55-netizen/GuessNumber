namespace GuessNumber.Domain;

public class GameEventArgs : EventArgs
{
    public string Message { get; }
    public int AttemptsLeft { get; }
    public bool IsWin { get; }

    public GameEventArgs(string message, int attemptsLeft = -1, bool isWin = false)
    {
        Message = message;
        AttemptsLeft = attemptsLeft;
        IsWin = isWin;
    }
}
