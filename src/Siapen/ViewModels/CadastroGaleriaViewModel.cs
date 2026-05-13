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

public partial class CadastroGaleriaViewModel : ModeloCadastroViewModel
{
    [ObservableProperty]
    private int _idGaleria;

    [ObservableProperty]
    private string _nomeGaleria = string.Empty;

    [ObservableProperty]
    private int _idPavilhao;

    [ObservableProperty]
    private int _idUp;

    [ObservableProperty]
    private List<LookupItem> _pavilhoes = new();

    [ObservableProperty]
    private LookupItem? _pavilhaoSelecionado;

    public CadastroGaleriaViewModel()
    {
        _orderBy = "galeria";
        TituloCadastro = "Cadastro de Galeria";
    }

    protected override object CreateGridItem(DataRow row)
    {
        return new GaleriaGridItem
        {
            IdGaleria = Convert.ToInt32(row["id_galeria"]),
            Galeria = row["galeria"]?.ToString()?.Trim() ?? "",
            IdPavilhao = row["idpavilhao"] == DBNull.Value ? 0 : Convert.ToInt32(row["idpavilhao"]),
            PavilhaoNome = row["pavilhao_nome"]?.ToString()?.Trim() ?? ""
        };
    }

    public void LoadPavilhoes()
    {
        IdUp = GlobalVars.IdUp;
        LogHelper.Debug($"CadastroGaleria: LoadPavilhoes com GlobalVars.IdUp={GlobalVars.IdUp}, IdUp={IdUp}", "UI");
        Pavilhoes = DmPrincipalService.GetPavilhoesLookup(IdUp > 0 ? IdUp : GlobalVars.IdUp);
    }

    partial void OnPavilhaoSelecionadoChanged(LookupItem? value)
    {
        if (value != null)
            IdPavilhao = value.Id;
    }

    protected override string GetSqlConsulta() =>
        "SELECT g.id_galeria, g.galeria, g.idpavilhao, p.pavilhao AS pavilhao_nome " +
        "FROM galeria g " +
        "INNER JOIN pavilhao p ON p.id_pavilhao = g.idpavilhao AND p.id_up = @ID_UP " +
        "ORDER BY g.galeria";

    protected override FbParameter[] GetSqlParametros()
    {
        var up = IdUp > 0 ? IdUp : GlobalVars.IdUp;
        LogHelper.Debug($"CadastroGaleria: parametro ID_UP={up} (IdUp={IdUp}, GlobalVars.IdUp={GlobalVars.IdUp})", "DB");
        return new[] { DatabaseService.CreateParameter("@ID_UP", up) };
    }

    protected override string Filtrar(string texto) =>
        $"galeria LIKE '%{texto.Replace("'", "''")}%' OR pavilhao_nome LIKE '%{texto.Replace("'", "''")}%'";

    protected override void LimparCampos()
    {
        IdGaleria = 0;
        NomeGaleria = string.Empty;
        IdPavilhao = 0;
        PavilhaoSelecionado = null;
    }

    protected override void PreencherCampos()
    {
        if (SelectedRow == null) return;
        IdGaleria = GetInt(SelectedRow, "id_galeria") ?? 0;
        NomeGaleria = GetString(SelectedRow, "galeria");
        var pavId = GetInt(SelectedRow, "idpavilhao") ?? 0;
        IdPavilhao = pavId;
        if (pavId > 0)
        {
            PavilhaoSelecionado = Pavilhoes.FirstOrDefault(p => p.Id == pavId);
        }
    }

    protected override bool ValidarCampos()
    {
        if (string.IsNullOrWhiteSpace(NomeGaleria))
        {
            StatusMessage = "O campo Galeria é obrigatório.";
            return false;
        }
        return true;
    }

    protected override async Task InserirAsync()
    {
        await Task.Run(() =>
        {
            var id = DatabaseService.GetGeneratorValue("GEN_GALERIA");
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO galeria (id_galeria, galeria, idpavilhao) VALUES (@ID, @NOME, @IDP)",
                DatabaseService.CreateParameter("@ID", id),
                DatabaseService.CreateParameter("@NOME", NomeGaleria.Trim().ToUpper()),
                DatabaseService.CreateParameter("@IDP", IdPavilhao > 0 ? IdPavilhao : DBNull.Value));
        });
    }

    protected override async Task AtualizarAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE galeria SET galeria = @NOME, idpavilhao = @IDP WHERE id_galeria = @ID",
                DatabaseService.CreateParameter("@ID", IdGaleria),
                DatabaseService.CreateParameter("@NOME", NomeGaleria.Trim().ToUpper()),
                DatabaseService.CreateParameter("@IDP", IdPavilhao > 0 ? IdPavilhao : DBNull.Value));
        });
    }

    protected override async Task ExcluirAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "DELETE FROM galeria WHERE id_galeria = @ID",
                DatabaseService.CreateParameter("@ID", IdGaleria));
        });
    }
}