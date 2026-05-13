using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Siapen.Helpers;
using Siapen.ViewModels;

namespace Siapen.Views;

public partial class CadastroGaleriaView : Window
{
    private readonly CadastroGaleriaViewModel _viewModel;

    public CadastroGaleriaView()
    {
        _viewModel = new CadastroGaleriaViewModel();
        DataContext = _viewModel;
        InitializeComponent();
    }

    protected override async void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        LogHelper.Debug($"CadastroGaleriaView.OnOpened: GlobalVars.IdUp={GlobalVars.IdUp}, IdFuncionario={GlobalVars.IdFuncionario}", "UI");
        try
        {
            _viewModel.LoadPavilhoes();
            await _viewModel.LoadAsync();
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar CadastroGaleria", ex, "UI");
            var msg = new MessageBox("Erro ao carregar", $"{ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
            msg.Show(this);
        }
    }

    private void Fechar_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
