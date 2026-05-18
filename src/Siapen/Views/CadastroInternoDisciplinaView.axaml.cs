using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Siapen.ViewModels;

namespace Siapen.Views;

public partial class CadastroInternoDisciplinaView : Window
{
    private readonly CadastroInternoDisciplinaViewModel _viewModel;

    public CadastroInternoDisciplinaView()
    {
        _viewModel = new CadastroInternoDisciplinaViewModel();
        DataContext = _viewModel;
        InitializeComponent();
    }

    protected override async void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        await _viewModel.LoadAsync();
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
