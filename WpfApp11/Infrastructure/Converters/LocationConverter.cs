using MapControl;
using System.Globalization;
using System;
using System.Windows;
using WpfApp11.Infrastructure.Converters.Base;

namespace WpfApp11.Infrastructure.Converters;

public class LocationConverter : Converter
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Point pt = (Point)value;
        return new Location(pt.X, pt.Y);
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return new Point(((Location)value).Latitude, ((Location)value).Longitude);
    }
}