using System;
using System.Collections;
using System.Data;
using System.Linq;
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

    // Typed grid items (like ModeloCadastroViewModel)
    private IList? _gridItems;
    public IList? GridItems
    {
        get => _gridItems;
        protected set => _gridItems = value;
    }

    private object? _selectedGridItem;
    public object? SelectedGridItem
    {
        get => _selectedGridItem;
        set
        {
            if (SetProperty(ref _selectedGridItem, value) && value != null && ConsultaDataSource != null && GridItems != null)
            {
                int idx = GridItems.IndexOf(value);
                if (idx >= 0 && idx < ConsultaDataSource.Count)
                    ConsultaSelectedRow = ConsultaDataSource[idx];
            }
        }
    }

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

    /// <summary>
    /// Creates a typed grid item from a DataRow. Override to provide typed items.
    /// </summary>
    protected virtual object CreateGridItem(DataRow row) => row;

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

            // Build typed grid items
            GridItems = ConsultaDataSource.Cast<DataRowView>().Select(r => CreateGridItem(r.Row)).ToList();
            OnPropertyChanged(nameof(GridItems));

            var sqlMov = GetSqlMovimento();
            if (!string.IsNullOrEmpty(sqlMov))
            {
                var paramMov = GetSqlParametrosMovimento();
                _movimentoTable = await Task.Run(() => DatabaseService.ExecuteQuery(sqlMov, paramMov));
                MovimentoDataSource = _movimentoTable.DefaultView;
            }

            StatusMessage = $"Registros: {ConsultaDataSource.Count}";
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

    partial void OnConsultaSelectedRowChanged(DataRowView? value)
    {
        if (value != null && Modo == CadastroModo.Navegando && GridItems != null)
        {
            int idx = GetRowIndex(value);
            if (idx >= 0 && idx < GridItems.Count)
                SelectedGridItem = GridItems[idx];
        }
    }

    partial void OnSearchTextChanged(string value)
    {
        if (ConsultaDataSource == null) return;
        if (string.IsNullOrWhiteSpace(value))
            ConsultaDataSource.RowFilter = string.Empty;
        else
            ConsultaDataSource.RowFilter = Filtrar(value);

        // Rebuild grid items after filter
        if (GridItems != null)
        {
            GridItems = ConsultaDataSource.Cast<DataRowView>().Select(r => CreateGridItem(r.Row)).ToList();
            OnPropertyChanged(nameof(GridItems));
        }

        StatusMessage = $"Registros: {ConsultaDataSource.Count}";
    }

    private int GetRowIndex(DataRowView row)
    {
        if (ConsultaDataSource == null) return -1;
        for (int i = 0; i < ConsultaDataSource.Count; i++)
            if (ConsultaDataSource[i] == row) return i;
        return -1;
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
