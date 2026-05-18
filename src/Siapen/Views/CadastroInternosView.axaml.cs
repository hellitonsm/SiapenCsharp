using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Siapen.ViewModels;

namespace Siapen.Views;

public partial class CadastroInternosView : Window
{
    private readonly CadastroInternosViewModel _viewModel;

    public CadastroInternosView()
    {
        _viewModel = new CadastroInternosViewModel();
        DataContext = _viewModel;
        InitializeComponent();
    }

    private void Fechar_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    private void DataGrid_DoubleTapped(object? sender, TappedEventArgs e)
    {
        _viewModel.CarregarRegistroSelecionadoCommand.Execute(null);
    }
}
