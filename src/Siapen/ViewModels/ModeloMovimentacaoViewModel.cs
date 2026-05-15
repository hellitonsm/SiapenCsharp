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
            LogHelper.Debug($"[LOAD] SQL: {sqlConsulta?.Replace("\n", " ").Replace("\r", " ").Substring(0, Math.Min(200, sqlConsulta?.Length ?? 0))}...", GetType().Name);
            LogHelper.Debug($"[LOAD] Params: {(parametros != null ? string.Join(", ", parametros.Select(p => $"{p.ParameterName}={p.Value}")) : "none")}", GetType().Name);
            _consultaTable = await Task.Run(() => DatabaseService.ExecuteQuery(sqlConsulta, parametros));
            LogHelper.Debug($"[LOAD] DataTable rows: {_consultaTable?.Rows.Count ?? -1}, cols: {_consultaTable?.Columns.Count ?? -1}", GetType().Name);
            if (_consultaTable != null && _consultaTable.Columns.Count > 0)
            {
                LogHelper.Debug($"[LOAD] Columns: {string.Join(", ", _consultaTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName))}", GetType().Name);
            }
            ConsultaDataSource = _consultaTable?.DefaultView;
            if (!string.IsNullOrEmpty(_orderBy) && ConsultaDataSource != null)
                ConsultaDataSource.Sort = _orderBy;

            if (ConsultaDataSource != null)
            {
                var items = ConsultaDataSource.Cast<DataRowView>().ToList();
                LogHelper.Debug($"[LOAD] DataView count: {items.Count}", GetType().Name);
                GridItems = items.Select(r => CreateGridItem(r.Row)).ToList();
                LogHelper.Debug($"[LOAD] GridItems count: {GridItems?.Count ?? -1}", GetType().Name);
            }
            else
            {
                LogHelper.Debug("[LOAD] ConsultaDataSource is NULL!", GetType().Name);
                GridItems = null;
            }
            OnPropertyChanged(nameof(GridItems));

            var sqlMov = GetSqlMovimento();
            if (!string.IsNullOrEmpty(sqlMov))
            {
                var paramMov = GetSqlParametrosMovimento();
                _movimentoTable = await Task.Run(() => DatabaseService.ExecuteQuery(sqlMov, paramMov));
                MovimentoDataSource = _movimentoTable?.DefaultView;
            }

            StatusMessage = $"Registros: {ConsultaDataSource?.Count ?? 0}";
            LogHelper.Debug($"[LOAD] Done. Status: {StatusMessage}", GetType().Name);
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
        LogHelper.Debug($"[SEARCH] OnSearchTextChanged: value='{value}', ConsultaDataSource={ConsultaDataSource?.Count ?? -1}", GetType().Name);
        if (ConsultaDataSource == null) return;
        if (string.IsNullOrWhiteSpace(value))
            ConsultaDataSource.RowFilter = string.Empty;
        else
            ConsultaDataSource.RowFilter = Filtrar(value);

        LogHelper.Debug($"[SEARCH] RowFilter='{ConsultaDataSource.RowFilter}', count after filter={ConsultaDataSource.Count}", GetType().Name);

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
        LogHelper.Debug($"[CMD] Novo — current Modo={Modo}", GetType().Name);
        if (Modo != CadastroModo.Navegando) return;
        Modo = CadastroModo.Inserindo;
        LimparCampos();
        LogHelper.Debug($"[CMD] Novo — Modo set to Inserindo", GetType().Name);
    }

    [RelayCommand]
    protected virtual void Editar()
    {
        LogHelper.Debug($"[CMD] Editar — current Modo={Modo}, SelectedRow={ConsultaSelectedRow != null}", GetType().Name);
        if (Modo != CadastroModo.Navegando) return;
        if (ConsultaSelectedRow == null) return;
        Modo = CadastroModo.Editando;
        PreencherCampos();
        LogHelper.Debug($"[CMD] Editar — Modo set to Editando", GetType().Name);
    }

    [RelayCommand]
    protected virtual void Cancelar()
    {
        LogHelper.Debug($"[CMD] Cancelar — current Modo={Modo}", GetType().Name);
        Modo = CadastroModo.Navegando;
        if (ConsultaSelectedRow != null)
            PreencherCampos();
        else
            LimparCampos();
        LogHelper.Debug($"[CMD] Cancelar — Modo set to Navegando", GetType().Name);
    }

    [RelayCommand]
    protected virtual async Task Salvar()
    {
        LogHelper.Debug($"[CMD] Salvar — Modo={Modo}", GetType().Name);
        if (Modo == CadastroModo.Navegando) return;
        if (!ValidarCampos())
        {
            LogHelper.Debug($"[CMD] Salvar — validation failed: {StatusMessage}", GetType().Name);
            return;
        }

        IsLoading = true;
        try
        {
            if (Modo == CadastroModo.Inserindo)
            {
                LogHelper.Debug("[CMD] Salvar — calling InserirAsync", GetType().Name);
                await InserirAsync();
            }
            else
            {
                LogHelper.Debug("[CMD] Salvar — calling AtualizarAsync", GetType().Name);
                await AtualizarAsync();
            }

            Modo = CadastroModo.Navegando;
            LogHelper.Debug("[CMD] Salvar — reloading data", GetType().Name);
            await LoadAsync();
            StatusMessage = "Registro salvo com sucesso.";
            LogHelper.Debug($"[CMD] Salvar — done: {StatusMessage}", GetType().Name);
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
        LogHelper.Debug($"[CMD] Excluir — Modo={Modo}, SelectedRow={ConsultaSelectedRow != null}", GetType().Name);
        if (Modo != CadastroModo.Navegando) return;
        if (ConsultaSelectedRow == null) return;

        IsLoading = true;
        try
        {
            await ExcluirAsync();
            await LoadAsync();
            StatusMessage = "Registro excluído com sucesso.";
            LogHelper.Debug($"[CMD] Excluir — done: {StatusMessage}", GetType().Name);
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
