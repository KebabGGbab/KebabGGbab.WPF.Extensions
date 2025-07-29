using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace KebabGGbab.Extensions.WPF.Converters
{
	public class EnumDisplayStringConverter : IValueConverter
	{
		public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (parameter == null)
			{
				return string.Empty;
			}

			Enum field = (Enum)parameter;
			string name = field.ToString();
			DisplayAttribute? attribute = (DisplayAttribute?)field.GetType().GetField(name)?.GetCustomAttribute(typeof(DisplayAttribute));

			return attribute?.Name ?? name;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
