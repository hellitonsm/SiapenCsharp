using System;

namespace Siapen.Helpers;

/// <summary>
/// Variáveis globais do sistema - equivalente às vars do Lib.pas
/// </summary>
public static class GlobalVars
{
    // Identificação do usuário logado
    public static int IdFuncionario { get; set; }
    public static string NomeFuncionarioLogado { get; set; } = string.Empty;
    public static string LoginConectado { get; set; } = string.Empty;
    public static string SenhaUsuario { get; set; } = string.Empty;
    public static string TipoSenha { get; set; } = string.Empty;
    public static int IdUp { get; set; }
    public static string NomeUp { get; set; } = string.Empty;
    public static string UpLogado { get; set; } = string.Empty;
    public static int IdPostoTrabalho { get; set; }
    public static int IdConexao { get; set; }

    // Dados do interno selecionado
    public static int IdInterno { get; set; }
    public static string Rgi { get; set; } = string.Empty;

    // Agenda
    public static int IdAgendaAtendimento { get; set; }
    public static string StatusAgenda { get; set; } = string.Empty;
    public static string StatusFiltroAgenda { get; set; } = string.Empty;

    // Movimentação
    public static int IdTransferenciaInterno { get; set; }
    public static int IdMudancaCela { get; set; }
    public static int IdMovDiarioVisitantes { get; set; }

    // Procedimentos
    public static string ConexaoProced { get; set; } = string.Empty;
    public static string AcessaProced { get; set; } = string.Empty;
    public static string UltimaDataProcedimento { get; set; } = string.Empty;

    // Caminhos
    public static string PatchSistema { get; set; } = string.Empty;
    public static string MeusDocumentos { get; set; } = string.Empty;
    public static string PatchRelatorio { get; set; } = string.Empty;
    public static string Local { get; set; } = string.Empty;
    public static string PastaLocal { get; set; } = string.Empty;
    public static string PastaDf { get; set; } = string.Empty;
    public static string PastaMa { get; set; } = string.Empty;
    public static string PastaMs { get; set; } = string.Empty;
    public static string PastaMt { get; set; } = string.Empty;
    public static string PastaSpf { get; set; } = string.Empty;
    public static string PastaPb { get; set; } = string.Empty;
    public static string CaminhoBiometria { get; set; } = string.Empty;
    public static string TipoCaptura { get; set; } = string.Empty;

    // Órgão
    public static string Orgao { get; set; } = string.Empty;
    public static string Departamento { get; set; } = string.Empty;
    public static string Diretoria { get; set; } = string.Empty;
    public static string PadraoSistema { get; set; } = string.Empty;
    public static string Uf { get; set; } = string.Empty;
    public static string IdVisitante { get; set; } = string.Empty;

    // Sistema
    public static DateTime Data { get; set; } = DateTime.Now;
    public static string Nome { get; set; } = string.Empty;
    public static string NomePerfilUsuarioLogado { get; set; } = string.Empty;
    public static string SkinPadrao { get; set; } = string.Empty;
    public static bool AtivouSkin { get; set; } = false;
    public static bool MostrarBotaoIncluir { get; set; } = false;
    public static bool FechaAgendaAtendimento { get; set; } = false;
    public static bool EditandoSeusDadosUsuario { get; set; } = false;

    // Cores
    public static string CorCompInativo { get; set; } = "#FFF0F0F0";
    public static string CorCompAtivo { get; set; } = "#FFFFFFFF";

    // Permissões estilo "CEDIR"
    public static string PermissaoConfere { get; set; } = string.Empty;
    public static string PermissaoVisitante { get; set; } = string.Empty;
    public static string PermissaoTrabalho { get; set; } = string.Empty;
    public static string PermissaoCadastro { get; set; } = string.Empty;
    public static string PermissaoEducacao { get; set; } = string.Empty;
    public static string PermissaoPsicossocial { get; set; } = string.Empty;
    public static string PermissaoJuridica { get; set; } = string.Empty;
    public static string PermissaoDisciplina { get; set; } = string.Empty;
    public static string PermissaoInteligencia { get; set; } = string.Empty;
    public static string PermissaoEnfermagem { get; set; } = string.Empty;
    public static string PermissaoFarmacia { get; set; } = string.Empty;
    public static string PermissaoClinicaMedica { get; set; } = string.Empty;
    public static string PermissaoPsicologia { get; set; } = string.Empty;
    public static string PermissaoPsiquiatria { get; set; } = string.Empty;
    public static string PermissaoSaude { get; set; } = string.Empty;
    public static string PermissaoTerapiaOcupacional { get; set; } = string.Empty;
    public static string PermissaoOdontologia { get; set; } = string.Empty;
    public static string PermissaoPedagogia { get; set; } = string.Empty;
    public static string PermissaoServicoSocial { get; set; } = string.Empty;
    public static string PermissaoArmas { get; set; } = string.Empty;
    public static string PermissaoMonitoramento { get; set; } = string.Empty;
    public static string PermissaoOcorrencia { get; set; } = string.Empty;
    public static string PermissaoConselhoDisciplinar { get; set; } = string.Empty;
    public static string PermissaoTransferenciaInterno { get; set; } = string.Empty;
    public static string PermissaoMudancaCela { get; set; } = string.Empty;
    public static string PermissaoSaidao { get; set; } = string.Empty;
    public static string PermissaoSaidaoCadastro { get; set; } = string.Empty;
    public static string PermissaoCirculacaoInterno { get; set; } = string.Empty;
    public static string PermissaoMovimentoSemiAberto { get; set; } = string.Empty;
    public static string PermissaoFuncionario { get; set; } = string.Empty;
    public static string PermissaoFuncaoFuncionario { get; set; } = string.Empty;
    public static string PermissaoUnidadePenal { get; set; } = string.Empty;
    public static string PermissaoHorarioFuncionario { get; set; } = string.Empty;
    public static string PermissaoPadraoSistema { get; set; } = string.Empty;
    public static string PermissaoEquipe { get; set; } = string.Empty;
    public static string PermissaoLocalPostoTrabalho { get; set; } = string.Empty;
    public static string PermissaoAgentePorEquipe { get; set; } = string.Empty;
    public static string PermissaoRegraVisitação { get; set; } = string.Empty;
    public static string PermissaoPerfilUsuario { get; set; } = string.Empty;
    public static string PermissaoAdvogado { get; set; } = string.Empty;
    public static string PermissaoVisitanteTrafico { get; set; } = string.Empty;
    public static string PermissaoFaccao { get; set; } = string.Empty;
    public static string PermissaoCtc { get; set; } = string.Empty;
    public static string PermissaoCorrespondencia { get; set; } = string.Empty;
    public static string PermissaoAgendaAtendimento { get; set; } = string.Empty;
    public static string PermissaoLivroRevista { get; set; } = string.Empty;
    public static string PermissaoPavilhao { get; set; } = string.Empty;
    public static string PermissaoGaleria { get; set; } = string.Empty;
    public static string PermissaoSolario { get; set; } = string.Empty;
    public static string PermissaoCela { get; set; } = string.Empty;
    public static string PermissaoCondicaoInterno { get; set; } = string.Empty;
    public static string PermissaoCidade { get; set; } = string.Empty;
    public static string PermissaoRaca { get; set; } = string.Empty;
    public static string PermissaoEscolaridade { get; set; } = string.Empty;
    public static string PermissaoNacionalidade { get; set; } = string.Empty;
    public static string PermissaoProcedencia { get; set; } = string.Empty;
    public static string PermissaoDestino { get; set; } = string.Empty;
    public static string PermissaoFornecedor { get; set; } = string.Empty;
    public static string PermissaoProfissao { get; set; } = string.Empty;
    public static string PermissaoFaltaDisciplinar { get; set; } = string.Empty;
    public static string PermissaoSerieFaseEstudo { get; set; } = string.Empty;
    public static string PermissaoProcessoCondenacao { get; set; } = string.Empty;
    public static string PermissaoDetracao { get; set; } = string.Empty;
    public static string PermissaoInterrupcao { get; set; } = string.Empty;
    public static string PermissaoRemicao { get; set; } = string.Empty;
    public static string PermissaoArtigoPenal { get; set; } = string.Empty;
    public static string PermissaoVaraExecucao { get; set; } = string.Empty;
    public static string PermissaoRemedio { get; set; } = string.Empty;
    public static string PermissaoFuncaoInterno { get; set; } = string.Empty;
    public static string PermissaoCalculoTrabalho { get; set; } = string.Empty;
    public static string PermissaoRemicaoTrabalho { get; set; } = string.Empty;
    public static string PermissaoRoupas { get; set; } = string.Empty;
    public static string PermissaoGrauParentesco { get; set; } = string.Empty;
    public static string PermissaoTipoContato { get; set; } = string.Empty;
    public static string PermissaoAssunto { get; set; } = string.Empty;
    public static string PermissaoSituacao { get; set; } = string.Empty;
    public static string PermissaoSetorTrabalhoCad { get; set; } = string.Empty;
    public static string PermissaoEventos { get; set; } = string.Empty;
    public static string PermissaoSubEventos { get; set; } = string.Empty;
    public static string PermissaoMonitoramentoEventos { get; set; } = string.Empty;
    public static string PermissaoPainel { get; set; } = string.Empty;
    public static string PermissaoEntradaVisitante { get; set; } = string.Empty;

    // Permissões estilo SIM/NÃO
    public static string Configuracao { get; set; } = string.Empty;
    public static string VisualizaOutrasUp { get; set; } = string.Empty;
    public static string DefinePerfilUsuario { get; set; } = string.Empty;
    public static string ConcedePermissaoIndividual { get; set; } = string.Empty;

    // Constantes SQL
    public const string SelectPavilhao = @"
        SELECT pavilhao.id_pavilhao, pavilhao.pavilhao, pavilhao.id_up, unidade_penal.nome_up
        FROM unidade_penal
        INNER JOIN pavilhao ON (unidade_penal.id_up = pavilhao.id_up)";

    public const string SelectGaleria = @"
        SELECT galeria.id_galeria, galeria.galeria, pavilhao.id_pavilhao,
               pavilhao.pavilhao, pavilhao.id_up, unidade_penal.nome_up
        FROM unidade_penal
        INNER JOIN pavilhao ON (unidade_penal.id_up = pavilhao.id_up)
        INNER JOIN galeria ON (pavilhao.id_pavilhao = galeria.idpavilhao)";

    public const string SelectSolario = @"
        SELECT solario.solario, solario.id_solario, galeria.id_galeria,
               galeria.galeria, pavilhao.id_pavilhao, pavilhao.pavilhao,
               pavilhao.id_up, unidade_penal.nome_up
        FROM unidade_penal
        INNER JOIN pavilhao ON (unidade_penal.id_up = pavilhao.id_up)
        INNER JOIN galeria ON (pavilhao.id_pavilhao = galeria.idpavilhao)
        INNER JOIN solario ON (galeria.id_galeria = solario.idgaleria)";

    public const string SelectCela = @"
        SELECT cela.id_cela, cela.cela, solario.solario, solario.id_solario,
               galeria.id_galeria, galeria.galeria, pavilhao.id_pavilhao,
               pavilhao.pavilhao, pavilhao.id_up, unidade_penal.nome_up
        FROM unidade_penal
        INNER JOIN pavilhao ON (unidade_penal.id_up = pavilhao.id_up)
        INNER JOIN galeria ON (pavilhao.id_pavilhao = galeria.idpavilhao)
        INNER JOIN solario ON (galeria.id_galeria = solario.idgaleria)
        INNER JOIN cela ON (solario.id_solario = cela.idsolario)";

    // Cores hexadecimais
    public static readonly string[] CoresHexa = {
        "FFFFFF", "000000", "FF0000", "00FFFF", "0000FF", "00FF00",
        "007FFF", "871F78", "4D4DFF", "FFFF00", "C0C0C0", "7F00FF",
        "00009C", "2F4F2F", "238E23", "70DB93", "5C3317", "A62A2A",
        "A67D3D", "42426F", "4F4F2F", "6B238E", "2F4F4F", "7093DB",
        "D19275", "9F9F5F", "E9C2A6", "32CD32", "32CD99", "6B8E23",
        "EAEAAE", "9370DB", "70DBDB", "DB7093", "2F2F4F", "23238E",
        "CFB53B", "8FBC8F", "BC8F8F", "D9D9F3", "5959AB", "238E68",
        "8E6B23", "3299CC", "236B8E", "DB9370", "ADEAEA", "4F2F4F", "D8D8BF"
    };

    // Códigos de erro
    public const int ErrCantOpenBd = -999;
    public const int ErrInvalidId = -998;
    public const int ErrInvalidTemplate = -997;
}
