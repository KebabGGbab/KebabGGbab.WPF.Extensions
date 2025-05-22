using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ExpandingControllersWPF.UserControls.NumericUpDown
{
    public class HalfThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness originalThickness)
            {
                return new Thickness(
                    originalThickness.Left / 2,
                    originalThickness.Top / 2,
                    originalThickness.Right / 2,
                    originalThickness.Bottom / 2
                );
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
