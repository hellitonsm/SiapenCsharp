object FrmModuloPrincipal: TFrmModuloPrincipal
  Left = 386
  Top = 263
  Width = 1014
  Height = 760
  HorzScrollBar.Visible = False
  VertScrollBar.Visible = False
  Caption = 'SIAPEN'
  Color = clWhite
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  KeyPreview = True
  Menu = MainMenu1
  OldCreateOrder = False
  Position = poScreenCenter
  WindowState = wsMaximized
  OnActivate = FormActivate
  OnCloseQuery = FormCloseQuery
  OnCreate = FormCreate
  OnKeyDown = FormKeyDown
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object Bevel1: TBevel
    Left = 0
    Top = 0
    Width = 1163
    Height = 714
    Align = alClient
  end
  object PanelCabecalho: TPanel
    Left = 0
    Top = 0
    Width = 1163
    Height = 147
    Caption = 'SIAPEN - Ativando o sistema, aguarde...'
    Color = clMenu
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -29
    Font.Name = 'Times New Roman'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 0
    object Image2: TImage
      Left = 1
      Top = 1
      Width = 1161
      Height = 145
      Align = alClient
      Visible = False
    end
  end
  object PageControlSiap: TPageControl
    Left = 0
    Top = 144
    Width = 1154
    Height = 558
    ActivePage = TabSheet1
    Images = ImageList1
    MultiLine = True
    TabOrder = 1
    TabWidth = 150
    OnChange = PageControlSiapChange
    object TabSheet1: TTabSheet
      Caption = 'Principal'
      ImageIndex = 25
      object Image1: TImage
        Left = 3
        Top = 64
        Width = 977
        Height = 529
        Center = True
        Visible = False
      end
      object LabelLOGIN: TLabel
        Left = 659
        Top = 429
        Width = 287
        Height = 42
        Alignment = taCenter
        AutoSize = False
        Caption = '-----------------------------'
        Color = clBlack
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -13
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        Layout = tlCenter
      end
      object LabelDatabase: TLabel
        Left = 406
        Top = 455
        Width = 164
        Height = 16
        Alignment = taCenter
        AutoSize = False
        Caption = '----------------------------'
        Color = clBlack
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -16
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        Layout = tlCenter
      end
      object LabelDATA_HORA: TLabel
        Left = 34
        Top = 429
        Width = 287
        Height = 42
        Alignment = taCenter
        AutoSize = False
        Caption = '----------------------------'
        Color = clBlack
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -24
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentColor = False
        ParentFont = False
        Layout = tlCenter
      end
      object BitBtn7: TBitBtn
        Left = 658
        Top = 202
        Width = 289
        Height = 70
        Hint = 
          'Os lan'#231'amentos de hist'#243'ricos dever'#227'o ser feitos atrav'#233's do respe' +
          'ctivo m'#243'dulo do Setor!'
        Caption = 'Hist'#243'rico / Ficha Disciplinar'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 6
        TabStop = False
        WordWrap = True
        OnClick = BitBtn7Click
      end
      object BtnAgendaAtendimento: TBitBtn
        Left = 32
        Top = 106
        Width = 289
        Height = 70
        Caption = 'Agenda de Atendimento'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 3
        TabStop = False
        WordWrap = True
        OnClick = BtnAgendaAtendimentoClick
      end
      object BtnConfere: TBitBtn
        Left = 32
        Top = 10
        Width = 289
        Height = 70
        Caption = 'Confere'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 0
        TabStop = False
        OnClick = BtnConfereClick
        Style = bsWin31
      end
      object Btnconsultageral: TBitBtn
        Left = 658
        Top = 106
        Width = 289
        Height = 70
        Caption = 'Consulta'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 4
        TabStop = False
        OnClick = BtnconsultageralClick
      end
      object Btnrelatorio: TBitBtn
        Left = 658
        Top = 10
        Width = 289
        Height = 70
        Caption = 'Relat'#243'rios'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 1
        TabStop = False
        OnClick = BtnrelatorioClick
      end
      object pnl1: TPanel
        Left = 31
        Top = 277
        Width = 290
        Height = 144
        Caption = 'Panel1'
        TabOrder = 7
        object frxPreview2: TfrxPreview
          Left = 1
          Top = 1
          Width = 288
          Height = 142
          Align = alClient
          BorderStyle = bsNone
          OutlineVisible = True
          OutlineWidth = 121
          PopupMenu = pm1
          ThumbnailVisible = False
          FindFmVisible = False
          UseReportHints = True
          OutlineTreeSortType = dtsUnsorted
          HideScrolls = False
        end
      end
      object Panel1: TPanel
        Left = 658
        Top = 278
        Width = 290
        Height = 144
        TabOrder = 8
        object frxPreview1: TfrxPreview
          Left = 1
          Top = 1
          Width = 288
          Height = 142
          Align = alClient
          BorderStyle = bsNone
          OutlineVisible = True
          OutlineWidth = 121
          PopupMenu = PopupMenu1
          ThumbnailVisible = False
          FindFmVisible = False
          OnClick = frxPreview1Click
          UseReportHints = True
          OutlineTreeSortType = dtsUnsorted
          HideScrolls = False
        end
      end
      object DBLookupComboBoxUP: TDBLookupComboBox
        Left = 333
        Top = 11
        Width = 310
        Height = 21
        Color = clMenuText
        DataField = 'ID_UP'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        KeyField = 'ID_UP'
        ListField = 'NOME_UP'
        ListSource = DsUP
        ParentFont = False
        TabOrder = 2
        OnClick = DBLookupComboBoxUPClick
      end
      object BitBtn20: TBitBtn
        Left = 32
        Top = 202
        Width = 289
        Height = 70
        Caption = 'Requerimentos'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 5
        TabStop = False
        WordWrap = True
        OnClick = BitBtn20Click
      end
      object RadioGroupBancoDados: TRadioGroup
        Left = 34
        Top = 474
        Width = 913
        Height = 33
        Caption = 'Banco de dados ativo'
        Columns = 16
        TabOrder = 9
        OnClick = RadioGroupBancoDadosClick
      end
      object BitBtnOcorrencia: TBitBtn
        Left = 341
        Top = 106
        Width = 300
        Height = 70
        Caption = 'Ocorr'#234'ncias Administrativas'
        Font.Charset = ANSI_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 10
        OnClick = BitBtnOcorrenciaClick
      end
    end
    object TabSheet2: TTabSheet
      Caption = 'Setores'
      ImageIndex = 23
      object BitBtn1: TBitBtn
        Left = 32
        Top = 96
        Width = 289
        Height = 60
        Caption = 'Disciplina'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 3
        TabStop = False
        OnClick = Disciplina2Click
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn2: TBitBtn
        Left = 32
        Top = 180
        Width = 289
        Height = 60
        Caption = 'Educa'#231#227'o'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 6
        TabStop = False
        OnClick = educClick
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn3: TBitBtn
        Left = 344
        Top = 15
        Width = 289
        Height = 60
        Caption = 'Jur'#237'dico'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 1
        TabStop = False
        OnClick = BitBtn3Click
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn4: TBitBtn
        Left = 344
        Top = 351
        Width = 289
        Height = 60
        Caption = 'Psicossocial'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 13
        TabStop = False
        OnClick = PSICOSSOCIAL1Click
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn5: TBitBtn
        Left = 656
        Top = 267
        Width = 289
        Height = 60
        Caption = 'Trabalho'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 11
        TabStop = False
        OnClick = trabalho2Click
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn6: TBitBtn
        Left = 344
        Top = 180
        Width = 289
        Height = 60
        Caption = 'Pedagogia'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 7
        TabStop = False
        OnClick = PedagogiaClick
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn8: TBitBtn
        Left = 656
        Top = 182
        Width = 289
        Height = 60
        Caption = 'Servi'#231'o Social'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 8
        TabStop = False
        OnClick = ServicoSocialClick
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn9: TBitBtn
        Left = 656
        Top = 350
        Width = 289
        Height = 60
        Caption = 'Terapia Ocupacional'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 14
        TabStop = False
        OnClick = erapiaOcupacionalClick
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn10: TBitBtn
        Left = 32
        Top = 352
        Width = 289
        Height = 60
        Caption = 'Farm'#225'cia'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 12
        TabStop = False
        OnClick = farmaciaClick
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn11: TBitBtn
        Left = 344
        Top = 97
        Width = 289
        Height = 60
        Caption = 'Odontologia'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 4
        TabStop = False
        OnClick = OdontologiaClick
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn12: TBitBtn
        Left = 344
        Top = 266
        Width = 289
        Height = 60
        Caption = 'Psicologia'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 10
        TabStop = False
        OnClick = PsicologiaClick
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn13: TBitBtn
        Left = 657
        Top = 16
        Width = 289
        Height = 60
        Caption = 'Psiquiatria'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 2
        TabStop = False
        OnClick = PsiquiatriaClick
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn14: TBitBtn
        Left = 32
        Top = 266
        Width = 289
        Height = 60
        Caption = 'Enfermagem'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 9
        TabStop = False
        OnClick = EnfermagemClick
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn15: TBitBtn
        Left = 32
        Top = 14
        Width = 289
        Height = 60
        Caption = 'Cl'#237'nica M'#233'dica'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 0
        TabStop = False
        OnClick = clinicamedicaClick
        Glyph.Data = {}
        Style = bsWin31
      end
      object BitBtn16: TBitBtn
        Left = 656
        Top = 97
        Width = 289
        Height = 60
        Caption = 'Sa'#250'de'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
        TabOrder = 5
        TabStop = False
        OnClick = Sade2Click
        Glyph.Data = {}
        Style = bsWin31
      end
    end
    object TabSheetProcedimentos: TTabSheet
      Caption = 'Procedimentos'
      ImageIndex = 19
      TabVisible = False
      object ToolBar1: TToolBar
        Left = 0
        Top = 0
        Width = 1146
        Height = 28
        ButtonHeight = 21
        ButtonWidth = 128
        Caption = 'ToolBar1'
        ShowCaptions = True
        TabOrder = 0
        object ToolButton1: TToolButton
          Left = 0
          Top = 2
          Caption = 'Agendar Procedimentos'
          ImageIndex = 0
          OnClick = ToolButton1Click
        end
        object ToolButton3: TToolButton
          Left = 128
          Top = 2
          Width = 44
          Caption = 'ToolButton3'
          ImageIndex = 2
          Style = tbsSeparator
        end
        object ToolButton2: TToolButton
          Left = 172
          Top = 2
          Caption = 'Configurar Procedimentos'
          ImageIndex = 1
          OnClick = ToolButton2Click
        end
        object ToolButton4: TToolButton
          Left = 300
          Top = 2
          Caption = 'Configurar Ocorrencias'
          ImageIndex = 3
          OnClick = ToolButton4Click
        end
        object ToolButton5: TToolButton
          Left = 428
          Top = 2
          Width = 8
          Caption = 'ToolButton5'
          ImageIndex = 3
          Style = tbsSeparator
        end
        object ToolButtonAtualizar: TToolButton
          Left = 436
          Top = 2
          Caption = 'Atualizar'
          ImageIndex = 2
          OnClick = ToolButtonAtualizarClick
        end
        object ToolButtonPostoTrabalho: TToolButton
          Left = 564
          Top = 2
          Caption = 'Posto de Trabalho'
          ImageIndex = 3
          OnClick = ToolButtonPostoTrabalhoClick
        end
      end
      object Panel2: TPanel
        Left = 0
        Top = 65
        Width = 1009
        Height = 442
        Caption = 'Panel1'
        TabOrder = 3
        object frxPreview3: TfrxPreview
          Left = 1
          Top = 1
          Width = 1007
          Height = 440
          Align = alClient
          ActiveFrameColor = clWhite
          BackColor = clWhite
          FrameColor = clWhite
          OutlineVisible = False
          OutlineWidth = 0
          ThumbnailVisible = False
          FindFmVisible = False
          UseReportHints = True
          OutlineTreeSortType = dtsUnsorted
          HideScrolls = False
        end
      end
      object RadioGroupDiaProcedimento: TRadioGroup
        Left = 0
        Top = 28
        Width = 609
        Height = 34
        Columns = 6
        ItemIndex = 2
        Items.Strings = (
          'Ultimos 7 dias'
          'Ontem'
          'Hoje'
          'Amanh'#227
          'Pr'#243'ximos 7 dias'
          'Todos')
        TabOrder = 1
        OnClick = RadioGroupDiaProcedimentoClick
      end
      object RadioGroupEncerrado: TRadioGroup
        Left = 628
        Top = 29
        Width = 269
        Height = 32
        Columns = 2
        ItemIndex = 0
        Items.Strings = (
          'Ativo/Aberto'
          'Arquivado/Encerrado')
        TabOrder = 2
        OnClick = RadioGroupEncerradoClick
      end
    end
    object TabSheetEscala: TTabSheet
      Caption = 'Escala de Plant'#227'o'
      ImageIndex = 3
      TabVisible = False
      object DBGridEscalaPlantao: TDBGrid
        Left = 0
        Top = 73
        Width = 1146
        Height = 456
        Align = alClient
        DataSource = DsEscalaPlantao
        TabOrder = 1
        TitleFont.Charset = DEFAULT_CHARSET
        TitleFont.Color = clWindowText
        TitleFont.Height = -11
        TitleFont.Name = 'MS Sans Serif'
        TitleFont.Style = []
        Columns = <
          item
            Expanded = False
            FieldName = 'DATA_PLANTAO'
            Title.Caption = 'Data'
            Width = 80
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'EQUIPE'
            Title.Caption = 'Equipe'
            Width = 100
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'NOME_FUNCIONARIO'
            Title.Caption = 'Funcion'#225'rio'
            Width = 150
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'POSTO_TRABALHO'
            Title.Caption = 'Posto'
            Width = 150
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'OBSERVACOES'
            Title.Caption = 'Observa'#231#245'es'
            Width = 200
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'HORA_INICIO'
            Title.Caption = 'Inicio'
            Width = 50
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'HORA_FIM'
            Title.Caption = 'Fim'
            Width = 50
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'SUBSTITUTO'
            Title.Caption = 'Substituto'
            Visible = True
          end>
      end
      object Panel3: TPanel
        Left = 0
        Top = 0
        Width = 1146
        Height = 73
        Align = alTop
        TabOrder = 0
        object Label1: TLabel
          Left = 16
          Top = 4
          Width = 66
          Height = 13
          Caption = 'Dia da Escala'
        end
        object Label3: TLabel
          Left = 542
          Top = 35
          Width = 33
          Height = 13
          Caption = 'Equipe'
        end
        object DateTimePickerEscala: TDateTimePicker
          Left = 17
          Top = 18
          Width = 89
          Height = 21
          Date = 40934.485215416670000000
          Time = 40934.485215416670000000
          TabOrder = 2
        end
        object BitBtn17: TBitBtn
          Left = 320
          Top = 11
          Width = 145
          Height = 25
          Caption = 'Iniciar Nova Escala'
          TabOrder = 0
          OnClick = BitBtn17Click
        end
        object BitBtn19: TBitBtn
          Left = 794
          Top = 43
          Width = 145
          Height = 25
          Caption = 'Apagar Escala'
          TabOrder = 4
          OnClick = BitBtn19Click
        end
        object BtnAtualizarEscalaDia: TBitBtn
          Left = 115
          Top = 13
          Width = 75
          Height = 25
          Caption = '&Atualizar '
          TabOrder = 1
          OnClick = BtnAtualizarEscalaDiaClick
          Glyph.Data = {}
          NumGlyphs = 2
        end
        object DBLookupComboBoxEquipe: TDBLookupComboBox
          Left = 542
          Top = 50
          Width = 243
          Height = 21
          KeyField = 'IDEQUIPE'
          ListField = 'EQUIPE'
          ListSource = DM.DsEquipe
          TabOrder = 6
        end
        object DBNavigator1: TDBNavigator
          Left = 14
          Top = 48
          Width = 234
          Height = 25
          DataSource = DsEscalaPlantao
          VisibleButtons = [nbFirst, nbPrior, nbNext, nbLast, nbInsert, nbDelete, nbEdit, nbPost, nbCancel]
          TabOrder = 5
        end
        object BitBtn18: TBitBtn
          Left = 320
          Top = 43
          Width = 145
          Height = 25
          Caption = 'Imprimir Escala'
          TabOrder = 3
          OnClick = BitBtn18Click
        end
      end
    end
    object TabSheet3: TTabSheet
      Caption = 'Caixa de Mensagem'
      ImageIndex = 4
      TabVisible = False
    end
    object Identificacao: TTabSheet
      Caption = 'Identifica'#231#227'o'
      ImageIndex = 21
      object Label2: TLabel
        Left = 165
        Top = 53
        Width = 11
        Height = 13
        Caption = 'ID'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label4: TLabel
        Left = 165
        Top = 85
        Width = 28
        Height = 13
        Caption = 'Nome'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label5: TLabel
        Left = 165
        Top = 117
        Width = 43
        Height = 13
        Caption = 'Matricula'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object DBText2: TDBText
        Left = 165
        Top = 69
        Width = 500
        Height = 17
        DataField = 'ID_FUNCIONARIO'
        DataSource = DsFuncionario
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object DBText4: TDBText
        Left = 165
        Top = 133
        Width = 500
        Height = 17
        DataField = 'MATRICULA'
        DataSource = DsFuncionario
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object DBText1: TDBText
        Left = 165
        Top = 101
        Width = 500
        Height = 17
        DataField = 'NOME_FUNCIONARIO'
        DataSource = DsFuncionario
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label6: TLabel
        Left = 27
        Top = 37
        Width = 116
        Height = 13
        Caption = '(Click para atualizar foto)'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clNavy
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object DBImageFOTOFUNCIONARIO: TDBImage
        Left = 18
        Top = 51
        Width = 144
        Height = 162
        DataField = 'FOTO'
        DataSource = DsFuncionario
        Stretch = True
        TabOrder = 0
        OnClick = DBImageFOTOFUNCIONARIOClick
      end
      object PageControl1: TPageControl
        Left = 0
        Top = 216
        Width = 1146
        Height = 313
        ActivePage = TabSheet5
        Align = alBottom
        TabOrder = 1
        TabWidth = 200
        object TabSheet5: TTabSheet
          Caption = 'Logs de Acesso'
          object DBGrid1: TDBGrid
            Left = 0
            Top = 0
            Width = 1138
            Height = 285
            Align = alClient
            DataSource = DsUltimosLogs
            ReadOnly = True
            TabOrder = 0
            TitleFont.Charset = DEFAULT_CHARSET
            TitleFont.Color = clWindowText
            TitleFont.Height = -11
            TitleFont.Name = 'MS Sans Serif'
            TitleFont.Style = []
            OnDrawColumnCell = DBGrid1DrawColumnCell
            Columns = <
              item
                Expanded = False
                FieldName = 'DATA_HORA'
                Title.Caption = 'Data - Hora'
                Width = 110
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'SCRIPT_REVERSAO'
                Title.Caption = 'Script '
                Width = 700
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'IP_MAQUINA'
                Title.Caption = 'Ip do Computador'
                Width = 110
                Visible = True
              end>
          end
        end
        object TabSheetInteligencia: TTabSheet
          Caption = 'Intelig'#234'ncia'
          ImageIndex = 1
          TabVisible = False
          object MemoInteligencia: TMemo
            Left = 0
            Top = 0
            Width = 1138
            Height = 285
            Align = alClient
            TabOrder = 0
          end
        end
      end
    end
  end
  object MainMenu1: TMainMenu
    Images = ImageList1
    Left = 444
    Top = 8
    object Cadastro1: TMenuItem
      Caption = 'Cadastro'
      ImageIndex = 22
      object Pavilho1: TMenuItem
        Caption = 'Pavilh'#227'o'
        ImageIndex = 22
        OnClick = Pavilho1Click
      end
      object Galeria1: TMenuItem
        Caption = 'Galeria'
        ImageIndex = 22
        OnClick = Galeria1Click
      end
      object Solario1: TMenuItem
        Caption = 'Solario'
        ImageIndex = 22
        OnClick = Solario1Click
      end
      object Cela1: TMenuItem
        Caption = 'Cela'
        ImageIndex = 22
        OnClick = Cela1Click
      end
      object N3: TMenuItem
        Caption = '-'
      end
      object CadastrodeInternos2: TMenuItem
        Caption = 'Internos'
        ImageIndex = 22
        OnClick = CadastrodeInternos1Click
      end
      object CondiodoInterno1: TMenuItem
        Caption = 'Condi'#231#227'o do Interno'
        ImageIndex = 22
        OnClick = CondiodoInterno1Click
      end
      object N2: TMenuItem
        Caption = '-'
      end
      object Advogado1: TMenuItem
        Caption = 'Advogado'
        ImageIndex = 22
        OnClick = Advogado1Click
      end
      object Faco1: TMenuItem
        Caption = 'Fac'#231#227'o'
        ImageIndex = 22
        OnClick = Faco1Click
      end
      object cIDADE1: TMenuItem
        Caption = 'Cidade'
        ImageIndex = 22
        OnClick = cIDADE1Click
      end
      object Raa1: TMenuItem
        Caption = 'Ra'#231'a'
        ImageIndex = 22
        OnClick = Raa1Click
      end
      object Escolaridade1: TMenuItem
        Caption = 'Escolaridade'
        ImageIndex = 22
        OnClick = Escolaridade1Click
      end
      object Nacionalidade1: TMenuItem
        Caption = 'Nacionalidade'
        ImageIndex = 22
        OnClick = Nacionalidade1Click
      end
      object Procedncia1: TMenuItem
        Caption = 'Proced'#234'ncia'
        ImageIndex = 22
        OnClick = Procedncia1Click
      end
      object Destino1: TMenuItem
        Caption = 'Destino'
        ImageIndex = 22
        OnClick = Destino1Click
      end
      object Fornecedor1: TMenuItem
        Caption = 'Fornecedor'
        ImageIndex = 22
        OnClick = Fornecedor1Click
      end
      object N4: TMenuItem
        Caption = '-'
      end
      object Profisso1: TMenuItem
        Caption = 'Profiss'#227'o'
        ImageIndex = 22
        OnClick = Profisso1Click
      end
      object N14: TMenuItem
        Caption = '-'
      end
      object CTC1: TMenuItem
        Caption = 'CTC'
        ImageIndex = 3
        OnClick = CTC1Click
      end
    end
    object Movimentao1: TMenuItem
      Caption = 'Movimenta'#231#227'o'
      object ransfernciadeInterno1: TMenuItem
        Caption = 'Transfer'#234'ncia de Interno (Movimento Externo)'
        ImageIndex = 24
        OnClick = ransfernciadeInterno1Click
      end
      object N28: TMenuItem
        Caption = '-'
      end
      object RecebimentodeTransferncia1: TMenuItem
        Caption = 'Conferir Transfer'#234'ncia Recebida'
        ImageIndex = 3
        OnClick = RecebimentodeTransferncia1Click
      end
      object N26: TMenuItem
        Caption = '-'
      end
      object ransfernciadeInternoMovimentoInterno1: TMenuItem
        Caption = 'Mudan'#231'a de Cela (Movimento Interno)'
        ImageIndex = 19
        OnClick = ransfernciadeInternoMovimentoInterno1Click
      end
      object N25: TMenuItem
        Caption = '-'
      end
      object CadastroPortaria1: TMenuItem
        Caption = 'Cadastro da Portaria do Sa'#237'd'#227'o'
        ImageIndex = 16
        OnClick = CadastroPortaria1Click
      end
      object Saido1: TMenuItem
        Caption = 'Inclus'#227'o dos Internos no Said'#227'o'
        ImageIndex = 11
        OnClick = Saido1Click
      end
      object N30: TMenuItem
        Caption = '-'
      end
      object CirculaodeInterno1: TMenuItem
        Caption = 'Circula'#231#227'o de Interno'
        ImageIndex = 19
        OnClick = CirculaodeInterno1Click
      end
      object N35: TMenuItem
        Caption = '-'
      end
      object MovimentoSemiAberto1: TMenuItem
        Caption = 'Movimento Semi-Aberto / Aberto'
        ImageIndex = 24
        OnClick = MovimentoSemiAberto1Click
      end
      object N37: TMenuItem
        Caption = '-'
      end
      object LocalizaoPorPronturio1: TMenuItem
        Caption = 'Consulta Movimenta'#231#227'o Geral do Interno'
        ImageIndex = 13
        OnClick = LocalizaoPorPronturio1Click
      end
      object Biometria1: TMenuItem
        Caption = '-'
      end
      object Biometria2: TMenuItem
        Visible = False
      end
    end
    object Setores1: TMenuItem
      Caption = 'Setores'
      ImageIndex = 22
      object disciplina1: TMenuItem
        Caption = 'Disciplina'
        ImageIndex = 6
        object Disciplina2: TMenuItem
          Caption = 'Disciplina'
          ImageIndex = 6
          OnClick = Disciplina2Click
        end
        object FaltaDisciplinar1: TMenuItem
          Caption = 'Falta Disciplinar'
          ImageIndex = 22
          OnClick = FaltaDisciplinar1Click
        end
      end
      object SetordeEducao1: TMenuItem
        Caption = 'Educa'#231#227'o'
        ImageIndex = 7
        object educ: TMenuItem
          Caption = 'Educa'#231#227'o'
          ImageIndex = 7
          OnClick = educClick
        end
        object SrieFaseAtual1: TMenuItem
          Caption = 'S'#233'rie/Fase Atual'
          ImageIndex = 22
          OnClick = SrieFaseAtual1Click
        end
        object Livro1: TMenuItem
          Caption = 'Livro/Revista'
          ImageIndex = 22
          OnClick = Livro1Click
        end
        object CargaHorria1: TMenuItem
          Caption = 'Carga Hor'#225'ria'
          OnClick = CargaHorria1Click
        end
      end
      object Jurdica1: TMenuItem
        Caption = 'Jur'#237'dico'
        ImageIndex = 11
        object Jurdico1: TMenuItem
          Caption = 'Jur'#237'dico'
          ImageIndex = 11
          OnClick = Jurdico1Click
        end
        object N9: TMenuItem
          Caption = '-'
        end
        object Processos1: TMenuItem
          Caption = 'Processos e/ou Condena'#231#245'es do Interno'
          ImageIndex = 22
          OnClick = Processos1Click
        end
        object Detrao1: TMenuItem
          Caption = 'Detra'#231#227'o / Desconto na pena definitiva aplicada'
          ImageIndex = 22
          OnClick = Detrao1Click
        end
        object InterrupesdaPena1: TMenuItem
          Caption = 'Interrup'#231#245'es da Execu'#231#227'o Penal'
          ImageIndex = 22
          OnClick = InterrupesdaPena1Click
        end
        object RemiesdePena1: TMenuItem
          Caption = 'Remi'#231#245'es de Pena'
          ImageIndex = 22
          OnClick = RemiesdePena1Click
        end
        object N22: TMenuItem
          Caption = '-'
        end
        object Artigo1: TMenuItem
          Caption = 'Artigos do C'#243'digo Penal Brasileiro'
          ImageIndex = 22
          OnClick = Artigo1Click
        end
        object N24: TMenuItem
          Caption = '-'
        end
        object VaradeExecuo1: TMenuItem
          Caption = 'Vara de Execu'#231#227'o'
          OnClick = VaradeExecuo1Click
        end
      end
      object PSICOSSOCIAL1: TMenuItem
        Caption = 'Psicossocial'
        ImageIndex = 14
        OnClick = PSICOSSOCIAL1Click
      end
      object Reabilitao1: TMenuItem
        Caption = 'Reabilita'#231#227'o'
        ImageIndex = 23
        object Pedagogia: TMenuItem
          Caption = 'Pedagogia'
          ImageIndex = 12
          OnClick = PedagogiaClick
        end
        object ServicoSocial: TMenuItem
          Caption = 'Servi'#231'o Social'
          ImageIndex = 18
          OnClick = ServicoSocialClick
        end
        object erapiaOcupacional: TMenuItem
          Caption = 'Terapia Ocupacional'
          ImageIndex = 19
          OnClick = erapiaOcupacionalClick
        end
      end
      object Sade1: TMenuItem
        Caption = 'Sa'#250'de'
        ImageIndex = 17
        object clinicamedica: TMenuItem
          Caption = 'Cl'#237'nica M'#233'dica'
          ImageIndex = 2
          OnClick = clinicamedicaClick
        end
        object Enfermagem: TMenuItem
          Caption = 'Enfermagem'
          ImageIndex = 8
          OnClick = EnfermagemClick
        end
        object farmacia: TMenuItem
          Caption = 'Farm'#225'cia'
          ImageIndex = 9
          OnClick = farmaciaClick
        end
        object Odontologia: TMenuItem
          Caption = 'Odontologia'
          ImageIndex = 5
          OnClick = OdontologiaClick
        end
        object Psicologia: TMenuItem
          Caption = 'Psicologia'
          ImageIndex = 13
          OnClick = PsicologiaClick
        end
        object Psiquiatria: TMenuItem
          Caption = 'Psiquiatria'
          ImageIndex = 15
          OnClick = PsiquiatriaClick
        end
        object N6: TMenuItem
          Caption = '-'
        end
        object Remdio1: TMenuItem
          Caption = 'Rem'#233'dio'
          ImageIndex = 22
          OnClick = Remdio1Click
        end
        object Sade2: TMenuItem
          Caption = 'Sa'#250'de'
          ImageIndex = 17
          OnClick = Sade2Click
        end
      end
      object SetorTrabalho1: TMenuItem
        Caption = 'Trabalho'
        ImageIndex = 20
        object trabalho2: TMenuItem
          Caption = 'Trabalho'
          ImageIndex = 20
          OnClick = trabalho2Click
        end
        object SetorTrabalho2: TMenuItem
          Caption = 'Setor Trabalho'
          ImageIndex = 22
          OnClick = SetorTrabalho2Click
        end
        object FunoInterno1: TMenuItem
          Caption = 'Fun'#231#227'o Interno'
          ImageIndex = 22
          OnClick = FunoInterno1Click
        end
        object N7: TMenuItem
          Caption = '-'
        end
        object ClculodeTrabalho1: TMenuItem
          Caption = 'C'#225'lculo de Trabalho'
          ImageIndex = 20
          OnClick = ClculodeTrabalho1Click
        end
        object RemioTrabalho1: TMenuItem
          Caption = 'Remi'#231#227'o Trabalho'
          OnClick = RemioTrabalho1Click
        end
      end
      object Planto1: TMenuItem
        Caption = 'Plant'#227'o'
        ImageIndex = 26
        object Roupas1: TMenuItem
          Caption = 'Roupas'
          OnClick = Roupas1Click
        end
        object Ocorrncias1: TMenuItem
          Caption = 'Ocorr'#234'ncias'
          OnClick = Ocorrncias1Click
        end
      end
      object ConselhoDi1: TMenuItem
        Caption = 'Conselho Disciplinar'
        ImageIndex = 3
        OnClick = ConselhoDi1Click
      end
      object mnuCorrespondencia: TMenuItem
        Caption = 'Correspond'#234'ncia'
        OnClick = mnuCorrespondenciaClick
      end
    end
    object Visitantes1: TMenuItem
      Caption = 'Visitantes'
      ImageIndex = 21
      object EntradadeVisitantes1: TMenuItem
        Caption = 'Entrada de Visitantes'
        ImageIndex = 21
        OnClick = EntradadeVisitantes1Click
      end
      object N8: TMenuItem
        Caption = '-'
      end
      object Consulta1: TMenuItem
        Caption = 'Consulta'
        ImageIndex = 21
        OnClick = Consulta1Click
      end
      object GrauParentesco1: TMenuItem
        Caption = 'Grau Parentesco'
        ImageIndex = 22
        OnClick = GrauParentesco1Click
      end
      object Visitante1: TMenuItem
        Caption = 'Visitante'
        ImageIndex = 22
        OnClick = Visitante1Click
      end
      object VisitantesTrfico1: TMenuItem
        Caption = 'Visitantes Tr'#225'fico'
        ImageIndex = 0
        OnClick = VisitantesTrfico1Click
      end
    end
    object Relatrios1: TMenuItem
      Caption = 'Relat'#243'rios'
      ImageIndex = 16
      object MenudeRelatrios1: TMenuItem
        Caption = 'Menu de Relat'#243'rios'
        ImageIndex = 16
        OnClick = MenudeRelatrios1Click
      end
      object N16: TMenuItem
        Caption = '-'
      end
      object ConsultaInterno1: TMenuItem
        Caption = 'Consulta'
        ImageIndex = 4
        object Interno1: TMenuItem
          Caption = 'Interno'
          ImageIndex = 4
          OnClick = Interno1Click
        end
      end
    end
    object Mdulos1: TMenuItem
      Caption = 'M'#243'dulos'
      object Patrimnio1: TMenuItem
        Caption = 'Patrim'#244'nio'
        ImageIndex = 13
        object ipodePatrimnio1: TMenuItem
          Caption = 'Tipo de Patrim'#244'nio'
          ImageIndex = 13
          OnClick = ipodePatrimnio1Click
        end
        object N13: TMenuItem
          Caption = '-'
        end
        object CadastrodePatrimonio1: TMenuItem
          Caption = 'Cadastro de Patrim'#244'nio'
          ImageIndex = 13
          OnClick = CadastrodePatrimonio1Click
        end
        object N15: TMenuItem
          Caption = '-'
        end
      end
      object N19: TMenuItem
        Caption = '-'
        Visible = False
      end
      object MduloGestodeArmas1: TMenuItem
        Caption = 'M'#243'dulo Gest'#227'o de Armas'
        ImageIndex = 6
        OnClick = MduloGestodeArmas1Click
      end
      object N17: TMenuItem
        Caption = '-'
        Visible = False
      end
      object ControledePortaria1: TMenuItem
        Caption = 'Controle de Portaria'
        ImageIndex = 21
        OnClick = ControledePortaria1Click
      end
      object N33: TMenuItem
        Caption = '-'
        Visible = False
      end
      object Inteligncia1: TMenuItem
        Caption = 'Intelig'#234'ncia'
        ImageIndex = 26
        Visible = False
        OnClick = Inteligncia1Click
      end
      object N18: TMenuItem
        Caption = '-'
        Visible = False
      end
      object Monitoramento1: TMenuItem
        Caption = 'Monitoramento'
        ImageIndex = 23
        OnClick = Monitoramento1Click
      end
      object N21: TMenuItem
        Caption = '-'
        Visible = False
      end
      object PlanilhaDinmica1: TMenuItem
        Caption = 'Planilha Din'#226'mica - Relat'#243'rio R'#225'pido e F'#225'cil'
        ImageIndex = 16
        Visible = False
        OnClick = PlanilhaDinmica1Click
      end
      object N27: TMenuItem
        Caption = '-'
        Visible = False
      end
      object SiapenMessenger1: TMenuItem
        Caption = 'Siapen - Messenger'
        ImageIndex = 23
        Visible = False
        OnClick = SiapenMessenger1Click
      end
      object N32: TMenuItem
        Caption = '-'
        Visible = False
      end
      object DepartamentoPEssoal1: TMenuItem
        Caption = 'Pessoal'
        ImageIndex = 14
        Visible = False
        object BancodeHoras1: TMenuItem
          Caption = 'Banco de Horas'
          ImageIndex = 1
          OnClick = BancodeHoras1Click
        end
      end
      object N34: TMenuItem
        Caption = '-'
        Visible = False
      end
      object MduloGestodePessoas1: TMenuItem
        Caption = 'M'#243'dulo Gest'#227'o de Pessoas'
        ImageIndex = 13
        Visible = False
        OnClick = MduloGestodePessoas1Click
      end
      object N36: TMenuItem
        Caption = '-'
        Visible = False
      end
      object MonitoramentoEletrnico1: TMenuItem
        Caption = 'Monitoramento Eletr'#244'nico'
        ImageIndex = 27
        OnClick = MonitoramentoEletrnico1Click
      end
      object N38: TMenuItem
        Caption = '-'
        Visible = False
      end
      object WebBrowser1: TMenuItem
        Caption = 'Web Browser'
        ImageIndex = 25
        Visible = False
        OnClick = WebBrowser1Click
      end
    end
    object Configurao1: TMenuItem
      Caption = 'Configura'#231#227'o'
      ImageIndex = 24
      object Funcionrio2: TMenuItem
        Caption = 'Usu'#225'rio/Funcion'#225'rio'
        ImageIndex = 22
        OnClick = Funcionrio2Click
      end
      object FunoFuncionrio1: TMenuItem
        Caption = 'Fun'#231#227'o Funcion'#225'rio'
        ImageIndex = 22
        OnClick = FunoFuncionrio1Click
      end
      object UnidadePenal2: TMenuItem
        Caption = 'Unidade Penal'
        ImageIndex = 22
        OnClick = UnidadePenal2Click
      end
      object HorarioFuncionrio1: TMenuItem
        Caption = 'Hor'#225'rio do Funcion'#225'rio'
        ImageIndex = 22
        OnClick = HorarioFuncionrio1Click
      end
      object N1: TMenuItem
        Caption = '-'
      end
      object PerfildeUsurio1: TMenuItem
        Caption = 'Perfil de Usu'#225'rio'
        ImageIndex = 22
        OnClick = PerfildeUsurio1Click
      end
      object PadroSist1: TMenuItem
        Caption = 'Padr'#227'o do Sistema'
        ImageIndex = 22
        OnClick = PadroSist1Click
      end
      object N10: TMenuItem
        Caption = '-'
      end
      object Equipe1: TMenuItem
        Caption = 'Equipe'
        ImageIndex = 6
        OnClick = Equipe1Click
      end
      object PostoLocaldeTrabalho1: TMenuItem
        Caption = 'Posto / Local de Trabalho'
        ImageIndex = 6
        OnClick = PostoLocaldeTrabalho1Click
      end
      object AgenteporEquipe1: TMenuItem
        Caption = 'Agente por  Equipe'
        ImageIndex = 6
        OnClick = AgenteporEquipe1Click
      end
      object N31: TMenuItem
        Caption = '-'
      end
      object RegraparaVisitano1: TMenuItem
        Caption = 'Regra de Visita'#231#227'o'
        ImageIndex = 24
        OnClick = RegraparaVisitano1Click
      end
    end
    object Manuteno1: TMenuItem
      Caption = 'Manuten'#231#227'o'
      ImageIndex = 24
      object DadosUsuarioLogado: TMenuItem
        Caption = 'Atualizar Meus Dados'
        ImageIndex = 26
        OnClick = DadosUsuarioLogadoClick
      end
      object rocarSenha1: TMenuItem
        Caption = 'Trocar Senha'
        ImageIndex = 24
        OnClick = rocarSenha1Click
      end
      object N12: TMenuItem
        Caption = '-'
      end
      object MensagemdoBancodeDados1: TMenuItem
        Caption = 'Mensagem do Banco de Dados'
        ImageIndex = 4
        OnClick = MensagemdoBancodeDados1Click
      end
      object WebCam1: TMenuItem
        Caption = 'WebCam'
        ImageIndex = 25
        Visible = False
        OnClick = WebCam1Click
      end
      object N20: TMenuItem
        Caption = '-'
      end
      object Copiarumarquivo1: TMenuItem
        Caption = 'Copiar um arquivo...'
        ImageIndex = 19
        OnClick = Copiarumarquivo1Click
      end
      object N23: TMenuItem
        Caption = '-'
      end
      object ConsultaPROCED1: TMenuItem
        Caption = 'Consulta PROCED'
        ImageIndex = 3
        OnClick = ConsultaPROCED1Click
      end
    end
    object Agendamento1: TMenuItem
      Caption = 'Agendamento'
      ImageIndex = 0
      object AgendadeAtendimento1: TMenuItem
        Caption = 'Agenda de Atendimento'
        ImageIndex = 0
        OnClick = AgendadeAtendimento1Click
      end
      object N5: TMenuItem
        Caption = '-'
      end
      object Assunto1: TMenuItem
        Caption = 'Assunto'
        ImageIndex = 22
        OnClick = Assunto1Click
      end
      object Situao1: TMenuItem
        Caption = 'Situa'#231#227'o'
        ImageIndex = 22
        OnClick = Situao1Click
      end
      object ipodeContatos1: TMenuItem
        Caption = 'Tipo de Contatos'
        ImageIndex = 22
        OnClick = ipodeContatos1Click
      end
    end
    object Sobre1: TMenuItem
      Caption = 'Sobre'
      object Informaes1: TMenuItem
        Caption = 'Informa'#231#245'es'
        ImageIndex = 0
        OnClick = Sobre1Click
      end
      object N11: TMenuItem
        Caption = '-'
      end
      object MudaSkin1: TMenuItem
        Caption = 'Muda Skin'
        ImageIndex = 0
        OnClick = MudaSkin1Click
      end
      object N29: TMenuItem
        Caption = '-'
      end
      object Manual1: TMenuItem
        Caption = 'Manual'
        ImageIndex = 0
        OnClick = Manual1Click
      end
      object AtribuicaoSetores1: TMenuItem
        Caption = 'Atribui'#231#227'o por Setores'
        ImageIndex = 0
        OnClick = AtribuicaoSetores1Click
      end
    end
    object Sair1: TMenuItem
      Caption = 'Sair'
      OnClick = Sair1Click
    end
  end
  object TimerAtivaImagem: TTimer
    Interval = 1
    OnTimer = TimerAtivaImagemTimer
    Left = 176
    Top = 56
  end
  object TimerDataHora: TTimer
    Enabled = False
    OnTimer = TimerDataHoraTimer
    Left = 504
    Top = 8
  end
  object frxReport1: TfrxReport
    Version = '6.9.12'
    DotMatrixReport = False
    IniFile = '\Software\Fast Reports'
    PreviewOptions.Buttons = [pbPrint, pbLoad, pbSave, pbExport, pbZoom, pbFind, pbOutline, pbPageSetup, pbTools, pbEdit, pbNavigator, pbExportQuick]
    PreviewOptions.Zoom = 1.000000000000000000
    PrintOptions.Printer = 'Default'
    PrintOptions.PrintOnSheet = 0
    ReportOptions.CreateDate = 39864.392612476900000000
    ReportOptions.LastChange = 41173.531611076400000000
    ScriptLanguage = 'PascalScript'
    ScriptText.Strings = (
      'procedure DialogPage1OnShow(Sender: TfrxComponent);'
      'begin'
      '      SqlListaInterno.Open;'
      '  while not SqlListaInterno.EOF do'
      '  begin'
      
        '    ComboBox1.Items.Add(SqlListaInterno.FieldByName('#39'NOME_INTERN' +
        'O'#39').AsString+'#39' ('#39'+SqlListaInterno.FieldByName('#39'ID_INTERNO'#39').AsSt' +
        'ring+'#39')'#39');'
      '    SqlListaInterno.Next;'
      '  end;                          '
      'end;'
      ''
      'procedure Memo2OnBeforePrint(Sender: TfrxComponent);'
      'begin'
      '      '
      'end;'
      ''
      'procedure Button1OnClick(Sender: TfrxComponent);'
      'begin'
      ''
      'end;'
      ''
      'procedure frxReport1OnStartReport(Sender: TfrxComponent);'
      'begin'
      '      IF <GLOBAL_CONFERE> <> '#39'R'#39' THEN'
      '  begin'
      '   SHOWMESSAGE('#39'N'#227'o h'#225' Permiss'#227'o Para Visualizar Relat'#243'rio!'#39');'
      '    page1.free;'
      '  end;  '
      'end;'
      ''
      'begin                      '
      'end.')
    OnStartReport = 'frxReport1OnStartReport'
    Left = 801
    Top = 20
    Datasets = <
      item
        DataSet = frxDBDataset1
        DataSetName = 'frxDBDataset1'
      end
      item
        DataSet = frxReport1.Sqlup
        DataSetName = 'Sqlup'
      end
      item
        DataSet = frxReport1.sqlfichadisciplinar
        DataSetName = 'sqlfichadisciplinar'
      end
      item
        DataSet = frxReport1.sqllistainterno
        DataSetName = 'sqllistainterno'
      end>
    Variables = <
      item
        Name = ' SIAP'
        Value = Null
      end
      item
        Name = 'DATA_AGENDA'
        Value = Null
      end
      item
        Name = 'GLOBAL_CONFERE'
        Value = #39'R'#39
      end
      item
        Name = 'ID_UP'
        Value = '73'
      end
      item
        Name = 'GLOBAL_ORGAO'
        Value = #39'GOVERNO DO ESTADO DE MATO GROSSO DO SUL'#39
      end
      item
        Name = 'GLOBAL_DEPARTAMENTO'
        Value = 
          #39'SECRETARIA DE JUSTI'#199'A E SEGURAN'#199'A P'#218'BLICA DE MATO GROSSO DO SUL' +
          #39
      end
      item
        Name = 'GLOBAL_DIRETORIA'
        Value = #39'AGENCIA ESTADUAL DE ADMINISTRA'#199#195'O DO SISTEMA PENITENCI'#193'RIO'#39
      end>
    Style = <>
    object Data: TfrxDataPage
      Height = 1000.000000000000000000
      Width = 1000.000000000000000000
      object Sqlup: TfrxIBXQuery
        UserName = 'Sqlup'
        CloseDataSource = True
        BCDToCurrency = False
        IgnoreDupParams = False
        Params = <
          item
            Name = 'ID_UP'
            DataType = ftInteger
            Expression = '<ID_UP>'
          end>
        SQL.Strings = (
          
            ' SELECT u.nome_up, u.endereco, u.bairro, u.numero, u.complemento' +
            ',u.sigla, u.cep,'
          'c.cidade||'#39' - '#39'||c.uf as cidade                    '
          'from unidade_penal u'
          
            'inner join cidade c on(c.id_cidade=u.id_cidade)                 ' +
            '                                      '
          'WHERE ID_UP = :ID_UP  ')
        Database = frxReport1.Database
        pLeft = 232
        pTop = 128
        Parameters = <
          item
            Name = 'ID_UP'
            DataType = ftInteger
            Expression = '<ID_UP>'
          end>
      end
      object sqlfichadisciplinar: TfrxIBXQuery
        UserName = 'sqlfichadisciplinar'
        CloseDataSource = True
        BCDToCurrency = False
        IgnoreDupParams = False
        Params = <
          item
            Name = 'nome_interno'
            DataType = ftString
            Expression = 'ComboBox1.text'
          end>
        SQL.Strings = (
          'select'
          'i.nome_interno,  i.foto, t.setor_trabalho, i.data_setor'
          '    from interno i'
          
            'inner join setor_trabalho t ON (i.idsetor_trabalho = t.id_setor_' +
            'trabalho)'
          
            '    where upper(i.NOME_INTERNO)||'#39' ('#39'||i.id_interno||'#39')'#39' = upper' +
            '(:nome_interno)    ')
        Database = frxReport1.Database
        pLeft = 232
        pTop = 196
        Parameters = <
          item
            Name = 'nome_interno'
            DataType = ftString
            Expression = 'ComboBox1.text'
          end>
      end
      object sqllistainterno: TfrxIBXQuery
        UserName = 'sqllistainterno'
        CloseDataSource = True
        BCDToCurrency = False
        IgnoreDupParams = False
        Params = <
          item
            Name = 'ID_UP'
            DataType = ftInteger
            Expression = '<ID_UP>'
          end>
        SQL.Strings = (
          'select'
          'I.nome_interno,'
          'i.id_interno                          '
          'from interno i    '
          'where I.ID_UP = :ID_UP'
          'and coalesce(i.nome_interno,'#39#39')<>'#39#39
          'order by i.nome_interno  ')
        Database = frxReport1.Database
        pLeft = 232
        pTop = 276
        Parameters = <
          item
            Name = 'ID_UP'
            DataType = ftInteger
            Expression = '<ID_UP>'
          end>
      end
      object Database: TfrxIBXDatabase
        DatabaseName = 'siap:siap'
        LoginPrompt = False
        Params.Strings = (
          'user_name=SYSDBA'
          'password=masterkey')
        SQLDialect = 3
        pLeft = 236
        pTop = 36
      end
    end
    object Page1: TfrxReportPage
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -11
      Font.Name = 'Courier'
      Font.Style = []
      PaperWidth = 210.000000000000000000
      PaperHeight = 297.000000000000000000
      PaperSize = 9
      LeftMargin = 20.000000000000000000
      RightMargin = 10.000000000000000000
      TopMargin = 5.000000000000000000
      BottomMargin = 10.000000000000000000
      Columns = 1
      ColumnWidth = 293.000000000000000000
      ColumnPositions.Strings = (
        '0')
      Frame.Typ = []
      MirrorMode = []
      object Memo5: TfrxMemoView
        AllowVectorExport = True
        Width = 377.953000000000000000
        Height = 249.448980000000000000
        DisplayFormat.DecimalSeparator = ','
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -16
        Font.Name = 'Lucida Console'
        Font.Style = [fsBold]
        Frame.Typ = [ftLeft, ftRight, ftTop, ftBottom]
        ParentFont = False
      end
      object PageHeader1: TfrxPageHeader
        FillType = ftBrush
        FillGap.Top = 0
        FillGap.Left = 0
        FillGap.Bottom = 0
        FillGap.Right = 0
        Frame.Typ = []
        Height = 264.567100000000000000
        Top = 16.000000000000000000
        Width = 680.315400000000000000
        object SqlupSIGLA: TfrxMemoView
          AllowVectorExport = True
          Left = 191.000000000000000000
          Top = 88.102350000000000000
          Width = 183.630180000000000000
          Height = 40.897650000000000000
          DataField = 'SIGLA'
          DataSet = frxReport1.Sqlup
          DataSetName = 'Sqlup'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -24
          Font.Name = 'Arial'
          Font.Style = [fsBold]
          Frame.Typ = []
          HAlign = haCenter
          Memo.UTF8 = (
            '[Sqlup."SIGLA"]')
          ParentFont = False
          VAlign = vaCenter
        end
        object Memo1: TfrxMemoView
          AllowVectorExport = True
          Top = 166.299320000000000000
          Width = 79.370130000000000000
          Height = 22.677180000000000000
          DisplayFormat.DecimalSeparator = ','
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -16
          Font.Name = 'Lucida Console'
          Font.Style = [fsBold]
          Frame.Typ = []
          Memo.UTF8 = (
            'NOME: ')
          ParentFont = False
        end
        object Picture2: TfrxPictureView
          AllowVectorExport = True
          Width = 185.196847950000000000
          Height = 151.181053540000000000
          DataField = 'FOTO'
          DataSet = frxReport1.sqlfichadisciplinar
          DataSetName = 'sqlfichadisciplinar'
          Frame.Typ = []
          HightQuality = False
          Transparent = False
          TransparentColor = clWhite
        end
        object Memo3: TfrxMemoView
          AllowVectorExport = True
          Top = 139.842610000000000000
          Width = 377.953000000000000000
          Height = 18.897650000000000000
          DisplayFormat.DecimalSeparator = ','
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -16
          Font.Name = 'Arial'
          Font.Style = [fsBold]
          Frame.Typ = [ftTop, ftBottom]
          HAlign = haCenter
          Memo.UTF8 = (
            'SETOR DE TRABALHO')
          ParentFont = False
        end
        object Memo13: TfrxMemoView
          AllowVectorExport = True
          Left = 64.252010000000000000
          Top = 162.519790000000000000
          Width = 309.921460000000000000
          Height = 37.795300000000000000
          DisplayFormat.DecimalSeparator = ','
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -16
          Font.Name = 'Lucida Console'
          Font.Style = [fsBold]
          Frame.Typ = []
          Memo.UTF8 = (
            '[sqlfichadisciplinar."NOME_INTERNO"]')
          ParentFont = False
        end
        object sqlfichadisciplinarSETOR_TRABALHO: TfrxMemoView
          AllowVectorExport = True
          Left = 64.252010000000000000
          Top = 192.756030000000000000
          Width = 309.921460000000000000
          Height = 18.897650000000000000
          DataSet = frxReport1.sqlfichadisciplinar
          DataSetName = 'sqlfichadisciplinar'
          DisplayFormat.DecimalSeparator = ','
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -16
          Font.Name = 'Lucida Console'
          Font.Style = [fsBold]
          Frame.Typ = []
          Memo.UTF8 = (
            '[sqlfichadisciplinar."SETOR_TRABALHO"]')
          ParentFont = False
        end
        object sqlfichadisciplinarDATA_SETOR: TfrxMemoView
          AllowVectorExport = True
          Left = 64.252010000000000000
          Top = 211.653680000000000000
          Width = 313.700990000000000000
          Height = 18.897650000000000000
          DataSet = frxReport1.sqlfichadisciplinar
          DataSetName = 'sqlfichadisciplinar'
          DisplayFormat.DecimalSeparator = ','
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -16
          Font.Name = 'Lucida Console'
          Font.Style = [fsBold]
          Frame.Typ = []
          Memo.UTF8 = (
            '[sqlfichadisciplinar."DATA_SETOR"]')
          ParentFont = False
        end
        object Memo2: TfrxMemoView
          AllowVectorExport = True
          Top = 192.756030000000000000
          Width = 94.488250000000000000
          Height = 18.897650000000000000
          DisplayFormat.DecimalSeparator = ','
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -16
          Font.Name = 'Lucida Console'
          Font.Style = [fsBold]
          Frame.Typ = []
          Memo.UTF8 = (
            'SETOR:')
          ParentFont = False
        end
        object Memo4: TfrxMemoView
          AllowVectorExport = True
          Top = 211.653680000000000000
          Width = 94.488250000000000000
          Height = 18.897650000000000000
          DisplayFormat.DecimalSeparator = ','
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -16
          Font.Name = 'Lucida Console'
          Font.Style = [fsBold]
          Frame.Typ = []
          Memo.UTF8 = (
            'DATA:')
          ParentFont = False
        end
        object Memo19: TfrxMemoView
          AllowVectorExport = True
          Left = -343.937230000000000000
          Top = 226.771800000000000000
          Width = 680.315400000000000000
          Height = 18.897650000000000000
          DisplayFormat.DecimalSeparator = ','
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'Arial'
          Font.Style = []
          Frame.Typ = []
          HAlign = haRight
          Memo.UTF8 = (
            
              'Projeto SIAP, Impresso em [Date] - [time], Pag. [Page#]/[TotalPa' +
              'ges#]')
          ParentFont = False
        end
        object Memo7: TfrxMemoView
          AllowVectorExport = True
          Left = 226.771800000000000000
          Top = 18.897650000000000000
          Width = 3.779530000000000000
          Height = 15.118120000000000000
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -27
          Font.Name = 'Arial'
          Font.Style = []
          Frame.Typ = []
          ParentFont = False
        end
      end
      object PageFooter1: TfrxPageFooter
        FillType = ftBrush
        FillGap.Top = 0
        FillGap.Left = 0
        FillGap.Bottom = 0
        FillGap.Right = 0
        Frame.Typ = []
        Height = 26.456710000000000000
        Top = 300.000000000000000000
        Width = 680.315400000000000000
      end
      object Picture1: TfrxPictureView
        AllowVectorExport = True
        Left = 243.110390000000000000
        Top = 6.236240000000000000
        Width = 119.283550000000000000
        Height = 87.811070000000000000
        Frame.Typ = []
        Picture.Data = {}
        HightQuality = False
        Transparent = False
        TransparentColor = clWhite
      end
    end
    object DialogPage1: TfrxDialogPage
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = []
      DoubleBuffered = False
      Height = 196.000000000000000000
      ClientHeight = 169.000000000000000000
      Left = 372.000000000000000000
      Top = 130.000000000000000000
      Width = 503.000000000000000000
      Scaled = True
      ClientWidth = 495.000000000000000000
      OnShow = 'DialogPage1OnShow'
      object Label1: TfrxLabelControl
        Left = 28.000000000000000000
        Top = 32.000000000000000000
        Width = 72.000000000000000000
        Height = 23.000000000000000000
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -19
        Font.Name = 'Tahoma'
        Font.Style = [fsBold]
        ParentFont = False
        ShowHint = True
        Caption = 'Interno'
        Color = 15854311
      end
      object Button1: TfrxButtonControl
        Left = 144.000000000000000000
        Top = 112.000000000000000000
        Width = 75.000000000000000000
        Height = 25.000000000000000000
        ShowHint = True
        Caption = 'OK'
        ModalResult = 1
        OnClick = 'Button1OnClick'
      end
      object Button2: TfrxButtonControl
        Left = 260.000000000000000000
        Top = 112.000000000000000000
        Width = 75.000000000000000000
        Height = 25.000000000000000000
        ShowHint = True
        Caption = 'Cancelar'
        ModalResult = 5
      end
      object ComboBox1: TfrxComboBoxControl
        Left = 28.000000000000000000
        Top = 64.000000000000000000
        Width = 425.000000000000000000
        Height = 21.000000000000000000
        ShowHint = True
        Color = clWindow
        ItemIndex = -1
      end
    end
  end
  object frxChartObject1: TfrxChartObject
    Left = 707
    Top = 98
  end
  object PopupMenu1: TPopupMenu
    Left = 729
    Top = 18
    object Desing1: TMenuItem
      Caption = 'Designer'
      OnClick = Desing1Click
    end
  end
  object frxReport2: TfrxReport
    Version = '6.9.12'
    DotMatrixReport = False
    IniFile = '\Software\Fast Reports'
    PreviewOptions.Buttons = [pbPrint, pbLoad, pbSave, pbExport, pbZoom, pbFind, pbOutline, pbPageSetup, pbTools, pbEdit, pbNavigator, pbExportQuick]
    PreviewOptions.Zoom = 1.000000000000000000
    PrintOptions.Printer = 'Default'
    PrintOptions.PrintOnSheet = 0
    ReportOptions.CreateDate = 39864.392612476900000000
    ReportOptions.LastChange = 44425.573495625000000000
    ScriptLanguage = 'PascalScript'
    ScriptText.Strings = (
      'procedure Page1OnBeforePrint(Sender: TfrxComponent);'
      'begin'
      '  '
      
        '    Database.Params.LoadFromFile('#39'..\config\dbxconnections.ini'#39')' +
        ';  '
      '  '
      'end;'
      ''
      'begin'
      ''
      'end.')
    Left = 801
    Top = 68
    Datasets = <
      item
        DataSet = frxReport2.SqlGraficoAgenda
        DataSetName = 'SqlGraficoAgenda'
      end>
    Variables = <
      item
        Name = ' SIAP'
        Value = Null
      end
      item
        Name = 'ID_FUNCIONARIO'
        Value = '401'
      end
      item
        Name = 'ID_UP'
        Value = '206'
      end
      item
        Name = 'GLOBAL_ORGAO'
        Value = #39'GOVERNO DO DISTRITO FEDERAL'#39
      end
      item
        Name = 'GLOBAL_DEPARTAMENTO'
        Value = #39'SECRETARIA DE ESTADO DE SEGURAN'#199'A P'#218'BLICA'#39
      end
      item
        Name = 'GLOBAL_DIRETORIA'
        Value = #39'SUBSECRETARIA DO SISTEMA PENITENCI'#193'RIO'#39
      end>
    Style = <>
    object Data: TfrxDataPage
      Height = 1000.000000000000000000
      Width = 1000.000000000000000000
      object Database: TfrxDBXDatabase
        ConnectionName = 'IBLocal'
        DriverName = 'DevartInterBase'
        GetDriverFunc = 'getSQLDriverInterBase'
        LibraryName = 'dbexpida.dll'
        LoginPrompt = False
        VendorLib = 'fbclient.DLL'
        pLeft = 172
        pTop = 32
      end
      object SqlGraficoAgenda: TfrxDBXQuery
        UserName = 'SqlGraficoAgenda'
        CloseDataSource = True
        BCDToCurrency = False
        IgnoreDupParams = False
        Params = <
          item
            Name = 'id_up'
            DataType = ftInteger
            Expression = '<ID_UP>'
          end>
        SQL.Strings = (
          'select '
          '    agenda_atendimento.idagenda_atendimento,'
          '    agenda_atendimento.hora_agenda,'
          '    agenda_atendimento.observacao,'
          '    agenda_atendimento.setor,'
          '    interno.nome_interno,'
          
            '    agenda_atendimento.hora_agenda||agenda_atendimento.setor GRU' +
            'PO_HORA_SETOR'
          'from agenda_atendimento'
          
            '   left join interno on (agenda_atendimento.id_interno = interno' +
            '.id_interno)'
          
            '   left join agenda_situacao s on (agenda_atendimento.idagenda_s' +
            'ituacao = s.idagenda_situacao)'
          'where agenda_atendimento.data_agenda = current_date'
          'and agenda_atendimento.id_up = :id_up'
          'order by agenda_atendimento.hora_agenda  ')
        Database = frxReport2.Database
        pLeft = 172
        pTop = 96
        Parameters = <
          item
            Name = 'id_up'
            DataType = ftInteger
            Expression = '<ID_UP>'
          end>
      end
    end
    object Page1: TfrxReportPage
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlack
      Font.Height = -11
      Font.Name = 'Courier'
      Font.Style = []
      PaperWidth = 65.000000000000000000
      PaperHeight = 331.000000000000000000
      PaperSize = 256
      Columns = 1
      ColumnWidth = 211.900000000000000000
      ColumnPositions.Strings = (
        '0')
      Frame.Typ = []
      MirrorMode = []
      OnBeforePrint = 'Page1OnBeforePrint'
      object ReportTitle1: TfrxReportTitle
        FillType = ftBrush
        FillGap.Top = 0
        FillGap.Left = 0
        FillGap.Bottom = 0
        FillGap.Right = 0
        Frame.Typ = []
        Height = 18.897650000000000000
        Top = 16.000000000000000000
        Width = 245.669450000000000000
        object Memo1: TfrxMemoView
          Align = baClient
          AllowVectorExport = True
          Width = 245.669450000000000000
          Height = 18.897650000000000000
          DisplayFormat.DecimalSeparator = ','
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -13
          Font.Name = 'Arial'
          Font.Style = []
          Frame.Typ = []
          HAlign = haCenter
          Memo.UTF8 = (
            'Agenda do Dia')
          ParentFont = False
        end
      end
      object MasterData1: TfrxMasterData
        FillType = ftBrush
        FillGap.Top = 0
        FillGap.Left = 0
        FillGap.Bottom = 0
        FillGap.Right = 0
        Frame.Typ = []
        Height = 41.574820240000000000
        Top = 92.000000000000000000
        Visible = False
        Width = 245.669450000000000000
        DataSet = frxReport2.SqlGraficoAgenda
        DataSetName = 'SqlGraficoAgenda'
        RowCount = 0
        Stretched = True
        object SqlGraficoAgendaOBSERVACAO: TfrxMemoView
          AllowVectorExport = True
          Left = 5.118120000000000000
          Top = 2.779529999999990000
          Width = 230.551207950000000000
          Height = 15.118120000000000000
          StretchMode = smMaxHeight
          DataSet = frxReport2.SqlGraficoAgenda
          DataSetName = 'SqlGraficoAgenda'
          DisplayFormat.DecimalSeparator = ','
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -9
          Font.Name = 'Arial'
          Font.Style = []
          Frame.Typ = []
          Memo.UTF8 = (
            
              '[SqlGraficoAgenda."NOME_INTERNO"]: [SqlGraficoAgenda."OBSERVACAO' +
              '"]')
          ParentFont = False
        end
      end
      object GroupHeader1: TfrxGroupHeader
        FillType = ftBrush
        FillGap.Top = 0
        FillGap.Left = 0
        FillGap.Bottom = 0
        FillGap.Right = 0
        Frame.Typ = []
        Height = 15.118110240000000000
        Top = 56.000000000000000000
        Width = 245.669450000000000000
        Condition = '<SqlGraficoAgenda."GRUPO_HORA_SETOR">'
        DrillDown = True
        object Memo2: TfrxMemoView
          AllowVectorExport = True
          Left = 2.015770000000000000
          Width = 37.795300000000000000
          Height = 15.118120000000000000
          DataField = 'HORA_AGENDA'
          DataSet = frxReport2.SqlGraficoAgenda
          DataSetName = 'SqlGraficoAgenda'
          DisplayFormat.DecimalSeparator = ','
          DisplayFormat.FormatStr = 'hh:mm'
          DisplayFormat.Kind = fkDateTime
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'Arial'
          Font.Style = [fsBold]
          Frame.Color = clBlue
          Frame.Typ = []
          HAlign = haRight
          Memo.UTF8 = (
            '[SqlGraficoAgenda."HORA_AGENDA"]')
          ParentFont = False
        end
        object Memo4: TfrxMemoView
          AllowVectorExport = True
          Left = 45.354360000000000000
          Width = 188.976500000000000000
          Height = 15.118120000000000000
          DataSet = frxReport2.SqlGraficoAgenda
          DataSetName = 'SqlGraficoAgenda'
          DisplayFormat.DecimalSeparator = ','
          DisplayFormat.FormatStr = 'hh:mm'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlack
          Font.Height = -11
          Font.Name = 'Arial'
          Font.Style = [fsBold]
          Frame.Color = clBlue
          Frame.Typ = []
          Memo.UTF8 = (
            '[SqlGraficoAgenda."SETOR"]')
          ParentFont = False
        end
      end
    end
  end
  object pm1: TPopupMenu
    Left = 81
    Top = 42
    object MenuItem1: TMenuItem
      Caption = 'Designer'
      OnClick = MenuItem1Click
    end
  end
  object tmr1: TTimer
    Interval = 100
    OnTimer = tmr1Timer
    Left = 584
    Top = 8
  end
  object ImageList1: TImageList
    Left = 240
    Top = 8
    Bitmap = {}
  end
  object SqlMovProcDetalhado: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT *'
      
        'FROM MOV_PROCEDIMENTOS M JOIN PROCEDIMENTOS P ON P.IDPROCEDIMENT' +
        'OS=M.IDPROCEDIMENTOS')
    SQLConnection = DM.SQLConnect
    Left = 880
    Top = 56
  end
  object DspMovProcDetalhado: TDataSetProvider
    DataSet = SqlMovProcDetalhado
    Left = 908
    Top = 56
  end
  object CdsMovProcDetalhado: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DSPMovProcDetalhado'
    Left = 936
    Top = 56
  end
  object DsMovProcDetalhado: TDataSource
    DataSet = CdsMovProcDetalhado
    Left = 964
    Top = 56
  end
  object PopupMenuProcedimentos: TPopupMenu
    Left = 337
    Top = 10
    object Encerrar1: TMenuItem
      Caption = 'Encerrar'
      OnClick = Encerrar1Click
    end
  end
  object frxDBDataset1: TfrxDBDataset
    UserName = 'frxDBDataset1'
    CloseDataSource = False
    DataSource = DsMovProcDetalhado
    BCDToCurrency = False
    Left = 891
    Top = 115
  end
  object frxGradientObject1: TfrxGradientObject
    Left = 664
    Top = 96
  end
  object frxReport3: TfrxReport
    Version = '6.9.12'
    DotMatrixReport = False
    IniFile = '\Software\Fast Reports'
    PreviewOptions.AllowEdit = False
    PreviewOptions.Buttons = [pbPrint, pbLoad, pbSave, pbExport, pbZoom, pbFind, pbOutline, pbPageSetup, pbTools, pbEdit, pbNavigator, pbExportQuick]
    PreviewOptions.Zoom = 100.000000000000000000
    PreviewOptions.ZoomMode = zmPageWidth
    PrintOptions.Printer = 'Padr'#227'o'
    PrintOptions.PrintOnSheet = 0
    ReportOptions.CreateDate = 40939.743598576390000000
    ReportOptions.LastChange = 40939.743598576390000000
    ScriptLanguage = 'PascalScript'
    ScriptText.Strings = (
      ''
      'begin'
      ''
      'end.')
    OnClickObject = frxReport3ClickObject
    Left = 800
    Top = 112
    Datasets = <>
    Variables = <>
    Style = <>
    object Data: TfrxDataPage
      Height = 1000.000000000000000000
      Width = 1000.000000000000000000
    end
    object Page1: TfrxReportPage
      PaperWidth = 215.900000000000000000
      PaperHeight = 279.400000000000000000
      PaperSize = 1
      LeftMargin = 10.000000000000000000
      RightMargin = 10.000000000000000000
      TopMargin = 10.000000000000000000
      BottomMargin = 10.000000000000000000
      Frame.Typ = []
      MirrorMode = []
      object ReportTitle1: TfrxReportTitle
        FillType = ftBrush
        FillGap.Top = 0
        FillGap.Left = 0
        FillGap.Bottom = 0
        FillGap.Right = 0
        Frame.Typ = []
        Height = 22.677180000000000000
        Top = 18.897650000000000000
        Width = 740.409927000000000000
      end
      object MasterData1: TfrxMasterData
        FillType = ftBrush
        FillGap.Top = 0
        FillGap.Left = 0
        FillGap.Bottom = 0
        FillGap.Right = 0
        Frame.Typ = []
        Height = 22.677180000000000000
        Top = 102.047310000000000000
        Width = 740.409927000000000000
        RowCount = 0
      end
      object PageFooter1: TfrxPageFooter
        FillType = ftBrush
        FillGap.Top = 0
        FillGap.Left = 0
        FillGap.Bottom = 0
        FillGap.Right = 0
        Frame.Typ = []
        Height = 22.677180000000000000
        Top = 185.196970000000000000
        Width = 740.409927000000000000
        object Memo1: TfrxMemoView
          AllowVectorExport = True
          Left = 665.197280000000000000
          Width = 75.590600000000000000
          Height = 18.897650000000000000
          Frame.Typ = []
          HAlign = haRight
          Memo.UTF8 = (
            '[Page#]')
        end
      end
    end
  end
  object frxReportOutros: TfrxReport
    Version = '6.9.12'
    DotMatrixReport = False
    IniFile = '\Software\Fast Reports'
    PreviewOptions.Buttons = [pbPrint, pbLoad, pbSave, pbExport, pbZoom, pbFind, pbOutline, pbPageSetup, pbTools, pbEdit, pbNavigator, pbExportQuick]
    PreviewOptions.Zoom = 1.000000000000000000
    PrintOptions.Printer = 'Padr'#227'o'
    PrintOptions.PrintOnSheet = 0
    ReportOptions.CreateDate = 40939.743679594910000000
    ReportOptions.LastChange = 40939.743679594910000000
    ScriptLanguage = 'PascalScript'
    ScriptText.Strings = (
      ''
      'begin'
      ''
      'end.')
    Left = 800
    Top = 160
    Datasets = <>
    Variables = <>
    Style = <>
    object Data: TfrxDataPage
      Height = 1000.000000000000000000
      Width = 1000.000000000000000000
    end
    object Page1: TfrxReportPage
      PaperWidth = 215.900000000000000000
      PaperHeight = 279.400000000000000000
      PaperSize = 1
      LeftMargin = 10.000000000000000000
      RightMargin = 10.000000000000000000
      TopMargin = 10.000000000000000000
      BottomMargin = 10.000000000000000000
      Frame.Typ = []
      MirrorMode = []
      object ReportTitle1: TfrxReportTitle
        FillType = ftBrush
        FillGap.Top = 0
        FillGap.Left = 0
        FillGap.Bottom = 0
        FillGap.Right = 0
        Frame.Typ = []
        Height = 22.677180000000000000
        Top = 18.897650000000000000
        Width = 740.409927000000000000
      end
      object MasterData1: TfrxMasterData
        FillType = ftBrush
        FillGap.Top = 0
        FillGap.Left = 0
        FillGap.Bottom = 0
        FillGap.Right = 0
        Frame.Typ = []
        Height = 22.677180000000000000
        Top = 102.047310000000000000
        Width = 740.409927000000000000
        RowCount = 0
      end
      object PageFooter1: TfrxPageFooter
        FillType = ftBrush
        FillGap.Top = 0
        FillGap.Left = 0
        FillGap.Bottom = 0
        FillGap.Right = 0
        Frame.Typ = []
        Height = 22.677180000000000000
        Top = 185.196970000000000000
        Width = 740.409927000000000000
        object Memo1: TfrxMemoView
          AllowVectorExport = True
          Left = 665.197280000000000000
          Width = 75.590600000000000000
          Height = 18.897650000000000000
          Frame.Typ = []
          HAlign = haRight
          Memo.UTF8 = (
            '[Page#]')
        end
      end
    end
  end
  object SqlEscalaPlantao: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT * FROM ESCALA_PLANTAO')
    SQLConnection = DM.SQLConnect
    Left = 880
    Top = 176
  end
  object DspEscalaPlantao: TDataSetProvider
    DataSet = SqlEscalaPlantao
    Left = 908
    Top = 176
  end
  object CdsEscalaPlantao: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DspEscalaPlantao'
    AfterInsert = CdsEscalaPlantaoAfterInsert
    AfterPost = CdsEscalaPlantaoAfterPost
    OnPostError = CdsEscalaPlantaoPostError
    Left = 936
    Top = 176
    object CdsEscalaPlantaoIDESCALA_PLANTAO: TIntegerField
      FieldName = 'IDESCALA_PLANTAO'
      Required = True
    end
    object CdsEscalaPlantaoIDEQUIPE: TIntegerField
      FieldName = 'IDEQUIPE'
      Required = True
    end
    object CdsEscalaPlantaoIDFUNCIONARIO: TIntegerField
      FieldName = 'IDFUNCIONARIO'
      Required = True
    end
    object CdsEscalaPlantaoIDFUNC_SUBSTITUTO: TIntegerField
      FieldName = 'IDFUNC_SUBSTITUTO'
    end
    object CdsEscalaPlantaoIDPOSTO_TRABALHO: TIntegerField
      FieldName = 'IDPOSTO_TRABALHO'
      Required = True
    end
    object CdsEscalaPlantaoDATA_PLANTAO: TSQLTimeStampField
      FieldName = 'DATA_PLANTAO'
      Required = True
    end
    object CdsEscalaPlantaoHORA_INICIO: TTimeField
      FieldName = 'HORA_INICIO'
      EditMask = '!90:00;1;_'
    end
    object CdsEscalaPlantaoHORA_FIM: TTimeField
      FieldName = 'HORA_FIM'
      EditMask = '!90:00;1;_'
    end
    object CdsEscalaPlantaoPOSTO_ROTATIVO: TStringField
      FieldName = 'POSTO_ROTATIVO'
      Size = 1
    end
    object CdsEscalaPlantaoOBSERVACOES: TStringField
      FieldName = 'OBSERVACOES'
      Size = 1000
    end
    object CdsEscalaPlantaoPOSTO_TRABALHO: TStringField
      FieldKind = fkLookup
      FieldName = 'POSTO_TRABALHO'
      LookupDataSet = DM.CdsPostoTrabalho
      LookupKeyFields = 'IDPOSTO_TRABALHO'
      LookupResultField = 'POSTO_TRABALHO'
      KeyFields = 'IDPOSTO_TRABALHO'
      Size = 50
      Lookup = True
    end
    object CdsEscalaPlantaoNOME_FUNCIONARIO: TStringField
      FieldKind = fkLookup
      FieldName = 'NOME_FUNCIONARIO'
      LookupDataSet = DM.cdsfuncionario
      LookupKeyFields = 'ID_FUNCIONARIO'
      LookupResultField = 'NOME_FUNCIONARIO'
      KeyFields = 'IDFUNCIONARIO'
      Size = 100
      Lookup = True
    end
    object CdsEscalaPlantaoEQUIPE: TStringField
      FieldKind = fkLookup
      FieldName = 'EQUIPE'
      LookupDataSet = DM.CdsEquipe
      LookupKeyFields = 'IDEQUIPE'
      LookupResultField = 'EQUIPE'
      KeyFields = 'IDEQUIPE'
      Size = 50
      Lookup = True
    end
    object CdsEscalaPlantaoSUBSTITUTO: TStringField
      FieldKind = fkLookup
      FieldName = 'SUBSTITUTO'
      LookupDataSet = DM.cdsfuncionario
      LookupKeyFields = 'ID_FUNCIONARIO'
      LookupResultField = 'NOME_FUNCIONARIO'
      KeyFields = 'IDFUNC_SUBSTITUTO'
      Lookup = True
    end
  end
  object DsEscalaPlantao: TDataSource
    DataSet = CdsEscalaPlantao
    Left = 964
    Top = 176
  end
  object DsUP: TDataSource
    DataSet = CdsUP
    Left = 164
    Top = 8
  end
  object CdsUP: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DspUP'
    Left = 136
    Top = 8
  end
  object DspUP: TDataSetProvider
    DataSet = SqlUP
    Left = 108
    Top = 8
  end
  object SqlUP: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT * FROM UNIDADE_PENAL'
      'order by nome_up')
    SQLConnection = DM.SQLConnect
    Left = 80
    Top = 8
  end
  object SkinDataSystem: TSkinData
    Active = False
    DisableTag = 99
    SkinControls = [xcMainMenu, xcPopupMenu, xcToolbar, xcControlbar, xcCombo, xcCheckBox, xcRadioButton, xcProgress, xcScrollbar, xcEdit, xcButton, xcBitBtn, xcSpeedButton, xcSpin, xcPanel, xcGroupBox, xcStatusBar, xcTab, xcTrackBar, xcSystemMenu]
    Options = [xoPreview, xoToolbarBK]
    Skin3rd.Strings = (
      'TCategoryButtons=scrollbar'
      'TPngBitBtn=pngbitbtn'
      'TVirtualStringTree=scrollbar'
      'TVirtualDrawTree=scrollbar'
      'TTBXDockablePanel=Panel'
      'TAdvPanelGroup=scrollbar'
      'TComboboxex=combobox'
      'TRxSpeedButton=speedbutton'
      'THTMLViewer=scrollbar'
      'TDBCtrlGrid=scrollbar'
      'TfrSpeedButton=speedbutton'
      'TfrTBButton=speedbutton'
      'TControlBar=Panel'
      'TTBDock=Panel'
      'TTBToolbar=Panel'
      'TImageEnMView=scrollbar'
      'TImageEnView=scrollbar'
      'TAdvMemo=scrollbar'
      'TDBAdvMemo=scrollbar'
      'TcxDBLookupComboBox=combobox'
      'TcxDBComboBox=combobox'
      'TcxDBDateEdit=combobox'
      'TcxDBImageComboBox=combobox'
      'TcxDBCalcEdit=combobox'
      'TcxDBBlobEdit=combobox'
      'TcxDBPopupEdit=combobox'
      'TcxDBFontNameComboBox=combobox'
      'TcxDBShellComboBox=combobox'
      'TRxLookupEdit=combobox'
      'TRxDBLookupCombo=combobox'
      'TRzGroup=panel'
      'TRzButton=button'
      'TRzBitbtn=bitbtn'
      'TRzMenuButton=menubtn'
      'TRzCheckGroup=CheckGroup'
      'TRzRadioGroup=Radiogroup'
      'TRzButtonEdit=Edit'
      'TRzDBRadioGroup=Radiogroup'
      'TRzDBRadioButton=Radiobutton'
      'TRzDateTimeEdit=combobox'
      'TRzColorEdit=combobox'
      'TRzDateTimePicker=combobox'
      'TRzDBDateTimeEdit=combobox'
      'TRzDbColorEdit=combobox'
      'TRzDBDateTimePicker=combobox'
      'TLMDButton=bitbtn'
      'TLMDGroupBox=Groupbox'
      'TDBCheckboxEh=Checkbox'
      'TDBCheckboxEh=Checkbox'
      'TLMDCHECKBOX=Checkbox'
      'TLMDDBCHECKBOX=Checkbox'
      'TLMDRadiobutton=Radiobutton'
      'TLMDCalculator=panel'
      'TLMDGROUPBOX=Panel'
      'TLMDSIMPLEPANEL=Panel'
      'TLMDDBCalendar=Panel'
      'TLMDButtonPanel=Panel'
      'TLMDLMDCalculator=Panel'
      'TLMDHeaderPanel=Panel'
      'TLMDTechnicalLine=Panel'
      'TLMDLMDClock=Panel'
      'TLMDTrackbar=panel'
      'TLMDListCombobox=combobox'
      'TLMDCheckListCombobox=combobox'
      'TLMDHeaderListCombobox=combobox'
      'TLMDImageCombobox=combobox'
      'TLMDColorCombobox=combobox'
      'TLMDFontCombobox=combobox'
      'TLMDFontSizeCombobox=combobox'
      'TLMDFontSizeCombobox=combobox'
      'TLMDPrinterCombobox=combobox'
      'TLMDDriveCombobox=combobox'
      'TLMDCalculatorComboBox=combobox'
      'TLMDTrackBarComboBox=combobox'
      'TLMDCalendarComboBox=combobox'
      'TLMDTreeComboBox=combobox'
      'TLMDRADIOGROUP=radiogroup'
      'TLMDCheckGroup=CheckGroup'
      'TLMDDBRADIOGROUP=radiogroup'
      'TLMDDBCheckGroup=CheckGroup'
      'TLMDCalculatorEdit=edit'
      'TLMDEDIT=Edit'
      'TLMDMASKEDIT=Edit'
      'TLMDBROWSEEDIT=Edit'
      'TLMDEXTSPINEDIT=Edit'
      'TLMDCALENDAREDIT=Edit'
      'TLMDFILEOPENEDIT=Edit'
      'TLMDFILESAVEEDIT=Edit'
      'TLMDCOLOREDIT=Edit'
      'TLMDDBEDIT=Edit'
      'TLMDDBMASKEDIT=Edit'
      'TLMDDBEXTSPINEDIT=Edit'
      'TLMDDBSPINEDIT=Edit'
      'TLMDDBEDITDBLookup=Edit'
      'TLMDEDITDBLookup=Edit'
      'TDBLookupCombobox=Combobox'
      'TWWDBCombobox=Combobox'
      'TWWDBLookupCombo=Combobox'
      'TWWDBCombobox=Combobox'
      'TWWKeyCombo=Combobox'
      'TWWTempKeyCombo=combobox'
      'TWWDBDateTimePicker=Combobox'
      'TWWRADIOGROUP=radiogroup'
      'TWWDBEDIT=Edit'
      'TcxButton=bitbtn'
      'TcxDBRadioGroup=radiogroup'
      'TcxRadioGroup=radiogroup'
      'TcxGroupbox=groupbox'
      'TOVCPICTUREFIELD=Edit'
      'TOVCDBPICTUREFIELD=Edit'
      'TOVCSLIDEREDIT=Edit'
      'TOVCDBSLIDEREDIT=Edit'
      'TOVCSIMPLEFIELD=Edit'
      'TOVCDBSIMPLEFIELD=Edit'
      'TO32DBFLEXEDIT=Edit'
      'TOVCNUMERICFIELD=Edit'
      'TOVCDBNUMERICFIELD=Edit')
    SkinStore = '(none)'
    SkinFormtype = sfMainform
    Version = '4.80.04.20'
    MenuUpdate = True
    MenuMerge = True
    Left = 48
    Top = 80
    SkinStream = {}
  end
  object SQLfuncionario: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT F.ID_FUNCIONARIO, F.NOME_FUNCIONARIO, F.FOTO,'
      '     F.DTNASCIMENTO, F.MATRICULA, P.POSTO_TRABALHO, U.NOME_UP '
      '     FROM FUNCIONARIO F '
      '     LEFT JOIN UNIDADE_PENAL U ON (F.ID_UP=U.ID_UP) '
      
        '     LEFT JOIN POSTO_TRABALHO P ON (F.IDPOSTO_TRABALHO=P.IDPOSTO' +
        '_TRABALHO)'
      '     WHERE F.ID_FUNCIONARIO=2099')
    SQLConnection = DM.SQLConnect
    Left = 880
    Top = 232
  end
  object dspfuncionario: TDataSetProvider
    DataSet = SQLfuncionario
    Left = 908
    Top = 232
  end
  object cdsfuncionario: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'dspfuncionario'
    Left = 936
    Top = 232
  end
  object DsFuncionario: TDataSource
    DataSet = cdsfuncionario
    Left = 964
    Top = 232
  end
  object OpenDialog1: TOpenDialog
    Filter = 'Imagens (*.jpg)|*.jpg'
    Left = 679
    Top = 8
  end
  object SqlUltimosLogs: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT F.ID_FUNCIONARIO, F.NOME_FUNCIONARIO, F.FOTO,'
      '     F.DTNASCIMENTO, F.MATRICULA, P.POSTO_TRABALHO, U.NOME_UP '
      '     FROM FUNCIONARIO F '
      '     LEFT JOIN UNIDADE_PENAL U ON (F.ID_UP=U.ID_UP) '
      
        '     LEFT JOIN POSTO_TRABALHO P ON (F.IDPOSTO_TRABALHO=P.IDPOSTO' +
        '_TRABALHO)'
      '     WHERE F.ID_FUNCIONARIO=2099')
    SQLConnection = DM.SQLConnect
    Left = 880
    Top = 280
  end
  object DspUltimosLogs: TDataSetProvider
    DataSet = SqlUltimosLogs
    Left = 908
    Top = 280
  end
  object CdsUltimosLogs: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DspUltimosLogs'
    Left = 936
    Top = 280
  end
  object DsUltimosLogs: TDataSource
    DataSet = CdsUltimosLogs
    Left = 964
    Top = 280
  end
  object TimerIdentificacao: TTimer
    Left = 864
    Top = 8
  end
  object TimeraAtualizaRelAgendaDia: TTimer
    Interval = 300000
    OnTimer = TimeraAtualizaRelAgendaDiaTimer
    Left = 264
    Top = 72
  end
  object TimerAtualizaRelQtdPresos: TTimer
    Interval = 1800000
    OnTimer = TimerAtualizaRelQtdPresosTimer
    Left = 264
    Top = 104
  end
end
