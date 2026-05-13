using System;

namespace Siapen.Models;

public class Interno
{
    public int IdInterno { get; set; }
    public string NomeInterno { get; set; } = string.Empty;
    public string? Rgi { get; set; }
    public string? NumeroInfopen { get; set; }
    public string? OutroNome { get; set; }
    public string? Vulgo { get; set; }
    public string? NomeSocial { get; set; }
    public string? OrientacaoSexual { get; set; }
    public string? St { get; set; }
    public string? Reincersao { get; set; }
    public string? Sexo { get; set; }
    public int IdUp { get; set; }
    public int? IdProcedencia { get; set; }
    public int? IdCondicaoInterno { get; set; }
    public int? IdFaccao { get; set; }
    public DateTime? DataEntrada { get; set; }
    public DateTime? dataPrisao { get; set; }
    public DateTime? DataPermanencia { get; set; }
    public string? Ci { get; set; }
    public string? TipoRegime { get; set; }
    public string? RegimeAtual { get; set; }
    public string? GrauPericulosidade { get; set; }
    public int? TempoConsolidadoAno { get; set; }
    public int? TempoConsolidadoMes { get; set; }
    public int? TempoConsolidadoDia { get; set; }
    public string? Foto { get; set; }

    public string? Mae { get; set; }
    public string? Pai { get; set; }
    public int? IdNaturalidade { get; set; }
    public int? IdNacionalidade { get; set; }
    public int? IdRaca { get; set; }
    public int? IdEscolaridade { get; set; }
    public int? IdProfissao { get; set; }
    public string? Religiao { get; set; }
    public string? Rg { get; set; }
    public string? Cpf { get; set; }
    public string? EstadoCivil { get; set; }
    public decimal? Altura { get; set; }
    public decimal? Peso { get; set; }
    public DateTime? DataNascimento { get; set; }
    public string? CorOlhos { get; set; }
    public string? CorCabelos { get; set; }

    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string? Complemento { get; set; }
    public string? Cep { get; set; }
    public int? IdCidade { get; set; }
    public int? IdPaisEndereco { get; set; }
    public string? Fone { get; set; }
    public string? Contato { get; set; }
}
