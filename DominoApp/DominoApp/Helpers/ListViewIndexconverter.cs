using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DominoApp.Helpers
{
    class ListViewIndexconverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return 0;
            var index = ((ListView)parameter).ItemsSource.Cast<object>().ToList().IndexOf(value);
            return index + 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return 0;
            var index = ((ListView)parameter).ItemsSource.Cast<object>().ToList().IndexOf(value);
            return index + 1;
        }
    }
}
