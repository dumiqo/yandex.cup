using NUnit.Framework;

namespace YandexCup.AlarmClocks.Test
{
    [TestFixture]
    public class AlarmClocksCalculatorTest
    {
        [TestCase(new ulong[] { 1, 2, 3, 4, 5, 6 }, 5, 10, 10)]
        [TestCase(new ulong[] { 2, 25 }, 1, 10, 11)]
        [TestCase(new ulong[] { 5, 22, 17, 13, 8 }, 7, 12, 27)]
        [TestCase(new ulong[] { 5, 5, 5, 5 }, 5, 6, 30)]
        [TestCase(new ulong[] {int.MaxValue }, 5, 1, int.MaxValue)]
        public void CorrectCalculateWakeUpTimeTest(ulong[] startTime, int step, int maxAlertNumber, int awakeTime)
        {
            var calculator = new AlarmClocksCalculator();
            var calculatedWakeTime = calculator.CalculateWakeUpTime(startTime, step, maxAlertNumber);
            Assert.AreEqual(awakeTime, calculatedWakeTime);
        }
    }
}