using System.Globalization;
using System.Windows.Data;

namespace ExpandingControllersWPF.Converters
{
	public class FlagsEnumBoolConverter : IValueConverter
	{
		private int _value;

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || parameter == null)
			{
				return false;
			}

			int mask = (int)parameter;
			_value = (int)value;

			return (mask & _value) != 0;
		}

		public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || parameter == null)
			{
				return 0;
			}

			_value ^= (int)parameter;
			return Enum.Parse(targetType, _value.ToString());
		}
	}
}
