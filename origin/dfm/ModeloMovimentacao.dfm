object FrmModeloMovimentacao: TFrmModeloMovimentacao
  Left = 235
  Top = 79
  Width = 715
  Height = 500
  Caption = 'Modelo de Movimenta'#231#227'o'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poMainFormCenter
  OnCloseQuery = FormCloseQuery
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  OnKeyDown = FormKeyDown
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object PanelBotoes: TPanel
    Left = 0
    Top = 0
    Width = 699
    Height = 88
    Align = alTop
    BevelOuter = bvNone
    TabOrder = 0
    object ToolBarModeloCadastro: TToolBar
      Left = 0
      Top = 36
      Width = 699
      Height = 52
      Align = alBottom
      BorderWidth = 1
      ButtonHeight = 38
      ButtonWidth = 91
      Caption = 'ToolBarModeloCadastro'
      Customizable = True
      Images = ImageListCadastro
      Indent = 1
      List = True
      ShowCaptions = True
      TabOrder = 1
      Transparent = False
      object Novo: TToolButton
        Left = 1
        Top = 2
        Caption = '&Novo'
        ImageIndex = 47
        OnClick = NovoClick
      end
      object Editar: TToolButton
        Left = 92
        Top = 2
        Caption = '&Editar'
        ImageIndex = 23
        OnClick = EditarClick
      end
      object Cancelar: TToolButton
        Left = 183
        Top = 2
        Caption = 'Cancelar  '
        ImageIndex = 45
        OnClick = CancelarClick
      end
      object Salvar: TToolButton
        Left = 274
        Top = 2
        Caption = '&Salvar'
        ImageIndex = 40
        OnClick = SalvarClick
      end
      object Excluir: TToolButton
        Left = 365
        Top = 2
        Caption = 'Excluir'
        ImageIndex = 48
        OnClick = ExcluirClick
      end
      object Fechar: TToolButton
        Left = 456
        Top = 2
        Caption = 'Fechar'
        ImageIndex = 43
        OnClick = FecharClick
      end
    end
    object PanelLocalizaConsulta: TPanel
      Left = 0
      Top = 0
      Width = 699
      Height = 34
      Align = alTop
      TabOrder = 0
      DesignSize = (
        699
        34)
      object Label1: TLabel
        Left = 8
        Top = 8
        Width = 45
        Height = 13
        Caption = 'Localizar:'
      end
      object EditLocalizar: TEdit
        Left = 63
        Top = 2
        Width = 642
        Height = 32
        Anchors = [akLeft, akTop, akRight]
        Color = clBlack
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clLime
        Font.Height = -19
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 0
      end
    end
  end
  object PanelModeloCadastro: TPanel
    Left = 0
    Top = 88
    Width = 699
    Height = 355
    Align = alClient
    BevelOuter = bvNone
    Caption = 'PanelModeloCadastro'
    TabOrder = 1
    object PageControlModeloCadastro: TPageControl
      Left = 0
      Top = 0
      Width = 699
      Height = 167
      ActivePage = TabSheetCadastro
      Align = alTop
      TabOrder = 0
      TabWidth = 150
      object TabSheetCadastro: TTabSheet
        Caption = 'Cadastro'
      end
    end
    object PageControlConsulta: TPageControl
      Left = 0
      Top = 167
      Width = 699
      Height = 188
      ActivePage = TabSheetConsulta
      Align = alClient
      TabOrder = 1
      TabWidth = 150
      object TabSheetConsulta: TTabSheet
        Caption = 'Consulta'
        object DBGridConsulta: TDBGrid
          Left = 0
          Top = 0
          Width = 691
          Height = 160
          Align = alClient
          DataSource = DsConsulta
          Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgConfirmDelete, dgCancelOnExit]
          ReadOnly = True
          TabOrder = 0
          TitleFont.Charset = DEFAULT_CHARSET
          TitleFont.Color = clWindowText
          TitleFont.Height = -11
          TitleFont.Name = 'MS Sans Serif'
          TitleFont.Style = []
          OnDrawColumnCell = DBGridConsultaDrawColumnCell
          OnTitleClick = DBGridConsultaTitleClick
        end
      end
      object TabSheetMovimentacao: TTabSheet
        Caption = 'Movimenta'#231#227'o'
        ImageIndex = 1
        object DBGrid1: TDBGrid
          Left = 0
          Top = 0
          Width = 642
          Height = 166
          Align = alClient
          DataSource = DsMovimento
          Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgConfirmDelete, dgCancelOnExit]
          ReadOnly = True
          TabOrder = 0
          TitleFont.Charset = DEFAULT_CHARSET
          TitleFont.Color = clWindowText
          TitleFont.Height = -11
          TitleFont.Name = 'MS Sans Serif'
          TitleFont.Style = []
          OnDrawColumnCell = DBGridConsultaDrawColumnCell
          OnTitleClick = DBGridConsultaTitleClick
        end
      end
    end
  end
  object StatusBar1: TStatusBar
    Left = 0
    Top = 443
    Width = 699
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
    SQLConnection = DM.SQLConnect
    Left = 16
    Top = 8
  end
  object DspCadastro: TDataSetProvider
    DataSet = SqlCadastro
    Left = 44
    Top = 8
  end
  object CdsCadastro: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DspCadastro'
    OnReconcileError = CdsCadastroReconcileError
    Left = 72
    Top = 8
  end
  object DsCadastro: TDataSource
    DataSet = CdsCadastro
    OnDataChange = DsCadastroDataChange
    Left = 100
    Top = 8
  end
  object SqlMovimento: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT * '
      'FROM SENHA')
    SQLConnection = DM.SQLConnect
    Left = 496
    Top = 8
  end
  object DspMovimento: TDataSetProvider
    DataSet = SqlMovimento
    Left = 524
    Top = 8
  end
  object CdsMovimento: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DspConsulta'
    Left = 552
    Top = 8
  end
  object DsMovimento: TDataSource
    DataSet = CdsMovimento
    OnDataChange = DsCadastroDataChange
    Left = 580
    Top = 8
  end
  object SqlConsulta: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT * '
      'FROM SENHA')
    SQLConnection = DM.SQLConnect
    Left = 272
    Top = 8
  end
  object DspConsulta: TDataSetProvider
    DataSet = SqlConsulta
    Left = 300
    Top = 8
  end
  object CdsConsulta: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DspConsulta'
    Left = 328
    Top = 8
  end
  object DsConsulta: TDataSource
    DataSet = CdsConsulta
    OnDataChange = DsCadastroDataChange
    Left = 356
    Top = 8
  end
end
