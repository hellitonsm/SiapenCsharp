using Avalonia.Controls;
using Avalonia.Interactivity;
using Siapen.Helpers;
using Siapen.ViewModels;

namespace Siapen.Views;

public partial class ConsultaProcedView : Window
{
    private readonly ConsultaProcedViewModel _viewModel;

    public ConsultaProcedView()
    {
        _viewModel = new ConsultaProcedViewModel();
        DataContext = _viewModel;
        InitializeComponent();
    }

    private void Fechar_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
