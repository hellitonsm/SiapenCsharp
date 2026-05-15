namespace Siapen.Models;

/// <summary>
/// Grid item for MovimentoInternos consultation grid.
/// Maps to the CdsConsulta fields from the Delphi source.
/// </summary>
public class MovimentoInternosGridItem
{
    public int IdInterno { get; set; }
    public int IdUp { get; set; }
    public string NomeInterno { get; set; } = string.Empty;
    public string NomeFonetica { get; set; } = string.Empty;
    public string Sigla { get; set; } = string.Empty;
    public string Pavilhao { get; set; } = string.Empty;
    public string Solario { get; set; } = string.Empty;
    public string Cela { get; set; } = string.Empty;
    public string Status { get; set; } = "A";
    public string St { get; set; } = "A";
    public string EmTransito { get; set; } = "N";
    public int IdPavilhao { get; set; }
    public int IdGaleria { get; set; }
    public int IdSolario { get; set; }
    public string NumeroRoupa { get; set; } = string.Empty;
}
