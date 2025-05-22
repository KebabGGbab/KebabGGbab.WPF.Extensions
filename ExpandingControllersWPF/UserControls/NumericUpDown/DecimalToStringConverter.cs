using System.Globalization;
using System.Windows.Data;

namespace ExpandingControllersWPF.UserControls.NumericUpDown
{
    [ValueConversion(typeof(string), typeof(decimal))]
    public class DecimalToStringConverter : IValueConverter
    {
        private bool _separator;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal dec)
            {
                return string.Concat(dec.ToString(culture), _separator ? culture.NumberFormat.NumberDecimalSeparator : null);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str && decimal.TryParse(str, NumberStyles.Number, culture, out decimal dec)) 
            {
                _separator = str.EndsWith(culture.NumberFormat.NumberDecimalSeparator, StringComparison.CurrentCulture);

				return dec;
            }

            _separator = false;
            return 0M;
        }
    }
}