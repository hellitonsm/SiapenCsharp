using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FirebirdSql.Data.FirebirdClient;
using Siapen.Helpers;
using Siapen.Services;

namespace Siapen.ViewModels;

public enum CadastroModo
{
    Navegando,
    Inserindo,
    Editando
}

public abstract partial class ModeloCadastroViewModel : ViewModelBase
{
    [ObservableProperty]
    private CadastroModo _modo = CadastroModo.Navegando;

    [ObservableProperty]
    private string _statusMessage = "Status do cadastro: Navegando";

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private DataView? _dataSource;

    [ObservableProperty]
    private DataRowView? _selectedRow;

    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty]
    private string _tituloCadastro = "Cadastro";

    [ObservableProperty]
    private bool _camposHabilitados;

    [ObservableProperty]
    private int _tabIndex;

    public DataView? DataViewSource => DataSource;
    public DataTable? DataTableSource => _dataTable;

    private IList? _gridItems;
    public IList? GridItems
    {
        get => _gridItems;
        private set => _gridItems = value;
    }

    protected DataTable? _dataTable;
    protected string _orderBy = string.Empty;
    private object? _selectedGridItem;

    public object? SelectedGridItem
    {
        get => _selectedGridItem;
        set
        {
            if (SetProperty(ref _selectedGridItem, value) && value != null && DataSource != null && GridItems != null)
            {
                int idx = GridItems.IndexOf(value);
                if (idx >= 0 && idx < DataSource.Count)
                    SelectedRow = DataSource[idx];
            }
        }
    }

    protected abstract string GetSqlConsulta();
    protected virtual FbParameter[] GetSqlParametros() => Array.Empty<FbParameter>();

    protected ModeloCadastroViewModel()
    {
    }

    partial void OnSelectedRowChanged(DataRowView? value)
    {
        if (value != null && Modo == CadastroModo.Navegando)
            PreencherCampos();
    }

    partial void OnTabIndexChanged(int value)
    {
        if (value == 1 && DataSource != null)
            OnPropertyChanged(nameof(DataViewSource));
    }

    /// <summary>
    /// Status filter expression for DataView.RowFilter (e.g. "st = 'A'" or "st = 'I'").
    /// Combined with search text filter when both are active.
    /// </summary>
    protected string? StatusFilter { get; set; }

    private void ApplyFilters()
    {
        if (DataSource == null) return;
        var filters = new List<string>();
        if (!string.IsNullOrEmpty(StatusFilter))
            filters.Add(StatusFilter);
        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            var textFilter = Filtrar(SearchText);
            if (!string.IsNullOrEmpty(textFilter))
                filters.Add(textFilter);
        }
        DataSource.RowFilter = filters.Count > 0 ? string.Join(" AND ", filters) : string.Empty;
        GridItems = DataSource.Cast<DataRowView>().Select(r => CreateGridItem(r.Row)).ToList();
        OnPropertyChanged(nameof(GridItems));
        StatusMessage = $"Registros: {DataSource.Count}";
    }

    partial void OnSearchTextChanged(string value)
    {
        ApplyFilters();
    }

    protected virtual string Filtrar(string texto)
    {
        return string.Empty;
    }

    public virtual async Task LoadAsync()
    {
        IsLoading = true;
        try
        {
            var sql = GetSqlConsulta();
            var parametros = GetSqlParametros();
            LogHelper.Debug($"[LOAD] SQL: {sql?.Replace("\n", " ").Replace("\r", " ").Substring(0, Math.Min(200, sql?.Length ?? 0))}...", GetType().Name);
            LogHelper.Debug($"[LOAD] Params: {(parametros != null ? string.Join(", ", parametros.Select(p => $"{p.ParameterName}={p.Value}")) : "none")}", GetType().Name);
            _dataTable = await Task.Run(() => DatabaseService.ExecuteQuery(sql!, parametros!));
            LogHelper.Debug($"[LOAD] DataTable rows: {_dataTable?.Rows.Count ?? -1}, cols: {_dataTable?.Columns.Count ?? -1}", GetType().Name);
            if (_dataTable != null && _dataTable.Columns.Count > 0)
            {
                LogHelper.Debug($"[LOAD] Columns: {string.Join(", ", _dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName))}", GetType().Name);
            }
            DataSource = _dataTable?.DefaultView;
            if (!string.IsNullOrEmpty(_orderBy) && DataSource != null)
                DataSource.Sort = _orderBy;
            // Apply status filter if set (e.g. "st = 'A'")
            if (!string.IsNullOrEmpty(StatusFilter) && DataSource != null)
                DataSource.RowFilter = StatusFilter;
            if (DataSource != null)
            {
                var items = DataSource.Cast<DataRowView>().ToList();
                LogHelper.Debug($"[LOAD] DataView count: {items.Count}", GetType().Name);
                GridItems = items.Select(r => CreateGridItem(r.Row)).ToList();
                LogHelper.Debug($"[LOAD] GridItems count: {GridItems?.Count ?? -1}", GetType().Name);
            }
            else
            {
                LogHelper.Debug("[LOAD] DataSource is NULL!", GetType().Name);
                GridItems = null;
            }
            OnPropertyChanged(nameof(DataViewSource));
            OnPropertyChanged(nameof(GridItems));
            StatusMessage = $"Registros: {DataSource?.Count ?? 0}";
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

    partial void OnModoChanged(CadastroModo value)
    {
        CamposHabilitados = value != CadastroModo.Navegando;
        StatusMessage = value switch
        {
            CadastroModo.Inserindo => "Status do cadastro: Inserindo novo registro",
            CadastroModo.Editando => "Status do cadastro: Editando registro",
            _ => "Status do cadastro: Navegando"
        };
    }

    [RelayCommand]
    protected virtual void Novo()
    {
        if (Modo != CadastroModo.Navegando) return;
        Modo = CadastroModo.Inserindo;
        LimparCampos();
        TabIndex = 0;
    }

    [RelayCommand]
    protected virtual void Editar()
    {
        if (Modo != CadastroModo.Navegando) return;
        if (SelectedRow == null) return;
        Modo = CadastroModo.Editando;
        PreencherCampos();
        TabIndex = 0;
    }

    [RelayCommand]
    protected virtual void Cancelar()
    {
        Modo = CadastroModo.Navegando;
        if (SelectedRow != null)
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
        if (SelectedRow == null) return;

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

    [RelayCommand]
    protected void NavegarPrimeiro()
    {
        if (DataSource != null && DataSource.Count > 0)
            SelectedRow = DataSource[0];
    }

    [RelayCommand]
    protected void NavegarAnterior()
    {
        if (DataSource == null || SelectedRow == null) return;
        int idx = GetRowIndex(SelectedRow);
        if (idx > 0)
            SelectedRow = DataSource[idx - 1];
    }

    [RelayCommand]
    protected void NavegarProximo()
    {
        if (DataSource == null || SelectedRow == null) return;
        int idx = GetRowIndex(SelectedRow);
        if (idx < DataSource.Count - 1)
            SelectedRow = DataSource[idx + 1];
    }

    private int GetRowIndex(DataRowView row)
    {
        if (DataSource == null) return -1;
        for (int i = 0; i < DataSource.Count; i++)
            if (DataSource[i] == row) return i;
        return -1;
    }

    [RelayCommand]
    protected void NavegarUltimo()
    {
        if (DataSource != null && DataSource.Count > 0)
            SelectedRow = DataSource[DataSource.Count - 1];
    }

    protected abstract void LimparCampos();
    protected abstract void PreencherCampos();
    protected abstract bool ValidarCampos();
    protected abstract object CreateGridItem(DataRow row);
    protected abstract Task InserirAsync();
    protected abstract Task AtualizarAsync();
    protected abstract Task ExcluirAsync();

    protected int? GetInt(DataRowView row, string column)
    {
        var val = row[column];
        if (val == null || val == DBNull.Value) return null;
        return Convert.ToInt32(val);
    }

    protected string GetString(DataRowView row, string column)
    {
        var val = row[column];
        if (val == null || val == DBNull.Value) return string.Empty;
        return val.ToString()!.Trim();
    }

    protected DateTime? GetDateTime(DataRowView row, string column)
    {
        var val = row[column];
        if (val == null || val == DBNull.Value) return null;
        return Convert.ToDateTime(val);
    }

    protected decimal? GetDecimal(DataRowView row, string column)
    {
        var val = row[column];
        if (val == null || val == DBNull.Value) return null;
        return Convert.ToDecimal(val);
    }
}
