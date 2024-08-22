using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;

namespace ExpandingControllersWPF
{
    [ValueConversion(typeof(string), typeof(decimal))]
    public class DecimalToStringConverter : IValueConverter
    {
        private bool HaveComma;
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal)
            {
                string str = value.ToString();
                if (HaveComma)
                {
                    str += ',';
                }
                return str;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str) 
            {
                MatchCollection matches = UsefulMethods.NonDigitInStringDigit().Matches(str);
                foreach (Match match in matches) 
                {
                    str = str.Remove(str.IndexOf(match.Value), match.Value.Length);
                }
                int firstCommaIndex = str.IndexOf(',');
                if (firstCommaIndex != -1)
                {
                    string beforeFirstComma = str.Substring(0, firstCommaIndex + 1);
                    string afterFirstComma = str.Substring(firstCommaIndex + 1);
                    afterFirstComma = afterFirstComma.Replace(",", "");
                    str = beforeFirstComma + afterFirstComma;
                }
                HaveComma = str.EndsWith(',') && str.IndexOf(',') > 0;
                if (decimal.TryParse(str, out decimal result))
                {
                    return result;
                }
            }
            return 0M;
        }
    }
}