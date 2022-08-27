using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System;

namespace WpfApp11.Infrastructure.Converters.Base;

public abstract class Converter : MarkupExtension, IValueConverter
{
    public override object ProvideValue(IServiceProvider sp) => this;
    public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

    public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException("Обратное преобразование не поддерживается");
    }
}