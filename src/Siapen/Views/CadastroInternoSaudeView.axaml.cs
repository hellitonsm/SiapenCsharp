using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Siapen.ViewModels;

namespace Siapen.Views;

public partial class CadastroInternoSaudeView : Window
{
    private readonly CadastroInternoSaudeViewModel _viewModel;

    public CadastroInternoSaudeView()
    {
        _viewModel = new CadastroInternoSaudeViewModel();
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
