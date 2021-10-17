using System;
using System.Globalization;
using System.Windows;

namespace DrawingTool
{
    /// <summary>
    /// A converter that takes in a boolean and returns a <see cref="Visibility"/>
    /// </summary>
    public class BooleanToCollapsedConverter : BaseValueConverter<BooleanToCollapsedConverter>
    {
        public override object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                // if no parameter, collapse on true.
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            else
                // if parameter, collapse on false
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
