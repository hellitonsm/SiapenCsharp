using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Siapen.Helpers;
using Siapen.ViewModels;

namespace Siapen.Views;

public partial class CadastroPavilhaoView : Window
{
    private readonly CadastroPavilhaoViewModel _viewModel;

    public CadastroPavilhaoView()
    {
        _viewModel = new CadastroPavilhaoViewModel();
        DataContext = _viewModel;
        InitializeComponent();
    }

    protected override async void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        LogHelper.Debug($"CadastroPavilhaoView.OnOpened: GlobalVars.IdUp={GlobalVars.IdUp}, IdFuncionario={GlobalVars.IdFuncionario}", "UI");
        try
        {
            _viewModel.LoadUnidades();
            await _viewModel.LoadAsync();
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar CadastroPavilhao", ex, "UI");
            var msg = new MessageBox("Erro ao carregar", $"{ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
            msg.Show(this);
        }
    }

    private void Fechar_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
