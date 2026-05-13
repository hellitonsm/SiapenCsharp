using System;
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
