using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Siapen.Views;

namespace Siapen.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _statusMessage = "SIAPEN - Sistema Integrado de Administração Penitenciária";

    [ObservableProperty]
    private string _loginInfo = "-----------------------------";

    [ObservableProperty]
    private string _databaseInfo = "----------------------------";

    [ObservableProperty]
    private string _dataHora = "----------------------------";

    [ObservableProperty]
    private int _selectedTabIndex;

    // Navegação - cada comando abre uma tela ou mostra "Não implementado"

    [RelayCommand]
    private void NaoImplementado()
    {
        new MessageBox("Não implementado", "Esta funcionalidade ainda não foi implementada.").Show();
    }

    // === TAB PRINCIPAL ===

    [RelayCommand]
    private void BtnConfere()
    {
        var view = new MovimentoInternosView();
        view.Show();
    }

    [RelayCommand]
    private void BtnRelatorio() => NaoImplementado();

    [RelayCommand]
    private void BtnAgendaAtendimento() => NaoImplementado();

    [RelayCommand]
    private void BtnConsultaGeral() => NaoImplementado();

    [RelayCommand]
    private void BtnRequerimentos() => NaoImplementado();

    [RelayCommand]
    private void BtnHistoricoFichaDisciplinar() => NaoImplementado();

    [RelayCommand]
    private void BtnOcorrencia() => NaoImplementado();

    // === TAB SETORES ===

    [RelayCommand]
    private void ClinicaMedica() => NaoImplementado();

    [RelayCommand]
    private void Disciplina() => NaoImplementado();

    [RelayCommand]
    private void Juridico() => NaoImplementado();

    [RelayCommand]
    private void Psiquiatria() => NaoImplementado();

    [RelayCommand]
    private void Saude() => NaoImplementado();

    [RelayCommand]
    private void Odontologia() => NaoImplementado();

    [RelayCommand]
    private void Educacao() => NaoImplementado();

    [RelayCommand]
    private void Pedagogia() => NaoImplementado();

    [RelayCommand]
    private void Enfermagem() => NaoImplementado();

    [RelayCommand]
    private void Psicologia() => NaoImplementado();

    [RelayCommand]
    private void Trabalho() => NaoImplementado();

    [RelayCommand]
    private void ServicoSocial() => NaoImplementado();

    [RelayCommand]
    private void Farmacia() => NaoImplementado();

    [RelayCommand]
    private void Psicossocial() => NaoImplementado();

    [RelayCommand]
    private void TerapiaOcupacional() => NaoImplementado();

    // === MENU CADASTRO ===

    private IRelayCommand? _cadastroPavilhaoCommand;
    public IRelayCommand CadastroPavilhaoCommand =>
        _cadastroPavilhaoCommand ??= new RelayCommand(() =>
        {
            var view = new CadastroPavilhaoView();
            view.Show();
        });

    [RelayCommand]
    private void CadastroInternos() => NaoImplementado();

    [RelayCommand]
    private void CadastroCondicaoInterno() => NaoImplementado();

    [RelayCommand]
    private void CadastroAdvogado() => NaoImplementado();

    [RelayCommand]
    private void CadastroFaccao() => NaoImplementado();

    [RelayCommand]
    private void CadastroCidade() => NaoImplementado();

    [RelayCommand]
    private void CadastroRaca() => NaoImplementado();

    [RelayCommand]
    private void CadastroEscolaridade() => NaoImplementado();

    [RelayCommand]
    private void CadastroNacionalidade() => NaoImplementado();

    [RelayCommand]
    private void CadastroProcedencia() => NaoImplementado();

    [RelayCommand]
    private void CadastroDestino() => NaoImplementado();

    [RelayCommand]
    private void CadastroFornecedor() => NaoImplementado();

    [RelayCommand]
    private void CadastroProfissao() => NaoImplementado();

    [RelayCommand]
    private void CadastroCtc() => NaoImplementado();

    // === MENU MOVIMENTAÇÃO ===

    [RelayCommand]
    private void TransferenciaInterno() => NaoImplementado();

    [RelayCommand]
    private void ConferirTransferenciaRecebida() => NaoImplementado();

    [RelayCommand]
    private void MudancaCela() => NaoImplementado();

    [RelayCommand]
    private void CadastroPortariaSaidao() => NaoImplementado();

    [RelayCommand]
    private void InclusaoSaidao() => NaoImplementado();

    [RelayCommand]
    private void CirculacaoInterno() => NaoImplementado();

    [RelayCommand]
    private void MovimentoSemiAberto() => NaoImplementado();

    [RelayCommand]
    private void ConsultaMovimentacaoGeral() => NaoImplementado();

    // === MENU SETORES (sub-menu) ===

    [RelayCommand]
    private void FaltaDisciplinar() => NaoImplementado();

    [RelayCommand]
    private void SerieFaseAtual() => NaoImplementado();

    [RelayCommand]
    private void LivroRevista() => NaoImplementado();

    [RelayCommand]
    private void CargaHoraria() => NaoImplementado();

    [RelayCommand]
    private void ProcessosCondenacoes() => NaoImplementado();

    [RelayCommand]
    private void Detracao() => NaoImplementado();

    [RelayCommand]
    private void InterrupcoesPena() => NaoImplementado();

    [RelayCommand]
    private void RemicoesPena() => NaoImplementado();

    [RelayCommand]
    private void ArtigoPenal() => NaoImplementado();

    [RelayCommand]
    private void VaraExecucao() => NaoImplementado();

    [RelayCommand]
    private void Remedio() => NaoImplementado();

    [RelayCommand]
    private void SetorTrabalho() => NaoImplementado();

    [RelayCommand]
    private void FuncaoInterno() => NaoImplementado();

    [RelayCommand]
    private void CalculoTrabalho() => NaoImplementado();

    [RelayCommand]
    private void RemicaoTrabalho() => NaoImplementado();

    [RelayCommand]
    private void Roupas() => NaoImplementado();

    [RelayCommand]
    private void Ocorrencias() => NaoImplementado();

    [RelayCommand]
    private void ConselhoDisciplinar() => NaoImplementado();

    [RelayCommand]
    private void Correspondencia() => NaoImplementado();

    // === MENU VISITANTES ===

    [RelayCommand]
    private void EntradaVisitantes() => NaoImplementado();

    [RelayCommand]
    private void ConsultaVisitante() => NaoImplementado();

    [RelayCommand]
    private void GrauParentesco() => NaoImplementado();

    [RelayCommand]
    private void Visitante() => NaoImplementado();

    [RelayCommand]
    private void VisitantesTrafico() => NaoImplementado();

    // === MENU RELATÓRIOS ===

    [RelayCommand]
    private void MenuRelatorios() => NaoImplementado();

    [RelayCommand]
    private void ConsultaInterno() => NaoImplementado();

    // === MENU MÓDULOS ===

    [RelayCommand]
    private void TipoPatrimonio() => NaoImplementado();

    [RelayCommand]
    private void CadastroPatrimonio() => NaoImplementado();

    [RelayCommand]
    private void ModuloGestaoArmas() => NaoImplementado();

    [RelayCommand]
    private void ControlePortaria() => NaoImplementado();

    [RelayCommand]
    private void Inteligencia() => NaoImplementado();

    [RelayCommand]
    private void Monitoramento() => NaoImplementado();

    [RelayCommand]
    private void PlanilhaDinamica() => NaoImplementado();

    [RelayCommand]
    private void SiapenMessenger() => NaoImplementado();

    [RelayCommand]
    private void BancoHoras() => NaoImplementado();

    [RelayCommand]
    private void ModuloGestaoPessoas() => NaoImplementado();

    [RelayCommand]
    private void MonitoramentoEletronico() => NaoImplementado();

    [RelayCommand]
    private void WebBrowser() => NaoImplementado();

    // === MENU CONFIGURAÇÃO ===

    [RelayCommand]
    private void Funcionario() => NaoImplementado();

    [RelayCommand]
    private void FuncaoFuncionario() => NaoImplementado();

    [RelayCommand]
    private void UnidadePenal() => NaoImplementado();

    [RelayCommand]
    private void HorarioFuncionario() => NaoImplementado();

    [RelayCommand]
    private void PerfilUsuario() => NaoImplementado();

    [RelayCommand]
    private void PadraoSistema() => NaoImplementado();

    [RelayCommand]
    private void Equipe() => NaoImplementado();

    [RelayCommand]
    private void PostoLocalTrabalho() => NaoImplementado();

    [RelayCommand]
    private void AgentePorEquipe() => NaoImplementado();

    [RelayCommand]
    private void RegraVisitação() => NaoImplementado();

    // === MENU MANUTENÇÃO ===

    [RelayCommand]
    private void AtualizarMeusDados() => NaoImplementado();

    [RelayCommand]
    private void TrocarSenha() => NaoImplementado();

    [RelayCommand]
    private void MensagemBancoDados() => NaoImplementado();

    [RelayCommand]
    private void WebCam() => NaoImplementado();

    [RelayCommand]
    private void CopiarArquivo() => NaoImplementado();

    [RelayCommand]
    private void ConsultaProced() => NaoImplementado();

    // === MENU AGENDAMENTO ===

    [RelayCommand]
    private void AgendaAtendimento() => NaoImplementado();

    [RelayCommand]
    private void Assunto() => NaoImplementado();

    [RelayCommand]
    private void Situacao() => NaoImplementado();

    [RelayCommand]
    private void TipoContatos() => NaoImplementado();

    // === MENU PROCEDIMENTOS ===

    [RelayCommand]
    private void AgendarProcedimentos() => NaoImplementado();

    [RelayCommand]
    private void ConfigurarProcedimentos() => NaoImplementado();

    [RelayCommand]
    private void ConfigurarOcorrencias() => NaoImplementado();

    [RelayCommand]
    private void AtualizarProcedimentos() => NaoImplementado();

    [RelayCommand]
    private void PostoTrabalho() => NaoImplementado();

    // === MENU ESCALA ===

    [RelayCommand]
    private void IniciarNovaEscala() => NaoImplementado();

    [RelayCommand]
    private void AtualizarEscalaDia() => NaoImplementado();

    [RelayCommand]
    private void ImprimirEscala() => NaoImplementado();

    [RelayCommand]
    private void ApagarEscala() => NaoImplementado();

    // === MENU SOBRE ===

    [RelayCommand]
    private void Sobre() => NaoImplementado();

    [RelayCommand]
    private void MudaSkin() => NaoImplementado();

    [RelayCommand]
    private void Manual() => NaoImplementado();

    [RelayCommand]
    private void AtribuicaoSetores() => NaoImplementado();
}
