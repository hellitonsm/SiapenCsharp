using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Siapen.Config;
using Siapen.Helpers;
using Siapen.Models;
using Siapen.Services;

namespace Siapen.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string _login = string.Empty;

    [ObservableProperty]
    private string _senha = string.Empty;

    [ObservableProperty]
    private ObservableCollection<UnidadePenal> _unidadesPenal = new();

    [ObservableProperty]
    private UnidadePenal? _selectedUp;

    [ObservableProperty]
    private bool _isConnecting = true;

    /// <summary>
    /// Indica se o botão Entrar deve estar habilitado
    /// </summary>
    public bool PodeEntrar => !IsLoading && !IsConnecting;

    partial void OnIsLoadingChanged(bool value) => OnPropertyChanged(nameof(PodeEntrar));
    partial void OnIsConnectingChanged(bool value) => OnPropertyChanged(nameof(PodeEntrar));

    partial void OnSelectedUpChanged(UnidadePenal? value)
    {
        if (value != null)
        {
            SelectedUpId = value.IdUp;
            SelectedUpNome = value.NomeUp;
            GlobalVars.IdUp = SelectedUpId;
            GlobalVars.NomeUp = SelectedUpNome;
            LogHelper.Debug($"UP selecionada: {value.NomeUp} (ID={value.IdUp})", "LOGIN");
        }
    }

    [ObservableProperty]
    private int _selectedUpId;

    [ObservableProperty]
    private string _selectedUpNome = string.Empty;

    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    /// <summary>
    /// Inicializa a conexão e carrega as unidades penais
    /// </summary>
    public async Task InitializeAsync()
    {
        try
        {
            LogHelper.Info("Inicializando LoginViewModel...", "LOGIN");

            // Carregar configurações
            AppConfig.LoadFromIni();
            LogHelper.Info($"Config: Server={AppConfig.DbServer}, DB={AppConfig.DbDatabase}", "LOGIN");

            // Conectar ao banco
            await Task.Run(() =>
            {
                var connStr = AppConfig.GetConnectionString();
                DatabaseService.Initialize(connStr);
            });

            // Carregar unidades penais
            var unidades = await Task.Run(() => DatabaseService.GetUnidadesPenal());

            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                foreach (var up in unidades)
                {
                    UnidadesPenal.Add(up);
                }
                IsConnecting = false;
            });

            LogHelper.Info($"Carregadas {unidades.Count} unidades penais.", "LOGIN");
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro na inicialização do login", ex, "LOGIN");
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                ErrorMessage = $"Erro ao conectar ao banco: {ex.Message}";
                IsConnecting = false;
            });
        }
    }

    /// <summary>
    /// Detecta a UP do funcionário pelo login e seleciona automaticamente no ComboBox
    /// </summary>
    [RelayCommand]
    private async Task DetectarUpPorLogin()
    {
        if (string.IsNullOrWhiteSpace(Login))
            return;

        try
        {
            var login = Login.Trim();
            int? idUp = await Task.Run(() => DatabaseService.GetIdUpByLogin(login));

            if (idUp.HasValue)
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    var up = UnidadesPenal.FirstOrDefault(u => u.IdUp == idUp.Value);
                    if (up != null)
                    {
                        SelectedUp = up;
                        LogHelper.Debug($"UP detectada automaticamente: {up.NomeUp} (ID={up.IdUp}) para login '{login}'", "LOGIN");
                    }
                });
            }
            else
            {
                LogHelper.Debug($"Nenhuma UP encontrada para login '{login}'", "LOGIN");
            }
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao detectar UP por login", ex, "LOGIN");
        }
    }

    /// <summary>
    /// Tenta fazer login
    /// </summary>
    [RelayCommand]
    private async Task Entrar()
    {
        if (string.IsNullOrWhiteSpace(Login))
        {
            ErrorMessage = "Informe o login.";
            return;
        }

        if (string.IsNullOrWhiteSpace(Senha))
        {
            ErrorMessage = "Informe a senha.";
            return;
        }

        if (SelectedUpId == 0)
        {
            ErrorMessage = "Selecione uma Unidade Penal.";
            return;
        }

        IsLoading = true;
        ErrorMessage = string.Empty;

        try
        {
            var login = Login;
            var senha = Senha;
            var idUp = SelectedUpId;

            var sucesso = await Task.Run(() =>
            {
                try
                {
                    return AuthHelper.Login(login, senha, idUp);
                }
                catch (Exception ex)
                {
                    LogHelper.Error("Exceção no AuthHelper.Login", ex, "LOGIN");
                    throw;
                }
            });

            if (sucesso)
            {
                LogHelper.Info("Login bem-sucedido, abrindo MainWindow.", "LOGIN");
                var mainWindow = new Views.MainWindow();
                mainWindow.Show();

                // Fechar a janela de login
                if (Avalonia.Application.Current?.ApplicationLifetime
                    is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
                {
                    foreach (var window in desktop.Windows)
                    {
                        if (window is Views.LoginWindow loginWindow)
                        {
                            loginWindow.Close();
                            break;
                        }
                    }
                }
            }
            else
            {
                ErrorMessage = "Login, senha ou unidade penal inválidos.";
            }
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao fazer login", ex, "LOGIN");
            ErrorMessage = $"Erro ao fazer login: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }

    /// <summary>
    /// Sai do sistema
    /// </summary>
    [RelayCommand]
    private void Sair()
    {
        LogHelper.LogAccess("SAIR", "Usuário fechou o login.");
        Environment.Exit(0);
    }
}
