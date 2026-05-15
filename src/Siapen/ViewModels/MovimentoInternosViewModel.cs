using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FirebirdSql.Data.FirebirdClient;
using Siapen.Helpers;
using Siapen.Models;
using Siapen.Services;
using Siapen.Views;

namespace Siapen.ViewModels;

public partial class MovimentoInternosViewModel : ModeloMovimentacaoViewModel
{
    // Filter state
    [ObservableProperty]
    private int _filtroStatusIndex = 0; // 0=Ativo, 1=Inativo

    [ObservableProperty]
    private bool _usarSoundex;

    // Grid items for typed binding
    [ObservableProperty]
    private IList<MovimentoInternosGridItem> _gridItems = new List<MovimentoInternosGridItem>();

    [ObservableProperty]
    private MovimentoInternosGridItem? _selectedGridItem;

    // Cadastro fields - Aba Dados
    [ObservableProperty]
    private string _nomeInterno = string.Empty;

    [ObservableProperty]
    private string _rgi = string.Empty;

    [ObservableProperty]
    private string _vulgo = string.Empty;

    [ObservableProperty]
    private string _mae = string.Empty;

    [ObservableProperty]
    private string _pai = string.Empty;

    [ObservableProperty]
    private int _sexoIndex = -1; // 0=Masculino, 1=Feminino

    [ObservableProperty]
    private int _statusIndex = 0; // 0=Ativo, 1=Inativo

    [ObservableProperty]
    private string _dataEntrada = string.Empty;

    [ObservableProperty]
    private string _ciOfMovimento = string.Empty;

    [ObservableProperty]
    private string _numeroRoupa = string.Empty;

    [ObservableProperty]
    private string _emTransito = "N";

    // Lookup ComboBoxes
    [ObservableProperty]
    private List<LookupItem> _procedencias = new();

    [ObservableProperty]
    private LookupItem? _selectedProcedencia;

    [ObservableProperty]
    private List<LookupItem> _destinos = new();

    [ObservableProperty]
    private LookupItem? _selectedDestino;

    [ObservableProperty]
    private List<LookupItem> _condicoesInterno = new();

    [ObservableProperty]
    private LookupItem? _selectedCondicaoInterno;

    [ObservableProperty]
    private List<LookupItem> _setoresTrabalho = new();

    [ObservableProperty]
    private LookupItem? _selectedSetorTrabalho;

    // Aba Saída
    [ObservableProperty]
    private string _dataSaida = string.Empty;

    [ObservableProperty]
    private string _motivoSaida = string.Empty;

    [ObservableProperty]
    private string _ciOfSaida = string.Empty;

    // Aba Cela - RadioGroups
    [ObservableProperty]
    private List<LookupItem> _pavilhoes = new();

    [ObservableProperty]
    private LookupItem? _selectedPavilhao;

    [ObservableProperty]
    private List<LookupItem> _galerias = new();

    [ObservableProperty]
    private LookupItem? _selectedGaleria;

    [ObservableProperty]
    private List<LookupItem> _solarios = new();

    [ObservableProperty]
    private LookupItem? _selectedSolario;

    [ObservableProperty]
    private List<LookupItem> _celas = new();

    [ObservableProperty]
    private LookupItem? _selectedCela;

    // Current interno ID for editing
    private int _currentIdInterno;
    private string _statusOld = "A";
    private string _emTransitoOld = "N";

    public MovimentoInternosViewModel() : base()
    {
        TituloMovimentacao = "Movimentação de Internos";
    }

    #region SQL Queries

    protected override string GetSqlConsulta()
    {
        return @"
            SELECT
                i.id_interno,
                i.id_up,
                i.nome_interno,
                i.nome_fonetica,
                up.sigla,
                p.pavilhao,
                s.solario,
                c.cela,
                i.st,
                i.status,
                i.em_transito,
                i.idpavilhao,
                i.idgaleria,
                i.idsolario,
                i.numero_roupa
            FROM interno i
            INNER JOIN unidade_penal up ON up.id_up = i.id_up
            LEFT JOIN pavilhao p ON p.id_pavilhao = i.idpavilhao
            LEFT JOIN galeria g ON g.id_galeria = i.idgaleria
            LEFT JOIN solario s ON s.id_solario = i.idsolario
            LEFT JOIN cela c ON c.id_cela = i.idcela
            WHERE i.id_up = @id_up
            ORDER BY i.nome_interno";
    }

    protected override FbParameter[] GetSqlParametrosConsulta()
    {
        return new[]
        {
            new FbParameter("@id_up", GlobalVars.IdUp)
        };
    }

    protected override string GetSqlMovimento()
    {
        return @"
            SELECT
                mi.id_mov_interno,
                mi.id_interno,
                mi.id_unidade_penal,
                mi.tipo_movimentacao,
                mi.data_movimentacao,
                mi.hora_movimentacao,
                mi.id_funcionario,
                (SELECT procedencia FROM procedencia WHERE procedencia.id_procedencia = mi.id_procedencia) AS procedencia,
                (SELECT destino FROM destino WHERE destino.id_destino = mi.id_destino) AS destino
            FROM mov_interno mi
            WHERE mi.id_interno = @id_interno";
    }

    protected override FbParameter[] GetSqlParametrosMovimento()
    {
        return new[]
        {
            new FbParameter("@id_interno", _currentIdInterno)
        };
    }

    #endregion

    #region Load

    public override async Task LoadAsync()
    {
        IsLoading = true;
        try
        {
            // Load consultation grid
            var sqlConsulta = GetSqlConsulta();
            var parametros = GetSqlParametrosConsulta();
            _consultaTable = await Task.Run(() => DatabaseService.ExecuteQuery(sqlConsulta, parametros));
            ConsultaDataSource = _consultaTable.DefaultView;

            // Build typed grid items
            BuildGridItems();

            // Load lookup tables
            await LoadLookupsAsync();

            StatusMessage = $"Registros: {_consultaTable.Rows.Count}";
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar MovimentoInternos", ex, GetType().Name);
            StatusMessage = $"Erro: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }

    private void BuildGridItems()
    {
        GridItems = new List<MovimentoInternosGridItem>();
        if (_consultaTable == null) return;

        foreach (DataRow row in _consultaTable.Rows)
        {
            GridItems.Add(new MovimentoInternosGridItem
            {
                IdInterno = Convert.ToInt32(row["id_interno"]),
                IdUp = Convert.ToInt32(row["id_up"]),
                NomeInterno = row["nome_interno"]?.ToString()?.Trim() ?? "",
                NomeFonetica = row["nome_fonetica"]?.ToString()?.Trim() ?? "",
                Sigla = row["sigla"]?.ToString()?.Trim() ?? "",
                Pavilhao = row["pavilhao"]?.ToString()?.Trim() ?? "",
                Solario = row["solario"]?.ToString()?.Trim() ?? "",
                Cela = row["cela"]?.ToString()?.Trim() ?? "",
                St = row["st"]?.ToString()?.Trim() ?? "A",
                Status = row["status"]?.ToString()?.Trim() ?? "A",
                EmTransito = row["em_transito"]?.ToString()?.Trim() ?? "N",
                IdPavilhao = row["idpavilhao"] == DBNull.Value ? 0 : Convert.ToInt32(row["idpavilhao"]),
                IdGaleria = row["idgaleria"] == DBNull.Value ? 0 : Convert.ToInt32(row["idgaleria"]),
                IdSolario = row["idsolario"] == DBNull.Value ? 0 : Convert.ToInt32(row["idsolario"]),
                NumeroRoupa = row["numero_roupa"]?.ToString()?.Trim() ?? ""
            });
        }
    }

    private async Task LoadLookupsAsync()
    {
        try
        {
            // Procedencias
            var dtProc = await Task.Run(() => DatabaseService.ExecuteQuery(
                "SELECT id_procedencia, procedencia FROM procedencia ORDER BY procedencia"));
            Procedencias = dtProc.AsEnumerable().Select(r => new LookupItem(
                Convert.ToInt32(r["id_procedencia"]),
                r["procedencia"]?.ToString()?.Trim() ?? ""
            )).ToList();

            // Destinos
            var dtDest = await Task.Run(() => DatabaseService.ExecuteQuery(
                "SELECT id_destino, destino FROM destino ORDER BY destino"));
            Destinos = dtDest.AsEnumerable().Select(r => new LookupItem(
                Convert.ToInt32(r["id_destino"]),
                r["destino"]?.ToString()?.Trim() ?? ""
            )).ToList();

            // Condições Interno
            var dtCond = await Task.Run(() => DatabaseService.ExecuteQuery(
                "SELECT id_condicao_interno, descricao FROM condicao_interno ORDER BY descricao"));
            CondicoesInterno = dtCond.AsEnumerable().Select(r => new LookupItem(
                Convert.ToInt32(r["id_condicao_interno"]),
                r["descricao"]?.ToString()?.Trim() ?? ""
            )).ToList();

            // Setores Trabalho
            var dtSetor = await Task.Run(() => DatabaseService.ExecuteQuery(
                "SELECT id_setor_trabalho, setor_trabalho FROM setor_trabalho ORDER BY setor_trabalho"));
            SetoresTrabalho = dtSetor.AsEnumerable().Select(r => new LookupItem(
                Convert.ToInt32(r["id_setor_trabalho"]),
                r["setor_trabalho"]?.ToString()?.Trim() ?? ""
            )).ToList();

            // Pavilhões for this UP
            await LoadPavilhoesAsync();
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar lookups", ex, GetType().Name);
        }
    }

    private async Task LoadPavilhoesAsync()
    {
        var dt = await Task.Run(() => DatabaseService.GetPavilhoes(GlobalVars.IdUp));
        Pavilhoes = dt.AsEnumerable().Select(r => new LookupItem(
            Convert.ToInt32(r["id_pavilhao"]),
            r["pavilhao"]?.ToString()?.Trim() ?? ""
        )).ToList();
    }

    #endregion

    #region Filter

    partial void OnFiltroStatusIndexChanged(int value)
    {
        ApplyFilter();
    }

    partial void OnUsarSoundexChanged(bool value)
    {
        ApplyFilter();
    }

    protected override string Filtrar(string texto)
    {
        return string.Empty; // Filtering done in ApplyFilter
    }

    private void ApplyFilter()
    {
        if (ConsultaDataSource == null) return;

        string status = FiltroStatusIndex == 0 ? "A" : "I";
        var filtered = GridItems.Where(g => g.St == status).ToList();

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            string search = SearchText.ToUpper().Trim();
            if (UsarSoundex)
            {
                // Phonetic search - simplified: match nome_interno or nome_fonetica containing search
                filtered = filtered.Where(g =>
                    g.NomeInterno.ToUpper().Contains(search) ||
                    g.NomeFonetica.ToUpper().Contains(search)).ToList();
            }
            else
            {
                filtered = filtered.Where(g =>
                    g.NomeInterno.ToUpper().Contains(search)).ToList();
            }
        }

        GridItems = filtered;
        StatusMessage = $"Registros: {filtered.Count}";
    }

    #endregion

    #region Selection Sync

    partial void OnSelectedGridItemChanged(MovimentoInternosGridItem? value)
    {
        if (value == null || Modo != CadastroModo.Navegando) return;
        // Load movimento grid for selected interno
        _currentIdInterno = value.IdInterno;
        _ = LoadMovimentoAsync();
    }

    private async Task LoadMovimentoAsync()
    {
        try
        {
            var sqlMov = GetSqlMovimento();
            var paramMov = GetSqlParametrosMovimento();
            _movimentoTable = await Task.Run(() => DatabaseService.ExecuteQuery(sqlMov, paramMov));
            MovimentoDataSource = _movimentoTable.DefaultView;
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar movimentação", ex, GetType().Name);
        }
    }

    #endregion

    #region CRUD - Etapa 1: Basic structure

    protected override void LimparCampos()
    {
        NomeInterno = string.Empty;
        Rgi = string.Empty;
        Vulgo = string.Empty;
        Mae = string.Empty;
        Pai = string.Empty;
        SexoIndex = -1;
        StatusIndex = 0;
        DataEntrada = string.Empty;
        CiOfMovimento = string.Empty;
        NumeroRoupa = string.Empty;
        EmTransito = "N";
        SelectedProcedencia = null;
        SelectedDestino = null;
        SelectedCondicaoInterno = null;
        SelectedSetorTrabalho = null;
        DataSaida = string.Empty;
        MotivoSaida = string.Empty;
        CiOfSaida = string.Empty;
        SelectedPavilhao = null;
        SelectedGaleria = null;
        SelectedSolario = null;
        SelectedCela = null;
        Galerias.Clear();
        Solarios.Clear();
        Celas.Clear();
    }

    protected override void PreencherCampos()
    {
        if (SelectedGridItem == null) return;
        // Full field loading will be implemented in Etapa 2
    }

    protected override bool ValidarCampos()
    {
        // Validation will be implemented in Etapa 2
        return true;
    }

    protected override async Task InserirAsync()
    {
        // Insert logic will be implemented in Etapa 2
        await Task.CompletedTask;
    }

    protected override async Task AtualizarAsync()
    {
        // Update logic will be implemented in Etapa 2
        await Task.CompletedTask;
    }

    protected override async Task ExcluirAsync()
    {
        // Delete not available in original Delphi (Excluir button is hidden)
        await Task.CompletedTask;
    }

    #endregion

    #region Cell Cascade (Etapa 3)

    partial void OnSelectedPavilhaoChanged(LookupItem? value)
    {
        if (value == null || Modo == CadastroModo.Navegando) return;
        _ = LoadGaleriasAsync(value.Id);
        SelectedGaleria = null;
        SelectedSolario = null;
        SelectedCela = null;
        Solarios.Clear();
        Celas.Clear();
    }

    partial void OnSelectedGaleriaChanged(LookupItem? value)
    {
        if (value == null || Modo == CadastroModo.Navegando) return;
        _ = LoadSolariosAsync(value.Id);
        SelectedSolario = null;
        SelectedCela = null;
        Celas.Clear();
    }

    partial void OnSelectedSolarioChanged(LookupItem? value)
    {
        if (value == null || Modo == CadastroModo.Navegando) return;
        _ = LoadCelasAsync(value.Id);
        SelectedCela = null;
    }

    private async Task LoadGaleriasAsync(int idPavilhao)
    {
        var dt = await Task.Run(() => DatabaseService.GetGalerias(idPavilhao));
        Galerias = dt.AsEnumerable().Select(r => new LookupItem(
            Convert.ToInt32(r["id_galeria"]),
            r["galeria"]?.ToString()?.Trim() ?? ""
        )).ToList();
    }

    private async Task LoadSolariosAsync(int idGaleria)
    {
        var dt = await Task.Run(() => DatabaseService.GetSolarios(idGaleria));
        Solarios = dt.AsEnumerable().Select(r => new LookupItem(
            Convert.ToInt32(r["id_solario"]),
            r["solario"]?.ToString()?.Trim() ?? ""
        )).ToList();
    }

    private async Task LoadCelasAsync(int idSolario)
    {
        var dt = await Task.Run(() => DatabaseService.GetCelas(idSolario));
        Celas = dt.AsEnumerable().Select(r => new LookupItem(
            Convert.ToInt32(r["id_cela"]),
            r["cela"]?.ToString()?.Trim() ?? ""
        )).ToList();
    }

    #endregion
}
