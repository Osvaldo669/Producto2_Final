using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ViewModel
{
    public class MonedaViewModel: INotifyPropertyChanged
    {
        private string urlApi = "https://api.exchangerate.host/";
        public Command CommandIntercambio { get; set; }
        HttpClient cliente;

        private Moneda Data;

        private string error;

        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        private string result;
        public string Result
        {
            get { return result; }
            set {result = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Pickers> monedas;
        public ObservableCollection<Pickers> Monedas
        {
            get { return monedas; }
            set
            {
                monedas = value;
                OnPropertyChanged();
            }
        }

        private int money;
        public int Money
        {
            get { return money; }
            set
            {
                money = value;
                OnPropertyChanged();
            }
        }

        private Pickers moneda1;
        public Pickers Moneda1
        {
            get { return moneda1; }
            set
            {
                moneda1 = value;
                OnPropertyChanged();
            }
        }

        private Pickers moneda2;
        public Pickers Moneda2
        {
            get { return moneda2; }
            set
            {
                moneda2 = value;
                OnPropertyChanged();
            }
        }

        public MonedaViewModel()
        {
            cliente =  new HttpClient();
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));
            CommandIntercambio = new Command(Intercambio);
            monedas = CrearMoneda();
        }

        ObservableCollection<Pickers> CrearMoneda()
        {
            var listaMoneda = new ObservableCollection<Pickers>
            {
                new Pickers{
                    Valor = "México",
                    Codigo = "MXN",
                },
                new Pickers
                {
                    Valor = "Estados Unidos",
                    Codigo = "USD",
                },
                new Pickers
                {
                    Valor = "Japón",
                    Codigo = "JPY",
                },
                new Pickers
                {
                    Valor = "Inglaterra",
                    Codigo = "GBP",
                },
                new Pickers
                {
                    Valor = "Italia",
                    Codigo = "EUR",
                },
                new Pickers
                {
                    Valor = "Nigeria",
                    Codigo = "NGN",
                },
                new Pickers
                {
                    Valor = "Mozambique",
                    Codigo = "MZN",
                }
            };
            return listaMoneda;
        }

        async Task<bool> Validador()
        {
            if (Money < 1)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Coloque una cantidad correcta", "Ok");
                return false;
            }

            if (moneda1 == null) { 
                await Application.Current.MainPage.DisplayAlert("Error", "Seleccione una moneda a intercambiar", "Ok");
                return false;
            }
            if(moneda2 == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Seleccione una moneda a cambiar", "Ok");
                return false;
            }
            return true;
        }

        async void Intercambio()
        {
            if (!await Validador())
            {
                return;
            }
            Result = "";
            string contenido;
            string url = urlApi + "convert?from="+ Moneda1.Codigo +"&to="+ Moneda2.Codigo + "&amount=" + Money;
            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                respuesta.EnsureSuccessStatusCode();
                if (respuesta.IsSuccessStatusCode)
                {
                    contenido = await respuesta.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<Moneda>(contenido);
                    Result = "Total: " + Data.result;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
