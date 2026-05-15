using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
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

    [ObservableProperty]
    private string _dataSetor = string.Empty;

    [ObservableProperty]
    private string _dataSaida = string.Empty;

    [ObservableProperty]
    private string _motivoSaida = string.Empty;

    [ObservableProperty]
    private string _ciOfSaida = string.Empty;

    [ObservableProperty]
    private string _dataIsolamento = string.Empty;

    [ObservableProperty]
    private string _statusIsolamento = string.Empty;

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

    // Aba Cela - ComboBoxes
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
        // NOTE: nome_fonetica column does not exist in the INTERNO table.
        // The original DFM used '' as nome_interno_soundex (empty placeholder).
        // We use the same approach here.
        return @"
            SELECT
                i.id_interno,
                i.id_up,
                i.nome_interno,
                '' as nome_fonetica,
                up.sigla,
                p.pavilhao,
                s.solario,
                c.cela,
                i.st,
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

    #region Grid Item Factory

    protected override object CreateGridItem(DataRow row)
    {
        // NOTE: 'status' column does not exist in the INTERNO table.
        // The original DFM used iif(interno.st='A','ATIVO','INATIVO') as status.
        // We derive it from 'st' here.
        string st = row["st"]?.ToString()?.Trim() ?? "A";
        string status = st == "A" ? "ATIVO" : "INATIVO";

        return new MovimentoInternosGridItem
        {
            IdInterno = Convert.ToInt32(row["id_interno"]),
            IdUp = Convert.ToInt32(row["id_up"]),
            NomeInterno = row["nome_interno"]?.ToString()?.Trim() ?? "",
            NomeFonetica = row["nome_fonetica"]?.ToString()?.Trim() ?? "",
            Sigla = row["sigla"]?.ToString()?.Trim() ?? "",
            Pavilhao = row["pavilhao"]?.ToString()?.Trim() ?? "",
            Solario = row["solario"]?.ToString()?.Trim() ?? "",
            Cela = row["cela"]?.ToString()?.Trim() ?? "",
            St = st,
            Status = status,
            EmTransito = row["em_transito"]?.ToString()?.Trim() ?? "N",
            IdPavilhao = row["idpavilhao"] == DBNull.Value ? 0 : Convert.ToInt32(row["idpavilhao"]),
            IdGaleria = row["idgaleria"] == DBNull.Value ? 0 : Convert.ToInt32(row["idgaleria"]),
            IdSolario = row["idsolario"] == DBNull.Value ? 0 : Convert.ToInt32(row["idsolario"]),
            NumeroRoupa = row["numero_roupa"]?.ToString()?.Trim() ?? ""
        };
    }

    #endregion

    #region Load

    public override async Task LoadAsync()
    {
        IsLoading = true;
        try
        {
            LogHelper.Debug($"[LOAD] START — IdUp={GlobalVars.IdUp}, IsLoading={IsLoading}", GetType().Name);
            LogHelper.Debug($"[LOAD] SQL Consulta: {GetSqlConsulta()?.Replace("\n", " ").Replace("\r", " ").Substring(0, Math.Min(300, GetSqlConsulta()?.Length ?? 0))}", GetType().Name);
            var sw = System.Diagnostics.Stopwatch.StartNew();

            await base.LoadAsync();
            sw.Stop();
            LogHelper.Debug($"[LOAD] base.LoadAsync done in {sw.ElapsedMilliseconds}ms — ConsultaDataSource={ConsultaDataSource?.Count ?? -1}, GridItems={GridItems?.Count ?? -1}", GetType().Name);

            sw.Restart();
            await LoadLookupsAsync();
            sw.Stop();
            LogHelper.Debug($"[LOAD] LoadLookupsAsync done in {sw.ElapsedMilliseconds}ms", GetType().Name);

            ApplyStatusFilter();
            LogHelper.Debug($"[LOAD] After ApplyStatusFilter: GridItems={GridItems?.Count ?? -1}", GetType().Name);
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar MovimentoInternos", ex, GetType().Name);
            StatusMessage = $"Erro: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
            LogHelper.Debug($"[LOAD] END — StatusMessage='{StatusMessage}'", GetType().Name);
        }
    }

    private async Task LoadLookupsAsync()
    {
        try
        {
            LogHelper.Debug("[LOOKUP] Loading Procedencias...", GetType().Name);
            var dtProc = await Task.Run(() => DatabaseService.ExecuteQuery(
                "SELECT id_procedencia, procedencia FROM procedencia ORDER BY procedencia"));
            Procedencias = dtProc.AsEnumerable().Select(r => new LookupItem(
                Convert.ToInt32(r["id_procedencia"]),
                r["procedencia"]?.ToString()?.Trim() ?? ""
            )).ToList();
            LogHelper.Debug($"[LOOKUP] Procedencias: {Procedencias?.Count ?? 0}", GetType().Name);

            LogHelper.Debug("[LOOKUP] Loading Destinos...", GetType().Name);
            var dtDest = await Task.Run(() => DatabaseService.ExecuteQuery(
                "SELECT id_destino, destino FROM destino ORDER BY destino"));
            Destinos = dtDest.AsEnumerable().Select(r => new LookupItem(
                Convert.ToInt32(r["id_destino"]),
                r["destino"]?.ToString()?.Trim() ?? ""
            )).ToList();
            LogHelper.Debug($"[LOOKUP] Destinos: {Destinos?.Count ?? 0}", GetType().Name);

            LogHelper.Debug("[LOOKUP] Loading CondicoesInterno...", GetType().Name);
            var dtCond = await Task.Run(() => DatabaseService.ExecuteQuery(
                "SELECT id_condicao_interno, descricao FROM condicao_interno ORDER BY descricao"));
            CondicoesInterno = dtCond.AsEnumerable().Select(r => new LookupItem(
                Convert.ToInt32(r["id_condicao_interno"]),
                r["descricao"]?.ToString()?.Trim() ?? ""
            )).ToList();
            LogHelper.Debug($"[LOOKUP] CondicoesInterno: {CondicoesInterno?.Count ?? 0}", GetType().Name);

            LogHelper.Debug("[LOOKUP] Loading SetoresTrabalho...", GetType().Name);
            var dtSetor = await Task.Run(() => DatabaseService.ExecuteQuery(
                "SELECT id_setor_trabalho, setor_trabalho FROM setor_trabalho ORDER BY setor_trabalho"));
            SetoresTrabalho = dtSetor.AsEnumerable().Select(r => new LookupItem(
                Convert.ToInt32(r["id_setor_trabalho"]),
                r["setor_trabalho"]?.ToString()?.Trim() ?? ""
            )).ToList();
            LogHelper.Debug($"[LOOKUP] SetoresTrabalho: {SetoresTrabalho?.Count ?? 0}", GetType().Name);

            LogHelper.Debug($"[LOOKUP] Loading Pavilhoes for IdUp={GlobalVars.IdUp}...", GetType().Name);
            await LoadPavilhoesAsync();
            LogHelper.Debug($"[LOOKUP] Pavilhoes: {Pavilhoes?.Count ?? 0}", GetType().Name);
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar lookups", ex, GetType().Name);
        }
    }

    private async Task LoadPavilhoesAsync()
    {
        var dt = await Task.Run(() => DatabaseService.GetPavilhoes(GlobalVars.IdUp));
        LogHelper.Debug($"[LOOKUP] GetPavilhoes returned {dt?.Rows.Count ?? 0} rows", GetType().Name);
        Pavilhoes = dt.AsEnumerable().Select(r => new LookupItem(
            Convert.ToInt32(r["id_pavilhao"]),
            r["pavilhao"]?.ToString()?.Trim() ?? ""
        )).ToList();
    }

    #endregion

    #region Filter

    partial void OnFiltroStatusIndexChanged(int value)
    {
        ApplyStatusFilter();
    }

    partial void OnUsarSoundexChanged(bool value)
    {
        ApplyStatusFilter();
    }

    protected override string Filtrar(string texto)
    {
        string status = FiltroStatusIndex == 0 ? "A" : "I";

        if (string.IsNullOrWhiteSpace(texto))
        {
            string f = $"st = '{status}'";
            LogHelper.Debug($"[FILTRAR] texto vazio, filter='{f}'", GetType().Name);
            return f;
        }

        string search = texto.Replace("'", "''");
        string filter = $"st = '{status}' AND nome_interno LIKE '%{search}%'";
        LogHelper.Debug($"[FILTRAR] texto='{texto}', filter='{filter}'", GetType().Name);
        return filter;
    }

    private void ApplyStatusFilter()
    {
        LogHelper.Debug($"[FILTER] START: ConsultaDataSource={ConsultaDataSource?.Count ?? -1}, FiltroStatusIndex={FiltroStatusIndex}, SearchText='{SearchText}', UsarSoundex={UsarSoundex}", GetType().Name);
        if (ConsultaDataSource == null)
        {
            LogHelper.Warning("[FILTER] ConsultaDataSource is NULL!", GetType().Name);
            return;
        }

        string status = FiltroStatusIndex == 0 ? "A" : "I";
        var allItems = ConsultaDataSource.Cast<DataRowView>().Select(r => CreateGridItem(r.Row)).ToList();
        LogHelper.Debug($"[FILTER] allItems={allItems.Count}, filtering by st='{status}'", GetType().Name);
        var filtered = allItems.Where(g => g is MovimentoInternosGridItem item && item.St == status).ToList();
        LogHelper.Debug($"[FILTER] after st filter: {filtered.Count}", GetType().Name);

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            string search = SearchText.ToUpper().Trim();
            filtered = filtered.Where(g => g is MovimentoInternosGridItem item &&
                item.NomeInterno.ToUpper().Contains(search)).ToList();
            LogHelper.Debug($"[FILTER] after search filter '{search}': {filtered.Count}", GetType().Name);
        }

        GridItems = filtered;
        OnPropertyChanged(nameof(GridItems));
        StatusMessage = $"Registros: {filtered.Count}";
        LogHelper.Debug($"[FILTER] END: GridItems={GridItems?.Count ?? -1}, StatusMessage='{StatusMessage}'", GetType().Name);
    }

    #endregion

    #region Selection Sync

    protected override void PreencherCampos()
    {
        var gridItem = SelectedGridItem as MovimentoInternosGridItem;
        if (gridItem == null)
        {
            LogHelper.Debug("[PREENCHE] SelectedGridItem is null or not MovimentoInternosGridItem", GetType().Name);
            return;
        }

        LogHelper.Debug($"[PREENCHE] IdInterno={gridItem.IdInterno}, Nome='{gridItem.NomeInterno}', St='{gridItem.St}'", GetType().Name);
        _currentIdInterno = gridItem.IdInterno;

        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT * FROM interno WHERE id_interno = @id",
                new FbParameter("@id", gridItem.IdInterno));

            LogHelper.Debug($"[PREENCHE] Query returned {dt.Rows.Count} rows", GetType().Name);
            if (dt.Rows.Count == 0)
            {
                LogHelper.Warning($"[PREENCHE] Interno id={gridItem.IdInterno} not found in DB!", GetType().Name);
                return;
            }

            var row = dt.Rows[0];
            _statusOld = row["st"]?.ToString()?.Trim() ?? "A";
            _emTransitoOld = row["em_transito"]?.ToString()?.Trim() ?? "N";

            NomeInterno = row["nome_interno"]?.ToString()?.Trim() ?? "";
            Rgi = row["rgi"]?.ToString()?.Trim() ?? "";
            Vulgo = row["vulgo"]?.ToString()?.Trim() ?? "";
            Mae = row["mae"]?.ToString()?.Trim() ?? "";
            Pai = row["pai"]?.ToString()?.Trim() ?? "";
            NumeroRoupa = row["numero_roupa"]?.ToString()?.Trim() ?? "";
            EmTransito = _emTransitoOld;
            DataIsolamento = row["data_isolamento"]?.ToString()?.Trim() ?? "";
            StatusIsolamento = row["status_isolamento"]?.ToString()?.Trim() ?? "";

            // Sexo
            string sexo = row["sexo"]?.ToString()?.Trim() ?? "";
            SexoIndex = sexo == "F" ? 1 : (sexo == "M" ? 0 : -1);

            // Status
            string st = row["st"]?.ToString()?.Trim() ?? "A";
            StatusIndex = st == "I" ? 1 : 0;

            // Dates
            if (row["data_entrada"] != DBNull.Value)
                DataEntrada = Convert.ToDateTime(row["data_entrada"]).ToString("dd/MM/yyyy");
            else
                DataEntrada = string.Empty;

            if (row["data_saida"] != DBNull.Value)
                DataSaida = Convert.ToDateTime(row["data_saida"]).ToString("dd/MM/yyyy");
            else
                DataSaida = string.Empty;

            if (row["data_setor"] != DBNull.Value)
                DataSetor = Convert.ToDateTime(row["data_setor"]).ToString("dd/MM/yyyy");
            else
                DataSetor = string.Empty;

            CiOfMovimento = row["ci"]?.ToString()?.Trim() ?? "";
            MotivoSaida = row["motivo_saida"]?.ToString()?.Trim() ?? "";
            CiOfSaida = row["cisaida"]?.ToString()?.Trim() ?? "";

            // Lookup selections
            int idProc = row["id_procedencia"] == DBNull.Value ? 0 : Convert.ToInt32(row["id_procedencia"]);
            SelectedProcedencia = Procedencias.FirstOrDefault(p => p.Id == idProc);

            int idDest = row["iddestino"] == DBNull.Value ? 0 : Convert.ToInt32(row["iddestino"]);
            SelectedDestino = Destinos.FirstOrDefault(d => d.Id == idDest);

            int idCond = row["idcondicao_interno"] == DBNull.Value ? 0 : Convert.ToInt32(row["idcondicao_interno"]);
            SelectedCondicaoInterno = CondicoesInterno.FirstOrDefault(c => c.Id == idCond);

            int idSetor = row["idsetor_trabalho"] == DBNull.Value ? 0 : Convert.ToInt32(row["idsetor_trabalho"]);
            SelectedSetorTrabalho = SetoresTrabalho.FirstOrDefault(s => s.Id == idSetor);

            // Cell cascade
            int idPav = row["idpavilhao"] == DBNull.Value ? 0 : Convert.ToInt32(row["idpavilhao"]);
            int idGal = row["idgaleria"] == DBNull.Value ? 0 : Convert.ToInt32(row["idgaleria"]);
            int idSol = row["idsolario"] == DBNull.Value ? 0 : Convert.ToInt32(row["idsolario"]);
            int idCela = row["idcela"] == DBNull.Value ? 0 : Convert.ToInt32(row["idcela"]);

            if (idPav > 0)
            {
                SelectedPavilhao = Pavilhoes.FirstOrDefault(p => p.Id == idPav);
                _ = LoadGaleriasAndSetAsync(idPav, idGal, idSol, idCela);
            }

            // Load movement history
            _ = LoadMovimentoAsync();
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao preencher campos", ex, GetType().Name);
        }
    }

    private async Task LoadGaleriasAndSetAsync(int idPavilhao, int idGaleria, int idSolario, int idCela)
    {
        await LoadGaleriasAsync(idPavilhao);
        SelectedGaleria = Galerias.FirstOrDefault(g => g.Id == idGaleria);
        if (idGaleria > 0)
        {
            await LoadSolariosAsync(idGaleria);
            SelectedSolario = Solarios.FirstOrDefault(s => s.Id == idSolario);
            if (idSolario > 0)
            {
                await LoadCelasAsync(idSolario);
                SelectedCela = Celas.FirstOrDefault(c => c.Id == idCela);
            }
        }
    }

    private async Task LoadMovimentoAsync()
    {
        try
        {
            var sqlMov = GetSqlMovimento();
            var paramMov = GetSqlParametrosMovimento();
            LogHelper.Debug($"[MOVIMENTO] Loading history for id_interno={_currentIdInterno}", GetType().Name);
            _movimentoTable = await Task.Run(() => DatabaseService.ExecuteQuery(sqlMov, paramMov));
            MovimentoDataSource = _movimentoTable.DefaultView;
            LogHelper.Debug($"[MOVIMENTO] Loaded {_movimentoTable.Rows.Count} history entries", GetType().Name);
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar movimentação", ex, GetType().Name);
        }
    }

    #endregion

    #region CRUD

    protected override void LimparCampos()
    {
        LogHelper.Debug($"[LIMPAR] Modo={Modo}, _currentIdInterno={_currentIdInterno}", GetType().Name);
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
        DataSetor = string.Empty;
        DataSaida = string.Empty;
        MotivoSaida = string.Empty;
        CiOfSaida = string.Empty;
        DataIsolamento = string.Empty;
        StatusIsolamento = string.Empty;
        SelectedProcedencia = null;
        SelectedDestino = null;
        SelectedCondicaoInterno = null;
        SelectedSetorTrabalho = null;
        SelectedPavilhao = null;
        SelectedGaleria = null;
        SelectedSolario = null;
        SelectedCela = null;
        Galerias.Clear();
        Solarios.Clear();
        Celas.Clear();
        _currentIdInterno = 0;
        _statusOld = "A";
        _emTransitoOld = "N";
    }

    protected override bool ValidarCampos()
    {
        LogHelper.Debug($"[VALIDAR] Nome='{NomeInterno}', DataEntrada='{DataEntrada}', SexoIndex={SexoIndex}, StatusIndex={StatusIndex}, Procedencia={SelectedProcedencia?.DisplayName ?? "null"}, Cela={SelectedCela?.DisplayName ?? "null"}", GetType().Name);

        if (string.IsNullOrWhiteSpace(DataEntrada))
        {
            StatusMessage = "Digite a Data de Entrada!";
            LogHelper.Debug($"[VALIDAR] FAIL: {StatusMessage}", GetType().Name);
            return false;
        }

        if (!LibHelper.ValidaData(DataEntrada))
        {
            StatusMessage = "Data de Entrada inválida!";
            LogHelper.Debug($"[VALIDAR] FAIL: {StatusMessage}", GetType().Name);
            return false;
        }

        if (SexoIndex < 0)
        {
            StatusMessage = "Informe o sexo!";
            LogHelper.Debug($"[VALIDAR] FAIL: {StatusMessage}", GetType().Name);
            return false;
        }

        if (StatusIndex < 0)
        {
            StatusMessage = "Informe o Status!";
            LogHelper.Debug($"[VALIDAR] FAIL: {StatusMessage}", GetType().Name);
            return false;
        }

        if (SelectedProcedencia == null)
        {
            StatusMessage = "Digite a Procedência!";
            LogHelper.Debug($"[VALIDAR] FAIL: {StatusMessage}", GetType().Name);
            return false;
        }

        if (string.IsNullOrWhiteSpace(NomeInterno))
        {
            StatusMessage = "Digite o Nome do Interno!";
            LogHelper.Debug($"[VALIDAR] FAIL: {StatusMessage}", GetType().Name);
            return false;
        }

        if (StatusIndex == 1)
        {
            if (string.IsNullOrWhiteSpace(DataSaida) || !LibHelper.ValidaData(DataSaida))
            {
                StatusMessage = "Digite a Data da Saída!";
                LogHelper.Debug($"[VALIDAR] FAIL: {StatusMessage}", GetType().Name);
                return false;
            }

            if (string.IsNullOrWhiteSpace(MotivoSaida))
            {
                StatusMessage = "Digite o Motivo!";
                LogHelper.Debug($"[VALIDAR] FAIL: {StatusMessage}", GetType().Name);
                return false;
            }

            if (string.IsNullOrWhiteSpace(CiOfSaida))
            {
                StatusMessage = "Digite a CI/OF SAÍDA!";
                LogHelper.Debug($"[VALIDAR] FAIL: {StatusMessage}", GetType().Name);
                return false;
            }
        }
        else
        {
            if (SelectedCela == null)
            {
                StatusMessage = "Digite a Cela!";
                LogHelper.Debug($"[VALIDAR] FAIL: {StatusMessage}", GetType().Name);
                return false;
            }

            if (Modo == CadastroModo.Inserindo || _statusOld != "A")
            {
                if (string.IsNullOrWhiteSpace(Mae))
                {
                    StatusMessage = "Digite o Nome da Mãe!";
                    LogHelper.Debug($"[VALIDAR] FAIL: {StatusMessage}", GetType().Name);
                    return false;
                }
            }
        }

        LogHelper.Debug("[VALIDAR] OK — all validations passed", GetType().Name);
        return true;
    }

    protected override async Task InserirAsync()
    {
        LogHelper.Debug($"[INSERIR] START — Nome='{NomeInterno}', StatusIndex={StatusIndex}, SexoIndex={SexoIndex}", GetType().Name);

        if (StatusIndex == 0)
        {
            var (ok, msg) = await ValidarCelaAsync();
            if (!ok)
            {
                LogHelper.Warning($"[INSERIR] ValidarCela failed: {msg}", GetType().Name);
                throw new InvalidOperationException(msg);
            }
        }

        var result = await Task.Run(() => DatabaseService.ExecuteScalar(
            "SELECT gen_id(cod_up, 0) || gen_id(ID_INTERNO, 1) FROM RDB$DATABASE"));
        int newId = Convert.ToInt32(result);
        LogHelper.Debug($"[INSERIR] Generated newId={newId}", GetType().Name);

        _currentIdInterno = newId;
        string sexoChar = SexoIndex == 1 ? "F" : "M";
        string statusChar = StatusIndex == 1 ? "I" : "A";
        DateTime dtEntrada = DateTime.ParseExact(DataEntrada, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        LogHelper.Debug($"[INSERIR] INSERT INTO interno — id={newId}, nome='{NomeInterno}', sexo={sexoChar}, st={statusChar}, data={DataEntrada}", GetType().Name);
        await Task.Run(() => DatabaseService.ExecuteNonQuery(
            @"INSERT INTO interno (
                id_interno, id_up, nome_interno, rgi, vulgo, mae, pai, sexo, st,
                data_entrada, ci, numero_roupa, em_transito, id_procedencia,
                idpavilhao, idgaleria, idsolario, idcela, id_funcionario,
                status_isolamento, data_isolamento
            ) VALUES (
                @id_interno, @id_up, @nome, @rgi, @vulgo, @mae, @pai, @sexo, @st,
                @data_entrada, @ci, @numero_roupa, @em_transito, @id_procedencia,
                @idpavilhao, @idgaleria, @idsolario, @idcela, @id_funcionario,
                @status_isolamento, @data_isolamento
            )",
            new FbParameter("@id_interno", newId),
            new FbParameter("@id_up", GlobalVars.IdUp),
            new FbParameter("@nome", NomeInterno.Trim()),
            new FbParameter("@rgi", Rgi.Trim()),
            new FbParameter("@vulgo", Vulgo.Trim()),
            new FbParameter("@mae", Mae.Trim()),
            new FbParameter("@pai", Pai.Trim()),
            new FbParameter("@sexo", sexoChar),
            new FbParameter("@st", statusChar),
            new FbParameter("@data_entrada", dtEntrada),
            new FbParameter("@ci", CiOfMovimento.Trim()),
            new FbParameter("@numero_roupa", NumeroRoupa.Trim()),
            new FbParameter("@em_transito", EmTransito),
            new FbParameter("@id_procedencia", SelectedProcedencia?.Id ?? 0),
            new FbParameter("@idpavilhao", SelectedPavilhao?.Id ?? 0),
            new FbParameter("@idgaleria", SelectedGaleria?.Id ?? 0),
            new FbParameter("@idsolario", SelectedSolario?.Id ?? 0),
            new FbParameter("@idcela", SelectedCela?.Id ?? 0),
            new FbParameter("@id_funcionario", GlobalVars.IdFuncionario),
            new FbParameter("@status_isolamento", string.IsNullOrEmpty(StatusIsolamento) ? DBNull.Value : (object)StatusIsolamento),
            new FbParameter("@data_isolamento", string.IsNullOrEmpty(DataIsolamento) ? DBNull.Value : (object)DataIsolamento)
        ));

        if (StatusIndex == 0)
        {
            LogHelper.Debug($"[INSERIR] Adding historico ENTRADA for id={newId}", GetType().Name);
            await AddHistoricoEntry(newId, dtEntrada,
                $"Deu Entrada na Unidade Penal: {GlobalVars.UpLogado}, Procedente {SelectedProcedencia?.DisplayName}, Conforme OF/CI {CiOfMovimento.Trim()}.",
                "E", SelectedProcedencia?.Id ?? 0);
        }

        if (StatusIndex == 1)
        {
            DateTime dtSaida = DateTime.ParseExact(DataSaida, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string descricao = $"Deu Saída da Unidade Penal: {GlobalVars.UpLogado}, Motivo: {MotivoSaida.Trim()}, Conforme CI/OF/AUTOS: {CiOfSaida.Trim()}.";
            LogHelper.Debug($"[INSERIR] Adding historico SAIDA for id={newId}", GetType().Name);
            await AddHistoricoEntry(newId, dtSaida, descricao, "S", SelectedProcedencia?.Id ?? 0);
        }

        LogHelper.Debug($"[INSERIR] END — id={newId} inserted successfully", GetType().Name);
    }

    protected override async Task AtualizarAsync()
    {
        LogHelper.Debug($"[ATUALIZAR] START — id={_currentIdInterno}, Nome='{NomeInterno}', StatusIndex={StatusIndex}, _statusOld='{_statusOld}'", GetType().Name);
        string sexoChar = SexoIndex == 1 ? "F" : "M";
        string statusChar = StatusIndex == 1 ? "I" : "A";
        DateTime dtEntrada = DateTime.ParseExact(DataEntrada, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        if (StatusIndex == 0)
        {
            var (ok, msg) = await ValidarCelaAsync();
            if (!ok)
            {
                LogHelper.Warning($"[ATUALIZAR] ValidarCela failed: {msg}", GetType().Name);
                throw new InvalidOperationException(msg);
            }
        }

        if (StatusIndex == 1)
        {
            // Inactive - update and add output history
            DateTime dtSaida = DateTime.ParseExact(DataSaida, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            await Task.Run(() => DatabaseService.ExecuteNonQuery(
                @"UPDATE interno SET
                    nome_interno = @nome, rgi = @rgi, vulgo = @vulgo, mae = @mae, pai = @pai,
                    sexo = @sexo, st = @st, data_entrada = @data_entrada,
                    ci = @ci, numero_roupa = @numero_roupa, em_transito = @em_transito,
                    id_procedencia = @id_procedencia, data_saida = @data_saida,
                    motivo_saida = @motivo_saida, cisaida = @cisaida,
                    iddestino = @iddestino, id_funcionario = @id_funcionario,
                    data_setor = NULL, idsetor_trabalho = NULL, idcondicao_interno = NULL,
                    idpavilhao = NULL, idgaleria = NULL, idsolario = NULL, idcela = NULL
                WHERE id_interno = @id_interno",
                new FbParameter("@nome", NomeInterno.Trim()),
                new FbParameter("@rgi", Rgi.Trim()),
                new FbParameter("@vulgo", Vulgo.Trim()),
                new FbParameter("@mae", Mae.Trim()),
                new FbParameter("@pai", Pai.Trim()),
                new FbParameter("@sexo", sexoChar),
                new FbParameter("@st", statusChar),
                new FbParameter("@data_entrada", dtEntrada),
                new FbParameter("@ci", CiOfMovimento.Trim()),
                new FbParameter("@numero_roupa", NumeroRoupa.Trim()),
                new FbParameter("@em_transito", EmTransito),
                new FbParameter("@id_procedencia", SelectedProcedencia?.Id ?? 0),
                new FbParameter("@data_saida", dtSaida),
                new FbParameter("@motivo_saida", MotivoSaida.Trim()),
                new FbParameter("@cisaida", CiOfSaida.Trim()),
                new FbParameter("@iddestino", SelectedDestino?.Id ?? 0),
                new FbParameter("@id_funcionario", GlobalVars.IdFuncionario),
                new FbParameter("@id_interno", _currentIdInterno)
            ));

            // Output history
            string descricao = $"Deu Saída da Unidade Penal: {GlobalVars.UpLogado}, Motivo: {MotivoSaida.Trim()}, Conforme CI/OF/AUTOS: {CiOfSaida.Trim()}.";
            if (SelectedDestino != null)
                descricao = $"Deu Saída da Unidade Penal: {GlobalVars.UpLogado}, Motivo: {MotivoSaida.Trim()} Destino: {SelectedDestino.DisplayName}, Conforme OF/CI{CiOfSaida.Trim()}.";

            await AddHistoricoEntry(_currentIdInterno, dtSaida, descricao, "S", SelectedProcedencia?.Id ?? 0);
        }
        else
        {
            // Active - update and handle history
            await Task.Run(() => DatabaseService.ExecuteNonQuery(
                @"UPDATE interno SET
                    nome_interno = @nome, rgi = @rgi, vulgo = @vulgo, mae = @mae, pai = @pai,
                    sexo = @sexo, st = @st, data_entrada = @data_entrada,
                    ci = @ci, numero_roupa = @numero_roupa, em_transito = @em_transito,
                    id_procedencia = @id_procedencia, idpavilhao = @idpavilhao,
                    idgaleria = @idgaleria, idsolario = @idsolario, idcela = @idcela,
                    idsetor_trabalho = @idsetor_trabalho, idcondicao_interno = @idcondicao_interno,
                    data_setor = @data_setor, id_funcionario = @id_funcionario,
                    data_saida = NULL, motivo_saida = NULL, cisaida = NULL, iddestino = NULL,
                    status_isolamento = @status_isolamento, data_isolamento = @data_isolamento
                WHERE id_interno = @id_interno",
                new FbParameter("@nome", NomeInterno.Trim()),
                new FbParameter("@rgi", Rgi.Trim()),
                new FbParameter("@vulgo", Vulgo.Trim()),
                new FbParameter("@mae", Mae.Trim()),
                new FbParameter("@pai", Pai.Trim()),
                new FbParameter("@sexo", sexoChar),
                new FbParameter("@st", statusChar),
                new FbParameter("@data_entrada", dtEntrada),
                new FbParameter("@ci", CiOfMovimento.Trim()),
                new FbParameter("@numero_roupa", NumeroRoupa.Trim()),
                new FbParameter("@em_transito", EmTransito),
                new FbParameter("@id_procedencia", SelectedProcedencia?.Id ?? 0),
                new FbParameter("@idpavilhao", SelectedPavilhao?.Id ?? 0),
                new FbParameter("@idgaleria", SelectedGaleria?.Id ?? 0),
                new FbParameter("@idsolario", SelectedSolario?.Id ?? 0),
                new FbParameter("@idcela", SelectedCela?.Id ?? 0),
                new FbParameter("@idsetor_trabalho", SelectedSetorTrabalho?.Id ?? 0),
                new FbParameter("@idcondicao_interno", SelectedCondicaoInterno?.Id ?? 0),
                new FbParameter("@data_setor", string.IsNullOrEmpty(DataSetor) ? DBNull.Value : (object)DateTime.ParseExact(DataSetor, "dd/MM/yyyy", CultureInfo.InvariantCulture)),
                new FbParameter("@status_isolamento", string.IsNullOrEmpty(StatusIsolamento) ? DBNull.Value : (object)StatusIsolamento),
                new FbParameter("@data_isolamento", string.IsNullOrEmpty(DataIsolamento) ? DBNull.Value : (object)DataIsolamento),
                new FbParameter("@id_funcionario", GlobalVars.IdFuncionario),
                new FbParameter("@id_interno", _currentIdInterno)
            ));

            if (_statusOld != "A")
            {
                LogHelper.Debug($"[ATUALIZAR] Adding historico ENTRADA (reactivated) for id={_currentIdInterno}", GetType().Name);
                await AddHistoricoEntry(_currentIdInterno, dtEntrada,
                    $"Deu Entrada na Unidade Penal: {GlobalVars.UpLogado}, Procedente {SelectedProcedencia?.DisplayName}, Conforme OF/CI {CiOfMovimento.Trim()}.",
                    "E", SelectedProcedencia?.Id ?? 0);
            }

            if (_emTransitoOld != EmTransito)
            {
                string descricao = EmTransito == "S"
                    ? $"Saiu em transito: {GlobalVars.UpLogado}, Destino {SelectedProcedencia?.DisplayName}, Conforme OF/CI {CiOfMovimento.Trim()}."
                    : $"Retorno do transito: {GlobalVars.UpLogado}, Origem {SelectedProcedencia?.DisplayName}, Conforme OF/CI {CiOfMovimento.Trim()}.";
                LogHelper.Debug($"[ATUALIZAR] Adding historico TRANSITO for id={_currentIdInterno}", GetType().Name);
                await AddHistoricoEntry(_currentIdInterno, DateTime.Now, descricao, "S", SelectedProcedencia?.Id ?? 0);
            }
        }

        LogHelper.Debug($"[ATUALIZAR] END — id={_currentIdInterno} updated successfully", GetType().Name);
    }

    protected override async Task ExcluirAsync()
    {
        LogHelper.Debug($"[EXCLUIR] id={_currentIdInterno} — NOT IMPLEMENTED", GetType().Name);
        await Task.CompletedTask;
    }

    /// <summary>
    /// Add a history entry to HISTORICO_INTERNO
    /// </summary>
    private async Task AddHistoricoEntry(int idInterno, DateTime dataHora, string descricao, string status, int idProcedencia)
    {
        try
        {
            LogHelper.Debug($"[HISTORICO] INSERT id_interno={idInterno}, status='{status}', data={dataHora:dd/MM/yyyy}", GetType().Name);
            await Task.Run(() => DatabaseService.ExecuteNonQuery(
                @"INSERT INTO historico_interno (idhistorico_interno, idinterno, data_hora, descricao, status, idprocedencia, idup)
                  VALUES (0, @idinterno, @data_hora, @descricao, @status, @idprocedencia, @idup)",
                new FbParameter("@idinterno", idInterno),
                new FbParameter("@data_hora", dataHora),
                new FbParameter("@descricao", descricao),
                new FbParameter("@status", status),
                new FbParameter("@idprocedencia", idProcedencia),
                new FbParameter("@idup", GlobalVars.IdUp)
            ));
            LogHelper.Debug($"[HISTORICO] INSERT OK for id_interno={idInterno}", GetType().Name);
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao adicionar histórico", ex, GetType().Name);
        }
    }

    #endregion

    #region Cell Validation

    private async Task<(bool ok, string message)> ValidarCelaAsync()
    {
        if (SelectedCela == null)
            return (false, "Selecione uma cela.");

        int idCela = SelectedCela.Id;

        var celaInfo = await Task.Run(() => DatabaseService.GetCelaInfo(idCela));
        if (celaInfo == null)
            return (false, "Cela não encontrada.");

        // Check disciplinary isolation
        string isolamento = celaInfo["isolamento"]?.ToString()?.Trim() ?? "N";
        if (isolamento == "S")
        {
            var dialog = new SituacaoDisciplinarView();
            var topLevel = App.Current?.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop
                ? desktop.MainWindow : null;

            if (topLevel != null)
                await dialog.ShowDialog(topLevel);
            else
                dialog.Show();

            if (!dialog.Confirmed)
                return (false, "Operação cancelada pelo usuário.");

            string situacao = dialog.SelectedOption switch
            {
                0 => "(1) SANCIONADO",
                1 => "(2) SEGURO",
                2 => "(3) EM OBSERVAÇÃO",
                _ => ""
            };
            StatusIsolamento = situacao;
            DataIsolamento = dialog.DataIsolamento;
        }

        // Check maintenance
        string emManutencao = celaInfo["em_manutencao"]?.ToString()?.Trim() ?? "N";
        if (emManutencao == "S")
        {
            string motivoManutencao = celaInfo["motivo_manutencao"]?.ToString()?.Trim() ?? "";
            LogHelper.Info($"Cela em manutenção: {motivoManutencao}", GetType().Name);
        }

        // Check capacity limit
        int limite = celaInfo["limite_por_cela"] == DBNull.Value ? 0 : Convert.ToInt32(celaInfo["limite_por_cela"]);
        if (limite > 0)
        {
            int currentCount = await Task.Run(() =>
                DatabaseService.CountInternosNaCela(idCela, Modo == CadastroModo.Editando ? _currentIdInterno : 0));

            if (currentCount >= limite)
                return (false, $"Favor Informar Outra Cela! Cela com {limite} Preso(a).");
        }

        return (true, "");
    }

    #endregion

    #region Cell Cascade

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
