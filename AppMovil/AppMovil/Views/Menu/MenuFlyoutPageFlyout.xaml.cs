using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovil.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuFlyoutPageFlyout : ContentPage
    {
        public ListView ListView;

        public MenuFlyoutPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuFlyoutPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MenuFlyoutPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuFlyoutPageFlyoutMenuItem> MenuItems { get; set; }

            public MenuFlyoutPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MenuFlyoutPageFlyoutMenuItem>(new[]
                {

                    new MenuFlyoutPageFlyoutMenuItem { Id = 0, Title = "Gasolina", TargetType = typeof(Gasolina) },
                    new MenuFlyoutPageFlyoutMenuItem { Id = 1, Title = "Moneda", TargetType = typeof(Moneda) },
                    new MenuFlyoutPageFlyoutMenuItem { Id = 2, Title = "Clima", TargetType=typeof(Clima) },
                    new MenuFlyoutPageFlyoutMenuItem { Id = 3, Title = "Medicamentos Lista", TargetType=typeof(Farmacia) },
                    new MenuFlyoutPageFlyoutMenuItem { Id = 4, Title = "Medicamentos Nombre", TargetType=typeof(MedicamentoNombre) },
                    new MenuFlyoutPageFlyoutMenuItem { Id = 5, Title = "Medicamentos Presentacion", TargetType=typeof(MedicamentosPresentacion) },
                    new MenuFlyoutPageFlyoutMenuItem { Id = 6, Title = "Medicamentos Caducidad", TargetType=typeof(MedicamentosCaducidad) },
                    new MenuFlyoutPageFlyoutMenuItem { Id = 7, Title = "Venta Medicamento", TargetType=typeof(VentaMedicamentos) },
                    new MenuFlyoutPageFlyoutMenuItem { Id = 8, Title = "Historial", TargetType=typeof(Historial) },
                    new MenuFlyoutPageFlyoutMenuItem { Id = 9, Title = "Publicidad", TargetType=typeof(Publicidad) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}