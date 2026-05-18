using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FirebirdSql.Data.FirebirdClient;
using Siapen.Helpers;
using Siapen.Services;

namespace Siapen.ViewModels;

/// <summary>
/// Grid item for the "Envolvido nos Inquéritos" DataGrid (DsBuscaEnvolvido equivalent).
/// </summary>
public class EncontradoGridItem
{
    public string NumeroProced { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Mae { get; set; } = string.Empty;
    public string Pai { get; set; } = string.Empty;
    public string DataNascimentoStr { get; set; } = string.Empty;
}

/// <summary>
/// Grid item for the "Antecedentes Criminais" DataGrid (DsAntecedentesCriminais equivalent).
/// </summary>
public class AntecedenteGridItem
{
    public string Numero { get; set; } = string.Empty;
    public string Ano { get; set; } = string.Empty;
    public string Up { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Instauracao { get; set; } = string.Empty;
    public string Sentencas { get; set; } = string.Empty;
    public string Baixa { get; set; } = string.Empty;
    public string MotivoAlvara { get; set; } = string.Empty;
    public string Incidencias { get; set; } = string.Empty;
}

public partial class ConsultaProcedViewModel : ViewModelBase
{
    // === Search fields ===
    [ObservableProperty] private string _numeroProced = string.Empty;
    [ObservableProperty] private string _nome = string.Empty;
    [ObservableProperty] private string _nomeMae = string.Empty;
    [ObservableProperty] private string _dataNascimento = string.Empty;

    // === Grid items: Encontrados (DsBuscaEnvolvido) ===
    [ObservableProperty] private List<EncontradoGridItem> _encontrados = new();
    [ObservableProperty] private EncontradoGridItem? _selectedEncontrado;

    // === Grid items: Antecedentes (DsAntecedentesCriminais) ===
    [ObservableProperty] private List<AntecedenteGridItem> _antecedentes = new();
    [ObservableProperty] private AntecedenteGridItem? _selectedAntecedente;

    // === Rich text sentence display ===
    [ObservableProperty] private string _sentencaTexto = string.Empty;

    // === Status ===
    [ObservableProperty] private string _statusMessage = "Preencha os campos e clique em Consultar";

    public ConsultaProcedViewModel()
    {
    }

    partial void OnSelectedEncontradoChanged(EncontradoGridItem? value)
    {
        if (value != null)
        {
            // When a row is selected in the "Envolvido" grid, load antecedents for that person
            LoadAntecedentesForEncontrado(value);
        }
    }

    [RelayCommand]
    private async Task Consultar()
    {
        StatusMessage = "Consultando...";
        try
        {
            // Since we don't have the external Proced system (DmProced DataModule),
            // we query the local INTERNO table as a placeholder.
            // This allows the screen to function with local data until the
            // Proced integration is available.
            await Task.Run(() => QueryLocalInternos());

            if (Encontrados.Count == 0)
            {
                StatusMessage = "Nenhum registro encontrado. Consulta ao Proced requer integração com sistema externo.";
                Antecedentes = new List<AntecedenteGridItem>();
                SentencaTexto = string.Empty;
            }
            else
            {
                StatusMessage = $"{Encontrados.Count} registro(s) encontrado(s) localmente.";
            }
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro na consulta", ex, nameof(ConsultaProcedViewModel));
            StatusMessage = $"Erro: {ex.Message}";
        }
    }

    /// <summary>
    /// Placeholder query against the local INTERNO table.
    /// In the original Delphi system, this would query the external Proced system via DmProced.
    /// </summary>
    private void QueryLocalInternos()
    {
        var results = new List<EncontradoGridItem>();

        var sql = "SELECT FIRST 50 i.id_interno, i.nome_interno, i.nome_mae, i.nome_pai, i.dt_nascimento " +
                  "FROM interno i WHERE i.id_up = @ID_UP";

        var parameters = new List<FbParameter>
        {
            DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp)
        };

        // Add optional filters
        if (!string.IsNullOrWhiteSpace(Nome))
        {
            sql += " AND i.nome_interno LIKE @NOME";
            parameters.Add(DatabaseService.CreateParameter("@NOME", $"%{Nome.Trim().ToUpper()}%"));
        }

        if (!string.IsNullOrWhiteSpace(NomeMae))
        {
            sql += " AND i.nome_mae LIKE @MAE";
            parameters.Add(DatabaseService.CreateParameter("@MAE", $"%{NomeMae.Trim().ToUpper()}%"));
        }

        sql += " ORDER BY i.nome_interno";

        try
        {
            var dt = DatabaseService.ExecuteQuery(sql, parameters.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                var dtNasc = row["dt_nascimento"];
                string dtNascStr = string.Empty;
                if (dtNasc != null && dtNasc != DBNull.Value)
                {
                    dtNascStr = Convert.ToDateTime(dtNasc).ToString("dd/MM/yyyy");
                }

                results.Add(new EncontradoGridItem
                {
                    NumeroProced = row["id_interno"]?.ToString() ?? "",
                    Nome = row["nome_interno"]?.ToString()?.Trim() ?? "",
                    Mae = row["nome_mae"]?.ToString()?.Trim() ?? "",
                    Pai = row["nome_pai"]?.ToString()?.Trim() ?? "",
                    DataNascimentoStr = dtNascStr
                });
            }
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro na consulta local de internos", ex, nameof(ConsultaProcedViewModel));
            throw;
        }

        Encontrados = results;
        Antecedentes = new List<AntecedenteGridItem>();
        SentencaTexto = string.Empty;
    }

    /// <summary>
    /// Placeholder: Load antecedents for a selected "encontrado".
    /// In the original system, this would come from DmProced.DsAntecedentesCriminais.
    /// </summary>
    private void LoadAntecedentesForEncontrado(EncontradoGridItem encontrado)
    {
        // Placeholder: no external Proced data available
        Antecedentes = new List<AntecedenteGridItem>();
        SentencaTexto = string.Empty;
    }
}
