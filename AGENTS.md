# SIAPEN - Conversão Delphi → C# Avalonia

## Regras do Projeto

### Escopo
- Converter o sistema SIAPEN (Delphi) para C# usando **Avalonia UI** (.NET)
- Código-fonte em `src/Siapen/`
- Arquivos Delphi de referência em `origin/`

### Diretrizes de Conversão

1. **Telas (DFM → Avalonia)**
   - **Codificação dos DFMs**: Arquivos `.dfm` em `origin/dfm/` são ASCII puro, mas usam a notação Delphi `#<ord>` para caracteres acentuados (ex: `#227'o` = `ão`, `#243'digo` = `ódigo`, `#231#227'o` = `ção`)
   - Os números após `#` são code points **Latin-1 (ISO-8859-1)**. Ex: `#227` = `ã` (U+00E3), `#243` = `ó` (U+00F3), `#231` = `ç` (U+00E7)
   - Ao converter para C#, substituir por literais Unicode (`\u00e3`, `\u00f3`, `\u00e7`) ou diretamente o caractere UTF-8
   - Só implementar telas que tiverem DFM fornecido em `origin/dfm/`
   - Cada tela DFM corresponde a um par `Views/<Nome>View.axaml` + `Views/<Nome>View.axaml.cs`
   - ViewModels em `ViewModels/<Nome>ViewModel.cs`
   - Usar MVVM pattern do Avalonia

2. **Módulo Principal**
   - Começa como esqueleto com todos os botões/menus
   - Botões sem tela implementada mostram MessageBox "Não implementado"
   - Conforme telas forem implementadas, botões passam a abrir as telas

3. **Lib.pas → Helpers/**
   - Funções utilitárias do `origin/lib/Lib.pas` convertidas para `Helpers/LibHelper.cs`
   - Variáveis globais em `Helpers/GlobalVars.cs`
   - Funções de login/criptografia em `Helpers/AuthHelper.cs`

4. **Banco de Dados**
   - Firebird (manter banco existente)
   - Usar `FirebirdSql.Data.FirebirdClient`
   - Para extrair DDLs de tabelas: `python origin/extrairdatabase/extractor.py <nome_tabela>`
   - Conexão e queries em `Services/DatabaseService.cs`

5. **Nomenclatura**
   - Manter nomes originais de tabelas e campos (Firebird é case-insensitive)
   - Classes C# usam PascalCase
   - Arquivos seguem o padrão `<Nome>View.axaml`, `<Nome>ViewModel.cs`

6. **Idioma**
   - Respostas em português
   - Comentários e código em inglês (padrão C#)
   - Labels/mensagens da UI em português

### Estrutura de Pastas

```
src/Siapen/
├── Views/              # Telas Avalonia (AXAML)
├── ViewModels/         # ViewModels (MVVM)
├── Services/           # Serviços (Database, etc.)
├── Models/             # Modelos de dados
├── Helpers/            # Funções utilitárias (Lib.pas convertido)
├── Config/             # Configurações
├── App.axaml           # Aplicação principal
├── App.axaml.cs
└── Program.cs
```

### Fluxo de Trabalho

1. Usuário fornece novo DFM
2. Criar View (AXAML) + code-behind
3. Criar ViewModel se necessário
4. Conectar botão correspondente no MainWindow
5. Se precisar de tabela do banco, usar extractor.py
6. Testar build: `cd src/Siapen && dotnet build`

### Estado Atual

- [x] Estrutura do projeto criada
- [x] LibHelper convertido (Senha(), ValidaCpf(), etc.)
- [x] GlobalVars convertido
- [x] DatabaseService criado (conexão Firebird OK)
- [x] MainWindow esqueleto com todos os botões
- [x] LoginWindow criada (ComboBox de UPs funcionando)
- [x] App.axaml.cs atualizado para abrir LoginWindow
- [x] Sistema de log criado (LogHelper.cs)
- [x] Charset corrigido (UTF8, ignorando WIN1252 do INI)
- [x] AuthHelper reescrito para ler senha como bytes brutos via CAST BLOB
- [x] **Login funcionando!** — Login `226080` / senha correta → `HELLITON SOARES MESQUITA` (ID=8024)
- [x] MainWindow NullReferenceException corrigida (UpdateDataHora movido para OnOpened)
- [ ] Telas de cadastro
- [ ] Telas de setores
- [ ] Telas de movimentação
- [ ] Relatórios

### Descobertas Importantes

#### Charset Firebird
- O driver FirebirdSql.Data.FirebirdClient 10.3.4 **NÃO suporta** WIN1252, ISO8859_1, NONE
- Apenas UTF8 funciona com o servidor Firebird 2.5
- O INI original tem `Charset=WIN1252` — o AppConfig sobrescreve para UTF8

#### Comparação de Senhas
- A cifra é `(255 - c) & 0xFF` — auto-inversora
- A senha cifrada contém chars >127 (ex: '5' 0x35 → 0xCF)
- O driver UTF8 converte chars >127 para 2 bytes, quebrando comparação
- **Solução**: Ler o campo SENHA como bytes brutos via `reader.GetBytes()` e converter com ISO-8859-1
- Comparar em C# com `StringComparison.Ordinal`

#### Credenciais de Teste
- Login: `233448`, Senha: `56965656` (confirmada via isql)
- Login: `ADMIN`, Senha: decifra de `BF CE CC CA C8 C6 CF BB` = `@135790D`
- Muitos funcionários têm senha = login

#### Ativação de Recursos no Menu
- `Command` binding (`Command="{Binding FooCommand}"`) **NÃO funciona** em sub-MenuItems no Avalonia (fica desabilitado)
- **Solução**: Usar `Click="Foo_Click"` no XAML e criar o handler no code-behind de `MainWindow.axaml.cs`
- Exemplo:
  ```xml
  <MenuItem Header="Pavilhão" Click="CadastroPavilhao_Click"/>
  ```
  ```csharp
  private void CadastroPavilhao_Click(object? sender, RoutedEventArgs e)
  {
      var view = new CadastroPavilhaoView();
      view.Show();
  }
  ```

#### Build
- `dotnet build --no-restore` é mais rápido (evita restore que às vezes trava)
- `dotnet run --no-build` para executar sem recompilar
- Logs em `bin/Debug/net10.0/Logs/siapen_YYYY-MM-DD.log`
