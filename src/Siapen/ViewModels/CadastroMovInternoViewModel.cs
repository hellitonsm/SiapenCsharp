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

public partial class CadastroMovInternoViewModel : ModeloCadastroViewModel
{
    // === Campos principais do MOV_INTERNO ===
    [ObservableProperty] private int _idMovInterno;
    [ObservableProperty] private int? _idInterno;
    [ObservableProperty] private int? _idUnidadePenal;
    [ObservableProperty] private DateTime? _dataMovimentacao = DateTime.Today;
    [ObservableProperty] private string _horaMovimentacao = string.Empty;
    [ObservableProperty] private string _tipoMovimentacao = string.Empty;
    [ObservableProperty] private int? _idFuncionario;
    [ObservableProperty] private int? _idProcedencia;
    [ObservableProperty] private int? _idDestino;

    // === Lookup selected items ===
    [ObservableProperty] private LookupItem? _selectedInterno;
    [ObservableProperty] private LookupItem? _selectedUnidadePenal;
    [ObservableProperty] private LookupItem? _selectedFuncionario;
    [ObservableProperty] private LookupItem? _selectedProcedencia;
    [ObservableProperty] private LookupItem? _selectedDestino;

    // === Lookup collections ===
    public List<LookupItem> Internos { get; } = new();
    public List<LookupItem> UnidadesPenal { get; } = new();
    public List<LookupItem> Funcionarios { get; } = new();
    public List<LookupItem> Procedencias { get; } = new();
    public List<LookupItem> Destinos { get; } = new();

    public CadastroMovInternoViewModel()
    {
        _orderBy = "data_movimentacao DESC";
        TituloCadastro = "Cadastro Movimentação do Interno(a)";
    }

    protected override string GetSqlConsulta() =>
        "SELECT m.id_mov_interno, m.id_interno, m.id_unidade_penal, " +
        "m.data_movimentacao, m.hora_movimentacao, m.tipo_movimentacao, " +
        "m.id_funcionario, m.id_procedencia, m.id_destino, " +
        "i.nome_interno " +
        "FROM mov_interno m " +
        "LEFT JOIN interno i ON m.id_interno = i.id_interno " +
        "ORDER BY m.data_movimentacao DESC";

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
                LoadLookup(Internos, "SELECT ID_INTERNO, NOME_INTERNO FROM INTERNO " +
                    "WHERE ID_UP = @ID_UP AND ST = 'A' AND COALESCE(NOME_INTERNO, '') <> '' ORDER BY NOME_INTERNO",
                    DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp));

                LoadLookup(UnidadesPenal, "SELECT ID_UP, NOME_UP FROM UNIDADE_PENAL ORDER BY NOME_UP");

                LoadLookup(Funcionarios, "SELECT ID_FUNCIONARIO, NOME_FUNCIONARIO FROM FUNCIONARIO " +
                    "WHERE ID_UP = @ID_UP AND COALESCE(NOME_FUNCIONARIO, '') <> '' ORDER BY NOME_FUNCIONARIO",
                    DatabaseService.CreateParameter("@ID_UP", GlobalVars.IdUp));

                LoadLookup(Procedencias, "SELECT ID_PROCEDENCIA, PROCEDENCIA FROM PROCEDENCIA ORDER BY PROCEDENCIA");
                LoadLookup(Destinos, "SELECT ID_DESTINO, DESTINO FROM DESTINO ORDER BY DESTINO");
            });
            OnPropertyChanged(nameof(Internos));
            OnPropertyChanged(nameof(UnidadesPenal));
            OnPropertyChanged(nameof(Funcionarios));
            OnPropertyChanged(nameof(Procedencias));
            OnPropertyChanged(nameof(Destinos));
        }
        catch (Exception ex)
        {
            LogHelper.Error("Erro ao carregar lookups do MovInterno", ex, nameof(CadastroMovInternoViewModel));
        }
    }

    private void LoadLookup(List<LookupItem> list, string sql, params FbParameter[] parameters)
    {
        list.Clear();
        var dt = DatabaseService.ExecuteQuery(sql, parameters);
        foreach (DataRow row in dt.Rows)
        {
            list.Add(new LookupItem(
                Convert.ToInt32(row[0]),
                row[1]?.ToString()?.Trim() ?? ""));
        }
    }

    partial void OnSelectedInternoChanged(LookupItem? value) => IdInterno = value?.Id;
    partial void OnSelectedUnidadePenalChanged(LookupItem? value) => IdUnidadePenal = value?.Id;
    partial void OnSelectedFuncionarioChanged(LookupItem? value) => IdFuncionario = value?.Id;
    partial void OnSelectedProcedenciaChanged(LookupItem? value) => IdProcedencia = value?.Id;
    partial void OnSelectedDestinoChanged(LookupItem? value) => IdDestino = value?.Id;

    [RelayCommand]
    private void CarregarRegistroSelecionado()
    {
        if (SelectedRow != null && Modo == CadastroModo.Navegando)
        {
            PreencherCampos();
            TabIndex = 0;
        }
    }

    protected override void LimparCampos()
    {
        IdMovInterno = 0;
        IdInterno = null;
        IdUnidadePenal = null;
        DataMovimentacao = DateTime.Today;
        HoraMovimentacao = string.Empty;
        TipoMovimentacao = string.Empty;
        IdFuncionario = null;
        IdProcedencia = null;
        IdDestino = null;
        SelectedInterno = null;
        SelectedUnidadePenal = null;
        SelectedFuncionario = null;
        SelectedProcedencia = null;
        SelectedDestino = null;
    }

    protected override void PreencherCampos()
    {
        if (SelectedRow == null) return;

        IdMovInterno = GetInt(SelectedRow, "id_mov_interno") ?? 0;
        IdInterno = GetInt(SelectedRow, "id_interno");
        IdUnidadePenal = GetInt(SelectedRow, "id_unidade_penal");
        DataMovimentacao = GetDateTime(SelectedRow, "data_movimentacao");
        HoraMovimentacao = GetString(SelectedRow, "hora_movimentacao");
        TipoMovimentacao = GetString(SelectedRow, "tipo_movimentacao");
        IdFuncionario = GetInt(SelectedRow, "id_funcionario");
        IdProcedencia = GetInt(SelectedRow, "id_procedencia");
        IdDestino = GetInt(SelectedRow, "id_destino");

        // Restore lookup selections from IDs
        SelectedInterno = Internos.FirstOrDefault(x => x.Id == IdInterno);
        SelectedUnidadePenal = UnidadesPenal.FirstOrDefault(x => x.Id == IdUnidadePenal);
        SelectedFuncionario = Funcionarios.FirstOrDefault(x => x.Id == IdFuncionario);
        SelectedProcedencia = Procedencias.FirstOrDefault(x => x.Id == IdProcedencia);
        SelectedDestino = Destinos.FirstOrDefault(x => x.Id == IdDestino);
    }

    protected override bool ValidarCampos()
    {
        if (IdInterno == null || IdInterno == 0)
        {
            StatusMessage = "O campo Interno é obrigatório.";
            return false;
        }
        if (IdUnidadePenal == null || IdUnidadePenal == 0)
        {
            StatusMessage = "O campo Unidade Penal é obrigatório.";
            return false;
        }
        if (DataMovimentacao == null)
        {
            StatusMessage = "O campo Data da Movimentação é obrigatório.";
            return false;
        }
        return true;
    }

    protected override object CreateGridItem(DataRow row)
    {
        return new MovInternoGridItem
        {
            IdMovInterno = Convert.ToInt32(row["id_mov_interno"]),
            IdInterno = Convert.ToInt32(row["id_interno"]),
            NomeInterno = row["nome_interno"]?.ToString()?.Trim() ?? "",
            IdUnidadePenal = row["id_unidade_penal"] != DBNull.Value ? Convert.ToInt32(row["id_unidade_penal"]) : 0,
            DataMovimentacao = row["data_movimentacao"]?.ToString(),
            HoraMovimentacao = row["hora_movimentacao"]?.ToString(),
            TipoMovimentacao = row["tipo_movimentacao"]?.ToString()?.Trim() ?? "",
            IdFuncionario = row["id_funcionario"] != DBNull.Value ? Convert.ToInt32(row["id_funcionario"]) : null,
            IdProcedencia = row["id_procedencia"] != DBNull.Value ? Convert.ToInt32(row["id_procedencia"]) : null,
            IdDestino = row["id_destino"] != DBNull.Value ? Convert.ToInt32(row["id_destino"]) : null
        };
    }

    protected override async Task InserirAsync()
    {
        await Task.Run(() =>
        {
            var id = DatabaseService.GetGeneratorValue("GEN_MOV_INTERNO");
            DatabaseService.ExecuteNonQuery(
                "INSERT INTO mov_interno (id_mov_interno, id_interno, id_unidade_penal, " +
                "data_movimentacao, hora_movimentacao, tipo_movimentacao, id_funcionario, " +
                "id_procedencia, id_destino) " +
                "VALUES (@ID, @ID_INTERNO, @ID_UP, @DATA, @HORA, @TIPO, @ID_FUNC, @ID_PROC, @ID_DEST)",
                DatabaseService.CreateParameter("@ID", id),
                DatabaseService.CreateParameter("@ID_INTERNO", (object?)IdInterno ?? DBNull.Value),
                DatabaseService.CreateParameter("@ID_UP", (object?)IdUnidadePenal ?? DBNull.Value),
                DatabaseService.CreateParameter("@DATA", DataMovimentacao ?? DateTime.Today),
                DatabaseService.CreateParameter("@HORA", string.IsNullOrWhiteSpace(HoraMovimentacao) ? (object)DBNull.Value : HoraMovimentacao.Trim()),
                DatabaseService.CreateParameter("@TIPO", string.IsNullOrWhiteSpace(TipoMovimentacao) ? (object)DBNull.Value : TipoMovimentacao.Trim().ToUpper()),
                DatabaseService.CreateParameter("@ID_FUNC", (object?)IdFuncionario ?? DBNull.Value),
                DatabaseService.CreateParameter("@ID_PROC", (object?)IdProcedencia ?? DBNull.Value),
                DatabaseService.CreateParameter("@ID_DEST", (object?)IdDestino ?? DBNull.Value));
        });
    }

    protected override async Task AtualizarAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "UPDATE mov_interno SET id_interno = @ID_INTERNO, id_unidade_penal = @ID_UP, " +
                "data_movimentacao = @DATA, hora_movimentacao = @HORA, tipo_movimentacao = @TIPO, " +
                "id_funcionario = @ID_FUNC, id_procedencia = @ID_PROC, id_destino = @ID_DEST " +
                "WHERE id_mov_interno = @ID",
                DatabaseService.CreateParameter("@ID", IdMovInterno),
                DatabaseService.CreateParameter("@ID_INTERNO", (object?)IdInterno ?? DBNull.Value),
                DatabaseService.CreateParameter("@ID_UP", (object?)IdUnidadePenal ?? DBNull.Value),
                DatabaseService.CreateParameter("@DATA", DataMovimentacao ?? DateTime.Today),
                DatabaseService.CreateParameter("@HORA", string.IsNullOrWhiteSpace(HoraMovimentacao) ? (object)DBNull.Value : HoraMovimentacao.Trim()),
                DatabaseService.CreateParameter("@TIPO", string.IsNullOrWhiteSpace(TipoMovimentacao) ? (object)DBNull.Value : TipoMovimentacao.Trim().ToUpper()),
                DatabaseService.CreateParameter("@ID_FUNC", (object?)IdFuncionario ?? DBNull.Value),
                DatabaseService.CreateParameter("@ID_PROC", (object?)IdProcedencia ?? DBNull.Value),
                DatabaseService.CreateParameter("@ID_DEST", (object?)IdDestino ?? DBNull.Value));
        });
    }

    protected override async Task ExcluirAsync()
    {
        await Task.Run(() =>
        {
            DatabaseService.ExecuteNonQuery(
                "DELETE FROM mov_interno WHERE id_mov_interno = @ID",
                DatabaseService.CreateParameter("@ID", IdMovInterno));
        });
    }
}
