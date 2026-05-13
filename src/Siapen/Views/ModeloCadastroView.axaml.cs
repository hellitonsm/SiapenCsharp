using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Siapen.Views;

public partial class ModeloCadastroView : Window
{
    public static readonly StyledProperty<object?> CadastroContentProperty =
        AvaloniaProperty.Register<ModeloCadastroView, object?>(nameof(CadastroContent));

    public object? CadastroContent
    {
        get => GetValue(CadastroContentProperty);
        set => SetValue(CadastroContentProperty, value);
    }

    public ModeloCadastroView()
    {
        InitializeComponent();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        var area = this.FindControl<ContentControl>("CadastroContentArea");
        if (area != null)
        {
            area.Bind(ContentControl.ContentProperty,
                this.GetBindingObservable(CadastroContentProperty));
        }
    }

    private void Fechar_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
