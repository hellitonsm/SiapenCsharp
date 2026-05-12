# SIAPEN - Conversão Delphi → C# Avalonia

## Regras do Projeto

### Escopo
- Converter o sistema SIAPEN (Delphi) para C# usando **Avalonia UI** (.NET)
- Código-fonte em `src/Siapen/`
- Arquivos Delphi de referência em `origin/`

### Diretrizes de Conversão

1. **Telas (DFM → Avalonia)**
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
- [x] LibHelper convertido
- [x] GlobalVars convertido
- [x] DatabaseService criado
- [x] MainWindow esqueleto com todos os botões
- [ ] LoginWindow
- [ ] Telas de cadastro
- [ ] Telas de setores
- [ ] Telas de movimentação
- [ ] Relatórios
