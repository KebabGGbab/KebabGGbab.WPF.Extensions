using System.ComponentModel;
using KebabGGbab.Localization;
using KebabGGbab.WPF.Extensions.Resources;

namespace KebabGGbab.WPF.Extensions.Services.Localization
{
    public class LocalizationListener : BaseLocalizationListener, INotifyPropertyChanged
    {
        private readonly string _key;
        private readonly object[]? _args;

        private object _value;

        public object Value 
        { 
            get => _value;
            private set
            {
                if (_value == value)
                {
                    return;
                }

                _value = value;
                OnPropertyChanged();
            }
        }

        public LocalizationListener(string key, object[]? args)
        {
            _key = key;
            _args = args;
            _value = SetValue();
        }

        public override bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(CurrentUICultureChangedEventManager))
            {
                Value = SetValue();

                return true;
            }

            return false;
        }

        private object SetValue()
        {
            try
            {
                object value = LocalizationManager.Instance.Localize(_key);

                if (value is string str && _args != null)
                {
                    return string.Format(str, _args);
                }
                else
                {
                    return value;
                }
            }
            catch (ResourceNotFoundException ex)
            {
                return string.Join(" ", Strings.ResourcePlaceholder, ex.Key);
            }
        }
    }
}
