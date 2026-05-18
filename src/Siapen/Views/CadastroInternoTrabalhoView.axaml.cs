using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Siapen.ViewModels;

namespace Siapen.Views;

public partial class CadastroInternoTrabalhoView : Window
{
    private readonly CadastroInternoTrabalhoViewModel _viewModel;

    public CadastroInternoTrabalhoView()
    {
        _viewModel = new CadastroInternoTrabalhoViewModel();
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
