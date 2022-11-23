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
    public class HistorialViewModel : INotifyPropertyChanged
    {
        private DateTime _fecha;
        public DateTime Fecha
        {
            get { return _fecha; }
            set
            {
                _fecha = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<HistorialVentas> _ventas;

        public ObservableCollection<HistorialVentas> Ventas
        {
            get { return _ventas; }
            set { _ventas = value; 
                OnPropertyChanged();
            }
        }


        public Command BusquedaCommand { get; set; }
        HttpClient httpClient;
        public HistorialViewModel()
        {
            Fecha = DateTime.Now;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue
                ("application/Json"));
            BusquedaCommand = new Command(() => ObtenerHistorial());
        }


        private async void ObtenerHistorial()
        {
            string Contenido;
            string URI = "http://20.92.255.155/Tiendita/api/Medicamentos/ObtenerVentas/"+Fecha.Year+"-"+Fecha.Month+"-"+Fecha.Day;


            try
            {
                HttpResponseMessage respuesta = await httpClient.GetAsync(URI);
                respuesta.EnsureSuccessStatusCode();

                if (respuesta.IsSuccessStatusCode)
                {
                    Contenido = await respuesta.Content.ReadAsStringAsync();
                    Ventas = JsonConvert.DeserializeObject<ObservableCollection<HistorialVentas>>(Contenido);
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
