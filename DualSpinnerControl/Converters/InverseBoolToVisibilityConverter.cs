using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace DualSpinnerControl.Converters
{
    internal class InverseBoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bValue = false;

            if (value != null)
            {
                bValue = (bool)value;
                bValue = !bValue; // doing inverse of teh boolean value
            }

            BooleanToVisibilityConverter boolConverter = new BooleanToVisibilityConverter();

            return boolConverter.Convert(bValue, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}