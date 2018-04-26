using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ValueConverter
{
    public class FlexibleBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool booleanValue = (bool)value;
            return VisibilityFromParameter(parameter.ToString(), booleanValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;
            Visibility trueVisibility = VisibilityFromParameter(parameter.ToString(), true);
            return visibility = trueVisibility;
        }

        private Visibility VisibilityFromParameter(string parameter, bool booleanValue)
        {
            string[] visibilities = parameter.Split('|');
            string visibility = booleanValue ? visibilities[0] : visibilities[1];
            return (Visibility)Enum.Parse(typeof(Visibility), visibility);
        }
    }
}
