using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Siapen.Views;

public partial class MovimentoInternosView : Window
{
    public MovimentoInternosView()
    {
        InitializeComponent();
    }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        if (DataContext is ViewModels.MovimentoInternosViewModel vm)
        {
            _ = vm.LoadAsync();
        }
    }

    private void Fechar_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
