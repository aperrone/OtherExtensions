using System;
using System.Linq;

namespace System
{
    public static class String_Extensions
    {
        /// <summary>
        /// Return the same string with the char capitalized
        /// </summary>
        /// <param name="input">String</param>
        /// <returns></returns>
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null:
                    throw new ArgumentNullException(nameof(input));
                case "":
                    return "";
                default:
                    return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        public static string Truncate(this string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.Substring(0, Math.Min(str.Length, maxLength));
        }

        public static string TruncateAfter(this string str, string delimiter)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            int index = str.IndexOf(delimiter);
            if (index < 0)
                return str;

            return str.Substring(0, index);
        }
    }
}
