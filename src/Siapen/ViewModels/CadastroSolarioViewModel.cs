using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FirebirdSql.Data.FirebirdClient;
using Siapen.Helpers;
using Siapen.Models;
using Siapen.Services;

namespace Siapen.ViewModels;

public partial class CadastroSolarioViewModel : ModeloCadastroViewModel
{
    [ObservableProperty]
    private int _idSolario;

    [ObservableProperty]
    private string _nomeSolario = string.Empty;

    [ObservableProperty]
    private string _diaVisita = "1";

    [ObservableProperty]
    private string _periodoVisita = "M";

    [ObservableProperty]
    private int _idPavilhao;

    [ObservableProperty]
    private int _idGaleria;

    [ObservableProperty]
    private int _idUp;

    [ObservableProperty]
    private List<LookupItem> _pavilhoes = new();

    [ObservableProperty]
    private LookupItem? _pavilhaoSelecionado;

    [ObservableProperty]
    private List<LookupItem> _galerias = new();

    [ObservableProperty]
    private LookupItem? _galeriaSelecionada;

    // Recursos sub-grid
    [ObservableProperty]
    private List<ExpandoObject>? _recursosGrid;

    [ObservableProperty]
    private ExpandoObject? _recursoSelecionado;

    [ObservableProperty]
    private string _recursoDescricao = string.Empty;

    [ObservableProperty]
    private string _recursoObservacao = string.Empty;

    private bool _isPreenchendo;

    public CadastroSolarioViewModel()
    {
        _orderBy = "solario";
        TituloCadastro = "Cadastro de Solário";
    }

    protected override object CreateGridItem(DataRow row)
    {
        return new SolarioGridItem
        {
            IdSolario = Convert.ToInt32(row["id_solario"]),
            Solario = row["solario"]?.ToString()?.Trim() ?? "",
            IdPavilhao = row["idpavilhao"] == DBNull.Value ? 0 : Convert.ToInt32(row["idpavilhao"]),
            IdGaleria = row["idgaleria"] == DBNull.Value ? 0 : Convert.ToInt32(row["idgaleria"]),
            DiaVisita = row["dia_visita"]?.ToString()?.Trim() ?? "1",
            PeriodoVisita = row["periodo_visita"]?.ToString()?.Trim() ?? "M",
            PavilhaoNome = row["pavilhao_nome"]?.ToString()?.Trim() ?? "",
            GaleriaNome = row["galeria_nome"]?.ToString()?.Trim() ?? ""
        };
    }

    public void LoadLookups()
    {
        IdUp = GlobalVars.IdUp;
        LogHelper.Debug($"CadastroSolario: LoadLookups com GlobalVars.IdUp={GlobalVars.IdUp}, IdUp={IdUp}", "UI");
        Pavilhoes = DmPrincipalService.GetPavilhoesLookup(IdUp > 0 ? IdUp : GlobalVars.IdUp);
    }

    partial void OnPavilhaoSelecionadoChanged(LookupItem? value)
    {
        if (value == null) return;
        IdPavilhao = value.Id;
        if (!_isPreenchendo && IdPavilhao > 0)
        {
            LoadGalerias(IdPavilhao);
            GaleriaSelecionada = null;
        }
    }

    private void LoadGalerias(int idPavilhao)
    {
        Galerias = DmPrincipalService.GetGaleriasLookup(idPavilhao);
    }

    private void LoadRecursos()
    {
        if (IdSolario <= 0)
        {
            RecursosGrid = null;
            return;
        }
        var dt = DatabaseService.ExecuteQuery(
            "SELECT id_recurso_ala, descricao, data, observacao FROM recursos_ala " +
            "WHERE id_solario = @ID ORDER BY data DESC, id_recurso_ala",
            DatabaseService.CreateParameter("@ID", IdSolario));
        var list = new List<ExpandoObject>();
        foreach (DataRow row in dt.Rows)
        {
            IDictionary<string, object?> item = new ExpandoObject();
            foreach (DataColumn col in dt.Columns)
                item[col.ColumnName] = row[col];
            list.Add((ExpandoObject)item);
        }
        RecursosGrid = list;
    }

    [RelayCommand]
    private void InserirRecurso()
    {
        if (IdSolario <= 0 || string.IsNullOrWhiteSpace(RecursoDescricao)) return;
        var id = DatabaseService.GetGeneratorValue("GEN_RECURSOS_ALA");
        DatabaseService.ExecuteNonQuery(
            "INSERT INTO recursos_ala (id_recurso_ala, id_solario, descricao, observacao, data) " +
            "VALUES (@ID, @IDS, @DESC, @OBS, @DATA)",
            DatabaseService.CreateParameter("@ID", id),
            DatabaseService.CreateParameter("@IDS", IdSolario),
            DatabaseService.CreateParameter("@DESC", RecursoDescricao.Trim()),
            DatabaseService.CreateParameter("@OBS", RecursoObservacao.Trim()),
            DatabaseService.CreateParameter("@DATA", DateTime.Now));
        RecursoDescricao = string.Empty;
        RecursoObservacao = string.Empty;
        LoadRecursos();
        StatusMessage = "Recurso inserido com sucesso.";
    }

    [RelayCommand]
    private void ExcluirRecurso()
    {
        if (RecursoSelecionado == null) return;
        var dict = (IDictionary<string, object?>)RecursoSelecionado;
        if (!dict.TryGetValue("id_recurso_ala", out var idVal) || idVal == null) return;
        var id = Convert.ToInt32(idVal);
        DatabaseService.ExecuteNonQuery(
            "DELETE FROM recursos_ala WHERE id_recurso_ala = @ID",
            DatabaseService.CreateParameter("@ID", id));
        LoadRecursos();
        StatusMessage = "Recurso excluído com sucesso.";
    }

    protected override string GetSqlConsulta() =>
        "SELECT s.id_solario, s.solario, s.idpavilhao, s.idgaleria, " +
        "s.dia_visita, s.periodo_visita, " +
        "p.pavilhao AS pavilhao_nome, g.galeria AS galeria_nome " +
        "FROM solario s " +
        "INNER JOIN pavilhao p ON p.id_pavilhao = s.idpavilhao AND p.id_up = @ID_UP " +
        "LEFT JOIN galeria g ON g.id_galeria = s.idgaleria " +
        "ORDER BY s.solario";

    protected override FbParameter[] GetSqlParametros()
    {
        var up = IdUp > 0 ? IdUp : GlobalVars.IdUp;
        LogHelper.Debug($"CadastroSolario: parametro ID_UP={up} (IdUp={IdUp}, GlobalVars.IdUp={GlobalVars.IdUp})", "DB");
        return new[] { DatabaseService.CreateParameter("@ID_UP", up) };
    }

    protected override string Filtrar(string texto) =>
        $"solario LIKE '%{texto.Replace("'", "''")}%'";

    protected override void LimparCampos()
    {
        IdSolario = 0;
        NomeSolario = string.Empty;
        IdPavilhao = 0;
        IdGaleria = 0;
        DiaVisita = "1";
        PeriodoVisita = "M";
        PavilhaoSelecionado = null;
        GaleriaSelecionada = null;
        RecursosGrid = null;
    }

    protected override void PreencherCampos()
    {
        if (SelectedRow == null) return;
        _isPreenchendo = true;
        IdSolario = GetInt(SelectedRow, "id_solario") ?? 0;
        NomeSolario = GetString(SelectedRow, "solario");
        DiaVisita = GetString(SelectedRow, "dia_visita");
        if (string.IsNullOrEmpty(DiaVisita)) DiaVisita = "1";
        PeriodoVisita = GetString(SelectedRow, "periodo_visita");
        if (string.IsNullOrEmpty(PeriodoVisita)) PeriodoVisita = "M";

        var pavId = GetInt(SelectedRow, "idpavilhao") ?? 0;
        IdPavilhao = pavId;

        if (pavId > 0)
        {
            LoadGalerias(pavId);
            PavilhaoSelecionado = Pavilhoes.FirstOrDefault(p => p.Id == pavId);
        }

        var galId = GetInt(SelectedRow, "idgaleria") ?? 0;
        IdGaleria = galId;
        if (galId > 0)
        {
            GaleriaSelecionada = Galerias.FirstOrDefault(g => g.Id == galId);
        }

        LoadRecursos();
        _isPreenchendo = false;
    }

    protected override bool ValidarCampos()
    {
        if (string.IsNullOrWhiteSpace(NomeSolario))
        {
            StatusMessage = "O campo Solário é obrigatório.";
            return false;
        }
        return true;
    }

    protected override async Task InserirAsync()
    {
        await Task.Run(() =>
        {
            var id = DatabaseService.GetGeneratorValue("GEN_SOLARIO");
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO solario (id_solario, solario, idpavilhao, idgaleria, dia_visita, periodo_visita) " +
                "VALUES (@ID, @NOME, @IDP, @IDG, @DV, @PV)",
                DatabaseService.CreateParameter("@ID", id),
                DatabaseService.CreateParameter("@NOME", NomeSolario.Trim().ToUpper()),
                DatabaseService.CreateParameter("@IDP", IdPavilhao > 0 ? IdPavilhao : DBNull.Value),
                DatabaseService.CreateParameter("@IDG", IdGaleria > 0 ? IdGaleria : DBNull.Value),
                DatabaseService.CreateParameter("@DV", DiaVisita),
                DatabaseService.CreateParameter("@PV", PeriodoVisita));
        });
    }

    protected override async Task AtualizarAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE solario SET solario = @NOME, idpavilhao = @IDP, idgaleria = @IDG, " +
                "dia_visita = @DV, periodo_visita = @PV WHERE id_solario = @ID",
                DatabaseService.CreateParameter("@ID", IdSolario),
                DatabaseService.CreateParameter("@NOME", NomeSolario.Trim().ToUpper()),
                DatabaseService.CreateParameter("@IDP", IdPavilhao > 0 ? IdPavilhao : DBNull.Value),
                DatabaseService.CreateParameter("@IDG", IdGaleria > 0 ? IdGaleria : DBNull.Value),
                DatabaseService.CreateParameter("@DV", DiaVisita),
                DatabaseService.CreateParameter("@PV", PeriodoVisita));
        });
    }

    protected override async Task ExcluirAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "DELETE FROM recursos_ala WHERE id_solario = @ID",
                DatabaseService.CreateParameter("@ID", IdSolario));
            DatabaseService.ExecuteNonQuery(
                "DELETE FROM solario WHERE id_solario = @ID",
                DatabaseService.CreateParameter("@ID", IdSolario));
        });
    }
}