using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ViewModel
{
    public class InicioViewModel
    {

        private string _contraseña;

        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        private string _user;

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }


        HttpClient httpClient;
        public INavigation Navigation { get; set; }
        public Command Logueo { get; set; }
        public InicioViewModel(INavigation navigation)
        {
            Navigation = navigation;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue
                ("application/Json"));

            Logueo = new Command<Type>(async (obj)=> await Iniciar(obj)); 
        }

        public InicioViewModel()
        {

        }

        async Task Iniciar(Type Tpage)
        {
            const string URI = "http://20.92.255.155/Tiendita/api/Usuarios/IniciarSesion";
            try
            {

                
                var DatosInicio = JsonConvert.SerializeObject(new
                {
                    Usuario = _user,
                    Contrasena = _contraseña
                });
                var BodyEnviar = new StringContent(DatosInicio, Encoding.UTF8,"application/json");
                HttpResponseMessage responseMessage = await httpClient.PostAsync(URI, BodyEnviar);
                responseMessage.EnsureSuccessStatusCode();
                if (responseMessage.IsSuccessStatusCode)
                {
                    var page = (Page)Activator.CreateInstance(Tpage);
                    await Navigation.PushAsync(page);
                }
            }
            catch(Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error inesperado", "Salir");
            }
        }

        
    }
}
