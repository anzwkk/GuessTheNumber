using System;

namespace GuessTheNumber
{
    public class Game
    {
        private readonly Random _random;
        private readonly int _numberToGuess;
        private int _attempts;

        public Game()
        {
            _random = new Random();
            _numberToGuess = _random.Next(1, 101);
            _attempts = 0;
        }

        public string Guess(int userGuess)
        {
            _attempts++;

            if (userGuess < _numberToGuess)
                return "Загадане число більше!";
            if (userGuess > _numberToGuess)
                return "Загадане число менше!";
            return $"Вітаємо! Ви вгадали число за {_attempts} спроб.";
        }

        public int GetAttempts()
        {
            return _attempts;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            int userGuess = 0;
            string result;

            Console.WriteLine("Вгадай число від 1 до 100!");

            while (true)
            {
                Console.Write("Введіть ваше число: ");
                if (int.TryParse(Console.ReadLine(), out userGuess))
                {
                    result = game.Guess(userGuess);
                    Console.WriteLine(result);

                    if (result.Contains("Вітаємо"))
                        break;
                }
                else
                {
                    Console.WriteLine("Введіть коректне число.");
                }
            }
        }
    }
}
