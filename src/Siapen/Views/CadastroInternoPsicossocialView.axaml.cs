using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Siapen.ViewModels;

namespace Siapen.Views;

public partial class CadastroInternoPsicossocialView : Window
{
    private readonly CadastroInternoPsicossocialViewModel _viewModel;

    public CadastroInternoPsicossocialView()
    {
        _viewModel = new CadastroInternoPsicossocialViewModel();
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

    private void IncluirAtendimento_Click(object? sender, RoutedEventArgs e)
    {
        _viewModel.IncluirAtendimentoCommand.Execute(null);
    }
}
