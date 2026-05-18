using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Siapen.Helpers;
using Siapen.ViewModels;

namespace Siapen.Views;

public partial class MovimentoInternosView : Window
{
    private readonly MovimentoInternosViewModel _viewModel;

    public MovimentoInternosView()
    {
        _viewModel = new MovimentoInternosViewModel();
        DataContext = _viewModel;
        InitializeComponent();
        LogHelper.Debug("[VIEW] MovimentoInternosView constructor — DataContext set", "MOV_INTERNOS");
    }

    protected override async void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        LogHelper.Debug($"[VIEW] OnOpened — DataContext type: {DataContext?.GetType().Name ?? "null"}", "MOV_INTERNOS");
        try
        {
            LogHelper.Debug($"[VIEW] Calling LoadAsync — IdUp={GlobalVars.IdUp}", "MOV_INTERNOS");
            await _viewModel.LoadAsync();
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar MovimentoInternos", ex, "MOV_INTERNOS");
        }
    }

    protected override void OnClosing(WindowClosingEventArgs e)
    {
        LogHelper.Debug("[VIEW] MovimentoInternosView closing", "MOV_INTERNOS");
        base.OnClosing(e);
    }

    private void Fechar_Click(object? sender, RoutedEventArgs e)
    {
        LogHelper.Debug("[VIEW] Fechar button clicked", "MOV_INTERNOS");
        Close();
    }

    private void DataGrid_DoubleTapped(object? sender, TappedEventArgs e)
    {
        if (_viewModel.Modo != CadastroModo.Navegando) return;
        if (_viewModel.SelectedGridItem == null) return;

        LogHelper.Debug("[VIEW] Double-click — showing record in view mode", "MOV_INTERNOS");
        // Fields are already filled by PreencherCampos() via SelectedGridItem setter.
        // Just switch to the Cadastro tab so the user sees the data.
        var tabControl = this.FindControl<TabControl>("CadastroTabControl");
        if (tabControl != null)
            tabControl.SelectedIndex = 0;
    }
}
