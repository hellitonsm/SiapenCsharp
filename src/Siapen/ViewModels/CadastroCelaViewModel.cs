using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using FirebirdSql.Data.FirebirdClient;
using Siapen.Helpers;
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
    private DataTable _pavilhoes = new();

    [ObservableProperty]
    private DataRowView? _pavilhaoSelecionado;

    [ObservableProperty]
    private DataTable _galerias = new();

    [ObservableProperty]
    private DataRowView? _galeriaSelecionada;

    [ObservableProperty]
    private DataTable _solarios = new();

    [ObservableProperty]
    private DataRowView? _solarioSelecionado;

    private bool _isPreenchendo;

    public CadastroCelaViewModel()
    {
        _orderBy = "id_cela";
        TituloCadastro = "Cadastro de Cela";
    }

    public void LoadLookups()
    {
        Pavilhoes = DmPrincipalService.GetPavilhoes(GlobalVars.IdUp);
    }

    partial void OnPavilhaoSelecionadoChanged(DataRowView? value)
    {
        if (value == null) return;
        IdPavilhao = GetInt(value, "id_pavilhao") ?? 0;
        if (!_isPreenchendo && IdPavilhao > 0)
        {
            LoadGalerias(IdPavilhao);
            GaleriaSelecionada = null;
            Solarios = new();
            SolarioSelecionado = null;
        }
    }

    partial void OnGaleriaSelecionadaChanged(DataRowView? value)
    {
        if (value == null) return;
        IdGaleria = GetInt(value, "id_galeria") ?? 0;
        if (!_isPreenchendo && IdGaleria > 0)
        {
            LoadSolarios(IdGaleria);
            SolarioSelecionado = null;
        }
    }

    private void LoadGalerias(int idPavilhao)
    {
        var dt = DmPrincipalService.GetGalerias(idPavilhao);
        Galerias = dt;
    }

    private void LoadSolarios(int idGaleria)
    {
        var dt = DmPrincipalService.GetSolarios(idGaleria);
        Solarios = dt;
    }

    protected override string GetSqlConsulta() =>
        "SELECT c.id_cela, c.cela, c.idpavilhao, c.idgaleria, c.idsolario, " +
        "c.isolamento, c.limite_por_cela, c.em_manutencao, c.motivo_manutencao, " +
        "p.pavilhao AS pavilhao_nome, g.galeria AS galeria_nome, s.solario AS solario_nome " +
        "FROM cela c " +
        "LEFT JOIN pavilhao p ON p.id_pavilhao = c.idpavilhao " +
        "LEFT JOIN galeria g ON g.id_galeria = c.idgaleria " +
        "LEFT JOIN solario s ON s.id_solario = c.idsolario " +
        "WHERE p.id_up = @ID_UP ORDER BY c.id_cela";

    protected override FbParameter[] GetSqlParametros() =>
        new[] { DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp) };

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
            if (Pavilhoes.DefaultView != null)
            {
                foreach (DataRowView row in Pavilhoes.DefaultView)
                {
                    if (GetInt(row, "id_pavilhao") == pavId)
                    { PavilhaoSelecionado = row; break; }
                }
            }
        }

        var galId = GetInt(SelectedRow, "idgaleria") ?? 0;
        IdGaleria = galId;
        if (galId > 0 && Galerias.DefaultView != null)
        {
            foreach (DataRowView row in Galerias.DefaultView)
            {
                if (GetInt(row, "id_galeria") == galId)
                { GaleriaSelecionada = row; break; }
            }
        }

        if (galId > 0)
        {
            LoadSolarios(galId);
        }

        var solId = GetInt(SelectedRow, "idsolario") ?? 0;
        IdSolario = solId;
        if (solId > 0 && Solarios.DefaultView != null)
        {
            foreach (DataRowView row in Solarios.DefaultView)
            {
                if (GetInt(row, "id_solario") == solId)
                { SolarioSelecionado = row; break; }
            }
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
