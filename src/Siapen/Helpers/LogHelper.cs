using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace Siapen.Helpers;

/// <summary>
/// Sistema de log - grava erros e informações em arquivo de texto
/// </summary>
public static class LogHelper
{
    private static readonly string _logDirectory;
    private static readonly object _lock = new();
    private static LogLevels _minimumLevel = LogLevels.Debug;

    public enum LogLevels
    {
        Debug = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        Fatal = 4
    }

    static LogHelper()
    {
        _logDirectory = Path.Combine(AppContext.BaseDirectory, "Logs");

        try
        {
            if (!Directory.Exists(_logDirectory))
                Directory.CreateDirectory(_logDirectory);
        }
        catch
        {
            // Se não conseguir criar a pasta, usa o diretório do executável
            _logDirectory = AppContext.BaseDirectory;
        }
    }

    /// <summary>
    /// Nível mínimo de log (abaixo deste nível, a mensagem é ignorada)
    /// </summary>
    public static LogLevels MinimumLevel
    {
        get => _minimumLevel;
        set => _minimumLevel = value;
    }

    /// <summary>
    /// Diretório onde os logs são salvos
    /// </summary>
    public static string LogDirectory => _logDirectory;

    /// <summary>
    /// Caminho do arquivo de log do dia atual
    /// </summary>
    public static string CurrentLogFile => Path.Combine(_logDirectory, $"siapen_{DateTime.Now:yyyy-MM-dd}.log");

    /// <summary>
    /// Log de debug
    /// </summary>
    public static void Debug(string message, string? category = null)
    {
        Write(LogLevels.Debug, message, category);
    }

    /// <summary>
    /// Log de informação
    /// </summary>
    public static void Info(string message, string? category = null)
    {
        Write(LogLevels.Info, message, category);
    }

    /// <summary>
    /// Log de aviso
    /// </summary>
    public static void Warning(string message, string? category = null)
    {
        Write(LogLevels.Warning, message, category);
    }

    /// <summary>
    /// Log de erro
    /// </summary>
    public static void Error(string message, Exception? ex = null, string? category = null)
    {
        var sb = new StringBuilder(message);
        if (ex != null)
        {
            sb.AppendLine();
            sb.AppendLine($"  Exception: {ex.GetType().FullName}");
            sb.AppendLine($"  Message:   {ex.Message}");
            sb.AppendLine($"  Stack:     {ex.StackTrace}");
            if (ex.InnerException != null)
            {
                sb.AppendLine($"  Inner:     {ex.InnerException.GetType().FullName}: {ex.InnerException.Message}");
            }
        }
        Write(LogLevels.Error, sb.ToString(), category);
    }

    /// <summary>
    /// Log de erro fatal
    /// </summary>
    public static void Fatal(string message, Exception? ex = null, string? category = null)
    {
        var sb = new StringBuilder(message);
        if (ex != null)
        {
            sb.AppendLine();
            sb.AppendLine($"  Exception: {ex.GetType().FullName}");
            sb.AppendLine($"  Message:   {ex.Message}");
            sb.AppendLine($"  Stack:     {ex.StackTrace}");
            if (ex.InnerException != null)
            {
                sb.AppendLine($"  Inner:     {ex.InnerException.GetType().FullName}: {ex.InnerException.Message}");
            }
        }
        Write(LogLevels.Fatal, sb.ToString(), category);
    }

    /// <summary>
    /// Log de acesso do usuário
    /// </summary>
    public static void LogAccess(string action, string? details = null)
    {
        var message = $"ACCESS: {action}";
        if (!string.IsNullOrEmpty(details))
            message += $" | {details}";
        Write(LogLevels.Info, message, "ACCESS");
    }

    /// <summary>
    /// Log de query SQL executada
    /// </summary>
    public static void LogSql(string sql, string? category = null)
    {
        Write(LogLevels.Debug, $"SQL: {sql}", category ?? "SQL");
    }

    private static void Write(LogLevels level, string message, string? category)
    {
        if (level < _minimumLevel) return;

        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        var threadId = Thread.CurrentThread.ManagedThreadId;
        var levelStr = level.ToString().ToUpper().PadRight(7);
        var cat = string.IsNullOrEmpty(category) ? "" : $"[{category}] ";

        var line = $"[{timestamp}] [{levelStr}] [T{threadId:D3}] {cat}{message}";

        // Escreve no console (debug)
        System.Diagnostics.Debug.WriteLine(line);

        // Escreve no arquivo
        try
        {
            lock (_lock)
            {
                var logFile = Path.Combine(_logDirectory, $"siapen_{DateTime.Now:yyyy-MM-dd}.log");
                File.AppendAllText(logFile, line + Environment.NewLine, Encoding.UTF8);
            }
        }
        catch
        {
            // Não deixa o log quebrar a aplicação
        }
    }
}
