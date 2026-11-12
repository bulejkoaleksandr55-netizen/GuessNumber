using GuessNumber.Domain;

var generator = new RandomNumberGenerator();
var game = new GameLogic(generator, 1, 100, 7);

Console.WriteLine("Угадайте число от 1 до 100. У вас 7 попыток.");

while (true)
{
    Console.Write("Введите число: ");
    if (!int.TryParse(Console.ReadLine(), out int guess))
    {
        Console.WriteLine("Ошибка: введите число.");
        continue;
    }

    if (game.MakeGuess(guess)) break;

    if (game.CurrentAttempt >= game.MaxAttempts)
    {
        Console.WriteLine($"Вы проиграли! Было загадано: {game.TargetNumber}");
        break;
    }
}
