namespace GuessNumber.Domain;

public class RandomNumberGenerator : INumberGenerator
{
    private readonly Random _random = new();

    public int Generate(int min, int max) => _random.Next(min, max + 1);
}
