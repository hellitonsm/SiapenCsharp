namespace Siapen.Models;

public class CelaGridItem
{
    public int IdCela { get; set; }
    public string Cela { get; set; } = "";
    public int IdPavilhao { get; set; }
    public int IdGaleria { get; set; }
    public int IdSolario { get; set; }
    public string Isolamento { get; set; } = "N";
    public int LimitePorCela { get; set; }
    public string EmManutencao { get; set; } = "N";
    public string MotivoManutencao { get; set; } = "";
    public string PavilhaoNome { get; set; } = "";
    public string GaleriaNome { get; set; } = "";
    public string SolarioNome { get; set; } = "";
}
