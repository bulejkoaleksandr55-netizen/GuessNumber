namespace GuessNumber.Domain;

public class GameLogic
{
    public int TargetNumber { get; }
    public int MaxAttempts { get; }
    public int CurrentAttempt { get; private set; }

    public event EventHandler<GameEventArgs>? OnMessage;

    public GameLogic(INumberGenerator generator, int min, int max, int maxAttempts)
    {
        TargetNumber = generator.Generate(min, max);
        MaxAttempts = maxAttempts;
    }

    public bool MakeGuess(int guess)
    {
        CurrentAttempt++;
        int attemptsLeft = MaxAttempts - CurrentAttempt;

        if (guess == TargetNumber)
        {
            OnMessage?.Invoke(this, new GameEventArgs("Вы угадали!", attemptsLeft, true));
            return true;
        }

        string hint = guess < TargetNumber ? "Больше" : "Меньше";
        OnMessage?.Invoke(this, new GameEventArgs($"Неверно. {hint}", attemptsLeft));
        return false;
    }
}