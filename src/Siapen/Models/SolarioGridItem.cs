namespace Siapen.Models;

public class SolarioGridItem
{
    public int IdSolario { get; set; }
    public string Solario { get; set; } = "";
    public int IdPavilhao { get; set; }
    public int IdGaleria { get; set; }
    public string DiaVisita { get; set; } = "1";
    public string PeriodoVisita { get; set; } = "M";
    public string PavilhaoNome { get; set; } = "";
    public string GaleriaNome { get; set; } = "";
}
