using System;
using System.Data;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using FirebirdSql.Data.FirebirdClient;
using Siapen.Helpers;
using Siapen.Services;

namespace Siapen.ViewModels;

public partial class ModeloInternoViewModel : ModeloCadastroViewModel
{
    [ObservableProperty]
    private int _idInterno;

    [ObservableProperty]
    private string _nomeInterno = string.Empty;

    [ObservableProperty]
    private string _rgi = string.Empty;

    [ObservableProperty]
    private string _numeroInfopen = string.Empty;

    [ObservableProperty]
    private string _outroNome = string.Empty;

    [ObservableProperty]
    private string _vulgo = string.Empty;

    [ObservableProperty]
    private string _nomeSocial = string.Empty;

    [ObservableProperty]
    private string _orientacaoSexual = string.Empty;

    [ObservableProperty]
    private string _status = "A";

    [ObservableProperty]
    private string _reincersao = "N";

    [ObservableProperty]
    private string _sexo = "M";

    [ObservableProperty]
    private string _tipoRegime = string.Empty;

    [ObservableProperty]
    private string _regimeAtual = string.Empty;

    [ObservableProperty]
    private string _grauPericulosidade = string.Empty;

    [ObservableProperty]
    private int? _tempoConsolidadoAno;

    [ObservableProperty]
    private int? _tempoConsolidadoMes;

    [ObservableProperty]
    private int? _tempoConsolidadoDia;

    // Identificação tab
    [ObservableProperty]
    private string _mae = string.Empty;

    [ObservableProperty]
    private string _pai = string.Empty;

    [ObservableProperty]
    private string _rg = string.Empty;

    [ObservableProperty]
    private string _cpf = string.Empty;

    [ObservableProperty]
    private string _estadoCivil = string.Empty;

    [ObservableProperty]
    private decimal? _altura;

    [ObservableProperty]
    private decimal? _peso;

    [ObservableProperty]
    private DateTime? _dataNascimento;

    [ObservableProperty]
    private string _corOlhos = string.Empty;

    [ObservableProperty]
    private string _corCabelos = string.Empty;

    [ObservableProperty]
    private string _religiao = string.Empty;

    // Endereço
    [ObservableProperty]
    private string _endereco = string.Empty;

    [ObservableProperty]
    private string _numeroEndereco = string.Empty;

    [ObservableProperty]
    private string _bairro = string.Empty;

    [ObservableProperty]
    private string _complemento = string.Empty;

    [ObservableProperty]
    private string _cep = string.Empty;

    [ObservableProperty]
    private string _fone = string.Empty;

    [ObservableProperty]
    private string _contato = string.Empty;

    public ModeloInternoViewModel()
    {
        _orderBy = "nome_interno";
        TituloCadastro = "Cadastro do Interno";
    }

    protected override string GetSqlConsulta() =>
        "SELECT i.id_interno, i.nome_interno, i.rgi, i.vulgo, " +
        "i.st, u.sigla, p.pavilhao, g.galeria, s.solario, c.cela, " +
        "i.id_up " +
        "FROM interno i " +
        "LEFT JOIN unidade_penal u ON (i.id_up = u.id_up) " +
        "LEFT JOIN pavilhao p ON (i.id_up = p.id_up) " +
        "LEFT JOIN galeria g ON (p.id_pavilhao = g.idpavilhao) " +
        "LEFT JOIN solario s ON (g.id_galeria = s.idgaleria) " +
        "LEFT JOIN cela c ON (s.id_solario = c.idsolario) " +
        "WHERE i.id_up = @ID_UP " +
        "ORDER BY i.nome_interno";

    protected override FbParameter[] GetSqlParametros() =>
        new[] { DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp) };

    protected override string Filtrar(string texto)
    {
        return $"nome_interno LIKE '%{texto.Replace("'", "''")}%'";
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
        Reincersao = "N";
        Sexo = "M";
        TipoRegime = string.Empty;
        RegimeAtual = string.Empty;
        GrauPericulosidade = string.Empty;
        TempoConsolidadoAno = null;
        TempoConsolidadoMes = null;
        TempoConsolidadoDia = null;
        Mae = string.Empty;
        Pai = string.Empty;
        Rg = string.Empty;
        Cpf = string.Empty;
        EstadoCivil = string.Empty;
        Altura = null;
        Peso = null;
        DataNascimento = null;
        CorOlhos = string.Empty;
        CorCabelos = string.Empty;
        Religiao = string.Empty;
        Endereco = string.Empty;
        NumeroEndereco = string.Empty;
        Bairro = string.Empty;
        Complemento = string.Empty;
        Cep = string.Empty;
        Fone = string.Empty;
        Contato = string.Empty;
    }

    protected override void PreencherCampos()
    {
        if (SelectedRow == null) return;
        IdInterno = GetInt(SelectedRow, "id_interno") ?? 0;
        NomeInterno = GetString(SelectedRow, "nome_interno");
        Rgi = GetString(SelectedRow, "rgi");
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

    protected override async Task InserirAsync()
    {
        await Task.Run(() =>
        {
            var id = DatabaseService.GetGeneratorValue("GEN_INTERNO");
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO interno (id_interno, nome_interno, rgi, st, id_up, sexo) " +
                "VALUES (@ID, @NOME, @RGI, @ST, @ID_UP, @SEXO)",
                DatabaseService.CreateParameter("@ID", id),
                DatabaseService.CreateParameter("@NOME", NomeInterno.Trim().ToUpper()),
                DatabaseService.CreateParameter("@RGI", Rgi?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ST", Status),
                DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp),
                DatabaseService.CreateParameter("@SEXO", Sexo));
        });
    }

    protected override async Task AtualizarAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE interno SET nome_interno = @NOME, rgi = @RGI, st = @ST, sexo = @SEXO " +
                "WHERE id_interno = @ID",
                DatabaseService.CreateParameter("@ID", IdInterno),
                DatabaseService.CreateParameter("@NOME", NomeInterno.Trim().ToUpper()),
                DatabaseService.CreateParameter("@RGI", Rgi?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ST", Status),
                DatabaseService.CreateParameter("@SEXO", Sexo));
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
