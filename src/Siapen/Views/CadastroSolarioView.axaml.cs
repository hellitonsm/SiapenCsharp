using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Siapen.Helpers;
using Siapen.ViewModels;

namespace Siapen.Views;

public partial class CadastroSolarioView : Window
{
    private readonly CadastroSolarioViewModel _viewModel;

    public CadastroSolarioView()
    {
        _viewModel = new CadastroSolarioViewModel();
        DataContext = _viewModel;
        InitializeComponent();
    }

    protected override async void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        LogHelper.Debug($"CadastroSolarioView.OnOpened: GlobalVars.IdUp={GlobalVars.IdUp}, IdFuncionario={GlobalVars.IdFuncionario}", "UI");
        try
        {
            _viewModel.LoadLookups();
            await _viewModel.LoadAsync();
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar CadastroSolario", ex, "UI");
            var msg = new MessageBox("Erro ao carregar", $"{ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
            msg.Show(this);
        }
    }

    private void Fechar_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
