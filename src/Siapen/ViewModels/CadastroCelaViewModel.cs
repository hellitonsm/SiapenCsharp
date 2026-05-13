using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using FirebirdSql.Data.FirebirdClient;
using Siapen.Helpers;
using Siapen.Models;
using Siapen.Services;

namespace Siapen.ViewModels;

public partial class CadastroCelaViewModel : ModeloCadastroViewModel
{
    [ObservableProperty]
    private int _idCela;

    [ObservableProperty]
    private string _nomeCela = string.Empty;

    [ObservableProperty]
    private string _isolamento = "N";

    [ObservableProperty]
    private int _limitePorCela;

    [ObservableProperty]
    private string _emManutencao = "N";

    [ObservableProperty]
    private string _motivoManutencao = string.Empty;

    // Cascading lookups
    [ObservableProperty]
    private int _idPavilhao;

    [ObservableProperty]
    private int _idGaleria;

    [ObservableProperty]
    private int _idSolario;

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

    [ObservableProperty]
    private List<LookupItem> _solarios = new();

    [ObservableProperty]
    private LookupItem? _solarioSelecionado;

    private bool _isPreenchendo;

    public CadastroCelaViewModel()
    {
        _orderBy = "id_cela";
        TituloCadastro = "Cadastro de Cela";
    }

    protected override object CreateGridItem(DataRow row)
    {
        return new CelaGridItem
        {
            IdCela = Convert.ToInt32(row["id_cela"]),
            Cela = row["cela"]?.ToString()?.Trim() ?? "",
            IdPavilhao = row["idpavilhao"] == DBNull.Value ? 0 : Convert.ToInt32(row["idpavilhao"]),
            IdGaleria = row["idgaleria"] == DBNull.Value ? 0 : Convert.ToInt32(row["idgaleria"]),
            IdSolario = row["idsolario"] == DBNull.Value ? 0 : Convert.ToInt32(row["idsolario"]),
            Isolamento = row["isolamento"]?.ToString()?.Trim() ?? "N",
            LimitePorCela = row["limite_por_cela"] == DBNull.Value ? 0 : Convert.ToInt32(row["limite_por_cela"]),
            EmManutencao = row["em_manutencao"]?.ToString()?.Trim() ?? "N",
            MotivoManutencao = row["motivo_manutencao"]?.ToString()?.Trim() ?? "",
            PavilhaoNome = row["pavilhao_nome"]?.ToString()?.Trim() ?? "",
            GaleriaNome = row["galeria_nome"]?.ToString()?.Trim() ?? "",
            SolarioNome = row["solario_nome"]?.ToString()?.Trim() ?? ""
        };
    }

    public void LoadLookups()
    {
        IdUp = GlobalVars.IdUp;
        LogHelper.Debug($"CadastroCela: LoadLookups com GlobalVars.IdUp={GlobalVars.IdUp}, IdUp={IdUp}", "UI");
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
            Solarios = new();
            SolarioSelecionado = null;
        }
    }

    partial void OnGaleriaSelecionadaChanged(LookupItem? value)
    {
        if (value == null) return;
        IdGaleria = value.Id;
        if (!_isPreenchendo && IdGaleria > 0)
        {
            LoadSolarios(IdGaleria);
            SolarioSelecionado = null;
        }
    }

    private void LoadGalerias(int idPavilhao)
    {
        Galerias = DmPrincipalService.GetGaleriasLookup(idPavilhao);
    }

    private void LoadSolarios(int idGaleria)
    {
        Solarios = DmPrincipalService.GetSolariosLookup(idGaleria);
    }

    protected override string GetSqlConsulta() =>
        "SELECT c.id_cela, c.cela, c.idpavilhao, c.idgaleria, c.idsolario, " +
        "c.isolamento, c.limite_por_cela, c.em_manutencao, c.motivo_manutencao, " +
        "p.pavilhao AS pavilhao_nome, g.galeria AS galeria_nome, s.solario AS solario_nome " +
        "FROM cela c " +
        "INNER JOIN pavilhao p ON p.id_pavilhao = c.idpavilhao AND p.id_up = @ID_UP " +
        "LEFT JOIN galeria g ON g.id_galeria = c.idgaleria " +
        "LEFT JOIN solario s ON s.id_solario = c.idsolario " +
        "ORDER BY c.id_cela";

    protected override FbParameter[] GetSqlParametros()
    {
        var up = IdUp > 0 ? IdUp : GlobalVars.IdUp;
        LogHelper.Debug($"CadastroCela: parametro ID_UP={up} (IdUp={IdUp}, GlobalVars.IdUp={GlobalVars.IdUp})", "DB");
        return new[] { DatabaseService.CreateParameter("@ID_UP", up) };
    }

    protected override string Filtrar(string texto) =>
        $"cela LIKE '%{texto.Replace("'", "''")}%' OR pavilhao_nome LIKE '%{texto.Replace("'", "''")}%'";

    protected override void LimparCampos()
    {
        IdCela = 0;
        NomeCela = string.Empty;
        Isolamento = "N";
        LimitePorCela = 0;
        EmManutencao = "N";
        MotivoManutencao = string.Empty;
        IdPavilhao = 0;
        IdGaleria = 0;
        IdSolario = 0;
        PavilhaoSelecionado = null;
        GaleriaSelecionada = null;
        SolarioSelecionado = null;
    }

    protected override void PreencherCampos()
    {
        if (SelectedRow == null) return;
        _isPreenchendo = true;
        IdCela = GetInt(SelectedRow, "id_cela") ?? 0;
        NomeCela = GetString(SelectedRow, "cela");
        Isolamento = GetString(SelectedRow, "isolamento");
        if (string.IsNullOrEmpty(Isolamento)) Isolamento = "N";
        LimitePorCela = GetInt(SelectedRow, "limite_por_cela") ?? 0;
        EmManutencao = GetString(SelectedRow, "em_manutencao");
        if (string.IsNullOrEmpty(EmManutencao)) EmManutencao = "N";
        MotivoManutencao = GetString(SelectedRow, "motivo_manutencao");

        var pavId = GetInt(SelectedRow, "idpavilhao") ?? 0;
        IdPavilhao = pavId;

        if (pavId > 0)
        {
            LoadGalerias(pavId);
            PavilhaoSelecionado = Pavilhoes.FirstOrDefault(p => p.Id == pavId);
        }

        var galId = GetInt(SelectedRow, "idgaleria") ?? 0;
        IdGaleria = galId;
        if (galId > 0 && Galerias.Count > 0)
        {
            GaleriaSelecionada = Galerias.FirstOrDefault(g => g.Id == galId);
            LoadSolarios(galId);
        }

        var solId = GetInt(SelectedRow, "idsolario") ?? 0;
        IdSolario = solId;
        if (solId > 0 && Solarios.Count > 0)
        {
            SolarioSelecionado = Solarios.FirstOrDefault(s => s.Id == solId);
        }

        _isPreenchendo = false;
    }

    protected override bool ValidarCampos()
    {
        if (string.IsNullOrWhiteSpace(NomeCela))
        {
            StatusMessage = "O campo Cela é obrigatório.";
            return false;
        }
        return true;
    }

    protected override async Task InserirAsync()
    {
        await Task.Run(() =>
        {
            var id = DatabaseService.GetGeneratorValue("GEN_CELA");
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO cela (id_cela, cela, idpavilhao, idgaleria, idsolario, " +
                "isolamento, limite_por_cela, em_manutencao, motivo_manutencao) " +
                "VALUES (@ID, @NOME, @IDP, @IDG, @IDS, @ISO, @LIM, @MAN, @MOT)",
                DatabaseService.CreateParameter("@ID", id),
                DatabaseService.CreateParameter("@NOME", NomeCela.Trim().ToUpper()),
                DatabaseService.CreateParameter("@IDP", IdPavilhao > 0 ? IdPavilhao : DBNull.Value),
                DatabaseService.CreateParameter("@IDG", IdGaleria > 0 ? IdGaleria : DBNull.Value),
                DatabaseService.CreateParameter("@IDS", IdSolario > 0 ? IdSolario : DBNull.Value),
                DatabaseService.CreateParameter("@ISO", Isolamento ?? "N"),
                DatabaseService.CreateParameter("@LIM", LimitePorCela > 0 ? LimitePorCela : DBNull.Value),
                DatabaseService.CreateParameter("@MAN", EmManutencao ?? "N"),
                DatabaseService.CreateParameter("@MOT", string.IsNullOrWhiteSpace(MotivoManutencao) ? DBNull.Value : MotivoManutencao.Trim()));
        });
    }

    protected override async Task AtualizarAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE cela SET cela = @NOME, idpavilhao = @IDP, idgaleria = @IDG, idsolario = @IDS, " +
                "isolamento = @ISO, limite_por_cela = @LIM, em_manutencao = @MAN, motivo_manutencao = @MOT " +
                "WHERE id_cela = @ID",
                DatabaseService.CreateParameter("@ID", IdCela),
                DatabaseService.CreateParameter("@NOME", NomeCela.Trim().ToUpper()),
                DatabaseService.CreateParameter("@IDP", IdPavilhao > 0 ? IdPavilhao : DBNull.Value),
                DatabaseService.CreateParameter("@IDG", IdGaleria > 0 ? IdGaleria : DBNull.Value),
                DatabaseService.CreateParameter("@IDS", IdSolario > 0 ? IdSolario : DBNull.Value),
                DatabaseService.CreateParameter("@ISO", Isolamento ?? "N"),
                DatabaseService.CreateParameter("@LIM", LimitePorCela > 0 ? LimitePorCela : DBNull.Value),
                DatabaseService.CreateParameter("@MAN", EmManutencao ?? "N"),
                DatabaseService.CreateParameter("@MOT", string.IsNullOrWhiteSpace(MotivoManutencao) ? DBNull.Value : MotivoManutencao.Trim()));
        });
    }

    protected override async Task ExcluirAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "DELETE FROM cela WHERE id_cela = @ID",
                DatabaseService.CreateParameter("@ID", IdCela));
        });
    }
}