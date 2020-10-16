using NUnit.Framework;

namespace YandexCup.ShareThemAll.Test
{
    [TestFixture]
    public class PokemonCheckerTest
    {
        [TestCase(new[] {0, 1, 1, 1})]
        [TestCase(new[] {1, 0, 0, 0, 1, 1, 1, 1, 0})]
        public void OneItem_CanCachThemAll_SuccessTest(int[] numbers)
        {
            var cacher = new PokemonChecker();
            var points = new int[1][];
            points[0] = numbers;
            Assert.IsTrue(cacher.CanCachThemAll(points));
        }

        [TestCase(new[] {0, 1, 1, 1})]
        [TestCase(new[] {0, 2, 2, 2})]
        [TestCase(new[] {0, 3, 3, 3})]
        [TestCase(new[] {0, 3, 3, 2})]
        public void TwoCircles_CanCachThemAll_SuccessTest(int[] numbers)
        {
            var cacher = new PokemonChecker();
            var points = new int[2][];
            points[0] = numbers;
            points[1] = new[] {0, 1, 1, 1};
            Assert.IsTrue(cacher.CanCachThemAll(points));
        }
        
        [TestCase(new[] {0, 2, 1, 1}, new[] {0, 2, 2, 1}, new[] {0, 3, 3, 1})]
        [TestCase(new[] {0, 1, 1, 1}, new[] {0, 2, 3, 1}, new[] {0, 3, 3, 3})]
        [TestCase(new[] {0, 1, 1, 1}, new[] {0, 2, 2, 2}, new[] {0, 3, 1, 3})]
        public void ThreeCircles_CanCachThemAll_FailedTest(int[] firstCircle, int[] secondCircle, int[] thirdCircle)
        {
            var cacher = new PokemonChecker();
            var points = new int[3][];
            points[0] = firstCircle;
            points[1] = secondCircle;
            points[2] = thirdCircle;
            Assert.IsFalse(cacher.CanCachThemAll(points));
        }
        
        [TestCase(new[] {0, 1, 0, 1}, new[] {0, 2, 0, 1}, new[] {0, 3, 0, 1})]
        [TestCase(new[] {0, 0, 1, 1}, new[] {0, 0, 2, 1}, new[] {0, 0, 3, 1})]
        [TestCase(new[] {0, 1, 1, 1}, new[] {0, 2, 2, 1}, new[] {0, 3, 3, 1})]
        [TestCase(new[] {0, 1, 1, 1}, new[] {0, 2, 2, 1}, new[] {0, 3, 3, 3})]
        [TestCase(new[] {0, 1, 1, 1}, new[] {0, 2, 2, 2}, new[] {0, 3, 3, 3})]
        [TestCase(new[] {0, 1, 1, 1}, new[] {0, 0, 0, 2}, new[] {0, 3, 3, 3})]
        [TestCase(new[] {0, 3, 3, 1}, new[] {0, 1, 1, 1}, new[] {0, 2, 2, 3})]
        [TestCase(new[] {0, 0, 0, 1}, new[] {0, 5, 5, 1}, new[] {0, 10, 10, 3})]
        [TestCase(new[] {0, 10, 10, 1}, new[] {0, 5, 5, 1}, new[] {0, -10, -10, 3})]
        [TestCase(new[] {0, 10, 10, 1}, new[] {0, 0, 0, 1}, new[] {0, -10, -10, 3})]
        public void ThreeCircles_CanCachThemAll_SuccessTest(int[] firstCircle, int[] secondCircle, int[] thirdCircle)
        {
            var cacher = new PokemonChecker();
            var points = new int[3][];
            points[0] = firstCircle;
            points[1] = secondCircle;
            points[2] = thirdCircle;
            Assert.IsTrue(cacher.CanCachThemAll(points));
        }
        
        [TestCase(new[] {1, 0, 0, 0, 1, 1, 1, 1, 0}, new[] {1, 0, 0, 0, 1, 1, 1, 1, 0})]
        public void TwoSquare_CanCachThemAll_SuccessTest(int[] firstSquare, int[] secondSquare)
        {
            var cacher = new PokemonChecker();
            var points = new int[2][];
            points[0] = firstSquare;
            points[1] = secondSquare;
            Assert.IsTrue(cacher.CanCachThemAll(points));
        }
    }
}