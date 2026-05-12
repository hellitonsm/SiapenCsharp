# SIAPEN - Sistema Integrado de Administração Penitenciária

Conversão do sistema legado Delphi para C# com Avalonia UI (.NET).

## Requisitos

- [.NET SDK 10.0+](https://dotnet.microsoft.com/download)
- Banco de dados **Firebird** (acesso via rede)
- Acesso ao servidor `172.18.15.251` (banco `siapentest`)

## Estrutura do Projeto

```
src/
├── Siapen/                    # Projeto principal Avalonia
│   ├── Config/                # Configurações (dbxconnections.ini)
│   ├── Helpers/               # Funções utilitárias (Lib.pas convertido)
│   │   ├── GlobalVars.cs      # Variáveis globais do sistema
│   │   ├── LibHelper.cs       # Utilitários (CPF, CNPJ, datas, etc.)
│   │   └── AuthHelper.cs      # Autenticação e permissões
│   ├── Models/                # Modelos de dados
│   ├── Services/              # Serviços
│   │   └── DatabaseService.cs # Conexão Firebird
│   ├── ViewModels/            # ViewModels (MVVM)
│   │   ├── MainWindowViewModel.cs
│   │   └── LoginViewModel.cs
│   ├── Views/                 # Telas (AXAML)
│   │   ├── MainWindow.axaml   # Módulo principal (esqueleto)
│   │   ├── LoginWindow.axaml  # Tela de login
│   │   └── MessageBox.cs      # MessageBox customizado
│   ├── App.axaml              # Aplicação principal
│   └── Program.cs             # Ponto de entrada
├── Siapen.sln                 # Solução
└── AGENTS.md                  # Regras de conversão
```

## Como Executar

### 1. Compilar

```bash
cd src/Siapen
dotnet build
```

### 2. Executar

```bash
dotnet run
```

Ou diretamente:

```bash
dotnet run --project src/Siapen/Siapen.csproj
```

### 3. Executar a partir do binário

```bash
cd src/Siapen/bin/Debug/net10.0
./Siapen
```

> **Nota:** O arquivo `Config/dbxconnections.ini` é copiado automaticamente para o diretório de saída.

## Configuração do Banco de Dados

Edite `src/Siapen/Config/dbxconnections.ini`:

```ini
[SISAP]
Database=172.18.15.251:siapentest
User_Name=SYSDBA
Password=masterkey
SQLDialect=3
Charset=WIN1252
```

## Fluxo da Aplicação

1. **LoginWindow** — Tela inicial com login, senha e seleção de Unidade Penal
2. **MainWindow** — Módulo principal com menu e abas:
   - **Principal** — Botões: Confere, Agenda, Requerimentos, Ocorrências, Relatórios, Consulta, Histórico
   - **Setores** — Clínica Médica, Disciplina, Educação, Enfermagem, Farmácia, Jurídico, Odontologia, Pedagogia, Psicologia, Psicossocial, Psiquiatria, Saúde, Serviço Social, Terapia Ocupacional, Trabalho
   - **Procedimentos** — Agendar/Configurar procedimentos com filtros
   - **Escala de Plantão** — Controle de escala com data e equipe
   - **Caixa de Mensagem** — (placeholder)
   - **Identificação** — Dados do funcionário logado + logs de acesso

## Estado Atual

- [x] Estrutura do projeto Avalonia
- [x] Tela de Login (esqueleto)
- [x] Módulo Principal com todos os menus e botões (esqueleto)
- [x] Conexão Firebird
- [x] Leitura de configuração do dbxconnections.ini
- [x] Funções utilitárias (Lib.pas → LibHelper.cs)
- [x] Variáveis globais (GlobalVars.cs)
- [x] Autenticação (AuthHelper.cs)
- [ ] Telas de cadastro (aguardando DFM)
- [ ] Telas de setores (aguardando DFM)
- [ ] Telas de movimentação (aguardando DFM)
- [ ] Relatórios (aguardando DFM)

> **Todos os botões atualmente mostram "Não implementado".**
> As telas serão implementadas conforme os DFMs forem fornecidos.

## Extrair Tabelas do Banco

Para extrair o DDL de uma tabela específica:

```bash
python origin/extrairdatabase/extractor.py NOME_DA_TABELA
```

Para extrair todas as tabelas:

```bash
python origin/extrairdatabase/extractor.py
```

## Adicionar Novas Telas

1. Fornecer o arquivo DFM em `origin/dfm/`
2. Criar `Views/<Nome>View.axaml` + code-behind
3. Criar `ViewModels/<Nome>ViewModel.cs` (se necessário)
4. Conectar o botão correspondente no `MainWindowViewModel`
5. Se precisar de tabela do banco, usar `extractor.py`

## Logs

O sistema de log grava automaticamente em `Logs/siapen_YYYY-MM-DD.log`:

- **Debug** — informações detalhadas (queries SQL, bindings)
- **Info** — eventos normais (conexão, login)
- **Warning** — situações inesperadas
- **Error/Fatal** — erros com stack trace completo

```bash
# Ver log do dia
tail -f bin/Debug/net10.0/Logs/siapen_$(date +%Y-%m-%d).log
```

## Troubleshooting

| Problema | Solução |
|----------|---------|
| Erro de conexão Firebird | Verificar se o servidor está acessível (`nc -zv IP 3050`) |
| Erro no login | Verificar `Logs/siapen_*.log` para detalhes |
| `dbxconnections.ini` não encontrado | Verificar se está em `bin/Debug/net10.0/Config/` |
| Erro de compilação | `dotnet restore && dotnet build` |
| Tela não abre | Instalar Avalonia templates: `dotnet new install Avalonia.Templates` |
