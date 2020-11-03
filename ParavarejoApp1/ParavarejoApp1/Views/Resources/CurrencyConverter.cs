using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ParavarejoApp1.Views.Resources
{
    public class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NumberFormatInfo nfi = culture.NumberFormat;
            return Double.Parse(value.ToString()).ToString("N2");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueFromString = Regex.Replace(value.ToString(), @"\D", "");

            if (valueFromString.Length <= 0)
                return 0d;

            long valueLong;
            if (!long.TryParse(valueFromString, out valueLong))
                return 0d;

            if (valueLong <= 0)
                return 0d;

            return valueLong / 100d;
        }
    }
}
