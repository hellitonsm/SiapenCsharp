namespace Siapen.Models;

public class Cidade
{
    public int IdCidade { get; set; }
    public string NomeCidade { get; set; } = string.Empty;
}

public class Nacionalidade
{
    public int IdNacionalidade { get; set; }
    public string NomeNacionalidade { get; set; } = string.Empty;
}

public class Raca
{
    public int IdRaca { get; set; }
    public string NomeRaca { get; set; } = string.Empty;
}

public class Escolaridade
{
    public int IdEscolaridade { get; set; }
    public string NomeEscolaridade { get; set; } = string.Empty;
}

public class Profissao
{
    public int IdProfissao { get; set; }
    public string NomeProfissao { get; set; } = string.Empty;
}

public class Procedencia
{
    public int IdProcedencia { get; set; }
    public string NomeProcedencia { get; set; } = string.Empty;
}

public class CondicaoInterno
{
    public int IdCondicaoInterno { get; set; }
    public string Descricao { get; set; } = string.Empty;
}

public class Faccao
{
    public int IdFaccao { get; set; }
    public string NomeFaccao { get; set; } = string.Empty;
}

public class Pavilhao
{
    public int IdPavilhao { get; set; }
    public string NomePavilhao { get; set; } = string.Empty;
    public int IdUp { get; set; }
}

public class Galeria
{
    public int IdGaleria { get; set; }
    public string NomeGaleria { get; set; } = string.Empty;
    public int IdPavilhao { get; set; }
}

public class Solario
{
    public int IdSolario { get; set; }
    public string NomeSolario { get; set; } = string.Empty;
    public int IdGaleria { get; set; }
}

public class Cela
{
    public int IdCela { get; set; }
    public string NomeCela { get; set; } = string.Empty;
    public int IdSolario { get; set; }
}
