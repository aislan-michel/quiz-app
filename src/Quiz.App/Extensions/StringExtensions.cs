using System.Linq;

namespace Quiz.App.Extensions
{
    public static class StringExtensions
    {
        private const string WhiteSpace = " ";

        public static bool ContainsWhiteSpace(this string str)
        {
            return str.Contains(WhiteSpace);
        }

        public static string GetFirstWord(this string str)
        {
            return str.Split(WhiteSpace).First();
        }

        public static string GetLastWord(this string str)
        {
            return str.Split(WhiteSpace).Last();
        }
    }
}