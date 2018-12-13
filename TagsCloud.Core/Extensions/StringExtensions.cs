using System.Text.RegularExpressions;

namespace TagsCloud.Core.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSpecialSymbols(this string text)
        {
            var textWithoutSpecialSymbols = Regex.Replace(text, "[^\\w\\._]", " ");
            return Regex.Replace(textWithoutSpecialSymbols, @"\s+", " ");
        }
    }
}