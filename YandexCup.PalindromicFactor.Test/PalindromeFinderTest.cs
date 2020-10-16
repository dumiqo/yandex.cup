using NUnit.Framework;

namespace YandexCup.PalindromicFactor.Test
{
    [TestFixture]
    public class PalindromeFinderTest
    {
        [TestCase("abac", "aba")]
        [TestCase("yandex", null)]
        [TestCase("abbadfs", "bb")]
        [TestCase("abbadfsaa", "aa")]
        [TestCase("abbadfsaba", "bb")]
        [TestCase("abba", "bb")]
        [TestCase("ffdfd", "ff")]
        [TestCase("sdf", null)]
        [TestCase("fffffffffff", "ff")]
        [TestCase("zacdfvzaczazdfg", "zaz")]
        [TestCase("zacdfvzacbazdfg", null)]
        [TestCase("zacdfvzacbazdfg", null)]
        [TestCase("aaff", "aa")]
        [TestCase("ffaa", "aa")]
        [TestCase("fffaa", "aa")]
        [TestCase("ffaza", "ff")]
        [TestCase("avadfaba", "aba")]
        [TestCase("faaafffffaaaaaaafffff", "aa")]
        [TestCase("abazzzzzzzaba", "zz")]
        [TestCase("aazzzzzzzaa", "aa")]
        [TestCase("aazzzzzzzaa", "aa")]
        [TestCase("ababababa", "aba")]
        public void FindSmallestTest(string inputString, string resultString)
        {
            var finder = new PalindromeFinder();
            Assert.AreEqual(resultString, finder.FindSmallest(inputString));
        }

        [TestCase("abba")]
        [TestCase("aba")]
        [TestCase("aa")]
        [TestCase("abzzzzzzzba")]
        [TestCase("abazzzzzzzaba")]
        public void IsPalindromeTrueTest(string inputString)
        {
            var finder = new PalindromeFinder();
            Assert.IsTrue(finder.IsPalindrome(inputString));
        }

        [TestCase("avba")]
        [TestCase("abdavcdba")]
        [TestCase("bas")]
        [TestCase("a")]
        [TestCase("")]
        public void IsPalindromeFalseTest(string inputString)
        {
            var finder = new PalindromeFinder();
            Assert.IsFalse(finder.IsPalindrome(inputString));
        }
    }
}