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
    public class FarmaciaviewModel : INotifyPropertyChanged
    {
        private Medicamentos _seleccion;

        public Medicamentos Seleccion
        {
            get { return _seleccion; }
            set
            {
                _seleccion = value;
                OnPropertyChanged();
            }
        }
        private Medicamentos _ventaMed;

        public Medicamentos VentaMed
        {
            get { return _ventaMed; }
            set
            {
                _ventaMed = value;
                OnPropertyChanged();
            }
        }



        private ObservableCollection<Medicamentos> _medicamentos;

        public ObservableCollection<Medicamentos> MedicamentosLista
        {
            get { return _medicamentos; }
            set { _medicamentos = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Medicamentos> _medicamento;

        public ObservableCollection<Medicamentos> Medicamento
        {
            get { return _medicamento; }
            set
            {
                _medicamento = value;
                OnPropertyChanged();
            }
        }

        private DateTime _fechaInicio;

        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value;
                OnPropertyChanged();
            }
        }


        private DateTime _fechafinal;

        public DateTime Fechafinal
        {
            get { return _fechafinal; }
            set { _fechafinal = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Medicamentos> _Presentacion;

        public ObservableCollection<Medicamentos> Presentacion
        {
            get { return _Presentacion; }
            set
            {
                _Presentacion = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Medicamentos> _caducidad;

        public ObservableCollection<Medicamentos> Caducidad
        {
            get { return _caducidad; }
            set
            {
                _caducidad = value;
                OnPropertyChanged();
            }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        private HttpClient Cliente;
        public Command ObtenerNombre { get; set; }
        public Command ObtenerPresentacion { get; set; }
        public Command ObtenerCaducidad { get; set; }
        public Command VentaCommand { get; set; }

        public FarmaciaviewModel()
        {
            
            Cliente = new HttpClient();
            Cliente.DefaultRequestHeaders.Accept.Clear();
            Cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue
                ("application/Json"));
            ObtenerNombre = new Command(() => ObtenerMedicamentosNombre());
            ObtenerPresentacion = new Command(() => ObtenerMedicamentosPresentacion());
            ObtenerCaducidad = new Command(() => ObtenerMedicamentosCaducidad());
            VentaCommand = new Command(() => VentaMedicamento());
            ObtenerMedicamentos();
        }


        private async void ObtenerMedicamentos()
        {
            string Contenido;
            string URI = " http://20.92.255.155/Tiendita/api/Medicamentos/ObtenerMedicamentos";
       

            try
            {
                HttpResponseMessage respuesta = await Cliente.GetAsync(URI);
                respuesta.EnsureSuccessStatusCode();

                if (respuesta.IsSuccessStatusCode)
                {
                    Contenido = await respuesta.Content.ReadAsStringAsync();
                    MedicamentosLista = JsonConvert.DeserializeObject<ObservableCollection<Medicamentos>>(Contenido);
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No hay medicamentos", "Salir");
            }
        }

        private async void ObtenerMedicamentosNombre()
        {
            string Contenido;
            string URI = " http://20.92.255.155/Tiendita/api/Medicamentos/ObtenerMedicamentosNombre/"+Nombre;


            try
            {
                HttpResponseMessage respuesta = await Cliente.GetAsync(URI);
                respuesta.EnsureSuccessStatusCode();

                if (respuesta.IsSuccessStatusCode)
                {
                    Contenido = await respuesta.Content.ReadAsStringAsync();
                    Medicamento = JsonConvert.DeserializeObject<ObservableCollection<Medicamentos>>(Contenido);
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No hay medicamentos", "Salir");
            }
        }

        

        private async void ObtenerMedicamentosPresentacion()
        {
            string Contenido;
            string URI = " http://20.92.255.155/Tiendita/api/Medicamentos/ObtenerMedicamentosPresentacion/" + Seleccion.Presentacion;


            try
            {
                HttpResponseMessage respuesta = await Cliente.GetAsync(URI);
                respuesta.EnsureSuccessStatusCode();

                if (respuesta.IsSuccessStatusCode)
                {
                    Contenido = await respuesta.Content.ReadAsStringAsync();
                    Presentacion = JsonConvert.DeserializeObject<ObservableCollection<Medicamentos>>(Contenido);
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No hay medicamentos", "Salir");
            }
        }

        private async void ObtenerMedicamentosCaducidad()
        {
            string Contenido;
            string date1 = FechaInicio.Year + "-" + FechaInicio.Month + "-" + FechaInicio.Day;
            string date2 = Fechafinal.Year + "-" + Fechafinal.Month + "-" + Fechafinal.Day;
            string URI = " http://20.92.255.155/Tiendita/api/Medicamentos/ObtenerMedicamentosCaducidad/" + date1+"/"+date2;


            try
            {
                HttpResponseMessage respuesta = await Cliente.GetAsync(URI);
                respuesta.EnsureSuccessStatusCode();

                if (respuesta.IsSuccessStatusCode)
                {
                    Contenido = await respuesta.Content.ReadAsStringAsync();
                    if(Contenido == null)
                    {
                         await Application.Current.MainPage.DisplayAlert("Error", "No hay medicamentos", "Salir");

                    }
                    Caducidad = JsonConvert.DeserializeObject<ObservableCollection<Medicamentos>>(Contenido);
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error con el servidor", "Salir");
            }
        }

        private async void VentaMedicamento()
        {
            string Contenido;
            
            string URI = " http://20.92.255.155/Tiendita/api/Medicamentos/Venta";
            if (VentaMed == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Seleccione un medicamento", "Salir");
                return;
            }

            try
            {
                Venta venta = new Venta()
                {
                    cantidad =1,
                    fecha_venta =DateTime.Today,
                    total_venta =(decimal)VentaMed.Precio,
                    producto_id = VentaMed.Producto_id

                };
                var ventaenviar = new StringContent(JsonConvert.SerializeObject(venta), Encoding.UTF8, "application/Json");
                HttpResponseMessage respuesta = await Cliente.PostAsync(URI,ventaenviar);
                respuesta.EnsureSuccessStatusCode();
                if (respuesta.IsSuccessStatusCode)
                {
                    VentaMed = null;
                    await Application.Current.MainPage.DisplayAlert("Error", "Venta Realizada con Exito", "Salir");

                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error con el servidor", "Salir");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
