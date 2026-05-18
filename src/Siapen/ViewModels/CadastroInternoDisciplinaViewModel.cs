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

public partial class CadastroInternoDisciplinaViewModel : ModeloCadastroViewModel
{
    // === Campos principais do INTERNO ===
    [ObservableProperty] private int _idInterno;
    [ObservableProperty] private string _nomeInterno = string.Empty;
    [ObservableProperty] private string _rgi = string.Empty;
    [ObservableProperty] private string _numeroInfopen = string.Empty;
    [ObservableProperty] private string _outroNome = string.Empty;
    [ObservableProperty] private string _vulgo = string.Empty;
    [ObservableProperty] private string _status = "A";
    [ObservableProperty] private string _sexo = "M";
    [ObservableProperty] private string _nomeUp = string.Empty;
    [ObservableProperty] private string _siglaUp = string.Empty;
    [ObservableProperty] private string _condenacao = string.Empty;

    // === Campos de Disciplina - Conduta ===
    [ObservableProperty] private string _tipoConduta = string.Empty;
    [ObservableProperty] private string _conceitoDisciplinar = string.Empty;
    [ObservableProperty] private DateTime? _dataDelito;
    [ObservableProperty] private DateTime? _dataReabilitacao;
    [ObservableProperty] private string _observacaoConduta = string.Empty;

    // === Campos de Disciplina - Faltas ===
    [ObservableProperty] private string _numeroPdi = string.Empty;
    [ObservableProperty] private DateTime? _dataIncidencia;
    [ObservableProperty] private string _conclusao = string.Empty;
    [ObservableProperty] private string _resultado = string.Empty;
    [ObservableProperty] private string _natureza = string.Empty;
    [ObservableProperty] private string _dataCondenacao = string.Empty;
    [ObservableProperty] private string _dataReabilitacaoFalta = string.Empty;
    [ObservableProperty] private string _qtdeDiasIsolamento = string.Empty;
    [ObservableProperty] private string _tipoProcedimento = string.Empty;
    [ObservableProperty] private bool _preventivoSim = true;
    [ObservableProperty] private bool _preventivoNao;

    // === Campos de Histórico ===
    [ObservableProperty] private DateTime? _dataHistorico;
    [ObservableProperty] private string _descricaoHistorico = string.Empty;

    // === Campos de Elogio ===
    [ObservableProperty] private DateTime? _dataElogio;
    [ObservableProperty] private string _descricaoElogio = string.Empty;

    // === Lookup Items ===
    [ObservableProperty] private LookupItem? _selectedFaltaDisciplinar;
    [ObservableProperty] private LookupItem? _selectedArtigoPerfil;

    // === Lookup collections ===
    public List<LookupItem> FaltasDisciplinares { get; } = new();
    public List<LookupItem> ArtigosPerfil { get; } = new();

    // === Grid collections for sub-tables ===
    public List<FaltaDisciplinarGridItem> FaltasGridItems { get; } = new();
    public List<HistoricoGridItem> HistoricoGridItems { get; } = new();
    public List<HistoricoGridItem> ElogioGridItems { get; } = new();

    // === Filtro ===
    [ObservableProperty] private bool _filtroAtivo = true;
    [ObservableProperty] private bool _filtroInativo;

    // === Sexo radio ===
    [ObservableProperty] private bool _sexoMasculino = true;
    [ObservableProperty] private bool _sexoFeminino;

    public CadastroInternoDisciplinaViewModel()
    {
        _orderBy = "nome_interno";
        TituloCadastro = "Cadastro da Disciplina";
        NomeUp = GlobalVars.NomeUp;
    }

    protected override string GetSqlConsulta() =>
        "SELECT i.id_interno, i.nome_interno, i.rgi, i.vulgo, i.st, " +
        "u.sigla " +
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
                LoadLookup(FaltasDisciplinares, "SELECT ID_FALTA_DISCIPLINAR, FALTA_DISCIPLINAR FROM FALTA_DISCIPLINAR ORDER BY FALTA_DISCIPLINAR");
                LoadLookup(ArtigosPerfil, "SELECT ID_ARTIGO_PERFIL, ARTIGO_PERFIL FROM ARTIGO_PERFIL ORDER BY ARTIGO_PERFIL");
            });
            OnPropertyChanged(nameof(FaltasDisciplinares));
            OnPropertyChanged(nameof(ArtigosPerfil));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar lookups", ex, nameof(CadastroInternoDisciplinaViewModel));
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

    private async Task LoadSubTablesAsync()
    {
        if (IdInterno == 0) return;
        try
        {
            await Task.Run(() =>
            {
                LoadFaltasDisciplinares();
                LoadHistorico();
                LoadElogio();
            });
            OnPropertyChanged(nameof(FaltasGridItems));
            OnPropertyChanged(nameof(HistoricoGridItems));
            OnPropertyChanged(nameof(ElogioGridItems));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar sub-tabelas", ex, nameof(CadastroInternoDisciplinaViewModel));
        }
    }

    private void LoadFaltasDisciplinares()
    {
        FaltasGridItems.Clear();
        var dt = DatabaseService.ExecuteQuery(
            "SELECT vfd.NUMERO_PDI, vfd.DATA_INCIDENCIA, vfd.DT_INICIO_ISOLAMENTO, " +
            "vfd.DT_FIM_ISOLAMENTO, fd.FALTA_DISCIPLINAR, vfd.CONCLUSAOCD, " +
            "vfd.RESULTADO, vfd.DATA_RESULTADO, vfd.DATA_CONDENACAO, " +
            "vfd.DATA_REABILITACAO, vfd.QTDE_DIAS_ISOLAMENTO, vfd.TIPO, " +
            "vfd.DATA_INSTAURACAO, vfd.NUMERO, vfd.STATUS, vfd.OBS " +
            "FROM vinc_falta_disciplinar vfd " +
            "LEFT JOIN falta_disciplinar fd ON vfd.ID_FALTA_DISCIPLINAR = fd.ID_FALTA_DISCIPLINAR " +
            "WHERE vfd.id_interno = @ID " +
            "ORDER BY vfd.data_incidencia DESC",
            DatabaseService.CreateParameter("@ID", IdInterno));

        foreach (DataRow row in dt.Rows)
        {
            FaltasGridItems.Add(new FaltaDisciplinarGridItem
            {
                NumeroPdi = row["NUMERO_PDI"]?.ToString()?.Trim() ?? "",
                DataIncidencia = FormatDate(row["DATA_INCIDENCIA"]),
                InicioIsolamento = FormatDate(row["DT_INICIO_ISOLAMENTO"]),
                FimIsolamento = FormatDate(row["DT_FIM_ISOLAMENTO"]),
                FaltaDisciplinar = row["FALTA_DISCIPLINAR"]?.ToString()?.Trim() ?? "",
                SituacaoPdi = row["CONCLUSAOCD"]?.ToString()?.Trim() ?? "",
                Resultado = row["RESULTADO"]?.ToString()?.Trim() ?? "",
                DataResultado = FormatDate(row["DATA_RESULTADO"]),
                DataCondenacao = FormatDate(row["DATA_CONDENACAO"]),
                DataReabilitacao = FormatDate(row["DATA_REABILITACAO"]),
                DiasIsolamento = row["QTDE_DIAS_ISOLAMENTO"]?.ToString()?.Trim() ?? "",
                TipoProcedimento = row["TIPO"]?.ToString()?.Trim() ?? "",
                DataInstauracao = FormatDate(row["DATA_INSTAURACAO"]),
                NumeroProcedimento = row["NUMERO"]?.ToString()?.Trim() ?? "",
                Isolamento = row["STATUS"]?.ToString()?.Trim() ?? "",
                Obs = row["OBS"]?.ToString()?.Trim() ?? ""
            });
        }
    }

    private void LoadHistorico()
    {
        HistoricoGridItems.Clear();
        var dt = DatabaseService.ExecuteQuery(
            "SELECT DATA_HORA, SETOR, DESCRICAO " +
            "FROM historico_interno " +
            "WHERE idinterno = @ID AND COALESCE(tipo_historico, '') = '' AND setor LIKE 'Disciplina' " +
            "ORDER BY data_hora DESC",
            DatabaseService.CreateParameter("@ID", IdInterno));

        foreach (DataRow row in dt.Rows)
        {
            HistoricoGridItems.Add(new HistoricoGridItem
            {
                Data = FormatDateTime(row["DATA_HORA"]),
                Setor = row["SETOR"]?.ToString()?.Trim() ?? "",
                Descricao = row["DESCRICAO"]?.ToString()?.Trim() ?? ""
            });
        }
    }

    private void LoadElogio()
    {
        ElogioGridItems.Clear();
        var dt = DatabaseService.ExecuteQuery(
            "SELECT DATA_HORA, SETOR, DESCRICAO " +
            "FROM historico_interno " +
            "WHERE idinterno = @ID AND tipo_historico = 'Elogio' " +
            "ORDER BY data_hora DESC",
            DatabaseService.CreateParameter("@ID", IdInterno));

        foreach (DataRow row in dt.Rows)
        {
            ElogioGridItems.Add(new HistoricoGridItem
            {
                Data = FormatDateTime(row["DATA_HORA"]),
                Setor = row["SETOR"]?.ToString()?.Trim() ?? "",
                Descricao = row["DESCRICAO"]?.ToString()?.Trim() ?? ""
            });
        }
    }

    private static string FormatDate(object? value)
    {
        if (value == null || value == DBNull.Value) return string.Empty;
        if (DateTime.TryParse(value.ToString(), out var dt))
            return dt.ToString("dd/MM/yyyy");
        return string.Empty;
    }

    private static string FormatDateTime(object? value)
    {
        if (value == null || value == DBNull.Value) return string.Empty;
        if (DateTime.TryParse(value.ToString(), out var dt))
            return dt.ToString("dd/MM/yyyy HH:mm");
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

    partial void OnSelectedFaltaDisciplinarChanged(LookupItem? value)
    {
        // Lookup selection changed
    }

    partial void OnSelectedArtigoPerfilChanged(LookupItem? value)
    {
        // Lookup selection changed
    }

    partial void OnSexoMasculinoChanged(bool value) { if (value) { Sexo = "M"; SexoFeminino = false; } }
    partial void OnSexoFemininoChanged(bool value) { if (value) { Sexo = "F"; SexoMasculino = false; } }
    partial void OnPreventivoSimChanged(bool value) { if (value) PreventivoNao = false; }
    partial void OnPreventivoNaoChanged(bool value) { if (value) PreventivoSim = false; }

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
        NumeroInfopen = string.Empty;
        OutroNome = string.Empty;
        Vulgo = string.Empty;
        Status = "A";
        Sexo = "M";
        SexoMasculino = true;
        SexoFeminino = false;
        Condenacao = string.Empty;

        // Conduta
        TipoConduta = string.Empty;
        ConceitoDisciplinar = string.Empty;
        DataDelito = null;
        DataReabilitacao = null;
        ObservacaoConduta = string.Empty;

        // Faltas
        NumeroPdi = string.Empty;
        DataIncidencia = null;
        Conclusao = string.Empty;
        Resultado = string.Empty;
        Natureza = string.Empty;
        DataCondenacao = string.Empty;
        DataReabilitacaoFalta = string.Empty;
        QtdeDiasIsolamento = string.Empty;
        TipoProcedimento = string.Empty;
        PreventivoSim = true;
        PreventivoNao = false;
        SelectedFaltaDisciplinar = null;

        // Artigo Perfil
        SelectedArtigoPerfil = null;

        // Histórico
        DataHistorico = null;
        DescricaoHistorico = string.Empty;

        // Elogio
        DataElogio = null;
        DescricaoElogio = string.Empty;

        // Clear grids
        FaltasGridItems.Clear();
        HistoricoGridItems.Clear();
        ElogioGridItems.Clear();
        OnPropertyChanged(nameof(FaltasGridItems));
        OnPropertyChanged(nameof(HistoricoGridItems));
        OnPropertyChanged(nameof(ElogioGridItems));
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
                "INSERT INTO interno (id_interno, nome_interno, rgi, st, id_up, sexo, " +
                "TIPOCONDUTA, CONCEITO_DISCIPLINAR, DATA_DELITO, DATA_REABILITACAO) " +
                "VALUES (@ID, @NOME, @RGI, @ST, @ID_UP, @SEXO, " +
                "@TIPOCONDUTA, @CONCEITO, @DATA_DELITO, @DATA_REABILITACAO)",
                DatabaseService.CreateParameter("@ID", id),
                DatabaseService.CreateParameter("@NOME", NomeInterno.Trim().ToUpper()),
                DatabaseService.CreateParameter("@RGI", Rgi?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ST", Status),
                DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp),
                DatabaseService.CreateParameter("@SEXO", Sexo),
                DatabaseService.CreateParameter("@TIPOCONDUTA", TipoConduta ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@CONCEITO", ConceitoDisciplinar ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@DATA_DELITO", (object?)DataDelito ?? DBNull.Value),
                DatabaseService.CreateParameter("@DATA_REABILITACAO", (object?)DataReabilitacao ?? DBNull.Value));
        });
    }

    protected override async Task AtualizarAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE interno SET nome_interno = @NOME, rgi = @RGI, st = @ST, sexo = @SEXO, " +
                "TIPOCONDUTA = @TIPOCONDUTA, CONCEITO_DISCIPLINAR = @CONCEITO, " +
                "DATA_DELITO = @DATA_DELITO, DATA_REABILITACAO = @DATA_REABILITACAO " +
                "WHERE id_interno = @ID",
                DatabaseService.CreateParameter("@ID", IdInterno),
                DatabaseService.CreateParameter("@NOME", NomeInterno.Trim().ToUpper()),
                DatabaseService.CreateParameter("@RGI", Rgi?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ST", Status),
                DatabaseService.CreateParameter("@SEXO", Sexo),
                DatabaseService.CreateParameter("@TIPOCONDUTA", TipoConduta ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@CONCEITO", ConceitoDisciplinar ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@DATA_DELITO", (object?)DataDelito ?? DBNull.Value),
                DatabaseService.CreateParameter("@DATA_REABILITACAO", (object?)DataReabilitacao ?? DBNull.Value));
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
