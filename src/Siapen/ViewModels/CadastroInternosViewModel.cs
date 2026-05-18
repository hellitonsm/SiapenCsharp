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

public partial class CadastroInternosViewModel : ModeloCadastroViewModel
{
    // === Campos principais do INTERNO ===
    [ObservableProperty] private int _idInterno;
    [ObservableProperty] private string _nomeInterno = string.Empty;
    [ObservableProperty] private string _rgi = string.Empty;
    [ObservableProperty] private string _numeroInfopen = string.Empty;
    [ObservableProperty] private string _outroNome = string.Empty;
    [ObservableProperty] private string _vulgo = string.Empty;
    [ObservableProperty] private string _nomeSocial = string.Empty;
    [ObservableProperty] private string _orientacaoSexual = string.Empty;
    [ObservableProperty] private string _status = "A";
    [ObservableProperty] private string _sexo = "M";
    [ObservableProperty] private string _tipoRegime = string.Empty;
    [ObservableProperty] private string _regimeAtual = string.Empty;
    [ObservableProperty] private string _grauPericulosidade = string.Empty;
    [ObservableProperty] private int? _tempoConsolidadoAno;
    [ObservableProperty] private int? _tempoConsolidadoMes;
    [ObservableProperty] private int? _tempoConsolidadoDia;
    [ObservableProperty] private string _nomeUp = string.Empty;

    // === Dados Gerais ===
    [ObservableProperty] private DateTime? _dataNascimento;
    [ObservableProperty] private string _rg = string.Empty;
    [ObservableProperty] private string _orgaoEmissorRg = string.Empty;
    [ObservableProperty] private string _cpf = string.Empty;
    [ObservableProperty] private string _estadoCivil = string.Empty;
    [ObservableProperty] private string _tituloEleitor = string.Empty;
    [ObservableProperty] private decimal? _altura;
    [ObservableProperty] private decimal? _peso;
    [ObservableProperty] private string _mae = string.Empty;
    [ObservableProperty] private string _pai = string.Empty;
    [ObservableProperty] private string _corOlhos = string.Empty;
    [ObservableProperty] private string _corCabelos = string.Empty;
    [ObservableProperty] private string _religiao = string.Empty;
    [ObservableProperty] private string _condenacao = string.Empty;
    [ObservableProperty] private string _historico = string.Empty;
    [ObservableProperty] private string _artigo = string.Empty;
    [ObservableProperty] private string _sinaisParticulares = string.Empty;

    // === Endereço ===
    [ObservableProperty] private string _endereco = string.Empty;
    [ObservableProperty] private string _numeroEndereco = string.Empty;
    [ObservableProperty] private string _bairro = string.Empty;
    [ObservableProperty] private string _complemento = string.Empty;
    [ObservableProperty] private string _cep = string.Empty;
    [ObservableProperty] private string _fone = string.Empty;
    [ObservableProperty] private string _contato = string.Empty;
    [ObservableProperty] private string _visitantes = string.Empty;

    // === IDs de lookup ===
    [ObservableProperty] private int? _idProcedencia;
    [ObservableProperty] private int? _idCondicaoInterno;
    [ObservableProperty] private int? _idFaccao;
    [ObservableProperty] private int? _idNaturalidade;
    [ObservableProperty] private int? _idNacionalidade;
    [ObservableProperty] private int? _idRaca;
    [ObservableProperty] private int? _idEscolaridade;
    [ObservableProperty] private int? _idProfissao;
    [ObservableProperty] private int? _idCidade;
    [ObservableProperty] private int? _idPaisEndereco;

    // === Lookup Items ===
    [ObservableProperty] private LookupItem? _selectedProcedencia;
    [ObservableProperty] private LookupItem? _selectedCondicaoInterno;
    [ObservableProperty] private LookupItem? _selectedFaccao;
    [ObservableProperty] private LookupItem? _selectedNaturalidade;
    [ObservableProperty] private LookupItem? _selectedNacionalidade;
    [ObservableProperty] private LookupItem? _selectedRaca;
    [ObservableProperty] private LookupItem? _selectedEscolaridade;
    [ObservableProperty] private LookupItem? _selectedProfissao;
    [ObservableProperty] private LookupItem? _selectedCidade;
    [ObservableProperty] private LookupItem? _selectedPais;

    // === Lookup collections ===
    public List<LookupItem> Procedencias { get; } = new();
    public List<LookupItem> CondicoesInterno { get; } = new();
    public List<LookupItem> Faccoes { get; } = new();
    public List<LookupItem> Cidades { get; } = new();
    public List<LookupItem> Nacionalidades { get; } = new();
    public List<LookupItem> Racas { get; } = new();
    public List<LookupItem> Escolaridades { get; } = new();
    public List<LookupItem> Profissoes { get; } = new();
    public List<LookupItem> Paises { get; } = new();

    // === Filtro ===
    [ObservableProperty] private bool _filtroAtivo = true;
    [ObservableProperty] private bool _filtroInativo;
    private bool _somenteInativos;

    // === Sexo radio ===
    [ObservableProperty] private bool _sexoMasculino = true;
    [ObservableProperty] private bool _sexoFeminino;

    public CadastroInternosViewModel()
    {
        _orderBy = "nome_interno";
        TituloCadastro = "Cadastro de Internos";
        NomeUp = GlobalVars.NomeUp;
    }

    protected override string GetSqlConsulta()
    {
        var sql = "SELECT i.id_interno, i.nome_interno, i.rgi, i.vulgo, i.st, " +
            "u.sigla, p.pavilhao, g.galeria, s.solario, c.cela, " +
            "pr.procedencia, i.id_procedencia, i.id_up " +
            "FROM interno i " +
            "LEFT JOIN unidade_penal u ON i.id_up = u.id_up " +
            "LEFT JOIN cela c ON i.idcela = c.id_cela " +
            "LEFT JOIN solario s ON c.idsolario = s.id_solario " +
            "LEFT JOIN galeria g ON s.idgaleria = g.id_galeria " +
            "LEFT JOIN pavilhao p ON g.idpavilhao = p.id_pavilhao " +
            "LEFT JOIN procedencia pr ON i.id_procedencia = pr.id_procedencia " +
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
                LoadLookup(Procedencias, "SELECT ID_PROCEDENCIA, PROCEDENCIA FROM PROCEDENCIA ORDER BY PROCEDENCIA");
                LoadLookup(CondicoesInterno, "SELECT ID_CONDICAO_INTERNO, DESCRICAO FROM CONDICAO_INTERNO ORDER BY DESCRICAO");
                LoadLookup(Faccoes, "SELECT ID_FACCAO, NOME_FACCAO FROM FACCAO ORDER BY NOME_FACCAO");
                LoadLookup(Cidades, "SELECT ID_CIDADE, CIDADE FROM CIDADE ORDER BY CIDADE");
                LoadLookup(Nacionalidades, "SELECT ID_NACIONALIDADE, NACIONALIDADE FROM NACIONALIDADE ORDER BY NACIONALIDADE");
                LoadLookup(Racas, "SELECT ID_RACA, RACA FROM RACA ORDER BY RACA");
                LoadLookup(Escolaridades, "SELECT ID_ESCOLARIDADE, ESCOLARIDADE FROM ESCOLARIDADE ORDER BY ESCOLARIDADE");
                LoadLookup(Profissoes, "SELECT ID_PROFISSAO, PROFISSAO FROM PROFISSAO ORDER BY PROFISSAO");
                LoadLookup(Paises, "SELECT ID_PAIS, PAIS FROM PAIS ORDER BY PAIS");
            });
            OnPropertyChanged(nameof(Procedencias));
            OnPropertyChanged(nameof(CondicoesInterno));
            OnPropertyChanged(nameof(Faccoes));
            OnPropertyChanged(nameof(Cidades));
            OnPropertyChanged(nameof(Nacionalidades));
            OnPropertyChanged(nameof(Racas));
            OnPropertyChanged(nameof(Escolaridades));
            OnPropertyChanged(nameof(Profissoes));
            OnPropertyChanged(nameof(Paises));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar lookups", ex, nameof(CadastroInternosViewModel));
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

    partial void OnSelectedProcedenciaChanged(LookupItem? value) => IdProcedencia = value?.Id;
    partial void OnSelectedCondicaoInternoChanged(LookupItem? value) => IdCondicaoInterno = value?.Id;
    partial void OnSelectedFaccaoChanged(LookupItem? value) => IdFaccao = value?.Id;
    partial void OnSelectedNaturalidadeChanged(LookupItem? value) => IdNaturalidade = value?.Id;
    partial void OnSelectedNacionalidadeChanged(LookupItem? value) => IdNacionalidade = value?.Id;
    partial void OnSelectedRacaChanged(LookupItem? value) => IdRaca = value?.Id;
    partial void OnSelectedEscolaridadeChanged(LookupItem? value) => IdEscolaridade = value?.Id;
    partial void OnSelectedProfissaoChanged(LookupItem? value) => IdProfissao = value?.Id;
    partial void OnSelectedCidadeChanged(LookupItem? value) => IdCidade = value?.Id;
    partial void OnSelectedPaisChanged(LookupItem? value) => IdPaisEndereco = value?.Id;

    partial void OnSexoMasculinoChanged(bool value) { if (value) Sexo = "M"; SexoFeminino = false; }
    partial void OnSexoFemininoChanged(bool value) { if (value) Sexo = "F"; SexoMasculino = false; }

    [RelayCommand]
    private void CarregarRegistroSelecionado()
    {
        if (SelectedRow != null && Modo == CadastroModo.Navegando)
        {
            PreencherCampos();
            TabIndex = 0;
        }
    }

    protected override void LimparCampos()
    {
        IdInterno = 0;
        NomeInterno = string.Empty;
        Rgi = string.Empty;
        NumeroInfopen = string.Empty;
        OutroNome = string.Empty;
        Vulgo = string.Empty;
        NomeSocial = string.Empty;
        OrientacaoSexual = string.Empty;
        Status = "A";
        Sexo = "M";
        SexoMasculino = true;
        SexoFeminino = false;
        TipoRegime = string.Empty;
        RegimeAtual = string.Empty;
        GrauPericulosidade = string.Empty;
        TempoConsolidadoAno = null;
        TempoConsolidadoMes = null;
        TempoConsolidadoDia = null;
        DataNascimento = null;
        Rg = string.Empty;
        OrgaoEmissorRg = string.Empty;
        Cpf = string.Empty;
        EstadoCivil = string.Empty;
        TituloEleitor = string.Empty;
        Altura = null;
        Peso = null;
        Mae = string.Empty;
        Pai = string.Empty;
        CorOlhos = string.Empty;
        CorCabelos = string.Empty;
        Religiao = string.Empty;
        Condenacao = string.Empty;
        Historico = string.Empty;
        Artigo = string.Empty;
        SinaisParticulares = string.Empty;
        Endereco = string.Empty;
        NumeroEndereco = string.Empty;
        Bairro = string.Empty;
        Complemento = string.Empty;
        Cep = string.Empty;
        Fone = string.Empty;
        Contato = string.Empty;
        Visitantes = string.Empty;
        IdProcedencia = null;
        IdCondicaoInterno = null;
        IdFaccao = null;
        IdNaturalidade = null;
        IdNacionalidade = null;
        IdRaca = null;
        IdEscolaridade = null;
        IdProfissao = null;
        IdCidade = null;
        IdPaisEndereco = null;
        SelectedProcedencia = null;
        SelectedCondicaoInterno = null;
        SelectedFaccao = null;
        SelectedNaturalidade = null;
        SelectedNacionalidade = null;
        SelectedRaca = null;
        SelectedEscolaridade = null;
        SelectedProfissao = null;
        SelectedCidade = null;
        SelectedPais = null;
    }

    protected override void PreencherCampos()
    {
        if (SelectedRow == null) return;
        IdInterno = GetInt(SelectedRow, "id_interno") ?? 0;
        NomeInterno = GetString(SelectedRow, "nome_interno");
        Rgi = GetString(SelectedRow, "rgi");
        Vulgo = GetString(SelectedRow, "vulgo");
        Status = GetString(SelectedRow, "st");
    }

    protected override bool ValidarCampos()
    {
        if (string.IsNullOrWhiteSpace(NomeInterno))
        {
            StatusMessage = "O campo Nome do Interno é obrigatório.";
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
            var id = DatabaseService.GetGeneratorValue("GEN_INTERNO");
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO interno (id_interno, nome_interno, rgi, st, id_up, sexo, id_procedencia) " +
                "VALUES (@ID, @NOME, @RGI, @ST, @ID_UP, @SEXO, @ID_PROCEDENCIA)",
                DatabaseService.CreateParameter("@ID", id),
                DatabaseService.CreateParameter("@NOME", NomeInterno.Trim().ToUpper()),
                DatabaseService.CreateParameter("@RGI", Rgi?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ST", Status),
                DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp),
                DatabaseService.CreateParameter("@SEXO", Sexo),
                DatabaseService.CreateParameter("@ID_PROCEDENCIA", (object?)IdProcedencia ?? DBNull.Value));
        });
    }

    protected override async Task AtualizarAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE interno SET nome_interno = @NOME, rgi = @RGI, st = @ST, sexo = @SEXO, " +
                "id_procedencia = @ID_PROCEDENCIA " +
                "WHERE id_interno = @ID",
                DatabaseService.CreateParameter("@ID", IdInterno),
                DatabaseService.CreateParameter("@NOME", NomeInterno.Trim().ToUpper()),
                DatabaseService.CreateParameter("@RGI", Rgi?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ST", Status),
                DatabaseService.CreateParameter("@SEXO", Sexo),
                DatabaseService.CreateParameter("@ID_PROCEDENCIA", (object?)IdProcedencia ?? DBNull.Value));
        });
    }

    protected override async Task ExcluirAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "DELETE FROM interno WHERE id_interno = @ID",
                DatabaseService.CreateParameter("@ID", IdInterno));
        });
    }
}
