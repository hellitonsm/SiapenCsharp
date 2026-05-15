using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Siapen.Views;

public partial class SituacaoDisciplinarView : Window
{
    public int SelectedOption { get; private set; } = 0;
    public string DataIsolamento { get; private set; } = string.Empty;

    public SituacaoDisciplinarView()
    {
        InitializeComponent();
    }

    private void Confirma_Click(object? sender, RoutedEventArgs e)
    {
        if (RbSancionado?.IsChecked == true)
            SelectedOption = 0;
        else if (RbSeguro?.IsChecked == true)
            SelectedOption = 1;
        else if (RbObservacao?.IsChecked == true)
            SelectedOption = 2;

        DataIsolamento = TxtDataIsolamento?.Text ?? string.Empty;
        Close(true);
    }

    private void Cancelar_Click(object? sender, RoutedEventArgs e)
    {
        SelectedOption = -1;
        Close(false);
    }
}
