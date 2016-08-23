using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace vsgerrit.Common.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isVisible = System.Convert.ToBoolean(value);

            if (parameter != null && System.Convert.ToBoolean(parameter))
            {
                isVisible = !isVisible;
            }

            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}