using System;
using Avalonia.Controls;
using Avalonia.Input;
using Siapen.ViewModels;

namespace Siapen.Views;

public partial class LoginWindow : Window
{
    private readonly LoginViewModel _viewModel;

    public LoginWindow()
    {
        _viewModel = new LoginViewModel();

        InitializeComponent();
        DataContext = _viewModel;

        // Conectar LostFocus do TextBox de Login para detectar UP automaticamente
        var txtLogin = this.FindControl<TextBox>("TxtLogin");
        if (txtLogin != null)
        {
            txtLogin.LostFocus += (s, e) => _ = _viewModel.DetectarUpPorLoginCommand.ExecuteAsync(null);
        }

        // Inicializar de forma assíncrona
        _ = _viewModel.InitializeAsync();
    }
}
