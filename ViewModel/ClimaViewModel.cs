using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Maps;
using Entities;

namespace ViewModel
{
    public class ClimaViewModel : INotifyPropertyChanged
    {
        private ClimaData _data;

        public ClimaData Dataclima
        {
            get { return _data; }
            set { _data = value;
                OnPropertyChanged();
            }
        }

        private string coordenadas;

        public string Coordenadas
        {
            get { return coordenadas; }
            set { coordenadas = value;
                OnPropertyChanged();
            }
        }

        private Map mapa;

        public Map Mapa
        {
            get { return mapa; }
            set { mapa = value;
                OnPropertyChanged();
            }
        }

        private Video _videos;

        public Video Videos
        {
            get { return _videos; }
            set { _videos = value;
                OnPropertyChanged();
            }
        }



        HttpClient httpClient;
        public Command llamarClima { get; set; }
        public Command BuscarCiudad { get; set; }

        public ClimaViewModel()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue
                ("application/Json"));
            llamarClima = new Command(ObtenerClimaPuebla);
            BuscarCiudad = new Command(ObtenerClima);
        }

        async void ObtenerClimaPuebla()
        {
            const string apiKey = "397da9eab94a4a8f8eb211fecab1e67a"; //Cuenta OsvaldoGS
            
            const string URI = "https://api.weatherbit.io/v2.0/forecast/daily?";
            const string Uri2 = "https://www.googleapis.com/youtube/v3/search?part=snippet&q=";

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync(URI + "lat=19.03793&lon=-98.20346&days=3&lang=es&key="+apiKey);
                responseMessage.EnsureSuccessStatusCode();

                if (responseMessage.IsSuccessStatusCode)
                {
                    var data = await responseMessage.Content.ReadAsStringAsync();
                    Dataclima = JsonConvert.DeserializeObject<ClimaData>(data);
                    Mapa = new Map(new MapSpan(new Position(Convert.ToDouble(Dataclima.lat), Convert.ToDouble(Dataclima.lon)), 0.1, 0.1));
                    GetYoutube(Uri2 + Dataclima.city_name + "&key=AIzaSyCzIAMswzxwbk3-H3LUYB626EedcWG_lOo");
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Muestra", "Error al cargar los datos", "salir");
            }
        }
        async void ObtenerClima()
        {
            const string apiKey = "397da9eab94a4a8f8eb211fecab1e67a"; //Cuenta OsvaldoGS

            const string URI = "https://api.weatherbit.io/v2.0/forecast/daily?";
            const string Uri2 = "https://www.googleapis.com/youtube/v3/search?part=snippet&q=";


            try
            {
                List<string> datos = Coordenadas.Split(new char[] { ',' }).ToList();
                string latitud = datos[0].ToString();
                string longitud = datos[1].ToString();

                HttpResponseMessage responseMessage = await httpClient.GetAsync(URI + "lat="+latitud+"&lon="+longitud+"&days=3&lang=es&key=" + apiKey);
                responseMessage.EnsureSuccessStatusCode();

                if (responseMessage.IsSuccessStatusCode)
                {
                    var data = await responseMessage.Content.ReadAsStringAsync();
                    Dataclima = JsonConvert.DeserializeObject<ClimaData>(data);
                    Mapa = new Map(new MapSpan(new Position(Convert.ToDouble(Dataclima.lat), Convert.ToDouble(Dataclima.lon)), 0.1, 0.1));
                    GetYoutube(Uri2 + Dataclima.city_name + "&key=AIzaSyCzIAMswzxwbk3-H3LUYB626EedcWG_lOo");

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Muestra", "Error al cargar los datos", "salir");
            }
        }

        async void GetYoutube(string uri)
        {
            try
            {
               
                HttpResponseMessage responseMessage = await httpClient.GetAsync(uri);
                responseMessage.EnsureSuccessStatusCode();

                if (responseMessage.IsSuccessStatusCode)
                {
                    var data = await responseMessage.Content.ReadAsStringAsync();
                    Videos = JsonConvert.DeserializeObject<Video>(data);
                   
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Muestra", "Error al cargar los videos", "salir");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
