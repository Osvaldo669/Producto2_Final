using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioSesion : ContentPage
    {
        public InicioSesion()
        {
            InitializeComponent();
            BindingContext = new InicioViewModel(Navigation);
        }
    }
}