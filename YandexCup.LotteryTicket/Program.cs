using System;
using System.Linq;

namespace YandexCup.LotteryTicket
{
    class Program
    {
        static void Main()
        {
            var winNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var checker = new LotteryTicketChecker(winNumbers);
            
            var ticketsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ticketsCount; i++)
            {
                var ticketNumbers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                
                Console.WriteLine(checker.IsWinTicket(ticketNumbers) ? "Lucky" : "Unlucky");
            }
        }
    }

    public class LotteryTicketChecker
    {
        private int[] _winNumbers;
        public LotteryTicketChecker(int[] winNumbers)
        {
            _winNumbers = winNumbers.Distinct().ToArray();
        }

        public bool IsWinTicket(int[] ticketNumbers)
        {
            return ticketNumbers
                       .Distinct()
                       .Concat(_winNumbers)
                       .GroupBy(x => x)
                       .Count(x => Enumerable.Count<int>(x) >= 2)
                   >= 3;
        }
    }
}