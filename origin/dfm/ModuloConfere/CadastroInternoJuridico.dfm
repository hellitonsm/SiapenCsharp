inherited FrmCadastroInternoJuridico: TFrmCadastroInternoJuridico
  Left = 581
  Top = 226
  Width = 964
  Height = 663
  Caption = 'Cadastro Jur'#237'dico'
  WindowState = wsMaximized
  PixelsPerInch = 96
  TextHeight = 13
  inherited PanelBotoes: TPanel
    Width = 956
    Height = 40
    Align = alTop
    inherited ToolBarModeloCadastro: TToolBar
      Width = 876
      Height = 40
      inherited Novo: TToolButton
        Wrap = False
      end
      inherited Editar: TToolButton
        Left = 114
        Top = 0
        Wrap = False
      end
      inherited Cancelar: TToolButton
        Left = 222
        Top = 0
        Wrap = False
      end
      inherited Salvar: TToolButton
        Left = 330
        Top = 0
        Wrap = False
      end
      inherited Excluir: TToolButton
        Left = 438
        Top = 0
        Wrap = False
      end
      inherited Fechar: TToolButton
        Left = 546
        Top = 0
      end
    end
    inherited DBNavigator1: TDBNavigator
      Left = 876
      Top = 0
      Width = 80
      Height = 40
      Align = alRight
      Hints.Strings = ()
      TabOrder = 1
    end
    inherited DBImage1: TDBImage
      TabOrder = 3
    end
    object DBImage2: TDBImage
      Left = 816
      Top = 1
      Width = 40
      Height = 38
      BorderStyle = bsNone
      DataField = 'FOTO'
      DataSource = DsCadastro
      Enabled = False
      Stretch = True
      TabOrder = 2
    end
  end
  inherited PanelModeloCadastro: TPanel
    Left = 0
    Top = 72
    Width = 956
    Height = 519
    inherited PageControlModeloCadastro: TPageControl
      Width = 956
      Height = 519
      inherited TabSheetCadastro: TTabSheet
        inherited PanelCadastro: TPanel
          Width = 948
          Height = 491
          inherited PageControlPrincipal: TPageControl
            Width = 946
            Height = 489
            ActivePage = TabSheetjuridico
            OnChange = PageControlPrincipalChange
            inherited TabSheetPrincipal: TTabSheet
              Enabled = True
              inherited Label2: TLabel
                Enabled = True
              end
              inherited Label3: TLabel
                Enabled = True
              end
              inherited Label4: TLabel
                Enabled = True
              end
              inherited Label12: TLabel
                Enabled = True
              end
              inherited SpeedButton1: TSpeedButton
                Enabled = True
              end
              inherited Label45: TLabel
                Enabled = True
              end
              inherited Label46: TLabel
                Enabled = True
              end
              inherited SpeedButton2: TSpeedButton
                Enabled = True
              end
              inherited Label27: TLabel
                Enabled = True
              end
              inherited Label36: TLabel
                Enabled = True
              end
              inherited Label65: TLabel
                Enabled = True
              end
              inherited Label66: TLabel
                Enabled = True
              end
              inherited lbl1: TLabel
                Enabled = True
              end
              inherited Label43: TLabel
                Enabled = True
              end
              inherited Label18: TLabel
                Enabled = True
              end
              inherited Label44: TLabel
                Enabled = True
              end
              inherited Label54: TLabel
                Enabled = True
              end
              inherited Label78: TLabel
                Enabled = True
              end
              inherited Label79: TLabel
                Enabled = True
              end
              inherited Label80: TLabel
                Enabled = True
              end
              inherited Label82: TLabel
                Left = 220
                Enabled = True
              end
              inherited Label83: TLabel
                Enabled = True
              end
              inherited DBEdit2: TDBEdit
                Enabled = True
              end
              inherited DBEdit3: TDBEdit
                Enabled = True
              end
              inherited DBEditID_PROCEDENCIA: TDBEdit
                Enabled = True
              end
              inherited DBLookupComboBoxID_PROCEDENCIA: TDBLookupComboBox
                Enabled = True
              end
              inherited DBRadioGroup1: TDBRadioGroup
                Enabled = True
              end
              inherited DBRadioGroup2: TDBRadioGroup
                Enabled = True
              end
              inherited DBEdit6: TDBEdit
                Enabled = True
              end
              inherited DBLookupComboBox1: TDBLookupComboBox
                Enabled = True
              end
              inherited DBEdit7: TDBEdit
                Enabled = True
              end
              inherited DBLookupComboBox2: TDBLookupComboBox
                Enabled = True
              end
              inherited DBImageFOTOInterno: TDBImage
                Enabled = True
              end
              inherited DBEdit24: TDBEdit
                Enabled = True
              end
              inherited DBEdit25: TDBEdit
                Enabled = True
              end
              inherited DBEdit35: TDBEdit
                Enabled = True
              end
              inherited DBComboBox3: TDBComboBox
                Enabled = True
              end
              inherited DBEdit86: TDBEdit
                Enabled = True
              end
              inherited dbrgrpST: TDBRadioGroup
                Enabled = True
              end
              inherited DBComboBox2: TDBComboBox
                Top = 220
              end
              inherited DBLookupComboBoxFACCAO: TDBLookupComboBox
                Enabled = True
              end
              inherited DBEdit8: TDBEdit
                Enabled = True
              end
              inherited DBEdit31: TDBEdit
                Enabled = True
              end
              inherited DBEdit33: TDBEdit
                Enabled = True
              end
              inherited DBComboBox5: TDBComboBox
                Left = 221
                Top = 394
                Enabled = True
                Items.Strings = (
                  'Aberto'
                  'Fechado'
                  'Medida de Seguran'#231'a'
                  'Medida de Tratamento'
                  'Provis'#243'rio'
                  'Semi-Aberto'
                  'Semi-Aberto Sem Saida'
                  'Semi-Aberto Com Trabalho Externo'
                  'Semi-Aberto Com Trabalho Externo e Sa'#237'da'
                  'Semi-Aberto Com Saida'
                  'Tempor'#225'rio')
              end
              inherited DBComboBox4: TDBComboBox
                Enabled = True
              end
            end
            inherited TabSheetDadosGerais: TTabSheet
              inherited Label11: TLabel
                Top = 64
                Enabled = True
              end
              inherited Label19: TLabel
                Top = 47
                Enabled = True
              end
              inherited Label21: TLabel
                Top = 87
                Enabled = True
              end
              inherited Label22: TLabel
                Top = 143
                Enabled = True
              end
              inherited Label23: TLabel
                Top = 165
                Enabled = True
              end
              inherited Label20: TLabel
                Top = 87
                Enabled = True
              end
              inherited Label37: TLabel
                Top = 203
                Enabled = True
              end
              inherited Label13: TLabel
                Top = 204
                Enabled = True
              end
              inherited SpeedButton4: TSpeedButton
                Top = 102
                Enabled = True
                OnClick = SpeedButton4Click
              end
              inherited SpeedButton5: TSpeedButton
                Top = 102
                Enabled = True
                OnClick = SpeedButton5Click
              end
              inherited SpeedButton6: TSpeedButton
                Top = 142
                Enabled = True
                OnClick = SpeedButton6Click
              end
              inherited SpeedButton7: TSpeedButton
                Top = 181
                Enabled = True
                OnClick = SpeedButton7Click
              end
              inherited SpeedButton9: TSpeedButton
                Top = 217
                Enabled = True
                OnClick = SpeedButton9Click
              end
              inherited Label5: TLabel
                Top = 7
                Enabled = True
              end
              inherited Label24: TLabel
                Top = 7
                Enabled = True
              end
              inherited Label25: TLabel
                Top = 7
                Enabled = True
              end
              inherited Label39: TLabel
                Top = 7
                Enabled = True
              end
              inherited Label47: TLabel
                Top = 7
                Enabled = True
              end
              inherited Label52: TLabel
                Top = 7
                Enabled = True
              end
              inherited Label63: TLabel
                Top = 127
                Enabled = True
              end
              inherited Label64: TLabel
                Top = 126
                Enabled = True
              end
              inherited Label28: TLabel
                Top = 240
                Enabled = True
              end
              inherited Label30: TLabel
                Top = 280
                Enabled = True
              end
              inherited Label31: TLabel
                Top = 321
                Enabled = True
              end
              inherited Label32: TLabel
                Top = 321
                Enabled = True
              end
              inherited Label33: TLabel
                Top = 359
                Enabled = True
              end
              inherited Label34: TLabel
                Top = 359
                Enabled = True
              end
              inherited Label35: TLabel
                Top = 399
                Enabled = True
              end
              inherited SpeedButton11: TSpeedButton
                Top = 373
                Enabled = True
                OnClick = SpeedButton11Click
              end
              inherited lbl2: TLabel
                Top = 399
                Enabled = True
              end
              inherited btn1: TSpeedButton
                Top = 414
                Enabled = True
                OnClick = btn1Click
              end
              inherited Label6: TLabel
                Top = 280
                Enabled = True
              end
              inherited Label7: TLabel
                Top = 127
                Enabled = True
              end
              inherited Label9: TLabel
                Top = 48
                Enabled = True
              end
              inherited DBEdit1: TDBEdit
                Top = 63
                Enabled = True
              end
              inherited DBEdit5: TDBEdit
                Top = 63
                Enabled = True
              end
              inherited DBLookupComboBoxIDNATURALIDADE: TDBLookupComboBox
                Top = 103
                Enabled = True
              end
              inherited DBLookupComboBoxIDNACIONALIDADE: TDBLookupComboBox
                Top = 103
                Enabled = True
              end
              inherited DBLookupComboBoxIDRACA: TDBLookupComboBox
                Top = 142
                Enabled = True
              end
              inherited DBLookupComboBoxIDESCOLARIDADE: TDBLookupComboBox
                Top = 181
                Enabled = True
              end
              inherited DBLookupComboBoxIDPROFISSAO: TDBLookupComboBox
                Top = 220
                Enabled = True
                TabOrder = 24
              end
              inherited DBEdit9: TDBEdit
                Top = 23
                Enabled = True
              end
              inherited DBEdit19: TDBEdit
                Top = 23
                Enabled = True
                OnExit = DBEdit19Exit
              end
              inherited DBComboBox1: TDBComboBox
                Top = 23
                Enabled = True
                Items.Strings = (
                  'Amasiado'
                  'Casado'
                  'Divorciado'
                  'Separado Judicialmente'
                  'Solteiro'
                  'Viuvo'
                  'Uni'#227'o Estavel'
                  'N'#227'o Declarado')
              end
              inherited DBEdit26: TDBEdit
                Top = 23
                Enabled = True
              end
              inherited DBEdit27: TDBEdit
                Top = 23
                Enabled = True
              end
              inherited DBEdit28: TDBEdit
                Top = 23
                Enabled = True
              end
              inherited DBEdit32: TDBEdit
                Top = 142
                Enabled = True
              end
              inherited DBEdit34: TDBEdit
                Top = 142
                Enabled = True
              end
              inherited DBEdit10: TDBEdit
                Top = 256
                Enabled = True
                TabOrder = 14
              end
              inherited DBEdit11: TDBEdit
                Top = 296
                Enabled = True
                TabOrder = 15
              end
              inherited DBEdit12: TDBEdit
                Top = 296
                Enabled = True
                TabOrder = 16
              end
              inherited DBEdit13: TDBEdit
                Top = 337
                Enabled = True
                TabOrder = 17
              end
              inherited DBEdit14: TDBEdit
                Top = 337
                Enabled = True
                TabOrder = 18
              end
              inherited DBEdit16: TDBEdit
                Top = 375
                Enabled = True
                TabOrder = 20
              end
              inherited DBEdit17: TDBEdit
                Top = 415
                Enabled = True
                TabOrder = 22
              end
              inherited DBLookupComboBoxIDCIDADE: TDBLookupComboBox
                Top = 375
                Enabled = True
                TabOrder = 19
              end
              inherited DBLookupComboBoxIDNACIONALIDADE1: TDBLookupComboBox
                Top = 415
                Enabled = True
                TabOrder = 21
              end
              inherited DBComboBoxReligiao1: TDBComboBox
                Top = 220
                Enabled = True
                TabOrder = 23
              end
            end
            object TabSheetjuridico: TTabSheet
              Caption = 'Jur'#237'dico'
              ImageIndex = 2
              object SpeedButton3: TSpeedButton
                Left = 380
                Top = 8
                Width = 23
                Height = 22
                Hint = 'Tirar Medida de Seguran'#231'a'
                Caption = '#'
                Flat = True
                ParentShowHint = False
                ShowHint = True
                OnClick = SpeedButton3Click
              end
              object Label17: TLabel
                Left = 16
                Top = 11
                Width = 83
                Height = 13
                Caption = 'Situa'#231#227'o Jurid'#237'ca'
              end
              object DBRadioGroup3: TDBRadioGroup
                Left = 415
                Top = -1
                Width = 170
                Height = 34
                DataField = 'MEDIDASEGURANCA'
                DataSource = DsCadastro
                Items.Strings = (
                  'MEDIDA DE SEGURAN'#199'A')
                TabOrder = 1
                Values.Strings = (
                  'MS')
              end
              object PageControl1: TPageControl
                Left = 0
                Top = 38
                Width = 862
                Height = 408
                ActivePage = TabSheet2
                TabOrder = 2
                TabWidth = 150
                object TabSheet2: TTabSheet
                  Caption = 'Controle Perman'#234'ncia'
                  object Label15: TLabel
                    Left = 5
                    Top = 11
                    Width = 53
                    Height = 13
                    Caption = 'Data Inicial'
                    Transparent = True
                  end
                  object Label57: TLabel
                    Left = 5
                    Top = 54
                    Width = 42
                    Height = 13
                    Caption = 'N'#186' Autos'
                    Transparent = True
                  end
                  object Label58: TLabel
                    Left = 172
                    Top = 54
                    Width = 177
                    Height = 13
                    Caption = 'Observa'#231#227'o referente '#224' Perman'#234'ncia'
                    Transparent = True
                  end
                  object Label56: TLabel
                    Left = 89
                    Top = 11
                    Width = 135
                    Height = 13
                    Caption = 'Autoriza'#231#227'o (Juiz/Colegiado)'
                    Transparent = True
                  end
                  object Label26: TLabel
                    Left = 508
                    Top = 11
                    Width = 74
                    Height = 13
                    Caption = 'Dias Autorizado'
                    Transparent = True
                  end
                  object Label16: TLabel
                    Left = 599
                    Top = 11
                    Width = 64
                    Height = 13
                    Caption = 'Data Retorno'
                    Transparent = True
                  end
                  object LbNumConflito: TLabel
                    Left = 712
                    Top = 54
                    Width = 65
                    Height = 13
                    Caption = 'N'#186' do Conflito'
                    Enabled = False
                  end
                  object LbObsConflito: TLabel
                    Left = 712
                    Top = 160
                    Width = 120
                    Height = 13
                    Caption = 'Obs. referente ao Conflito'
                    Enabled = False
                  end
                  object LbMSG1: TLabel
                    Left = 248
                    Top = 234
                    Width = 338
                    Height = 26
                    Caption = 
                      'Clique no menos (-) para excluir o registro de perman'#234'ncia selec' +
                      'ionado. Obs: S'#243' '#233' poss'#237'vel excluir a perman'#234'ncia ap'#243's excluir os' +
                      ' anexos dela.'
                    WordWrap = True
                  end
                  object GroupBox1: TGroupBox
                    Left = 0
                    Top = 264
                    Width = 710
                    Height = 123
                    Caption = 'Anexos'
                    TabOrder = 17
                    object LbMSG2: TLabel
                      Left = 16
                      Top = 88
                      Width = 134
                      Height = 26
                      Caption = 'Clique no menos (-) para excluir o anexo selecionado.'
                      WordWrap = True
                    end
                  end
                  object BtnIncluirDocDigitalizado: TBitBtn
                    Left = 56
                    Top = 273
                    Width = 200
                    Height = 30
                    Caption = 'Incluir Doc. Digitalizado'
                    Font.Charset = DEFAULT_CHARSET
                    Font.Color = clBlack
                    Font.Height = -13
                    Font.Name = 'Times New Roman'
                    Font.Style = []
                    ParentFont = False
                    TabOrder = 13
                    TabStop = False
                    OnClick = BtnIncluirDocDigitalizadoClick
                    Glyph.Data = {}
                    Style = bsWin31
                  end
                  object BtnVisuzalizarDocDigitalizador: TBitBtn
                    Left = 56
                    Top = 313
                    Width = 200
                    Height = 30
                    Caption = 'Visualizar Doc. Digitalizado'
                    Font.Charset = DEFAULT_CHARSET
                    Font.Color = clBlack
                    Font.Height = -13
                    Font.Name = 'Times New Roman'
                    Font.Style = []
                    ParentFont = False
                    TabOrder = 14
                    TabStop = False
                    OnClick = BtnVisuzalizarDocDigitalizadorClick
                    Glyph.Data = {}
                    Style = bsWin31
                  end
                  object DBNavigator2: TDBNavigator
                    Left = -1
                    Top = 234
                    Width = 240
                    Height = 25
                    DataSource = DsControlePermanencia
                    TabOrder = 12
                  end
                  object DBGrid3: TDBGrid
                    Left = 264
                    Top = 273
                    Width = 441
                    Height = 105
                    DataSource = DsPermanenciaScaner
                    Options = [dgTitles, dgIndicator, dgColumnResize, dgTabs, dgConfirmDelete, dgCancelOnExit]
                    ReadOnly = True
                    TabOrder = 15
                    TitleFont.Charset = DEFAULT_CHARSET
                    TitleFont.Color = clWindowText
                    TitleFont.Height = -11
                    TitleFont.Name = 'MS Sans Serif'
                    TitleFont.Style = []
                    OnDblClick = DBGrid3DblClick
                    Columns = <
                      item
                        Expanded = False
                        FieldName = 'DESCRICAO_PERMANENCIA'
                        Title.Caption = 'Documentos Digitalizados'
                        Width = 420
                        Visible = True
                      end>
                  end
                  object DBEditDataInicio: TDBEdit
                    Left = 5
                    Top = 29
                    Width = 82
                    Height = 21
                    DataField = 'data_inicial'
                    DataSource = DsControlePermanencia
                    TabOrder = 0
                    OnExit = DBEditDataInicioExit
                    OnKeyPress = DBEditDataInicioKeyPress
                  end
                  object DBEdit23: TDBEdit
                    Left = 5
                    Top = 69
                    Width = 164
                    Height = 21
                    DataField = 'nautos'
                    DataSource = DsControlePermanencia
                    TabOrder = 4
                  end
                  object DBMemo4: TDBMemo
                    Left = 172
                    Top = 69
                    Width = 333
                    Height = 41
                    DataField = 'obs'
                    DataSource = DsControlePermanencia
                    TabOrder = 5
                  end
                  object DBEdit22: TDBEdit
                    Left = 89
                    Top = 29
                    Width = 418
                    Height = 21
                    DataField = 'autorizacao'
                    DataSource = DsControlePermanencia
                    TabOrder = 1
                  end
                  object DBEdit30: TDBEdit
                    Left = 508
                    Top = 29
                    Width = 90
                    Height = 21
                    DataField = 'diasautorizados'
                    DataSource = DsControlePermanencia
                    TabOrder = 2
                  end
                  object DBEditDataFim: TDBEdit
                    Left = 599
                    Top = 29
                    Width = 90
                    Height = 21
                    DataField = 'data_final'
                    DataSource = DsControlePermanencia
                    TabOrder = 3
                    OnExit = DBEditDataFimExit
                    OnKeyPress = DBEditDataFimKeyPress
                  end
                  object DBGrid11: TDBGrid
                    Left = 0
                    Top = 112
                    Width = 705
                    Height = 120
                    DataSource = DsControlePermanencia
                    ReadOnly = True
                    TabOrder = 11
                    TitleFont.Charset = DEFAULT_CHARSET
                    TitleFont.Color = clWindowText
                    TitleFont.Height = -11
                    TitleFont.Name = 'MS Sans Serif'
                    TitleFont.Style = []
                    OnDrawColumnCell = DBGrid11DrawColumnCell
                    Columns = <
                      item
                        Expanded = False
                        FieldName = 'data_inicial'
                        Title.Caption = 'Data Inicial'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'autorizacao'
                        Title.Caption = 'Juiz/Colegiado'
                        Width = 100
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'diasautorizados'
                        Title.Caption = 'Dias Aut.'
                        Width = 60
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'data_final'
                        Title.Caption = 'Data Final'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'nautos'
                        Title.Caption = 'N'#186' Autos'
                        Width = 100
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'obs'
                        Title.Caption = 'Observa'#231#227'o Perman'#234'ncia'
                        Width = 260
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'CONFLITO_COMPETENCIA'
                        Title.Caption = 'H'#225' Conflito?'
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'NUM_CONFLITO_COMPETENCIA'
                        Title.Caption = 'N'#186' Conflito'
                        Width = 100
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'OBS_CONFLITO_COMPETENCIA'
                        Title.Caption = 'Observa'#231#227'o Conflito'
                        Width = 260
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'CONFLITO_STATUS'
                        Title.Caption = 'Status Conflito'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'OFICIO_PRAZO'
                        Title.Caption = 'Of'#237'cio Renova'#231#227'o'
                        Width = 94
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'NUM_OFICIO_PRAZO'
                        Title.Caption = 'N'#186' Of'#237'cio'
                        Width = 100
                        Visible = True
                      end>
                  end
                  object DBRadioGroupConflito: TDBRadioGroup
                    Left = 696
                    Top = 8
                    Width = 153
                    Height = 41
                    Caption = 'H'#225' Conflito de Compet'#234'ncia?'
                    Columns = 2
                    DataField = 'CONFLITO_COMPETENCIA'
                    DataSource = DsControlePermanencia
                    Items.Strings = (
                      'Sim'
                      'N'#227'o')
                    TabOrder = 7
                    Values.Strings = (
                      'S'
                      'N')
                    OnChange = DBRadioGroupConflitoChange
                    OnClick = DBRadioGroupConflitoClick
                  end
                  object DBEditNumConflito: TDBEdit
                    Left = 712
                    Top = 69
                    Width = 137
                    Height = 21
                    DataField = 'NUM_CONFLITO_COMPETENCIA'
                    DataSource = DsControlePermanencia
                    Enabled = False
                    TabOrder = 8
                  end
                  object DBMemoObsConflito: TDBMemo
                    Left = 712
                    Top = 176
                    Width = 137
                    Height = 185
                    DataField = 'OBS_CONFLITO_COMPETENCIA'
                    DataSource = DsControlePermanencia
                    Enabled = False
                    TabOrder = 10
                  end
                  object DBRadioGroupStatusConflito: TDBRadioGroup
                    Left = 712
                    Top = 104
                    Width = 137
                    Height = 49
                    Caption = 'Status do Conflito'
                    DataField = 'CONFLITO_STATUS'
                    DataSource = DsControlePermanencia
                    Enabled = False
                    Items.Strings = (
                      'Em Andamento'
                      'Finalizado')
                    TabOrder = 9
                    Values.Strings = (
                      'A'
                      'F')
                  end
                  object DBNavigator3: TDBNavigator
                    Left = 160
                    Top = 352
                    Width = 100
                    Height = 25
                    DataSource = DsPermanenciaScaner
                    VisibleButtons = [nbFirst, nbPrior, nbNext, nbLast, nbDelete]
                    TabOrder = 16
                  end
                  object GbOficioPrazo: TGroupBox
                    Left = 508
                    Top = 54
                    Width = 197
                    Height = 57
                    Caption = 'Of'#237'cio de Renova'#231#227'o de Prazo'
                    TabOrder = 6
                    object LbNumOficioPrazo: TLabel
                      Left = 104
                      Top = 15
                      Width = 59
                      Height = 13
                      Caption = 'N'#186' do Of'#237'cio'
                      Enabled = False
                    end
                    object DbRgEnviadoOficioPrazo: TDBRadioGroup
                      Left = 4
                      Top = 16
                      Width = 93
                      Height = 36
                      Caption = 'Enviado?'
                      Columns = 2
                      DataField = 'OFICIO_PRAZO'
                      DataSource = DsControlePermanencia
                      Items.Strings = (
                        'Sim'
                        'N'#227'o')
                      TabOrder = 0
                      Values.Strings = (
                        'S'
                        'N')
                      OnChange = DbRgEnviadoOficioPrazoChange
                      OnClick = DbRgEnviadoOficioPrazoClick
                    end
                    object DBEditNumOficioPrazo: TDBEdit
                      Left = 104
                      Top = 31
                      Width = 89
                      Height = 21
                      DataField = 'NUM_OFICIO_PRAZO'
                      DataSource = DsControlePermanencia
                      Enabled = False
                      TabOrder = 1
                    end
                  end
                end
                object TabSheet3: TTabSheet
                  Caption = 
                    'Metodo Antigo no Jur'#237'dico (Substituido por Cadastro de Processos' +
                    ')'
                  ImageIndex = 1
                  TabVisible = False
                  object PageControl2: TPageControl
                    Left = 8
                    Top = 4
                    Width = 648
                    Height = 363
                    ActivePage = TabSheet9
                    TabOrder = 0
                    object TabSheet9: TTabSheet
                      Caption = 'Condena'#231#227'o do Interno'
                      object Label71: TLabel
                        Left = 16
                        Top = 113
                        Width = 32
                        Height = 13
                        Caption = 'Artigos'
                      end
                      object Label72: TLabel
                        Left = 16
                        Top = 152
                        Width = 58
                        Height = 13
                        Caption = 'Observa'#231#227'o'
                      end
                      object Label73: TLabel
                        Left = 403
                        Top = 115
                        Width = 19
                        Height = 13
                        Caption = 'Ano'
                      end
                      object Label74: TLabel
                        Left = 475
                        Top = 115
                        Width = 20
                        Height = 13
                        Caption = 'M'#234's'
                      end
                      object Label75: TLabel
                        Left = 555
                        Top = 115
                        Width = 16
                        Height = 13
                        Caption = 'Dia'
                      end
                      object Label139: TLabel
                        Left = 16
                        Top = 0
                        Width = 42
                        Height = 13
                        Caption = 'Comarca'
                      end
                      object Label150: TLabel
                        Left = 296
                        Top = 0
                        Width = 22
                        Height = 13
                        Caption = 'Vara'
                      end
                      object Label151: TLabel
                        Left = 16
                        Top = 38
                        Width = 29
                        Height = 13
                        Caption = 'Pris'#227'o'
                      end
                      object Label152: TLabel
                        Left = 296
                        Top = 38
                        Width = 20
                        Height = 13
                        Caption = 'R'#233'u'
                      end
                      object Label153: TLabel
                        Left = 457
                        Top = 38
                        Width = 59
                        Height = 13
                        Caption = 'N'#186' Processo'
                      end
                      object Label154: TLabel
                        Left = 16
                        Top = 75
                        Width = 90
                        Height = 13
                        Caption = 'Guia Recolhimento'
                      end
                      object Label155: TLabel
                        Left = 345
                        Top = 75
                        Width = 83
                        Height = 13
                        Caption = 'Situa'#231#227'o Jur'#237'dica'
                      end
                      object Label162: TLabel
                        Left = 457
                        Top = 0
                        Width = 33
                        Height = 13
                        Caption = 'Justi'#231'a'
                      end
                      object BitBtn2: TBitBtn
                        Left = 168
                        Top = 189
                        Width = 75
                        Height = 25
                        Caption = 'Inserir'
                        TabOrder = 13
                        OnClick = BtnVisuzalizarDocDigitalizadorClick
                        Glyph.Data = {}
                        NumGlyphs = 2
                      end
                      object BitBtn3: TBitBtn
                        Left = 264
                        Top = 189
                        Width = 75
                        Height = 25
                        Caption = 'Deletar'
                        TabOrder = 14
                        Glyph.Data = {}
                        NumGlyphs = 2
                      end
                      object DBGrid2: TDBGrid
                        Left = 16
                        Top = 216
                        Width = 601
                        Height = 118
                        TabOrder = 15
                        TitleFont.Charset = DEFAULT_CHARSET
                        TitleFont.Color = clWindowText
                        TitleFont.Height = -11
                        TitleFont.Name = 'MS Sans Serif'
                        TitleFont.Style = []
                        Columns = <
                          item
                            Expanded = False
                            FieldName = 'COMARCA'
                            Width = 197
                            Visible = True
                          end
                          item
                            Expanded = False
                            FieldName = 'VARA'
                            Width = 132
                            Visible = True
                          end
                          item
                            Expanded = False
                            FieldName = 'PRISAO'
                            Width = 135
                            Visible = True
                          end
                          item
                            Expanded = False
                            FieldName = 'REU'
                            Width = 128
                            Visible = True
                          end
                          item
                            Expanded = False
                            FieldName = 'NPROCESSO'
                            Width = 86
                            Visible = True
                          end
                          item
                            Expanded = False
                            FieldName = 'GR'
                            Width = 97
                            Visible = True
                          end
                          item
                            Expanded = False
                            FieldName = 'SITUACAOJURIDICA'
                            Visible = True
                          end
                          item
                            Expanded = False
                            FieldName = 'TOTAL_PENA_ANO'
                            Visible = True
                          end
                          item
                            Expanded = False
                            FieldName = 'ARTIGO'
                            Width = 154
                            Visible = True
                          end
                          item
                            Expanded = False
                            FieldName = 'TOTAL_PENA_MES'
                            Visible = True
                          end
                          item
                            Expanded = False
                            FieldName = 'TOTAL_PENA_DIA'
                            Visible = True
                          end
                          item
                            Expanded = False
                            FieldName = 'OBSERVACAO'
                            Visible = True
                          end>
                      end
                      object EditArtigo: TEdit
                        Left = 16
                        Top = 129
                        Width = 375
                        Height = 21
                        MaxLength = 100
                        TabOrder = 8
                      end
                      object EditObservacaoCondenacao: TEdit
                        Left = 16
                        Top = 166
                        Width = 600
                        Height = 21
                        MaxLength = 100
                        TabOrder = 12
                      end
                      object EditAno: TEdit
                        Left = 401
                        Top = 129
                        Width = 65
                        Height = 21
                        MaxLength = 4
                        TabOrder = 9
                      end
                      object EditMes: TEdit
                        Left = 473
                        Top = 129
                        Width = 73
                        Height = 21
                        MaxLength = 4
                        TabOrder = 10
                      end
                      object EditDia: TEdit
                        Left = 553
                        Top = 129
                        Width = 62
                        Height = 21
                        MaxLength = 4
                        TabOrder = 11
                      end
                      object DBLookupComboBox11: TDBLookupComboBox
                        Left = 16
                        Top = 16
                        Width = 270
                        Height = 21
                        KeyField = 'ID_CIDADE'
                        ListField = 'CIDADE'
                        ListSource = DM.DSCIDADE
                        TabOrder = 0
                      end
                      object Editguia: TEdit
                        Left = 16
                        Top = 91
                        Width = 322
                        Height = 21
                        TabOrder = 6
                      end
                      object Editvara: TEdit
                        Left = 296
                        Top = 16
                        Width = 152
                        Height = 21
                        TabOrder = 1
                      end
                      object ComboBoxprisao: TComboBox
                        Left = 16
                        Top = 54
                        Width = 273
                        Height = 21
                        ItemHeight = 13
                        TabOrder = 3
                        Items.Strings = (
                          'Flagrante'
                          'Cumprimento de Senten'#231'a'
                          'Mandado de Pris'#227'o Preventiva'
                          'Mandado de Pris'#227'o Provis'#243'rio')
                      end
                      object ComboBoxreu: TComboBox
                        Left = 296
                        Top = 54
                        Width = 154
                        Height = 21
                        ItemHeight = 13
                        TabOrder = 4
                        Items.Strings = (
                          'Prim'#225'rio'
                          'Reincidente'
                          'Tecnicamente Prim'#225'rio')
                      end
                      object Editprocesso: TEdit
                        Left = 457
                        Top = 54
                        Width = 158
                        Height = 21
                        TabOrder = 5
                      end
                      object ComboBox1: TComboBox
                        Left = 345
                        Top = 91
                        Width = 271
                        Height = 21
                        ItemHeight = 13
                        ItemIndex = 0
                        TabOrder = 7
                        Text = 'Condenado'
                        Items.Strings = (
                          'Condenado'
                          'Processado')
                      end
                      object cbbJustica: TComboBox
                        Left = 456
                        Top = 16
                        Width = 157
                        Height = 21
                        ItemHeight = 13
                        TabOrder = 2
                        Text = 'cbbJustica'
                        Items.Strings = (
                          'JUSTI'#199'A COMUM'
                          'JUSTI'#199'A FEDERAL')
                      end
                    end
                  end
                end
                object TabSheet4: TTabSheet
                  Caption = 'Passagem no Sistema'
                  ImageIndex = 2
                  object Label8: TLabel
                    Left = 16
                    Top = 16
                    Width = 258
                    Height = 13
                    Caption = 'Observa'#231#245'es da Passagem Pelo Sistema Penitenci'#225'rio'
                  end
                  object Label14: TLabel
                    Left = 16
                    Top = 152
                    Width = 159
                    Height = 13
                    Caption = 'Motiva'#231#227'o do Pedido de Inclus'#227'o'
                  end
                  object DBMemo2: TDBMemo
                    Left = 16
                    Top = 32
                    Width = 713
                    Height = 97
                    DataField = 'PASSAGEM_SPF'
                    DataSource = DsCadastro
                    TabOrder = 0
                  end
                  object DBMemo3: TDBMemo
                    Left = 16
                    Top = 168
                    Width = 713
                    Height = 153
                    DataField = 'MOTIVACAO_INCLUSAO'
                    DataSource = DsCadastro
                    TabOrder = 1
                  end
                end
              end
              object DBComboBox7: TDBComboBox
                Left = 104
                Top = 9
                Width = 265
                Height = 21
                Style = csDropDownList
                DataField = 'TIPOPROCESSO'
                DataSource = DsCadastro
                ItemHeight = 13
                Items.Strings = (
                  'CONDENADO'
                  'PROVISORIO')
                TabOrder = 0
              end
            end
            object TabSheet1: TTabSheet
              Caption = 'Hist'#243'rico'
              ImageIndex = 3
              object Label29: TLabel
                Left = 39
                Top = 16
                Width = 23
                Height = 13
                Caption = 'Data'
              end
              object Label41: TLabel
                Left = 144
                Top = 16
                Width = 48
                Height = 13
                Caption = 'Descri'#231#227'o'
              end
              object DateTimePickhistorico: TDateTimePicker
                Left = 39
                Top = 33
                Width = 91
                Height = 21
                Date = 0.302563541663403200
                Time = 0.302563541663403200
                TabOrder = 0
              end
              object Memohistorico: TMemo
                Left = 140
                Top = 33
                Width = 506
                Height = 97
                TabOrder = 1
              end
              object BitBtn6: TBitBtn
                Left = 48
                Top = 104
                Width = 81
                Height = 25
                Caption = 'Inserir'
                Default = True
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -13
                Font.Name = 'MS Sans Serif'
                Font.Style = [fsBold]
                ParentFont = False
                TabOrder = 2
                OnClick = BitBtn6Click
                Glyph.Data = {}
                NumGlyphs = 2
              end
              object DBGrid5: TDBGrid
                Left = 40
                Top = 157
                Width = 610
                Height = 140
                DataSource = DSHISTORICO_interno
                TabOrder = 3
                TitleFont.Charset = DEFAULT_CHARSET
                TitleFont.Color = clWindowText
                TitleFont.Height = -11
                TitleFont.Name = 'MS Sans Serif'
                TitleFont.Style = []
                Columns = <
                  item
                    Expanded = False
                    FieldName = 'DATA_HORA'
                    Title.Caption = 'Data'
                    Width = 79
                    Visible = True
                  end
                  item
                    Expanded = False
                    FieldName = 'SETOR'
                    Title.Caption = 'Setor'
                    Width = 71
                    Visible = True
                  end
                  item
                    Expanded = False
                    FieldName = 'DESCRICAO'
                    Title.Caption = 'Descri'#231#227'o'
                    Width = 454
                    Visible = True
                  end>
              end
              object DBMemohistorico: TDBMemo
                Left = 40
                Top = 327
                Width = 610
                Height = 106
                DataField = 'DESCRICAO'
                DataSource = DSHISTORICO_interno
                TabOrder = 4
              end
            end
            object TabSheetCalcularExecucaoPenal: TTabSheet
              Caption = 'Calcular a Execu'#231#227'o Penal'
              ImageIndex = 4
              object Label48: TLabel
                Left = 24
                Top = 18
                Width = 536
                Height = 13
                Caption = 
                  'F'#243'rmula: (Data inicial)-(Data base) + Soma das Fra'#231#245'es dos Proce' +
                  'ssos  + Interrup'#231#227'o - Detra'#231#227'o - Remi'#231#227'o - 1 dia'
              end
              object Label60: TLabel
                Left = 24
                Top = 2
                Width = 304
                Height = 13
                Caption = 'M'#233'todo da calculadora do CNJ: http://www.cnj.jus.br'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = [fsBold]
                ParentFont = False
              end
              object BitBtn15: TBitBtn
                Left = 14
                Top = 41
                Width = 175
                Height = 43
                Caption = 'I / P / C'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clNavy
                Font.Height = -19
                Font.Name = 'Times New Roman'
                Font.Style = []
                ParentFont = False
                TabOrder = 0
                TabStop = False
                OnClick = BitBtn15Click
                Glyph.Data = {}
                Style = bsWin31
              end
              object BitBtn1: TBitBtn
                Left = 196
                Top = 41
                Width = 175
                Height = 43
                Caption = 'Detra'#231#227'o'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clNavy
                Font.Height = -19
                Font.Name = 'Times New Roman'
                Font.Style = []
                ParentFont = False
                TabOrder = 1
                TabStop = False
                OnClick = BitBtn1Click
                Glyph.Data = {}
                Style = bsWin31
              end
              object BitBtn4: TBitBtn
                Left = 378
                Top = 41
                Width = 175
                Height = 43
                Caption = 'Interrup'#231#227'o'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clNavy
                Font.Height = -19
                Font.Name = 'Times New Roman'
                Font.Style = []
                ParentFont = False
                TabOrder = 2
                TabStop = False
                OnClick = BitBtn4Click
                Glyph.Data = {}
                Style = bsWin31
              end
              object BitBtn5: TBitBtn
                Left = 560
                Top = 41
                Width = 175
                Height = 43
                Caption = 'Remi'#231#227'o'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clNavy
                Font.Height = -19
                Font.Name = 'Times New Roman'
                Font.Style = []
                ParentFont = False
                TabOrder = 3
                TabStop = False
                OnClick = BitBtn5Click
                Glyph.Data = {}
                Style = bsWin31
              end
              object PageControlCalculo: TPageControl
                Left = 8
                Top = 88
                Width = 915
                Height = 350
                ActivePage = TabSheet12
                TabOrder = 5
                TabWidth = 100
                object TabSheet12: TTabSheet
                  Caption = 'Calculo'
                  ImageIndex = 131
                  object DBGridLinhaTempo: TDBGrid
                    Left = 0
                    Top = 57
                    Width = 907
                    Height = 265
                    Align = alClient
                    DataSource = DsLinhaTempo
                    Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgConfirmDelete, dgCancelOnExit]
                    ReadOnly = True
                    TabOrder = 1
                    TitleFont.Charset = DEFAULT_CHARSET
                    TitleFont.Color = clWindowText
                    TitleFont.Height = -11
                    TitleFont.Name = 'MS Sans Serif'
                    TitleFont.Style = []
                    Columns = <
                      item
                        Expanded = False
                        FieldName = 'LINHA'
                        Title.Caption = 'Registros'
                        Width = 860
                        Visible = True
                      end>
                  end
                  object Panel1: TPanel
                    Left = 0
                    Top = 0
                    Width = 907
                    Height = 57
                    Align = alTop
                    TabOrder = 0
                    object Label81: TLabel
                      Left = 186
                      Top = 7
                      Width = 89
                      Height = 13
                      Caption = 'Pena Consolidada:'
                    end
                    object BtnCalcular: TBitBtn
                      Left = 6
                      Top = 9
                      Width = 175
                      Height = 33
                      Caption = 'Calcular'
                      TabOrder = 0
                      OnClick = BtnCalcularClick
                      Glyph.Data = {}
                    end
                    object DBEditANO: TDBEdit
                      Left = 187
                      Top = 23
                      Width = 65
                      Height = 21
                      DataField = 'TEMPO_CONSOLIDADO_ANO'
                      DataSource = DsCadastro
                      TabOrder = 1
                    end
                    object RadioGroupVerLinha: TRadioGroup
                      Left = 520
                      Top = 7
                      Width = 185
                      Height = 39
                      Caption = 'Visualizar detalhes:'
                      Columns = 2
                      ItemIndex = 1
                      Items.Strings = (
                        'Sim'
                        'N'#227'o')
                      TabOrder = 5
                    end
                    object DBEditMES: TDBEdit
                      Left = 259
                      Top = 23
                      Width = 65
                      Height = 21
                      DataField = 'TEMPO_CONSOLIDADO_MES'
                      DataSource = DsCadastro
                      TabOrder = 2
                    end
                    object DBEditDIA: TDBEdit
                      Left = 331
                      Top = 23
                      Width = 65
                      Height = 21
                      DataField = 'TEMPO_CONSOLIDADO_DIA'
                      DataSource = DsCadastro
                      TabOrder = 3
                    end
                    object DBCheckBox1: TDBCheckBox
                      Left = 408
                      Top = 24
                      Width = 97
                      Height = 17
                      Caption = 'Calculo Manual'
                      DataSource = DsCadastro
                      TabOrder = 4
                      ValueChecked = 'True'
                      ValueUnchecked = 'False'
                      Visible = False
                    end
                  end
                end
                object TabSheet7: TTabSheet
                  Caption = 'Condena'#231#245'es'
                  ImageIndex = 86
                  object DBGrid6: TDBGrid
                    Left = 0
                    Top = 0
                    Width = 907
                    Height = 322
                    Align = alClient
                    DataSource = DsCondenacao
                    Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgConfirmDelete, dgCancelOnExit]
                    ReadOnly = True
                    TabOrder = 0
                    TitleFont.Charset = DEFAULT_CHARSET
                    TitleFont.Color = clWindowText
                    TitleFont.Height = -11
                    TitleFont.Name = 'MS Sans Serif'
                    TitleFont.Style = []
                    OnDrawColumnCell = DBGridConsultaDrawColumnCell
                    OnDblClick = DBGridConsultaDblClick
                    OnKeyDown = DBGridConsultaKeyDown
                    OnTitleClick = DBGridConsultaTitleClick
                    Columns = <
                      item
                        Expanded = False
                        FieldName = 'NUMERO_INQUERITO'
                        Title.Caption = 'Inqu'#233'rito'
                        Width = 100
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DATA_PRISAO'
                        Title.Caption = 'Data Pris'#227'o'
                        Width = 100
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'NPROCESSO'
                        Title.Caption = 'Processo'
                        Width = 100
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DATA_INICIO_CONDENACAO'
                        Title.Caption = 'Inicio Condena'#231#227'o'
                        Width = 100
                        Visible = True
                      end>
                  end
                end
                object TabSheet8: TTabSheet
                  Caption = 'Detra'#231#227'o'
                  ImageIndex = 83
                  object DBGrid7: TDBGrid
                    Left = 0
                    Top = 0
                    Width = 907
                    Height = 322
                    Align = alClient
                    DataSource = DsDetracao
                    Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgConfirmDelete, dgCancelOnExit]
                    ReadOnly = True
                    TabOrder = 0
                    TitleFont.Charset = DEFAULT_CHARSET
                    TitleFont.Color = clWindowText
                    TitleFont.Height = -11
                    TitleFont.Name = 'MS Sans Serif'
                    TitleFont.Style = []
                    OnDrawColumnCell = DBGridConsultaDrawColumnCell
                    OnDblClick = DBGridConsultaDblClick
                    OnKeyDown = DBGridConsultaKeyDown
                    OnTitleClick = DBGridConsultaTitleClick
                    Columns = <
                      item
                        Expanded = False
                        FieldName = 'NUMERO_DOCUMENTO'
                        Title.Caption = 'Documento'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DATA_INICIAL'
                        Title.Caption = 'Data Inicial'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DATA_FINAL'
                        Title.Caption = 'Data Final'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'ANO'
                        Title.Caption = 'Ano'
                        Width = 40
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'MES'
                        Title.Caption = 'M'#234's'
                        Width = 40
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DIA'
                        Title.Caption = 'Dia'
                        Width = 40
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'MOTIVO'
                        Title.Caption = 'Motivo'
                        Width = 130
                        Visible = True
                      end>
                  end
                end
                object TabSheet10: TTabSheet
                  Caption = 'Interrup'#231#227'o'
                  ImageIndex = 2
                  object DBGrid8: TDBGrid
                    Left = 0
                    Top = 0
                    Width = 907
                    Height = 322
                    Align = alClient
                    DataSource = DsInterrupcao
                    Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgConfirmDelete, dgCancelOnExit]
                    ReadOnly = True
                    TabOrder = 0
                    TitleFont.Charset = DEFAULT_CHARSET
                    TitleFont.Color = clWindowText
                    TitleFont.Height = -11
                    TitleFont.Name = 'MS Sans Serif'
                    TitleFont.Style = []
                    OnDrawColumnCell = DBGridConsultaDrawColumnCell
                    OnDblClick = DBGridConsultaDblClick
                    OnKeyDown = DBGridConsultaKeyDown
                    OnTitleClick = DBGridConsultaTitleClick
                    Columns = <
                      item
                        Expanded = False
                        FieldName = 'NUMERO_DOCUMENTO'
                        Title.Caption = 'Documento'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DATA_INICIAL'
                        Title.Caption = 'Data Inicial'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DATA_FINAL'
                        Title.Caption = 'Data Final'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'ANO'
                        Title.Caption = 'Ano'
                        Width = 40
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'MES'
                        Title.Caption = 'M'#234's'
                        Width = 40
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DIA'
                        Title.Caption = 'Dia'
                        Width = 40
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'MOTIVO'
                        Title.Caption = 'Motivo'
                        Width = 130
                        Visible = True
                      end>
                  end
                end
                object TabSheet11: TTabSheet
                  Caption = 'Remi'#231#227'o'
                  ImageIndex = 18
                  object DBGrid9: TDBGrid
                    Left = 0
                    Top = 0
                    Width = 907
                    Height = 322
                    Align = alClient
                    DataSource = DsRemicao
                    Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgConfirmDelete, dgCancelOnExit]
                    ReadOnly = True
                    TabOrder = 0
                    TitleFont.Charset = DEFAULT_CHARSET
                    TitleFont.Color = clWindowText
                    TitleFont.Height = -11
                    TitleFont.Name = 'MS Sans Serif'
                    TitleFont.Style = []
                    OnDrawColumnCell = DBGridConsultaDrawColumnCell
                    OnDblClick = DBGridConsultaDblClick
                    OnKeyDown = DBGridConsultaKeyDown
                    OnTitleClick = DBGridConsultaTitleClick
                    Columns = <
                      item
                        Expanded = False
                        FieldName = 'NUMERO_DOCUMENTO'
                        Title.Caption = 'Documento'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DIAS_REMIDOS'
                        Title.Caption = 'Dias Remidos'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'MOTIVO'
                        Title.Caption = 'Motivo'
                        Width = 300
                        Visible = True
                      end>
                  end
                end
                object TabSheet6: TTabSheet
                  Caption = 'Formula'#231#227'o'
                  TabVisible = False
                  object DBGrid1: TDBGrid
                    Left = 0
                    Top = 0
                    Width = 907
                    Height = 322
                    Align = alClient
                    DataSource = DsCalculoPena
                    Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgConfirmDelete, dgCancelOnExit]
                    ReadOnly = True
                    TabOrder = 0
                    TitleFont.Charset = DEFAULT_CHARSET
                    TitleFont.Color = clWindowText
                    TitleFont.Height = -11
                    TitleFont.Name = 'MS Sans Serif'
                    TitleFont.Style = []
                    Columns = <
                      item
                        Expanded = False
                        FieldName = 'DATA_PRISAO'
                        Title.Caption = 'Pris'#227'o Definitiva'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'TIPO'
                        Title.Caption = 'Tipo de refer'#234'ncia'
                        Width = 250
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'TOTAL_PENA_ANO'
                        Title.Caption = 'Pena Ano'
                        Width = 60
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'TOTAL_PENA_MES'
                        Title.Caption = 'Pena M'#234's'
                        Width = 60
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'TOTAL_PENA_DIA'
                        Title.Caption = 'Pena Dia'
                        Width = 60
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DATA_TERMINO_PENA'
                        Title.Caption = 'Termino Pena'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'ANO_PROGRESSAO'
                        Title.Caption = 'Ano RTP'
                        Width = 60
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'MES_PROGRESSAO'
                        Title.Caption = 'M'#234's RTP'
                        Width = 60
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DIA_PROGRESSAO'
                        Title.Caption = 'Dia RTP'
                        Width = 60
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DATA_PROGRESSAO'
                        Title.Caption = 'Data do RTP'
                        Width = 80
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'ANO_CONDICIONAL'
                        Title.Caption = 'Ano RTC'
                        Width = 60
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'MES_CONDICIONAL'
                        Title.Caption = 'M'#234's RTC'
                        Width = 60
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DIA_CONDICIONAL'
                        Title.Caption = 'Dia RTC'
                        Width = 60
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'DATA_CONDICIONAL'
                        Title.Caption = 'Data para RTC'
                        Width = 80
                        Visible = True
                      end>
                  end
                end
                object TabSheet13: TTabSheet
                  Caption = 'Mapa Carcer'#225'rio'
                  ImageIndex = 125
                  object Label42: TLabel
                    Left = 258
                    Top = 11
                    Width = 25
                    Height = 13
                    Caption = 'Pena'
                  end
                  object Label50: TLabel
                    Left = 287
                    Top = 11
                    Width = 19
                    Height = 13
                    Caption = 'Ano'
                  end
                  object Label51: TLabel
                    Left = 354
                    Top = 11
                    Width = 20
                    Height = 13
                    Caption = 'M'#234's'
                  end
                  object Label53: TLabel
                    Left = 421
                    Top = 11
                    Width = 16
                    Height = 13
                    Caption = 'Dia'
                  end
                  object DBEdit21: TDBEdit
                    Left = 287
                    Top = 27
                    Width = 65
                    Height = 21
                    DataField = 'TEMPO_CONSOLIDADO_ANO'
                    DataSource = DsCadastro
                    TabOrder = 1
                  end
                  object DBEdit36: TDBEdit
                    Left = 354
                    Top = 27
                    Width = 65
                    Height = 21
                    DataField = 'TEMPO_CONSOLIDADO_MES'
                    DataSource = DsCadastro
                    TabOrder = 2
                  end
                  object DBEdit37: TDBEdit
                    Left = 421
                    Top = 27
                    Width = 65
                    Height = 21
                    DataField = 'TEMPO_CONSOLIDADO_DIA'
                    DataSource = DsCadastro
                    TabOrder = 3
                  end
                  object DBComboBox6: TDBComboBox
                    Left = 18
                    Top = 29
                    Width = 239
                    Height = 21
                    Style = csDropDownList
                    DataField = 'REGIME_ATUAL'
                    DataSource = DsCadastro
                    ItemHeight = 13
                    Items.Strings = (
                      'Fechado'
                      'Semi-Aberto Sem Saida'
                      'Semi-Aberto Com Trabalho Externo'
                      'Semi-Aberto Com Saida'
                      'Semi-Aberto Com Trabalho Externo e Sa'#237'da')
                    TabOrder = 0
                  end
                end
                object TabSheet14: TTabSheet
                  Caption = 'Comuta'#231#227'o'
                  ImageIndex = 135
                  object DBGrid10: TDBGrid
                    Left = 0
                    Top = 0
                    Width = 907
                    Height = 322
                    Align = alClient
                    DataSource = DsComutacao
                    ReadOnly = True
                    TabOrder = 0
                    TitleFont.Charset = DEFAULT_CHARSET
                    TitleFont.Color = clWindowText
                    TitleFont.Height = -11
                    TitleFont.Name = 'MS Sans Serif'
                    TitleFont.Style = []
                    Columns = <
                      item
                        Expanded = False
                        FieldName = 'DATA_LIBERACAO'
                        Title.Caption = 'Libera'#231#227'o'
                        Width = 100
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'TIPO_COMUTACAO'
                        Title.Caption = 'Tipo'
                        Width = 200
                        Visible = True
                      end
                      item
                        Expanded = False
                        FieldName = 'VARA'
                        Title.Caption = 'Vara'
                        Width = 200
                        Visible = True
                      end>
                  end
                end
              end
              object BitBtn7: TBitBtn
                Left = 742
                Top = 41
                Width = 175
                Height = 43
                Caption = 'Comuta'#231#227'o'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clNavy
                Font.Height = -19
                Font.Name = 'Times New Roman'
                Font.Style = []
                ParentFont = False
                TabOrder = 4
                TabStop = False
                OnClick = BitBtn7Click
                Glyph.Data = {}
                Style = bsWin31
              end
            end
            object TabSheet5: TTabSheet
              Caption = 'Benef'#237'cio'
              ImageIndex = 5
              object Label61: TLabel
                Left = 16
                Top = 24
                Width = 23
                Height = 13
                Caption = 'Data'
              end
              object Label62: TLabel
                Left = 160
                Top = 24
                Width = 46
                Height = 13
                Caption = 'Benef'#237'cio'
              end
              object Label70: TLabel
                Left = 16
                Top = 64
                Width = 51
                Height = 13
                Caption = 'Concedido'
              end
              object Label76: TLabel
                Left = 19
                Top = 112
                Width = 19
                Height = 13
                Caption = 'Obs'
              end
              object Label77: TLabel
                Left = 288
                Top = 410
                Width = 356
                Height = 20
                Caption = 'DUPLO CLIQUE PARA EDITAR BENEF'#205'CIO'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clRed
                Font.Height = -16
                Font.Name = 'MS Sans Serif'
                Font.Style = [fsBold]
                ParentFont = False
              end
              object Editconcedido: TEdit
                Left = 16
                Top = 80
                Width = 417
                Height = 21
                TabOrder = 2
              end
              object Memoobsbeneficio: TMemo
                Left = 17
                Top = 132
                Width = 416
                Height = 89
                Lines.Strings = (
                  '')
                TabOrder = 3
              end
              object ComboBoxbeneficio: TComboBox
                Left = 160
                Top = 40
                Width = 273
                Height = 21
                Style = csDropDownList
                ItemHeight = 13
                TabOrder = 1
                Items.Strings = (
                  'Livramento Condicional'
                  'Pris'#227'o Domiciliar'
                  'Progress'#227'o de Regime'
                  'Progress'#227'o de Regime/Trabalho Externo'
                  'Prog. Regime/Trab. Ext./Sa'#237'da Temp.'
                  'Sa'#237'das Tempor'#225'rias/Trabalho Externo'
                  'Sa'#237'da Tempor'#225'ria'
                  'Trabalho Externo')
              end
              object DateTimePickerdtbeneficio: TDateTimePicker
                Left = 17
                Top = 40
                Width = 129
                Height = 21
                Date = 41072.458390775460000000
                Time = 41072.458390775460000000
                TabOrder = 0
              end
              object DBGrid4: TDBGrid
                Left = 16
                Top = 272
                Width = 665
                Height = 120
                DataSource = dsbeneficio
                TabOrder = 5
                TitleFont.Charset = DEFAULT_CHARSET
                TitleFont.Color = clWindowText
                TitleFont.Height = -11
                TitleFont.Name = 'MS Sans Serif'
                TitleFont.Style = []
                OnDblClick = DBGrid4DblClick
                Columns = <
                  item
                    Expanded = False
                    FieldName = 'DATA_BENEFICIO'
                    Title.Caption = 'Data'
                    Width = 81
                    Visible = True
                  end
                  item
                    Expanded = False
                    FieldName = 'BENEFICIO'
                    Title.Caption = 'Benef'#237'cio'
                    Width = 182
                    Visible = True
                  end
                  item
                    Expanded = False
                    FieldName = 'CONCEDIDO'
                    Title.Caption = 'Concedido'
                    Width = 102
                    Visible = True
                  end
                  item
                    Expanded = False
                    FieldName = 'DATA_REVOGACAO'
                    Title.Caption = 'Data Revoga'#231'ao'
                    Width = 89
                    Visible = True
                  end
                  item
                    Expanded = False
                    FieldName = 'MOTIVO_REVOGACAO'
                    Title.Caption = 'Motivo Revoga'#231'ao'
                    Width = 191
                    Visible = True
                  end
                  item
                    Expanded = False
                    FieldName = 'OBS'
                    Width = 174
                    Visible = True
                  end>
              end
              object Button1: TButton
                Left = 144
                Top = 232
                Width = 75
                Height = 25
                Caption = 'Inserir'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -13
                Font.Name = 'MS Sans Serif'
                Font.Style = [fsBold]
                ParentFont = False
                TabOrder = 4
                OnClick = Button1Click
              end
              object DBMemo1: TDBMemo
                Left = 685
                Top = 271
                Width = 193
                Height = 103
                DataField = 'OBS'
                DataSource = dsbeneficio
                TabOrder = 6
              end
            end
          end
        end
      end
      inherited TabSheetConsulta: TTabSheet
        inherited PanelLocalizaConsulta: TPanel
          Width = 948
          inherited EditLocalizar: TEdit
            TabOrder = 1
          end
          inherited RadioGroupStatus: TRadioGroup
            Left = 811
            TabOrder = 3
          end
          inherited chkSoundex: TCheckBox
            TabOrder = 2
          end
        end
        inherited PanelConsulta: TPanel
          Width = 948
          Height = 449
          inherited DBGridConsulta: TDBGrid
            Width = 938
            Height = 435
          end
          inherited DBCtrlGridConsulta: TDBCtrlGrid
            Width = 937
            Height = 435
            PanelHeight = 87
            PanelWidth = 921
          end
        end
      end
    end
  end
  inherited PanelTituloModeloCadastro: TPanel
    Width = 956
    inherited Image2: TImage
      Width = 956
    end
  end
  inherited StatusBar1: TStatusBar
    Top = 591
    Width = 956
  end
  inherited ImageListCadastro: TImageList
    Left = 608
    Top = 65528
  end
  inherited SqlCadastro: TSQLQuery
    Left = 448
    Top = 0
  end
  inherited DspCadastro: TDataSetProvider
    Left = 476
    Top = 0
  end
  inherited CdsCadastro: TClientDataSet
    Left = 504
    Top = 0
  end
  inherited DsCadastro: TDataSource
    Left = 532
    Top = 0
  end
  inherited DsConsulta: TDataSource
    Left = 821
  end
  inherited CdsConsulta: TClientDataSet
    Left = 793
  end
  inherited DspConsulta: TDataSetProvider
    Left = 765
  end
  inherited SqlConsulta: TSQLQuery
    Left = 737
  end
  object SQLHISTORICO_interno: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'id_interno'
        ParamType = ptInput
      end>
    SQL.Strings = (
      'select *'
      'from historico_interno'
      'where idinterno=:id_interno '
      'and coalesce(tipo_historico,'#39#39')='#39#39' '
      'and (setor = '#39'Jur'#237'dico'#39' or setor like '#39'Monitor%'#39')'
      'order by data_hora desc')
    SQLConnection = DM.SQLConnect
    Left = 585
    Top = 465
  end
  object DSPHISTORICO_interno: TDataSetProvider
    DataSet = SQLHISTORICO_interno
    Left = 613
    Top = 465
  end
  object CDSHISTORICO_interno: TClientDataSet
    Aggregates = <>
    IndexFieldNames = 'IDINTERNO'
    MasterFields = 'ID_INTERNO'
    MasterSource = DsCadastro
    PacketRecords = 0
    Params = <>
    ProviderName = 'DSPHISTORICO_interno'
    AfterInsert = CDSHISTORICO_internoAfterInsert
    Left = 641
    Top = 465
    object CDSHISTORICO_internoFuncionrio: TStringField
      FieldKind = fkLookup
      FieldName = 'Funcion'#225'rio'
      LookupDataSet = DM.CdsFuncionarioLista
      LookupKeyFields = 'ID_FUNCIONARIO'
      LookupResultField = 'NOME_FUNCIONARIO'
      KeyFields = 'ID_FUNCIONARIO'
      Size = 100
      Lookup = True
    end
    object CDSHISTORICO_internoIDHISTORICO_INTERNO: TIntegerField
      FieldName = 'IDHISTORICO_INTERNO'
      Required = True
    end
    object CDSHISTORICO_internoDESCRICAO: TStringField
      FieldName = 'DESCRICAO'
      Required = True
      Size = 16386
    end
    object CDSHISTORICO_internoDATA_HORA: TSQLTimeStampField
      FieldName = 'DATA_HORA'
      Required = True
    end
    object CDSHISTORICO_internoIDINTERNO: TIntegerField
      FieldName = 'IDINTERNO'
      Required = True
    end
    object CDSHISTORICO_internoSTATUS: TStringField
      FieldName = 'STATUS'
      Size = 1
    end
    object CDSHISTORICO_internoMOTIVO_SAIDA: TStringField
      FieldName = 'MOTIVO_SAIDA'
      Size = 50
    end
    object CDSHISTORICO_internoIDPROCEDENCIA: TIntegerField
      FieldName = 'IDPROCEDENCIA'
    end
    object CDSHISTORICO_internoIDUP: TIntegerField
      FieldName = 'IDUP'
    end
    object CDSHISTORICO_internoSETOR: TStringField
      FieldName = 'SETOR'
      Size = 50
    end
    object CDSHISTORICO_internoID_FUNCIONARIO: TIntegerField
      FieldName = 'ID_FUNCIONARIO'
    end
    object CDSHISTORICO_internoTIPO_HISTORICO: TStringField
      FieldName = 'TIPO_HISTORICO'
      Size = 30
    end
  end
  object DSHISTORICO_interno: TDataSource
    DataSet = CDSHISTORICO_interno
    OnDataChange = DsCadastroDataChange
    Left = 669
    Top = 465
  end
  object SqlDsControlePermanencia: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'id_interno'
        ParamType = ptInput
      end>
    SQL.Strings = (
      'SELECT'
      ''
      'ID_CONTROLE_PERMANENCIA,'
      'DATA_INICIAL,'
      'DATA_FINAL,'
      'AUTORIZACAO,'
      'OBS,'
      'ID_INTERNO,'
      'DIASAUTORIZADOS,'
      'NAUTOS,'
      'AVISADO,'
      'CONFLITO_COMPETENCIA,'
      'NUM_CONFLITO_COMPETENCIA,'
      'OBS_CONFLITO_COMPETENCIA,'
      'CONFLITO_STATUS,'
      'OFICIO_PRAZO,'
      'NUM_OFICIO_PRAZO'
      ''
      'from controle_permanencia'
      'where id_interno = :id_interno'
      'order by data_final desc')
    SQLConnection = DM.SQLConnect
    Left = 16
    Top = 368
  end
  object DspDsControlePermanencia: TDataSetProvider
    DataSet = SqlDsControlePermanencia
    Left = 44
    Top = 368
  end
  object CdsDsControlePermanencia: TClientDataSet
    Aggregates = <>
    IndexFieldNames = 'ID_INTERNO'
    MasterFields = 'ID_INTERNO'
    MasterSource = DsCadastro
    PacketRecords = 0
    Params = <>
    ProviderName = 'DspDsControlePermanencia'
    AfterInsert = CdsDsControlePermanenciaAfterInsert
    AfterPost = CdsDsControlePermanenciaAfterPost
    Left = 72
    Top = 368
  end
  object DsControlePermanencia: TDataSource
    DataSet = CdsDsControlePermanencia
    OnDataChange = DsControlePermanenciaDataChange
    Left = 100
    Top = 368
  end
  object SqlPermanenciaScaner: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'id_controle_permanencia'
        ParamType = ptInput
      end>
    SQL.Strings = (
      'select * from permanencia_scaner'
      'where id_controle_permanencia = :id_controle_permanencia'
      '')
    SQLConnection = DM.SQLConnect
    Left = 152
    Top = 336
  end
  object DspPermanenciaScaner: TDataSetProvider
    DataSet = SqlPermanenciaScaner
    Left = 180
    Top = 336
  end
  object CdsPermanenciaScaner: TClientDataSet
    Aggregates = <>
    IndexFieldNames = 'ID_CONTROLE_PERMANENCIA'
    MasterFields = 'ID_CONTROLE_PERMANENCIA'
    MasterSource = DsControlePermanencia
    PacketRecords = 0
    Params = <>
    ProviderName = 'DspPermanenciaScaner'
    AfterInsert = CdsPermanenciaScanerAfterInsert
    Left = 208
    Top = 336
  end
  object DsPermanenciaScaner: TDataSource
    DataSet = CdsPermanenciaScaner
    OnDataChange = DsPermanenciaScanerDataChange
    Left = 236
    Top = 336
  end
  object OpenDialog1: TOpenDialog
    Filter = 'Imagens (*.jpg)|*.jpg'
    Left = 559
    Top = 65528
  end
  object OpenDialogDoc: TOpenDialog
    Left = 359
    Top = 8
  end
  object SaveDialogDoc: TSaveDialog
    Left = 304
    Top = 8
  end
  object DsCalculoPena: TDataSource
    DataSet = CdsCalculoPena
    OnDataChange = DsPermanenciaScanerDataChange
    Left = 912
    Top = 128
  end
  object CdsCalculoPena: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DspCalculoPena'
    AfterInsert = CdsPermanenciaScanerAfterInsert
    Left = 880
    Top = 128
  end
  object DspCalculoPena: TDataSetProvider
    DataSet = SqlCalculoPena
    Left = 848
    Top = 128
  end
  object SqlCalculoPena: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'ID_INTERNO'
        ParamType = ptInput
        Value = 0
      end
      item
        DataType = ftDateTime
        Name = 'DATA_PRISAO'
        ParamType = ptInput
        Value = 0d
      end
      item
        DataType = ftDateTime
        Name = 'data_base_p'
        ParamType = ptInput
        Value = 0d
      end
      item
        DataType = ftDateTime
        Name = 'data_base_c'
        ParamType = ptInput
        Value = 0d
      end>
    SQL.Strings = (
      
        'select * from SP_CALCULO_EXECUCAO_PENAL (:ID_INTERNO,:DATA_PRISA' +
        'O,:data_base_p,:data_base_c)')
    SQLConnection = DM.SQLConnect
    Left = 816
    Top = 128
  end
  object SQLbeneficio: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'id'
        ParamType = ptInput
        Value = -1
      end>
    SQL.Strings = (
      'select * from beneficio'
      'where id_interno = :id'
      'order by data_beneficio desc')
    SQLConnection = DM.SQLConnect
    Left = 632
    Top = 128
  end
  object DSPbeneficio: TDataSetProvider
    DataSet = SQLbeneficio
    Left = 664
    Top = 128
  end
  object cdsbeneficio: TClientDataSet
    Aggregates = <>
    IndexFieldNames = 'ID_INTERNO'
    MasterFields = 'ID_INTERNO'
    MasterSource = DsCadastro
    PacketRecords = 0
    Params = <>
    ProviderName = 'DSPbeneficio'
    Left = 696
    Top = 128
    object cdsbeneficioID_BENEFICIOS: TIntegerField
      FieldName = 'ID_BENEFICIOS'
      Required = True
    end
    object cdsbeneficioBENEFICIO: TStringField
      FieldName = 'BENEFICIO'
      Size = 100
    end
    object cdsbeneficioDATA_BENEFICIO: TSQLTimeStampField
      FieldName = 'DATA_BENEFICIO'
    end
    object cdsbeneficioCONCEDIDO: TStringField
      FieldName = 'CONCEDIDO'
      Size = 100
    end
    object cdsbeneficioDATA_REVOGACAO: TSQLTimeStampField
      FieldName = 'DATA_REVOGACAO'
    end
    object cdsbeneficioMOTIVO_REVOGACAO: TStringField
      FieldName = 'MOTIVO_REVOGACAO'
      Size = 100
    end
    object cdsbeneficioOBS: TStringField
      FieldName = 'OBS'
      Size = 200
    end
    object cdsbeneficioID_INTERNO: TIntegerField
      FieldName = 'ID_INTERNO'
    end
  end
  object dsbeneficio: TDataSource
    DataSet = cdsbeneficio
    Left = 728
    Top = 128
  end
  object SqlCondenacao: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'idinterno'
        ParamType = ptInput
        Value = 0
      end>
    SQL.Strings = (
      'select *'
      'from processo'
      'where idinterno=:idinterno'
      'and upper(SITUACAOJURIDICA) like '#39'COND%'#39)
    SQLConnection = DM.SQLConnect
    Left = 281
    Top = 371
  end
  object DspCondenacao: TDataSetProvider
    DataSet = SqlCondenacao
    Left = 309
    Top = 371
  end
  object CdsCondenacao: TClientDataSet
    Aggregates = <>
    IndexFieldNames = 'IDINTERNO'
    MasterFields = 'ID_INTERNO'
    MasterSource = DsCadastro
    PacketRecords = 0
    Params = <>
    ProviderName = 'DspCondenacao'
    AfterInsert = CDSHISTORICO_internoAfterInsert
    Left = 337
    Top = 371
  end
  object DsCondenacao: TDataSource
    DataSet = CdsCondenacao
    OnDataChange = DsCadastroDataChange
    Left = 365
    Top = 371
  end
  object SqlDetracao: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'id_interno'
        ParamType = ptInput
      end>
    SQL.Strings = (
      'select *'
      'from detracao'
      'where id_interno=:id_interno'
      '')
    SQLConnection = DM.SQLConnect
    Left = 385
    Top = 334
  end
  object DspDetracao: TDataSetProvider
    DataSet = SqlDetracao
    Left = 413
    Top = 334
  end
  object CdsDetracao: TClientDataSet
    Aggregates = <>
    IndexFieldNames = 'ID_INTERNO'
    MasterFields = 'ID_INTERNO'
    MasterSource = DsCadastro
    PacketRecords = 0
    Params = <>
    ProviderName = 'DSPDetracao'
    AfterInsert = CDSHISTORICO_internoAfterInsert
    Left = 441
    Top = 334
  end
  object DsDetracao: TDataSource
    DataSet = CdsDetracao
    OnDataChange = DsCadastroDataChange
    Left = 469
    Top = 334
  end
  object SqlInterrupcao: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'id_interno'
        ParamType = ptInput
      end>
    SQL.Strings = (
      'select *'
      'from interrupcao'
      'where id_interno=:id_interno'
      '')
    SQLConnection = DM.SQLConnect
    Left = 297
    Top = 474
  end
  object DspInterrupcao: TDataSetProvider
    DataSet = SqlInterrupcao
    Left = 325
    Top = 474
  end
  object CdsInterrupcao: TClientDataSet
    Aggregates = <>
    IndexFieldNames = 'ID_INTERNO'
    MasterFields = 'ID_INTERNO'
    MasterSource = DsCadastro
    PacketRecords = 0
    Params = <>
    ProviderName = 'DSPInterrupcao'
    AfterInsert = CDSHISTORICO_internoAfterInsert
    Left = 353
    Top = 474
  end
  object DsInterrupcao: TDataSource
    DataSet = CdsInterrupcao
    OnDataChange = DsCadastroDataChange
    Left = 381
    Top = 474
  end
  object SqlRemicao: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'id_interno'
        ParamType = ptInput
      end>
    SQL.Strings = (
      'select *'
      'from remicao'
      'where id_interno=:id_interno'
      '')
    SQLConnection = DM.SQLConnect
    Left = 433
    Top = 477
  end
  object DspRemicao: TDataSetProvider
    DataSet = SqlRemicao
    Left = 461
    Top = 477
  end
  object CdsRemicao: TClientDataSet
    Aggregates = <>
    IndexFieldNames = 'ID_INTERNO'
    MasterFields = 'ID_INTERNO'
    MasterSource = DsCadastro
    PacketRecords = 0
    Params = <>
    ProviderName = 'DSPRemicao'
    AfterInsert = CDSHISTORICO_internoAfterInsert
    Left = 489
    Top = 477
  end
  object DsRemicao: TDataSource
    DataSet = CdsRemicao
    OnDataChange = DsCadastroDataChange
    Left = 517
    Top = 477
  end
  object SqlLinhaTempo: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'id_interno'
        ParamType = ptInput
      end
      item
        DataType = ftString
        Name = 'ver_linha'
        ParamType = ptUnknown
        Value = 'N'
      end>
    SQL.Strings = (
      'select *'
      'from sp_linha_tempo(:id_interno,:ver_linha)'
      ''
      '')
    SQLConnection = DM.SQLConnect
    Left = 729
    Top = 61
  end
  object DspLinhaTempo: TDataSetProvider
    DataSet = SqlLinhaTempo
    Left = 757
    Top = 61
  end
  object CdsLinhaTempo: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DSPLinhaTempo'
    Left = 785
    Top = 61
  end
  object DsLinhaTempo: TDataSource
    DataSet = CdsLinhaTempo
    OnDataChange = DsCadastroDataChange
    Left = 813
    Top = 61
  end
  object DsComutacao: TDataSource
    DataSet = CdsComutacao
    Left = 672
    Top = 56
  end
  object CdsComutacao: TClientDataSet
    Aggregates = <>
    IndexFieldNames = 'ID_INTERNO'
    MasterFields = 'ID_INTERNO'
    MasterSource = DsCadastro
    PacketRecords = 0
    Params = <>
    ProviderName = 'DspComutacao'
    Left = 640
    Top = 56
  end
  object DspComutacao: TDataSetProvider
    DataSet = SqlComutacao
    Left = 608
    Top = 56
  end
  object SqlComutacao: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'ID_INTERNO'
        ParamType = ptInput
        Value = 0
      end>
    SQL.Strings = (
      'SELECT '
      'V.IDPROCESSO,'
      'C.DATA_LIBERACAO,C.TIPO_COMUTACAO,C.VARA'
      ',C.ID_INTERNO'
      'FROM COMUTACAO C'
      'JOIN VINC_COMUTACAO V ON (V.ID_COMUTACAO=C.ID_COMUTACAO)'
      'WHERE C.ID_INTERNO=:ID_INTERNO')
    SQLConnection = DM.SQLConnect
    Left = 576
    Top = 56
  end
end
