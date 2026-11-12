namespace GuessNumber.Domain;

public interface INumberGenerator
{
    int Generate(int min, int max);
}