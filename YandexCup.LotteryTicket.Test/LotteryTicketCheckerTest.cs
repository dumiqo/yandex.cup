using System;
using System.Reflection.Emit;
using NUnit.Framework;

namespace YandexCup.LotteryTicket.Test
{
    [TestFixture]
    public class LotteryTicketCheckerTest
    {
        [TestCase(new int[] { 1, 2, 3, 4 ,5 ,6 ,7 }, new int[] { 1, 2, 3, 4 ,5 ,6 ,7 })]
        [TestCase(new int[] { 1, 2, 3, 4 ,5 ,6 ,7 }, new int[] { 1, 3, 32, 12 ,11 ,6 ,7 })]
        [TestCase(new int[] { 1, 2, 3, 4 ,5 ,6 ,7 }, new int[] { 12, 2, 22, 4 ,5 ,32 ,12 })]
        public void WinnerNimbersCheckTest(int[] winNumbers, int[] ticketNumbers)
        {
            var checker = new LotteryTicketChecker(winNumbers);
            Assert.IsTrue(checker.IsWinTicket(ticketNumbers));
        }
        
        [TestCase(new int[] { 22, 3 ,4 ,5 ,6 }, new int[] { 22, 3, 4, 21, 21})]
        public void NotWinnerNimbersCheckTest(int[] winNumbers, int[] ticketNumbers)
        {
            var checker = new LotteryTicketChecker(winNumbers);
            Assert.IsFalse(checker.IsWinTicket(ticketNumbers));
        }
    }
}