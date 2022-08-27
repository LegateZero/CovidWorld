using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using CV19.Models;

namespace WpfApp11.Infrastructure.Converters;

public class StringToCountryInfo: Freezable, IValueConverter
{
    #region Info : IList<CountryInfo> - Информация о странах

    public static readonly DependencyProperty InfoProperty =
        DependencyProperty.Register(
            nameof(Info),
            typeof(IList<CountryInfo>),
            typeof(StringToCountryInfo),
            new PropertyMetadata(default(IList<CountryInfo>)));

    [Description("Информация о стране")]
    internal IList<CountryInfo> Info
    {
        get => (IList<CountryInfo>) GetValue(InfoProperty);
        set => SetValue(InfoProperty, value);
    }

    #endregion
    protected override Freezable CreateInstanceCore()
    {
        throw new NotImplementedException();
    }

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null) return null;
        var loc = Info?.Where(g => g.Name == (string)value).FirstOrDefault();
        return String.Format("Lat: {0:F2} Lon: {1:F2}", loc.Location.X, loc.Location.Y);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}