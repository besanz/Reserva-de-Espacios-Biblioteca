using CommunityToolkit.Mvvm.ComponentModel;

namespace Reserva_de_Espacios_Biblioteca.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string titulo = "Reserva de Espacios - Biblioteca Municipal";
    }
}
