using System;
using Avalonia.Controls;
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

        // Inicializar de forma assíncrona
        _ = _viewModel.InitializeAsync();
    }
}
