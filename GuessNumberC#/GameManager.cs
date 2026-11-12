using GuessNumber.Domain;

namespace GuessNumber.Application;

public class GameManager
{
    private readonly INumberGenerator _generator;
    private GameLogic? _currentGame;

    public GameManager(INumberGenerator generator)
    {
        _generator = generator;
    }

    public void Start()
    {
        Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");

        while (true)
        {
            Console.WriteLine("\nВыберите уровень сложности:");
            Console.WriteLine("1. Легкий (1-50, 10 попыток)");
            Console.WriteLine("2. Средний (1-100, 7 попыток)");
            Console.WriteLine("3. Сложный (1-200, 5 попыток)");
            Console.WriteLine("0. Выход");

            string? choice = Console.ReadLine();
            if (choice == "0") break;

            int maxRange, attempts;
            switch (choice)
            {
                case "1": maxRange = 50; attempts = 10; break;
                case "2": maxRange = 100; attempts = 7; break;
                case "3": maxRange = 200; attempts = 5; break;
                default:
                    Console.WriteLine("Неверный ввод.");
                    continue;
            }

            PlayGame(maxRange, attempts);
        }
    }

    private void PlayGame(int max, int attempts)
    {
        _currentGame = new GameLogic(_generator, 1, max, attempts);

        _currentGame.OnMessage += (sender, e) =>
        {
            Console.WriteLine(e.Message);
            if (e.AttemptsLeft >= 0)
                Console.WriteLine($"Осталось попыток: {e.AttemptsLeft}");
        };

        bool isWin = false;
        while (!isWin)
        {
            Console.Write("Введите число: ");
            if (!int.TryParse(Console.ReadLine(), out int guess))
            {
                Console.WriteLine("Ошибка: введите число.");
                continue;
            }

            isWin = _currentGame.MakeGuess(guess);

            if (!isWin && _currentGame.CurrentAttempt >= _currentGame.MaxAttempts)
            {
                Console.WriteLine($"Вы проиграли! Загаданное число было: {_currentGame.TargetNumber}");
                break;
            }
        }
    }
}