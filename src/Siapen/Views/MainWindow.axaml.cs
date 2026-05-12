using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Threading;
using Siapen.Helpers;
using Siapen.Models;
using Siapen.Services;
using Siapen.ViewModels;
using System;
using System.Linq;

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

        InitializeData();
        UpdateDataHora();

        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        timer.Tick += (_, _) => UpdateDataHora();
        timer.Start();
    }

    private void InitializeData()
    {
        try
        {
            var unidades = DatabaseService.GetUnidadesPenal();
            var comboUp = this.FindControl<ComboBox>("ComboUp");
            if (comboUp != null)
            {
                comboUp.ItemsSource = unidades;

                // Registrar o handler ANTES de selecionar para evitar null reference
                comboUp.SelectionChanged += (_, args) =>
                {
                    if (comboUp.SelectedItem is UnidadePenal up)
                    {
                        GlobalVars.IdUp = up.IdUp;
                        GlobalVars.NomeUp = up.NomeUp;
                        if (_viewModel != null)
                            _viewModel.DatabaseInfo = $"UP: {up.NomeUp}";
                        LogHelper.Debug($"UP alterada: {up.NomeUp} (ID={up.IdUp})", "MAIN");
                    }
                };

                // Selecionar a APÓS registrar o handler
                if (GlobalVars.IdUp > 0)
                {
                    var upSelecionada = unidades.FirstOrDefault(u => u.IdUp == GlobalVars.IdUp);
                    if (upSelecionada != null)
                        comboUp.SelectedItem = upSelecionada;
                }
            }

            _viewModel.LoginInfo = $"{GlobalVars.NomeFuncionarioLogado} ({GlobalVars.LoginConectado})";
            _viewModel.DatabaseInfo = $"UP: {GlobalVars.NomeUp}";

            LogHelper.Info($"MainWindow inicializada: {unidades.Count} unidades carregadas.", "MAIN");
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao inicializar MainWindow", ex, "MAIN");
        }
    }

    private void UpdateDataHora()
    {
        if (_viewModel != null)
            _viewModel.DataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    }

    private void SairMenuItem_Click(object? sender, RoutedEventArgs e)
    {
        var confirmWindow = new Window
        {
            Title = "Confirmação",
            Width = 380,
            Height = 160,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            CanResize = false,
            Background = new SolidColorBrush(Color.Parse("#F4F6F8"))
        };

        var textBlock = new TextBlock
        {
            Text = "Tem certeza que deseja sair do sistema?",
            TextWrapping = TextWrapping.Wrap,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Margin = new Thickness(20),
            FontSize = 14,
            Foreground = new SolidColorBrush(Color.Parse("#212529"))
        };

        var btnSim = new Button
        {
            Content = "Sim",
            Width = 90,
            Height = 32,
            HorizontalAlignment = HorizontalAlignment.Center,
            Background = new SolidColorBrush(Color.Parse("#DC3545")),
            Foreground = new SolidColorBrush(Color.Parse("#FFFFFF"))
        };

        var btnNao = new Button
        {
            Content = "Não",
            Width = 90,
            Height = 32,
            HorizontalAlignment = HorizontalAlignment.Center
        };

        var buttonPanel = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Center,
            Spacing = 16
        };
        buttonPanel.Children.Add(btnSim);
        buttonPanel.Children.Add(btnNao);

        var panel = new DockPanel
        {
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Center,
            Margin = new Thickness(0, 30, 0, 0)
        };
        DockPanel.SetDock(textBlock, Dock.Top);
        panel.Children.Add(textBlock);
        panel.Children.Add(buttonPanel);

        confirmWindow.Content = panel;

        btnSim.Click += (_, _) =>
        {
            LogHelper.LogAccess("SAIR", "Usuário encerrou o sistema.");
            confirmWindow.Close();
            CloseApplication();
        };

        btnNao.Click += (_, _) => confirmWindow.Close();

        confirmWindow.Show();
    }

    private static void CloseApplication()
    {
        if (Avalonia.Application.Current?.ApplicationLifetime
            is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
        else
        {
            Environment.Exit(0);
        }
    }
}
