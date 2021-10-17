using System;
using System.Globalization;
using System.Windows;

namespace DrawingTool
{
    /// <summary>
    /// A converter that takes in a boolean and returns a <see cref="Visibility"/>
    /// </summary>
    public class BooleanToVisibilityConverter : BaseValueConverter<BooleanToVisibilityConverter>
    {
        public override object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                // if no parameter, hide on true.
                return (bool)value ? Visibility.Hidden : Visibility.Visible;
            else
                // if parameter, hide on false
                return (bool)value ? Visibility.Visible : Visibility.Hidden;
        }

        public override object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
