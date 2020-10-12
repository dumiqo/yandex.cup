using System;
using System.Linq;

namespace YandexCup.InterestingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstString = Console.ReadLine();
            var secondString = Console.ReadLine();

            var firstParameters = firstString.Split(' ')
                .Select(int.Parse)
                .ToArray();
            
            var cardValue = secondString.Split(' ')
                .Select(int.Parse)
                .ToArray();
            
            var game = new InterestingGame();
            var gameWinner = game.GetWinner(cardValue, firstParameters[0]);
            Console.WriteLine(gameWinner);
        }
    }

    public class InterestingGame
    {
        private const string _firstPlayerName = "Petya";
        private const int _firstPlayerNumber = 3;
        private const string _secondPlayerName = "Vasya";
        private const int _secondPlayerNumber = 5;
        private string _noWinner = "Draw";

        public string GetWinner(int[] cards, int winScore)
        {
            var petya = new Player(_firstPlayerNumber, _firstPlayerName);
            var vasya = new Player(_secondPlayerNumber, _secondPlayerName);
            var players = new[] {petya, vasya};
            cards = cards.Where(x => petya.IsRoundWin(x) != vasya.IsRoundWin(x))
                .ToArray();

            foreach (var card in cards)
            {
                var winnerPlayer = players.First(x => x.IsRoundWin(card));
                winnerPlayer.IncreaseScore();
                if (winnerPlayer.Score >= winScore)
                    return winnerPlayer.Name;
            }

            return _noWinner;
        }
    }

    public class Player
    {
        private int _number;
        private string _name;
        private int _score;

        public Player(int number, string name, int score = 0)
        {
            _number = number;
            _name = name;
            _score = score;
        }

        public bool IsRoundWin(int value)
        {
            return value % _number == 0;
        }

        public void IncreaseScore()
        {
            _score++;
        }
        
        public string Name => _name;
        public int Score => _score;
    }
}