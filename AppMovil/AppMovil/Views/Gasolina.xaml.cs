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
    public partial class Gasolina : ContentPage
    {
        public Gasolina()
        {
            InitializeComponent();
            BindingContext = new GasolinaViewModel();
        }
    }
}