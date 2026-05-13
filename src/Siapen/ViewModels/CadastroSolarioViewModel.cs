using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FirebirdSql.Data.FirebirdClient;
using Siapen.Helpers;
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
    private DataTable _pavilhoes = new();

    [ObservableProperty]
    private DataRowView? _pavilhaoSelecionado;

    [ObservableProperty]
    private DataTable _galerias = new();

    [ObservableProperty]
    private DataRowView? _galeriaSelecionada;

    // Recursos sub-grid
    [ObservableProperty]
    private DataView? _recursosDataSource;

    [ObservableProperty]
    private DataRowView? _recursoSelecionado;

    [ObservableProperty]
    private string _recursoDescricao = string.Empty;

    [ObservableProperty]
    private string _recursoObservacao = string.Empty;

    private bool _isPreenchendo;
    private bool _isInitialized;

    public CadastroSolarioViewModel()
    {
        _orderBy = "solario";
        TituloCadastro = "Cadastro de Sol\u00e1rio";
        PropertyChanged += OnPropertyChangedHandler;
    }

    private void OnPropertyChangedHandler(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedRow) && SelectedRow != null && Modo == CadastroModo.Navegando && _isInitialized)
        {
            _isPreenchendo = true;
            IdSolario = GetInt(SelectedRow, "id_solario") ?? 0;
            LoadRecursos();
            _isPreenchendo = false;
        }
    }

    public void LoadLookups()
    {
        Pavilhoes = DmPrincipalService.GetPavilhoes(GlobalVars.IdUp);
        _isInitialized = true;
    }

    partial void OnPavilhaoSelecionadoChanged(DataRowView? value)
    {
        if (value == null) return;
        IdPavilhao = GetInt(value, "id_pavilhao") ?? 0;
        if (!_isPreenchendo && IdPavilhao > 0)
        {
            LoadGalerias(IdPavilhao);
            GaleriaSelecionada = null;
        }
    }

    private void LoadGalerias(int idPavilhao)
    {
        var dt = DmPrincipalService.GetGalerias(idPavilhao);
        Galerias = dt;
    }

    private void LoadRecursos()
    {
        if (IdSolario <= 0)
        {
            RecursosDataSource = null;
            return;
        }
        var dt = DatabaseService.ExecuteQuery(
            "SELECT id_recurso_ala, descricao, data, observacao FROM recursos_ala " +
            "WHERE id_solario = @ID ORDER BY data DESC, id_recurso_ala",
            DatabaseService.CreateParameter("@ID", IdSolario));
        RecursosDataSource = dt.DefaultView;
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
        var id = GetInt(RecursoSelecionado, "id_recurso_ala");
        if (id == null) return;
        DatabaseService.ExecuteNonQuery(
            "DELETE FROM recursos_ala WHERE id_recurso_ala = @ID",
            DatabaseService.CreateParameter("@ID", id.Value));
        LoadRecursos();
        StatusMessage = "Recurso exclu\u00eddo com sucesso.";
    }

    protected override string GetSqlConsulta() =>
        "SELECT s.id_solario, s.solario, s.idpavilhao, s.idgaleria, " +
        "s.dia_visita, s.periodo_visita, " +
        "p.pavilhao AS pavilhao_nome, g.galeria AS galeria_nome " +
        "FROM solario s " +
        "LEFT JOIN pavilhao p ON p.id_pavilhao = s.idpavilhao " +
        "LEFT JOIN galeria g ON g.id_galeria = s.idgaleria " +
        "WHERE p.id_up = @ID_UP ORDER BY s.solario";

    protected override FbParameter[] GetSqlParametros() =>
        new[] { DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp) };

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
        RecursosDataSource = null;
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

        LoadRecursos();
        _isPreenchendo = false;
    }

    protected override bool ValidarCampos()
    {
        if (string.IsNullOrWhiteSpace(NomeSolario))
        {
            StatusMessage = "O campo Sol\u00e1rio \u00e9 obrigat\u00f3rio.";
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
