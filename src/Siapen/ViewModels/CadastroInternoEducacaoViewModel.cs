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

public partial class CadastroInternoEducacaoViewModel : ModeloCadastroViewModel
{
    // === Campos principais do INTERNO ===
    [ObservableProperty] private int _idInterno;
    [ObservableProperty] private string _nomeInterno = string.Empty;
    [ObservableProperty] private string _rgi = string.Empty;
    [ObservableProperty] private string _vulgo = string.Empty;
    [ObservableProperty] private string _status = "A";
    [ObservableProperty] private string _nomeUp = string.Empty;
    [ObservableProperty] private string _siglaUp = string.Empty;

    // === Campos de Educação ===
    [ObservableProperty] private DateTime? _dataMatricula;
    [ObservableProperty] private List<LookupItem> _seriesEstudo = new();
    [ObservableProperty] private LookupItem? _selectedSerieEstudo;
    [ObservableProperty] private string _turma = string.Empty;
    [ObservableProperty] private string _deficiencia = string.Empty;
    [ObservableProperty] private string _periodo = string.Empty;
    [ObservableProperty] private string _obsEducacao = string.Empty;

    // === Campos de Portaria (Remição) ===
    [ObservableProperty] private DateTime? _portariaDataEntrada;
    [ObservableProperty] private string _portariaTurma = string.Empty;
    [ObservableProperty] private string _portariaNumero = string.Empty;

    // === Campos de Dados Estudo ===
    [ObservableProperty] private DateTime? _estudoDataInicial;
    [ObservableProperty] private DateTime? _estudoDataFinal;
    [ObservableProperty] private string _estudoHoras = string.Empty;
    [ObservableProperty] private string _estudoSalas = string.Empty;

    // === Campos de Atestado ===
    [ObservableProperty] private DateTime? _atestadoDataInicial;
    [ObservableProperty] private DateTime? _atestadoDataFinal;
    [ObservableProperty] private string _atestadoSaldoAnterior = string.Empty;
    [ObservableProperty] private string _atestadoDiasEstudo = string.Empty;
    [ObservableProperty] private string _atestadoTotalEstudo = string.Empty;
    [ObservableProperty] private string _atestadoDiasRemido = string.Empty;
    [ObservableProperty] private string _atestadoSaldoProximo = string.Empty;

    // === Campos de Livros ===
    [ObservableProperty] private DateTime? _livrosDataInicial;
    [ObservableProperty] private DateTime? _livrosDataFinal;
    [ObservableProperty] private string _livrosQtde = string.Empty;
    [ObservableProperty] private string _livrosDiasRemidos = string.Empty;

    // === Campos de Histórico ===
    [ObservableProperty] private DateTime? _historicoData;
    [ObservableProperty] private string _historicoTexto = string.Empty;
    [ObservableProperty] private string _historicoMemo = string.Empty;

    // === Filtro ===
    [ObservableProperty] private bool _filtroAtivo = true;
    [ObservableProperty] private bool _filtroInativo;

    // === Grid collections for sub-tables ===
    public List<PortariaGridItem> PortariaGridItems { get; } = new();
    public List<EstudoGridItem> EstudoGridItems { get; } = new();
    public List<AtestadoGridItem> AtestadoGridItems { get; } = new();
    public List<LivrosGridItem> LivrosGridItems { get; } = new();
    public List<HistoricoEducacaoGridItem> HistoricoGridItems { get; } = new();

    public CadastroInternoEducacaoViewModel()
    {
        _orderBy = "nome_interno";
        TituloCadastro = "Cadastro da Educação";
        NomeUp = GlobalVars.NomeUp;
    }

    protected override string GetSqlConsulta() =>
        "SELECT i.id_interno, i.nome_interno, i.rgi, i.vulgo, i.st, " +
        "i.data_matricula, i.serie_fase_atual, i.turma, i.deficiencia, " +
        "i.periodo, i.obs_educacao, u.sigla " +
        "FROM interno i " +
        "LEFT JOIN unidade_penal u ON i.id_up = u.id_up " +
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
                LoadSerieEstudoLookup();
            });
            OnPropertyChanged(nameof(SeriesEstudo));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar lookups", ex, nameof(CadastroInternoEducacaoViewModel));
        }
    }

    private void LoadSerieEstudoLookup()
    {
        SeriesEstudo.Clear();
        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT ID_SERIE_FASE, SERIE_FASE FROM SERIE_FASE_ESTUDO ORDER BY SERIE_FASE");
            foreach (DataRow row in dt.Rows)
            {
                SeriesEstudo.Add(new LookupItem(
                    Convert.ToInt32(row["ID_SERIE_FASE"]),
                    row["SERIE_FASE"]?.ToString()?.Trim() ?? ""));
            }
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar Série/Fase", ex, nameof(CadastroInternoEducacaoViewModel));
        }
    }

    private async Task LoadSubTablesAsync()
    {
        if (IdInterno == 0) return;
        try
        {
            await Task.Run(() =>
            {
                LoadPortariaGrid();
                LoadEstudoGrid();
                LoadAtestadoGrid();
                LoadLivrosGrid();
                LoadHistoricoGrid();
            });
            OnPropertyChanged(nameof(PortariaGridItems));
            OnPropertyChanged(nameof(EstudoGridItems));
            OnPropertyChanged(nameof(AtestadoGridItems));
            OnPropertyChanged(nameof(LivrosGridItems));
            OnPropertyChanged(nameof(HistoricoGridItems));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar sub-tabelas", ex, nameof(CadastroInternoEducacaoViewModel));
        }
    }

    private void LoadPortariaGrid()
    {
        PortariaGridItems.Clear();
        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT NUMERO_PORTARIA, DATA_ENTRADA, TURMA_CURSO, DATA_FINAL " +
                "FROM VINC_PORTARIA_EDUCACAO " +
                "WHERE id_interno = @ID " +
                "ORDER BY DATA_ENTRADA DESC",
                DatabaseService.CreateParameter("@ID", IdInterno));
            foreach (DataRow row in dt.Rows)
            {
                PortariaGridItems.Add(new PortariaGridItem
                {
                    Portaria = row["NUMERO_PORTARIA"]?.ToString()?.Trim() ?? "",
                    DataEntrada = FormatDate(row["DATA_ENTRADA"]),
                    Turma = row["TURMA_CURSO"]?.ToString()?.Trim() ?? "",
                    DataFinal = FormatDate(row["DATA_FINAL"])
                });
            }
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar Portarias", ex, nameof(CadastroInternoEducacaoViewModel));
        }
    }

    private void LoadEstudoGrid()
    {
        EstudoGridItems.Clear();
        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT DATA_INICIAL, DATA_FINAL, HORAS " +
                "FROM VINC_ESTUDO_EDUCACAO " +
                "WHERE id_interno = @ID " +
                "ORDER BY DATA_INICIAL DESC",
                DatabaseService.CreateParameter("@ID", IdInterno));
            foreach (DataRow row in dt.Rows)
            {
                EstudoGridItems.Add(new EstudoGridItem
                {
                    DataInicial = FormatDate(row["DATA_INICIAL"]),
                    DataFinal = FormatDate(row["DATA_FINAL"]),
                    Horas = row["HORAS"]?.ToString()?.Trim() ?? ""
                });
            }
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar Dados Estudo", ex, nameof(CadastroInternoEducacaoViewModel));
        }
    }

    private void LoadAtestadoGrid()
    {
        AtestadoGridItems.Clear();
        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT DATA_INICIAL, DATA_FINAL, SALDO_ANTERIOR, DIAS_REMIDO, " +
                "TOTAL_HORAS, SALDO_PROXIMA " +
                "FROM VINC_ATESTADO_EDUCACAO " +
                "WHERE id_interno = @ID " +
                "ORDER BY DATA_INICIAL DESC",
                DatabaseService.CreateParameter("@ID", IdInterno));
            foreach (DataRow row in dt.Rows)
            {
                AtestadoGridItems.Add(new AtestadoGridItem
                {
                    DataInicial = FormatDate(row["DATA_INICIAL"]),
                    DataFinal = FormatDate(row["DATA_FINAL"]),
                    SaldoAnterior = row["SALDO_ANTERIOR"]?.ToString()?.Trim() ?? "",
                    DiasRemido = row["DIAS_REMIDO"]?.ToString()?.Trim() ?? "",
                    TotalHoras = row["TOTAL_HORAS"]?.ToString()?.Trim() ?? "",
                    SaldoProxima = row["SALDO_PROXIMA"]?.ToString()?.Trim() ?? ""
                });
            }
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar Atestados", ex, nameof(CadastroInternoEducacaoViewModel));
        }
    }

    private void LoadLivrosGrid()
    {
        LivrosGridItems.Clear();
        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT DATA_INICIAL, DATA_FINAL, QTDE_LIVROS " +
                "FROM VINC_LIVROS_EDUCACAO " +
                "WHERE id_interno = @ID " +
                "ORDER BY DATA_INICIAL DESC",
                DatabaseService.CreateParameter("@ID", IdInterno));
            foreach (DataRow row in dt.Rows)
            {
                LivrosGridItems.Add(new LivrosGridItem
                {
                    DataInicial = FormatDate(row["DATA_INICIAL"]),
                    DataFinal = FormatDate(row["DATA_FINAL"]),
                    Livros = row["QTDE_LIVROS"]?.ToString()?.Trim() ?? ""
                });
            }
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar Livros", ex, nameof(CadastroInternoEducacaoViewModel));
        }
    }

    private void LoadHistoricoGrid()
    {
        HistoricoGridItems.Clear();
        try
        {
            var dt = DatabaseService.ExecuteQuery(
                "SELECT DATA_HORA, DESCRICAO " +
                "FROM HISTORICO_INTERNO " +
                "WHERE idinterno = @ID AND setor LIKE 'Educação' " +
                "ORDER BY DATA_HORA DESC",
                DatabaseService.CreateParameter("@ID", IdInterno));
            foreach (DataRow row in dt.Rows)
            {
                HistoricoGridItems.Add(new HistoricoEducacaoGridItem
                {
                    Data = FormatDate(row["DATA_HORA"]),
                    Historico = row["DESCRICAO"]?.ToString()?.Trim() ?? ""
                });
            }
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar Histórico", ex, nameof(CadastroInternoEducacaoViewModel));
        }
    }

    private static string FormatDate(object? value)
    {
        if (value == null || value == DBNull.Value) return string.Empty;
        if (DateTime.TryParse(value.ToString(), out var dt))
            return dt.ToString("dd/MM/yyyy");
        return string.Empty;
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

    partial void OnSelectedSerieEstudoChanged(LookupItem? value)
    {
        // Lookup selection changed
    }

    [RelayCommand]
    private async void CarregarRegistroSelecionado()
    {
        if (SelectedRow != null && Modo == CadastroModo.Navegando)
        {
            PreencherCampos();
            await LoadSubTablesAsync();
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

        // Educação
        DataMatricula = null;
        SelectedSerieEstudo = null;
        Turma = string.Empty;
        Deficiencia = string.Empty;
        Periodo = string.Empty;
        ObsEducacao = string.Empty;

        // Portaria
        PortariaDataEntrada = null;
        PortariaTurma = string.Empty;
        PortariaNumero = string.Empty;

        // Estudo
        EstudoDataInicial = null;
        EstudoDataFinal = null;
        EstudoHoras = string.Empty;
        EstudoSalas = string.Empty;

        // Atestado
        AtestadoDataInicial = null;
        AtestadoDataFinal = null;
        AtestadoSaldoAnterior = string.Empty;
        AtestadoDiasEstudo = string.Empty;
        AtestadoTotalEstudo = string.Empty;
        AtestadoDiasRemido = string.Empty;
        AtestadoSaldoProximo = string.Empty;

        // Livros
        LivrosDataInicial = null;
        LivrosDataFinal = null;
        LivrosQtde = string.Empty;
        LivrosDiasRemidos = string.Empty;

        // Histórico
        HistoricoData = null;
        HistoricoTexto = string.Empty;
        HistoricoMemo = string.Empty;

        // Clear grids
        PortariaGridItems.Clear();
        EstudoGridItems.Clear();
        AtestadoGridItems.Clear();
        LivrosGridItems.Clear();
        HistoricoGridItems.Clear();
        OnPropertyChanged(nameof(PortariaGridItems));
        OnPropertyChanged(nameof(EstudoGridItems));
        OnPropertyChanged(nameof(AtestadoGridItems));
        OnPropertyChanged(nameof(LivrosGridItems));
        OnPropertyChanged(nameof(HistoricoGridItems));
    }

    protected override void PreencherCampos()
    {
        if (SelectedRow == null) return;
        IdInterno = GetInt(SelectedRow, "id_interno") ?? 0;
        NomeInterno = GetString(SelectedRow, "nome_interno");
        Rgi = GetString(SelectedRow, "rgi");
        Vulgo = GetString(SelectedRow, "vulgo");
        Status = GetString(SelectedRow, "st");
        SiglaUp = GetString(SelectedRow, "sigla");

        // Educação fields
        DataMatricula = GetDateTime(SelectedRow, "data_matricula");
        Turma = GetString(SelectedRow, "turma");
        Deficiencia = GetString(SelectedRow, "deficiencia");
        Periodo = GetString(SelectedRow, "periodo");
        ObsEducacao = GetString(SelectedRow, "obs_educacao");

        // Restore Serie/Fase lookup selection
        var serieId = GetInt(SelectedRow, "serie_fase_atual");
        if (serieId.HasValue && serieId.Value > 0)
            SelectedSerieEstudo = SeriesEstudo.FirstOrDefault(s => s.Id == serieId.Value);
        else
            SelectedSerieEstudo = null;
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
                "INSERT INTO interno (id_interno, nome_interno, rgi, st, id_up, " +
                "data_matricula, serie_fase_atual, turma, deficiencia, periodo, obs_educacao) " +
                "VALUES (@ID, @NOME, @RGI, @ST, @ID_UP, " +
                "@DATA_MATRICULA, @SERIE, @TURMA, @DEFICIENCIA, @PERIODO, @OBS_EDUCACAO)",
                DatabaseService.CreateParameter("@ID", id),
                DatabaseService.CreateParameter("@NOME", NomeInterno.Trim().ToUpper()),
                DatabaseService.CreateParameter("@RGI", Rgi?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ST", Status),
                DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp),
                DatabaseService.CreateParameter("@DATA_MATRICULA", (object?)DataMatricula ?? DBNull.Value),
                DatabaseService.CreateParameter("@SERIE", (object?)SelectedSerieEstudo?.Id ?? DBNull.Value),
                DatabaseService.CreateParameter("@TURMA", string.IsNullOrWhiteSpace(Turma) ? DBNull.Value : Turma.Trim().ToUpper()),
                DatabaseService.CreateParameter("@DEFICIENCIA", string.IsNullOrWhiteSpace(Deficiencia) ? DBNull.Value : Deficiencia.Trim()),
                DatabaseService.CreateParameter("@PERIODO", string.IsNullOrWhiteSpace(Periodo) ? DBNull.Value : Periodo.Trim()),
                DatabaseService.CreateParameter("@OBS_EDUCACAO", string.IsNullOrWhiteSpace(ObsEducacao) ? DBNull.Value : ObsEducacao.Trim()));
        });
    }

    protected override async Task AtualizarAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE interno SET nome_interno = @NOME, rgi = @RGI, st = @ST, " +
                "data_matricula = @DATA_MATRICULA, serie_fase_atual = @SERIE, " +
                "turma = @TURMA, deficiencia = @DEFICIENCIA, periodo = @PERIODO, " +
                "obs_educacao = @OBS_EDUCACAO " +
                "WHERE id_interno = @ID",
                DatabaseService.CreateParameter("@ID", IdInterno),
                DatabaseService.CreateParameter("@NOME", NomeInterno.Trim().ToUpper()),
                DatabaseService.CreateParameter("@RGI", Rgi?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ST", Status),
                DatabaseService.CreateParameter("@DATA_MATRICULA", (object?)DataMatricula ?? DBNull.Value),
                DatabaseService.CreateParameter("@SERIE", (object?)SelectedSerieEstudo?.Id ?? DBNull.Value),
                DatabaseService.CreateParameter("@TURMA", string.IsNullOrWhiteSpace(Turma) ? DBNull.Value : Turma.Trim().ToUpper()),
                DatabaseService.CreateParameter("@DEFICIENCIA", string.IsNullOrWhiteSpace(Deficiencia) ? DBNull.Value : Deficiencia.Trim()),
                DatabaseService.CreateParameter("@PERIODO", string.IsNullOrWhiteSpace(Periodo) ? DBNull.Value : Periodo.Trim()),
                DatabaseService.CreateParameter("@OBS_EDUCACAO", string.IsNullOrWhiteSpace(ObsEducacao) ? DBNull.Value : ObsEducacao.Trim()));
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

// === Sub-table grid item classes ===

public class PortariaGridItem
{
    public string Portaria { get; set; } = "";
    public string DataEntrada { get; set; } = "";
    public string Turma { get; set; } = "";
    public string DataFinal { get; set; } = "";
}

public class EstudoGridItem
{
    public string DataInicial { get; set; } = "";
    public string DataFinal { get; set; } = "";
    public string Horas { get; set; } = "";
}

public class AtestadoGridItem
{
    public string DataInicial { get; set; } = "";
    public string DataFinal { get; set; } = "";
    public string SaldoAnterior { get; set; } = "";
    public string DiasRemido { get; set; } = "";
    public string TotalHoras { get; set; } = "";
    public string SaldoProxima { get; set; } = "";
}

public class LivrosGridItem
{
    public string DataInicial { get; set; } = "";
    public string DataFinal { get; set; } = "";
    public string Livros { get; set; } = "";
}

public class HistoricoEducacaoGridItem
{
    public string Data { get; set; } = "";
    public string Historico { get; set; } = "";
}
