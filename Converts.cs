using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace MulTools
{
    [ValueConversion(typeof(bool), typeof(string))]
    public class ColorConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool have = (bool)value;
            if (have)
                return "Green";
            else
                return "Black";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return "Black";
        }
    }
}
