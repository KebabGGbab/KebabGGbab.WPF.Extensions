using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ExpandingControllersWPF.UserControls.NumericUpDown
{
    [TemplatePart(Name = "PART_UpValue", Type = typeof(RepeatButton))]
    [TemplatePart(Name = "PART_DownValue", Type = typeof(RepeatButton))]
    public partial class NumericUpDown : Control
    {
        #region property
        public static readonly DependencyProperty ValueProperty;
        public static readonly DependencyProperty MinValueProperty;
        public static readonly DependencyProperty MaxValueProperty;
        public static readonly DependencyProperty StepProperty;
        public static readonly DependencyProperty RoundProperty;
        #endregion

        #region accessor
        public decimal Value
        {
            get { return (decimal)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public decimal MinValue
        {
            get { return (decimal)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public decimal MaxValue
        {
            get { return (decimal)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public decimal Step
        {
            get { return (decimal)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        public byte Round
        {
            get { return (byte)GetValue(RoundProperty); }
            set { SetValue(RoundProperty, value); }
        }

        #endregion

        static NumericUpDown()
        {
            ValueProperty = DependencyProperty.Register("Value", typeof(decimal), typeof(NumericUpDown), new FrameworkPropertyMetadata(0.0M, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, CoerceValue), ValidateValue);
            MinValueProperty = DependencyProperty.Register("MinValue", typeof(decimal), typeof(NumericUpDown), new PropertyMetadata(0.0M));
            MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(decimal), typeof(NumericUpDown), new PropertyMetadata(100.0M));
            StepProperty = DependencyProperty.Register("Step", typeof(decimal), typeof(NumericUpDown), new PropertyMetadata(1.0M));
            RoundProperty = DependencyProperty.Register("Round", typeof(byte), typeof(NumericUpDown), new PropertyMetadata((byte)0));
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }

        private static object CoerceValue(DependencyObject d, object baseValue)
        {
            NumericUpDown control = (NumericUpDown)d;

            if (baseValue is not decimal value)
                return 0.0M;

            value = Math.Round(value, control.Round);

            if (value < control.MinValue)
                return control.MinValue;
            if (value > control.MaxValue)
                return control.MaxValue;

            return value;
        }

        private static bool ValidateValue(object value)
        {
            return value is decimal;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (GetTemplateChild("PART_UpValue") is RepeatButton UpButton && GetTemplateChild("PART_DownValue") is RepeatButton DownButton)
            {
                UpButton.Click += UpValue_Click;
                DownButton.Click += DownValue_Click;
            }
        }

        private void UpValue_Click(object sender, RoutedEventArgs e)
        {
            Value += Step;
        }

        private void DownValue_Click(object sender, RoutedEventArgs e)
        {
            Value -= Step;
        }
	}
}