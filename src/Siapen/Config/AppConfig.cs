using System;
using System.Collections.Generic;
using System.IO;
using Siapen.Helpers;

namespace Siapen.Config;

/// <summary>
/// Configurações da aplicação - lê do dbxconnections.ini
/// </summary>
public static class AppConfig
{
    public const string AppName = "SIAPEN";
    public const string AppFullName = "Sistema Integrado de Administração Penitenciária";
    public const string OrgaoName = "AGÊNCIA ESTADUAL DE ADMINISTRAÇÃO DO SISTEMA PENITENCIÁRIO";

    // Valores padrão (sobrescritos pelo INI)
    public static string DbServer { get; set; } = "172.23.15.251";
    public static string DbDatabase { get; set; } = "siapentest";
    public static string DbUser { get; set; } = "SYSDBA";
    public static string DbPassword { get; set; } = "masterkey";
    public static string DbDialect { get; set; } = "3";
    public static string DbCharset { get; set; } = "UTF8";
    public static string Local { get; set; } = "DEPEN";
    public static string Nome { get; set; } = "SISTEMA PENITENCIÁRIO DO ESTADO DE MATO GROSSO";
    public static string Orgao { get; set; } = "GOVERNO DO ESTADO DE MATO GROSSO";
    public static string Departamento { get; set; } = "SECRETARIA DE ESTADO DE SEGURANÇA PUBLICA";
    public static string Diretoria { get; set; } = "SECRETARIA ADJUNTA DE ADMINISTRAÇÃO PENITENCIÁRIA";
    public static string Skin { get; set; } = "skin0264.skn";

    private static readonly Dictionary<string, string> _iniValues = new();

    /// <summary>
    /// Carrega as configurações do arquivo dbxconnections.ini
    /// </summary>
    public static void LoadFromIni(string? iniPath = null)
    {
        iniPath ??= Path.Combine(AppContext.BaseDirectory, "Config", "dbxconnections.ini");

        if (!File.Exists(iniPath))
        {
            iniPath = Path.Combine(AppContext.BaseDirectory, "dbxconnections.ini");
        }

        if (!File.Exists(iniPath))
        {
            LogHelper.Warning($"Arquivo dbxconnections.ini não encontrado. Usando valores padrão.", "Config");
            return;
        }

        string currentSection = "";
        foreach (var line in File.ReadAllLines(iniPath))
        {
            var trimmed = line.Trim();
            if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("#")) continue;

            if (trimmed.StartsWith("[") && trimmed.EndsWith("]"))
            {
                currentSection = trimmed[1..^1];
                continue;
            }

            var eqIndex = trimmed.IndexOf('=');
            if (eqIndex < 0) continue;

            var key = trimmed[..eqIndex].Trim();
            var value = trimmed[(eqIndex + 1)..].Trim();
            _iniValues[$"{currentSection}.{key}"] = value;
        }

        if (GetValue("SISAP.Database") is { } db)
        {
            var colonIdx = db.IndexOf(':');
            if (colonIdx >= 0)
            {
                DbServer = db[..colonIdx];
                DbDatabase = db[(colonIdx + 1)..];
            }
        }

        DbUser = GetValue("SISAP.User_Name") ?? DbUser;
        DbPassword = GetValue("SISAP.Password") ?? DbPassword;
        DbDialect = GetValue("SISAP.SQLDialect") ?? DbDialect;

        // O driver Firebird .NET não suporta WIN1252/ISO8859_1.
        // Sempre usar UTF8 independente do que está no INI.
        var iniCharset = GetValue("SISAP.Charset");
        if (!string.IsNullOrEmpty(iniCharset) && iniCharset != "UTF8")
        {
            LogHelper.Warning($"Charset '{iniCharset}' do INI não é suportado pelo driver .NET. Usando UTF8.", "Config");
        }
        DbCharset = "UTF8";
        Local = GetValue("SISAP.LOCAL") ?? Local;
        Nome = GetValue("SISAP.NOME") ?? Nome;
        Orgao = GetValue("SISAP.ORGAO") ?? Orgao;
        Departamento = GetValue("SISAP.DEPARTAMENTO") ?? Departamento;
        Diretoria = GetValue("SISAP.DIRETORIA") ?? Diretoria;
        Skin = GetValue("SISAP.SKIN") ?? Skin;

        LogHelper.Info($"Config carregada: Server={DbServer}, DB={DbDatabase}, User={DbUser}", "Config");
    }

    private static string? GetValue(string key)
    {
        return _iniValues.TryGetValue(key, out var value) ? value : null;
    }

    public static string GetConnectionString()
    {
        return $"Server={DbServer};Database={DbDatabase};User={DbUser};Password={DbPassword};Dialect={DbDialect};Charset={DbCharset};";
    }
}
