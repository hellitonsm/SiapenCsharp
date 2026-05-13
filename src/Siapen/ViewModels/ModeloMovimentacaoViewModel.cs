using System;
using System.Data;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FirebirdSql.Data.FirebirdClient;
using Siapen.Helpers;
using Siapen.Services;

namespace Siapen.ViewModels;

public partial class ModeloMovimentacaoViewModel : ViewModelBase
{
    [ObservableProperty]
    private CadastroModo _modo = CadastroModo.Navegando;

    [ObservableProperty]
    private string _statusMessage = "Status: Navegando";

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private DataView? _consultaDataSource;

    [ObservableProperty]
    private DataRowView? _consultaSelectedRow;

    [ObservableProperty]
    private DataView? _movimentoDataSource;

    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty]
    private bool _camposHabilitados;

    [ObservableProperty]
    private string _tituloMovimentacao = "Movimentação";

    protected DataTable? _consultaTable;
    protected DataTable? _movimentoTable;
    protected string _orderBy = string.Empty;

    public ModeloMovimentacaoViewModel()
    {
    }

    protected virtual string GetSqlConsulta() => string.Empty;
    protected virtual FbParameter[] GetSqlParametrosConsulta() => Array.Empty<FbParameter>();
    protected virtual string GetSqlMovimento() => string.Empty;
    protected virtual FbParameter[] GetSqlParametrosMovimento() => Array.Empty<FbParameter>();

    public virtual async Task LoadAsync()
    {
        IsLoading = true;
        try
        {
            var sqlConsulta = GetSqlConsulta();
            var parametros = GetSqlParametrosConsulta();
            _consultaTable = await Task.Run(() => DatabaseService.ExecuteQuery(sqlConsulta, parametros));
            ConsultaDataSource = _consultaTable.DefaultView;
            if (!string.IsNullOrEmpty(_orderBy))
                ConsultaDataSource.Sort = _orderBy;

            var sqlMov = GetSqlMovimento();
            if (!string.IsNullOrEmpty(sqlMov))
            {
                var paramMov = GetSqlParametrosMovimento();
                _movimentoTable = await Task.Run(() => DatabaseService.ExecuteQuery(sqlMov, paramMov));
                MovimentoDataSource = _movimentoTable.DefaultView;
            }

            StatusMessage = $"Registros: {_consultaTable.Rows.Count}";
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar dados", ex, GetType().Name);
            StatusMessage = $"Erro: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }

    partial void OnSearchTextChanged(string value)
    {
        if (ConsultaDataSource == null) return;
        if (string.IsNullOrWhiteSpace(value))
            ConsultaDataSource.RowFilter = string.Empty;
        else
            ConsultaDataSource.RowFilter = Filtrar(value);
    }

    protected virtual string Filtrar(string texto) => string.Empty;

    partial void OnModoChanged(CadastroModo value)
    {
        CamposHabilitados = value != CadastroModo.Navegando;
        StatusMessage = value switch
        {
            CadastroModo.Inserindo => "Status: Inserindo novo registro",
            CadastroModo.Editando => "Status: Editando registro",
            _ => "Status: Navegando"
        };
    }

    [RelayCommand]
    protected virtual void Novo()
    {
        if (Modo != CadastroModo.Navegando) return;
        Modo = CadastroModo.Inserindo;
        LimparCampos();
    }

    [RelayCommand]
    protected virtual void Editar()
    {
        if (Modo != CadastroModo.Navegando) return;
        if (ConsultaSelectedRow == null) return;
        Modo = CadastroModo.Editando;
        PreencherCampos();
    }

    [RelayCommand]
    protected virtual void Cancelar()
    {
        Modo = CadastroModo.Navegando;
        if (ConsultaSelectedRow != null)
            PreencherCampos();
        else
            LimparCampos();
    }

    [RelayCommand]
    protected virtual async Task Salvar()
    {
        if (Modo == CadastroModo.Navegando) return;
        if (!ValidarCampos()) return;

        IsLoading = true;
        try
        {
            if (Modo == CadastroModo.Inserindo)
                await InserirAsync();
            else
                await AtualizarAsync();

            Modo = CadastroModo.Navegando;
            await LoadAsync();
            StatusMessage = "Registro salvo com sucesso.";
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao salvar", ex, GetType().Name);
            StatusMessage = $"Erro ao salvar: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    protected virtual async Task Excluir()
    {
        if (Modo != CadastroModo.Navegando) return;
        if (ConsultaSelectedRow == null) return;

        IsLoading = true;
        try
        {
            await ExcluirAsync();
            await LoadAsync();
            StatusMessage = "Registro excluído com sucesso.";
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao excluir", ex, GetType().Name);
            StatusMessage = $"Erro ao excluir: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    protected virtual void Fechar()
    {
    }

    protected virtual void LimparCampos() { }
    protected virtual void PreencherCampos() { }
    protected virtual bool ValidarCampos() => true;
    protected virtual Task InserirAsync() => Task.CompletedTask;
    protected virtual Task AtualizarAsync() => Task.CompletedTask;
    protected virtual Task ExcluirAsync() => Task.CompletedTask;
}
