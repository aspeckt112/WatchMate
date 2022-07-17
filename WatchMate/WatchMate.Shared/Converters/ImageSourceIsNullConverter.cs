using System;
using System.Globalization;
using Xamarin.Forms;

namespace WatchMate.Shared.Converters;

public class ImageSourceIsNullConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is not ImageSource;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}