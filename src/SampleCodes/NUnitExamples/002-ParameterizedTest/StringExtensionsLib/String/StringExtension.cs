using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSD.Extensions.String
{
    public static class StringExtension
    {
        public static string RemoveWhitespaces(this string text)
        {
            var stringBuilder = new StringBuilder();
            
            foreach (var c in text)
                if (!char.IsWhiteSpace(c))
                    stringBuilder.Append(c);

            return stringBuilder.ToString();
        }

        public static string GetLetters(this string text)
        {
            var stringBuilder = new StringBuilder();

            foreach (var c in text)
                if (char.IsLetter(c))
                    stringBuilder.Append(c);

            return stringBuilder.ToString();
        }

        public static bool IsPalindrome(this string text)
        {
            var str = GetLetters(text);

            int left = 0;
            int right = str.Length - 1;

            while (left < right)
                if (char.ToLower(str[left++]) != char.ToLower(str[right--]))
                    return false;

            return true;
        }
    }
}
