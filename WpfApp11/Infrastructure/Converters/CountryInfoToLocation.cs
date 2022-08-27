using System;
using System.Globalization;
using System.Windows.Data;
using CV19.Models;

namespace WpfApp11.Infrastructure.Converters;

public class CountryInfoToLocation : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(value is CountryInfo info)) return null;
        return ("Lat:" + info.Location.X + " Lon:" + info.Location.Y);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}