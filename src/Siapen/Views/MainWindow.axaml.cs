using Avalonia.Controls;
using Avalonia.Threading;
using Siapen.ViewModels;
using System;

namespace Siapen.Views;

public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        _viewModel = (MainWindowViewModel)DataContext!;
    }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);

        UpdateDataHora();

        // Timer para atualizar data/hora
        var timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        timer.Tick += (_, _) => UpdateDataHora();
        timer.Start();
    }

    private void UpdateDataHora()
    {
        if (_viewModel != null)
        {
            _viewModel.DataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
