using System;
using Avalonia.Data;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Siapen.ViewModels;

public static class CadastroModoConverters
{
    public static readonly IsNavegandoConverter IsNavegando = new();
}

public class IsNavegandoConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is CadastroModo modo)
            return modo == CadastroModo.Navegando;
        return false;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Converts an int index to bool for RadioButton IsChecked.
/// ConverterParameter is the index to match.
/// </summary>
public class IndexToBoolConverter : IValueConverter
{
    public static readonly IndexToBoolConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is int index && parameter is string paramStr && int.TryParse(paramStr, out int target))
            return index == target;
        return false;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is true && parameter is string paramStr && int.TryParse(paramStr, out int target))
            return target;
        return BindingOperations.DoNothing;
    }
}
