namespace Siapen.Models;

public class Funcionario
{
    public int IdFuncionario { get; set; }
    public string NomeFuncionario { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public int IdUp { get; set; }
    public string? Foto { get; set; }
}
