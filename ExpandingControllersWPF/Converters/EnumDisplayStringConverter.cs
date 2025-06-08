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
			string name = field.ToString();
			DisplayAttribute? attribute = field.GetType().GetField(name)?.GetCustomAttributes(false).OfType<DisplayAttribute>().FirstOrDefault();

			if (attribute == null)
			{
				return field.ToString();
			}

			return attribute.Name;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
