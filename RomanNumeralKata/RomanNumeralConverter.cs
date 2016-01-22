using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralKata
{
    public class RomanNumeralConverter
    {
        static Dictionary<char, int> LetterValues = new Dictionary<char, int>() {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public static int RomanToArabic(string roman)
        {
            var result = 0;
            
            int final = 0;
            int previousLetterValue = 0;
            int currentLetterValue = 0;
            int timesSameLetterSeen = 0;

            foreach (var letter in roman)
            {
                if (LetterValues.ContainsKey(letter))
                {
                    currentLetterValue = LetterValues[letter];
                    final = currentLetterValue;

                    if (currentLetterValue == previousLetterValue)
                    {
                        timesSameLetterSeen++;
                    }
                    else
                    {
                        timesSameLetterSeen = 1;
                    }

                    if (timesSameLetterSeen > 3)
                    {
                        return 0;
                    }

                    if (previousLetterValue != 0)
                    {
                        if (previousLetterValue < currentLetterValue)
                        {
                            final = currentLetterValue - (previousLetterValue * 2);
                        }
                    }

                    result += final;
                    previousLetterValue = currentLetterValue;
                }
                else
                {
                    return 0;
                }
            }

            return result;
        }

        public static string ArabicToRoman(int arabic)
        {
            return "";
        }
    }
}
