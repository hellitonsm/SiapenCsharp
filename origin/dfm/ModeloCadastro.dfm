object FrmModeloCadastro: TFrmModeloCadastro
  Left = 281
  Top = 226
  Width = 800
  Height = 462
  Caption = 'Modelo de Cadastro'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnActivate = FormActivate
  OnCloseQuery = FormCloseQuery
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  OnKeyDown = FormKeyDown
  OnKeyPress = FormKeyPress
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object PanelBotoes: TPanel
    Left = 0
    Top = 32
    Width = 115
    Height = 384
    Align = alLeft
    BevelOuter = bvNone
    TabOrder = 1
    object ToolBarModeloCadastro: TToolBar
      Left = 0
      Top = 0
      Width = 115
      Height = 366
      Align = alClient
      ButtonHeight = 38
      ButtonWidth = 117
      Caption = 'ToolBarModeloCadastro'
      Color = 11828053
      EdgeBorders = []
      Flat = True
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clNavy
      Font.Height = -13
      Font.Name = 'Lucida Console'
      Font.Style = []
      Images = ImageListCadastro
      Indent = 6
      List = True
      ParentColor = False
      ParentFont = False
      ShowCaptions = True
      TabOrder = 0
      Transparent = False
      object Novo: TToolButton
        Left = 6
        Top = 0
        Caption = '&NOVO'
        ImageIndex = 47
        Wrap = True
        OnClick = NovoClick
      end
      object Editar: TToolButton
        Left = 6
        Top = 38
        Caption = '&EDITAR'
        ImageIndex = 23
        Wrap = True
        OnClick = EditarClick
      end
      object Cancelar: TToolButton
        Left = 6
        Top = 76
        Caption = 'CANCELAR'
        ImageIndex = 45
        Wrap = True
        OnClick = CancelarClick
      end
      object Salvar: TToolButton
        Left = 6
        Top = 114
        Caption = '&SALVAR'
        ImageIndex = 40
        Wrap = True
        OnClick = SalvarClick
      end
      object Excluir: TToolButton
        Left = 6
        Top = 152
        Caption = 'EXCLUIR'
        ImageIndex = 48
        Wrap = True
        Visible = False
        OnClick = ExcluirClick
      end
      object Fechar: TToolButton
        Left = 6
        Top = 190
        Caption = 'FECHAR'
        ImageIndex = 43
        OnClick = FecharClick
      end
    end
    object DBNavigator1: TDBNavigator
      Left = 0
      Top = 366
      Width = 115
      Height = 18
      DataSource = DsCadastro
      VisibleButtons = [nbFirst, nbPrior, nbNext, nbLast]
      Align = alBottom
      TabOrder = 1
    end
  end
  object PanelModeloCadastro: TPanel
    Left = 115
    Top = 32
    Width = 677
    Height = 384
    Align = alClient
    BevelOuter = bvNone
    Caption = 'PanelModeloCadastro'
    TabOrder = 2
    object PageControlModeloCadastro: TPageControl
      Left = 0
      Top = 0
      Width = 677
      Height = 384
      ActivePage = TabSheetConsulta
      Align = alClient
      TabOrder = 0
      TabWidth = 150
      OnChange = PageControlModeloCadastroChange
      object TabSheetCadastro: TTabSheet
        Caption = 'Cadastro'
        object PanelCadastro: TPanel
          Left = 0
          Top = 0
          Width = 669
          Height = 356
          Align = alClient
          TabOrder = 0
        end
      end
      object TabSheetConsulta: TTabSheet
        Caption = 'Consulta'
        ImageIndex = 1
        object PanelLocalizaConsulta: TPanel
          Left = 0
          Top = 0
          Width = 669
          Height = 34
          Align = alTop
          TabOrder = 0
          object Label1: TLabel
            Left = 8
            Top = 8
            Width = 45
            Height = 13
            Caption = 'Localizar:'
          end
          object EditLocalizar: TEdit
            Left = 56
            Top = 8
            Width = 608
            Height = 21
            BorderStyle = bsNone
            CharCase = ecUpperCase
            Color = clBlack
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clLime
            Font.Height = -19
            Font.Name = 'Lucida Console'
            Font.Style = []
            ParentFont = False
            TabOrder = 0
            OnChange = EditLocalizarChange
          end
        end
        object PanelConsulta: TPanel
          Left = 0
          Top = 34
          Width = 669
          Height = 322
          Align = alClient
          TabOrder = 1
          OnDblClick = CancelarClick
          object DBGridConsulta: TDBGrid
            Left = 1
            Top = 1
            Width = 667
            Height = 320
            Align = alClient
            DataSource = DsCadastro
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
          end
        end
      end
    end
  end
  object PanelTituloModeloCadastro: TPanel
    Left = 0
    Top = 0
    Width = 792
    Height = 32
    Align = alTop
    BevelOuter = bvNone
    Caption = 'Modelo de Cadastro'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -40
    Font.Name = 'Times New Roman'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 0
    object Image2: TImage
      Left = 0
      Top = 0
      Width = 792
      Height = 32
      Align = alClient
      Picture.Data = {}
      Stretch = True
    end
    object Image3: TImage
      Left = 12
      Top = -1
      Width = 35
      Height = 32
      Picture.Data = {}
    end
    object LabelTitulo: TLabel
      Left = 49
      Top = 4
      Width = 560
      Height = 23
      Alignment = taCenter
      Caption = 'SIAPEN - Sistema Integrado de Administra'#231#227'o Penitenci'#225'ria'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -21
      Font.Name = 'Times New Roman'
      Font.Style = []
      ParentFont = False
      Transparent = True
    end
  end
  object StatusBar1: TStatusBar
    Left = 0
    Top = 416
    Width = 792
    Height = 19
    Panels = <
      item
        Text = 'Status do cadastro:'
        Width = 100
      end
      item
        Width = 400
      end
      item
        Width = 200
      end>
  end
  object ImageListCadastro: TImageList
    Height = 32
    Width = 32
    Left = 656
    Top = 8
    Bitmap = {}
  end
  object SqlCadastro: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT * '
      'FROM SENHA')
    Left = 592
    Top = 152
  end
  object DspCadastro: TDataSetProvider
    DataSet = SqlCadastro
    Left = 620
    Top = 152
  end
  object CdsCadastro: TClientDataSet
    Aggregates = <>
    PacketRecords = 100
    Params = <>
    ProviderName = 'DspCadastro'
    OnFilterRecord = CdsCadastroFilterRecord
    Left = 648
    Top = 152
  end
  object DsCadastro: TDataSource
    DataSet = CdsCadastro
    OnDataChange = DsCadastroDataChange
    Left = 676
    Top = 152
  end
end
