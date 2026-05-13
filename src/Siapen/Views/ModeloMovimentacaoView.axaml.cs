using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Siapen.Views;

public partial class ModeloMovimentacaoView : Window
{
    public ModeloMovimentacaoView()
    {
        InitializeComponent();
    }

    private void Fechar_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
