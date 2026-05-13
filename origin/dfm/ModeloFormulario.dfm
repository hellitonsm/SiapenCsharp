object FrmModeloFormulario: TFrmModeloFormulario
  Left = 206
  Top = 281
  Width = 438
  Height = 245
  Caption = 'Formulario Auxiliar'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poMainFormCenter
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object PanelGeral: TPanel
    Left = 0
    Top = 41
    Width = 422
    Height = 166
    Align = alClient
    TabOrder = 0
  end
  object PanelTitulo: TPanel
    Left = 0
    Top = 0
    Width = 422
    Height = 41
    Align = alTop
    Caption = 'Formulario Auxiliar'
    Color = clCream
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clNavy
    Font.Height = -11
    Font.Name = 'Times New Roman'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    object Image2: TImage
      Left = 1
      Top = 1
      Width = 420
      Height = 39
      Align = alClient
      Picture.Data = {}
      Stretch = True
    end
    object LabelTitulo: TLabel
      Left = 45
      Top = 9
      Width = 498
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
    object Image3: TImage
      Left = 12
      Top = 5
      Width = 35
      Height = 32
      Picture.Data = {}
    end
  end
end
