using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FirebirdSql.Data.FirebirdClient;
using Siapen.Helpers;

namespace Siapen.Services;

/// <summary>
/// Serviço de banco de dados Firebird - equivalente ao DmPrincipal.dfm
/// </summary>
public static class DatabaseService
{
    private static FbConnection? _connection;
    private static string _connectionString = string.Empty;

    /// <summary>
    /// Conexão ativa com o banco de dados
    /// </summary>
    public static FbConnection Connection
    {
        get
        {
            if (_connection == null)
                throw new InvalidOperationException("Conexão não inicializada. Chame Initialize() primeiro.");
            return _connection;
        }
    }

    /// <summary>
    /// Indica se a conexão está ativa
    /// </summary>
    public static bool IsConnected => _connection?.State == ConnectionState.Open;

    /// <summary>
    /// Inicializa a conexão com o banco de dados
    /// </summary>
    public static void Initialize(string server, string database, string user = "SYSDBA", string password = "masterkey", int dialect = 3)
    {
        _connectionString = $"Server={server};Database={database};User={user};Password={password};Dialect={dialect};Charset=UTF8;";
        
        _connection = new FbConnection(_connectionString);
        _connection.Open();
        LogHelper.Info("Conexão Firebird estabelecida com sucesso.", "DB");
    }

    /// <summary>
    /// Inicializa a conexão com string de conexão completa
    /// </summary>
    public static void Initialize(string connectionString)
    {
        _connectionString = connectionString;

        // Garantir Connection Timeout na string (padrão é muito longo)
        if (!_connectionString.Contains("Connection Timeout", StringComparison.OrdinalIgnoreCase) &&
            !_connectionString.Contains("ConnectionTimeout", StringComparison.OrdinalIgnoreCase))
        {
            _connectionString += "Connection Timeout=5;";
        }

        _connection = new FbConnection(_connectionString);
        _connection.Open();
        LogHelper.Info("Conexão Firebird estabelecida com sucesso.", "DB");
    }

    /// <summary>
    /// Fecha a conexão com o banco
    /// </summary>
    public static void Disconnect()
    {
        if (_connection != null && _connection.State == ConnectionState.Open)
        {
            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }
    }

    /// <summary>
    /// Executa uma query SELECT e retorna um DataTable
    /// </summary>
    public static DataTable ExecuteQuery(string sql, params FbParameter[] parameters)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        string sqlShort = sql.Replace("\n", " ").Replace("\r", " ").Substring(0, Math.Min(150, sql.Length));
        string paramSummary = parameters != null && parameters.Length > 0
            ? string.Join(", ", parameters.Select(p => $"{p.ParameterName}={p.Value}"))
            : "(none)";
        LogHelper.Debug($"[DB] Query START: {sqlShort}... | Params: {paramSummary}", "DB");

        using var cmd = new FbCommand(sql, Connection);
        cmd.CommandTimeout = 10; // 10 second timeout to avoid hanging
        if (parameters != null)
            cmd.Parameters.AddRange(parameters);

        var dt = new DataTable();
        using var adapter = new FbDataAdapter(cmd);
        adapter.Fill(dt);
        sw.Stop();
        LogHelper.Debug($"[DB] Query END: {dt.Rows.Count} rows in {sw.ElapsedMilliseconds}ms", "DB");
        return dt;
    }

    /// <summary>
    /// Executa um comando SQL (INSERT, UPDATE, DELETE)
    /// </summary>
    public static int ExecuteNonQuery(string sql, params FbParameter[] parameters)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        string sqlShort = sql.Replace("\n", " ").Replace("\r", " ").Substring(0, Math.Min(150, sql.Length));
        string paramSummary = parameters != null && parameters.Length > 0
            ? string.Join(", ", parameters.Select(p => $"{p.ParameterName}={p.Value}"))
            : "(none)";
        LogHelper.Debug($"[DB] NonQuery START: {sqlShort}... | Params: {paramSummary}", "DB");

        using var cmd = new FbCommand(sql, Connection);
        cmd.CommandTimeout = 10;
        if (parameters != null)
            cmd.Parameters.AddRange(parameters);
        int affected = cmd.ExecuteNonQuery();
        sw.Stop();
        LogHelper.Debug($"[DB] NonQuery END: {affected} rows affected in {sw.ElapsedMilliseconds}ms", "DB");
        return affected;
    }

    /// <summary>
    /// Executa um comando SQL e retorna um valor escalar
    /// </summary>
    public static object? ExecuteScalar(string sql, params FbParameter[] parameters)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        string sqlShort = sql.Replace("\n", " ").Replace("\r", " ").Substring(0, Math.Min(150, sql.Length));
        LogHelper.Debug($"[DB] Scalar START: {sqlShort}...", "DB");

        using var cmd = new FbCommand(sql, Connection);
        cmd.CommandTimeout = 10;
        if (parameters != null)
            cmd.Parameters.AddRange(parameters);
        var result = cmd.ExecuteScalar();
        sw.Stop();
        LogHelper.Debug($"[DB] Scalar END: result={result} in {sw.ElapsedMilliseconds}ms", "DB");
        return result;
    }

    /// <summary>
    /// Executa uma stored procedure ou função do Firebird
    /// </summary>
    public static T? ExecuteFunction<T>(string functionName, params FbParameter[] parameters)
    {
        string sql = $"SELECT {functionName} FROM RDB$DATABASE";
        using var cmd = new FbCommand(sql, Connection);
        cmd.CommandTimeout = 10;
        if (parameters != null)
            cmd.Parameters.AddRange(parameters);
        var result = cmd.ExecuteScalar();
        if (result == null || result == DBNull.Value) return default;
        return (T)Convert.ChangeType(result, typeof(T));
    }

    /// <summary>
    /// Obtém o próximo valor de um generator (sequence) do Firebird
    /// </summary>
    public static int GetGeneratorValue(string generatorName, bool somaUm = true)
    {
        string sql = somaUm
            ? $"SELECT GEN_ID({generatorName}, 1) FROM RDB$DATABASE"
            : $"SELECT GEN_ID({generatorName}, 0) FROM RDB$DATABASE";

        var result = ExecuteScalar(sql);
        return Convert.ToInt32(result);
    }

    /// <summary>
    /// Cria um parâmetro para query
    /// </summary>
    public static FbParameter CreateParameter(string name, object? value)
    {
        return new FbParameter(name, value ?? DBNull.Value);
    }

    /// <summary>
    /// Inicia uma transação
    /// </summary>
    public static FbTransaction BeginTransaction()
    {
        return Connection.BeginTransaction();
    }

    /// <summary>
    /// Retorna lista de unidades penais
    /// </summary>
    public static List<Models.UnidadePenal> GetUnidadesPenal()
    {
        var lista = new List<Models.UnidadePenal>();
        using var cmd = new FbCommand("SELECT ID_UP, NOME_UP FROM UNIDADE_PENAL ORDER BY NOME_UP", Connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new Models.UnidadePenal
            {
                IdUp = reader.GetInt32(0),
                NomeUp = reader.IsDBNull(1) ? string.Empty : reader.GetString(1).Trim()
            });
        }
        return lista;
    }

    /// <summary>
    /// Retorna o ID_UP de um funcionário pelo login
    /// </summary>
    public static int? GetIdUpByLogin(string login)
    {
        using var cmd = new FbCommand(
            "SELECT ID_UP FROM FUNCIONARIO WHERE UPPER(LOGIN) = @LOGIN",
            Connection);
        cmd.Parameters.AddWithValue("@LOGIN", login.ToUpper().Trim());
        var result = cmd.ExecuteScalar();
        if (result == null || result == DBNull.Value) return null;
        return Convert.ToInt32(result);
    }

    /// <summary>
    /// Retorna lista de funcionários por UP
    /// </summary>
    public static DataTable GetFuncionarios(int idUp)
    {
        return ExecuteQuery(
            "SELECT ID_FUNCIONARIO, NOME_FUNCIONARIO, MATRICULA FROM FUNCIONARIO " +
            "WHERE ID_UP = @ID_UP AND COALESCE(NOME_FUNCIONARIO, '') <> '' ORDER BY NOME_FUNCIONARIO",
            CreateParameter("@ID_UP", idUp));
    }

    /// <summary>
    /// Retorna informações de uma cela específica
    /// </summary>
    public static DataRow? GetCelaInfo(int idCela)
    {
        var dt = ExecuteQuery(
            "SELECT id_cela, cela, limite_por_cela, isolamento, em_manutencao, motivo_manutencao FROM cela WHERE id_cela = @id",
            CreateParameter("@id", idCela));
        return dt.Rows.Count > 0 ? dt.Rows[0] : null;
    }

    /// <summary>
    /// Conta quantos internos ativos estão em uma cela
    /// </summary>
    public static int CountInternosNaCela(int idCela, int excludeIdInterno = 0)
    {
        string sql = "SELECT COUNT(*) FROM INTERNO WHERE st = 'A' AND nome_interno IS NOT NULL AND idcela = @idcela";
        if (excludeIdInterno > 0)
            sql += " AND id_interno <> @exclude";

        var paramList = new List<FbParameter> { CreateParameter("@idcela", idCela) };
        if (excludeIdInterno > 0)
            paramList.Add(CreateParameter("@exclude", excludeIdInterno));

        var result = ExecuteScalar(sql, paramList.ToArray());
        return Convert.ToInt32(result);
    }

    /// <summary>
    /// Retorna lista de internos por UP
    /// </summary>
    public static DataTable GetInternos(int idUp)
    {
        return ExecuteQuery(
            "SELECT ID_INTERNO, NOME_INTERNO, RGI FROM INTERNO " +
            "WHERE ID_UP = @ID_UP AND COALESCE(NOME_INTERNO, '') <> '' AND ST = 'A' ORDER BY NOME_INTERNO",
            CreateParameter("@ID_UP", idUp));
    }

    /// <summary>
    /// Retorna lista de pavilhões por UP
    /// </summary>
    public static DataTable GetPavilhoes(int idUp)
    {
        return ExecuteQuery(
            "SELECT ID_PAVILHAO, PAVILHAO FROM PAVILHAO WHERE ID_UP = @ID_UP ORDER BY PAVILHAO",
            CreateParameter("@ID_UP", idUp));
    }

    /// <summary>
    /// Retorna lista de galerias por pavilhão
    /// </summary>
    public static DataTable GetGalerias(int idPavilhao)
    {
        return ExecuteQuery(
            "SELECT ID_GALERIA, GALERIA FROM GALERIA WHERE IDPAVILHAO = @IDPAVILHAO ORDER BY GALERIA",
            CreateParameter("@IDPAVILHAO", idPavilhao));
    }

    /// <summary>
    /// Retorna lista de solários por galeria
    /// </summary>
    public static DataTable GetSolarios(int idGaleria)
    {
        return ExecuteQuery(
            "SELECT ID_SOLARIO, SOLARIO FROM SOLARIO WHERE IDGALERIA = @IDGALERIA ORDER BY SOLARIO",
            CreateParameter("@IDGALERIA", idGaleria));
    }

    /// <summary>
    /// Retorna lista de celas por solário
    /// </summary>
    public static DataTable GetCelas(int idSolario)
    {
        return ExecuteQuery(
            "SELECT ID_CELA, CELA FROM CELA WHERE IDSOLARIO = @IDSOLARIO ORDER BY CELA",
            CreateParameter("@IDSOLARIO", idSolario));
    }
}
