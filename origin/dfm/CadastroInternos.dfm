inherited FrmCadastroInternos: TFrmCadastroInternos
  Left = 561
  Top = 163
  Width = 940
  Height = 663
  Caption = 'Cadastro de Internos(as)'
  Menu = MainMenu1
  OldCreateOrder = True
  PixelsPerInch = 96
  TextHeight = 13
  object Label59: TLabel [0]
    Left = 616
    Top = 301
    Width = 87
    Height = 13
    Caption = 'Orienta'#231#227'o Sexual'
  end
  inherited PanelBotoes: TPanel
    Height = 566
    inherited ToolBarModeloCadastro: TToolBar
      Height = 548
      PopupMenu = PopupMenuRecuperarFotoEmergencia
      inherited Novo: TToolButton
        Visible = False
      end
    end
    inherited DBNavigator1: TDBNavigator
      Top = 548
      DataSource = DsConsulta
      Hints.Strings = ()
    end
  end
  inherited PanelModeloCadastro: TPanel
    Width = 817
    Height = 566
    inherited PageControlModeloCadastro: TPageControl
      Width = 817
      Height = 566
      inherited TabSheetCadastro: TTabSheet
        inherited PanelCadastro: TPanel
          Width = 809
          Height = 538
          object SpeedButton3: TSpeedButton
            Left = 288
            Top = 136
            Width = 23
            Height = 22
          end
          object SpeedButton10: TSpeedButton
            Left = 224
            Top = 16
            Width = 23
            Height = 22
          end
          object PageControlInterno: TPageControl
            Left = 1
            Top = 1
            Width = 807
            Height = 536
            ActivePage = TabSheet1
            Align = alClient
            TabOrder = 0
            TabWidth = 80
            OnChange = PageControlInternoChange
            object TabSheet1: TTabSheet
              Caption = 'Principal'
              object Label2: TLabel
                Left = 149
                Top = 9
                Width = 11
                Height = 13
                Caption = 'ID'
                FocusControl = DBEditCodigo
              end
              object Label3: TLabel
                Left = 231
                Top = 9
                Width = 33
                Height = 13
                Caption = 'Interno'
                FocusControl = DBEdit2
              end
              object Label4: TLabel
                Left = 269
                Top = 55
                Width = 76
                Height = 13
                Caption = 'RGI (Prontu'#225'rio)'
                FocusControl = DBEdit3
              end
              object Label10: TLabel
                Left = 149
                Top = 136
                Width = 63
                Height = 13
                Caption = 'Data Entrada'
              end
              object Label12: TLabel
                Left = 8
                Top = 303
                Width = 60
                Height = 13
                Caption = 'Proced'#234'ncia'
              end
              object Label40: TLabel
                Left = 238
                Top = 136
                Width = 55
                Height = 13
                Caption = 'Data Pris'#227'o'
                FocusControl = DBEditdtprisao
              end
              object SpeedButton1: TSpeedButton
                Left = 273
                Top = 319
                Width = 23
                Height = 22
                Hint = 'Cadastrar Procedencia'
                Caption = '...'
                Flat = True
                ParentShowHint = False
                ShowHint = True
                Visible = False
                OnClick = SpeedButton1Click
              end
              object Label45: TLabel
                Left = 7
                Top = 345
                Width = 96
                Height = 13
                Caption = 'Condi'#231#227'o do Interno'
                Visible = False
              end
              object Label43: TLabel
                Left = 616
                Top = 270
                Width = 29
                Height = 13
                Caption = 'ID UP'
                FocusControl = DBEdit7
                Visible = False
              end
              object Label46: TLabel
                Left = 10
                Top = 262
                Width = 70
                Height = 13
                Caption = 'Unidade Penal'
              end
              object SpeedButton2: TSpeedButton
                Left = 273
                Top = 358
                Width = 23
                Height = 22
                Hint = 'Cadastrar Procedencia'
                Caption = '...'
                Flat = True
                ParentShowHint = False
                ShowHint = True
                Visible = False
                OnClick = SpeedButton2Click
              end
              object Label27: TLabel
                Left = 149
                Top = 96
                Width = 57
                Height = 13
                Caption = 'Outro Nome'
                FocusControl = DBEdit24
              end
              object Label36: TLabel
                Left = 432
                Top = 96
                Width = 27
                Height = 13
                Caption = 'Vulgo'
                FocusControl = DBEdit25
              end
              object Label55: TLabel
                Left = 431
                Top = 135
                Width = 69
                Height = 13
                Caption = 'CI/OF Entrada'
                FocusControl = DBEdit29
              end
              object Label65: TLabel
                Left = 168
                Top = 180
                Width = 73
                Height = 13
                Caption = 'NOME SOCIAL'
                FocusControl = DBEdit35
              end
              object Label66: TLabel
                Left = 8
                Top = 221
                Width = 87
                Height = 13
                Caption = 'Orienta'#231#227'o Sexual'
              end
              object Label163: TLabel
                Left = 305
                Top = 343
                Width = 82
                Height = 13
                Caption = 'Cargo na Fac'#231#227'o'
              end
              object lbl1: TLabel
                Left = 149
                Top = 57
                Width = 51
                Height = 13
                Caption = 'N'#186' Infopen'
                FocusControl = DBEdit86
              end
              object Label38: TLabel
                Left = 8
                Top = 179
                Width = 66
                Height = 13
                Caption = 'Regime Inicial'
              end
              object Label49: TLabel
                Left = 327
                Top = 136
                Width = 88
                Height = 13
                Caption = 'Data Perman'#234'ncia'
              end
              object Label62: TLabel
                Left = 317
                Top = 261
                Width = 62
                Height = 13
                Caption = 'N'#186' da Roupa'
                FocusControl = DBEdit19
              end
              object Label78: TLabel
                Left = 7
                Top = 427
                Width = 30
                Height = 13
                Caption = 'Ano(s)'
              end
              object Label79: TLabel
                Left = 74
                Top = 427
                Width = 37
                Height = 13
                Caption = 'M'#234's(es)'
              end
              object Label80: TLabel
                Left = 141
                Top = 427
                Width = 27
                Height = 13
                Caption = 'Dia(s)'
              end
              object Label82: TLabel
                Left = 218
                Top = 427
                Width = 63
                Height = 13
                Caption = 'Regime Atual'
              end
              object Label83: TLabel
                Left = 490
                Top = 427
                Width = 110
                Height = 13
                Caption = 'Grau de Periculosidade'
              end
              object Label67: TLabel
                Left = 373
                Top = 57
                Width = 49
                Height = 13
                Caption = 'N'#186' Proced'
                FocusControl = DBEdit36
              end
              object Label18: TLabel
                Left = 304
                Top = 303
                Width = 36
                Height = 13
                Caption = 'Fac'#231#227'o'
              end
              object SpeedButton8: TSpeedButton
                Left = 577
                Top = 319
                Width = 23
                Height = 22
                Hint = 'Cadastrar Procedencia'
                Caption = '...'
                Flat = True
                ParentShowHint = False
                ShowHint = True
                Visible = False
                OnClick = SpeedButton8Click
              end
              object Label51: TLabel
                Left = 485
                Top = 57
                Width = 73
                Height = 13
                Caption = 'ID Monitora'#231#227'o'
                FocusControl = DBEdit8
              end
              object Label57: TLabel
                Left = 8
                Top = 386
                Width = 166
                Height = 13
                Caption = 'Cidade/Estado Solicitante da Vaga'
              end
              object Label58: TLabel
                Left = 304
                Top = 384
                Width = 88
                Height = 13
                Caption = 'Presidio de Origem'
              end
              object Label60: TLabel
                Left = 493
                Top = 220
                Width = 125
                Height = 13
                Caption = 'Comportamento do Interno'
              end
              object DBEditCodigo: TDBEdit
                Left = 149
                Top = 25
                Width = 76
                Height = 21
                DataField = 'ID_INTERNO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 2
              end
              object DBEdit2: TDBEdit
                Left = 232
                Top = 25
                Width = 370
                Height = 21
                CharCase = ecUpperCase
                DataField = 'NOME_INTERNO'
                DataSource = DsCadastro
                TabOrder = 3
              end
              object DBEdit3: TDBEdit
                Left = 267
                Top = 72
                Width = 100
                Height = 21
                DataField = 'RGI'
                DataSource = DsCadastro
                TabOrder = 5
              end
              object DBEditdtentrada: TDBEdit
                Left = 149
                Top = 152
                Width = 84
                Height = 21
                DataField = 'DATA_ENTRADA'
                DataSource = DsCadastro
                TabOrder = 11
              end
              object DBLookupComboBoxID_PROCEDENCIA: TDBLookupComboBox
                Left = 7
                Top = 319
                Width = 265
                Height = 21
                DataField = 'ID_PROCEDENCIA'
                DataSource = DsCadastro
                KeyField = 'ID_PROCEDENCIA'
                ListField = 'PROCEDENCIA'
                ListSource = DM.DsProcedencia
                TabOrder = 24
              end
              object DBEditdtprisao: TDBEdit
                Left = 238
                Top = 152
                Width = 83
                Height = 21
                DataField = 'DATA_PRISAO'
                DataSource = DsCadastro
                TabOrder = 12
              end
              object DBRadioGroup1: TDBRadioGroup
                Left = 608
                Top = 5
                Width = 105
                Height = 44
                Caption = 'Status'
                DataField = 'ST'
                DataSource = DsCadastro
                Enabled = False
                Items.Strings = (
                  'Ativo'
                  'Inativo')
                TabOrder = 8
                Values.Strings = (
                  'A'
                  'I')
              end
              object DBRadioGroup2: TDBRadioGroup
                Left = 235
                Top = 220
                Width = 145
                Height = 40
                Caption = 'Sexo'
                Columns = 2
                DataField = 'SEXO'
                DataSource = DsCadastro
                Items.Strings = (
                  'Masculino'
                  'Feminino')
                TabOrder = 18
                Values.Strings = (
                  'M'
                  'F')
              end
              object DBLookupComboBox1: TDBLookupComboBox
                Left = 7
                Top = 361
                Width = 258
                Height = 21
                DataField = 'IDCONDICAO_INTERNO'
                DataSource = DsCadastro
                KeyField = 'IDCONDICAO_INTERNO'
                ListField = 'DESCRICAO'
                ListSource = DM.DsCondicaoInterno
                TabOrder = 26
                Visible = False
              end
              object DBEdit7: TDBEdit
                Left = 616
                Top = 286
                Width = 52
                Height = 21
                DataField = 'ID_UP'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 21
                Visible = False
              end
              object DBLookupComboBox2: TDBLookupComboBox
                Left = 7
                Top = 278
                Width = 295
                Height = 21
                DataField = 'ID_UP'
                DataSource = DsCadastro
                Enabled = False
                KeyField = 'ID_UP'
                ListField = 'SIGLA'
                ListSource = DM.DsUP
                TabOrder = 22
              end
              object DBImageFOTOInterno: TDBImage
                Left = 10
                Top = 13
                Width = 135
                Height = 127
                BorderStyle = bsNone
                DataField = 'FOTO'
                DataSource = DsCadastro
                Stretch = True
                TabOrder = 0
                OnClick = DBImageFOTOInternoClick
              end
              object DBEdit24: TDBEdit
                Left = 149
                Top = 112
                Width = 276
                Height = 21
                DataField = 'OUTRO_NOME'
                DataSource = DsCadastro
                TabOrder = 9
              end
              object DBEdit25: TDBEdit
                Left = 430
                Top = 112
                Width = 171
                Height = 21
                DataField = 'VULGO'
                DataSource = DsCadastro
                TabOrder = 10
              end
              object DBEdit29: TDBEdit
                Left = 432
                Top = 151
                Width = 169
                Height = 21
                DataField = 'CI'
                DataSource = DsCadastro
                TabOrder = 14
              end
              object DBEdit35: TDBEdit
                Left = 168
                Top = 196
                Width = 433
                Height = 21
                DataField = 'NOME_SOCIAL'
                DataSource = DsCadastro
                TabOrder = 16
              end
              object DBComboBox3: TDBComboBox
                Left = 8
                Top = 237
                Width = 225
                Height = 21
                Style = csDropDownList
                DataField = 'ORIENTACAO_SEXUAL'
                DataSource = DsCadastro
                ItemHeight = 13
                Items.Strings = (
                  'HOMOSEXUAL'
                  'BISSEXUAL'
                  'HETEROSEXUAL')
                TabOrder = 17
              end
              object DBEdit86: TDBEdit
                Left = 149
                Top = 72
                Width = 114
                Height = 21
                DataField = 'NUMERO_INFOPEN'
                DataSource = DsCadastro
                TabOrder = 4
              end
              object dbrgrpST: TDBRadioGroup
                Left = 382
                Top = 220
                Width = 108
                Height = 40
                Caption = 'Reinser'#231#227'o'
                Columns = 2
                DataField = 'REINCERSAO'
                DataSource = DsCadastro
                Items.Strings = (
                  'Sim'
                  'N'#227'o')
                TabOrder = 19
                Values.Strings = (
                  'S'
                  'N')
              end
              object DBComboBox2: TDBComboBox
                Left = 8
                Top = 195
                Width = 153
                Height = 21
                Style = csDropDownList
                DataField = 'TIPOREGIME'
                DataSource = DsCadastro
                ItemHeight = 13
                Items.Strings = (
                  'Aberto'
                  'Fechado'
                  'Mandado de Pris'#227'o C'#237'vel'
                  'Medida de Seguran'#231'a'
                  'Medida de Tratamento'
                  'Provis'#243'rio'
                  'Semi-Aberto'
                  'Semi-Aberto Sem Sa'#237'da'
                  'Semi-Aberto Com Trabalho Externo'
                  'Semi-Aberto Com Sa'#237'da'
                  'Semi-Aberto Com Trabalho Concedido'
                  'Semi-Aberto Com Trabalho Concedido e Sa'#237'da'
                  'Semi-Aberto Com Trabalho e Sa'#237'da'
                  'Tempor'#225'rio'
                  'N'#227'o Informado')
                TabOrder = 15
              end
              object DBEditpermanencia: TDBEdit
                Left = 326
                Top = 152
                Width = 91
                Height = 21
                DataField = 'DATA_PERMANENCIA'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 13
              end
              object BitBtn1: TBitBtn
                Left = 16
                Top = 144
                Width = 121
                Height = 25
                Caption = 'Salvar em disco'
                TabOrder = 1
                Visible = False
                OnClick = BitBtn1Click
              end
              object DBEdit19: TDBEdit
                Left = 318
                Top = 278
                Width = 234
                Height = 21
                DataField = 'NUMERO_ROUPA'
                DataSource = DsCadastro
                TabOrder = 23
              end
              object DBEdit28: TDBEdit
                Left = 7
                Top = 443
                Width = 65
                Height = 21
                DataField = 'TEMPO_CONSOLIDADO_ANO'
                DataSource = DsCadastro
                TabOrder = 30
              end
              object DBEdit31: TDBEdit
                Left = 74
                Top = 443
                Width = 65
                Height = 21
                DataField = 'TEMPO_CONSOLIDADO_MES'
                DataSource = DsCadastro
                TabOrder = 31
              end
              object DBEdit33: TDBEdit
                Left = 141
                Top = 443
                Width = 65
                Height = 21
                DataField = 'TEMPO_CONSOLIDADO_DIA'
                DataSource = DsCadastro
                TabOrder = 32
              end
              object DBComboBox5: TDBComboBox
                Left = 216
                Top = 443
                Width = 265
                Height = 21
                Style = csDropDownList
                DataField = 'REGIME_ATUAL'
                DataSource = DsCadastro
                ItemHeight = 13
                Items.Strings = (
                  'Aberto'
                  'Fechado'
                  'Mandado de Pris'#227'o C'#237'vel'
                  'Medida de Seguran'#231'a'
                  'Medida de Tratamento'
                  'Provis'#243'rio'
                  'Semi-Aberto'
                  'Semi-Aberto Sem Sa'#237'da'
                  'Semi-Aberto Com Trabalho Externo'
                  'Semi-Aberto Com Sa'#237'da'
                  'Semi-Aberto Com Trabalho Concedido'
                  'Semi-Aberto Com Trabalho Concedido e Sa'#237'da'
                  'Semi-Aberto Com Trabalho e Sa'#237'da'
                  'Tempor'#225'rio'
                  'N'#227'o Informado')
                TabOrder = 33
              end
              object DBComboBoxpericulosidade: TDBComboBox
                Left = 490
                Top = 443
                Width = 111
                Height = 21
                Style = csDropDownList
                DataField = 'GRAU_PERICULOSIDADE'
                DataSource = DsCadastro
                ItemHeight = 13
                Items.Strings = (
                  'Nivel 1'
                  'Nivel 1-A'
                  'Nivel 2'
                  'Nivel 2-A'
                  'Nivel 3'
                  'Nivel 3-A'
                  'Nivel 4'
                  'Nivel 4-A'
                  'Nivel 5'
                  'Nivel 5-A')
                Sorted = True
                TabOrder = 34
              end
              object DBEdit36: TDBEdit
                Left = 373
                Top = 72
                Width = 108
                Height = 21
                DataField = 'NUMERO_PROCED'
                DataSource = DsCadastro
                TabOrder = 6
              end
              object DBLookupComboBoxFACCAO: TDBLookupComboBox
                Left = 303
                Top = 319
                Width = 274
                Height = 21
                DataField = 'ID_FACCAO'
                DataSource = DsCadastro
                KeyField = 'ID_FACCAO'
                ListField = 'FACCAO'
                ListSource = DsFaccao
                TabOrder = 25
              end
              object DBEdit84: TDBEdit
                Left = 307
                Top = 359
                Width = 297
                Height = 21
                Hint = 'FACCAO'
                DataField = 'FACCAO'
                DataSource = DsCadastro
                TabOrder = 27
              end
              object DBEdit8: TDBEdit
                Left = 485
                Top = 72
                Width = 115
                Height = 21
                DataField = 'ID_ME'
                DataSource = DsCadastro
                TabOrder = 7
              end
              object DBLookupComboBoxSolicitanteVaga: TDBLookupComboBox
                Left = 7
                Top = 402
                Width = 258
                Height = 21
                DataField = 'ID_SOLICITANTE_VAGA'
                DataSource = DsCadastro
                KeyField = 'ID_CIDADE'
                ListField = 'CIDADE'
                ListSource = DM.DSCIDADE
                TabOrder = 28
              end
              object DBLookupComboBoxPresidioOrigem: TDBLookupComboBox
                Left = 304
                Top = 401
                Width = 273
                Height = 21
                DataField = 'ID_PRESIDIO_ORIGEM'
                DataSource = DsCadastro
                KeyField = 'ID_PROCEDENCIA'
                ListField = 'PROCEDENCIA'
                ListSource = DM.DsProcedencia
                TabOrder = 29
              end
              object DBComboBox6: TDBComboBox
                Left = 492
                Top = 237
                Width = 177
                Height = 21
                Style = csDropDownList
                DataField = 'TIPOCONDUTA'
                DataSource = DsCadastro
                ItemHeight = 13
                Items.Strings = (
                  'BOM'
                  'REGULAR'
                  'RUIM')
                TabOrder = 20
              end
              object DbrgReuColaborador: TDBRadioGroup
                Left = 608
                Top = 56
                Width = 105
                Height = 49
                Caption = 'R'#233'u Colaborador?'
                DataField = 'COLABORADOR'
                DataSource = DsCadastro
                Items.Strings = (
                  'Sim'
                  'N'#227'o')
                TabOrder = 35
                Values.Strings = (
                  'S'
                  'N')
              end
            end
            object TabSheet2: TTabSheet
              Caption = 'Dados Gerais'
              ImageIndex = 1
              object Label11: TLabel
                Left = 24
                Top = 56
                Width = 21
                Height = 13
                Caption = 'M'#227'e'
                FocusControl = DBEdit1
              end
              object Label19: TLabel
                Left = 312
                Top = 56
                Width = 15
                Height = 13
                Caption = 'Pai'
                FocusControl = DBEdit5
              end
              object Label21: TLabel
                Left = 312
                Top = 96
                Width = 68
                Height = 13
                Caption = 'Nacionalidade'
              end
              object Label22: TLabel
                Left = 144
                Top = 135
                Width = 26
                Height = 13
                Caption = 'Ra'#231'a'
              end
              object Label23: TLabel
                Left = 25
                Top = 176
                Width = 61
                Height = 13
                Caption = 'Escolaridade'
              end
              object Label20: TLabel
                Left = 24
                Top = 96
                Width = 60
                Height = 13
                Caption = 'Naturalidade'
              end
              object Label37: TLabel
                Left = 25
                Top = 217
                Width = 38
                Height = 13
                Caption = 'Religi'#227'o'
              end
              object Label41: TLabel
                Left = 24
                Top = 291
                Width = 61
                Height = 13
                Caption = 'Condena'#231#227'o'
                FocusControl = DBEdit21
              end
              object Label42: TLabel
                Left = 24
                Top = 329
                Width = 41
                Height = 13
                Caption = 'Hist'#243'rico'
                FocusControl = DBEdit22
              end
              object Label13: TLabel
                Left = 336
                Top = 216
                Width = 43
                Height = 13
                Caption = 'Profiss'#227'o'
              end
              object SpeedButton4: TSpeedButton
                Left = 284
                Top = 111
                Width = 23
                Height = 22
                Caption = '...'
                Flat = True
                Visible = False
                OnClick = SpeedButton4Click
              end
              object SpeedButton5: TSpeedButton
                Left = 594
                Top = 111
                Width = 23
                Height = 22
                Caption = '...'
                Flat = True
                Visible = False
                OnClick = SpeedButton5Click
              end
              object SpeedButton6: TSpeedButton
                Left = 301
                Top = 151
                Width = 23
                Height = 22
                Caption = '...'
                Flat = True
                Visible = False
                OnClick = SpeedButton6Click
              end
              object SpeedButton7: TSpeedButton
                Left = 285
                Top = 190
                Width = 23
                Height = 22
                Caption = '...'
                Flat = True
                Visible = False
                OnClick = SpeedButton7Click
              end
              object SpeedButton9: TSpeedButton
                Left = 602
                Top = 229
                Width = 23
                Height = 22
                Caption = '...'
                Flat = True
                Visible = False
                OnClick = SpeedButton9Click
              end
              object Label5: TLabel
                Left = 137
                Top = 16
                Width = 16
                Height = 13
                Caption = 'RG'
                FocusControl = DBEditrg
              end
              object Label24: TLabel
                Left = 351
                Top = 16
                Width = 20
                Height = 13
                Caption = 'CPF'
                FocusControl = DBEditCPF
              end
              object Label25: TLabel
                Left = 486
                Top = 16
                Width = 55
                Height = 13
                Caption = 'Estado Civil'
              end
              object Label26: TLabel
                Left = 24
                Top = 368
                Width = 86
                Height = 13
                Caption = 'Sinais Particulares'
                FocusControl = DBEdit23
              end
              object Label39: TLabel
                Left = 24
                Top = 136
                Width = 27
                Height = 13
                Caption = 'Altura'
                FocusControl = DBEdit26
              end
              object Label47: TLabel
                Left = 80
                Top = 136
                Width = 24
                Height = 13
                Caption = 'Peso'
                FocusControl = DBEdit27
              end
              object Label52: TLabel
                Left = 24
                Top = 16
                Width = 82
                Height = 13
                Caption = 'Data Nascimento'
                FocusControl = DBEditdtrnascimento
              end
              object Label56: TLabel
                Left = 24
                Top = 253
                Width = 27
                Height = 13
                Caption = 'Artigo'
                FocusControl = DBEdit30
              end
              object Label63: TLabel
                Left = 329
                Top = 136
                Width = 66
                Height = 13
                Caption = 'Cor dos Olhos'
                FocusControl = DBEdit32
              end
              object Label64: TLabel
                Left = 458
                Top = 135
                Width = 67
                Height = 13
                Caption = 'Cor do Cabelo'
                FocusControl = DBEdit34
              end
              object Label149: TLabel
                Left = 24
                Top = 405
                Width = 45
                Height = 13
                Caption = 'Visitantes'
                FocusControl = DBEdit83
              end
              object Label48: TLabel
                Left = 311
                Top = 176
                Width = 73
                Height = 13
                Caption = 'Titulo de Eleitor'
                FocusControl = DBEdit4
              end
              object Label77: TLabel
                Left = 241
                Top = 16
                Width = 68
                Height = 13
                Caption = 'Org'#227'o Emissor'
                FocusControl = DBEdit20
              end
              object DBEdit1: TDBEdit
                Left = 24
                Top = 72
                Width = 281
                Height = 21
                DataField = 'MAE'
                DataSource = DsCadastro
                TabOrder = 5
              end
              object DBEdit5: TDBEdit
                Left = 312
                Top = 72
                Width = 313
                Height = 21
                DataField = 'PAI'
                DataSource = DsCadastro
                TabOrder = 6
              end
              object DBLookupComboBoxIDNATURALIDADE: TDBLookupComboBox
                Left = 24
                Top = 112
                Width = 257
                Height = 21
                DataField = 'IDNATURALIDADE'
                DataSource = DsCadastro
                KeyField = 'ID_CIDADE'
                ListField = 'CIDADE'
                ListSource = DM.DSCIDADE
                TabOrder = 7
              end
              object DBLookupComboBoxIDNACIONALIDADE: TDBLookupComboBox
                Left = 312
                Top = 112
                Width = 281
                Height = 21
                DataField = 'IDNACIONALIDADE'
                DataSource = DsCadastro
                KeyField = 'ID_NACIONALIDADE'
                ListField = 'NACIONALIDADE'
                ListSource = DM.DSNACIONALIDADE
                TabOrder = 8
              end
              object DBLookupComboBoxIDRACA: TDBLookupComboBox
                Left = 144
                Top = 151
                Width = 153
                Height = 21
                DataField = 'IDRACA'
                DataSource = DsCadastro
                KeyField = 'ID_RACA'
                ListField = 'RACA'
                ListSource = DM.DSRACA
                TabOrder = 11
              end
              object DBLookupComboBoxIDESCOLARIDADE: TDBLookupComboBox
                Left = 24
                Top = 192
                Width = 257
                Height = 21
                DataField = 'IDESCOLARIDADE'
                DataSource = DsCadastro
                KeyField = 'ID_ESCOLARIDADE'
                ListField = 'ESCOLARIDADE'
                ListSource = DM.DSESCOLARIDADE
                TabOrder = 14
              end
              object DBEdit21: TDBEdit
                Left = 24
                Top = 306
                Width = 601
                Height = 21
                DataField = 'CONDENACAO'
                DataSource = DsCadastro
                TabOrder = 18
              end
              object DBEdit22: TDBEdit
                Left = 24
                Top = 345
                Width = 601
                Height = 21
                DataField = 'HISTORICO'
                DataSource = DsCadastro
                TabOrder = 19
              end
              object DBLookupComboBoxIDPROFISSAO: TDBLookupComboBox
                Left = 336
                Top = 232
                Width = 257
                Height = 21
                DataField = 'IDPROFISSAO'
                DataSource = DsCadastro
                KeyField = 'ID_PROFISSAO'
                ListField = 'PROFISSAO'
                ListSource = DM.DsProfissao
                TabOrder = 16
              end
              object DBEditrg: TDBEdit
                Left = 137
                Top = 32
                Width = 98
                Height = 21
                DataField = 'RG'
                DataSource = DsCadastro
                TabOrder = 1
              end
              object DBEditCPF: TDBEdit
                Left = 352
                Top = 32
                Width = 131
                Height = 21
                DataField = 'CPF'
                DataSource = DsCadastro
                TabOrder = 3
                OnExit = DBEditcpfExit
              end
              object DBEdit23: TDBEdit
                Left = 24
                Top = 384
                Width = 600
                Height = 21
                DataField = 'SINAIS_PARTICULARES'
                DataSource = DsCadastro
                TabOrder = 20
              end
              object DBComboBox1: TDBComboBox
                Left = 486
                Top = 32
                Width = 137
                Height = 21
                Style = csDropDownList
                DataField = 'ESTADO_CIVIL'
                DataSource = DsCadastro
                ItemHeight = 13
                Items.Strings = (
                  'Amasiado'
                  'Casado'
                  'Divorciado'
                  'Separado Judicialmente'
                  'Solteiro'
                  'Vi'#250'vo'
                  'Uni'#227'o Est'#225'vel'
                  'N'#227'o Declarado')
                TabOrder = 4
              end
              object DBEdit26: TDBEdit
                Left = 24
                Top = 152
                Width = 49
                Height = 21
                DataField = 'ALTURA'
                DataSource = DsCadastro
                TabOrder = 9
              end
              object DBEdit27: TDBEdit
                Left = 80
                Top = 152
                Width = 57
                Height = 21
                DataField = 'PESO'
                DataSource = DsCadastro
                TabOrder = 10
              end
              object DBEditdtrnascimento: TDBEdit
                Left = 24
                Top = 32
                Width = 105
                Height = 21
                DataField = 'DATA_NASCIMENTO'
                DataSource = DsCadastro
                TabOrder = 0
              end
              object DBEdit30: TDBEdit
                Left = 24
                Top = 270
                Width = 601
                Height = 21
                DataField = 'ARTIGO'
                DataSource = DsCadastro
                TabOrder = 17
              end
              object DBEdit32: TDBEdit
                Left = 328
                Top = 151
                Width = 119
                Height = 21
                DataField = 'COR_OLHOS'
                DataSource = DsCadastro
                TabOrder = 12
              end
              object DBEdit34: TDBEdit
                Left = 456
                Top = 151
                Width = 169
                Height = 21
                DataField = 'COR_CABELOS'
                DataSource = DsCadastro
                TabOrder = 13
              end
              object DBEdit83: TDBEdit
                Left = 24
                Top = 421
                Width = 601
                Height = 21
                DataField = 'VISITANTES'
                DataSource = DsCadastro
                TabOrder = 21
              end
              object DBEdit4: TDBEdit
                Left = 312
                Top = 192
                Width = 311
                Height = 21
                DataField = 'TITULO_ELEITOR'
                DataSource = DsCadastro
                TabOrder = 15
              end
              object DBEdit20: TDBEdit
                Left = 241
                Top = 32
                Width = 98
                Height = 21
                DataField = 'ORGAO_EMISSOR_RG'
                DataSource = DsCadastro
                TabOrder = 2
              end
              object DBComboBox4: TDBComboBox
                Left = 26
                Top = 232
                Width = 289
                Height = 21
                Style = csDropDownList
                DataField = 'RELIGIAO'
                DataSource = DsCadastro
                ItemHeight = 13
                Items.Strings = (
                  'Adventista'
                  'Ateu'
                  'Budista'
                  'Cat'#243'lica'
                  'Evang'#233'lica'
                  'Esp'#237'rita'
                  'Mul'#231'umano'
                  'N'#227'o Informada'
                  'Sem Religi'#227'o'
                  'Outras')
                TabOrder = 22
              end
            end
            object tsAdvogado: TTabSheet
              Caption = 'Advogados'
              ImageIndex = 10
              OnEnter = tsAdvogadoEnter
              object lbl3: TLabel
                Left = 8
                Top = 333
                Width = 57
                Height = 13
                Caption = 'Advogado'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = [fsBold]
                ParentFont = False
              end
              object btn2: TSpeedButton
                Left = 412
                Top = 348
                Width = 23
                Height = 22
                Caption = '...'
                Flat = True
                OnClick = btn2Click
              end
              object Label50: TLabel
                Left = 8
                Top = 376
                Width = 74
                Height = 13
                Caption = 'Observa'#231#245'es'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = [fsBold]
                ParentFont = False
              end
              object Label61: TLabel
                Left = 8
                Top = 204
                Width = 63
                Height = 13
                Caption = 'Observa'#231#245'es'
              end
              object Label70: TLabel
                Left = 456
                Top = 333
                Width = 119
                Height = 13
                Caption = 'Data da Constitui'#231#227'o'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = [fsBold]
                ParentFont = False
              end
              object Label71: TLabel
                Left = 8
                Top = 313
                Width = 609
                Height = 13
                Caption = 
                  '________________________________________________________________' +
                  '_______________________'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = [fsBold]
                ParentFont = False
              end
              object Label72: TLabel
                Left = 8
                Top = 4
                Width = 129
                Height = 13
                Caption = 'Advogados do Interno:'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = [fsBold]
                ParentFont = False
              end
              object Label75: TLabel
                Left = 312
                Top = 468
                Width = 287
                Height = 13
                Caption = '*Para que qualquer altera'#231#227'o seja salva, clique em SALVAR!'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clRed
                Font.Height = -8
                Font.Name = 'MS Sans Serif'
                Font.Style = []
                ParentFont = False
              end
              object Label81: TLabel
                Left = 280
                Top = 304
                Width = 266
                Height = 13
                Caption = 'Atualizar Data de Constitui'#231#227'o do registro selecionado ->'
              end
              object DBLookupComboBoxIDADVOGADO: TDBLookupComboBox
                Left = 7
                Top = 349
                Width = 402
                Height = 21
                KeyField = 'ID_ADVOGADO'
                ListField = 'ADVOGADO'
                ListSource = DM.DsAdvogado
                TabOrder = 4
              end
              object Button2: TButton
                Left = 8
                Top = 460
                Width = 200
                Height = 25
                Caption = 'Constituir'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -13
                Font.Name = 'MS Sans Serif'
                Font.Style = [fsBold]
                ParentFont = False
                TabOrder = 7
                OnClick = Button2Click
              end
              object Memoobsadvogado: TMemo
                Left = 8
                Top = 392
                Width = 609
                Height = 65
                TabOrder = 6
              end
              object DBGrid3: TDBGrid
                Left = 8
                Top = 20
                Width = 609
                Height = 177
                DataSource = dsADVOGADO_INTERNO
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
                    FieldName = 'ADVOGADO'
                    Title.Caption = 'Advogado'
                    Width = 216
                    Visible = True
                  end
                  item
                    Alignment = taCenter
                    Expanded = False
                    FieldName = 'STATUS'
                    Title.Alignment = taCenter
                    Title.Caption = 'Status'
                    Width = 35
                    Visible = True
                  end
                  item
                    Alignment = taCenter
                    Expanded = False
                    FieldName = 'DATA_CONSTITUICAO'
                    Title.Alignment = taCenter
                    Title.Caption = 'Data Constitui'#231#227'o'
                    Width = 91
                    Visible = True
                  end
                  item
                    Alignment = taCenter
                    Expanded = False
                    FieldName = 'DATA_DESCONSTITUICAO'
                    Title.Alignment = taCenter
                    Title.Caption = 'Data Desconstitui'#231#227'o'
                    Width = 110
                    Visible = True
                  end
                  item
                    Expanded = False
                    FieldName = 'OBSADVOGADO_INTERNO'
                    Title.Caption = 'Observa'#231#245'es'
                    Width = 360
                    Visible = True
                  end>
              end
              object Button3: TButton
                Left = 8
                Top = 292
                Width = 200
                Height = 25
                Caption = 'Desconstituir'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -13
                Font.Name = 'MS Sans Serif'
                Font.Style = [fsBold]
                ParentFont = False
                TabOrder = 2
                OnClick = Button3Click
              end
              object DBMemoObservacaoAdvogado: TDBMemo
                Left = 8
                Top = 220
                Width = 609
                Height = 65
                DataField = 'OBSADVOGADO_INTERNO'
                DataSource = dsADVOGADO_INTERNO
                TabOrder = 1
              end
              object DtpDataConstituicao: TDateTimePicker
                Left = 456
                Top = 349
                Width = 161
                Height = 21
                Date = 41699.665746296300000000
                Time = 41699.665746296300000000
                TabOrder = 5
              end
              object Button4: TButton
                Left = 552
                Top = 296
                Width = 65
                Height = 25
                Caption = 'Atualizar'
                TabOrder = 3
                OnClick = Button4Click
              end
            end
            object TabSheet3: TTabSheet
              Caption = 'Endere'#231'o'
              ImageIndex = 2
              object Label28: TLabel
                Left = 16
                Top = 8
                Width = 46
                Height = 13
                Caption = 'Endere'#231'o'
                FocusControl = DBEdit10
              end
              object Label29: TLabel
                Left = 16
                Top = 48
                Width = 12
                Height = 13
                Caption = 'N'#186
                FocusControl = DBEdit11
              end
              object Label30: TLabel
                Left = 80
                Top = 48
                Width = 27
                Height = 13
                Caption = 'Bairro'
                FocusControl = DBEdit12
              end
              object Label31: TLabel
                Left = 16
                Top = 96
                Width = 64
                Height = 13
                Caption = 'Complemento'
                FocusControl = DBEdit13
              end
              object Label32: TLabel
                Left = 496
                Top = 96
                Width = 21
                Height = 13
                Caption = 'CEP'
                FocusControl = DBEditcep
              end
              object Label33: TLabel
                Left = 16
                Top = 142
                Width = 33
                Height = 13
                Caption = 'Cidade'
              end
              object Label34: TLabel
                Left = 496
                Top = 142
                Width = 42
                Height = 13
                Caption = 'Telefone'
                FocusControl = DBEditfone
              end
              object Label35: TLabel
                Left = 376
                Top = 184
                Width = 37
                Height = 13
                Caption = 'Contato'
                FocusControl = DBEdit17
              end
              object SpeedButton11: TSpeedButton
                Left = 462
                Top = 156
                Width = 23
                Height = 22
                Hint = 'Cadastrar Cidade'
                Caption = '...'
                Flat = True
                ParentShowHint = False
                ShowHint = True
                Visible = False
                OnClick = SpeedButton11Click
              end
              object lbl2: TLabel
                Left = 16
                Top = 184
                Width = 20
                Height = 13
                Caption = 'Pais'
              end
              object btn1: TSpeedButton
                Left = 342
                Top = 199
                Width = 23
                Height = 22
                Caption = '...'
                Flat = True
                OnClick = SpeedButton5Click
              end
              object DBEdit10: TDBEdit
                Left = 16
                Top = 24
                Width = 600
                Height = 21
                DataField = 'ENDERECO'
                DataSource = DsCadastro
                TabOrder = 0
              end
              object DBEdit11: TDBEdit
                Left = 16
                Top = 64
                Width = 57
                Height = 21
                DataField = 'NUMERO'
                DataSource = DsCadastro
                TabOrder = 1
              end
              object DBEdit12: TDBEdit
                Left = 80
                Top = 64
                Width = 537
                Height = 21
                DataField = 'BAIRRO'
                DataSource = DsCadastro
                TabOrder = 2
              end
              object DBEdit13: TDBEdit
                Left = 16
                Top = 112
                Width = 465
                Height = 21
                DataField = 'COMPLEMENETO'
                DataSource = DsCadastro
                TabOrder = 3
              end
              object DBEditcep: TDBEdit
                Left = 496
                Top = 112
                Width = 121
                Height = 21
                DataField = 'CEP'
                DataSource = DsCadastro
                TabOrder = 4
              end
              object DBEditfone: TDBEdit
                Left = 496
                Top = 158
                Width = 121
                Height = 21
                DataField = 'FONE'
                DataSource = DsCadastro
                TabOrder = 6
              end
              object DBEdit17: TDBEdit
                Left = 376
                Top = 200
                Width = 241
                Height = 21
                DataField = 'CONTATO'
                DataSource = DsCadastro
                TabOrder = 8
              end
              object DBLookupComboBoxIDCIDADE: TDBLookupComboBox
                Left = 16
                Top = 158
                Width = 441
                Height = 21
                DataField = 'IDCIDADE'
                DataSource = DsCadastro
                KeyField = 'ID_CIDADE'
                ListField = 'CIDADE'
                ListSource = DM.DSCIDADE
                TabOrder = 5
              end
              object DBLookupComboBoxIDNACIONALIDADE1: TDBLookupComboBox
                Left = 16
                Top = 200
                Width = 321
                Height = 21
                DataField = 'IDPAIS_ENDERECO'
                DataSource = DsCadastro
                KeyField = 'ID_NACIONALIDADE'
                ListField = 'NACIONALIDADE'
                ListSource = DM.DsPais
                TabOrder = 7
              end
            end
            object TabSheet5: TTabSheet
              Caption = 'Hist'#243'rico'
              ImageIndex = 4
              object Label53: TLabel
                Left = 7
                Top = 16
                Width = 62
                Height = 13
                Caption = 'Data do Fato'
              end
              object Label54: TLabel
                Left = 112
                Top = 16
                Width = 211
                Height = 13
                Caption = 'Descri'#231#227'o do Hist'#243'rico para Ficha Disciplinar'
              end
              object DBGrid1: TDBGrid
                Left = 8
                Top = 157
                Width = 610
                Height = 129
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
                    Width = 60
                    Visible = True
                  end
                  item
                    Expanded = False
                    FieldName = 'SETOR'
                    Width = 50
                    Visible = True
                  end
                  item
                    Expanded = False
                    FieldName = 'DESCRICAO'
                    Visible = True
                  end>
              end
              object Button1: TButton
                Left = 6
                Top = 106
                Width = 98
                Height = 25
                Caption = 'Incluir'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -13
                Font.Name = 'MS Sans Serif'
                Font.Style = [fsBold]
                ParentFont = False
                TabOrder = 2
                OnClick = Button1Click
              end
              object DBMemo1: TDBMemo
                Left = 8
                Top = 301
                Width = 610
                Height = 121
                DataField = 'DESCRICAO'
                DataSource = DSHISTORICO_interno
                TabOrder = 4
              end
              object MemoDescricao: TMemo
                Left = 108
                Top = 33
                Width = 506
                Height = 97
                TabOrder = 1
              end
              object DateTimePickerHistorico: TDateTimePicker
                Left = 7
                Top = 33
                Width = 91
                Height = 21
                Date = 0.302563541663403200
                Time = 0.302563541663403200
                TabOrder = 0
              end
            end
            object TabSheet6: TTabSheet
              Caption = 'Fotos'
              ImageIndex = 5
              object FOTO: TLabel
                Left = 16
                Top = 7
                Width = 23
                Height = 13
                Caption = 'Perfil'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = []
                ParentFont = False
              end
              object Label6: TLabel
                Left = 168
                Top = 7
                Width = 91
                Height = 13
                Caption = 'Tatuagem Principal'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = []
                ParentFont = False
              end
              object Label7: TLabel
                Left = 320
                Top = 7
                Width = 86
                Height = 13
                Caption = 'Sinais Particulares'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = []
                ParentFont = False
              end
              object Label8: TLabel
                Left = 472
                Top = 7
                Width = 95
                Height = 13
                Caption = 'Sinais Particulares 1'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = []
                ParentFont = False
              end
              object Label9: TLabel
                Left = 168
                Top = 155
                Width = 95
                Height = 13
                Caption = 'Sinais Particulares 2'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = []
                ParentFont = False
              end
              object Label14: TLabel
                Left = 320
                Top = 155
                Width = 95
                Height = 13
                Caption = 'Sinais Particulares 3'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = []
                ParentFont = False
              end
              object Label15: TLabel
                Left = 472
                Top = 153
                Width = 95
                Height = 13
                Caption = 'Sinais Particulares 4'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = []
                ParentFont = False
              end
              object Label16: TLabel
                Left = 15
                Top = 297
                Width = 60
                Height = 13
                Caption = 'Outras Fotos'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'MS Sans Serif'
                Font.Style = []
                ParentFont = False
              end
              object Label17: TLabel
                Left = 152
                Top = 314
                Width = 23
                Height = 13
                Caption = 'Data'
              end
              object Label44: TLabel
                Left = 152
                Top = 357
                Width = 48
                Height = 13
                Caption = 'Descri'#231#227'o'
              end
              object DBImageFOTOPERFIL: TDBImage
                Left = 16
                Top = 23
                Width = 127
                Height = 127
                DataField = 'FOTO_PERFIL'
                DataSource = DsCadastro
                Stretch = True
                TabOrder = 0
                OnClick = DBImageFOTOPERFILClick
              end
              object DBImagetatuagem1: TDBImage
                Left = 168
                Top = 23
                Width = 127
                Height = 127
                DataField = 'FOTO_TATUAGEM'
                DataSource = DsCadastro
                TabOrder = 1
                OnClick = DBImagetatuagem1Click
              end
              object DBImageFOTO_SINAIS: TDBImage
                Left = 320
                Top = 23
                Width = 127
                Height = 127
                DataField = 'FOTO_SINAIS'
                DataSource = DsCadastro
                TabOrder = 2
                OnClick = DBImageFOTO_SINAISClick
              end
              object DBImageFOTO_SINAIS1: TDBImage
                Left = 472
                Top = 23
                Width = 127
                Height = 127
                DataField = 'FOTO_SINAIS1'
                DataSource = DsCadastro
                TabOrder = 3
                OnClick = DBImageFOTO_SINAIS1Click
              end
              object DBImageFOTO_SINAIS2: TDBImage
                Left = 168
                Top = 170
                Width = 127
                Height = 127
                DataField = 'FOTO_SINAIS2'
                DataSource = DsCadastro
                TabOrder = 4
                OnClick = DBImageFOTO_SINAIS2Click
              end
              object DBImageFOTO_SINAIS3: TDBImage
                Left = 320
                Top = 170
                Width = 127
                Height = 127
                DataField = 'FOTO_SINAIS3'
                DataSource = DsCadastro
                TabOrder = 5
                OnClick = DBImageFOTO_SINAIS3Click
              end
              object DBImageFOTO_SINAIS4: TDBImage
                Left = 472
                Top = 170
                Width = 127
                Height = 127
                DataField = 'FOTO_SINAIS4'
                DataSource = DsCadastro
                TabOrder = 6
                OnClick = DBImageFOTO_SINAIS4Click
              end
              object DBImageOutras: TDBImage
                Left = 15
                Top = 314
                Width = 127
                Height = 127
                DataField = 'FOTO'
                DataSource = DsFoto
                Stretch = True
                TabOrder = 7
                OnClick = DBImageOutrasClick
              end
              object DBGrid4: TDBGrid
                Left = 384
                Top = 312
                Width = 320
                Height = 120
                DataSource = DsFoto
                ReadOnly = True
                TabOrder = 11
                TitleFont.Charset = DEFAULT_CHARSET
                TitleFont.Color = clWindowText
                TitleFont.Height = -11
                TitleFont.Name = 'MS Sans Serif'
                TitleFont.Style = []
                Columns = <
                  item
                    Expanded = False
                    FieldName = 'DATA'
                    Title.Caption = 'Data'
                    Width = 70
                    Visible = True
                  end
                  item
                    Expanded = False
                    FieldName = 'DESCRICAO'
                    Title.Caption = 'Descri'#231#227'o'
                    Width = 200
                    Visible = True
                  end>
              end
              object DBEdit6: TDBEdit
                Left = 152
                Top = 373
                Width = 209
                Height = 21
                DataField = 'DESCRICAO'
                DataSource = DsFoto
                TabOrder = 9
              end
              object adpDBDateTimePicker1: TadpDBDateTimePicker
                Left = 152
                Top = 332
                Width = 89
                Height = 21
                Date = 41096.671558287040000000
                Time = 41096.671558287040000000
                TabOrder = 8
                ReadOnly = False
              end
              object DBNavigator3: TDBNavigator
                Left = 141
                Top = 413
                Width = 240
                Height = 25
                DataSource = DsFoto
                TabOrder = 10
              end
            end
            object TabSheet4: TTabSheet
              Caption = 'Mov. Anterior'
              ImageIndex = 8
              object DBMemo2: TDBMemo
                Left = 0
                Top = 0
                Width = 791
                Height = 496
                Align = alClient
                DataField = 'HISTORICO_VELHO'
                DataSource = DsCadastro
                TabOrder = 0
              end
            end
          end
        end
      end
      inherited TabSheetConsulta: TTabSheet
        inherited PanelLocalizaConsulta: TPanel
          Width = 809
          inherited EditLocalizar: TEdit
            Left = 212
            Width = 277
            TabOrder = 1
          end
          object RadioGroupStatus: TRadioGroup
            Left = 651
            Top = 0
            Width = 121
            Height = 33
            Anchors = [akTop, akRight]
            Caption = 'Filtro'
            Columns = 2
            ItemIndex = 0
            Items.Strings = (
              'Ativo'
              'Inativo')
            TabOrder = 3
            OnClick = RadioGroupStatusClick
          end
          object chkSoundex: TCheckBox
            Left = 493
            Top = 10
            Width = 68
            Height = 17
            Caption = 'Fon'#233'tica'
            TabOrder = 2
            Visible = False
            OnClick = chkSoundexClick
          end
          object RadioGroupTipoLocalizar: TRadioGroup
            Left = 54
            Top = -2
            Width = 155
            Height = 34
            Columns = 2
            ItemIndex = 1
            Items.Strings = (
              'Prontu'#225'rio'
              'Nome')
            TabOrder = 0
            OnClick = RadioGroupTipoLocalizarClick
          end
        end
        inherited PanelConsulta: TPanel
          Width = 809
          Height = 504
          inherited DBGridConsulta: TDBGrid
            Width = 799
            Height = 490
            DataSource = DsConsulta
            TabOrder = 1
            Columns = <
              item
                Expanded = False
                FieldName = 'NOME_INTERNO'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'Times New Roman'
                Font.Style = []
                Title.Caption = 'Nome do Interno'
                Width = 300
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'SIGLA'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'Times New Roman'
                Font.Style = []
                Title.Caption = 'Sigla'
                Width = 53
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'PAVILHAO'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'Times New Roman'
                Font.Style = []
                Title.Caption = 'Pavilh'#227'o'
                Width = 94
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'SOLARIO'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'Times New Roman'
                Font.Style = []
                Title.Caption = 'Solario'
                Width = 83
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'CELA'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'Times New Roman'
                Font.Style = []
                Title.Caption = 'Cela'
                Width = 62
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'STATUS'
                Font.Charset = DEFAULT_CHARSET
                Font.Color = clWindowText
                Font.Height = -11
                Font.Name = 'Times New Roman'
                Font.Style = []
                Title.Caption = 'Status'
                Width = 62
                Visible = True
              end>
          end
          object DBCtrlGridConsulta: TDBCtrlGrid
            Left = 1
            Top = 1
            Width = 798
            Height = 490
            Align = alClient
            DataSource = DsConsulta
            PanelHeight = 98
            PanelWidth = 782
            TabOrder = 0
            RowCount = 5
            SelectedColor = clSilver
            OnDblClick = DBGridConsultaDblClick
            object Label68: TLabel
              Left = 82
              Top = 4
              Width = 79
              Height = 13
              Caption = 'Nome do Interno'
              OnDblClick = DBGridConsultaDblClick
            end
            object LabelPavilhao: TLabel
              Left = 165
              Top = 59
              Width = 41
              Height = 13
              Caption = 'Pavilh'#227'o'
              OnDblClick = DBGridConsultaDblClick
            end
            object LabelGaleria: TLabel
              Left = 317
              Top = 59
              Width = 33
              Height = 13
              Caption = 'Galeria'
              OnDblClick = DBGridConsultaDblClick
            end
            object LabelSolario: TLabel
              Left = 449
              Top = 59
              Width = 32
              Height = 13
              Caption = 'Solario'
              OnDblClick = DBGridConsultaDblClick
            end
            object LabelCela: TLabel
              Left = 595
              Top = 58
              Width = 21
              Height = 13
              Caption = 'Cela'
              OnDblClick = DBGridConsultaDblClick
            end
            object Label73: TLabel
              Left = 82
              Top = 59
              Width = 23
              Height = 13
              Caption = 'Sigla'
              OnDblClick = DBGridConsultaDblClick
            end
            object Label74: TLabel
              Left = 449
              Top = 4
              Width = 27
              Height = 13
              Caption = 'Vulgo'
              OnDblClick = DBGridConsultaDblClick
            end
            object DBText5: TDBText
              Left = 82
              Top = 17
              Width = 360
              Height = 15
              Color = clBtnFace
              DataField = 'NOME_INTERNO'
              DataSource = DsConsulta
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clNavy
              Font.Height = -11
              Font.Name = 'MS Sans Serif'
              Font.Style = [fsBold]
              ParentColor = False
              ParentFont = False
              Transparent = True
              OnDblClick = DBGridConsultaDblClick
            end
            object DBText6: TDBText
              Left = 449
              Top = 17
              Width = 244
              Height = 15
              Color = clBtnFace
              DataField = 'VULGO'
              DataSource = DsConsulta
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clNavy
              Font.Height = -11
              Font.Name = 'MS Sans Serif'
              Font.Style = [fsBold]
              ParentColor = False
              ParentFont = False
              Transparent = True
              OnDblClick = DBGridConsultaDblClick
            end
            object DBText7: TDBText
              Left = 82
              Top = 72
              Width = 78
              Height = 15
              Color = clBtnFace
              DataField = 'SIGLA'
              DataSource = DsConsulta
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clNavy
              Font.Height = -11
              Font.Name = 'MS Sans Serif'
              Font.Style = [fsBold]
              ParentColor = False
              ParentFont = False
              Transparent = True
              OnDblClick = DBGridConsultaDblClick
            end
            object DBText8: TDBText
              Left = 165
              Top = 72
              Width = 148
              Height = 15
              Color = clBtnFace
              DataField = 'PAVILHAO'
              DataSource = DsConsulta
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clNavy
              Font.Height = -11
              Font.Name = 'MS Sans Serif'
              Font.Style = [fsBold]
              ParentColor = False
              ParentFont = False
              Transparent = True
              OnDblClick = DBGridConsultaDblClick
            end
            object DBText9: TDBText
              Left = 317
              Top = 72
              Width = 125
              Height = 15
              Color = clBtnFace
              DataField = 'GALERIA'
              DataSource = DsConsulta
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clNavy
              Font.Height = -11
              Font.Name = 'MS Sans Serif'
              Font.Style = [fsBold]
              ParentColor = False
              ParentFont = False
              Transparent = True
              OnDblClick = DBGridConsultaDblClick
            end
            object DBText10: TDBText
              Left = 449
              Top = 72
              Width = 138
              Height = 15
              Color = clBtnFace
              DataField = 'SOLARIO'
              DataSource = DsConsulta
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clNavy
              Font.Height = -11
              Font.Name = 'MS Sans Serif'
              Font.Style = [fsBold]
              ParentColor = False
              ParentFont = False
              Transparent = True
              OnDblClick = DBGridConsultaDblClick
            end
            object DBText11: TDBText
              Left = 594
              Top = 72
              Width = 99
              Height = 15
              Color = clBtnFace
              DataField = 'CELA'
              DataSource = DsConsulta
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clNavy
              Font.Height = -11
              Font.Name = 'MS Sans Serif'
              Font.Style = [fsBold]
              ParentColor = False
              ParentFont = False
              Transparent = True
              OnDblClick = DBGridConsultaDblClick
            end
            object DBText13: TDBText
              Left = 82
              Top = 44
              Width = 360
              Height = 15
              Color = clBtnFace
              DataField = 'ESTADO_SOLICITANTE'
              DataSource = DsConsulta
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clNavy
              Font.Height = -11
              Font.Name = 'MS Sans Serif'
              Font.Style = [fsBold]
              ParentColor = False
              ParentFont = False
              Transparent = True
              OnDblClick = DBGridConsultaDblClick
            end
            object Label76: TLabel
              Left = 82
              Top = 31
              Width = 128
              Height = 13
              Caption = 'Estado Solicitante da Vaga'
              OnDblClick = DBGridConsultaDblClick
            end
            object Label69: TLabel
              Left = 11
              Top = 2
              Width = 48
              Height = 13
              Caption = 'Prontu'#225'rio'
              FocusControl = DBEdit3
            end
            object DBText1: TDBText
              Left = 10
              Top = 17
              Width = 71
              Height = 15
              Color = clBtnFace
              DataField = 'RGI'
              DataSource = DsConsulta
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clNavy
              Font.Height = -11
              Font.Name = 'MS Sans Serif'
              Font.Style = [fsBold]
              ParentColor = False
              ParentFont = False
              Transparent = True
              OnDblClick = DBGridConsultaDblClick
            end
            object Image1: TImage
              Left = 28
              Top = 47
              Width = 34
              Height = 34
              Picture.Data = {}
            end
            object LbFaccao: TLabel
              Left = 449
              Top = 31
              Width = 36
              Height = 13
              Caption = 'Fac'#231#227'o'
              OnDblClick = DBGridConsultaDblClick
            end
            object DBTFaccao: TDBText
              Left = 449
              Top = 44
              Width = 244
              Height = 15
              Color = clBtnFace
              DataField = 'FACCAO'
              DataSource = DsConsulta
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clNavy
              Font.Height = -11
              Font.Name = 'MS Sans Serif'
              Font.Style = [fsBold]
              ParentColor = False
              ParentFont = False
              Transparent = True
              OnDblClick = DBGridConsultaDblClick
            end
            object LbStatus: TLabel
              Left = 699
              Top = 58
              Width = 30
              Height = 13
              Caption = 'Status'
              OnDblClick = DBGridConsultaDblClick
            end
            object DBTStatus: TDBText
              Left = 698
              Top = 72
              Width = 99
              Height = 15
              Color = clBtnFace
              DataField = 'STATUS'
              DataSource = DsConsulta
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clNavy
              Font.Height = -11
              Font.Name = 'MS Sans Serif'
              Font.Style = [fsBold]
              ParentColor = False
              ParentFont = False
              Transparent = True
              OnDblClick = DBGridConsultaDblClick
            end
          end
        end
      end
    end
  end
  inherited PanelTituloModeloCadastro: TPanel
    Width = 932
    inherited Image2: TImage
      Width = 932
    end
  end
  inherited StatusBar1: TStatusBar
    Top = 598
    Width = 932
  end
  inherited SqlCadastro: TSQLQuery
    Params = <
      item
        DataType = ftInteger
        Name = 'id_interno'
        ParamType = ptInput
        Value = -1
      end>
    SQL.Strings = (
      'select *'
      'from interno'
      'where id_interno=:id_interno')
    Left = 26
    Top = 11
    object SqlCadastroID_INTERNO: TIntegerField
      FieldName = 'ID_INTERNO'
      Required = True
    end
    object SqlCadastroNOME_INTERNO: TStringField
      FieldName = 'NOME_INTERNO'
      Size = 100
    end
    object SqlCadastroRGI: TStringField
      FieldName = 'RGI'
      Size = 30
    end
    object SqlCadastroIDPROFISSAO: TIntegerField
      FieldName = 'IDPROFISSAO'
    end
    object SqlCadastroIDGALERIA: TIntegerField
      FieldName = 'IDGALERIA'
    end
    object SqlCadastroIDPAVILHAO: TIntegerField
      FieldName = 'IDPAVILHAO'
    end
    object SqlCadastroIDSOLARIO: TIntegerField
      FieldName = 'IDSOLARIO'
    end
    object SqlCadastroIDCELA: TIntegerField
      FieldName = 'IDCELA'
    end
    object SqlCadastroDATA_ENTRADA: TSQLTimeStampField
      FieldName = 'DATA_ENTRADA'
    end
    object SqlCadastroMAE: TStringField
      FieldName = 'MAE'
      Size = 100
    end
    object SqlCadastroPAI: TStringField
      FieldName = 'PAI'
      Size = 100
    end
    object SqlCadastroIDNATURALIDADE: TIntegerField
      FieldName = 'IDNATURALIDADE'
    end
    object SqlCadastroIDNACIONALIDADE: TIntegerField
      FieldName = 'IDNACIONALIDADE'
    end
    object SqlCadastroIDRACA: TIntegerField
      FieldName = 'IDRACA'
    end
    object SqlCadastroIDESCOLARIDADE: TIntegerField
      FieldName = 'IDESCOLARIDADE'
    end
    object SqlCadastroENDERECO: TStringField
      FieldName = 'ENDERECO'
      Size = 200
    end
    object SqlCadastroNUMERO: TStringField
      FieldName = 'NUMERO'
      Size = 50
    end
    object SqlCadastroBAIRRO: TStringField
      FieldName = 'BAIRRO'
      Size = 100
    end
    object SqlCadastroCOMPLEMENETO: TStringField
      FieldName = 'COMPLEMENETO'
      Size = 100
    end
    object SqlCadastroCEP: TStringField
      FieldName = 'CEP'
      Size = 8
    end
    object SqlCadastroIDCIDADE: TIntegerField
      FieldName = 'IDCIDADE'
    end
    object SqlCadastroFONE: TStringField
      FieldName = 'FONE'
      Size = 50
    end
    object SqlCadastroCONTATO: TStringField
      FieldName = 'CONTATO'
      Size = 50
    end
    object SqlCadastroRELIGIAO: TStringField
      FieldName = 'RELIGIAO'
      Size = 50
    end
    object SqlCadastroIDADVOGADO: TIntegerField
      FieldName = 'IDADVOGADO'
    end
    object SqlCadastroID_PROCEDENCIA: TIntegerField
      FieldName = 'ID_PROCEDENCIA'
    end
    object SqlCadastroCONDENACAO: TStringField
      FieldName = 'CONDENACAO'
      Size = 100
    end
    object SqlCadastroDATA_PRISAO: TSQLTimeStampField
      FieldName = 'DATA_PRISAO'
    end
    object SqlCadastroHISTORICO: TStringField
      FieldName = 'HISTORICO'
      Size = 8192
    end
    object SqlCadastroST: TStringField
      FieldName = 'ST'
      Size = 1
    end
    object SqlCadastroSEXO: TStringField
      FieldName = 'SEXO'
      Size = 1
    end
    object SqlCadastroID_UP: TIntegerField
      FieldName = 'ID_UP'
    end
    object SqlCadastroIDCONDICAO_INTERNO: TIntegerField
      FieldName = 'IDCONDICAO_INTERNO'
    end
    object SqlCadastroIDDESTINO: TIntegerField
      FieldName = 'IDDESTINO'
    end
    object SqlCadastroID_FUNCIONARIO: TIntegerField
      FieldName = 'ID_FUNCIONARIO'
    end
    object SqlCadastroSTATUS_ISOLAMENTO: TStringField
      FieldName = 'STATUS_ISOLAMENTO'
      Size = 30
    end
    object SqlCadastroIDSETOR_TRABALHO: TIntegerField
      FieldName = 'IDSETOR_TRABALHO'
    end
    object SqlCadastroDATA_SETOR: TSQLTimeStampField
      FieldName = 'DATA_SETOR'
    end
    object SqlCadastroFOTO: TBlobField
      FieldName = 'FOTO'
    end
    object SqlCadastroFOTO_PERFIL: TBlobField
      FieldName = 'FOTO_PERFIL'
    end
    object SqlCadastroFOTO_TATUAGEM: TBlobField
      FieldName = 'FOTO_TATUAGEM'
    end
    object SqlCadastroDATA_SAIDA: TSQLTimeStampField
      FieldName = 'DATA_SAIDA'
    end
    object SqlCadastroMOTIVO_SAIDA: TStringField
      FieldName = 'MOTIVO_SAIDA'
      Size = 100
    end
    object SqlCadastroID_FUNCAOINTERNO: TIntegerField
      FieldName = 'ID_FUNCAOINTERNO'
    end
    object SqlCadastroOBSTRABALHO: TStringField
      FieldName = 'OBSTRABALHO'
      Size = 100
    end
    object SqlCadastroDATA_NASCIMENTO: TSQLTimeStampField
      FieldName = 'DATA_NASCIMENTO'
    end
    object SqlCadastroRG: TStringField
      FieldName = 'RG'
      Size = 30
    end
    object SqlCadastroCPF: TStringField
      FieldName = 'CPF'
      Size = 50
    end
    object SqlCadastroESTADO_CIVIL: TStringField
      FieldName = 'ESTADO_CIVIL'
      Size = 30
    end
    object SqlCadastroVULGO: TStringField
      FieldName = 'VULGO'
      Size = 100
    end
    object SqlCadastroOUTRO_NOME: TStringField
      FieldName = 'OUTRO_NOME'
      Size = 1000
    end
    object SqlCadastroSINAIS_PARTICULARES: TStringField
      FieldName = 'SINAIS_PARTICULARES'
      Size = 200
    end
    object SqlCadastroALTURA: TStringField
      FieldName = 'ALTURA'
      Size = 30
    end
    object SqlCadastroPESO: TStringField
      FieldName = 'PESO'
      Size = 30
    end
    object SqlCadastroCI: TStringField
      FieldName = 'CI'
      Size = 30
    end
    object SqlCadastroCISAIDA: TStringField
      FieldName = 'CISAIDA'
      Size = 30
    end
    object SqlCadastroFOTO_SINAIS: TBlobField
      FieldName = 'FOTO_SINAIS'
    end
    object SqlCadastroFOTO_SINAIS1: TBlobField
      FieldName = 'FOTO_SINAIS1'
    end
    object SqlCadastroFOTO_SINAIS2: TBlobField
      FieldName = 'FOTO_SINAIS2'
    end
    object SqlCadastroFOTO_SINAIS3: TBlobField
      FieldName = 'FOTO_SINAIS3'
    end
    object SqlCadastroFOTO_SINAIS4: TBlobField
      FieldName = 'FOTO_SINAIS4'
    end
    object SqlCadastroARTIGO: TStringField
      FieldName = 'ARTIGO'
      Size = 100
    end
    object SqlCadastroDATA_ISOLAMENTO: TSQLTimeStampField
      FieldName = 'DATA_ISOLAMENTO'
    end
    object SqlCadastroDATA_MATRICULA: TSQLTimeStampField
      FieldName = 'DATA_MATRICULA'
    end
    object SqlCadastroOBSEDUCACAO: TStringField
      FieldName = 'OBSEDUCACAO'
      Size = 8192
    end
    object SqlCadastroDEFICIENCIA: TStringField
      FieldName = 'DEFICIENCIA'
      Size = 100
    end
    object SqlCadastroIDSERIEESTUDO: TIntegerField
      FieldName = 'IDSERIEESTUDO'
    end
    object SqlCadastroCOR_OLHOS: TStringField
      FieldName = 'COR_OLHOS'
      Size = 100
    end
    object SqlCadastroCOR_CABELOS: TStringField
      FieldName = 'COR_CABELOS'
      Size = 100
    end
    object SqlCadastroNOME_SOCIAL: TStringField
      FieldName = 'NOME_SOCIAL'
      Size = 50
    end
    object SqlCadastroORIENTACAO_SEXUAL: TStringField
      FieldName = 'ORIENTACAO_SEXUAL'
      Size = 50
    end
    object SqlCadastroIDENTIDADE_GENERO: TStringField
      FieldName = 'IDENTIDADE_GENERO'
      Size = 50
    end
    object SqlCadastroHISTORICO_VELHO: TStringField
      FieldName = 'HISTORICO_VELHO'
      Size = 16386
    end
    object SqlCadastroTIPOPROCESSO: TStringField
      FieldName = 'TIPOPROCESSO'
      Size = 100
    end
    object SqlCadastroCONCEITO_DISCIPLINAR: TStringField
      FieldName = 'CONCEITO_DISCIPLINAR'
      Size = 200
    end
    object SqlCadastroTIPOCONDUTA: TStringField
      FieldName = 'TIPOCONDUTA'
      Size = 30
    end
    object SqlCadastroPERIODO: TStringField
      FieldName = 'PERIODO'
      Size = 30
    end
    object SqlCadastroFAMILIARPRESO: TStringField
      FieldName = 'FAMILIARPRESO'
      Size = 30
    end
    object SqlCadastroPARENTESCOPRESO: TStringField
      FieldName = 'PARENTESCOPRESO'
      Size = 50
    end
    object SqlCadastroUPFAMILIARPRESO: TStringField
      FieldName = 'UPFAMILIARPRESO'
      Size = 200
    end
    object SqlCadastroMOTIVODELITO: TStringField
      FieldName = 'MOTIVODELITO'
      Size = 200
    end
    object SqlCadastroMAIORPERDA: TStringField
      FieldName = 'MAIORPERDA'
      Size = 200
    end
    object SqlCadastroPAISVIVOS: TStringField
      FieldName = 'PAISVIVOS'
      Size = 30
    end
    object SqlCadastroPAISSEPARADOS: TStringField
      FieldName = 'PAISSEPARADOS'
      Size = 30
    end
    object SqlCadastroIDADEPAISSEPARADOS: TStringField
      FieldName = 'IDADEPAISSEPARADOS'
      Size = 30
    end
    object SqlCadastroPROFISSAOPAIS: TStringField
      FieldName = 'PROFISSAOPAIS'
      Size = 100
    end
    object SqlCadastroQUEMCRIOU: TStringField
      FieldName = 'QUEMCRIOU'
      Size = 100
    end
    object SqlCadastroTRABALHOFAMILIA: TStringField
      FieldName = 'TRABALHOFAMILIA'
      Size = 100
    end
    object SqlCadastroQTDEIRMAOS: TStringField
      FieldName = 'QTDEIRMAOS'
      Size = 30
    end
    object SqlCadastroCRIADOIRMAOS: TStringField
      FieldName = 'CRIADOIRMAOS'
      Size = 30
    end
    object SqlCadastroMORADIA: TStringField
      FieldName = 'MORADIA'
      Size = 100
    end
    object SqlCadastroREPRESENTACAOPAIS: TStringField
      FieldName = 'REPRESENTACAOPAIS'
      Size = 200
    end
    object SqlCadastroEDUCACAORECEBIDA: TStringField
      FieldName = 'EDUCACAORECEBIDA'
      Size = 200
    end
    object SqlCadastroMUDANCAFAMILIA: TStringField
      FieldName = 'MUDANCAFAMILIA'
      Size = 100
    end
    object SqlCadastroFUGACASA: TStringField
      FieldName = 'FUGACASA'
      Size = 100
    end
    object SqlCadastroCONDICOESCRIACAO: TStringField
      FieldName = 'CONDICOESCRIACAO'
      Size = 30
    end
    object SqlCadastroINSTITUICAOASSISTENCIAL: TStringField
      FieldName = 'INSTITUICAOASSISTENCIAL'
      Size = 100
    end
    object SqlCadastroVIOLENCIADOMESTICA: TStringField
      FieldName = 'VIOLENCIADOMESTICA'
      Size = 200
    end
    object SqlCadastroMORADIAANTESPRESO: TStringField
      FieldName = 'MORADIAANTESPRESO'
      Size = 100
    end
    object SqlCadastroRESIDENCIAFAMILIAR: TStringField
      FieldName = 'RESIDENCIAFAMILIAR'
      Size = 100
    end
    object SqlCadastroQTDEFILHOS: TStringField
      FieldName = 'QTDEFILHOS'
      Size = 100
    end
    object SqlCadastroFILHOSMENORES16: TStringField
      FieldName = 'FILHOSMENORES16'
      Size = 100
    end
    object SqlCadastroFILHOSVIVEM: TStringField
      FieldName = 'FILHOSVIVEM'
      Size = 200
    end
    object SqlCadastroFILHOADOCAO: TStringField
      FieldName = 'FILHOADOCAO'
      Size = 200
    end
    object SqlCadastroPROVEDORFAMILIA: TStringField
      FieldName = 'PROVEDORFAMILIA'
      Size = 30
    end
    object SqlCadastroRENDIMENTOFAMILIAR: TStringField
      FieldName = 'RENDIMENTOFAMILIAR'
      Size = 200
    end
    object SqlCadastroPROGRAMASOCIAL: TStringField
      FieldName = 'PROGRAMASOCIAL'
      Size = 200
    end
    object SqlCadastroAUXRECLUSAO: TStringField
      FieldName = 'AUXRECLUSAO'
      Size = 200
    end
    object SqlCadastroREPROVADOESCOLA: TStringField
      FieldName = 'REPROVADOESCOLA'
      Size = 200
    end
    object SqlCadastroIDADETRABALHO: TStringField
      FieldName = 'IDADETRABALHO'
      Size = 200
    end
    object SqlCadastroCURSOPROFISSIONALIZANTE: TStringField
      FieldName = 'CURSOPROFISSIONALIZANTE'
      Size = 200
    end
    object SqlCadastroEXERCICIATRABALHO: TStringField
      FieldName = 'EXERCICIATRABALHO'
      Size = 100
    end
    object SqlCadastroREGISTROCARTEIRA: TStringField
      FieldName = 'REGISTROCARTEIRA'
      Size = 100
    end
    object SqlCadastroTRABALHOUPANTERIOR: TStringField
      FieldName = 'TRABALHOUPANTERIOR'
      Size = 200
    end
    object SqlCadastroDOCUMENTOS: TStringField
      FieldName = 'DOCUMENTOS'
      Size = 200
    end
    object SqlCadastroUSODROGAS: TStringField
      FieldName = 'USODROGAS'
      Size = 200
    end
    object SqlCadastroDATADEPENDENCIA: TStringField
      FieldName = 'DATADEPENDENCIA'
      Size = 100
    end
    object SqlCadastroABANDONODROGAS: TStringField
      FieldName = 'ABANDONODROGAS'
      Size = 200
    end
    object SqlCadastroDROGASCOMCRIME: TStringField
      FieldName = 'DROGASCOMCRIME'
      Size = 200
    end
    object SqlCadastroDOENCAGRAVE: TStringField
      FieldName = 'DOENCAGRAVE'
      Size = 30
    end
    object SqlCadastroDOENCAMENTAL: TStringField
      FieldName = 'DOENCAMENTAL'
      Size = 30
    end
    object SqlCadastroPROBLEMASAUDE: TStringField
      FieldName = 'PROBLEMASAUDE'
      Size = 200
    end
    object SqlCadastroDOENCALABORAL: TStringField
      FieldName = 'DOENCALABORAL'
      Size = 200
    end
    object SqlCadastroVISITAOUTRAPESSOA: TStringField
      FieldName = 'VISITAOUTRAPESSOA'
      Size = 200
    end
    object SqlCadastroESTUDOCUMPENA: TStringField
      FieldName = 'ESTUDOCUMPENA'
      Size = 100
    end
    object SqlCadastroTRABALHOCUMPENA: TStringField
      FieldName = 'TRABALHOCUMPENA'
      Size = 100
    end
    object SqlCadastroPROFISSAOCUMPENA: TStringField
      FieldName = 'PROFISSAOCUMPENA'
      Size = 100
    end
    object SqlCadastroDATAPSICOSSOCIAL: TSQLTimeStampField
      FieldName = 'DATAPSICOSSOCIAL'
    end
    object SqlCadastroIDTECNICO: TIntegerField
      FieldName = 'IDTECNICO'
    end
    object SqlCadastroOBSPSICOSSOCIAL: TStringField
      FieldName = 'OBSPSICOSSOCIAL'
      Size = 200
    end
    object SqlCadastroDATA_DELITO: TSQLTimeStampField
      FieldName = 'DATA_DELITO'
    end
    object SqlCadastroDATA_REABILITACAO: TSQLTimeStampField
      FieldName = 'DATA_REABILITACAO'
    end
    object SqlCadastroMP: TIntegerField
      FieldName = 'MP'
    end
    object SqlCadastroSUICIDIO: TStringField
      FieldName = 'SUICIDIO'
      Size = 100
    end
    object SqlCadastroCID: TStringField
      FieldName = 'CID'
      Size = 100
    end
    object SqlCadastroEFEITOSDROGA: TStringField
      FieldName = 'EFEITOSDROGA'
      Size = 200
    end
    object SqlCadastroSINTOMASDEPRESSIVOS: TStringField
      FieldName = 'SINTOMASDEPRESSIVOS'
      Size = 200
    end
    object SqlCadastroEPISODIOSHUMOR: TStringField
      FieldName = 'EPISODIOSHUMOR'
      Size = 200
    end
    object SqlCadastroSINTOMASPSICOTICOS: TStringField
      FieldName = 'SINTOMASPSICOTICOS'
      Size = 200
    end
    object SqlCadastroDELIRIOS: TStringField
      FieldName = 'DELIRIOS'
      Size = 200
    end
    object SqlCadastroALUCINACOES: TStringField
      FieldName = 'ALUCINACOES'
      Size = 100
    end
    object SqlCadastroPERSONALIDADE: TStringField
      FieldName = 'PERSONALIDADE'
      Size = 100
    end
    object SqlCadastroVISITANTES: TStringField
      FieldName = 'VISITANTES'
      Size = 200
    end
    object SqlCadastroMEDICACAOCONTROLADA: TStringField
      FieldName = 'MEDICACAOCONTROLADA'
      Size = 200
    end
    object SqlCadastroDOENCAINFECTOCONTAGIOSA: TStringField
      FieldName = 'DOENCAINFECTOCONTAGIOSA'
      Size = 200
    end
    object SqlCadastroTRATAMENTOINFECTO: TStringField
      FieldName = 'TRATAMENTOINFECTO'
      Size = 200
    end
    object SqlCadastroRESULTADOINFECTO: TStringField
      FieldName = 'RESULTADOINFECTO'
      Size = 200
    end
    object SqlCadastroSITUACAOCIVIL: TStringField
      FieldName = 'SITUACAOCIVIL'
      Size = 100
    end
    object SqlCadastroMEDIDASEGURANCA: TStringField
      FieldName = 'MEDIDASEGURANCA'
      Size = 30
    end
    object SqlCadastroFACCAO: TStringField
      FieldName = 'FACCAO'
      Size = 100
    end
    object SqlCadastroVARA_ORIGEM: TStringField
      FieldName = 'VARA_ORIGEM'
      Size = 100
    end
    object SqlCadastroEM_TRANSITO: TStringField
      FieldName = 'EM_TRANSITO'
      Size = 1
    end
    object SqlCadastroNUMERO_INFOPEN: TStringField
      FieldName = 'NUMERO_INFOPEN'
      Size = 30
    end
    object SqlCadastroREINCERSAO: TStringField
      FieldName = 'REINCERSAO'
      Size = 1
    end
    object SqlCadastroIDPAIS_ENDERECO: TIntegerField
      FieldName = 'IDPAIS_ENDERECO'
    end
    object SqlCadastroOUTROS_ADVOGADOS: TStringField
      FieldName = 'OUTROS_ADVOGADOS'
      Size = 1000
    end
    object SqlCadastroTITULO_ELEITOR: TStringField
      FieldName = 'TITULO_ELEITOR'
      Size = 30
    end
    object SqlCadastroTIPOREGIME: TStringField
      FieldName = 'TIPOREGIME'
      Size = 100
    end
    object SqlCadastroDATA_PERMANENCIA: TSQLTimeStampField
      FieldName = 'DATA_PERMANENCIA'
    end
    object SqlCadastroPASSAGEM_SPF: TStringField
      FieldName = 'PASSAGEM_SPF'
      Size = 1000
    end
    object SqlCadastroMOTIVACAO_INCLUSAO: TStringField
      FieldName = 'MOTIVACAO_INCLUSAO'
      Size = 8192
    end
    object SqlCadastroNUMERO_ROUPA: TStringField
      FieldName = 'NUMERO_ROUPA'
      Size = 100
    end
    object SqlCadastroORGAO_EMISSOR_RG: TStringField
      FieldName = 'ORGAO_EMISSOR_RG'
      Size = 30
    end
    object SqlCadastroTEMPO_CONSOLIDADO_ANO: TIntegerField
      FieldName = 'TEMPO_CONSOLIDADO_ANO'
    end
    object SqlCadastroTEMPO_CONSOLIDADO_MES: TIntegerField
      FieldName = 'TEMPO_CONSOLIDADO_MES'
    end
    object SqlCadastroTEMPO_CONSOLIDADO_DIA: TIntegerField
      FieldName = 'TEMPO_CONSOLIDADO_DIA'
    end
    object SqlCadastroREGIME_ATUAL: TStringField
      FieldName = 'REGIME_ATUAL'
      Size = 100
    end
    object SqlCadastroGRAU_PERICULOSIDADE: TStringField
      FieldName = 'GRAU_PERICULOSIDADE'
      Size = 30
    end
    object SqlCadastroDATA_BASE_PROGRESSAO: TSQLTimeStampField
      FieldName = 'DATA_BASE_PROGRESSAO'
    end
    object SqlCadastroDATA_BASE_CONDICIONAL: TSQLTimeStampField
      FieldName = 'DATA_BASE_CONDICIONAL'
    end
    object SqlCadastroCHAVE_MIGRACAO: TStringField
      FieldName = 'CHAVE_MIGRACAO'
      Size = 100
    end
    object SqlCadastroDOC_TRABALHO: TStringField
      FieldName = 'DOC_TRABALHO'
      Size = 30
    end
    object SqlCadastroID_UP_DESTINO: TIntegerField
      FieldName = 'ID_UP_DESTINO'
    end
    object SqlCadastroID_LOCAL_TRABALHO: TIntegerField
      FieldName = 'ID_LOCAL_TRABALHO'
    end
    object SqlCadastroTURMA: TStringField
      FieldName = 'TURMA'
      Size = 10
    end
    object SqlCadastroNUMERO_PROCED: TStringField
      FieldName = 'NUMERO_PROCED'
      Size = 30
    end
    object SqlCadastroDATA_TERMINO_CONDENACAO: TSQLTimeStampField
      FieldName = 'DATA_TERMINO_CONDENACAO'
    end
    object SqlCadastroDATA_REQUISITO_CONDICIONAL: TSQLTimeStampField
      FieldName = 'DATA_REQUISITO_CONDICIONAL'
    end
    object SqlCadastroOBS_CONDICIONAL: TStringField
      FieldName = 'OBS_CONDICIONAL'
      Size = 100
    end
    object SqlCadastroDATA_REQUISITO_PROGRESSAO: TSQLTimeStampField
      FieldName = 'DATA_REQUISITO_PROGRESSAO'
    end
    object SqlCadastroOBS_PROGRESSAO: TStringField
      FieldName = 'OBS_PROGRESSAO'
      Size = 100
    end
    object SqlCadastroCLASSIFICACAO_MAPA: TStringField
      FieldName = 'CLASSIFICACAO_MAPA'
      Size = 100
    end
    object SqlCadastroPRIMARIO_REINCIDENTE: TStringField
      FieldName = 'PRIMARIO_REINCIDENTE'
      Size = 1
    end
    object SqlCadastroCOM_DIREITO_MAPA: TStringField
      FieldName = 'COM_DIREITO_MAPA'
      Size = 1
    end
    object SqlCadastroOBS_MAPA: TStringField
      FieldName = 'OBS_MAPA'
      Size = 100
    end
    object SqlCadastroID_FACCAO: TIntegerField
      FieldName = 'ID_FACCAO'
    end
    object SqlCadastroHORARIO_ENTRADA_SEMANAL: TTimeField
      FieldName = 'HORARIO_ENTRADA_SEMANAL'
    end
    object SqlCadastroHORARIO_SAIDA_SEMANAL: TTimeField
      FieldName = 'HORARIO_SAIDA_SEMANAL'
    end
    object SqlCadastroTURMA_SAIDAO: TStringField
      FieldName = 'TURMA_SAIDAO'
      Size = 10
    end
    object SqlCadastroHORARIO_ENTRADA_SAIDAO: TTimeField
      FieldName = 'HORARIO_ENTRADA_SAIDAO'
    end
    object SqlCadastroHORARIO_SAIDA_SAIDAO: TTimeField
      FieldName = 'HORARIO_SAIDA_SAIDAO'
    end
    object SqlCadastroHORARIO_ENTRADA_SABADO: TTimeField
      FieldName = 'HORARIO_ENTRADA_SABADO'
    end
    object SqlCadastroHORARIO_SAIDA_SABADO: TTimeField
      FieldName = 'HORARIO_SAIDA_SABADO'
    end
    object SqlCadastroHORARIO_ENTRADA_DOMINGO: TTimeField
      FieldName = 'HORARIO_ENTRADA_DOMINGO'
    end
    object SqlCadastroHORARIO_SAIDA_DOMINGO: TTimeField
      FieldName = 'HORARIO_SAIDA_DOMINGO'
    end
    object SqlCadastroTIPO_ATIVIDADE: TStringField
      FieldName = 'TIPO_ATIVIDADE'
      Size = 30
    end
    object SqlCadastroCORTE: TStringField
      FieldName = 'CORTE'
      Size = 10
    end
    object SqlCadastroSUS: TStringField
      FieldName = 'SUS'
      Size = 100
    end
    object SqlCadastroDADOS_OUTRO_BANCO: TStringField
      FieldName = 'DADOS_OUTRO_BANCO'
      Size = 50
    end
    object SqlCadastroID_ME: TStringField
      FieldName = 'ID_ME'
      Size = 100
    end
    object SqlCadastroDIGITAL_CHAVE: TStringField
      FieldName = 'DIGITAL_CHAVE'
      Size = 2000
    end
    object SqlCadastroDIGITAL_IMAGEM: TBlobField
      FieldName = 'DIGITAL_IMAGEM'
    end
    object SqlCadastroID_PRESIDIO_ORIGEM: TIntegerField
      FieldName = 'ID_PRESIDIO_ORIGEM'
    end
    object SqlCadastroID_SOLICITANTE_VAGA: TIntegerField
      FieldName = 'ID_SOLICITANTE_VAGA'
    end
    object SqlCadastroCOLABORADOR: TStringField
      FieldName = 'COLABORADOR'
      Size = 1
    end
  end
  inherited DspCadastro: TDataSetProvider
    Left = 54
    Top = 11
  end
  inherited CdsCadastro: TClientDataSet
    IndexFieldNames = 'ID_INTERNO'
    MasterFields = 'ID_INTERNO'
    MasterSource = DsConsulta
    PacketRecords = 0
    BeforePost = CdsCadastroBeforePost
    Left = 82
    Top = 11
  end
  inherited DsCadastro: TDataSource
    Left = 110
    Top = 11
  end
  object OpenDialogCapturarFoto: TOpenDialog
    Filter = 'Imagens (*.jpg)|*.jpg'
    Left = 679
    Top = 8
  end
  object SqlConsulta: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'select '
      '    interno.nome_interno,'
      '    interno.rgi,'
      '    INTERNO.VULGO,'
      '    faccao.FACCAO,'
      '    '#39#39' as  nome_interno_soundex,'
      '    unidade_penal.sigla,'
      '    pavilhao.pavilhao,'
      '    galeria.galeria,'
      '    solario.solario,'
      '    cela.cela,'
      '    interno.id_interno,'
      '    interno.id_up,'
      '    interno.idpavilhao,'
      '    interno.idgaleria,'
      '    interno.idsolario,'
      '    coalesce(interno.st,'#39'I'#39') as st,'
      '    interno.numero_roupa,'
      '    iif(coalesce(interno.st,'#39'I'#39')='#39'A'#39','#39'ATIVO'#39', '#39'INATIVO'#39') status,'
      '    interno.em_transito,'
      
        '    PROCEDENCIA.PROEDENCIA||'#39'/'#39'||coalesce(PROCEDENCIA.UF,'#39'UF'#39') A' +
        'S PROCEDENCIA'
      'from interno'
      '  left join cela on (cela.id_cela = interno.idcela)'
      
        '  left join pavilhao on (interno.idpavilhao = pavilhao.id_pavilh' +
        'ao)'
      
        '  left join unidade_penal on (pavilhao.id_up = unidade_penal.id_' +
        'up)'
      '  left  join galeria on (interno.idgaleria = galeria.id_galeria)'
      '  left  join solario on (interno.idsolario = solario.id_solario)'
      '  left join faccao on (interno.id_faccao = faccao.id_faccao)'
      
        '   LEFT JOIN PROCEDENCIA ON (INTERNO.ID_PROCEDENCIA = PROCEDENCI' +
        'A.ID_PROCEDENCIA)'
      'where coalesce(interno.nome_interno,'#39#39')<>'#39#39
      'ORDER BY INTERNO.NOME_INTERNO'
      ''
      ' ')
    SQLConnection = DM.SQLConnect
    Left = 41
    Top = 295
  end
  object DspConsulta: TDataSetProvider
    DataSet = SqlConsulta
    Left = 72
    Top = 295
  end
  object CdsConsulta: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DspConsulta'
    OnFilterRecord = CdsConsultaFilterRecord
    Left = 113
    Top = 295
  end
  object DsConsulta: TDataSource
    DataSet = CdsConsulta
    OnDataChange = DsConsultaDataChange
    Left = 149
    Top = 295
  end
  object SqlSelectInterno: TSQLQuery
    Params = <>
    SQL.Strings = (
      'select '
      '    interno.nome_interno,'
      '    unidade_penal.sigla,'
      '    pavilhao.pavilhao,'
      '    solario.solario,'
      '    cela.cela,'
      '    interno.id_interno,'
      'interno.idpavilhao,'
      'interno.idgaleria,'
      'interno.idsolario,'
      'iif(interno.st='#39'A'#39','#39'ATIVO'#39', '#39'INATIVO'#39') status'
      'from cela'
      '   inner join interno on (cela.id_cela = interno.idcela)'
      
        '   inner join pavilhao on (interno.idpavilhao = pavilhao.id_pavi' +
        'lhao)'
      
        '   inner join unidade_penal on (pavilhao.id_up = unidade_penal.i' +
        'd_up)'
      
        '   inner join solario on (interno.idsolario = solario.id_solario' +
        ')'
      '   ')
    Left = 640
    Top = 12
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
      'where idinterno=:id_interno'
      'order by data_hora desc, IDHISTORICO_INTERNO desc')
    SQLConnection = DM.SQLConnect
    Left = 177
    Top = 17
  end
  object DSPHISTORICO_interno: TDataSetProvider
    DataSet = SQLHISTORICO_interno
    Left = 205
    Top = 17
  end
  object CDSHISTORICO_interno: TClientDataSet
    Aggregates = <>
    IndexFieldNames = 'IDINTERNO'
    MasterFields = 'ID_INTERNO'
    MasterSource = DsCadastro
    PacketRecords = 0
    Params = <>
    ProviderName = 'DSPHISTORICO_interno'
    Left = 233
    Top = 17
  end
  object DSHISTORICO_interno: TDataSource
    DataSet = CDSHISTORICO_interno
    OnDataChange = DsCadastroDataChange
    Left = 261
    Top = 17
  end
  object SqlSelectInternoInativo: TSQLQuery
    Params = <>
    SQL.Strings = (
      'select '
      '   nome_interno,'
      '   '#39'INAT'#39' sigla,'
      '   '#39#39' pavilhao,'
      '   '#39#39' solario,'
      '   '#39#39' cela,'
      '    id_interno,'
      '    idpavilhao,'
      '    idgaleria,'
      '    idsolario,'
      ' '#39'INATIVO'#39' status'
      'from interno')
    Left = 592
    Top = 12
  end
  object SqlSoundex: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'select '
      '    interno.nome_interno,'
      
        '    (SELECT RET FROM soundex(interno.nome_interno)) nome_interno' +
        '_soundex,'
      '    unidade_penal.sigla,'
      '    pavilhao.pavilhao,'
      '    solario.solario,'
      '    cela.cela,'
      '    interno.id_interno,'
      '    interno.id_up,'
      '    interno.idpavilhao,'
      '    interno.idgaleria,'
      '    interno.idsolario,'
      '    interno.st,'
      '    iif(interno.st='#39'A'#39','#39'ATIVO'#39', '#39'INATIVO'#39') status'
      'from interno'
      '   join cela on (cela.id_cela = interno.idcela)'
      '   join pavilhao on (interno.idpavilhao = pavilhao.id_pavilhao)'
      '   join unidade_penal on (pavilhao.id_up = unidade_penal.id_up)'
      '   join solario on (interno.idsolario = solario.id_solario)'
      'where interno.nome_interno is not null'
      'order by interno.nome_interno'
      ''
      ' ')
    SQLConnection = DM.SQLConnect
    Left = 529
    Top = 15
  end
  object dsADVOGADO_INTERNO: TDataSource
    DataSet = cdsadvogadointerno
    Left = 800
    Top = 8
  end
  object cdsadvogadointerno: TClientDataSet
    Aggregates = <>
    IndexFieldNames = 'ID_INTERNO'
    MasterFields = 'ID_INTERNO'
    MasterSource = DsCadastro
    PacketRecords = 0
    Params = <>
    ProviderName = 'dspadvogadointerno'
    Left = 776
    Top = 8
    object cdsadvogadointernoADVOGADOESCRITRIO: TStringField
      FieldKind = fkLookup
      FieldName = 'ADVOGADO'
      LookupDataSet = DM.CDSADVOGADO
      LookupKeyFields = 'ID_ADVOGADO'
      LookupResultField = 'ADVOGADO'
      KeyFields = 'ID_ADVOGADO'
      Size = 50
      Lookup = True
    end
    object cdsadvogadointernoID_ADVOGADOS_INTERNOS: TIntegerField
      FieldName = 'ID_ADVOGADOS_INTERNOS'
      Required = True
    end
    object cdsadvogadointernoID_ADVOGADO: TIntegerField
      FieldName = 'ID_ADVOGADO'
    end
    object cdsadvogadointernoID_INTERNO: TIntegerField
      FieldName = 'ID_INTERNO'
    end
    object cdsadvogadointernoOBSADVOGADO_INTERNO: TStringField
      FieldName = 'OBSADVOGADO_INTERNO'
      Size = 8192
    end
    object cdsadvogadointernoSTATUS: TStringField
      FieldName = 'STATUS'
      Size = 1
    end
    object cdsadvogadointernoDATA_CONSTITUICAO: TSQLTimeStampField
      FieldName = 'DATA_CONSTITUICAO'
    end
    object cdsadvogadointernoDATA_DESCONSTITUICAO: TSQLTimeStampField
      FieldName = 'DATA_DESCONSTITUICAO'
    end
  end
  object dspadvogadointerno: TDataSetProvider
    DataSet = SQLadvogadointerno
    Left = 752
    Top = 8
  end
  object SQLadvogadointerno: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'id_interno'
        ParamType = ptInput
      end>
    SQL.Strings = (
      'SELECT ai.*'
      'FROM advogados_internos ai'
      'inner join advogado a on (ai.id_advogado = a.id_advogado)'
      'where ai.id_interno = :id_interno'
      
        'order by ai.status, a.advogado, ai.data_constituicao, ai.data_de' +
        'sconstituicao')
    SQLConnection = DM.SQLConnect
    Left = 728
    Top = 8
  end
  object SqlFilhos: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'id_interno'
        ParamType = ptInput
      end>
    SQL.Strings = (
      'select *'
      'from filhos'
      'where idinterno=:id_interno'
      '')
    SQLConnection = DM.SQLConnect
    Left = 1
    Top = 353
  end
  object DspFilhos: TDataSetProvider
    DataSet = SqlFilhos
    Left = 29
    Top = 353
  end
  object CdsFilhos: TClientDataSet
    Aggregates = <>
    IndexFieldNames = 'IDINTERNO'
    MasterFields = 'ID_INTERNO'
    MasterSource = DsCadastro
    PacketRecords = 0
    Params = <>
    ProviderName = 'DspFilhos'
    BeforePost = CdsFilhosBeforePost
    Left = 57
    Top = 353
    object CdsFilhosIDFILHOS: TIntegerField
      FieldName = 'IDFILHOS'
      Required = True
    end
    object CdsFilhosNOME: TStringField
      FieldName = 'NOME'
      Size = 50
    end
    object CdsFilhosDATA_NASCIMENTO: TSQLTimeStampField
      FieldName = 'DATA_NASCIMENTO'
    end
    object CdsFilhosESCOLA: TStringField
      FieldName = 'ESCOLA'
      Size = 100
    end
    object CdsFilhosENDERECO: TStringField
      FieldName = 'ENDERECO'
      Size = 100
    end
    object CdsFilhosIDCIDADE: TIntegerField
      FieldName = 'IDCIDADE'
    end
    object CdsFilhosNOME_MAE: TStringField
      FieldName = 'NOME_MAE'
      Size = 50
    end
    object CdsFilhosIDINTERNO: TIntegerField
      FieldName = 'IDINTERNO'
    end
  end
  object DsFilhos: TDataSource
    DataSet = CdsFilhos
    OnDataChange = DsCadastroDataChange
    Left = 85
    Top = 353
  end
  object DsLista: TDataSource
    DataSet = CdsLista
    OnDataChange = DsCadastroDataChange
    Left = 540
  end
  object CdsLista: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DspLista'
    BeforePost = CdsCadastroBeforePost
    Left = 512
  end
  object DspLista: TDataSetProvider
    DataSet = SqlLista
    Left = 484
  end
  object SqlLista: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT DISTINCT FACCAO FROM INTERNO')
    SQLConnection = DM.SQLConnect
    Left = 456
  end
  object PopupMenuRecuperarFotoEmergencia: TPopupMenu
    Left = 80
    Top = 400
    object Recalculartodasasfotos1: TMenuItem
      Caption = 'Recarregar todas as fotos'
      OnClick = Recalculartodasasfotos1Click
    end
    object N1: TMenuItem
      Caption = '-'
    end
    object RecuperarFotosdeArquivo1: TMenuItem
      Caption = 'Recuperar Fotos de Arquivo'
      OnClick = RecuperarFotosdeArquivo1Click
    end
  end
  object SqlConsultaBackup: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'select '
      '    interno.nome_interno,'
      '    interno.rgi,'
      '    INTERNO.VULGO,'
      '    faccao.FACCAO,'
      '    '#39#39' as  nome_interno_soundex,'
      '    unidade_penal.sigla,'
      '    pavilhao.pavilhao,'
      '    galeria.galeria,'
      '    solario.solario,'
      '    cela.cela,'
      '    interno.id_interno,'
      '    interno.id_up,'
      '    interno.idpavilhao,'
      '    interno.idgaleria,'
      '    interno.idsolario,'
      '    coalesce(interno.st,'#39'I'#39') as st,'
      '    interno.numero_roupa,'
      '    iif(coalesce(interno.st,'#39'I'#39')='#39'A'#39','#39'ATIVO'#39', '#39'INATIVO'#39') status,'
      '    interno.em_transito,'
      
        '    PROCEDENCIA.PROEDENCIA||'#39'/'#39'||coalesce(PROCEDENCIA.UF,'#39'UF'#39') A' +
        'S PROCEDENCIA,'
      
        '    IIF(TRIM(COALESCE(estado.estado,'#39#39'))='#39#39','#39'N'#195'O INFORMADO'#39',esta' +
        'do.estado) as ESTADO_SOLICITANTE'
      'from interno'
      '   left join cela on (cela.id_cela = interno.idcela)'
      
        '   left join pavilhao on (interno.idpavilhao = pavilhao.id_pavil' +
        'hao)'
      
        '   left join unidade_penal on (pavilhao.id_up = unidade_penal.id' +
        '_up)'
      '   left join galeria on (interno.idgaleria = galeria.id_galeria)'
      '   left join solario on (interno.idsolario = solario.id_solario)'
      '   left join faccao on (interno.id_faccao = faccao.id_faccao)'
      
        '   LEFT JOIN PROCEDENCIA ON (INTERNO.ID_PROCEDENCIA = PROCEDENCI' +
        'A.ID_PROCEDENCIA)'
      
        '   LEFT JOIN  CIDADE ON (INTERNO.ID_SOLICITANTE_VAGA = CIDADE.ID' +
        '_CIDADE)'
      '   LEFT JOIN ESTADO ON (CIDADE.UF = ESTADO.UF)'
      'where coalesce(interno.nome_interno,'#39#39')<>'#39#39)
    SQLConnection = DM.SQLConnect
    Left = 8
    Top = 296
  end
  object MainMenu1: TMainMenu
    Left = 219
    Top = 40
    object Relatorios1: TMenuItem
      Caption = 'Relat'#243'rios'
      object Especifico1: TMenuItem
        Caption = 'Espec'#237'ficos'
        OnClick = Especifico1Click
      end
    end
  end
  object DsFaccao: TDataSource
    DataSet = CdsFaccao
    Left = 100
    Top = 64
  end
  object CdsFaccao: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'dspFaccao'
    Left = 72
    Top = 64
  end
  object DspFaccao: TDataSetProvider
    DataSet = SqlFaccao
    Left = 44
    Top = 64
  end
  object SqlFaccao: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      
        'SELECT  COALESCE(FACCAO,'#39#39') || '#39' - '#39' || COALESCE(SIGLA,'#39#39')  AS F' +
        'ACCAO, ID_FACCAO'
      'FROM FACCAO'
      'ORDER BY FACCAO')
    Left = 16
    Top = 64
  end
  object SqlFoto: TSQLQuery
    MaxBlobSize = -1
    Params = <
      item
        DataType = ftInteger
        Name = 'id_interno'
        ParamType = ptInput
        Value = -1
      end>
    SQL.Strings = (
      'select *'
      'from foto_interno'
      'where id_interno=:id_interno'
      '')
    SQLConnection = DM.SQLConnect
    Left = 297
    Top = 1
  end
  object DspFoto: TDataSetProvider
    DataSet = SqlFoto
    Left = 325
    Top = 1
  end
  object CdsFoto: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DspFoto'
    AfterInsert = CdsFotoAfterInsert
    Left = 353
    Top = 1
  end
  object DsFoto: TDataSource
    DataSet = CdsFoto
    OnDataChange = DsCadastroDataChange
    Left = 381
    Top = 1
  end
end
