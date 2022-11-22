using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ViewModel
{
    public class PublicidadViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<AnucioRecibo> _anuncios;

        public ObservableCollection<AnucioRecibo> Anuncios
        {
            get { return _anuncios; }
            set
            {
                _anuncios = value;
                OnPropertyChanged();
            }
        }
        HttpClient httpClient;
        public PublicidadViewModel()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue
                ("application/Json"));
            ObtenerHistorial();
        }

        private async void ObtenerHistorial()
        {
            string Contenido;
            string URI = "http://20.92.255.155/Tiendita/api/Anuncios/ObtenerAnuncios";


            try
            {
                HttpResponseMessage respuesta = await httpClient.GetAsync(URI);
                respuesta.EnsureSuccessStatusCode();

                if (respuesta.IsSuccessStatusCode)
                {
                    Contenido = await respuesta.Content.ReadAsStringAsync();
                    Anuncios = JsonConvert.DeserializeObject<ObservableCollection<AnucioRecibo>>(Contenido);
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No hay medicamentos", "Salir");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
