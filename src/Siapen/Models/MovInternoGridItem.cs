namespace Siapen.Models;

/// <summary>
/// Grid item for CadastroMovInterno consultation grid.
/// Maps to MOV_INTERNO fields joined with INTERNO.
/// </summary>
public class MovInternoGridItem
{
    public int IdMovInterno { get; set; }
    public int IdInterno { get; set; }
    public string NomeInterno { get; set; } = string.Empty;
    public int IdUnidadePenal { get; set; }
    public string? DataMovimentacao { get; set; }
    public string? HoraMovimentacao { get; set; }
    public string? TipoMovimentacao { get; set; }
    public int? IdFuncionario { get; set; }
    public int? IdProcedencia { get; set; }
    public int? IdDestino { get; set; }
}
