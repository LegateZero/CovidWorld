using System;
using System.Globalization;
using System.Windows.Data;
using WpfApp11.Infrastructure.Converters.Base;

namespace WpfApp11.Infrastructure.Converters;

public class CompositeConverter : Converter
{
    public IValueConverter _First { get; set; }
    public IValueConverter _Second { get; set; }
    public CompositeConverter() {}
    public CompositeConverter(IValueConverter first) => this._First = first;
    public CompositeConverter(IValueConverter first, IValueConverter second) : this(first) => this._Second = second;

    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var result1 = _First.Convert(value, targetType, parameter, culture);
        var result2 = _Second.Convert(result1, targetType, parameter, culture);
        return result2;
    }

}