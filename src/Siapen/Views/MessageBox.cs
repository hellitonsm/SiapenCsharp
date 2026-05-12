using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace Siapen.Views;

/// <summary>
/// MessageBox simples para substituir MessageBox.Show do WinForms
/// </summary>
public class MessageBox : Window
{
    public MessageBox(string title, string message)
    {
        Title = title;
        Width = 400;
        Height = 180;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        CanResize = false;
        Background = new SolidColorBrush(Color.Parse("#F0F0F0"));

        var textBlock = new TextBlock
        {
            Text = message,
            TextWrapping = TextWrapping.Wrap,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Margin = new Avalonia.Thickness(20),
            FontSize = 14
        };

        var button = new Button
        {
            Content = "OK",
            Width = 80,
            Height = 30,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center
        };
        button.Click += (_, _) => Close();

        var panel = new StackPanel
        {
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        panel.Children.Add(textBlock);
        panel.Children.Add(button);

        Content = panel;
    }

    public new void Show()
    {
        ShowDialog(null!);
    }
}
