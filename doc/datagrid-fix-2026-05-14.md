# DataGrid Fix — Migração de DataViewSource para GridItems

**Data**: 2026-05-14
**Commit**: `2cc95fa` — "fix: use GridItems (typed objects) instead of DataView for DataGrid"
**Escopo**: CadastroPavilhao, CadastroGaleria, CadastroSolario, CadastroCela

---

## Problema

Após o commit `c65f2ef` (módulo Confere completo), os DataGrids dos cadastros existentes pararam de exibir dados corretamente:

- **CadastroPavilhao**: Grid aparecia com bugs (dados não renderizavam)
- **CadastroCela**: Grid não mostrava dados

### Causa Raiz

O `CadastroPavilhaoView.axaml` usava binding direto com `DataViewSource`:

```xml
<DataGrid ItemsSource="{Binding DataViewSource}"
          AutoGenerateColumns="True" />
```

O controle `DataGrid` do Avalonia **não renderiza corretamente** quando ligado a um `DataView` sem o tema Fluent aplicado. O `DataView` é um objeto do `System.Data` que o Avalonia não sabe exibir nativamente sem um conversor ou template.

O `CadastroCelaView.axaml` já usava `GridItems` com colunas manuais, mas o `ModeloCadastroViewModel` base não expunha essa propriedade adequadamente.

---

## Solução

### 1. ModeloCadastroViewModel — Nova propriedade `GridItems`

Adicionou-se uma propriedade `GridItems` (IList) que converte `DataRowView` em objetos tipados:

```csharp
private IList? _gridItems;
public IList? GridItems
{
    get => _gridItems;
    private set => _gridItems = value;
}
```

O método `LoadAsync()` agora popula `GridItems`:

```csharp
GridItems = DataSource.Cast<DataRowView>()
    .Select(r => CreateGridItem(r.Row)).ToList();
OnPropertyChanged(nameof(GridItems));
```

### 2. Sincronização SelectedGridItem ↔ SelectedRow

Para manter a compatibilidade com `PreencherCampos()` (que usa `SelectedRow`/`DataRowView`):

```csharp
public object? SelectedGridItem
{
    get => _selectedGridItem;
    set
    {
        if (SetProperty(ref _selectedGridItem, value) && value != null
            && DataSource != null && GridItems != null)
        {
            int idx = GridItems.IndexOf(value);
            if (idx >= 0 && idx < DataSource.Count)
                SelectedRow = DataSource[idx];
        }
    }
}
```

### 3. Views — Migração para GridItems

**Antes** (CadastroPavilhaoView.axaml):
```xml
<DataGrid ItemsSource="{Binding DataViewSource}"
          SelectedItem="{Binding SelectedRow}"
          AutoGenerateColumns="True" />
```

**Depois**:
```xml
<DataGrid ItemsSource="{Binding GridItems}"
          SelectedItem="{Binding SelectedGridItem}"
          AutoGenerateColumns="True" />
```

### 4. Code-behind — Seleção manual

O `CadastroPavilhaoView.axaml.cs` recebeu um handler para garantir sincronização:

```csharp
private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
{
    if (DataContext is CadastroPavilhaoViewModel vm)
    {
        vm.SelectedGridItem = dataGrid.SelectedItem;
    }
}
```

---

## Modelos GridItem

Cada cadastro tem seu model tipado para exibição no grid:

| ViewModel | GridItem | Arquivo |
|-----------|----------|---------|
| CadastroPavilhao | `PavilhaoGridItem` | `Models/PavilhaoGridItem.cs` |
| CadastroGaleria | `GaleriaGridItem` | `Models/GaleriaGridItem.cs` |
| CadastroSolario | `SolarioGridItem` | `Models/SolarioGridItem.cs` |
| CadastroCela | `CelaGridItem` | `Models/CelaGridItem.cs` |

Exemplo (`PavilhaoGridItem`):
```csharp
public class PavilhaoGridItem
{
    public int IdPavilhao { get; set; }
    public string Pavilhao { get; set; } = "";
    public int IdUp { get; set; }
}
```

---

## Padrão Recomendado

Para novos cadastros, seguir este padrão:

1. **Criar GridItem model** em `Models/<Nome>GridItem.cs` com propriedades simples
2. **Implementar `CreateGridItem(DataRow)`** no ViewModel
3. **Usar `ItemsSource="{Binding GridItems}"`** no XAML
4. **Usar `SelectedItem="{Binding SelectedGridItem}"`** para seleção
5. **Usar `AutoGenerateColumns="True"`** ou definir colunas manualmente

---

## Arquivos Alterados

| Arquivo | Alteração |
|---------|-----------|
| `ViewModels/ModeloCadastroViewModel.cs` | +29 linhas: GridItems, SelectedGridItem, sincronização |
| `Views/CadastroPavilhaoView.axaml` | -4/+3: ItemsSource e SelectedItem |
| `Views/CadastroPavilhaoView.axaml.cs` | +14: SelectionChanged handler |

---

## Build Status

```
0 Erros
4 Warnings (Watermark obsoleto, nullable reference)
Tempo: ~10s
```
