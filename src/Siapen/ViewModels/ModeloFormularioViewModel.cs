using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Siapen.ViewModels;

public partial class ModeloFormularioViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _titulo = "SIAPEN - Formulário Auxiliar";

    [ObservableProperty]
    private string _subTitulo = string.Empty;

    [ObservableProperty]
    private bool _isLoading;

    [RelayCommand]
    protected virtual void Confirmar()
    {
    }

    [RelayCommand]
    protected virtual void Cancelar()
    {
    }
}
