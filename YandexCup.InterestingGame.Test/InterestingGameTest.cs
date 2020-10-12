using NUnit.Framework;

namespace YandexCup.InterestingGame.Test
{
    [TestFixture]
    public class InterestingGameTest
    {
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, 3, "Petya")]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, 10, "Draw")]
        [TestCase(new int[] {5, 10, 15, 20, 3, 6, 9, 25, 30, 12, 21, 24}, 4, "Vasya")]
        public void GetWinnerTest(int[] cards, int winnerScore, string winnerName)
        {
            var game = new InterestingGame();
            var playerName = game.GetWinner(cards, winnerScore);
            Assert.AreEqual(winnerName, playerName);
        }
    }
}