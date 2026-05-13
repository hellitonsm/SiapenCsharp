using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace Siapen.ViewModels;

public class RadioValueConverter : IValueConverter
{
    private readonly string _expectedValue;

    public RadioValueConverter(string expectedValue)
    {
        _expectedValue = expectedValue;
    }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value?.ToString() == _expectedValue;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool isChecked && isChecked)
            return _expectedValue;
        return BindingOperations.DoNothing;
    }
}

public static class RadioValueConverters
{
    public static readonly RadioValueConverter Eq1 = new("1");
    public static readonly RadioValueConverter Eq2 = new("2");
    public static readonly RadioValueConverter Eq3 = new("3");
    public static readonly RadioValueConverter Eq4 = new("4");
    public static readonly RadioValueConverter Eq5 = new("5");
    public static readonly RadioValueConverter Eq6 = new("6");
    public static readonly RadioValueConverter Eq7 = new("7");
    public static readonly RadioValueConverter Eq8 = new("8");
    public static readonly RadioValueConverter EqM = new("M");
    public static readonly RadioValueConverter EqT = new("T");
    public static readonly RadioValueConverter EqS = new("S");
    public static readonly RadioValueConverter EqN = new("N");
}
