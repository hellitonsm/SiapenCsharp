object TelaLogin: TTelaLogin
  Left = 871
  Top = 574
  BorderStyle = bsDialog
  Caption = 'SIAPEN - Sistema Integrado de Administra'#231#227'o Penitenci'#225'ria'
  ClientHeight = 206
  ClientWidth = 658
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnCreate = FormCreate
  OnKeyDown = FormKeyDown
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBoxLocal: TGroupBox
    Left = 8
    Top = 8
    Width = 633
    Height = 61
    Caption = 'AGEPEN'
    Color = clWhite
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -19
    Font.Name = 'Times New Roman'
    Font.Style = [fsBold]
    ParentColor = False
    ParentFont = False
    TabOrder = 0
    object Image2: TImage
      Left = 2
      Top = 23
      Width = 629
      Height = 36
      Align = alClient
      Picture.Data = {}
      Stretch = True
    end
    object LabelNome: TLabel
      Left = 41
      Top = 32
      Width = 564
      Height = 17
      Caption = 'AG'#202'NCIA ESTADUAL DE ADMINISTRA'#199#195'O DO SISTEMA PENITENCI'#193'RIO'
      Font.Charset = ANSI_CHARSET
      Font.Color = clBlack
      Font.Height = -16
      Font.Name = 'Times New Roman'
      Font.Style = [fsBold]
      ParentFont = False
      Transparent = True
    end
    object Image3: TImage
      Left = 4
      Top = 24
      Width = 35
      Height = 31
      Picture.Data = {}
    end
  end
  object GroupBox2: TGroupBox
    Left = 184
    Top = 72
    Width = 457
    Height = 113
    Caption = 'Estabelecimento Penal'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 2
    object SpeedButton1: TSpeedButton
      Left = 72
      Top = 40
      Width = 113
      Height = 65
      Caption = 'Entrar'
      Flat = True
      Glyph.Data = {}
      OnClick = SpeedButton1Click
    end
    object SpeedButton2: TSpeedButton
      Left = 264
      Top = 40
      Width = 105
      Height = 65
      Caption = 'Sair'
      Flat = True
      Glyph.Data = {}
      OnClick = SpeedButton2Click
    end
    object DBLookupComboBox1: TDBLookupComboBox
      Left = 8
      Top = 16
      Width = 441
      Height = 21
      Enabled = False
      KeyField = 'ID_UP'
      ListField = 'NOME_UP'
      ListSource = DsUP
      TabOrder = 0
      OnClick = DBLookupComboBox1Click
    end
  end
  object GroupBox4: TGroupBox
    Left = 8
    Top = 72
    Width = 161
    Height = 113
    Caption = 'Identfica'#231#227'o'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 1
    object Label1: TLabel
      Left = 11
      Top = 16
      Width = 31
      Height = 13
      Caption = 'Login'
      Font.Charset = ANSI_CHARSET
      Font.Color = clNavy
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label2: TLabel
      Left = 11
      Top = 59
      Width = 36
      Height = 13
      Caption = 'Senha'
      Font.Charset = ANSI_CHARSET
      Font.Color = clNavy
      Font.Height = -11
      Font.Name = 'MS Sans Serif'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Edit1: TEdit
      Left = 8
      Top = 32
      Width = 121
      Height = 21
      CharCase = ecUpperCase
      TabOrder = 0
      OnExit = Edit1Exit
    end
    object Edit2: TEdit
      Left = 8
      Top = 76
      Width = 121
      Height = 21
      CharCase = ecUpperCase
      PasswordChar = '*'
      TabOrder = 1
      OnKeyDown = Edit2KeyDown
    end
  end
  object Sqlservidor: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'select * from funcionario')
    SQLConnection = DM.SQLConnect
    Left = 552
    Top = 104
  end
  object Dspservidor: TDataSetProvider
    DataSet = Sqlservidor
    Left = 580
    Top = 104
  end
  object Cdsservidor: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'Dspservidor'
    Left = 608
    Top = 104
  end
  object Dsservidor: TDataSource
    DataSet = Cdsservidor
    Left = 636
    Top = 104
  end
  object SqlUP: TSQLQuery
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT * FROM UNIDADE_PENAL'
      'order by nome_up')
    SQLConnection = DM.SQLConnect
    Left = 552
    Top = 152
  end
  object DspUP: TDataSetProvider
    DataSet = SqlUP
    Left = 580
    Top = 152
  end
  object CdsUP: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DspUP'
    Left = 608
    Top = 152
    object CdsUPID_UP: TIntegerField
      FieldName = 'ID_UP'
      Required = True
    end
    object CdsUPNOME_UP: TStringField
      FieldName = 'NOME_UP'
      Size = 50
    end
    object CdsUPENDERECO: TStringField
      FieldName = 'ENDERECO'
      Size = 50
    end
    object CdsUPNUMERO: TStringField
      FieldName = 'NUMERO'
      Size = 30
    end
    object CdsUPBAIRRO: TStringField
      FieldName = 'BAIRRO'
      Size = 50
    end
    object CdsUPCOMPLEMENTO: TStringField
      FieldName = 'COMPLEMENTO'
      Size = 50
    end
    object CdsUPCEP: TStringField
      FieldName = 'CEP'
      Size = 8
    end
    object CdsUPID_CIDADE: TIntegerField
      FieldName = 'ID_CIDADE'
    end
    object CdsUPFONE: TStringField
      FieldName = 'FONE'
      Size = 10
    end
    object CdsUPFAX: TStringField
      FieldName = 'FAX'
      Size = 10
    end
    object CdsUPCONTATO: TStringField
      FieldName = 'CONTATO'
      Size = 50
    end
    object CdsUPFOTO: TStringField
      FieldName = 'FOTO'
      Size = 16386
    end
    object CdsUPCAPITAL: TStringField
      FieldName = 'CAPITAL'
      Size = 30
    end
    object CdsUPREGIAO: TStringField
      FieldName = 'REGIAO'
      Size = 50
    end
    object CdsUPSIGLA: TStringField
      FieldName = 'SIGLA'
      Size = 50
    end
  end
  object DsUP: TDataSource
    DataSet = CdsUP
    Left = 636
    Top = 152
  end
end
