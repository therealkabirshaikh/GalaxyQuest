using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GalaxyQuest
{
    public static class RomanArabicConverter
    {
        private static readonly Dictionary<char, int> RomanNumberDictionary;
        private static readonly Dictionary<int, string> NumberRomanDictionary;

        static RomanArabicConverter()
        {
            RomanNumberDictionary = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            NumberRomanDictionary = new Dictionary<int, string>
            {
                {1000, "M"},
                {900, "CM"},
                {500, "D"},
                {400, "CD"},
                {100, "C"},
                {90, "XC"},
                {50, "L"},
                {40, "XL"},
                {10, "X"},
                {9, "IX"},
                {5, "V"},
                {4, "IV"},
                {1, "I"}
            };
        }

        public static string ToRomanNumeral(int number)
        {
            var romanNumeral = new StringBuilder();
            foreach (var (arabic, roman) in NumberRomanDictionary)
            {
                while (number >= arabic)
                {
                    romanNumeral.Append(roman);
                    number -= arabic;
                }
            }

            return romanNumeral.ToString();
        }

        public static decimal ToArabicNumber(string roman)
        {
            var pattern = @"^(?=[MDCLXVI])M*(C[MD]|D?C{0,3})(X[CL]|L?X{0,3})(I[XV]|V?I{0,3})$";
            var regex = new Regex(pattern);
            if (!regex.IsMatch(roman))
                return -1;

            decimal total = 0;

            decimal current, previous = 0;
            char currentRoman, previousRoman = '\0';

            for (var i = 0; i < roman.Length; i++)
            {
                currentRoman = roman[i];

                previous = previousRoman != '\0' ? RomanNumberDictionary[previousRoman] : '\0';
                current = RomanNumberDictionary[currentRoman];

                if (previous != 0 && current > previous)
                {
                    total = total - (2 * previous) + current;
                }
                else
                {
                    total += current;
                }

                previousRoman = currentRoman;
            }

            return total;
        }
        
        
    }
}