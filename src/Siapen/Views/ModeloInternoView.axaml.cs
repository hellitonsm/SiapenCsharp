using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Siapen.Views;

public partial class ModeloInternoView : Window
{
    public ModeloInternoView()
    {
        InitializeComponent();
    }

    private void Fechar_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
