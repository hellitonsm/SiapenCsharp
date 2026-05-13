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

public partial class CadastroPavilhaoViewModel : ModeloCadastroViewModel
{
    [ObservableProperty]
    private int _idPavilhao;

    [ObservableProperty]
    private string _nomePavilhao = string.Empty;

    [ObservableProperty]
    private int _idUp;

    [ObservableProperty]
    private UnidadePenal? _unidadePenalSelecionada;

    [ObservableProperty]
    private List<UnidadePenal> _unidadesPenal = new();

    private bool _isInitialized;
    private bool _isPreenchendo;

    public CadastroPavilhaoViewModel()
    {
        _orderBy = "pavilhao";
        TituloCadastro = "Cadastro de Pavilhão";
    }

    public void LoadUnidades()
    {
        UnidadesPenal = DmPrincipalService.GetUnidadesPenal();
        UnidadePenalSelecionada = UnidadesPenal.FirstOrDefault(u => u.IdUp == GlobalVars.IdUp);
        if (UnidadePenalSelecionada != null)
            IdUp = UnidadePenalSelecionada.IdUp;
        _isInitialized = true;
    }

    partial void OnUnidadePenalSelecionadaChanged(UnidadePenal? value)
    {
        if (value != null)
        {
            IdUp = value.IdUp;
            if (_isInitialized && !_isPreenchendo && Modo == CadastroModo.Navegando)
                _ = LoadAsync();
        }
    }

    protected override string GetSqlConsulta() =>
        "SELECT id_pavilhao, pavilhao, id_up " +
        "FROM pavilhao WHERE id_up = @ID_UP ORDER BY pavilhao";

    protected override FbParameter[] GetSqlParametros() =>
        new[] { DatabaseService.CreateParameter("@ID_UP", IdUp > 0 ? IdUp : GlobalVars.IdUp) };

    protected override string Filtrar(string texto) =>
        $"pavilhao LIKE '%{texto.Replace("'", "''")}%'";

    protected override void LimparCampos()
    {
        IdPavilhao = 0;
        NomePavilhao = string.Empty;
        if (UnidadePenalSelecionada != null)
            IdUp = UnidadePenalSelecionada.IdUp;
    }

    protected override void PreencherCampos()
    {
        if (SelectedRow == null) return;
        _isPreenchendo = true;
        IdPavilhao = GetInt(SelectedRow, "id_pavilhao") ?? 0;
        NomePavilhao = GetString(SelectedRow, "pavilhao");
        var rowIdUp = GetInt(SelectedRow, "id_up");
        if (rowIdUp.HasValue)
        {
            IdUp = rowIdUp.Value;
            UnidadePenalSelecionada = UnidadesPenal.FirstOrDefault(u => u.IdUp == IdUp);
        }
        _isPreenchendo = false;
    }

    protected override bool ValidarCampos()
    {
        if (string.IsNullOrWhiteSpace(NomePavilhao))
        {
            StatusMessage = "O campo Pavilhão é obrigatório.";
            return false;
        }
        return true;
    }

    protected override object CreateGridItem(DataRow row)
    {
        return new PavilhaoGridItem
        {
            IdPavilhao = System.Convert.ToInt32(row["id_pavilhao"]),
            Pavilhao = row["pavilhao"]?.ToString()?.Trim() ?? "",
            IdUp = System.Convert.ToInt32(row["id_up"])
        };
    }

    protected override async Task InserirAsync()
    {
        await Task.Run(() =>
        {
            var id = DatabaseService.GetGeneratorValue("GEN_PAVILHAO");
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO pavilhao (id_pavilhao, pavilhao, id_up) VALUES (@ID, @NOME, @ID_UP)",
                DatabaseService.CreateParameter("@ID", id),
                DatabaseService.CreateParameter("@NOME", NomePavilhao.Trim().ToUpper()),
                DatabaseService.CreateParameter("@ID_UP", IdUp > 0 ? IdUp : GlobalVars.IdUp));
        });
    }

    protected override async Task AtualizarAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE pavilhao SET pavilhao = @NOME, id_up = @ID_UP WHERE id_pavilhao = @ID",
                DatabaseService.CreateParameter("@ID", IdPavilhao),
                DatabaseService.CreateParameter("@NOME", NomePavilhao.Trim().ToUpper()),
                DatabaseService.CreateParameter("@ID_UP", IdUp > 0 ? IdUp : GlobalVars.IdUp));
        });
    }

    protected override async Task ExcluirAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "DELETE FROM pavilhao WHERE id_pavilhao = @ID",
                DatabaseService.CreateParameter("@ID", IdPavilhao));
        });
    }
}
