inherited FrmModeloInterno: TFrmModeloInterno
  Left = 264
  Top = 81
  Width = 943
  Height = 637
  Caption = 'FrmModeloInterno'
  KeyPreview = True
  Menu = MainMenu1
  OldCreateOrder = True
  PixelsPerInch = 96
  TextHeight = 13
  inherited PanelBotoes: TPanel
    Height = 533
    inherited ToolBarModeloCadastro: TToolBar
      Height = 515
      ButtonWidth = 108
      inherited Novo: TToolButton
        Caption = '&N'#195'O'
        Visible = False
      end
      inherited Editar: TToolButton
        Caption = '&EDI'#199#195'O'
      end
      inherited Cancelar: TToolButton
        Caption = '&CANCELA'
      end
    end
    inherited DBNavigator1: TDBNavigator
      Top = 515
      DataSource = DsConsulta
      Hints.Strings = ()
      TabOrder = 2
    end
    object DBImage1: TDBImage
      Left = 8
      Top = 248
      Width = 97
      Height = 92
      BorderStyle = bsNone
      DataField = 'FOTO'
      DataSource = DsCadastro
      Enabled = False
      Stretch = True
      TabOrder = 1
    end
  end
  inherited PanelModeloCadastro: TPanel
    Width = 820
    Height = 533
    inherited PageControlModeloCadastro: TPageControl
      Width = 820
      Height = 533
      inherited TabSheetCadastro: TTabSheet
        inherited PanelCadastro: TPanel
          Width = 812
          Height = 505
          object PageControlPrincipal: TPageControl
            Left = 1
            Top = 1
            Width = 810
            Height = 503
            ActivePage = TabSheetPrincipal
            Align = alClient
            TabOrder = 0
            TabWidth = 150
            object TabSheetPrincipal: TTabSheet
              Caption = 'Identifica'#231#227'o'
              Enabled = False
              object Label2: TLabel
                Left = 196
                Top = 9
                Width = 11
                Height = 13
                Caption = 'ID'
                Enabled = False
                FocusControl = DBEditCodigo
              end
              object Label3: TLabel
                Left = 277
                Top = 9
                Width = 33
                Height = 13
                Caption = 'Interno'
                Enabled = False
                FocusControl = DBEdit2
              end
              object Label4: TLabel
                Left = 316
                Top = 55
                Width = 76
                Height = 13
                Caption = 'RGI (Prontu'#225'rio)'
                Enabled = False
                FocusControl = DBEdit3
              end
              object Label12: TLabel
                Left = 71
                Top = 293
                Width = 60
                Height = 13
                Caption = 'Procedencia'
                Enabled = False
              end
              object SpeedButton1: TSpeedButton
                Left = 336
                Top = 309
                Width = 23
                Height = 22
                Hint = 'Cadastrar Procedencia'
                Caption = '...'
                Enabled = False
                Flat = True
                ParentShowHint = False
                ShowHint = True
                OnClick = SpeedButton1Click
              end
              object Label45: TLabel
                Left = 68
                Top = 335
                Width = 96
                Height = 13
                Caption = 'Condi'#231#227'o do Interno'
                Enabled = False
              end
              object Label46: TLabel
                Left = 68
                Top = 247
                Width = 70
                Height = 13
                Caption = 'Unidade Penal'
                Enabled = False
              end
              object SpeedButton2: TSpeedButton
                Left = 336
                Top = 348
                Width = 23
                Height = 22
                Hint = 'Cadastrar Procedencia'
                Caption = '...'
                Enabled = False
                Flat = True
                ParentShowHint = False
                ShowHint = True
                OnClick = SpeedButton2Click
              end
              object Label27: TLabel
                Left = 196
                Top = 104
                Width = 57
                Height = 13
                Caption = 'Outro Nome'
                Enabled = False
                FocusControl = DBEdit24
              end
              object Label36: TLabel
                Left = 479
                Top = 104
                Width = 27
                Height = 13
                Caption = 'Vulgo'
                Enabled = False
                FocusControl = DBEdit25
              end
              object Label65: TLabel
                Left = 170
                Top = 203
                Width = 60
                Height = 13
                Caption = 'Nome Social'
                Enabled = False
                FocusControl = DBEdit35
              end
              object Label66: TLabel
                Left = 469
                Top = 203
                Width = 87
                Height = 13
                Caption = 'Orienta'#231#227'o Sexual'
                Enabled = False
              end
              object lbl1: TLabel
                Left = 196
                Top = 57
                Width = 76
                Height = 13
                Caption = 'Numero Infopen'
                Enabled = False
                FocusControl = DBEdit86
              end
              object Label43: TLabel
                Left = 10
                Top = 247
                Width = 11
                Height = 13
                Caption = 'ID'
                Enabled = False
                FocusControl = DBEdit7
              end
              object Label18: TLabel
                Left = 10
                Top = 293
                Width = 11
                Height = 13
                Caption = 'ID'
                Enabled = False
              end
              object Label44: TLabel
                Left = 10
                Top = 335
                Width = 11
                Height = 13
                Caption = 'ID'
                Enabled = False
                FocusControl = DBEdit6
              end
              object Label10: TLabel
                Left = 197
                Top = 158
                Width = 63
                Height = 13
                Caption = 'Data Entrada'
                Enabled = False
                FocusControl = DBEdit4
              end
              object Label40: TLabel
                Left = 282
                Top = 158
                Width = 55
                Height = 13
                Caption = 'Data Pris'#227'o'
                Enabled = False
              end
              object Label55: TLabel
                Left = 474
                Top = 157
                Width = 69
                Height = 13
                Caption = 'CI/OF Entrada'
                Enabled = False
                FocusControl = DBEdit29
              end
              object Label38: TLabel
                Left = 8
                Top = 205
                Width = 36
                Height = 13
                Caption = 'Regime'
                Enabled = False
              end
              object Label49: TLabel
                Left = 367
                Top = 158
                Width = 88
                Height = 13
                Caption = 'Data Perman'#234'ncia'
                Enabled = False
              end
              object Label54: TLabel
                Left = 368
                Top = 292
                Width = 36
                Height = 13
                Caption = 'Fac'#231#227'o'
                Enabled = False
              end
              object SpeedButton8: TSpeedButton
                Left = 641
                Top = 308
                Width = 23
                Height = 22
                Hint = 'Cadastrar Procedencia'
                Caption = '...'
                Enabled = False
                Flat = True
                ParentShowHint = False
                ShowHint = True
                OnClick = SpeedButton8Click
              end
              object Label78: TLabel
                Left = 10
                Top = 379
                Width = 30
                Height = 13
                Caption = 'Ano(s)'
                Enabled = False
              end
              object Label79: TLabel
                Left = 77
                Top = 379
                Width = 37
                Height = 13
                Caption = 'M'#234's(es)'
                Enabled = False
              end
              object Label80: TLabel
                Left = 144
                Top = 379
                Width = 27
                Height = 13
                Caption = 'Dia(s)'
                Enabled = False
              end
              object Label82: TLabel
                Left = 221
                Top = 379
                Width = 63
                Height = 13
                Caption = 'Regime Atual'
                Enabled = False
              end
              object Label83: TLabel
                Left = 493
                Top = 379
                Width = 110
                Height = 13
                Caption = 'Grau de Periculosidade'
                Enabled = False
              end
              object DBEditCodigo: TDBEdit
                Left = 196
                Top = 25
                Width = 77
                Height = 21
                DataField = 'ID_INTERNO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 1
              end
              object DBEdit2: TDBEdit
                Left = 280
                Top = 25
                Width = 369
                Height = 21
                CharCase = ecUpperCase
                DataField = 'NOME_INTERNO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 2
              end
              object DBEdit3: TDBEdit
                Left = 314
                Top = 72
                Width = 100
                Height = 21
                DataField = 'RGI'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 4
              end
              object DBEditID_PROCEDENCIA: TDBEdit
                Left = 10
                Top = 309
                Width = 52
                Height = 21
                DataField = 'ID_PROCEDENCIA'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 19
              end
              object DBLookupComboBoxID_PROCEDENCIA: TDBLookupComboBox
                Left = 68
                Top = 309
                Width = 265
                Height = 21
                DataField = 'ID_PROCEDENCIA'
                DataSource = DsCadastro
                Enabled = False
                KeyField = 'ID_PROCEDENCIA'
                ListField = 'PROCEDENCIA'
                ListSource = DM.DsProcedencia
                TabOrder = 20
              end
              object DBRadioGroup1: TDBRadioGroup
                Left = 535
                Top = 52
                Width = 113
                Height = 40
                Caption = 'Status'
                Columns = 2
                DataField = 'ST'
                DataSource = DsCadastro
                Enabled = False
                Items.Strings = (
                  'Ativo'
                  'Inativo')
                TabOrder = 6
                Values.Strings = (
                  'A'
                  'I')
              end
              object DBRadioGroup2: TDBRadioGroup
                Left = 507
                Top = 245
                Width = 142
                Height = 40
                Caption = 'Sexo'
                Columns = 2
                DataField = 'SEXO'
                DataSource = DsCadastro
                Enabled = False
                Items.Strings = (
                  'Masculino'
                  'Feminino')
                TabOrder = 18
                Values.Strings = (
                  'M'
                  'F')
              end
              object DBEdit6: TDBEdit
                Left = 10
                Top = 351
                Width = 52
                Height = 21
                DataField = 'IDCONDICAO_INTERNO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 22
              end
              object DBLookupComboBox1: TDBLookupComboBox
                Left = 68
                Top = 351
                Width = 265
                Height = 21
                DataField = 'IDCONDICAO_INTERNO'
                DataSource = DsCadastro
                Enabled = False
                KeyField = 'IDCONDICAO_INTERNO'
                ListField = 'DESCRICAO'
                ListSource = DM.DsCondicaoInterno
                TabOrder = 23
              end
              object DBEdit7: TDBEdit
                Left = 10
                Top = 263
                Width = 52
                Height = 21
                DataField = 'ID_UP'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 16
              end
              object DBLookupComboBox2: TDBLookupComboBox
                Left = 68
                Top = 263
                Width = 421
                Height = 21
                DataField = 'ID_UP'
                DataSource = DsCadastro
                Enabled = False
                KeyField = 'ID_UP'
                ListField = 'NOME_UP'
                ListSource = DM.DsUP
                TabOrder = 17
              end
              object DBImageFOTOInterno: TDBImage
                Left = 7
                Top = 12
                Width = 183
                Height = 179
                BorderStyle = bsNone
                DataField = 'FOTO'
                DataSource = DsCadastro
                Enabled = False
                Stretch = True
                TabOrder = 0
                OnClick = DBImageFOTOInternoClick
              end
              object DBEdit24: TDBEdit
                Left = 196
                Top = 120
                Width = 276
                Height = 21
                DataField = 'OUTRO_NOME'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 7
              end
              object DBEdit25: TDBEdit
                Left = 477
                Top = 120
                Width = 171
                Height = 21
                DataField = 'VULGO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 8
              end
              object DBEdit35: TDBEdit
                Left = 168
                Top = 220
                Width = 297
                Height = 21
                DataField = 'NOME_SOCIAL'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 14
              end
              object DBComboBox3: TDBComboBox
                Left = 469
                Top = 219
                Width = 180
                Height = 21
                Style = csDropDownList
                DataField = 'ORIENTACAO_SEXUAL'
                DataSource = DsCadastro
                Enabled = False
                ItemHeight = 13
                Items.Strings = (
                  'HOMOSEXUAL'
                  'BISSEXUAL'
                  'HETEROSEXUAL')
                TabOrder = 15
              end
              object DBEdit86: TDBEdit
                Left = 196
                Top = 72
                Width = 114
                Height = 21
                DataField = 'NUMERO_INFOPEN'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 3
              end
              object dbrgrpST: TDBRadioGroup
                Left = 420
                Top = 52
                Width = 113
                Height = 40
                Caption = 'Reinser'#231#227'o'
                Columns = 2
                DataField = 'REINCERSAO'
                DataSource = DsCadastro
                Enabled = False
                Items.Strings = (
                  'Sim'
                  'N'#227'o')
                TabOrder = 5
                Values.Strings = (
                  'S'
                  'N')
              end
              object DBEdit4: TDBEdit
                Left = 197
                Top = 174
                Width = 76
                Height = 21
                DataField = 'DATA_ENTRADA'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 9
              end
              object DBEdit20: TDBEdit
                Left = 282
                Top = 174
                Width = 79
                Height = 21
                DataField = 'DATA_PRISAO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 10
              end
              object DBEdit29: TDBEdit
                Left = 472
                Top = 173
                Width = 177
                Height = 21
                DataField = 'CI'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 12
              end
              object DBComboBox2: TDBComboBox
                Left = 8
                Top = 221
                Width = 153
                Height = 21
                Style = csDropDownList
                DataField = 'TIPOREGIME'
                DataSource = DsCadastro
                Enabled = False
                ItemHeight = 13
                Items.Strings = (
                  'Aberto'
                  'Fechado'
                  'Semiaberto')
                TabOrder = 13
              end
              object DBEditpermanencia: TDBEdit
                Left = 367
                Top = 174
                Width = 99
                Height = 21
                DataField = 'DATA_PERMANENCIA'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 11
              end
              object DBLookupComboBoxFACCAO: TDBLookupComboBox
                Left = 367
                Top = 308
                Width = 265
                Height = 21
                DataField = 'ID_FACCAO'
                DataSource = DsCadastro
                Enabled = False
                KeyField = 'ID_FACCAO'
                ListField = 'FACCAO'
                ListSource = DsFaccao
                TabOrder = 21
              end
              object DBEdit8: TDBEdit
                Left = 10
                Top = 395
                Width = 65
                Height = 21
                DataField = 'TEMPO_CONSOLIDADO_ANO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 24
              end
              object DBEdit31: TDBEdit
                Left = 77
                Top = 395
                Width = 65
                Height = 21
                DataField = 'TEMPO_CONSOLIDADO_MES'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 25
              end
              object DBEdit33: TDBEdit
                Left = 144
                Top = 395
                Width = 65
                Height = 21
                DataField = 'TEMPO_CONSOLIDADO_DIA'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 26
              end
              object DBComboBox5: TDBComboBox
                Left = 219
                Top = 395
                Width = 265
                Height = 21
                Style = csDropDownList
                DataField = 'REGIME_ATUAL'
                DataSource = DsCadastro
                Enabled = False
                ItemHeight = 13
                Items.Strings = (
                  'Aberto'
                  'Fechado'
                  'Mandado de Pris'#227'o C'#237'vel'
                  'Medida de Seguran'#231'a'
                  'Medida de Tratamento'
                  'Provis'#243'rio'
                  'Semi-Aberto Sem Sa'#237'da'
                  'Semi-Aberto Com Trabalho Externo'
                  'Semi-Aberto Com Sa'#237'da'
                  'Semi-Aberto Com Trabalho Concedido'
                  'Semi-Aberto Com Trabalho Concedido e Sa'#237'da'
                  'Semi-Aberto Com Trabalho e Sa'#237'da'
                  'Tempor'#225'rio'
                  'N'#227'o Informado')
                TabOrder = 27
              end
              object DBComboBox4: TDBComboBox
                Left = 493
                Top = 394
                Width = 164
                Height = 21
                Style = csDropDownList
                DataField = 'GRAU_PERICULOSIDADE'
                DataSource = DsCadastro
                Enabled = False
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
                TabOrder = 28
              end
            end
            object TabSheetDadosGerais: TTabSheet
              Caption = 'Dados Gerais'
              ImageIndex = 1
              object Label11: TLabel
                Left = 24
                Top = 56
                Width = 23
                Height = 13
                Caption = 'M'#195'E'
                Enabled = False
                FocusControl = DBEdit1
              end
              object Label19: TLabel
                Left = 297
                Top = 39
                Width = 15
                Height = 13
                Caption = 'Pai'
                Enabled = False
                FocusControl = DBEdit5
              end
              object Label21: TLabel
                Left = 297
                Top = 79
                Width = 68
                Height = 13
                Caption = 'Nacionalidade'
                Enabled = False
              end
              object Label22: TLabel
                Left = 24
                Top = 135
                Width = 29
                Height = 13
                Caption = 'RA'#199'A'
                Enabled = False
              end
              object Label23: TLabel
                Left = 10
                Top = 157
                Width = 61
                Height = 13
                Caption = 'Escolaridade'
                Enabled = False
              end
              object Label20: TLabel
                Left = 9
                Top = 79
                Width = 60
                Height = 13
                Caption = 'Naturalidade'
                Enabled = False
              end
              object Label37: TLabel
                Left = 9
                Top = 196
                Width = 38
                Height = 13
                Caption = 'Religi'#227'o'
                Enabled = False
              end
              object Label13: TLabel
                Left = 321
                Top = 196
                Width = 43
                Height = 13
                Caption = 'Profiss'#227'o'
                Enabled = False
              end
              object SpeedButton4: TSpeedButton
                Left = 269
                Top = 94
                Width = 23
                Height = 22
                Caption = '...'
                Enabled = False
                Flat = True
              end
              object SpeedButton5: TSpeedButton
                Left = 587
                Top = 94
                Width = 23
                Height = 22
                Caption = '...'
                Enabled = False
                Flat = True
              end
              object SpeedButton6: TSpeedButton
                Left = 222
                Top = 134
                Width = 23
                Height = 22
                Caption = '...'
                Enabled = False
                Flat = True
              end
              object SpeedButton7: TSpeedButton
                Left = 587
                Top = 173
                Width = 23
                Height = 22
                Caption = '...'
                Enabled = False
                Flat = True
              end
              object SpeedButton9: TSpeedButton
                Left = 587
                Top = 209
                Width = 23
                Height = 22
                Caption = '...'
                Enabled = False
                Flat = True
              end
              object Label5: TLabel
                Left = 122
                Top = -1
                Width = 16
                Height = 13
                Caption = 'RG'
                Enabled = False
                FocusControl = DBEdit9
              end
              object Label24: TLabel
                Left = 222
                Top = -1
                Width = 20
                Height = 13
                Caption = 'CPF'
                Enabled = False
                FocusControl = DBEdit19
              end
              object Label25: TLabel
                Left = 373
                Top = -1
                Width = 55
                Height = 13
                Caption = 'Estado Civil'
                Enabled = False
              end
              object Label39: TLabel
                Left = 513
                Top = -1
                Width = 27
                Height = 13
                Caption = 'Altura'
                Enabled = False
                FocusControl = DBEdit26
              end
              object Label47: TLabel
                Left = 569
                Top = -1
                Width = 24
                Height = 13
                Caption = 'Peso'
                Enabled = False
                FocusControl = DBEdit27
              end
              object Label52: TLabel
                Left = 9
                Top = -1
                Width = 82
                Height = 13
                Caption = 'Data Nascimento'
                Enabled = False
                FocusControl = DBEdit28
              end
              object Label63: TLabel
                Left = 250
                Top = 119
                Width = 66
                Height = 13
                Caption = 'Cor dos Olhos'
                Enabled = False
                FocusControl = DBEdit32
              end
              object Label64: TLabel
                Left = 411
                Top = 118
                Width = 77
                Height = 13
                Caption = 'Cor dos Cabelos'
                Enabled = False
                FocusControl = DBEdit34
              end
              object Label28: TLabel
                Left = 9
                Top = 232
                Width = 46
                Height = 13
                Caption = 'Endere'#231'o'
                Enabled = False
                FocusControl = DBEdit10
              end
              object Label30: TLabel
                Left = 73
                Top = 272
                Width = 27
                Height = 13
                Caption = 'Bairro'
                Enabled = False
                FocusControl = DBEdit12
              end
              object Label31: TLabel
                Left = 9
                Top = 313
                Width = 64
                Height = 13
                Caption = 'Complemento'
                Enabled = False
                FocusControl = DBEdit13
              end
              object Label32: TLabel
                Left = 489
                Top = 313
                Width = 21
                Height = 13
                Caption = 'CEP'
                Enabled = False
                FocusControl = DBEdit14
              end
              object Label33: TLabel
                Left = 9
                Top = 351
                Width = 33
                Height = 13
                Caption = 'Cidade'
                Enabled = False
              end
              object Label34: TLabel
                Left = 489
                Top = 351
                Width = 42
                Height = 13
                Caption = 'Telefone'
                Enabled = False
                FocusControl = DBEdit16
              end
              object Label35: TLabel
                Left = 377
                Top = 391
                Width = 37
                Height = 13
                Caption = 'Contato'
                Enabled = False
                FocusControl = DBEdit17
              end
              object SpeedButton11: TSpeedButton
                Left = 455
                Top = 365
                Width = 23
                Height = 22
                Hint = 'Cadastrar Cidade'
                Caption = '...'
                Enabled = False
                Flat = True
                ParentShowHint = False
                ShowHint = True
              end
              object lbl2: TLabel
                Left = 9
                Top = 391
                Width = 22
                Height = 13
                Caption = 'Pa'#237's'
                Enabled = False
              end
              object btn1: TSpeedButton
                Left = 343
                Top = 406
                Width = 23
                Height = 22
                Caption = '...'
                Enabled = False
                Flat = True
              end
              object Label6: TLabel
                Left = 9
                Top = 272
                Width = 37
                Height = 13
                Caption = 'Numero'
                Enabled = False
                FocusControl = DBEdit7
              end
              object Label7: TLabel
                Left = 9
                Top = 119
                Width = 26
                Height = 13
                Caption = 'Ra'#231'a'
                Enabled = False
              end
              object Label9: TLabel
                Left = 9
                Top = 40
                Width = 21
                Height = 13
                Caption = 'M'#227'e'
                Enabled = False
                FocusControl = DBEdit1
              end
              object DBEdit1: TDBEdit
                Left = 9
                Top = 55
                Width = 281
                Height = 21
                DataField = 'MAE'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 6
              end
              object DBEdit5: TDBEdit
                Left = 297
                Top = 55
                Width = 313
                Height = 21
                DataField = 'PAI'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 7
              end
              object DBLookupComboBoxIDNATURALIDADE: TDBLookupComboBox
                Left = 9
                Top = 95
                Width = 257
                Height = 21
                DataField = 'IDNATURALIDADE'
                DataSource = DsCadastro
                Enabled = False
                KeyField = 'ID_CIDADE'
                ListField = 'CIDADE'
                ListSource = DM.DSCIDADE
                TabOrder = 8
              end
              object DBLookupComboBoxIDNACIONALIDADE: TDBLookupComboBox
                Left = 297
                Top = 95
                Width = 281
                Height = 21
                DataField = 'IDNACIONALIDADE'
                DataSource = DsCadastro
                Enabled = False
                KeyField = 'ID_NACIONALIDADE'
                ListField = 'NACIONALIDADE'
                ListSource = DM.DSNACIONALIDADE
                TabOrder = 9
              end
              object DBLookupComboBoxIDRACA: TDBLookupComboBox
                Left = 9
                Top = 134
                Width = 209
                Height = 21
                DataField = 'IDRACA'
                DataSource = DsCadastro
                Enabled = False
                KeyField = 'ID_RACA'
                ListField = 'RACA'
                ListSource = DM.DSRACA
                TabOrder = 10
              end
              object DBLookupComboBoxIDESCOLARIDADE: TDBLookupComboBox
                Left = 9
                Top = 173
                Width = 569
                Height = 21
                DataField = 'IDESCOLARIDADE'
                DataSource = DsCadastro
                Enabled = False
                KeyField = 'ID_ESCOLARIDADE'
                ListField = 'ESCOLARIDADE'
                ListSource = DM.DSESCOLARIDADE
                TabOrder = 13
              end
              object DBLookupComboBoxIDPROFISSAO: TDBLookupComboBox
                Left = 321
                Top = 212
                Width = 257
                Height = 21
                DataField = 'IDPROFISSAO'
                DataSource = DsCadastro
                Enabled = False
                KeyField = 'ID_PROFISSAO'
                ListField = 'PROFISSAO'
                ListSource = DM.DsProfissao
                TabOrder = 15
              end
              object DBEdit9: TDBEdit
                Left = 122
                Top = 15
                Width = 98
                Height = 21
                DataField = 'RG'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 1
              end
              object DBEdit19: TDBEdit
                Left = 223
                Top = 15
                Width = 147
                Height = 21
                DataField = 'CPF'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 2
              end
              object DBComboBox1: TDBComboBox
                Left = 373
                Top = 15
                Width = 137
                Height = 21
                Style = csDropDownList
                DataField = 'ESTADO_CIVIL'
                DataSource = DsCadastro
                Enabled = False
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
                TabOrder = 3
              end
              object DBEdit26: TDBEdit
                Left = 513
                Top = 15
                Width = 49
                Height = 21
                DataField = 'ALTURA'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 4
              end
              object DBEdit27: TDBEdit
                Left = 569
                Top = 15
                Width = 41
                Height = 21
                DataField = 'PESO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 5
              end
              object DBEdit28: TDBEdit
                Left = 9
                Top = 15
                Width = 105
                Height = 21
                DataField = 'DATA_NASCIMENTO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 0
              end
              object DBEdit32: TDBEdit
                Left = 250
                Top = 134
                Width = 158
                Height = 21
                DataField = 'COR_OLHOS'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 11
              end
              object DBEdit34: TDBEdit
                Left = 410
                Top = 134
                Width = 200
                Height = 21
                DataField = 'COR_CABELOS'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 12
              end
              object DBEdit10: TDBEdit
                Left = 9
                Top = 248
                Width = 600
                Height = 21
                DataField = 'ENDERECO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 16
              end
              object DBEdit11: TDBEdit
                Left = 9
                Top = 288
                Width = 57
                Height = 21
                DataField = 'NUMERO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 17
              end
              object DBEdit12: TDBEdit
                Left = 73
                Top = 288
                Width = 537
                Height = 21
                DataField = 'BAIRRO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 18
              end
              object DBEdit13: TDBEdit
                Left = 9
                Top = 329
                Width = 465
                Height = 21
                DataField = 'COMPLEMENETO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 19
              end
              object DBEdit14: TDBEdit
                Left = 489
                Top = 329
                Width = 121
                Height = 21
                DataField = 'CEP'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 20
              end
              object DBEdit16: TDBEdit
                Left = 489
                Top = 367
                Width = 121
                Height = 21
                DataField = 'FONE'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 22
              end
              object DBEdit17: TDBEdit
                Left = 377
                Top = 407
                Width = 234
                Height = 21
                DataField = 'CONTATO'
                DataSource = DsCadastro
                Enabled = False
                TabOrder = 24
              end
              object DBLookupComboBoxIDCIDADE: TDBLookupComboBox
                Left = 9
                Top = 367
                Width = 441
                Height = 21
                DataField = 'IDCIDADE'
                DataSource = DsCadastro
                Enabled = False
                KeyField = 'ID_CIDADE'
                ListField = 'CIDADE'
                ListSource = DM.DSCIDADE
                TabOrder = 21
              end
              object DBLookupComboBoxIDNACIONALIDADE1: TDBLookupComboBox
                Left = 9
                Top = 407
                Width = 331
                Height = 21
                DataField = 'IDPAIS_ENDERECO'
                DataSource = DsCadastro
                Enabled = False
                KeyField = 'ID_NACIONALIDADE'
                ListField = 'NACIONALIDADE'
                ListSource = DM.DsPais
                TabOrder = 23
              end
              object DBComboBoxReligiao1: TDBComboBox
                Left = 9
                Top = 212
                Width = 281
                Height = 21
                Style = csDropDownList
                DataField = 'RELIGIAO'
                DataSource = DsCadastro
                Enabled = False
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
                TabOrder = 14
              end
            end
          end
        end
      end
      inherited TabSheetConsulta: TTabSheet
        inherited PanelLocalizaConsulta: TPanel
          Width = 812
          Height = 42
          DesignSize = (
            812
            42)
          inherited EditLocalizar: TEdit
            Left = 216
            Top = 6
            Width = 321
            Height = 31
            TabOrder = 2
          end
          object RadioGroupStatus: TRadioGroup
            Left = 675
            Top = -2
            Width = 121
            Height = 33
            Anchors = [akTop, akRight]
            Caption = 'Filtro'
            Columns = 2
            ItemIndex = 0
            Items.Strings = (
              'Ativo'
              'Inativo')
            TabOrder = 1
            OnClick = RadioGroupStatusClick
          end
          object chkSoundex: TCheckBox
            Left = 541
            Top = 10
            Width = 77
            Height = 17
            Caption = 'Fon'#233'tica'
            TabOrder = 3
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
          Top = 42
          Width = 812
          Height = 463
          inherited DBGridConsulta: TDBGrid
            Width = 802
            Height = 449
            DataSource = DsConsulta
            Columns = <
              item
                Expanded = False
                FieldName = 'NOME_INTERNO'
                Title.Caption = 'Nome do Interno'
                Width = 300
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'SIGLA'
                Title.Caption = 'Sigla'
                Width = 53
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'PAVILHAO'
                Title.Caption = 'Pavilh'#227'o'
                Width = 94
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'SOLARIO'
                Title.Caption = 'Solario'
                Width = 83
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'CELA'
                Title.Caption = 'Cela'
                Width = 62
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'STATUS'
                Title.Caption = 'Status'
                Width = 62
                Visible = True
              end>
          end
          object DBCtrlGridConsulta: TDBCtrlGrid
            Left = 1
            Top = 1
            Width = 801
            Height = 445
            Align = alClient
            DataSource = DsConsulta
            PanelHeight = 89
            PanelWidth = 785
            TabOrder = 1
            RowCount = 5
            SelectedColor = clSilver
            OnDblClick = DBGridConsultaDblClick
            object LabelNome: TLabel
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
            object Label73sigla: TLabel
              Left = 82
              Top = 59
              Width = 23
              Height = 13
              Caption = 'Sigla'
              OnDblClick = DBGridConsultaDblClick
            end
            object Label74vulgo: TLabel
              Left = 449
              Top = 4
              Width = 27
              Height = 13
              Caption = 'Vulgo'
              OnDblClick = DBGridConsultaDblClick
            end
            object DBTextNomeInterno: TDBText
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
            object DBTextVulgo: TDBText
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
            object DBTextSigla: TDBText
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
            object DBTextPavilhao: TDBText
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
            object DBTextGaleria: TDBText
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
            object DBTextSolario: TDBText
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
            object DBTextCela: TDBText
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
            object Label75facacao: TLabel
              Left = 449
              Top = 31
              Width = 36
              Height = 13
              Caption = 'Fac'#231#227'o'
              OnDblClick = DBGridConsultaDblClick
            end
            object DBTextFaccao: TDBText
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
            object DBTextEstado: TDBText
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
            object LabelProced: TLabel
              Left = 82
              Top = 31
              Width = 128
              Height = 13
              Caption = 'Estado Solicitante da Vaga'
              OnDblClick = DBGridConsultaDblClick
            end
            object Image1: TImage
              Left = 28
              Top = 47
              Width = 34
              Height = 34
              Picture.Data = {}
            end
            object Label69: TLabel
              Left = 11
              Top = 2
              Width = 48
              Height = 13
              Caption = 'Prontu'#225'rio'
            end
            object DBTextProntuario: TDBText
              Left = 10
              Top = 17
              Width = 63
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
            object LabelST: TLabel
              Left = 699
              Top = 58
              Width = 30
              Height = 13
              Caption = 'Status'
              OnDblClick = DBGridConsultaDblClick
            end
            object DBTextST: TDBText
              Left = 700
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
    Width = 935
    inherited Image2: TImage
      Width = 935
    end
  end
  inherited StatusBar1: TStatusBar
    Top = 565
    Width = 935
    Height = 26
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
    Left = 776
    Top = 168
  end
  inherited DspCadastro: TDataSetProvider
    Left = 804
    Top = 168
  end
  inherited CdsCadastro: TClientDataSet
    IndexFieldNames = 'ID_INTERNO'
    MasterFields = 'ID_INTERNO'
    MasterSource = DsConsulta
    PacketRecords = 0
    Left = 840
    Top = 168
  end
  inherited DsCadastro: TDataSource
    Left = 876
    Top = 168
  end
  object DsConsulta: TDataSource
    DataSet = CdsConsulta
    OnDataChange = DsConsultaDataChange
    Left = 341
    Top = 65535
  end
  object CdsConsulta: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DspConsulta'
    OnFilterRecord = CdsConsultaFilterRecord
    Left = 313
    Top = 65535
  end
  object DspConsulta: TDataSetProvider
    DataSet = SqlConsulta
    Left = 285
    Top = 65535
  end
  object SqlConsulta: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'select'
      '    interno.nome_interno,'
      '    interno.rgi,'
      '    INTERNO.VULGO,'
      '    FACCAO.FACCAO,'
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
      '    coalesce(interno.st,'#39#39') as st,'
      '    interno.numero_roupa,'
      '    iif(interno.st='#39'A'#39','#39'ATIVO'#39', '#39'INATIVO'#39') status,'
      '    interno.em_transito,'
      
        '    PROCEDENCIA.PROEDENCIA||'#39'/'#39'||coalesce(PROCEDENCIA.UF,'#39'UF'#39') A' +
        'S PROCEDENCIA,'
      
        '   IIF(TRIM(COALESCE(estado.estado,'#39#39'))='#39#39','#39'N'#195'O INFORMADO'#39',estad' +
        'o.estado) as ESTADO_SOLICITANTE'
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
      'where coalesce(interno.nome_interno,'#39#39')<>'#39#39
      'ORDER BY INTERNO.NOME_INTERNO collate win_ptbr')
    SQLConnection = DM.SQLConnect
    Left = 257
    Top = 65535
  end
  object SqlConsultaBackup: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'select '
      '    interno.nome_interno,'
      '    interno.rgi,'
      '    INTERNO.VULGO,'
      '    FACCAO.FACCAO,'
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
      '    coalesce(interno.st,'#39#39') as st,'
      '    interno.numero_roupa,'
      '    iif(interno.st='#39'A'#39','#39'ATIVO'#39', '#39'INATIVO'#39') status,'
      '    interno.em_transito,'
      
        '    PROCEDENCIA.PROEDENCIA||'#39'/'#39'||coalesce(PROCEDENCIA.UF,'#39'UF'#39') A' +
        'S PROCEDENCIA,'
      
        '   IIF(TRIM(COALESCE(estado.estado,'#39#39'))='#39#39','#39'N'#195'O INFORMADO'#39',estad' +
        'o.estado) as ESTADO_SOLICITANTE'
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
    Left = 168
  end
  object MainMenu1: TMainMenu
    Left = 219
    object Relatorios1: TMenuItem
      Caption = 'Relat'#243'rios'
      object Especifico1: TMenuItem
        Caption = 'Espec'#237'ficos'
        OnClick = Especifico1Click
      end
    end
  end
  object SqlFaccao: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT * '
      'FROM FACCAO')
    Left = 16
    Top = 64
  end
  object DspFaccao: TDataSetProvider
    DataSet = SqlFaccao
    Left = 44
    Top = 64
  end
  object CdsFaccao: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'dspFaccao'
    Left = 72
    Top = 64
  end
  object DsFaccao: TDataSource
    DataSet = CdsFaccao
    Left = 100
    Top = 64
  end
  object OpenDialogCapturarFoto: TOpenDialog
    Filter = 'Imagens (*.jpg)|*.jpg'
    Left = 679
    Top = 8
  end
end
