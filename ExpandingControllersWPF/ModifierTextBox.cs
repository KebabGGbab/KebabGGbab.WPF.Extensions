using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace ExpandingControllersWPF
{
    public class ModifierTextBox : TextBox
    {
        public static readonly DependencyProperty PlaceholderProperty;
        public static readonly DependencyProperty PlaceholderForegroundProperty;
        public static readonly DependencyProperty PlaceholderFontFamilyProperty;
        public static readonly DependencyProperty PlaceholderFontSizeProperty;
        public static readonly DependencyProperty PlaceholderFontWeightProperty;
        public static readonly DependencyProperty PlaceholderFontStretchProperty;
        public static readonly DependencyProperty PlaceholderFontStyleProperty;

        static ModifierTextBox()
        {
            PlaceholderProperty = DependencyProperty.Register("Placeholder", typeof(string), typeof(ModifierTextBox), new PropertyMetadata(string.Empty));
            PlaceholderForegroundProperty = DependencyProperty.Register("PlaceholderForeground", typeof(Brush), typeof(ModifierTextBox), new PropertyMetadata(Brushes.Gray));
            PlaceholderFontFamilyProperty = DependencyProperty.Register("PlaceholderFontFamily", typeof(FontFamily), typeof(ModifierTextBox), new PropertyMetadata(null));
            PlaceholderFontSizeProperty = DependencyProperty.Register("PlaceholderFontSize", typeof(double), typeof(ModifierTextBox), new PropertyMetadata(null));
            PlaceholderFontWeightProperty = DependencyProperty.Register("PlaceholderFontWeight", typeof(FontWeight), typeof(ModifierTextBox), new PropertyMetadata(null));
            PlaceholderFontStretchProperty = DependencyProperty.Register("PlaceholderFontStretch", typeof(FontStretch), typeof(ModifierTextBox), new PropertyMetadata(null));
            PlaceholderFontStyleProperty = DependencyProperty.Register("PlaceholderFontStyle", typeof(FontStyle), typeof(ModifierTextBox), new PropertyMetadata(null));
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModifierTextBox), new FrameworkPropertyMetadata(typeof(ModifierTextBox)));
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public Brush PlaceholderForeground
        {
            get { return (Brush)GetValue(PlaceholderForegroundProperty); }
            set { SetValue(PlaceholderForegroundProperty, value); }
        }

        public FontFamily PlaceholderFontFamily
        {
            get { return (FontFamily)GetValue(PlaceholderFontFamilyProperty); }
            set { SetValue(PlaceholderFontFamilyProperty, value); }
        }

        public double PlaceholderFontSize
        {
            get { return (double)GetValue(PlaceholderFontSizeProperty); }
            set { SetValue(PlaceholderFontSizeProperty, value); }
        }

        public FontWeight PlaceholderFontWeight
        {
            get { return (FontWeight)GetValue(PlaceholderFontWeightProperty); }
            set { SetValue(PlaceholderFontWeightProperty, value); }
        }

        public FontStretch PlaceholderFontStretch
        {
            get { return (FontStretch)GetValue(PlaceholderFontStretchProperty); }
            set { SetValue(PlaceholderFontStretchProperty, value); }
        }

        public FontStyle PlaceholderFontStyle
        {
            get { return (FontStyle)GetValue(PlaceholderFontStyleProperty); }
            set { SetValue(PlaceholderFontStyleProperty, value); }
        }
    }
}
