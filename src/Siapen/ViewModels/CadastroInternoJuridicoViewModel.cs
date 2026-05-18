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

public partial class CadastroInternoJuridicoViewModel : ModeloCadastroViewModel
{
    // === Campos principais do INTERNO ===
    [ObservableProperty] private int _idInterno;
    [ObservableProperty] private string _nomeInterno = string.Empty;
    [ObservableProperty] private string _rgi = string.Empty;
    [ObservableProperty] private string _vulgo = string.Empty;
    [ObservableProperty] private string _status = "A";
    [ObservableProperty] private string _sexo = "M";
    [ObservableProperty] private string _nomeUp = string.Empty;
    [ObservableProperty] private string _siglaUp = string.Empty;

    // === Campos Jurídicos ===
    [ObservableProperty] private bool _medidaSegurancaSim;
    [ObservableProperty] private bool _medidaSegurancaNao = true;
    [ObservableProperty] private string _tipoProcesso = string.Empty;
    [ObservableProperty] private string _regimeAtual = string.Empty;
    [ObservableProperty] private int? _tempoConsolidadoAno;
    [ObservableProperty] private int? _tempoConsolidadoMes;
    [ObservableProperty] private int? _tempoConsolidadoDia;
    [ObservableProperty] private string _passagemSpf = string.Empty;
    [ObservableProperty] private string _motivacaoInclusao = string.Empty;

    // === Controle Permanência ===
    [ObservableProperty] private DateTime? _dataInicialPermanencia;
    [ObservableProperty] private string _autorizacaoPermanencia = string.Empty;
    [ObservableProperty] private int? _diasAutorizadosPermanencia;
    [ObservableProperty] private DateTime? _dataFinalPermanencia;
    [ObservableProperty] private string _numAutosPermanencia = string.Empty;
    [ObservableProperty] private string _obsPermanencia = string.Empty;
    [ObservableProperty] private bool _conflitoCompetenciaSim;
    [ObservableProperty] private bool _conflitoCompetenciaNao = true;
    [ObservableProperty] private string _numConflito = string.Empty;
    [ObservableProperty] private string _obsConflito = string.Empty;
    [ObservableProperty] private string _statusConflito = string.Empty;

    // === Histórico ===
    [ObservableProperty] private DateTime? _dataHistorico;
    [ObservableProperty] private string _descricaoHistorico = string.Empty;
    [ObservableProperty] private string _obsHistorico = string.Empty;

    // === Benefício ===
    [ObservableProperty] private DateTime? _dataBeneficio;
    [ObservableProperty] private string _tipoBeneficio = string.Empty;
    [ObservableProperty] private bool _beneficioConcedidoSim;
    [ObservableProperty] private bool _beneficioConcedidoNao = true;
    [ObservableProperty] private string _obsBeneficio = string.Empty;

    // === Filtro ===
    [ObservableProperty] private bool _filtroAtivo = true;
    [ObservableProperty] private bool _filtroInativo;
    private bool _somenteInativos;

    // === Sexo radio ===
    [ObservableProperty] private bool _sexoMasculino = true;
    [ObservableProperty] private bool _sexoFeminino;

    // === Grid items for sub-tables ===
    public List<ControlePermanenciaItem> ControlePermanenciaItems { get; } = new();
    public List<HistoricoItem> HistoricoItems { get; } = new();
    public List<CalculoExecucaoItem> CalculoExecucaoItems { get; } = new();
    public List<CondenacoesItem> CondenacoesItems { get; } = new();
    public List<DetracaoItem> DetracaoItems { get; } = new();
    public List<InterrupcaoItem> InterrupcaoItems { get; } = new();
    public List<RemicaoItem> RemicaoItems { get; } = new();
    public List<MapaCarcerarioItem> MapaCarcerarioItems { get; } = new();
    public List<ComutacaoItem> ComutacaoItems { get; } = new();
    public List<BeneficioItem> BeneficioItems { get; } = new();

    public CadastroInternoJuridicoViewModel()
    {
        _orderBy = "nome_interno";
        TituloCadastro = "Cadastro Jurídico";
        NomeUp = GlobalVars.NomeUp;
    }

    protected override string GetSqlConsulta()
    {
        var sql = "SELECT i.id_interno, i.nome_interno, i.rgi, i.vulgo, i.st, " +
            "i.medida_seguranca, i.tipo_processo, i.passagem_spf, i.motivacao_inclusao, " +
            "i.tempo_consolidado_ano, i.tempo_consolidado_mes, i.tempo_consolidado_dia, " +
            "i.regime_atual, i.sexo, u.sigla " +
            "FROM interno i " +
            "LEFT JOIN unidade_penal u ON i.id_up = u.id_up " +
            "WHERE i.id_up = @ID_UP ";
        if (_somenteInativos)
            sql += "AND i.st = 'I' ROWS 500 ";
        else
            sql += "AND i.st = 'A' ";
        sql += "ORDER BY i.nome_interno";
        return sql;
    }

    protected override FbParameter[] GetSqlParametros() =>
        new[] { DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp) };

    protected override string Filtrar(string texto) =>
        $"nome_interno LIKE '%{texto.Replace("'", "''")}%'";

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

    partial void OnSexoMasculinoChanged(bool value) { if (value) Sexo = "M"; SexoFeminino = false; }
    partial void OnSexoFemininoChanged(bool value) { if (value) Sexo = "F"; SexoMasculino = false; }

    partial void OnMedidaSegurancaSimChanged(bool value) { if (value) MedidaSegurancaNao = false; }
    partial void OnMedidaSegurancaNaoChanged(bool value) { if (value) MedidaSegurancaSim = false; }

    partial void OnConflitoCompetenciaSimChanged(bool value) { if (value) ConflitoCompetenciaNao = false; }
    partial void OnConflitoCompetenciaNaoChanged(bool value) { if (value) ConflitoCompetenciaSim = false; }

    partial void OnBeneficioConcedidoSimChanged(bool value) { if (value) BeneficioConcedidoNao = false; }
    partial void OnBeneficioConcedidoNaoChanged(bool value) { if (value) BeneficioConcedidoSim = false; }

    [RelayCommand]
    private void CarregarRegistroSelecionado()
    {
        if (SelectedRow != null && Modo == CadastroModo.Navegando)
        {
            PreencherCampos();
            TabIndex = 0;
        }
    }

    [RelayCommand]
    private async Task LoadCommand()
    {
        await LoadAsync();
    }

    protected override void LimparCampos()
    {
        IdInterno = 0;
        NomeInterno = string.Empty;
        Rgi = string.Empty;
        Vulgo = string.Empty;
        Status = "A";
        Sexo = "M";
        SexoMasculino = true;
        SexoFeminino = false;
        MedidaSegurancaSim = false;
        MedidaSegurancaNao = true;
        TipoProcesso = string.Empty;
        RegimeAtual = string.Empty;
        TempoConsolidadoAno = null;
        TempoConsolidadoMes = null;
        TempoConsolidadoDia = null;
        PassagemSpf = string.Empty;
        MotivacaoInclusao = string.Empty;
        DataInicialPermanencia = null;
        AutorizacaoPermanencia = string.Empty;
        DiasAutorizadosPermanencia = null;
        DataFinalPermanencia = null;
        NumAutosPermanencia = string.Empty;
        ObsPermanencia = string.Empty;
        ConflitoCompetenciaSim = false;
        ConflitoCompetenciaNao = true;
        NumConflito = string.Empty;
        ObsConflito = string.Empty;
        StatusConflito = string.Empty;
        DataHistorico = null;
        DescricaoHistorico = string.Empty;
        ObsHistorico = string.Empty;
        DataBeneficio = null;
        TipoBeneficio = string.Empty;
        BeneficioConcedidoSim = false;
        BeneficioConcedidoNao = true;
        ObsBeneficio = string.Empty;
        ControlePermanenciaItems.Clear();
        HistoricoItems.Clear();
        CalculoExecucaoItems.Clear();
        CondenacoesItems.Clear();
        DetracaoItems.Clear();
        InterrupcaoItems.Clear();
        RemicaoItems.Clear();
        MapaCarcerarioItems.Clear();
        ComutacaoItems.Clear();
        BeneficioItems.Clear();
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

        // Jurídico fields
        var medidaSeguranca = GetString(SelectedRow, "medida_seguranca");
        MedidaSegurancaSim = medidaSeguranca == "S";
        MedidaSegurancaNao = medidaSeguranca != "S";
        TipoProcesso = GetString(SelectedRow, "tipo_processo");
        RegimeAtual = GetString(SelectedRow, "regime_atual");
        TempoConsolidadoAno = GetInt(SelectedRow, "tempo_consolidado_ano");
        TempoConsolidadoMes = GetInt(SelectedRow, "tempo_consolidado_mes");
        TempoConsolidadoDia = GetInt(SelectedRow, "tempo_consolidado_dia");
        PassagemSpf = GetString(SelectedRow, "passagem_spf");
        MotivacaoInclusao = GetString(SelectedRow, "motivacao_inclusao");

        // Sexo
        var sexoVal = GetString(SelectedRow, "sexo");
        SexoMasculino = sexoVal == "M" || string.IsNullOrEmpty(sexoVal);
        SexoFeminino = sexoVal == "F";
        Sexo = SexoMasculino ? "M" : "F";
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
                "medida_seguranca, tipo_processo, regime_atual, " +
                "tempo_consolidado_ano, tempo_consolidado_mes, tempo_consolidado_dia, " +
                "passagem_spf, motivacao_inclusao) " +
                "VALUES (@ID, @NOME, @RGI, @ST, @ID_UP, @SEXO, " +
                "@MEDIDA, @TIPO_PROC, @REGIME, " +
                "@ANO, @MES, @DIA, " +
                "@PASSAGEM, @MOTIVACAO)",
                DatabaseService.CreateParameter("@ID", id),
                DatabaseService.CreateParameter("@NOME", NomeInterno.Trim().ToUpper()),
                DatabaseService.CreateParameter("@RGI", Rgi?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ST", Status),
                DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp),
                DatabaseService.CreateParameter("@SEXO", Sexo),
                DatabaseService.CreateParameter("@MEDIDA", MedidaSegurancaSim ? "S" : "N"),
                DatabaseService.CreateParameter("@TIPO_PROC", TipoProcesso ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@REGIME", RegimeAtual ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ANO", (object?)TempoConsolidadoAno ?? DBNull.Value),
                DatabaseService.CreateParameter("@MES", (object?)TempoConsolidadoMes ?? DBNull.Value),
                DatabaseService.CreateParameter("@DIA", (object?)TempoConsolidadoDia ?? DBNull.Value),
                DatabaseService.CreateParameter("@PASSAGEM", PassagemSpf ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@MOTIVACAO", MotivacaoInclusao ?? (object)DBNull.Value));
        });
    }

    protected override async Task AtualizarAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE interno SET nome_interno = @NOME, rgi = @RGI, st = @ST, sexo = @SEXO, " +
                "medida_seguranca = @MEDIDA, tipo_processo = @TIPO_PROC, regime_atual = @REGIME, " +
                "tempo_consolidado_ano = @ANO, tempo_consolidado_mes = @MES, tempo_consolidado_dia = @DIA, " +
                "passagem_spf = @PASSAGEM, motivacao_inclusao = @MOTIVACAO " +
                "WHERE id_interno = @ID",
                DatabaseService.CreateParameter("@ID", IdInterno),
                DatabaseService.CreateParameter("@NOME", NomeInterno.Trim().ToUpper()),
                DatabaseService.CreateParameter("@RGI", Rgi?.Trim() ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ST", Status),
                DatabaseService.CreateParameter("@SEXO", Sexo),
                DatabaseService.CreateParameter("@MEDIDA", MedidaSegurancaSim ? "S" : "N"),
                DatabaseService.CreateParameter("@TIPO_PROC", TipoProcesso ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@REGIME", RegimeAtual ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@ANO", (object?)TempoConsolidadoAno ?? DBNull.Value),
                DatabaseService.CreateParameter("@MES", (object?)TempoConsolidadoMes ?? DBNull.Value),
                DatabaseService.CreateParameter("@DIA", (object?)TempoConsolidadoDia ?? DBNull.Value),
                DatabaseService.CreateParameter("@PASSAGEM", PassagemSpf ?? (object)DBNull.Value),
                DatabaseService.CreateParameter("@MOTIVACAO", MotivacaoInclusao ?? (object)DBNull.Value));
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

public class ControlePermanenciaItem
{
    public string DataInicial { get; set; } = "";
    public string Autorizacao { get; set; } = "";
    public string Dias { get; set; } = "";
    public string DataFinal { get; set; } = "";
    public string NumAutos { get; set; } = "";
    public string Obs { get; set; } = "";
}

public class HistoricoItem
{
    public string Data { get; set; } = "";
    public string Descricao { get; set; } = "";
}

public class CalculoExecucaoItem
{
    public string Tipo { get; set; } = "";
    public string Descricao { get; set; } = "";
    public string Tempo { get; set; } = "";
}

public class CondenacoesItem
{
    public string Artigo { get; set; } = "";
    public string Descricao { get; set; } = "";
    public string Pena { get; set; } = "";
}

public class DetracaoItem
{
    public string DataInicio { get; set; } = "";
    public string DataFim { get; set; } = "";
    public string Dias { get; set; } = "";
    public string Obs { get; set; } = "";
}

public class InterrupcaoItem
{
    public string DataInicio { get; set; } = "";
    public string DataFim { get; set; } = "";
    public string Dias { get; set; } = "";
    public string Motivo { get; set; } = "";
}

public class RemicaoItem
{
    public string Data { get; set; } = "";
    public string Tipo { get; set; } = "";
    public string Dias { get; set; } = "";
    public string Obs { get; set; } = "";
}

public class MapaCarcerarioItem
{
    public string Data { get; set; } = "";
    public string Regime { get; set; } = "";
    public string Local { get; set; } = "";
}

public class ComutacaoItem
{
    public string Data { get; set; } = "";
    public string Decreto { get; set; } = "";
    public string DiasRemidos { get; set; } = "";
    public string Obs { get; set; } = "";
}

public class BeneficioItem
{
    public string Data { get; set; } = "";
    public string Tipo { get; set; } = "";
    public string Concedido { get; set; } = "";
    public string Obs { get; set; } = "";
}
