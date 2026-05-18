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
/// Grid item for the consultation DataGrid
/// </summary>
public class PsicossocialGridItem
{
    public int IdInterno { get; set; }
    public string NomeInterno { get; set; } = string.Empty;
    public string Rgi { get; set; } = string.Empty;
    public string Vulgo { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Sigla { get; set; } = string.Empty;
}

/// <summary>
/// Atendimento item for the sub-grid
/// </summary>
public class AtendimentoItem
{
    public string Data { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Tecnico { get; set; } = string.Empty;
}

public partial class CadastroInternoPsicossocialViewModel : ModeloCadastroViewModel
{
    // === Identificação (read-only from grid) ===
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

    // === Tab index for sub-tabs ===
    [ObservableProperty] private int _psicossocialTabIndex;

    // === Geral ===
    [ObservableProperty] private string _familiarPreso = string.Empty;
    [ObservableProperty] private string _parentescoPreso = string.Empty;
    [ObservableProperty] private string _upFamiliarPreso = string.Empty;
    [ObservableProperty] private string _motivoDelito = string.Empty;
    [ObservableProperty] private string _maiorPerda = string.Empty;
    [ObservableProperty] private int? _idAdvogado;
    [ObservableProperty] private LookupItem? _selectedAdvogado;
    [ObservableProperty] private string _situacaoCivil = string.Empty;
    [ObservableProperty] private string _visitantes = string.Empty;

    // === Histórico Familiar ===
    [ObservableProperty] private string _paisVivos = string.Empty;
    [ObservableProperty] private string _paisSeparados = string.Empty;
    [ObservableProperty] private string _idadePaisSeparados = string.Empty;
    [ObservableProperty] private string _quemCriou = string.Empty;
    [ObservableProperty] private string _profissaoPais = string.Empty;
    [ObservableProperty] private string _trabalhoFamilia = string.Empty;
    [ObservableProperty] private string _qtdeIrmaos = string.Empty;
    [ObservableProperty] private string _criadoIrmaos = string.Empty;
    [ObservableProperty] private string _moradia = string.Empty;
    [ObservableProperty] private string _representacaoPais = string.Empty;
    [ObservableProperty] private string _educacaoRecebida = string.Empty;
    [ObservableProperty] private string _mudancaFamilia = string.Empty;
    [ObservableProperty] private string _fugaCasa = string.Empty;
    [ObservableProperty] private string _condicoesCriacao = string.Empty;
    [ObservableProperty] private string _instituicaoAssistencial = string.Empty;
    [ObservableProperty] private string _violenciaDomestica = string.Empty;

    // === Situação Pessoal ===
    [ObservableProperty] private string _religiao = string.Empty;
    [ObservableProperty] private string _qtdeFilhos = string.Empty;
    [ObservableProperty] private string _filhosMenores16 = string.Empty;
    [ObservableProperty] private string _moradiaAntesPreso = string.Empty;
    [ObservableProperty] private string _residenciaFamiliar = string.Empty;
    [ObservableProperty] private string _filhosVivem = string.Empty;
    [ObservableProperty] private string _filhoAdocao = string.Empty;
    [ObservableProperty] private string _provedorFamilia = string.Empty;
    [ObservableProperty] private string _rendimentoFamiliar = string.Empty;
    [ObservableProperty] private string _programaSocial = string.Empty;
    [ObservableProperty] private string _auxilioReclusao = string.Empty;

    // === Escolaridade ===
    [ObservableProperty] private int? _idEscolaridade;
    [ObservableProperty] private LookupItem? _selectedEscolaridade;
    [ObservableProperty] private string _reprovadoEscola = string.Empty;

    // === Situação Profissional/Documental ===
    [ObservableProperty] private string _idadeTrabalho = string.Empty;
    [ObservableProperty] private string _cursoProfissionalizante = string.Empty;
    [ObservableProperty] private string _exerciciaTrabalho = string.Empty;
    [ObservableProperty] private string _registroCarteira = string.Empty;
    [ObservableProperty] private string _trabalhoUpAnterior = string.Empty;
    [ObservableProperty] private int? _idProfissao;
    [ObservableProperty] private LookupItem? _selectedProfissao;
    [ObservableProperty] private string _documentos = string.Empty;

    // === Situação Intramuros/Perspectivas ===
    [ObservableProperty] private string _visitaOutraPessoa = string.Empty;
    [ObservableProperty] private string _estudoCumpena = string.Empty;
    [ObservableProperty] private string _trabalhoCumpena = string.Empty;
    [ObservableProperty] private string _profissaoCumpena = string.Empty;
    [ObservableProperty] private string _obsPsicossocial = string.Empty;
    [ObservableProperty] private DateTime? _dataPsicossocial;
    [ObservableProperty] private int? _idTecnico;
    [ObservableProperty] private LookupItem? _selectedTecnico;

    // === Saúde I ===
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

    // === Saúde II ===
    [ObservableProperty] private string _doencaLaboral = string.Empty;
    [ObservableProperty] private string _suicidio = string.Empty;
    [ObservableProperty] private string _cid = string.Empty;
    [ObservableProperty] private string _sintomasDepressivos = string.Empty;
    [ObservableProperty] private string _episodiosHumor = string.Empty;
    [ObservableProperty] private string _sintomasPsicoticos = string.Empty;
    [ObservableProperty] private string _delirios = string.Empty;
    [ObservableProperty] private string _alucinacoes = string.Empty;
    [ObservableProperty] private string _personalidade = string.Empty;

    // Radio groups Saúde II (S/N stored in DB)
    [ObservableProperty] private bool _tosseSemana;
    [ObservableProperty] private bool _notTosseSemana = true;
    [ObservableProperty] private bool _manchaCorpo;
    [ObservableProperty] private bool _notManchaCorpo = true;
    [ObservableProperty] private bool _doencaVenerea;
    [ObservableProperty] private bool _notDoencaVenerea = true;
    [ObservableProperty] private bool _hepatite;
    [ObservableProperty] private bool _notHepatite = true;
    [ObservableProperty] private bool _pressaoAlta;
    [ObservableProperty] private bool _notPressaoAlta = true;
    [ObservableProperty] private bool _diabete;
    [ObservableProperty] private bool _notDiabete = true;
    [ObservableProperty] private bool _hiv;
    [ObservableProperty] private bool _notHiv = true;

    // === Atendimentos ===
    [ObservableProperty] private DateTime? _atendimentoData = DateTime.Today;
    [ObservableProperty] private string _atendimentoDescricao = string.Empty;
    [ObservableProperty] private LookupItem? _selectedAtendimentoTecnico;
    [ObservableProperty] private List<AtendimentoItem> _atendimentos = new();

    // === Lookup collections ===
    public List<LookupItem> Advogados { get; } = new();
    public List<LookupItem> Escolaridades { get; } = new();
    public List<LookupItem> Profissoes { get; } = new();
    public List<LookupItem> Tecnicos { get; } = new();

    // === Filtro ===
    [ObservableProperty] private bool _filtroAtivo = true;
    [ObservableProperty] private bool _filtroInativo;

    public CadastroInternoPsicossocialViewModel()
    {
        _orderBy = "nome_interno";
        TituloCadastro = "Cadastro do Psicossocial";
        NomeUp = GlobalVars.NomeUp;
    }

    protected override string GetSqlConsulta() =>
        "SELECT i.id_interno, i.nome_interno, i.rgi, i.vulgo, i.st, i.sexo, " +
        "u.sigla, p.pavilhao, g.galeria, s.solario, c.cela " +
        "FROM interno i " +
        "LEFT JOIN unidade_penal u ON i.id_up = u.id_up " +
        "LEFT JOIN cela c ON i.idcela = c.id_cela " +
        "LEFT JOIN solario s ON c.idsolario = s.id_solario " +
        "LEFT JOIN galeria g ON s.idgaleria = g.id_galeria " +
        "LEFT JOIN pavilhao p ON g.idpavilhao = p.id_pavilhao " +
        "WHERE i.id_up = @ID_UP " +
        "ORDER BY i.nome_interno";

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
                LoadLookup(Advogados, "SELECT ID_ADVOGADO, ADVOGADO FROM ADVOGADO ORDER BY ADVOGADO");
                LoadLookup(Escolaridades, "SELECT ID_ESCOLARIDADE, ESCOLARIDADE FROM ESCOLARIDADE ORDER BY ESCOLARIDADE");
                LoadLookup(Profissoes, "SELECT ID_PROFISSAO, PROFISSAO FROM PROFISSAO ORDER BY PROFISSAO");
                LoadLookup(Tecnicos, "SELECT ID_FUNCIONARIO, NOME_FUNCIONARIO FROM FUNCIONARIO " +
                    "WHERE ID_UP = @ID_UP AND COALESCE(NOME_FUNCIONARIO, '') <> '' ORDER BY NOME_FUNCIONARIO",
                    DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp));
            });
            OnPropertyChanged(nameof(Advogados));
            OnPropertyChanged(nameof(Escolaridades));
            OnPropertyChanged(nameof(Profissoes));
            OnPropertyChanged(nameof(Tecnicos));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar lookups", ex, nameof(CadastroInternoPsicossocialViewModel));
        }
    }

    private void LoadLookup(List<LookupItem> list, string sql, params FbParameter[] parameters)
    {
        list.Clear();
        var dt = DatabaseService.ExecuteQuery(sql, parameters);
        foreach (DataRow row in dt.Rows)
        {
            list.Add(new LookupItem(
                Convert.ToInt32(row[0]),
                row[1]?.ToString()?.Trim() ?? ""));
        }
    }

    partial void OnFiltroAtivoChanged(bool value)
    {
        if (value && DataSource != null)
        {
            FiltroInativo = false;
            DataSource.RowFilter = "st = 'A'";
            OnPropertyChanged(nameof(GridItems));
        }
    }

    partial void OnFiltroInativoChanged(bool value)
    {
        if (value && DataSource != null)
        {
            FiltroAtivo = false;
            DataSource.RowFilter = "st = 'I'";
            OnPropertyChanged(nameof(GridItems));
        }
    }

    // === Lookup selection handlers ===
    partial void OnSelectedAdvogadoChanged(LookupItem? value) => IdAdvogado = value?.Id;
    partial void OnSelectedEscolaridadeChanged(LookupItem? value) => IdEscolaridade = value?.Id;
    partial void OnSelectedProfissaoChanged(LookupItem? value) => IdProfissao = value?.Id;
    partial void OnSelectedTecnicoChanged(LookupItem? value) => IdTecnico = value?.Id;

    // === Radio button mutual exclusion ===
    partial void OnTosseSemanaChanged(bool value) { if (value) NotTosseSemana = false; }
    partial void OnNotTosseSemanaChanged(bool value) { if (value) TosseSemana = false; }
    partial void OnManchaCorpoChanged(bool value) { if (value) NotManchaCorpo = false; }
    partial void OnNotManchaCorpoChanged(bool value) { if (value) ManchaCorpo = false; }
    partial void OnDoencaVenereaChanged(bool value) { if (value) NotDoencaVenerea = false; }
    partial void OnNotDoencaVenereaChanged(bool value) { if (value) DoencaVenerea = false; }
    partial void OnHepatiteChanged(bool value) { if (value) NotHepatite = false; }
    partial void OnNotHepatiteChanged(bool value) { if (value) Hepatite = false; }
    partial void OnPressaoAltaChanged(bool value) { if (value) NotPressaoAlta = false; }
    partial void OnNotPressaoAltaChanged(bool value) { if (value) PressaoAlta = false; }
    partial void OnDiabeteChanged(bool value) { if (value) NotDiabete = false; }
    partial void OnNotDiabeteChanged(bool value) { if (value) Diabete = false; }
    partial void OnHivChanged(bool value) { if (value) NotHiv = false; }
    partial void OnNotHivChanged(bool value) { if (value) Hiv = false; }

    [RelayCommand]
    private void CarregarRegistroSelecionado()
    {
        if (SelectedRow != null && Modo == CadastroModo.Navegando)
        {
            PreencherCampos();
            CarregarAtendimentos();
            TabIndex = 0;
        }
    }

    private void CarregarAtendimentos()
    {
        Atendimentos.Clear();
        if (IdInterno <= 0) return;

        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT ap.DATAATENDIMENTO, ap.DESCRICAO_ATENDIMENTO, f.NOME_FUNCIONARIO " +
                "FROM ATENDIMENTO_PSICOSSOCIAL ap " +
                "LEFT JOIN FUNCIONARIO f ON ap.IDTECNICO = f.ID_FUNCIONARIO " +
                "WHERE ap.IDINTERNO = @ID ORDER BY ap.DATAATENDIMENTO DESC",
                DatabaseService.CreateParameter("@ID", IdInterno));

            foreach (DataRow row in dt.Rows)
            {
                var data = row["DATAATENDIMENTO"];
                Atendimentos.Add(new AtendimentoItem
                {
                    Data = data != DBNull.Value ? Convert.ToDateTime(data).ToString("dd/MM/yyyy") : "",
                    Descricao = row["DESCRICAO_ATENDIMENTO"]?.ToString()?.Trim() ?? "",
                    Tecnico = row["NOME_FUNCIONARIO"]?.ToString()?.Trim() ?? ""
                });
            }
            OnPropertyChanged(nameof(Atendimentos));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar atendimentos", ex, nameof(CadastroInternoPsicossocialViewModel));
        }
    }

    [RelayCommand]
    private void IncluirAtendimento()
    {
        if (IdInterno <= 0)
        {
            StatusMessage = "Selecione um interno antes de incluir atendimento.";
            return;
        }

        if (AtendimentoData == null)
        {
            StatusMessage = "Informe a data do atendimento.";
            return;
        }

        if (string.IsNullOrWhiteSpace(AtendimentoDescricao))
        {
            StatusMessage = "Informe a descrição do atendimento.";
            return;
        }

        try
        {
            var tecnicoId = SelectedAtendimentoTecnico?.Id ?? 0;
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO ATENDIMENTO_PSICOSSOCIAL (ID_ATENDIMENTO, IDINTERNO, DATAATENDIMENTO, IDTECNICO, DESCRICAO_ATENDIMENTO) " +
                "VALUES (@ID, @IDINTERNO, @DATA, @IDTECNICO, @DESC)",
                DatabaseService.CreateParameter("@ID", DatabaseService.GetGeneratorValue("GEN_ATENDIMENTO_PSICOSSOCIAL")),
                DatabaseService.CreateParameter("@IDINTERNO", IdInterno),
                DatabaseService.CreateParameter("@DATA", AtendimentoData.Value),
                DatabaseService.CreateParameter("@IDTECNICO", tecnicoId > 0 ? tecnicoId : (object)DBNull.Value),
                DatabaseService.CreateParameter("@DESC", AtendimentoDescricao.Trim()));

            AtendimentoDescricao = string.Empty;
            AtendimentoData = DateTime.Today;
            SelectedAtendimentoTecnico = null;
            CarregarAtendimentos();
            StatusMessage = "Atendimento incluído com sucesso.";
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao incluir atendimento", ex, nameof(CadastroInternoPsicossocialViewModel));
            StatusMessage = $"Erro ao incluir atendimento: {ex.Message}";
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
        Pavilhao = string.Empty;
        Galeria = string.Empty;
        Solario = string.Empty;
        Cela = string.Empty;

        FamiliarPreso = string.Empty;
        ParentescoPreso = string.Empty;
        UpFamiliarPreso = string.Empty;
        MotivoDelito = string.Empty;
        MaiorPerda = string.Empty;
        IdAdvogado = null;
        SelectedAdvogado = null;
        SituacaoCivil = string.Empty;
        Visitantes = string.Empty;

        PaisVivos = string.Empty;
        PaisSeparados = string.Empty;
        IdadePaisSeparados = string.Empty;
        QuemCriou = string.Empty;
        ProfissaoPais = string.Empty;
        TrabalhoFamilia = string.Empty;
        QtdeIrmaos = string.Empty;
        CriadoIrmaos = string.Empty;
        Moradia = string.Empty;
        RepresentacaoPais = string.Empty;
        EducacaoRecebida = string.Empty;
        MudancaFamilia = string.Empty;
        FugaCasa = string.Empty;
        CondicoesCriacao = string.Empty;
        InstituicaoAssistencial = string.Empty;
        ViolenciaDomestica = string.Empty;

        Religiao = string.Empty;
        QtdeFilhos = string.Empty;
        FilhosMenores16 = string.Empty;
        MoradiaAntesPreso = string.Empty;
        ResidenciaFamiliar = string.Empty;
        FilhosVivem = string.Empty;
        FilhoAdocao = string.Empty;
        ProvedorFamilia = string.Empty;
        RendimentoFamiliar = string.Empty;
        ProgramaSocial = string.Empty;
        AuxilioReclusao = string.Empty;

        IdEscolaridade = null;
        SelectedEscolaridade = null;
        ReprovadoEscola = string.Empty;

        IdadeTrabalho = string.Empty;
        CursoProfissionalizante = string.Empty;
        ExerciciaTrabalho = string.Empty;
        RegistroCarteira = string.Empty;
        TrabalhoUpAnterior = string.Empty;
        IdProfissao = null;
        SelectedProfissao = null;
        Documentos = string.Empty;

        VisitaOutraPessoa = string.Empty;
        EstudoCumpena = string.Empty;
        TrabalhoCumpena = string.Empty;
        ProfissaoCumpena = string.Empty;
        ObsPsicossocial = string.Empty;
        DataPsicossocial = null;
        IdTecnico = null;
        SelectedTecnico = null;

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

        TosseSemana = false; NotTosseSemana = true;
        ManchaCorpo = false; NotManchaCorpo = true;
        DoencaVenerea = false; NotDoencaVenerea = true;
        Hepatite = false; NotHepatite = true;
        PressaoAlta = false; NotPressaoAlta = true;
        Diabete = false; NotDiabete = true;
        Hiv = false; NotHiv = true;

        AtendimentoData = DateTime.Today;
        AtendimentoDescricao = string.Empty;
        SelectedAtendimentoTecnico = null;
        Atendimentos.Clear();
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

        // Load all psicossocial fields from database
        CarregarDadosPsicossocial();
    }

    private void CarregarDadosPsicossocial()
    {
        if (IdInterno <= 0) return;

        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT * FROM INTERNO WHERE ID_INTERNO = @ID",
                DatabaseService.CreateParameter("@ID", IdInterno));

            if (dt.Rows.Count == 0) return;
            var row = dt.Rows[0];

            // Geral
            FamiliarPreso = GetRowString(row, "FAMILIARPRESO");
            ParentescoPreso = GetRowString(row, "PARENTESCOPRESO");
            UpFamiliarPreso = GetRowString(row, "UPFAMILIARPRESO");
            MotivoDelito = GetRowString(row, "MOTIVODELITO");
            MaiorPerda = GetRowString(row, "MAIORPERDA");
            IdAdvogado = GetRowInt(row, "IDADVOGADO");
            SelectedAdvogado = Advogados.FirstOrDefault(a => a.Id == IdAdvogado);
            SituacaoCivil = GetRowString(row, "SITUACAOCIVIL");
            Visitantes = GetRowString(row, "VISITANTES");

            // Histórico Familiar
            PaisVivos = GetRowString(row, "PAISVIVOS");
            PaisSeparados = GetRowString(row, "PAISSEPARADOS");
            IdadePaisSeparados = GetRowString(row, "IDADEPAISSEPARADOS");
            QuemCriou = GetRowString(row, "QUEMCRIOU");
            ProfissaoPais = GetRowString(row, "PROFISSAOPAIS");
            TrabalhoFamilia = GetRowString(row, "TRABALHOFAMILIA");
            QtdeIrmaos = GetRowString(row, "QTDEIRMAOS");
            CriadoIrmaos = GetRowString(row, "CRIADOIRMAOS");
            Moradia = GetRowString(row, "MORADIA");
            RepresentacaoPais = GetRowString(row, "REPRESENTACAOPAIS");
            EducacaoRecebida = GetRowString(row, "EDUCACAORECEBIDA");
            MudancaFamilia = GetRowString(row, "MUDANCAFAMILIA");
            FugaCasa = GetRowString(row, "FUGACASA");
            CondicoesCriacao = GetRowString(row, "CONDICOESCRIACAO");
            InstituicaoAssistencial = GetRowString(row, "INSTITUICAOASSISTENCIAL");
            ViolenciaDomestica = GetRowString(row, "VIOLENCIADOMESTICA");

            // Situação Pessoal
            Religiao = GetRowString(row, "RELIGIAO");
            QtdeFilhos = GetRowString(row, "QTDEFILHOS");
            FilhosMenores16 = GetRowString(row, "FILHOSMENORES16");
            MoradiaAntesPreso = GetRowString(row, "MORADIAANTESPRESO");
            ResidenciaFamiliar = GetRowString(row, "RESIDENCIAFAMILIAR");
            FilhosVivem = GetRowString(row, "FILHOSVIVEM");
            FilhoAdocao = GetRowString(row, "FILHOADOCAO");
            ProvedorFamilia = GetRowString(row, "PROVEDORFAMILIA");
            RendimentoFamiliar = GetRowString(row, "RENDIMENTOFAMILIAR");
            ProgramaSocial = GetRowString(row, "PROGRAMASOCIAL");
            AuxilioReclusao = GetRowString(row, "AUXRECLUSAO");

            // Escolaridade
            IdEscolaridade = GetRowInt(row, "IDESCOLARIDADE");
            SelectedEscolaridade = Escolaridades.FirstOrDefault(e => e.Id == IdEscolaridade);
            ReprovadoEscola = GetRowString(row, "REPROVADOESCOLA");

            // Situação Profissional/Documental
            IdadeTrabalho = GetRowString(row, "IDADETRABALHO");
            CursoProfissionalizante = GetRowString(row, "CURSOPROFISSIONALIZANTE");
            ExerciciaTrabalho = GetRowString(row, "EXERCICIATRABALHO");
            RegistroCarteira = GetRowString(row, "REGISTROCARTEIRA");
            TrabalhoUpAnterior = GetRowString(row, "TRABALHOUPANTERIOR");
            IdProfissao = GetRowInt(row, "IDPROFISSAO");
            SelectedProfissao = Profissoes.FirstOrDefault(p => p.Id == IdProfissao);
            Documentos = GetRowString(row, "DOCUMENTOS");

            // Situação Intramuros/Perspectivas
            VisitaOutraPessoa = GetRowString(row, "VISITAOUTRAPESSOA");
            EstudoCumpena = GetRowString(row, "ESTUDOCUMPENA");
            TrabalhoCumpena = GetRowString(row, "TRABALHOCUMPENA");
            ProfissaoCumpena = GetRowString(row, "PROFISSAOCUMPENA");
            ObsPsicossocial = GetRowString(row, "OBSPSICOSSOCIAL");
            var dataPsic = row["DATAPSICOSSOCIAL"];
            DataPsicossocial = dataPsic != DBNull.Value ? Convert.ToDateTime(dataPsic) : null;
            IdTecnico = GetRowInt(row, "IDTECNICO");
            SelectedTecnico = Tecnicos.FirstOrDefault(t => t.Id == IdTecnico);

            // Saúde I
            Sus = GetRowString(row, "SUS");
            UsoDrogas = GetRowString(row, "USODROGAS");
            EfeitosDroga = GetRowString(row, "EFEITOSDROGA");
            DataDependencia = GetRowString(row, "DATADEPENDENCIA");
            AbandonoDrogas = GetRowString(row, "ABANDONODROGAS");
            DrogasComCrime = GetRowString(row, "DROGASCOMCRIME");
            DoencaGrave = GetRowString(row, "DOENCAGRAVE");
            DoencaMental = GetRowString(row, "DOENCAMENTAL");
            ProblemaSaude = GetRowString(row, "PROBLEMASAUDE");
            MedicacaoControlada = GetRowString(row, "MEDICACAOCONTROLADA");
            DoencaInfectoContagiosa = GetRowString(row, "DOENCAINFECTOCONTAGIOSA");
            TratamentoInfecto = GetRowString(row, "TRATAMENTOINFECTO");
            ResultadoInfecto = GetRowString(row, "RESULTADOINFECTO");

            // Saúde II
            DoencaLaboral = GetRowString(row, "DOENCALABORAL");
            Suicidio = GetRowString(row, "SUICIDIO");
            Cid = GetRowString(row, "CID");
            SintomasDepressivos = GetRowString(row, "SINTOMASDEPRESSIVOS");
            EpisodiosHumor = GetRowString(row, "EPISODIOSHUMOR");
            SintomasPsicoticos = GetRowString(row, "SINTOMASPSICOTICOS");
            Delirios = GetRowString(row, "DELIRIOS");
            Alucinacoes = GetRowString(row, "ALUCINACOES");
            Personalidade = GetRowString(row, "PERSONALIDADE");

            // Radio groups
            SetRadioPair(GetRowString(row, "tosse_semana"), ref _tosseSemana, ref _notTosseSemana);
            SetRadioPair(GetRowString(row, "mancha_corpo"), ref _manchaCorpo, ref _notManchaCorpo);
            SetRadioPair(GetRowString(row, "doenca_venerea"), ref _doencaVenerea, ref _notDoencaVenerea);
            SetRadioPair(GetRowString(row, "hepatite"), ref _hepatite, ref _notHepatite);
            SetRadioPair(GetRowString(row, "pressao_alta"), ref _pressaoAlta, ref _notPressaoAlta);
            SetRadioPair(GetRowString(row, "diabete"), ref _diabete, ref _notDiabete);
            SetRadioPair(GetRowString(row, "hiv"), ref _hiv, ref _notHiv);

            // Notify all lookup selections
            OnPropertyChanged(nameof(SelectedAdvogado));
            OnPropertyChanged(nameof(SelectedEscolaridade));
            OnPropertyChanged(nameof(SelectedProfissao));
            OnPropertyChanged(nameof(SelectedTecnico));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar dados psicossocial", ex, nameof(CadastroInternoPsicossocialViewModel));
        }
    }

    private static string GetRowString(DataRow row, string column)
    {
        if (!row.Table.Columns.Contains(column)) return string.Empty;
        var val = row[column];
        return val == DBNull.Value ? string.Empty : val.ToString()!.Trim();
    }

    private static int? GetRowInt(DataRow row, string column)
    {
        if (!row.Table.Columns.Contains(column)) return null;
        var val = row[column];
        return val == DBNull.Value ? null : Convert.ToInt32(val);
    }

    private void SetRadioPair(string value, ref bool sim, ref bool nao)
    {
        if (value == "S") { sim = true; nao = false; }
        else { sim = false; nao = true; }
    }

    protected override bool ValidarCampos()
    {
        if (IdInterno <= 0)
        {
            StatusMessage = "Selecione um interno válido.";
            return false;
        }
        return true;
    }

    protected override object CreateGridItem(DataRow row)
    {
        return new PsicossocialGridItem
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
        // This screen updates existing internos, not inserts new ones
        await AtualizarAsync();
    }

    protected override async Task AtualizarAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE interno SET " +
                "FAMILIARPRESO = @FAMILIARPRESO, " +
                "PARENTESCOPRESO = @PARENTESCOPRESO, " +
                "UPFAMILIARPRESO = @UPFAMILIARPRESO, " +
                "MOTIVODELITO = @MOTIVODELITO, " +
                "MAIORPERDA = @MAIORPERDA, " +
                "IDADVOGADO = @IDADVOGADO, " +
                "SITUACAOCIVIL = @SITUACAOCIVIL, " +
                "VISITANTES = @VISITANTES, " +
                "PAISVIVOS = @PAISVIVOS, " +
                "PAISSEPARADOS = @PAISSEPARADOS, " +
                "IDADEPAISSEPARADOS = @IDADEPAISSEPARADOS, " +
                "QUEMCRIOU = @QUEMCRIOU, " +
                "PROFISSAOPAIS = @PROFISSAOPAIS, " +
                "TRABALHOFAMILIA = @TRABALHOFAMILIA, " +
                "QTDEIRMAOS = @QTDEIRMAOS, " +
                "CRIADOIRMAOS = @CRIADOIRMAOS, " +
                "MORADIA = @MORADIA, " +
                "REPRESENTACAOPAIS = @REPRESENTACAOPAIS, " +
                "EDUCACAORECEBIDA = @EDUCACAORECEBIDA, " +
                "MUDANCAFAMILIA = @MUDANCAFAMILIA, " +
                "FUGACASA = @FUGACASA, " +
                "CONDICOESCRIACAO = @CONDICOESCRIACAO, " +
                "INSTITUICAOASSISTENCIAL = @INSTITUICAOASSISTENCIAL, " +
                "VIOLENCIADOMESTICA = @VIOLENCIADOMESTICA, " +
                "RELIGIAO = @RELIGIAO, " +
                "QTDEFILHOS = @QTDEFILHOS, " +
                "FILHOSMENORES16 = @FILHOSMENORES16, " +
                "MORADIAANTESPRESO = @MORADIAANTESPRESO, " +
                "RESIDENCIAFAMILIAR = @RESIDENCIAFAMILIAR, " +
                "FILHOSVIVEM = @FILHOSVIVEM, " +
                "FILHOADOCAO = @FILHOADOCAO, " +
                "PROVEDORFAMILIA = @PROVEDORFAMILIA, " +
                "RENDIMENTOFAMILIAR = @RENDIMENTOFAMILIAR, " +
                "PROGRAMASOCIAL = @PROGRAMASOCIAL, " +
                "AUXRECLUSAO = @AUXRECLUSAO, " +
                "IDESCOLARIDADE = @IDESCOLARIDADE, " +
                "REPROVADOESCOLA = @REPROVADOESCOLA, " +
                "IDADETRABALHO = @IDADETRABALHO, " +
                "CURSOPROFISSIONALIZANTE = @CURSOPROFISSIONALIZANTE, " +
                "EXERCICIATRABALHO = @EXERCICIATRABALHO, " +
                "REGISTROCARTEIRA = @REGISTROCARTEIRA, " +
                "TRABALHOUPANTERIOR = @TRABALHOUPANTERIOR, " +
                "IDPROFISSAO = @IDPROFISSAO, " +
                "DOCUMENTOS = @DOCUMENTOS, " +
                "VISITAOUTRAPESSOA = @VISITAOUTRAPESSOA, " +
                "ESTUDOCUMPENA = @ESTUDOCUMPENA, " +
                "TRABALHOCUMPENA = @TRABALHOCUMPENA, " +
                "PROFISSAOCUMPENA = @PROFISSAOCUMPENA, " +
                "OBSPSICOSSOCIAL = @OBSPSICOSSOCIAL, " +
                "DATAPSICOSSOCIAL = @DATAPSICOSSOCIAL, " +
                "IDTECNICO = @IDTECNICO, " +
                "SUS = @SUS, " +
                "USODROGAS = @USODROGAS, " +
                "EFEITOSDROGA = @EFEITOSDROGA, " +
                "DATADEPENDENCIA = @DATADEPENDENCIA, " +
                "ABANDONODROGAS = @ABANDONODROGAS, " +
                "DROGASCOMCRIME = @DROGASCOMCRIME, " +
                "DOENCAGRAVE = @DOENCAGRAVE, " +
                "DOENCAMENTAL = @DOENCAMENTAL, " +
                "PROBLEMASAUDE = @PROBLEMASAUDE, " +
                "MEDICACAOCONTROLADA = @MEDICACAOCONTROLADA, " +
                "DOENCAINFECTOCONTAGIOSA = @DOENCAINFECTOCONTAGIOSA, " +
                "TRATAMENTOINFECTO = @TRATAMENTOINFECTO, " +
                "RESULTADOINFECTO = @RESULTADOINFECTO, " +
                "DOENCALABORAL = @DOENCALABORAL, " +
                "SUICIDIO = @SUICIDIO, " +
                "CID = @CID, " +
                "SINTOMASDEPRESSIVOS = @SINTOMASDEPRESSIVOS, " +
                "EPISODIOSHUMOR = @EPISODIOSHUMOR, " +
                "SINTOMASPSICOTICOS = @SINTOMASPSICOTICOS, " +
                "DELIRIOS = @DELIRIOS, " +
                "ALUCINACOES = @ALUCINACOES, " +
                "PERSONALIDADE = @PERSONALIDADE, " +
                "tosse_semana = @tosse_semana, " +
                "mancha_corpo = @mancha_corpo, " +
                "doenca_venerea = @doenca_venerea, " +
                "hepatite = @hepatite, " +
                "pressao_alta = @pressao_alta, " +
                "diabete = @diabete, " +
                "hiv = @hiv " +
                "WHERE id_interno = @ID",

                DatabaseService.CreateParameter("@ID", IdInterno),
                DatabaseService.CreateParameter("@FAMILIARPRESO", StrOrNull(FamiliarPreso)),
                DatabaseService.CreateParameter("@PARENTESCOPRESO", StrOrNull(ParentescoPreso)),
                DatabaseService.CreateParameter("@UPFAMILIARPRESO", StrOrNull(UpFamiliarPreso)),
                DatabaseService.CreateParameter("@MOTIVODELITO", StrOrNull(MotivoDelito)),
                DatabaseService.CreateParameter("@MAIORPERDA", StrOrNull(MaiorPerda)),
                DatabaseService.CreateParameter("@IDADVOGADO", (object?)IdAdvogado ?? DBNull.Value),
                DatabaseService.CreateParameter("@SITUACAOCIVIL", StrOrNull(SituacaoCivil)),
                DatabaseService.CreateParameter("@VISITANTES", StrOrNull(Visitantes)),
                DatabaseService.CreateParameter("@PAISVIVOS", StrOrNull(PaisVivos)),
                DatabaseService.CreateParameter("@PAISSEPARADOS", StrOrNull(PaisSeparados)),
                DatabaseService.CreateParameter("@IDADEPAISSEPARADOS", StrOrNull(IdadePaisSeparados)),
                DatabaseService.CreateParameter("@QUEMCRIOU", StrOrNull(QuemCriou)),
                DatabaseService.CreateParameter("@PROFISSAOPAIS", StrOrNull(ProfissaoPais)),
                DatabaseService.CreateParameter("@TRABALHOFAMILIA", StrOrNull(TrabalhoFamilia)),
                DatabaseService.CreateParameter("@QTDEIRMAOS", StrOrNull(QtdeIrmaos)),
                DatabaseService.CreateParameter("@CRIADOIRMAOS", StrOrNull(CriadoIrmaos)),
                DatabaseService.CreateParameter("@MORADIA", StrOrNull(Moradia)),
                DatabaseService.CreateParameter("@REPRESENTACAOPAIS", StrOrNull(RepresentacaoPais)),
                DatabaseService.CreateParameter("@EDUCACAORECEBIDA", StrOrNull(EducacaoRecebida)),
                DatabaseService.CreateParameter("@MUDANCAFAMILIA", StrOrNull(MudancaFamilia)),
                DatabaseService.CreateParameter("@FUGACASA", StrOrNull(FugaCasa)),
                DatabaseService.CreateParameter("@CONDICOESCRIACAO", StrOrNull(CondicoesCriacao)),
                DatabaseService.CreateParameter("@INSTITUICAOASSISTENCIAL", StrOrNull(InstituicaoAssistencial)),
                DatabaseService.CreateParameter("@VIOLENCIADOMESTICA", StrOrNull(ViolenciaDomestica)),
                DatabaseService.CreateParameter("@RELIGIAO", StrOrNull(Religiao)),
                DatabaseService.CreateParameter("@QTDEFILHOS", StrOrNull(QtdeFilhos)),
                DatabaseService.CreateParameter("@FILHOSMENORES16", StrOrNull(FilhosMenores16)),
                DatabaseService.CreateParameter("@MORADIAANTESPRESO", StrOrNull(MoradiaAntesPreso)),
                DatabaseService.CreateParameter("@RESIDENCIAFAMILIAR", StrOrNull(ResidenciaFamiliar)),
                DatabaseService.CreateParameter("@FILHOSVIVEM", StrOrNull(FilhosVivem)),
                DatabaseService.CreateParameter("@FILHOADOCAO", StrOrNull(FilhoAdocao)),
                DatabaseService.CreateParameter("@PROVEDORFAMILIA", StrOrNull(ProvedorFamilia)),
                DatabaseService.CreateParameter("@RENDIMENTOFAMILIAR", StrOrNull(RendimentoFamiliar)),
                DatabaseService.CreateParameter("@PROGRAMASOCIAL", StrOrNull(ProgramaSocial)),
                DatabaseService.CreateParameter("@AUXRECLUSAO", StrOrNull(AuxilioReclusao)),
                DatabaseService.CreateParameter("@IDESCOLARIDADE", (object?)IdEscolaridade ?? DBNull.Value),
                DatabaseService.CreateParameter("@REPROVADOESCOLA", StrOrNull(ReprovadoEscola)),
                DatabaseService.CreateParameter("@IDADETRABALHO", StrOrNull(IdadeTrabalho)),
                DatabaseService.CreateParameter("@CURSOPROFISSIONALIZANTE", StrOrNull(CursoProfissionalizante)),
                DatabaseService.CreateParameter("@EXERCICIATRABALHO", StrOrNull(ExerciciaTrabalho)),
                DatabaseService.CreateParameter("@REGISTROCARTEIRA", StrOrNull(RegistroCarteira)),
                DatabaseService.CreateParameter("@TRABALHOUPANTERIOR", StrOrNull(TrabalhoUpAnterior)),
                DatabaseService.CreateParameter("@IDPROFISSAO", (object?)IdProfissao ?? DBNull.Value),
                DatabaseService.CreateParameter("@DOCUMENTOS", StrOrNull(Documentos)),
                DatabaseService.CreateParameter("@VISITAOUTRAPESSOA", StrOrNull(VisitaOutraPessoa)),
                DatabaseService.CreateParameter("@ESTUDOCUMPENA", StrOrNull(EstudoCumpena)),
                DatabaseService.CreateParameter("@TRABALHOCUMPENA", StrOrNull(TrabalhoCumpena)),
                DatabaseService.CreateParameter("@PROFISSAOCUMPENA", StrOrNull(ProfissaoCumpena)),
                DatabaseService.CreateParameter("@OBSPSICOSSOCIAL", StrOrNull(ObsPsicossocial)),
                DatabaseService.CreateParameter("@DATAPSICOSSOCIAL", (object?)DataPsicossocial ?? DBNull.Value),
                DatabaseService.CreateParameter("@IDTECNICO", (object?)IdTecnico ?? DBNull.Value),
                DatabaseService.CreateParameter("@SUS", StrOrNull(Sus)),
                DatabaseService.CreateParameter("@USODROGAS", StrOrNull(UsoDrogas)),
                DatabaseService.CreateParameter("@EFEITOSDROGA", StrOrNull(EfeitosDroga)),
                DatabaseService.CreateParameter("@DATADEPENDENCIA", StrOrNull(DataDependencia)),
                DatabaseService.CreateParameter("@ABANDONODROGAS", StrOrNull(AbandonoDrogas)),
                DatabaseService.CreateParameter("@DROGASCOMCRIME", StrOrNull(DrogasComCrime)),
                DatabaseService.CreateParameter("@DOENCAGRAVE", StrOrNull(DoencaGrave)),
                DatabaseService.CreateParameter("@DOENCAMENTAL", StrOrNull(DoencaMental)),
                DatabaseService.CreateParameter("@PROBLEMASAUDE", StrOrNull(ProblemaSaude)),
                DatabaseService.CreateParameter("@MEDICACAOCONTROLADA", StrOrNull(MedicacaoControlada)),
                DatabaseService.CreateParameter("@DOENCAINFECTOCONTAGIOSA", StrOrNull(DoencaInfectoContagiosa)),
                DatabaseService.CreateParameter("@TRATAMENTOINFECTO", StrOrNull(TratamentoInfecto)),
                DatabaseService.CreateParameter("@RESULTADOINFECTO", StrOrNull(ResultadoInfecto)),
                DatabaseService.CreateParameter("@DOENCALABORAL", StrOrNull(DoencaLaboral)),
                DatabaseService.CreateParameter("@SUICIDIO", StrOrNull(Suicidio)),
                DatabaseService.CreateParameter("@CID", StrOrNull(Cid)),
                DatabaseService.CreateParameter("@SINTOMASDEPRESSIVOS", StrOrNull(SintomasDepressivos)),
                DatabaseService.CreateParameter("@EPISODIOSHUMOR", StrOrNull(EpisodiosHumor)),
                DatabaseService.CreateParameter("@SINTOMASPSICOTICOS", StrOrNull(SintomasPsicoticos)),
                DatabaseService.CreateParameter("@DELIRIOS", StrOrNull(Delirios)),
                DatabaseService.CreateParameter("@ALUCINACOES", StrOrNull(Alucinacoes)),
                DatabaseService.CreateParameter("@PERSONALIDADE", StrOrNull(Personalidade)),
                DatabaseService.CreateParameter("@tosse_semana", TosseSemana ? "S" : "N"),
                DatabaseService.CreateParameter("@mancha_corpo", ManchaCorpo ? "S" : "N"),
                DatabaseService.CreateParameter("@doenca_venerea", DoencaVenerea ? "S" : "N"),
                DatabaseService.CreateParameter("@hepatite", Hepatite ? "S" : "N"),
                DatabaseService.CreateParameter("@pressao_alta", PressaoAlta ? "S" : "N"),
                DatabaseService.CreateParameter("@diabete", Diabete ? "S" : "N"),
                DatabaseService.CreateParameter("@hiv", Hiv ? "S" : "N")
            );
        });
    }

    protected override async Task ExcluirAsync()
    {
        // This screen doesn't delete internos, only clears psicossocial data
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE interno SET " +
                "FAMILIARPRESO = NULL, PARENTESCOPRESO = NULL, UPFAMILIARPRESO = NULL, " +
                "MOTIVODELITO = NULL, MAIORPERDA = NULL, IDADVOGADO = NULL, " +
                "SITUACAOCIVIL = NULL, VISITANTES = NULL, PAISVIVOS = NULL, " +
                "PAISSEPARADOS = NULL, IDADEPAISSEPARADOS = NULL, QUEMCRIOU = NULL, " +
                "PROFISSAOPAIS = NULL, TRABALHOFAMILIA = NULL, QTDEIRMAOS = NULL, " +
                "CRIADOIRMAOS = NULL, MORADIA = NULL, REPRESENTACAOPAIS = NULL, " +
                "EDUCACAORECEBIDA = NULL, MUDANCAFAMILIA = NULL, FUGACASA = NULL, " +
                "CONDICOESCRIACAO = NULL, INSTITUICAOASSISTENCIAL = NULL, " +
                "VIOLENCIADOMESTICA = NULL, RELIGIAO = NULL, QTDEFILHOS = NULL, " +
                "FILHOSMENORES16 = NULL, MORADIAANTESPRESO = NULL, RESIDENCIAFAMILIAR = NULL, " +
                "FILHOSVIVEM = NULL, FILHOADOCAO = NULL, PROVEDORFAMILIA = NULL, " +
                "RENDIMENTOFAMILIAR = NULL, PROGRAMASOCIAL = NULL, AUXRECLUSAO = NULL, " +
                "IDESCOLARIDADE = NULL, REPROVADOESCOLA = NULL, IDADETRABALHO = NULL, " +
                "CURSOPROFISSIONALIZANTE = NULL, EXERCICIATRABALHO = NULL, " +
                "REGISTROCARTEIRA = NULL, TRABALHOUPANTERIOR = NULL, IDPROFISSAO = NULL, " +
                "DOCUMENTOS = NULL, VISITAOUTRAPESSOA = NULL, ESTUDOCUMPENA = NULL, " +
                "TRABALHOCUMPENA = NULL, PROFISSAOCUMPENA = NULL, OBSPSICOSSOCIAL = NULL, " +
                "DATAPSICOSSOCIAL = NULL, IDTECNICO = NULL, SUS = NULL, USODROGAS = NULL, " +
                "EFEITOSDROGA = NULL, DATADEPENDENCIA = NULL, ABANDONODROGAS = NULL, " +
                "DROGASCOMCRIME = NULL, DOENCAGRAVE = NULL, DOENCAMENTAL = NULL, " +
                "PROBLEMASAUDE = NULL, MEDICACAOCONTROLADA = NULL, " +
                "DOENCAINFECTOCONTAGIOSA = NULL, TRATAMENTOINFECTO = NULL, " +
                "RESULTADOINFECTO = NULL, DOENCALABORAL = NULL, SUICIDIO = NULL, " +
                "CID = NULL, SINTOMASDEPRESSIVOS = NULL, EPISODIOSHUMOR = NULL, " +
                "SINTOMASPSICOTICOS = NULL, DELIRIOS = NULL, ALUCINACOES = NULL, " +
                "PERSONALIDADE = NULL, tosse_semana = NULL, mancha_corpo = NULL, " +
                "doenca_venerea = NULL, hepatite = NULL, pressao_alta = NULL, " +
                "diabete = NULL, hiv = NULL " +
                "WHERE id_interno = @ID",
                DatabaseService.CreateParameter("@ID", IdInterno));
        });
    }

    private static object? StrOrNull(string value) =>
        string.IsNullOrWhiteSpace(value) ? DBNull.Value : value.Trim();
}
