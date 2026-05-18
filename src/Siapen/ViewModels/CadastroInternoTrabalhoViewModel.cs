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

namespace Siapen.ViewModels;

/// <summary>
/// Grid item for historico_trabalho sub-grid
/// </summary>
public class HistoricoTrabalhoGridItem
{
    public string Documento { get; set; } = "";
    public string Data { get; set; } = "";
    public string LocalTrabalho { get; set; } = "";
    public string SetorTrabalho { get; set; } = "";
    public string Funcao { get; set; } = "";
    public string Obs { get; set; } = "";
    public string DataSaida { get; set; } = "";
    public string MotivoSaida { get; set; } = "";
}

/// <summary>
/// Grid item for calc_setor_trabalho (Remição - Dados)
/// </summary>
public class RemicaoGridItem
{
    public string DataInicial { get; set; } = "";
    public string DataFinal { get; set; } = "";
    public string DiasTrabalhado { get; set; } = "";
}

/// <summary>
/// Grid item for atestado_trabalho (Remição - Certidão)
/// </summary>
public class CertidaoGridItem
{
    public string DataInicial { get; set; } = "";
    public string DataFinal { get; set; } = "";
    public string SaldoAnterior { get; set; } = "";
    public string DiasTrabalhado { get; set; } = "";
    public string TotalDias { get; set; } = "";
    public string DiasRemido { get; set; } = "";
    public string SaldoProxima { get; set; } = "";
}

/// <summary>
/// Grid item for historico_interno (Histórico tab)
/// </summary>
public class HistoricoInternoGridItem
{
    public string DataHora { get; set; } = "";
    public string Setor { get; set; } = "";
    public string Descricao { get; set; } = "";
}

public partial class CadastroInternoTrabalhoViewModel : ModeloCadastroViewModel
{
    // === Identificação (read-only from INTERNO) ===
    [ObservableProperty] private int _idInterno;
    [ObservableProperty] private string _nomeInterno = string.Empty;
    [ObservableProperty] private string _rgi = string.Empty;
    [ObservableProperty] private string _vulgo = string.Empty;
    [ObservableProperty] private string _status = "A";
    [ObservableProperty] private string _sexo = string.Empty;
    [ObservableProperty] private string _nomeUp = string.Empty;
    [ObservableProperty] private string _pavilhao = string.Empty;
    [ObservableProperty] private string _galeria = string.Empty;
    [ObservableProperty] private string _solario = string.Empty;
    [ObservableProperty] private string _cela = string.Empty;

    // === Trabalho > Lançamento ===
    [ObservableProperty] private string _docTrabalho = string.Empty;
    [ObservableProperty] private DateTime? _dataSetor;
    [ObservableProperty] private int? _idFuncaoInterno;
    [ObservableProperty] private int? _idLocalTrabalho;
    [ObservableProperty] private int? _idSetorTrabalho;
    [ObservableProperty] private string _tipoAtividade = string.Empty;
    [ObservableProperty] private string _obsTrabalho = string.Empty;

    // === Lookups Lançamento ===
    [ObservableProperty] private LookupItem? _selectedFuncaoInterno;
    [ObservableProperty] private LookupItem? _selectedLocalTrabalho;
    [ObservableProperty] private LookupItem? _selectedSetorTrabalho;

    public List<LookupItem> FuncoesInterno { get; } = new();
    public List<LookupItem> LocaisTrabalho { get; } = new();
    public List<LookupItem> SetoresTrabalho { get; } = new();

    // === Trabalho > Horários ===
    [ObservableProperty] private string _horarioSaidaSaidao = string.Empty;
    [ObservableProperty] private string _horarioEntradaSaidao = string.Empty;
    [ObservableProperty] private string _turmaSaidao = string.Empty;
    [ObservableProperty] private string _corte = string.Empty;
    [ObservableProperty] private string _horarioSaidaSemanal = string.Empty;
    [ObservableProperty] private string _horarioEntradaSemanal = string.Empty;
    [ObservableProperty] private string _horarioSaidaSabado = string.Empty;
    [ObservableProperty] private string _horarioEntradaSabado = string.Empty;
    [ObservableProperty] private string _horarioSaidaDomingo = string.Empty;
    [ObservableProperty] private string _horarioEntradaDomingo = string.Empty;
    [ObservableProperty] private string _horarioSaidaSeg = string.Empty;
    [ObservableProperty] private string _horarioEntradaSeg = string.Empty;
    [ObservableProperty] private string _horarioSaidaTer = string.Empty;
    [ObservableProperty] private string _horarioEntradaTer = string.Empty;
    [ObservableProperty] private string _horarioSaidaQua = string.Empty;
    [ObservableProperty] private string _horarioEntradaQua = string.Empty;
    [ObservableProperty] private string _horarioSaidaQui = string.Empty;
    [ObservableProperty] private string _horarioEntradaQui = string.Empty;
    [ObservableProperty] private string _horarioSaidaSex = string.Empty;
    [ObservableProperty] private string _horarioEntradaSex = string.Empty;

    // === Remição - Dados ===
    [ObservableProperty] private DateTime? _remicaoDataInicial;
    [ObservableProperty] private DateTime? _remicaoDataFinal;
    [ObservableProperty] private string _remicaoDiasTrabalhado = string.Empty;

    // === Remição - Certidão ===
    [ObservableProperty] private DateTime? _certidaoDataInicial;
    [ObservableProperty] private DateTime? _certidaoDataFinal;
    [ObservableProperty] private string _certidaoSaldoAnterior = string.Empty;
    [ObservableProperty] private string _certidaoDiasTrabalhado = string.Empty;
    [ObservableProperty] private string _certidaoTotalTrabalhado = string.Empty;
    [ObservableProperty] private string _certidaoDiasRemido = string.Empty;
    [ObservableProperty] private string _certidaoSaldoProxima = string.Empty;

    // === Histórico ===
    [ObservableProperty] private DateTime? _historicoData;
    [ObservableProperty] private string _historicoDescricao = string.Empty;

    // === Tab indices ===
    [ObservableProperty] private int _tabTrabalhoIndex;
    [ObservableProperty] private int _tabRemicaoIndex;

    // === Sub-grid items ===
    private List<HistoricoTrabalhoGridItem> _historicoTrabalhoItems = new();
    public List<HistoricoTrabalhoGridItem> HistoricoTrabalhoItems
    {
        get => _historicoTrabalhoItems;
        private set => _historicoTrabalhoItems = value;
    }

    private List<RemicaoGridItem> _remicaoItems = new();
    public List<RemicaoGridItem> RemicaoItems
    {
        get => _remicaoItems;
        private set => _remicaoItems = value;
    }

    private List<CertidaoGridItem> _certidaoItems = new();
    public List<CertidaoGridItem> CertidaoItems
    {
        get => _certidaoItems;
        private set => _certidaoItems = value;
    }

    private List<HistoricoInternoGridItem> _historicoInternoItems = new();
    public List<HistoricoInternoGridItem> HistoricoInternoItems
    {
        get => _historicoInternoItems;
        private set => _historicoInternoItems = value;
    }

    // === Filtro ===
    [ObservableProperty] private bool _filtroAtivo = true;
    [ObservableProperty] private bool _filtroInativo;
    private bool _somenteInativos;

    public CadastroInternoTrabalhoViewModel()
    {
        _orderBy = "nome_interno";
        TituloCadastro = "Cadastro de Trabalho";
        NomeUp = GlobalVars.NomeUp;
    }

    protected override string GetSqlConsulta()
    {
        var sql = "SELECT i.id_interno, i.nome_interno, i.rgi, i.vulgo, i.st, i.sexo, " +
            "u.sigla, p.pavilhao, g.galeria, s.solario, c.cela " +
            "FROM interno i " +
            "LEFT JOIN unidade_penal u ON i.id_up = u.id_up " +
            "LEFT JOIN cela c ON i.idcela = c.id_cela " +
            "LEFT JOIN solario s ON c.idsolario = s.id_solario " +
            "LEFT JOIN galeria g ON s.idgaleria = g.id_galeria " +
            "LEFT JOIN pavilhao p ON g.idpavilhao = p.id_pavilhao " +
            "WHERE i.id_up = @ID_UP ";
        if (_somenteInativos)
            sql += "AND i.st = 'I' ";
        else
            sql += "AND i.st = 'A' ";
        sql += "ORDER BY i.nome_interno ";
        if (_somenteInativos)
            sql += "ROWS 500";
        return sql;
    }

    protected override FbParameter[] GetSqlParametros() =>
        new[] { DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp) };

    protected override string Filtrar(string texto) =>
        $"nome_interno LIKE '%{texto.Replace("'", "''")}%'";

    public override async Task LoadAsync()
    {
        await base.LoadAsync();
        await LoadLookupsAsync();
    }

    private async Task LoadLookupsAsync()
    {
        try
        {
            await Task.Run(() =>
            {
                LoadLookup(FuncoesInterno, "SELECT ID_FUNCAO_INTERNO, FUNCAO_INTERNO FROM FUNCAO_INTERNO ORDER BY FUNCAO_INTERNO");
                LoadLookup(LocaisTrabalho, "SELECT ID_LOCAL_TRABALHO, LOCAL_TRABALHO FROM LOCAL_TRABALHO ORDER BY LOCAL_TRABALHO");
                LoadLookup(SetoresTrabalho, "SELECT ID_SETOR_TRABALHO, SETOR_TRABALHO FROM SETOR_TRABALHO ORDER BY SETOR_TRABALHO");
            });
            OnPropertyChanged(nameof(FuncoesInterno));
            OnPropertyChanged(nameof(LocaisTrabalho));
            OnPropertyChanged(nameof(SetoresTrabalho));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar lookups", ex, nameof(CadastroInternoTrabalhoViewModel));
        }
    }

    private void LoadLookup(List<LookupItem> list, string sql)
    {
        list.Clear();
        var dt = DatabaseService.ExecuteQuery(sql);
        foreach (DataRow row in dt.Rows)
        {
            list.Add(new LookupItem(
                Convert.ToInt32(row[0]),
                row[1]?.ToString()?.Trim() ?? ""));
        }
    }

    /// <summary>
    /// Load sub-tables when an interno is selected
    /// </summary>
    private async Task LoadSubTablesAsync(int idInterno)
    {
        try
        {
            await Task.Run(() =>
            {
                LoadHistoricoTrabalho(idInterno);
                LoadRemicaoDados(idInterno);
                LoadCertidao(idInterno);
                LoadHistoricoInterno(idInterno);
            });
            OnPropertyChanged(nameof(HistoricoTrabalhoItems));
            OnPropertyChanged(nameof(RemicaoItems));
            OnPropertyChanged(nameof(CertidaoItems));
            OnPropertyChanged(nameof(HistoricoInternoItems));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar sub-tabelas", ex, nameof(CadastroInternoTrabalhoViewModel));
        }
    }

    private void LoadHistoricoTrabalho(int idInterno)
    {
        var dt = DatabaseService.ExecuteQuery(
            "SELECT DOCUMENTO, DATA, OBS, DATA_SAIDA, MOTIVO_SAIDA, " +
            "ID_LOCAL_TRABALHO, ID_SETOR_TRABALHO, ID_FUNCAO_INTERNO " +
            "FROM historico_trabalho WHERE id_interno = @ID ORDER BY DATA DESC",
            DatabaseService.CreateParameter("@ID", idInterno));

        var items = new List<HistoricoTrabalhoGridItem>();
        foreach (DataRow row in dt.Rows)
        {
            items.Add(new HistoricoTrabalhoGridItem
            {
                Documento = row["DOCUMENTO"]?.ToString()?.Trim() ?? "",
                Data = FormatDate(row["DATA"]),
                LocalTrabalho = GetLookupDisplayName(LocaisTrabalho, GetInt(row, "ID_LOCAL_TRABALHO")),
                SetorTrabalho = GetLookupDisplayName(SetoresTrabalho, GetInt(row, "ID_SETOR_TRABALHO")),
                Funcao = GetLookupDisplayName(FuncoesInterno, GetInt(row, "ID_FUNCAO_INTERNO")),
                Obs = row["OBS"]?.ToString()?.Trim() ?? "",
                DataSaida = FormatDate(row["DATA_SAIDA"]),
                MotivoSaida = row["MOTIVO_SAIDA"]?.ToString()?.Trim() ?? ""
            });
        }
        HistoricoTrabalhoItems = items;
    }

    private void LoadRemicaoDados(int idInterno)
    {
        var dt = DatabaseService.ExecuteQuery(
            "SELECT DATA_INICIAL, DATA_FINAL, QTDEDIASTRABALHADO " +
            "FROM calc_setor_trabalho WHERE id_interno = @ID ORDER BY DATA_INICIAL DESC",
            DatabaseService.CreateParameter("@ID", idInterno));

        var items = new List<RemicaoGridItem>();
        foreach (DataRow row in dt.Rows)
        {
            items.Add(new RemicaoGridItem
            {
                DataInicial = FormatDate(row["DATA_INICIAL"]),
                DataFinal = FormatDate(row["DATA_FINAL"]),
                DiasTrabalhado = row["QTDEDIASTRABALHADO"]?.ToString()?.Trim() ?? ""
            });
        }
        RemicaoItems = items;
    }

    private void LoadCertidao(int idInterno)
    {
        var dt = DatabaseService.ExecuteQuery(
            "SELECT DATA_INICIAL, DATA_FINAL, SALDO_ANTERIOR, DIAS_TRABALHADO, " +
            "TOTAL_DIAS, DIAS_REMIDO, SALDO_PROXIMA " +
            "FROM atestado_trabalho WHERE id_interno = @ID ORDER BY DATA_INICIAL",
            DatabaseService.CreateParameter("@ID", idInterno));

        var items = new List<CertidaoGridItem>();
        foreach (DataRow row in dt.Rows)
        {
            items.Add(new CertidaoGridItem
            {
                DataInicial = FormatDate(row["DATA_INICIAL"]),
                DataFinal = FormatDate(row["DATA_FINAL"]),
                SaldoAnterior = row["SALDO_ANTERIOR"]?.ToString()?.Trim() ?? "",
                DiasTrabalhado = row["DIAS_TRABALHADO"]?.ToString()?.Trim() ?? "",
                TotalDias = row["TOTAL_DIAS"]?.ToString()?.Trim() ?? "",
                DiasRemido = row["DIAS_REMIDO"]?.ToString()?.Trim() ?? "",
                SaldoProxima = row["SALDO_PROXIMA"]?.ToString()?.Trim() ?? ""
            });
        }
        CertidaoItems = items;
    }

    private void LoadHistoricoInterno(int idInterno)
    {
        var dt = DatabaseService.ExecuteQuery(
            "SELECT DATA_HORA, SETOR, DESCRICAO " +
            "FROM historico_interno WHERE id_interno = @ID AND SETOR LIKE 'Trabalho' " +
            "ORDER BY DATA_HORA DESC",
            DatabaseService.CreateParameter("@ID", idInterno));

        var items = new List<HistoricoInternoGridItem>();
        foreach (DataRow row in dt.Rows)
        {
            items.Add(new HistoricoInternoGridItem
            {
                DataHora = FormatDateTime(row["DATA_HORA"]),
                Setor = row["SETOR"]?.ToString()?.Trim() ?? "",
                Descricao = row["DESCRICAO"]?.ToString()?.Trim() ?? ""
            });
        }
        HistoricoInternoItems = items;
    }

    private static string FormatDate(object? value)
    {
        if (value == null || value == DBNull.Value) return "";
        if (value is DateTime dt) return dt.ToString("dd/MM/yyyy");
        return value.ToString()?.Trim() ?? "";
    }

    private static string FormatDateTime(object? value)
    {
        if (value == null || value == DBNull.Value) return "";
        if (value is DateTime dt) return dt.ToString("dd/MM/yyyy HH:mm");
        return value.ToString()?.Trim() ?? "";
    }

    private static string GetLookupDisplayName(List<LookupItem> list, int? id)
    {
        if (id == null) return "";
        var item = list.FirstOrDefault(x => x.Id == id);
        return item?.DisplayName ?? "";
    }

    private static int? GetInt(DataRow row, string column)
    {
        var val = row[column];
        if (val == null || val == DBNull.Value) return null;
        return Convert.ToInt32(val);
    }

    partial void OnFiltroAtivoChanged(bool value)
    {
        if (value)
        {
            FiltroInativo = false;
            _somenteInativos = false;
            StatusFilter = null;
            _ = LoadAsync();
        }
    }

    partial void OnFiltroInativoChanged(bool value)
    {
        if (value)
        {
            FiltroAtivo = false;
            _somenteInativos = true;
            StatusFilter = null;
            _ = LoadAsync();
        }
    }

    partial void OnSelectedFuncaoInternoChanged(LookupItem? value) => IdFuncaoInterno = value?.Id;
    partial void OnSelectedLocalTrabalhoChanged(LookupItem? value) => IdLocalTrabalho = value?.Id;
    partial void OnSelectedSetorTrabalhoChanged(LookupItem? value) => IdSetorTrabalho = value?.Id;

    [RelayCommand]
    private async Task CarregarRegistroSelecionado()
    {
        if (SelectedRow != null && Modo == CadastroModo.Navegando)
        {
            PreencherCampos();
            await LoadSubTablesAsync(IdInterno);
            TabIndex = 0;
        }
    }

    protected override void LimparCampos()
    {
        IdInterno = 0;
        NomeInterno = string.Empty;
        Rgi = string.Empty;
        Vulgo = string.Empty;
        Status = "A";
        Sexo = string.Empty;
        NomeUp = GlobalVars.NomeUp;
        Pavilhao = string.Empty;
        Galeria = string.Empty;
        Solario = string.Empty;
        Cela = string.Empty;
        DocTrabalho = string.Empty;
        DataSetor = null;
        IdFuncaoInterno = null;
        IdLocalTrabalho = null;
        IdSetorTrabalho = null;
        TipoAtividade = string.Empty;
        ObsTrabalho = string.Empty;
        SelectedFuncaoInterno = null;
        SelectedLocalTrabalho = null;
        SelectedSetorTrabalho = null;
        HorarioSaidaSaidao = string.Empty;
        HorarioEntradaSaidao = string.Empty;
        TurmaSaidao = string.Empty;
        Corte = string.Empty;
        HorarioSaidaSemanal = string.Empty;
        HorarioEntradaSemanal = string.Empty;
        HorarioSaidaSabado = string.Empty;
        HorarioEntradaSabado = string.Empty;
        HorarioSaidaDomingo = string.Empty;
        HorarioEntradaDomingo = string.Empty;
        HorarioSaidaSeg = string.Empty;
        HorarioEntradaSeg = string.Empty;
        HorarioSaidaTer = string.Empty;
        HorarioEntradaTer = string.Empty;
        HorarioSaidaQua = string.Empty;
        HorarioEntradaQua = string.Empty;
        HorarioSaidaQui = string.Empty;
        HorarioEntradaQui = string.Empty;
        HorarioSaidaSex = string.Empty;
        HorarioEntradaSex = string.Empty;
        RemicaoDataInicial = null;
        RemicaoDataFinal = null;
        RemicaoDiasTrabalhado = string.Empty;
        CertidaoDataInicial = null;
        CertidaoDataFinal = null;
        CertidaoSaldoAnterior = string.Empty;
        CertidaoDiasTrabalhado = string.Empty;
        CertidaoTotalTrabalhado = string.Empty;
        CertidaoDiasRemido = string.Empty;
        CertidaoSaldoProxima = string.Empty;
        HistoricoData = null;
        HistoricoDescricao = string.Empty;
        HistoricoTrabalhoItems = new List<HistoricoTrabalhoGridItem>();
        RemicaoItems = new List<RemicaoGridItem>();
        CertidaoItems = new List<CertidaoGridItem>();
        HistoricoInternoItems = new List<HistoricoInternoGridItem>();
    }

    protected override void PreencherCampos()
    {
        if (SelectedRow == null) return;
        IdInterno = GetInt(SelectedRow, "id_interno") ?? 0;
        NomeInterno = GetString(SelectedRow, "nome_interno");
        Rgi = GetString(SelectedRow, "rgi");
        Vulgo = GetString(SelectedRow, "vulgo");
        Status = GetString(SelectedRow, "st");
        Sexo = GetString(SelectedRow, "sexo");
        NomeUp = GetString(SelectedRow, "sigla");
        Pavilhao = GetString(SelectedRow, "pavilhao");
        Galeria = GetString(SelectedRow, "galeria");
        Solario = GetString(SelectedRow, "solario");
        Cela = GetString(SelectedRow, "cela");
    }

    protected override bool ValidarCampos()
    {
        if (IdInterno <= 0)
        {
            StatusMessage = "Selecione um interno.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(DocTrabalho))
        {
            StatusMessage = "O campo Nº Documento é obrigatório.";
            return false;
        }
        return true;
    }

    protected override object CreateGridItem(DataRow row)
    {
        return new InternoGridItem
        {
            IdInterno = Convert.ToInt32(row["id_interno"]),
            NomeInterno = row["nome_interno"]?.ToString()?.Trim() ?? "",
            Rgi = row["rgi"]?.ToString()?.Trim() ?? "",
            Vulgo = row["vulgo"]?.ToString()?.Trim() ?? "",
            Status = row["st"]?.ToString()?.Trim() ?? "A",
            Sigla = row["sigla"]?.ToString()?.Trim() ?? ""
        };
    }

    protected override async Task InserirAsync()
    {
        await Task.Run(() =>
        {
            // Update INTERNO fields related to work
            DatabaseService.ExecuteNonQuery(
                "UPDATE interno SET " +
                "doc_trabalho = @DOC, data_setor = @DATA_SETOR, " +
                "id_funcaointerno = @ID_FUNCAO, id_local_trabalho = @ID_LOCAL, " +
                "idsetor_trabalho = @ID_SETOR, tipo_atividade = @TIPO, " +
                "obstrabalho = @OBS, " +
                "horario_saida_saidao = @H_SAIDA_SAIDAO, horario_entrada_saidao = @H_ENT_SAIDAO, " +
                "turma_saidao = @TURMA, corte = @CORTE, " +
                "horario_saida_semanal = @H_SAIDA_SEM, horario_entrada_semanal = @H_ENT_SEM, " +
                "horario_saida_sabado = @H_SAIDA_SAB, horario_entrada_sabado = @H_ENT_SAB, " +
                "horario_saida_domingo = @H_SAIDA_DOM, horario_entrada_domingo = @H_ENT_DOM, " +
                "horario_saida_seg = @H_SAIDA_SEG, horario_entrada_seg = @H_ENT_SEG, " +
                "horario_saida_ter = @H_SAIDA_TER, horario_entrada_ter = @H_ENT_TER, " +
                "horario_saida_qua = @H_SAIDA_QUA, horario_entrada_qua = @H_ENT_QUA, " +
                "horario_saida_qui = @H_SAIDA_QUI, horario_entrada_qui = @H_ENT_QUI, " +
                "horario_saida_sex = @H_SAIDA_SEX, horario_entrada_sex = @H_ENT_SEX " +
                "WHERE id_interno = @ID",
                DatabaseService.CreateParameter("@ID", IdInterno),
                DatabaseService.CreateParameter("@DOC", DocTrabalho?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@DATA_SETOR", (object?)DataSetor ?? DBNull.Value),
                DatabaseService.CreateParameter("@ID_FUNCAO", (object?)IdFuncaoInterno ?? DBNull.Value),
                DatabaseService.CreateParameter("@ID_LOCAL", (object?)IdLocalTrabalho ?? DBNull.Value),
                DatabaseService.CreateParameter("@ID_SETOR", (object?)IdSetorTrabalho ?? DBNull.Value),
                DatabaseService.CreateParameter("@TIPO", TipoAtividade?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@OBS", ObsTrabalho?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_SAIDA_SAIDAO", HorarioSaidaSaidao?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_ENT_SAIDAO", HorarioEntradaSaidao?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@TURMA", TurmaSaidao?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@CORTE", Corte?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_SAIDA_SEM", HorarioSaidaSemanal?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_ENT_SEM", HorarioEntradaSemanal?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_SAIDA_SAB", HorarioSaidaSabado?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_ENT_SAB", HorarioEntradaSabado?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_SAIDA_DOM", HorarioSaidaDomingo?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_ENT_DOM", HorarioEntradaDomingo?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_SAIDA_SEG", HorarioSaidaSeg?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_ENT_SEG", HorarioEntradaSeg?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_SAIDA_TER", HorarioSaidaTer?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_ENT_TER", HorarioEntradaTer?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_SAIDA_QUA", HorarioSaidaQua?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_ENT_QUA", HorarioEntradaQua?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_SAIDA_QUI", HorarioSaidaQui?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_ENT_QUI", HorarioEntradaQui?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_SAIDA_SEX", HorarioSaidaSex?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@H_ENT_SEX", HorarioEntradaSex?.Trim() ?? (object)DBNull.Value));
        });
    }

    protected override async Task AtualizarAsync()
    {
        // Same as insert — UPDATE statement
        await InserirAsync();
    }

    protected override async Task ExcluirAsync()
    {
        await Task.Run(() =>
        {
            // Clear work fields on INTERNO
            DatabaseService.ExecuteNonQuery(
                "UPDATE interno SET " +
                "doc_trabalho = NULL, data_setor = NULL, " +
                "id_funcaointerno = NULL, id_local_trabalho = NULL, " +
                "idsetor_trabalho = NULL, tipo_atividade = NULL, " +
                "obstrabalho = NULL " +
                "WHERE id_interno = @ID",
                DatabaseService.CreateParameter("@ID", IdInterno));
        });
    }
}
