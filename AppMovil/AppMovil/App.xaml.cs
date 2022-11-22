using AppMovil.Views;
using AppMovil.Views.Menu;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InicioSesion());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
