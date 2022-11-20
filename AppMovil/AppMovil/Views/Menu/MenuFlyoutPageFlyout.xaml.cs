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