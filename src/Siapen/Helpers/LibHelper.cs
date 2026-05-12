using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Siapen.Helpers;

/// <summary>
/// Funções utilitárias convertidas do Lib.pas
/// </summary>
public static class LibHelper
{
    /// <summary>
    /// Criptografia/descriptografia de senha (XOR com chave)
    /// </summary>
    public static string Senha(string strValue, ushort chave = 256)
    {
        var sb = new StringBuilder();
        foreach (char c in strValue)
        {
            sb.Append((char)(~(c - chave)));
        }
        return sb.ToString();
    }

    /// <summary>
    /// Retorna string entre aspas simples
    /// </summary>
    public static string Qs(string descricao)
    {
        return $"'{descricao}'";
    }

    /// <summary>
    /// Retorna apenas números de uma string
    /// </summary>
    public static string ApenasNumero(string pStr)
    {
        return new string(pStr.Where(char.IsDigit).ToArray());
    }

    /// <summary>
    /// Formata número com zeros à esquerda
    /// </summary>
    public static string StrZero(object aValue, int aLength, bool vazio = false)
    {
        string str = aValue?.ToString() ?? string.Empty;
        if (string.IsNullOrEmpty(str) && vazio) return string.Empty;
        return str.PadLeft(aLength, '0');
    }

    /// <summary>
    /// Calcula idade a partir da data de nascimento
    /// </summary>
    public static string Idade2(DateTime dataNasc)
    {
        DateTime hoje = DateTime.Today;
        int ano1 = dataNasc.Year, mes1 = dataNasc.Month, dia1 = dataNasc.Day;
        int ano2 = hoje.Year, mes2 = hoje.Month, dia2 = hoje.Day;
        int auxDia1 = dia1, auxDia2 = dia2;

        if (dia1 > dia2 && (mes2 - mes1) == 1)
        {
            dia2 += DiasDoMes(ano1, mes1);
            mes1 = mes2;
        }
        else if (dia1 > dia2 && mes1 != mes2)
        {
            dia2 += DiasDoMes(ano1, mes1);
        }
        else if (mes1 == mes2 && dia1 > dia2 && ano1 != ano2)
        {
            dia2 += DiasDoMes(ano1, mes1);
            mes2 += 11;
            ano1 += 1;
        }

        if (mes1 > mes2 && auxDia1 <= auxDia2)
        {
            ano1 += 1;
            mes2 += 12;
        }
        else if (mes1 > mes2 && auxDia1 > auxDia2)
        {
            ano1 += 1;
            mes2 += 11;
        }

        int ano = ano2 - ano1;
        int mes = mes2 - mes1;
        int dia = dia2 - dia1;

        string idade = string.Empty;

        if (ano > 1)
            idade = $"{ano} Anos";
        else if (ano == 1)
            idade = $"{ano} Ano";

        if (mes > 1)
            idade += $", {mes} Meses";
        else if (mes != 0)
            idade += $", {mes} Mês";

        if (ano == 0 && idade.Length > 0)
            idade = idade.Remove(0, 1);

        if (dia > 1)
            idade += $" e {dia} Dias";
        else if (dia != 0)
            idade += $" e {dia} Dia";

        if (mes == 0 && ano == 0 && idade.Length >= 3)
            idade = idade.Remove(0, 3);

        if (ano1 == ano2 && mes1 == mes2 && dia1 > dia2)
            idade = "0";

        return idade;
    }

    /// <summary>
    /// Verifica se ano é bissexto
    /// </summary>
    public static bool Bissexto(int ano)
    {
        return (ano % 4 == 0) && ((ano % 100 != 0) || (ano % 400 == 0));
    }

    /// <summary>
    /// Retorna quantidade de dias no mês
    /// </summary>
    public static int DiasDoMes(int ano, int mes)
    {
        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        int dias = daysInMonth[mes - 1];
        if (mes == 2 && Bissexto(ano)) dias++;
        return dias;
    }

    /// <summary>
    /// Substitui todas as ocorrências de uma string por outra
    /// </summary>
    public static string BuscaTroca(string text, string busca, string troca)
    {
        if (string.IsNullOrEmpty(busca)) return text;
        return text.Replace(busca, troca);
    }

    /// <summary>
    /// Verifica se string contém valor
    /// </summary>
    public static bool ContemValor(string sCompare, string sString)
    {
        return sString?.Contains(sCompare) ?? false;
    }

    /// <summary>
    /// Valida CPF
    /// </summary>
    public static bool ValidaCpf(string cpf)
    {
        cpf = ApenasNumero(cpf);
        if (cpf.Length != 11) return false;
        if (cpf.Distinct().Count() == 1) return false;

        int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf.Substring(0, 9);
        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * mult1[i];

        int resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;
        if (resto != int.Parse(cpf[9].ToString())) return false;

        tempCpf += cpf[9];
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * mult2[i];

        resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;
        return resto == int.Parse(cpf[10].ToString());
    }

    /// <summary>
    /// Valida CNPJ
    /// </summary>
    public static bool ValidaCnpj(string cnpj)
    {
        cnpj = ApenasNumero(cnpj);
        if (cnpj.Length != 14) return false;
        if (cnpj.Distinct().Count() == 1) return false;

        int[] mult1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] mult2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        int soma = 0;
        for (int i = 0; i < 12; i++)
            soma += int.Parse(cnpj[i].ToString()) * mult1[i];

        int resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;
        if (resto != int.Parse(cnpj[12].ToString())) return false;

        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(cnpj[i].ToString()) * mult2[i];

        resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;
        return resto == int.Parse(cnpj[13].ToString());
    }

    /// <summary>
    /// Valida data no formato dd/mm/yyyy
    /// </summary>
    public static bool ValidaData(string sData)
    {
        return DateTime.TryParseExact(sData, "dd/MM/yyyy",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
    }

    /// <summary>
    /// Remove acentos de uma string
    /// </summary>
    public static string RemoveAcentos(string str)
    {
        if (string.IsNullOrEmpty(str)) return str;

        string comAcentos = "àáâãäåèéêëìíîïòóôõöùúûüýÿñçÀÁÂÃÄÅÈÉÊËÌÍÎÏÒÓÔÕÖÙÚÛÜÝŸÑÇ";
        string semAcentos = "aaaaaaeeeeiiiiooooouuuuyyncAAAAAAAAAEEEEIIIIOOOOOUUUUYYNC";

        var sb = new StringBuilder(str);
        for (int i = 0; i < sb.Length; i++)
        {
            int idx = comAcentos.IndexOf(sb[i]);
            if (idx >= 0) sb[i] = semAcentos[idx];
        }
        return sb.ToString();
    }

    /// <summary>
    /// Substitui múltiplos caracteres em uma string
    /// </summary>
    public static string SiapStringReplace(string sString,
        string old1, string new1,
        string old2 = "", string new2 = "",
        string old3 = "", string new3 = "")
    {
        sString = sString.Replace(old1, new1);
        if (!string.IsNullOrEmpty(old2)) sString = sString.Replace(old2, new2);
        if (!string.IsNullOrEmpty(old3)) sString = sString.Replace(old3, new3);
        return sString;
    }

    /// <summary>
    /// Retorna o último dia do mês
    /// </summary>
    public static DateTime UltimoDiaMes(DateTime data)
    {
        return new DateTime(data.Year, data.Month, DiasDoMes(data.Year, data.Month));
    }

    /// <summary>
    /// Verifica se data é válida e retorna DateTime
    /// </summary>
    public static DateTime InformarData(string sData, string tipo = "Inicial")
    {
        if (DateTime.TryParseExact(sData, "dd/MM/yyyy",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            return result;

        throw new ArgumentException($"Data {tipo} inválida: {sData}");
    }

    /// <summary>
    /// Formata valor monetário
    /// </summary>
    public static string FormataValor(decimal valor)
    {
        return valor.ToString("N2", new CultureInfo("pt-BR"));
    }

    /// <summary>
    /// Converte data para formato Firebird (dd.mm.yyyy)
    /// </summary>
    public static string DataFirebird(DateTime data)
    {
        return data.ToString("dd.MM.yyyy");
    }

    /// <summary>
    /// Calcula dias úteis entre duas datas
    /// </summary>
    public static int DiasUteis(DateTime dataIni, DateTime dataFim, string ignorar = "")
    {
        int dias = 0;
        DateTime data = dataIni;
        while (data <= dataFim)
        {
            if (data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday)
                dias++;
            data = data.AddDays(1);
        }
        return dias;
    }
}
