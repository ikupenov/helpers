using System;

namespace Helpers
{
    public static class IntegerExtensions
    {
        public static string ToWords(this int @this)
        {
            if (@this == 0)
            {
                return "zero";
            }

            if (@this < 0)
            {
                return $"negative {ToWords(Math.Abs(@this))}";
            }

            var numberInWords = string.Empty;

            if (@this / 1000000 > 0)
            {
                numberInWords += $"{ToWords(@this / 1000)} million ";
                @this %= 1000000;
            }

            if (@this / 1000 > 0)
            {
                numberInWords += $"{ToWords(@this / 1000)} thousand ";
                @this %= 1000;
            }

            if (@this / 100 > 0)
            {
                numberInWords += $"{ToWords(@this / 100)} hundred ";
                @this %= 100;
            }

            if (@this == 0)
            {
                return numberInWords;
            }

            var digits = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tens = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (numberInWords != string.Empty)
            {
                numberInWords += "and ";
            }

            if (@this < 20)
            {
                numberInWords += digits[@this];
            }
            else if (@this / 10 > 0)
            {
                numberInWords += tens[@this / 10];

                if (@this % 10 > 0)
                {
                    numberInWords += $"-{digits[@this % 10]}";
                }
            }

            return numberInWords;
        }
    }
}
