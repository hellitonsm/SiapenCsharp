using Avalonia.Controls;
using Siapen.ViewModels;

namespace Siapen.Views;

public partial class ModeloFormularioView : Window
{
    public ModeloFormularioView()
    {
        InitializeComponent();
    }

    public ModeloFormularioView(ModeloFormularioViewModel viewModel) : this()
    {
        DataContext = viewModel;
    }
}
