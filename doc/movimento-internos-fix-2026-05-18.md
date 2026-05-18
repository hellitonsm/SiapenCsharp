# Correção MovimentoInternos - 2026-05-18

## Problemas Identificados

### 1. Dados não apareciam no grid
- Query SQL demorava ~26 segundos sem timeout definido (padrão 30s do Firebird)
- Sem `CommandTimeout`, a query travava e o `ConsultaDataSource` nunca era preenchido
- O `OnSearchTextChanged` era chamado com `ConsultaDataSource=-1` (null/vazio)

### 2. Campos não eram preenchidos ao selecionar registro
- `OnConsultaSelectedRowChanged` não chamava `PreencherCampos()`
- O usuário clicava no grid e os campos permaneciam vazios

### 3. Sem suporte a double-click
- Não havia navegação ao dar duplo clique no grid

## Correções Aplicadas

### DatabaseService.cs — CommandTimeout
- Adicionado `cmd.CommandTimeout = 10` em `ExecuteQuery`, `ExecuteNonQuery`, `ExecuteScalar` e `ExecuteFunction`
- Evita travamento indefinido em queries lentas

### ModeloMovimentacaoViewModel.cs — PreencherCampos na seleção
- Adicionado `PreencherCampos()` no `OnConsultaSelectedRowChanged`
- Agora ao clicar em uma linha do grid, os dados aparecem nos campos automaticamente em modo leitura

### MovimentoInternosViewModel.cs — Query otimizada
- Removido `LEFT JOIN galeria g` desnecessário (coluna não era usada no SELECT)
- Adicionado filtro `AND i.nome_interno IS NOT NULL` (comportamento original do Delphi)

### MovimentoInternosView — Double-click
- Adicionado evento `DoubleTapped="DataGrid_DoubleTapped"` no DataGrid
- Handler no code-behind troca para a aba de Cadastro ao dar duplo clique
- Campos são preenchidos em modo leitura (desativados), só ativam ao clicar em "Editar"

## Comportamento Esperado
1. Usuário abre MovimentoInternos → dados carregam no grid
2. Usuário clica em uma linha → campos são preenchidos em modo leitura
3. Usuário dá duplo clique → vai para aba de Cadastro com campos preenchidos (leitura)
4. Usuário clica "Editar" → campos são habilitados para edição
