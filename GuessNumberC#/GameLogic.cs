namespace GuessNumber.Domain;

public class GameLogic
{
    public int TargetNumber { get; }
    public int MaxAttempts { get; }
    public int CurrentAttempt { get; private set; }

    public GameLogic(INumberGenerator generator, int min, int max, int maxAttempts)
    {
        TargetNumber = generator.Generate(min, max);
        MaxAttempts = maxAttempts;
        CurrentAttempt = 0;
    }

    public bool MakeGuess(int guess)
    {
        CurrentAttempt++;
        int attemptsLeft = MaxAttempts - CurrentAttempt;

        if (guess == TargetNumber)
        {
            Console.WriteLine("Вы угадали!");
            return true;
        }

        string hint = guess < TargetNumber ? "Больше" : "Меньше";
        Console.WriteLine($"Неверно. {hint}. Осталось попыток: {attemptsLeft}");
        return false;
    }
}