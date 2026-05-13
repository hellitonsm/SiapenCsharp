using System;
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
    private DataTable _pavilhoes = new();

    [ObservableProperty]
    private DataRowView? _pavilhaoSelecionado;

    public CadastroGaleriaViewModel()
    {
        _orderBy = "galeria";
        TituloCadastro = "Cadastro de Galeria";
    }

    public void LoadPavilhoes()
    {
        Pavilhoes = DmPrincipalService.GetPavilhoes(GlobalVars.IdUp);
    }

    partial void OnPavilhaoSelecionadoChanged(DataRowView? value)
    {
        if (value != null)
            IdPavilhao = GetInt(value, "id_pavilhao") ?? 0;
    }

    protected override string GetSqlConsulta() =>
        "SELECT g.id_galeria, g.galeria, g.idpavilhao, p.pavilhao AS pavilhao_nome " +
        "FROM galeria g " +
        "LEFT JOIN pavilhao p ON p.id_pavilhao = g.idpavilhao " +
        "WHERE p.id_up = @ID_UP ORDER BY g.galeria";

    protected override FbParameter[] GetSqlParametros() =>
        new[] { DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp) };

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
        if (pavId > 0 && Pavilhoes.DefaultView != null)
        {
            foreach (DataRowView row in Pavilhoes.DefaultView)
            {
                if (GetInt(row, "id_pavilhao") == pavId)
                {
                    PavilhaoSelecionado = row;
                    break;
                }
            }
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
