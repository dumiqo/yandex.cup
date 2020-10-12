using System;
using System.Linq;

namespace YandexCup.AlarmClocks
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
            
            var alarmTimes = secondString.Split(' ')
                .Select(ulong.Parse)
                .ToArray();
            
            var calculator = new AlarmClocksCalculator();
            var wakeUpTime = calculator.CalculateWakeUpTime(alarmTimes, firstParameters[1], firstParameters[2]);
            Console.WriteLine(wakeUpTime);
        }
    }

    public class AlarmClocksCalculator
    {
        public ulong CalculateWakeUpTime(ulong[] startTime, int step, int maxAlertNumer)
        {
            return startTime.SelectMany(x => Enumerable.Range(0, maxAlertNumer)
                    .Select(y => (ulong) (step * y) + x))
                .Distinct()
                .OrderBy(x => x)
                .Skip(maxAlertNumer - 1)
                .First();
        }
    }
}