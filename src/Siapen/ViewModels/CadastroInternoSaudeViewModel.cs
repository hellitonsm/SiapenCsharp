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

public partial class CadastroInternoSaudeViewModel : ModeloCadastroViewModel
{
    // === Identificação (read-only from interno) ===
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

    // === Saúde - Dados 1 ===
    [ObservableProperty] private string _sus = string.Empty;
    [ObservableProperty] private string _usoDrogas = string.Empty;
    [ObservableProperty] private string _efeitosDroga = string.Empty;
    [ObservableProperty] private string _dataDependencia = string.Empty;
    [ObservableProperty] private string _abandonoDrogas = string.Empty;
    [ObservableProperty] private string _drogasComCrime = string.Empty;
    [ObservableProperty] private string _doencaGrave = string.Empty;
    [ObservableProperty] private string _doencaMental = string.Empty;
    [ObservableProperty] private string _problemaSaude = string.Empty;
    [ObservableProperty] private string _medicacaoControlada = string.Empty;
    [ObservableProperty] private string _doencaInfectoContagiosa = string.Empty;
    [ObservableProperty] private string _tratamentoInfecto = string.Empty;
    [ObservableProperty] private string _resultadoInfecto = string.Empty;

    // === Saúde - Dados 2 ===
    [ObservableProperty] private string _doencaLaboral = string.Empty;
    [ObservableProperty] private string _suicidio = string.Empty;
    [ObservableProperty] private string _cid = string.Empty;
    [ObservableProperty] private string _sintomasDepressivos = string.Empty;
    [ObservableProperty] private string _episodiosHumor = string.Empty;
    [ObservableProperty] private string _sintomasPsicoticos = string.Empty;
    [ObservableProperty] private string _delirios = string.Empty;
    [ObservableProperty] private string _alucinacoes = string.Empty;
    [ObservableProperty] private string _personalidade = string.Empty;

    // === Histórico ===
    [ObservableProperty] private DateTime? _dataHistorico;
    [ObservableProperty] private string _descricaoHistorico = string.Empty;
    [ObservableProperty] private string _setorHistorico = string.Empty;

    // === Dieta ===
    [ObservableProperty] private DateTime? _dataConsultaDieta;
    [ObservableProperty] private DateTime? _dataInicioDieta;
    [ObservableProperty] private DateTime? _dataTerminoDieta;
    [ObservableProperty] private string _descricaoDieta = string.Empty;
    [ObservableProperty] private int? _idMedicoDieta;
    [ObservableProperty] private int? _idTipoDieta;
    [ObservableProperty] private LookupItem? _selectedMedicoDieta;
    [ObservableProperty] private LookupItem? _selectedTipoDieta;

    // === Enfermidade ===
    [ObservableProperty] private int? _idEnfermidade;
    [ObservableProperty] private LookupItem? _selectedEnfermidade;
    [ObservableProperty] private int? _idEnfermidadeInterno;
    [ObservableProperty] private LookupItem? _selectedEnfermidadeInterno;

    // === Remédio ===
    [ObservableProperty] private DateTime? _dataRemedio;
    [ObservableProperty] private int? _idRemedio;
    [ObservableProperty] private LookupItem? _selectedRemedio;
    [ObservableProperty] private string _qtdeRemedio = string.Empty;
    [ObservableProperty] private string _obsRemedio = string.Empty;

    // === Deficiência ===
    [ObservableProperty] private DateTime? _dataDeficiencia;
    [ObservableProperty] private int? _idDeficiencia;
    [ObservableProperty] private LookupItem? _selectedDeficiencia;
    [ObservableProperty] private string _locomocaoDeficiencia = string.Empty;
    [ObservableProperty] private string _membroDeficiencia = string.Empty;
    [ObservableProperty] private string _atrofiaDeficiencia = string.Empty;
    [ObservableProperty] private string _motivoDeficiencia = string.Empty;

    // === Vacina ===
    [ObservableProperty] private DateTime? _dataVacina;
    [ObservableProperty] private int? _idVacina;
    [ObservableProperty] private LookupItem? _selectedVacina;
    [ObservableProperty] private string _doseVacina = string.Empty;

    // === Lookup collections ===
    public List<LookupItem> Medicos { get; } = new();
    public List<LookupItem> TipoDietas { get; } = new();
    public List<LookupItem> Enfermidades { get; } = new();
    public List<LookupItem> Remedios { get; } = new();
    public List<LookupItem> Deficiencias { get; } = new();
    public List<LookupItem> Vacinas { get; } = new();

    // === Sub-grid items ===
    public List<InternoSaudeGridItem> HistoricoSaudeItems { get; set; } = new();
    public List<InternoDietaGridItem> DietaItems { get; set; } = new();
    public List<LookupItem> EnfermidadeInternoItems { get; set; } = new();
    public List<InternoRemedioGridItem> RemedioEnfermidadeItems { get; set; } = new();
    public List<InternoDeficienciaGridItem> DeficienciaInternoItems { get; set; } = new();
    public List<InternoVacinaGridItem> VacinaInternoItems { get; set; } = new();

    // === Filtro ===
    [ObservableProperty] private bool _filtroAtivo = true;
    [ObservableProperty] private bool _filtroInativo;
    private bool _somenteInativos;

    public CadastroInternoSaudeViewModel()
    {
        _orderBy = "nome_interno";
        TituloCadastro = "Cadastro da Saúde";
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
                LoadLookup(Medicos, "SELECT ID_MEDICO, MEDICO FROM MEDICO ORDER BY MEDICO");
                LoadLookup(TipoDietas, "SELECT ID_TIPO_DIETA, TIPO_DIETA FROM TIPO_DIETA ORDER BY TIPO_DIETA");
                LoadLookup(Enfermidades, "SELECT ID_ENFERMIDADE, ENFERMIDADE FROM ENFERMIDADE ORDER BY ENFERMIDADE");
                LoadLookup(Remedios, "SELECT ID_REMEDIO, NOME_REMEDIO FROM REMEDIO ORDER BY NOME_REMEDIO");
                LoadLookup(Deficiencias, "SELECT ID_DEFICIENCIA, DEFICIENCIA FROM DEFICIENCIA ORDER BY DEFICIENCIA");
                LoadLookup(Vacinas, "SELECT ID_VACINA, VACINA FROM VACINA ORDER BY VACINA");
            });
            OnPropertyChanged(nameof(Medicos));
            OnPropertyChanged(nameof(TipoDietas));
            OnPropertyChanged(nameof(Enfermidades));
            OnPropertyChanged(nameof(Remedios));
            OnPropertyChanged(nameof(Deficiencias));
            OnPropertyChanged(nameof(Vacinas));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar lookups de saúde", ex, nameof(CadastroInternoSaudeViewModel));
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

    // === Lookup selection handlers ===
    partial void OnSelectedMedicoDietaChanged(LookupItem? value) => IdMedicoDieta = value?.Id;
    partial void OnSelectedTipoDietaChanged(LookupItem? value) => IdTipoDieta = value?.Id;
    partial void OnSelectedEnfermidadeChanged(LookupItem? value) => IdEnfermidade = value?.Id;
    partial void OnSelectedEnfermidadeInternoChanged(LookupItem? value)
    {
        IdEnfermidadeInterno = value?.Id;
        if (value != null)
            LoadRemedioEnfermidade(value.Id);
    }
    partial void OnSelectedRemedioChanged(LookupItem? value) => IdRemedio = value?.Id;
    partial void OnSelectedDeficienciaChanged(LookupItem? value) => IdDeficiencia = value?.Id;
    partial void OnSelectedVacinaChanged(LookupItem? value) => IdVacina = value?.Id;

    [RelayCommand]
    private void CarregarRegistroSelecionado()
    {
        if (SelectedRow != null && Modo == CadastroModo.Navegando)
        {
            PreencherCampos();
            CarregarSubDados();
            TabIndex = 0;
        }
    }

    /// <summary>
    /// Carrega os sub-dados de saúde do interno selecionado
    /// </summary>
    private void CarregarSubDados()
    {
        if (IdInterno <= 0) return;
        CarregarDadosSaude();
        CarregarHistoricoSaude();
        CarregarDietas();
        CarregarEnfermidades();
        CarregarDeficiencias();
        CarregarVacinas();
    }

    private void CarregarDadosSaude()
    {
        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT SUS, USODROGAS, EFEITOSDROGA, DATADEPENDENCIA, ABANDONODROGAS, " +
                "DROGASCOMCRIME, DOENCAGRAVE, DOENCAMENTAL, PROBLEMASAUDE, MEDICACAOCONTROLADA, " +
                "DOENCAINFECTOCONTAGIOSA, TRATAMENTOINFECTO, RESULTADOINFECTO, " +
                "DOENCALABORAL, SUICIDIO, CID, SINTOMASDEPRESSIVOS, EPISODIOSHUMOR, " +
                "SINTOMASPSICOTICOS, DELIRIOS, ALUCINACOES, PERSONALIDADE " +
                "FROM INTERNO WHERE ID_INTERNO = @ID",
                DatabaseService.CreateParameter("@ID", IdInterno));
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                Sus = GetSafeString(row, "SUS");
                UsoDrogas = GetSafeString(row, "USODROGAS");
                EfeitosDroga = GetSafeString(row, "EFEITOSDROGA");
                DataDependencia = GetSafeString(row, "DATADEPENDENCIA");
                AbandonoDrogas = GetSafeString(row, "ABANDONODROGAS");
                DrogasComCrime = GetSafeString(row, "DROGASCOMCRIME");
                DoencaGrave = GetSafeString(row, "DOENCAGRAVE");
                DoencaMental = GetSafeString(row, "DOENCAMENTAL");
                ProblemaSaude = GetSafeString(row, "PROBLEMASAUDE");
                MedicacaoControlada = GetSafeString(row, "MEDICACAOCONTROLADA");
                DoencaInfectoContagiosa = GetSafeString(row, "DOENCAINFECTOCONTAGIOSA");
                TratamentoInfecto = GetSafeString(row, "TRATAMENTOINFECTO");
                ResultadoInfecto = GetSafeString(row, "RESULTADOINFECTO");
                DoencaLaboral = GetSafeString(row, "DOENCALABORAL");
                Suicidio = GetSafeString(row, "SUICIDIO");
                Cid = GetSafeString(row, "CID");
                SintomasDepressivos = GetSafeString(row, "SINTOMASDEPRESSIVOS");
                EpisodiosHumor = GetSafeString(row, "EPISODIOSHUMOR");
                SintomasPsicoticos = GetSafeString(row, "SINTOMASPSICOTICOS");
                Delirios = GetSafeString(row, "DELIRIOS");
                Alucinacoes = GetSafeString(row, "ALUCINACOES");
                Personalidade = GetSafeString(row, "PERSONALIDADE");
            }
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar dados de saúde", ex, nameof(CadastroInternoSaudeViewModel));
        }
    }

    private void CarregarHistoricoSaude()
    {
        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT hs.DATA, hs.SETOR, hs.DESCRICAO, f.NOME_FUNCIONARIO " +
                "FROM HISTORICO_SAUDE hs " +
                "LEFT JOIN FUNCIONARIO f ON hs.ID_FUNCIONARIO = f.ID_FUNCIONARIO " +
                "WHERE hs.ID_INTERNO = @ID ORDER BY hs.DATA",
                DatabaseService.CreateParameter("@ID", IdInterno));
            HistoricoSaudeItems = dt.Rows.Cast<DataRow>().Select(r => new InternoSaudeGridItem
            {
                Data = r["DATA"] == DBNull.Value ? "" : Convert.ToDateTime(r["DATA"]).ToString("dd/MM/yyyy"),
                Setor = r["SETOR"]?.ToString()?.Trim() ?? "",
                Descricao = r["DESCRICAO"]?.ToString()?.Trim() ?? "",
                Funcionario = r["NOME_FUNCIONARIO"]?.ToString()?.Trim() ?? ""
            }).ToList();
            OnPropertyChanged(nameof(HistoricoSaudeItems));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar histórico de saúde", ex, nameof(CadastroInternoSaudeViewModel));
        }
    }

    private void CarregarDietas()
    {
        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT cd.DATA_CONSULTA, cd.DATA_INICIO, cd.DATA_TERMINO, cd.DESCRICAO, " +
                "m.MEDICO, td.TIPO_DIETA " +
                "FROM CONTROLE_DIETA cd " +
                "LEFT JOIN MEDICO m ON cd.ID_MEDICO = m.ID_MEDICO " +
                "LEFT JOIN TIPO_DIETA td ON cd.ID_TIPO_DIETA = td.ID_TIPO_DIETA " +
                "WHERE cd.ID_INTERNO = @ID ORDER BY cd.DATA_CONSULTA",
                DatabaseService.CreateParameter("@ID", IdInterno));
            DietaItems = dt.Rows.Cast<DataRow>().Select(r => new InternoDietaGridItem
            {
                DataConsulta = r["DATA_CONSULTA"] == DBNull.Value ? "" : Convert.ToDateTime(r["DATA_CONSULTA"]).ToString("dd/MM/yyyy"),
                DataInicio = r["DATA_INICIO"] == DBNull.Value ? "" : Convert.ToDateTime(r["DATA_INICIO"]).ToString("dd/MM/yyyy"),
                DataTermino = r["DATA_TERMINO"] == DBNull.Value ? "" : Convert.ToDateTime(r["DATA_TERMINO"]).ToString("dd/MM/yyyy"),
                Descricao = r["DESCRICAO"]?.ToString()?.Trim() ?? "",
                Medico = r["MEDICO"]?.ToString()?.Trim() ?? "",
                TipoDieta = r["TIPO_DIETA"]?.ToString()?.Trim() ?? ""
            }).ToList();
            OnPropertyChanged(nameof(DietaItems));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar dietas", ex, nameof(CadastroInternoSaudeViewModel));
        }
    }

    private void CarregarEnfermidades()
    {
        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT ei.ID_ENFERMDIADE_INTERNO, e.ENFERMIDADE " +
                "FROM ENFERMDIADE_INTERNO ei " +
                "LEFT JOIN ENFERMIDADE e ON ei.ID_ENFERMIDADE = e.ID_ENFERMIDADE " +
                "WHERE ei.ID_INTERNO = @ID ORDER BY e.ENFERMIDADE",
                DatabaseService.CreateParameter("@ID", IdInterno));
            EnfermidadeInternoItems = dt.Rows.Cast<DataRow>().Select(r => new LookupItem(
                Convert.ToInt32(r["ID_ENFERMDIADE_INTERNO"]),
                r["ENFERMIDADE"]?.ToString()?.Trim() ?? ""
            )).ToList();
            OnPropertyChanged(nameof(EnfermidadeInternoItems));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar enfermidades", ex, nameof(CadastroInternoSaudeViewModel));
        }
    }

    private void LoadRemedioEnfermidade(int idEnfermidadeInterno)
    {
        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT re.DATA_INICIO, re.DATA_FIM, re.QTDE, re.OBS, r.NOME_REMEDIO " +
                "FROM REMEDIO_ENFERMIDADE re " +
                "LEFT JOIN REMEDIO r ON re.ID_REMEDIO = r.ID_REMEDIO " +
                "WHERE re.ID_ENFERMIDADE_INTERNO = @ID ORDER BY re.DATA_INICIO",
                DatabaseService.CreateParameter("@ID", idEnfermidadeInterno));
            RemedioEnfermidadeItems = dt.Rows.Cast<DataRow>().Select(r => new InternoRemedioGridItem
            {
                DataInicio = r["DATA_INICIO"] == DBNull.Value ? "" : Convert.ToDateTime(r["DATA_INICIO"]).ToString("dd/MM/yyyy"),
                DataFim = r["DATA_FIM"] == DBNull.Value ? "" : Convert.ToDateTime(r["DATA_FIM"]).ToString("dd/MM/yyyy"),
                Qtde = r["QTDE"]?.ToString()?.Trim() ?? "",
                Obs = r["OBS"]?.ToString()?.Trim() ?? "",
                Remedio = r["NOME_REMEDIO"]?.ToString()?.Trim() ?? ""
            }).ToList();
            OnPropertyChanged(nameof(RemedioEnfermidadeItems));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar remédios da enfermidade", ex, nameof(CadastroInternoSaudeViewModel));
        }
    }

    private void CarregarDeficiencias()
    {
        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT di.DEFICIENCIA, di.TIPO_LOCOMOCAO, di.MEMBRO, di.TIPO_ATROFIA, di.MOTIVO " +
                "FROM DEFICIENCIA_INTERNO d " +
                "LEFT JOIN DEFICIENCIA di ON d.ID_DEFICIENCIA = di.ID_DEFICIENCIA " + // Note: field is DEFICIENCIA not ID_DEFICIENCIA
                "WHERE d.ID_INTERNO = @ID",
                DatabaseService.CreateParameter("@ID", IdInterno));
            // Fallback query with correct join
            dt = DatabaseService.ExecuteQuery(
                "SELECT df.DEFICIENCIA, d.TIPO_LOCOMOCAO, d.MEMBRO, d.TIPO_ATROFIA, d.MOTIVO " +
                "FROM DEFICIENCIA_INTERNO d " +
                "LEFT JOIN DEFICIENCIA df ON d.ID_DEFICIENCIA = df.ID_DEFICIENCIA " +
                "WHERE d.ID_INTERNO = @ID ORDER BY df.DEFICIENCIA",
                DatabaseService.CreateParameter("@ID", IdInterno));
            DeficienciaInternoItems = dt.Rows.Cast<DataRow>().Select(r => new InternoDeficienciaGridItem
            {
                Deficiencia = r["DEFICIENCIA"]?.ToString()?.Trim() ?? "",
                Locomocao = r["TIPO_LOCOMOCAO"]?.ToString()?.Trim() ?? "",
                Membro = r["MEMBRO"]?.ToString()?.Trim() ?? "",
                Atrofia = r["TIPO_ATROFIA"]?.ToString()?.Trim() ?? "",
                Motivo = r["MOTIVO"]?.ToString()?.Trim() ?? ""
            }).ToList();
            OnPropertyChanged(nameof(DeficienciaInternoItems));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar deficiências", ex, nameof(CadastroInternoSaudeViewModel));
        }
    }

    private void CarregarVacinas()
    {
        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT v.VACINA, vi.DATA_VACINA, vi.DOSE " +
                "FROM VACINA_INTERNO vi " +
                "LEFT JOIN VACINA v ON vi.ID_VACINA = v.ID_VACINA " +
                "WHERE vi.ID_INTERNO = @ID ORDER BY vi.DATA_VACINA",
                DatabaseService.CreateParameter("@ID", IdInterno));
            VacinaInternoItems = dt.Rows.Cast<DataRow>().Select(r => new InternoVacinaGridItem
            {
                Vacina = r["VACINA"]?.ToString()?.Trim() ?? "",
                DataVacina = r["DATA_VACINA"] == DBNull.Value ? "" : Convert.ToDateTime(r["DATA_VACINA"]).ToString("dd/MM/yyyy"),
                Dose = r["DOSE"]?.ToString()?.Trim() ?? ""
            }).ToList();
            OnPropertyChanged(nameof(VacinaInternoItems));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar vacinas", ex, nameof(CadastroInternoSaudeViewModel));
        }
    }

    // === Commands para sub-tabelas ===

    [RelayCommand]
    private void IncluirHistorico()
    {
        if (IdInterno <= 0 || !DataHistorico.HasValue) return;
        try
        {
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO HISTORICO_SAUDE (ID_INTERNO, DATA, SETOR, DESCRICAO, ID_FUNCIONARIO) " +
                "VALUES (@ID, @DATA, @SETOR, @DESCRICAO, @FUNC)",
                DatabaseService.CreateParameter("@ID", IdInterno),
                DatabaseService.CreateParameter("@DATA", DataHistorico.Value),
                DatabaseService.CreateParameter("@SETOR", SetorHistorico ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@DESCRICAO", DescricaoHistorico ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@FUNC", GlobalVars.IdFuncionario));
            CarregarHistoricoSaude();
            DataHistorico = null;
            DescricaoHistorico = string.Empty;
            SetorHistorico = string.Empty;
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao incluir histórico", ex, nameof(CadastroInternoSaudeViewModel));
        }
    }

    [RelayCommand]
    private void IncluirDieta()
    {
        if (IdInterno <= 0 || !DataConsultaDieta.HasValue || !IdMedicoDieta.HasValue || !IdTipoDieta.HasValue) return;
        try
        {
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO CONTROLE_DIETA (ID_INTERNO, DATA_CONSULTA, DATA_INICIO, DATA_TERMINO, " +
                "DESCRICAO, ID_MEDICO, ID_TIPO_DIETA, ID_FUNCIONARIO) " +
                "VALUES (@ID, @CONSULTA, @INICIO, @TERMINO, @DESC, @MEDICO, @TIPO, @FUNC)",
                DatabaseService.CreateParameter("@ID", IdInterno),
                DatabaseService.CreateParameter("@CONSULTA", DataConsultaDieta.Value),
                DatabaseService.CreateParameter("@INICIO", (object?)DataInicioDieta ?? DBNull.Value),
                DatabaseService.CreateParameter("@TERMINO", (object?)DataTerminoDieta ?? DBNull.Value),
                DatabaseService.CreateParameter("@DESC", DescricaoDieta ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@MEDICO", IdMedicoDieta.Value),
                DatabaseService.CreateParameter("@TIPO", IdTipoDieta.Value),
                DatabaseService.CreateParameter("@FUNC", GlobalVars.IdFuncionario));
            CarregarDietas();
            DataConsultaDieta = null;
            DataInicioDieta = null;
            DataTerminoDieta = null;
            DescricaoDieta = string.Empty;
            SelectedMedicoDieta = null;
            SelectedTipoDieta = null;
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao incluir dieta", ex, nameof(CadastroInternoSaudeViewModel));
        }
    }

    [RelayCommand]
    private void InserirEnfermidade()
    {
        if (IdInterno <= 0 || !IdEnfermidade.HasValue) return;
        try
        {
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO ENFERMDIADE_INTERNO (ID_INTERNO, ID_ENFERMIDADE, STATUS) " +
                "VALUES (@ID, @ENF, 'A')",
                DatabaseService.CreateParameter("@ID", IdInterno),
                DatabaseService.CreateParameter("@ENF", IdEnfermidade.Value));
            CarregarEnfermidades();
            SelectedEnfermidade = null;
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao inserir enfermidade", ex, nameof(CadastroInternoSaudeViewModel));
        }
    }

    [RelayCommand]
    private void InserirRemedio()
    {
        if (!IdEnfermidadeInterno.HasValue || !IdRemedio.HasValue) return;
        try
        {
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO REMEDIO_ENFERMIDADE (ID_ENFERMIDADE_INTERNO, ID_REMEDIO, DATA_INICIO, QTDE, OBS) " +
                "VALUES (@ENF_INT, @REM, @DATA, @QTDE, @OBS)",
                DatabaseService.CreateParameter("@ENF_INT", IdEnfermidadeInterno.Value),
                DatabaseService.CreateParameter("@REM", IdRemedio.Value),
                DatabaseService.CreateParameter("@DATA", (object?)DataRemedio ?? DBNull.Value),
                DatabaseService.CreateParameter("@QTDE", QtdeRemedio ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@OBS", ObsRemedio ?? (object)DBNull.Value));
            LoadRemedioEnfermidade(IdEnfermidadeInterno.Value);
            DataRemedio = null;
            SelectedRemedio = null;
            QtdeRemedio = string.Empty;
            ObsRemedio = string.Empty;
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao inserir remédio", ex, nameof(CadastroInternoSaudeViewModel));
        }
    }

    [RelayCommand]
    private void InserirDeficiencia()
    {
        if (IdInterno <= 0 || !IdDeficiencia.HasValue) return;
        try
        {
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO DEFICIENCIA_INTERNO (ID_INTERNO, ID_DEFICIENCIA, TIPO_LOCOMOCAO, MEMBRO, TIPO_ATROFIA, MOTIVO, ID_FUNCIONARIO) " +
                "VALUES (@ID, @DEF, @LOC, @MEMB, @ATRO, @MOT, @FUNC)",
                DatabaseService.CreateParameter("@ID", IdInterno),
                DatabaseService.CreateParameter("@DEF", IdDeficiencia.Value),
                DatabaseService.CreateParameter("@LOC", LocomocaoDeficiencia ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@MEMB", MembroDeficiencia ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ATRO", AtrofiaDeficiencia ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@MOT", MotivoDeficiencia ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@FUNC", GlobalVars.IdFuncionario));
            CarregarDeficiencias();
            DataDeficiencia = null;
            SelectedDeficiencia = null;
            LocomocaoDeficiencia = string.Empty;
            MembroDeficiencia = string.Empty;
            AtrofiaDeficiencia = string.Empty;
            MotivoDeficiencia = string.Empty;
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao inserir deficiência", ex, nameof(CadastroInternoSaudeViewModel));
        }
    }

    [RelayCommand]
    private void CadastrarDeficiencia()
    {
        // Placeholder - would open CadastroDeficiencia dialog
        StatusMessage = "Cadastro de Deficiência não implementado.";
    }

    [RelayCommand]
    private void InserirVacina()
    {
        if (IdInterno <= 0 || !IdVacina.HasValue || !DataVacina.HasValue) return;
        try
        {
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO VACINA_INTERNO (ID_INTERNO, ID_VACINA, DATA_VACINA, DOSE) " +
                "VALUES (@ID, @VAC, @DATA, @DOSE)",
                DatabaseService.CreateParameter("@ID", IdInterno),
                DatabaseService.CreateParameter("@VAC", IdVacina.Value),
                DatabaseService.CreateParameter("@DATA", DataVacina.Value),
                DatabaseService.CreateParameter("@DOSE", DoseVacina ?? (object)DBNull.Value));
            CarregarVacinas();
            DataVacina = null;
            SelectedVacina = null;
            DoseVacina = string.Empty;
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao inserir vacina", ex, nameof(CadastroInternoSaudeViewModel));
        }
    }

    private static string GetSafeString(DataRow row, string column)
    {
        var val = row[column];
        if (val == null || val == DBNull.Value) return string.Empty;
        return val.ToString()!.Trim();
    }

    // Overrides

    protected override void LimparCampos()
    {
        IdInterno = 0;
        NomeInterno = string.Empty;
        Rgi = string.Empty;
        Vulgo = string.Empty;
        Status = "A";
        Sexo = string.Empty;
        Pavilhao = string.Empty;
        Galeria = string.Empty;
        Solario = string.Empty;
        Cela = string.Empty;

        Sus = string.Empty;
        UsoDrogas = string.Empty;
        EfeitosDroga = string.Empty;
        DataDependencia = string.Empty;
        AbandonoDrogas = string.Empty;
        DrogasComCrime = string.Empty;
        DoencaGrave = string.Empty;
        DoencaMental = string.Empty;
        ProblemaSaude = string.Empty;
        MedicacaoControlada = string.Empty;
        DoencaInfectoContagiosa = string.Empty;
        TratamentoInfecto = string.Empty;
        ResultadoInfecto = string.Empty;
        DoencaLaboral = string.Empty;
        Suicidio = string.Empty;
        Cid = string.Empty;
        SintomasDepressivos = string.Empty;
        EpisodiosHumor = string.Empty;
        SintomasPsicoticos = string.Empty;
        Delirios = string.Empty;
        Alucinacoes = string.Empty;
        Personalidade = string.Empty;

        DataHistorico = null;
        DescricaoHistorico = string.Empty;
        SetorHistorico = string.Empty;
        DataConsultaDieta = null;
        DataInicioDieta = null;
        DataTerminoDieta = null;
        DescricaoDieta = string.Empty;
        SelectedMedicoDieta = null;
        SelectedTipoDieta = null;
        SelectedEnfermidade = null;
        SelectedEnfermidadeInterno = null;
        DataRemedio = null;
        SelectedRemedio = null;
        QtdeRemedio = string.Empty;
        ObsRemedio = string.Empty;
        DataDeficiencia = null;
        SelectedDeficiencia = null;
        LocomocaoDeficiencia = string.Empty;
        MembroDeficiencia = string.Empty;
        AtrofiaDeficiencia = string.Empty;
        MotivoDeficiencia = string.Empty;
        DataVacina = null;
        SelectedVacina = null;
        DoseVacina = string.Empty;

        HistoricoSaudeItems = new List<InternoSaudeGridItem>();
        DietaItems = new List<InternoDietaGridItem>();
        EnfermidadeInternoItems = new List<LookupItem>();
        RemedioEnfermidadeItems = new List<InternoRemedioGridItem>();
        DeficienciaInternoItems = new List<InternoDeficienciaGridItem>();
        VacinaInternoItems = new List<InternoVacinaGridItem>();
        OnPropertyChanged(nameof(HistoricoSaudeItems));
        OnPropertyChanged(nameof(DietaItems));
        OnPropertyChanged(nameof(EnfermidadeInternoItems));
        OnPropertyChanged(nameof(RemedioEnfermidadeItems));
        OnPropertyChanged(nameof(DeficienciaInternoItems));
        OnPropertyChanged(nameof(VacinaInternoItems));
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
        Pavilhao = GetString(SelectedRow, "pavilhao");
        Galeria = GetString(SelectedRow, "galeria");
        Solario = GetString(SelectedRow, "solario");
        Cela = GetString(SelectedRow, "cela");
    }

    protected override bool ValidarCampos()
    {
        // Health data is informational, no mandatory fields
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
        // The interno record must already exist (it's selected from the grid)
        // We only update the health fields on the interno record
        await AtualizarSaudeInternoAsync();
    }

    protected override async Task AtualizarAsync()
    {
        await AtualizarSaudeInternoAsync();
    }

    private async Task AtualizarSaudeInternoAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE INTERNO SET " +
                "SUS = @SUS, USODROGAS = @USODROGAS, EFEITOSDROGA = @EFEITOSDROGA, " +
                "DATADEPENDENCIA = @DATADEPENDENCIA, ABANDONODROGAS = @ABANDONODROGAS, " +
                "DROGASCOMCRIME = @DROGASCOMCRIME, DOENCAGRAVE = @DOENCAGRAVE, " +
                "DOENCAMENTAL = @DOENCAMENTAL, PROBLEMASAUDE = @PROBLEMASAUDE, " +
                "MEDICACAOCONTROLADA = @MEDICACAOCONTROLADA, " +
                "DOENCAINFECTOCONTAGIOSA = @DOENCAINFECTOCONTAGIOSA, " +
                "TRATAMENTOINFECTO = @TRATAMENTOINFECTO, RESULTADOINFECTO = @RESULTADOINFECTO, " +
                "DOENCALABORAL = @DOENCALABORAL, SUICIDIO = @SUICIDIO, CID = @CID, " +
                "SINTOMASDEPRESSIVOS = @SINTOMASDEPRESSIVOS, EPISODIOSHUMOR = @EPISODIOSHUMOR, " +
                "SINTOMASPSICOTICOS = @SINTOMASPSICOTICOS, DELIRIOS = @DELIRIOS, " +
                "ALUCINACOES = @ALUCINACOES, PERSONALIDADE = @PERSONALIDADE " +
                "WHERE ID_INTERNO = @ID",
                DatabaseService.CreateParameter("@ID", IdInterno),
                DatabaseService.CreateParameter("@SUS", Sus ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@USODROGAS", UsoDrogas ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@EFEITOSDROGA", EfeitosDroga ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@DATADEPENDENCIA", DataDependencia ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ABANDONODROGAS", AbandonoDrogas ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@DROGASCOMCRIME", DrogasComCrime ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@DOENCAGRAVE", DoencaGrave ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@DOENCAMENTAL", DoencaMental ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@PROBLEMASAUDE", ProblemaSaude ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@MEDICACAOCONTROLADA", MedicacaoControlada ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@DOENCAINFECTOCONTAGIOSA", DoencaInfectoContagiosa ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@TRATAMENTOINFECTO", TratamentoInfecto ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@RESULTADOINFECTO", ResultadoInfecto ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@DOENCALABORAL", DoencaLaboral ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@SUICIDIO", Suicidio ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@CID", Cid ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@SINTOMASDEPRESSIVOS", SintomasDepressivos ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@EPISODIOSHUMOR", EpisodiosHumor ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@SINTOMASPSICOTICOS", SintomasPsicoticos ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@DELIRIOS", Delirios ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ALUCINACOES", Alucinacoes ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@PERSONALIDADE", Personalidade ?? (object)DBNull.Value));
        });
    }

    protected override async Task ExcluirAsync()
    {
        // Health data is part of the interno record, not deleted separately
        await Task.CompletedTask;
    }
}

// === Grid item classes for sub-tables ===

public class InternoSaudeGridItem
{
    public string Data { get; set; } = "";
    public string Setor { get; set; } = "";
    public string Descricao { get; set; } = "";
    public string Funcionario { get; set; } = "";
}

public class InternoDietaGridItem
{
    public string DataConsulta { get; set; } = "";
    public string DataInicio { get; set; } = "";
    public string DataTermino { get; set; } = "";
    public string TipoDieta { get; set; } = "";
    public string Descricao { get; set; } = "";
    public string Medico { get; set; } = "";
}

public class InternoRemedioGridItem
{
    public string DataInicio { get; set; } = "";
    public string DataFim { get; set; } = "";
    public string Remedio { get; set; } = "";
    public string Qtde { get; set; } = "";
    public string Obs { get; set; } = "";
}

public class InternoDeficienciaGridItem
{
    public string Deficiencia { get; set; } = "";
    public string Locomocao { get; set; } = "";
    public string Membro { get; set; } = "";
    public string Atrofia { get; set; } = "";
    public string Motivo { get; set; } = "";
}

public class InternoVacinaGridItem
{
    public string DataVacina { get; set; } = "";
    public string Dose { get; set; } = "";
    public string Vacina { get; set; } = "";
}
