using System.Text.RegularExpressions;

namespace ExpandingControllersWPF
{
    internal static partial class UsefulMethods
    {
        [GeneratedRegex(@"^\d+$")]
        internal static partial Regex StringIsDigit();

        [GeneratedRegex(@"[^0-9,]+")]
        internal static partial Regex NonDigitInStringDigit();
    }
}
