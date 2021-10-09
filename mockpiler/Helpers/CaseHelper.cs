using System.Text.RegularExpressions;

namespace mockpiler.Helpers
{
    public static class CaseHelper
    {
        public static string TitleCaseDashUnderscore(string s)
        {
            var withUnderscoreDashUpper = Regex.Replace(s, "[_-]([A-Za-z])", m => m.Groups[1].Value.ToUpper());
            return char.ToUpperInvariant(withUnderscoreDashUpper[0]) + withUnderscoreDashUpper.Substring(1);
        }
    }
}