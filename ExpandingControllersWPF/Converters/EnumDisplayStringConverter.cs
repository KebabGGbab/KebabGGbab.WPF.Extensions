using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows.Data;

namespace ExpandingControllersWPF.Converters
{
	public class EnumDisplayStringConverter : IValueConverter
	{
		public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return string.Empty;
			}

			Enum field = (Enum)parameter;
			object[] attributes = field.GetType().GetCustomAttributes(false);

			foreach (object attribute in attributes)
			{
				if (attribute is DisplayAttribute display)
				{
					return display.Name;
				}
			}

			return field.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
