namespace Siapen.Models;

public class UnidadePenal
{
    public int IdUp { get; set; }
    public string NomeUp { get; set; } = string.Empty;
    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Fone { get; set; }
    public string? Sigla { get; set; }
    public string? Regime { get; set; }
    public string? Genero { get; set; }
    public int QtdeVaga { get; set; }
}
