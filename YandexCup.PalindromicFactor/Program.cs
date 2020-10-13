using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexCup.PalindromicFactor
{
    class Program
    {
        static void Main()
        {
            var inputString = Console.ReadLine();
            var finder = new PalindromeFinder();
            var smallestPalindrome = finder.FindSmallest(inputString);
            
            Console.Write(string.IsNullOrWhiteSpace(smallestPalindrome)
                ? "-1"
                : smallestPalindrome);
        }
    }

    public class PalindromeFinder
    {
        public string FindSmallest(string text)
        {
            var allPalindrome = FindAllPalindrome(text);
            if (!allPalindrome.Any())
            {
                return null;
            }

            return allPalindrome.OrderBy(x => x.Length)
                .ThenBy(x => x)
                .First();
        }

        private string[] FindAllPalindrome(string inputString)
        {
            var allSubstrings = new List<string>();
            for (int length = 1; length < inputString.Length; length++)
            {
                // End index is tricky.
                for (int start = 0; start <= inputString.Length - length; start++)
                {
                    string substring = inputString.Substring(start, length);
                    allSubstrings.Add(substring);
                }
            }

            return allSubstrings.Where(IsPalindrome)
                .ToArray();
        }

        public bool IsPalindrome(string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText))
                return false;
            
            if (inputText.Length <= 1)
                return false;

            var lastSymbolIndex = inputText.Length - 1;
            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputText[i] != inputText[lastSymbolIndex]) 
                    return false;

                if (lastSymbolIndex <= i)
                    return true;

                lastSymbolIndex -= 1;
            }

            return false;
        }
    }
}