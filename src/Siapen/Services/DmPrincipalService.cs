using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FirebirdSql.Data.FirebirdClient;
using Siapen.Helpers;
using Siapen.Models;

namespace Siapen.Services;

/// <summary>
/// Serviço equivalente ao DataModule DmPrincipal.dfm.
/// Fornece acesso a todas as tabelas lookup do sistema.
/// </summary>
public static class DmPrincipalService
{
    public static List<UnidadePenal> GetUnidadesPenal()
    {
        var lista = new List<UnidadePenal>();
        var dt = DatabaseService.ExecuteQuery("SELECT id_up, nome_up, sigla FROM unidade_penal ORDER BY nome_up");
        foreach (DataRow row in dt.Rows)
        {
            lista.Add(new UnidadePenal
            {
                IdUp = ConvertToInt(row["id_up"]),
                NomeUp = ConvertToString(row["nome_up"]),
                Sigla = ConvertToString(row["sigla"])
            });
        }
        return lista;
    }

    public static DataTable GetPavilhoes(int idUp)
    {
        return DatabaseService.ExecuteQuery(
            "SELECT id_pavilhao, pavilhao FROM pavilhao WHERE id_up = @ID_UP ORDER BY pavilhao",
            DatabaseService.CreateParameter("@ID_UP", idUp));
    }

    public static DataTable GetGalerias(int idPavilhao)
    {
        return DatabaseService.ExecuteQuery(
            "SELECT id_galeria, galeria FROM galeria WHERE idpavilhao = @IDP ORDER BY galeria",
            DatabaseService.CreateParameter("@IDP", idPavilhao));
    }

    public static DataTable GetSolarios(int idGaleria)
    {
        return DatabaseService.ExecuteQuery(
            "SELECT id_solario, solario FROM solario WHERE idgaleria = @IDG ORDER BY solario",
            DatabaseService.CreateParameter("@IDG", idGaleria));
    }

    public static DataTable GetCelas(int idSolario)
    {
        return DatabaseService.ExecuteQuery(
            "SELECT id_cela, cela FROM cela WHERE idsolario = @IDS ORDER BY cela",
            DatabaseService.CreateParameter("@IDS", idSolario));
    }

    public static List<LookupItem> GetPavilhoesLookup(int idUp)
    {
        var dt = GetPavilhoes(idUp);
        return dt.Rows.Cast<DataRow>()
            .Select(r => new LookupItem(ConvertToInt(r["id_pavilhao"]), ConvertToString(r["pavilhao"])))
            .ToList();
    }

    public static List<LookupItem> GetGaleriasLookup(int idPavilhao)
    {
        var dt = GetGalerias(idPavilhao);
        return dt.Rows.Cast<DataRow>()
            .Select(r => new LookupItem(ConvertToInt(r["id_galeria"]), ConvertToString(r["galeria"])))
            .ToList();
    }

    public static List<LookupItem> GetSolariosLookup(int idGaleria)
    {
        var dt = GetSolarios(idGaleria);
        return dt.Rows.Cast<DataRow>()
            .Select(r => new LookupItem(ConvertToInt(r["id_solario"]), ConvertToString(r["solario"])))
            .ToList();
    }

    public static DataTable GetCidades()
    {
        return DatabaseService.ExecuteQuery(
            "SELECT id_cidade, cidade || ' - ' || uf AS cidade FROM cidade " +
            "WHERE TRIM(COALESCE(cidade || ' - ' || uf, '')) <> '' ORDER BY cidade || ' - ' || uf");
    }

    public static DataTable getNacionalidades()
    {
        return DatabaseService.ExecuteQuery("SELECT id_nacionalidade, nacionalidade FROM nacionalidade ORDER BY nacionalidade");
    }

    public static DataTable GetRacas()
    {
        return DatabaseService.ExecuteQuery("SELECT id_raca, raca FROM raca ORDER BY raca");
    }

    public static DataTable GetEscolaridades()
    {
        return DatabaseService.ExecuteQuery("SELECT id_escolaridade, escolaridade FROM escolaridade ORDER BY escolaridade");
    }

    public static DataTable GetProfissoes()
    {
        return DatabaseService.ExecuteQuery("SELECT id_profissao, profissao FROM profissao ORDER BY profissao");
    }

    public static DataTable GetProcedencias()
    {
        return DatabaseService.ExecuteQuery(
            "SELECT id_procedencia, proedencia FROM procedencia ORDER BY proedencia");
    }

    public static DataTable GetCondicoesInterno()
    {
        return DatabaseService.ExecuteQuery("SELECT idcondicao_interno, descricao FROM condicao_interno ORDER BY descricao");
    }

    public static DataTable GetFaccoes()
    {
        return DatabaseService.ExecuteQuery("SELECT id_faccao, faccao FROM faccao ORDER BY faccao");
    }

    public static DataTable GetInternos(int idUp)
    {
        return DatabaseService.ExecuteQuery(
            "SELECT id_interno, nome_interno, rgi FROM interno " +
            "WHERE id_up = @ID_UP AND COALESCE(nome_interno, '') <> '' AND st = 'A' ORDER BY nome_interno",
            DatabaseService.CreateParameter("@ID_UP", idUp));
    }

    public static DataTable GetFuncionarios()
    {
        return DatabaseService.ExecuteQuery(
            "SELECT id_funcionario, nome_funcionario FROM funcionario " +
            "WHERE COALESCE(nome_funcionario, '') <> '' ORDER BY nome_funcionario");
    }

    public static DataTable GetAdvogados()
    {
        return DatabaseService.ExecuteQuery("SELECT id_advogado, advogado FROM advogado ORDER BY advogado");
    }

    public static DataTable GetDestinos()
    {
        return DatabaseService.ExecuteQuery("SELECT id_destino, destino FROM destino ORDER BY destino");
    }

    public static DataTable GetFornecedores()
    {
        return DatabaseService.ExecuteQuery("SELECT id_fornecedor, fornecedor FROM fornecedor ORDER BY fornecedor");
    }

    public static DataTable GetGrausParentesco()
    {
        return DatabaseService.ExecuteQuery("SELECT id_grau_parentesco, grau_parentesco FROM grau_parentesco ORDER BY grau_parentesco");
    }

    public static DataTable GetFuncoesFuncionario()
    {
        return DatabaseService.ExecuteQuery("SELECT id_funcao_funcionario, funcao_funcionario FROM funcao_funcionario");
    }

    public static DataTable GetFuncoesInterno()
    {
        return DatabaseService.ExecuteQuery("SELECT id_funcao_interno, funcao_interno FROM funcao_interno ORDER BY funcao_interno");
    }

    public static DataTable GetSetoresTrabalho()
    {
        return DatabaseService.ExecuteQuery("SELECT id_setor_trabalho, setor_trabalho FROM setor_trabalho ORDER BY setor_trabalho");
    }

    public static DataTable GetPaises()
    {
        return DatabaseService.ExecuteQuery("SELECT id_nacionalidade, nacionalidade FROM nacionalidade ORDER BY nacionalidade");
    }

    public static DataTable GetPadrao(int idUp)
    {
        return DatabaseService.ExecuteQuery(
            "SELECT * FROM padrao WHERE cod_up = @ID_UP",
            DatabaseService.CreateParameter("@ID_UP", idUp));
    }

    private static int ConvertToInt(object value)
    {
        if (value == null || value == DBNull.Value) return 0;
        return System.Convert.ToInt32(value);
    }

    private static string ConvertToString(object value)
    {
        if (value == null || value == DBNull.Value) return string.Empty;
        return value.ToString()!.Trim();
    }
}
