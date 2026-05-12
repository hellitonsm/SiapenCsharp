using System;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using Siapen.Services;

namespace Siapen.Helpers;

/// <summary>
/// Funções de autenticação e login - convertidas do Lib.pas e Login.dfm
/// </summary>
public static class AuthHelper
{
    /// <summary>
    /// Tenta fazer login no sistema
    /// </summary>
    public static bool Login(string login, string senha, int idUp)
    {
        try
        {
            LogHelper.Info($"Tentativa de login: login='{login}', idUp={idUp}", "AUTH");

            // Verificar se a conexão está ativa
            if (!DatabaseService.IsConnected)
            {
                LogHelper.Error("Login falhou: conexão com banco não está ativa.", null, "AUTH");
                return false;
            }

            // Criptografar a senha usando a mesma função do sistema original (Lib.pas)
            string senhaCriptografada = LibHelper.Senha(senha);
            LogHelper.Debug($"Senha criptografada (length={senhaCriptografada.Length})", "AUTH");

            // Ler a senha cifrada como bytes brutos para evitar problemas de charset.
            // O driver .NET com UTF8 converte chars >127 para 2 bytes, quebrando a comparação.
            // Precisamos ler os bytes brutos do banco e comparar com os bytes da senha cifrada.
            byte[] senhaCifradaBytes = System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(senhaCriptografada);
            LogHelper.Debug($"Senha cifrada bytes: {BitConverter.ToString(senhaCifradaBytes)}", "AUTH");

            string sql = @"
                SELECT ID_FUNCIONARIO, NOME_FUNCIONARIO, LOGIN,
                       CAST(SENHA AS BLOB SUB_TYPE BINARY) AS SENHA_BINARY, ID_UP,
                       PERMISSAO_CONFERE, PERMISSAO_VISITANTE, PERMISSAO_SETORTRABALHO,
                       PERMISSAO_SETOREDUCACAO, PERMISSAO_PSICOSSOCIAL, PERMISSAO_JURIDICA,
                       PERMISSAO_DISCIPLINA, PERMISSAO_CLINICAMEDICA, PERMISSAO_ENFERMAGEM,
                       PERMISSAO_FARMACIA, PERMISSAO_PSIQUIATRIA, PERMISSAO_SERVICOSOCIAL,
                       PERMISSAO_TERAPIAOCUPACIONAL, PERMISSAO_ODONTOLOGIA, PERMISSAO_PEDAGOGIA,
                       PERMISSAO_PSICOLOGIA, PERMISSAO_SAUDE, PERMISSAO_ARMAS,
                       PERMISSAO_MONITORAMENTO, PERMISSAO_OCORRENCIA, PERMISSAO_INTELIGENCIA,
                       PERMISSAO_CONSELHODISCIPLINAR, PERMISSAO_TRANSFERENCIAINTERNO,
                       PERMISSAO_MUDANCACELA, PERMISSAO_SAIDAO, PERMISSAO_SAIDAO_CADASTRO,
                       PERMISSAO_CIRCULACAOINTERNO, PERMISSAO_MOVIMENTOSEMIABERTO,
                       PERMISSAO_FUNCIONARIO, PERMISSAO_FUNCAOFUNCIONARIO, PERMISSAO_UNIDADEPENAL,
                       PERMISSAO_HORARIOFUNCIONARIO, PERMISSAO_PADRAOSISTEMA, PERMISSAO_EQUIPE,
                       PERMISSAO_LOCALPOSTOTRABALHO, PERMISSAO_AGENTEPOREQUIPE, PERMISSAO_REGRAVISITACAO,
                       PERMISSAO_PERFILUSUARIO, PERMISSAO_ADVOGADO, PERMISSAO_VISITANTETRAFICO,
                       PERMISSAO_FACCAO, PERMISSAO_CTC, PERMISSAO_CORRESPONDENCIA,
                       PERMISSAO_AGENDAATENDIMENTO, PERMISSAO_LIVROREVISTA, PERMISSAO_PAVILHAO,
                       PERMISSAO_GALERIA, PERMISSAO_SOLARIO, PERMISSAO_CELA,
                       PERMISSAO_CONDICAOINTERNO, PERMISSAO_CIDADE, PERMISSAO_RACA,
                       PERMISSAO_ESCOLARIDADE, PERMISSAO_NACIONALIDADE, PERMISSAO_PROCEDENCIA,
                       PERMISSAO_DESTINO, PERMISSAO_FORNECEDOR, PERMISSAO_PROFISSAO,
                       PERMISSAO_FALTADISCIPLINAR, PERMISSAO_SERIEFASEESTUDO,
                       PERMISSAO_PROCESSOCONDENACAO, PERMISSAO_DETRACAO, PERMISSAO_INTERRUPCAO,
                       PERMISSAO_REMICAO, PERMISSAO_ARTIGOPENAL, PERMISSAO_VARAEXECUCAO,
                       PERMISSAO_REMEDIO, PERMISSAO_FUNCAOINTERNO, PERMISSAO_CALCULOTRABALHO,
                       PERMISSAO_REMICAOTRABALHO, PERMISSAO_ROUPAS, PERMISSAO_GRAUPARENTESCO,
                       PERMISSAO_TIPOCONTATO, PERMISSAO_ASSUNTO, PERMISSAO_SITUACAO,
                       PERMISSAO_SETORTRABALHOCAD, PERMISSAO_EVENTOS, PERMISSAO_SUBEVENTOS,
                       PERMISSAO_MONITORAMENTOEVENTOS, PERMISSAO_PAINEL,
                       PERMISSAO_ENTRADAVISITANTE, DEFINE_PERFIL_USUARIO,
                       CONCEDE_PERMISSAO_INDIVIDUAL, CONFIGURACOES, VISUALIZA_OUTRAS_UP,
                       IDPOSTO_TRABALHO
                FROM FUNCIONARIO
                WHERE UPPER(LOGIN) = @LOGIN AND ID_UP = @ID_UP";

            using var cmd = new FbCommand(sql, DatabaseService.Connection);
            cmd.Parameters.AddWithValue("@LOGIN", login.ToUpper());
            cmd.Parameters.AddWithValue("@ID_UP", idUp);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Ler o campo SENHA como bytes brutos via CAST para BLOB.
                // O driver com UTF8 converte chars >127 para 2 bytes, quebrando a comparação.
                // CAST(SENHA AS BLOB SUB_TYPE BINARY) retorna os bytes brutos sem conversão.
                int senhaOrdinal = reader.GetOrdinal("SENHA_BINARY");
                byte[] senhaBancoBytes = reader.GetValue(senhaOrdinal) as byte[]
                    ?? throw new InvalidOperationException("SENHA_BINARY retornou null ou não é byte[]");

                // Converter bytes brutos usando ISO-8859-1 (mapping 1:1 byte→char)
                string senhaBancoISO = System.Text.Encoding.GetEncoding("ISO-8859-1").GetString(senhaBancoBytes).Trim();

                LogHelper.Debug($"Senha banco bytes: {BitConverter.ToString(senhaBancoBytes)}", "AUTH");
                LogHelper.Debug($"Senha banco ISO-8859-1 (trim): '{senhaBancoISO}'", "AUTH");

                // Comparar usando Ordinal para evitar qualquer diferença de cultura
                if (string.Compare(senhaBancoISO, senhaCriptografada, StringComparison.Ordinal) != 0)
                {
                    LogHelper.Warning($"Login falhou: login='{login}', idUp={idUp} — senha não confere.", "AUTH");
                    LogHelper.Debug($"Esperado (ISO-8859-1): '{senhaCriptografada}' bytes={BitConverter.ToString(senhaCifradaBytes)}", "AUTH");
                    LogHelper.Debug($"Obtido   (ISO-8859-1): '{senhaBancoISO}' bytes={BitConverter.ToString(senhaBancoBytes)}", "AUTH");
                    return false;
                }

                GlobalVars.IdFuncionario = reader.GetInt32(reader.GetOrdinal("ID_FUNCIONARIO"));
                GlobalVars.NomeFuncionarioLogado = GetStringSafe(reader, "NOME_FUNCIONARIO");
                GlobalVars.LoginConectado = GetStringSafe(reader, "LOGIN");
                GlobalVars.IdUp = reader.GetInt32(reader.GetOrdinal("ID_UP"));
                GlobalVars.IdPostoTrabalho = reader.GetInt32(reader.GetOrdinal("IDPOSTO_TRABALHO"));

                LoadPermissions(reader);

                LogHelper.Info($"Login OK: funcionario='{GlobalVars.NomeFuncionarioLogado}' (ID={GlobalVars.IdFuncionario})", "AUTH");
                LogHelper.LogAccess("LOGIN", $"login='{login}', idUp={idUp}, nome='{GlobalVars.NomeFuncionarioLogado}'");

                return true;
            }

            LogHelper.Warning($"Login falhou: login='{login}', idUp={idUp} — registro não encontrado.", "AUTH");
            return false;
        }
        catch (Exception ex)
        {
            LogHelper.Error($"Erro no login: login='{login}', idUp={idUp}", ex, "AUTH");
            throw;
        }
    }

    /// <summary>
    /// Carrega todas as permissões do usuário
    /// </summary>
    private static void LoadPermissions(FbDataReader reader)
    {
        GlobalVars.PermissaoConfere = GetStringSafe(reader, "PERMISSAO_CONFERE");
        GlobalVars.PermissaoVisitante = GetStringSafe(reader, "PERMISSAO_VISITANTE");
        GlobalVars.PermissaoTrabalho = GetStringSafe(reader, "PERMISSAO_SETORTRABALHO");
        GlobalVars.PermissaoEducacao = GetStringSafe(reader, "PERMISSAO_SETOREDUCACAO");
        GlobalVars.PermissaoPsicossocial = GetStringSafe(reader, "PERMISSAO_PSICOSSOCIAL");
        GlobalVars.PermissaoJuridica = GetStringSafe(reader, "PERMISSAO_JURIDICA");
        GlobalVars.PermissaoDisciplina = GetStringSafe(reader, "PERMISSAO_DISCIPLINA");
        GlobalVars.PermissaoClinicaMedica = GetStringSafe(reader, "PERMISSAO_CLINICAMEDICA");
        GlobalVars.PermissaoEnfermagem = GetStringSafe(reader, "PERMISSAO_ENFERMAGEM");
        GlobalVars.PermissaoFarmacia = GetStringSafe(reader, "PERMISSAO_FARMACIA");
        GlobalVars.PermissaoPsiquiatria = GetStringSafe(reader, "PERMISSAO_PSIQUIATRIA");
        GlobalVars.PermissaoServicoSocial = GetStringSafe(reader, "PERMISSAO_SERVICOSOCIAL");
        GlobalVars.PermissaoTerapiaOcupacional = GetStringSafe(reader, "PERMISSAO_TERAPIAOCUPACIONAL");
        GlobalVars.PermissaoOdontologia = GetStringSafe(reader, "PERMISSAO_ODONTOLOGIA");
        GlobalVars.PermissaoPedagogia = GetStringSafe(reader, "PERMISSAO_PEDAGOGIA");
        GlobalVars.PermissaoPsicologia = GetStringSafe(reader, "PERMISSAO_PSICOLOGIA");
        GlobalVars.PermissaoSaude = GetStringSafe(reader, "PERMISSAO_SAUDE");
        GlobalVars.PermissaoArmas = GetStringSafe(reader, "PERMISSAO_ARMAS");
        GlobalVars.PermissaoMonitoramento = GetStringSafe(reader, "PERMISSAO_MONITORAMENTO");
        GlobalVars.PermissaoOcorrencia = GetStringSafe(reader, "PERMISSAO_OCORRENCIA");
        GlobalVars.PermissaoInteligencia = GetStringSafe(reader, "PERMISSAO_INTELIGENCIA");
        GlobalVars.PermissaoConselhoDisciplinar = GetStringSafe(reader, "PERMISSAO_CONSELHODISCIPLINAR");
        GlobalVars.PermissaoTransferenciaInterno = GetStringSafe(reader, "PERMISSAO_TRANSFERENCIAINTERNO");
        GlobalVars.PermissaoMudancaCela = GetStringSafe(reader, "PERMISSAO_MUDANCACELA");
        GlobalVars.PermissaoSaidao = GetStringSafe(reader, "PERMISSAO_SAIDAO");
        GlobalVars.PermissaoSaidaoCadastro = GetStringSafe(reader, "PERMISSAO_SAIDAO_CADASTRO");
        GlobalVars.PermissaoCirculacaoInterno = GetStringSafe(reader, "PERMISSAO_CIRCULACAOINTERNO");
        GlobalVars.PermissaoMovimentoSemiAberto = GetStringSafe(reader, "PERMISSAO_MOVIMENTOSEMIABERTO");
        GlobalVars.PermissaoFuncionario = GetStringSafe(reader, "PERMISSAO_FUNCIONARIO");
        GlobalVars.PermissaoFuncaoFuncionario = GetStringSafe(reader, "PERMISSAO_FUNCAOFUNCIONARIO");
        GlobalVars.PermissaoUnidadePenal = GetStringSafe(reader, "PERMISSAO_UNIDADEPENAL");
        GlobalVars.PermissaoHorarioFuncionario = GetStringSafe(reader, "PERMISSAO_HORARIOFUNCIONARIO");
        GlobalVars.PermissaoPadraoSistema = GetStringSafe(reader, "PERMISSAO_PADRAOSISTEMA");
        GlobalVars.PermissaoEquipe = GetStringSafe(reader, "PERMISSAO_EQUIPE");
        GlobalVars.PermissaoLocalPostoTrabalho = GetStringSafe(reader, "PERMISSAO_LOCALPOSTOTRABALHO");
        GlobalVars.PermissaoAgentePorEquipe = GetStringSafe(reader, "PERMISSAO_AGENTEPOREQUIPE");
        GlobalVars.PermissaoRegraVisitação = GetStringSafe(reader, "PERMISSAO_REGRAVISITACAO");
        GlobalVars.PermissaoPerfilUsuario = GetStringSafe(reader, "PERMISSAO_PERFILUSUARIO");
        GlobalVars.PermissaoAdvogado = GetStringSafe(reader, "PERMISSAO_ADVOGADO");
        GlobalVars.PermissaoVisitanteTrafico = GetStringSafe(reader, "PERMISSAO_VISITANTETRAFICO");
        GlobalVars.PermissaoFaccao = GetStringSafe(reader, "PERMISSAO_FACCAO");
        GlobalVars.PermissaoCtc = GetStringSafe(reader, "PERMISSAO_CTC");
        GlobalVars.PermissaoCorrespondencia = GetStringSafe(reader, "PERMISSAO_CORRESPONDENCIA");
        GlobalVars.PermissaoAgendaAtendimento = GetStringSafe(reader, "PERMISSAO_AGENDAATENDIMENTO");
        GlobalVars.PermissaoLivroRevista = GetStringSafe(reader, "PERMISSAO_LIVROREVISTA");
        GlobalVars.PermissaoPavilhao = GetStringSafe(reader, "PERMISSAO_PAVILHAO");
        GlobalVars.PermissaoGaleria = GetStringSafe(reader, "PERMISSAO_GALERIA");
        GlobalVars.PermissaoSolario = GetStringSafe(reader, "PERMISSAO_SOLARIO");
        GlobalVars.PermissaoCela = GetStringSafe(reader, "PERMISSAO_CELA");
        GlobalVars.PermissaoCondicaoInterno = GetStringSafe(reader, "PERMISSAO_CONDICAOINTERNO");
        GlobalVars.PermissaoCidade = GetStringSafe(reader, "PERMISSAO_CIDADE");
        GlobalVars.PermissaoRaca = GetStringSafe(reader, "PERMISSAO_RACA");
        GlobalVars.PermissaoEscolaridade = GetStringSafe(reader, "PERMISSAO_ESCOLARIDADE");
        GlobalVars.PermissaoNacionalidade = GetStringSafe(reader, "PERMISSAO_NACIONALIDADE");
        GlobalVars.PermissaoProcedencia = GetStringSafe(reader, "PERMISSAO_PROCEDENCIA");
        GlobalVars.PermissaoDestino = GetStringSafe(reader, "PERMISSAO_DESTINO");
        GlobalVars.PermissaoFornecedor = GetStringSafe(reader, "PERMISSAO_FORNECEDOR");
        GlobalVars.PermissaoProfissao = GetStringSafe(reader, "PERMISSAO_PROFISSAO");
        GlobalVars.PermissaoFaltaDisciplinar = GetStringSafe(reader, "PERMISSAO_FALTADISCIPLINAR");
        GlobalVars.PermissaoSerieFaseEstudo = GetStringSafe(reader, "PERMISSAO_SERIEFASEESTUDO");
        GlobalVars.PermissaoProcessoCondenacao = GetStringSafe(reader, "PERMISSAO_PROCESSOCONDENACAO");
        GlobalVars.PermissaoDetracao = GetStringSafe(reader, "PERMISSAO_DETRACAO");
        GlobalVars.PermissaoInterrupcao = GetStringSafe(reader, "PERMISSAO_INTERRUPCAO");
        GlobalVars.PermissaoRemicao = GetStringSafe(reader, "PERMISSAO_REMICAO");
        GlobalVars.PermissaoArtigoPenal = GetStringSafe(reader, "PERMISSAO_ARTIGOPENAL");
        GlobalVars.PermissaoVaraExecucao = GetStringSafe(reader, "PERMISSAO_VARAEXECUCAO");
        GlobalVars.PermissaoRemedio = GetStringSafe(reader, "PERMISSAO_REMEDIO");
        GlobalVars.PermissaoFuncaoInterno = GetStringSafe(reader, "PERMISSAO_FUNCAOINTERNO");
        GlobalVars.PermissaoCalculoTrabalho = GetStringSafe(reader, "PERMISSAO_CALCULOTRABALHO");
        GlobalVars.PermissaoRemicaoTrabalho = GetStringSafe(reader, "PERMISSAO_REMICAOTRABALHO");
        GlobalVars.PermissaoRoupas = GetStringSafe(reader, "PERMISSAO_ROUPAS");
        GlobalVars.PermissaoGrauParentesco = GetStringSafe(reader, "PERMISSAO_GRAUPARENTESCO");
        GlobalVars.PermissaoTipoContato = GetStringSafe(reader, "PERMISSAO_TIPOCONTATO");
        GlobalVars.PermissaoAssunto = GetStringSafe(reader, "PERMISSAO_ASSUNTO");
        GlobalVars.PermissaoSituacao = GetStringSafe(reader, "PERMISSAO_SITUACAO");
        GlobalVars.PermissaoSetorTrabalhoCad = GetStringSafe(reader, "PERMISSAO_SETORTRABALHOCAD");
        GlobalVars.PermissaoEventos = GetStringSafe(reader, "PERMISSAO_EVENTOS");
        GlobalVars.PermissaoSubEventos = GetStringSafe(reader, "PERMISSAO_SUBEVENTOS");
        GlobalVars.PermissaoMonitoramentoEventos = GetStringSafe(reader, "PERMISSAO_MONITORAMENTOEVENTOS");
        GlobalVars.PermissaoPainel = GetStringSafe(reader, "PERMISSAO_PAINEL");
        GlobalVars.PermissaoEntradaVisitante = GetStringSafe(reader, "PERMISSAO_ENTRADAVISITANTE");
        GlobalVars.DefinePerfilUsuario = GetStringSafe(reader, "DEFINE_PERFIL_USUARIO");
        GlobalVars.ConcedePermissaoIndividual = GetStringSafe(reader, "CONCEDE_PERMISSAO_INDIVIDUAL");
        GlobalVars.Configuracao = GetStringSafe(reader, "CONFIGURACOES");
        GlobalVars.VisualizaOutrasUp = GetStringSafe(reader, "VISUALIZA_OUTRAS_UP");
    }

    private static string GetStringSafe(FbDataReader reader, string fieldName)
    {
        try
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.IsDBNull(ordinal) ? string.Empty : reader.GetString(ordinal).Trim();
        }
        catch
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// Verifica se o usuário tem permissão para uma determinada ação
    /// </summary>
    public static bool TemPermissao(string permissao)
    {
        return !string.IsNullOrEmpty(permissao) && permissao.ToUpper() != "N";
    }
}
