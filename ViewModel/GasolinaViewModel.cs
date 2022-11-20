using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Entities;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class GasolinaViewModel: INotifyPropertyChanged
    {
        private string urlApi = "https://petrointelligence.com/api/";
        public Command CommandGasolina { get; set; }


        private string _sorce;
        public string Sorce
        {
            get { return _sorce; }
            set { _sorce = value;
                OnPropertyChanged();
            }
        }

        private string _imagen;
        public string Imagen
        {
            get { return _imagen; }
            set
            {
                _imagen = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Pickers> _estados;
        public ObservableCollection<Pickers> Estados
        {
            get { return _estados; }
            set
            {
                _estados = value;
                OnPropertyChanged();
            }
        }

        private Pickers _estado;
        public Pickers Estado
        {
            get { return _estado; }
            set
            {
                _estado = value;
                OnPropertyChanged();
            }
        }

        private int _estadoIndex;
        public int EstadoIndex
        {
            get { return _estadoIndex; }
            set
            {
                _estadoIndex = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Pickers> _gasolinas;
        public ObservableCollection<Pickers> Gasolinas
        {
            get { return _gasolinas; }
            set
            {
                _gasolinas = value;
                OnPropertyChanged();
            }
        }

        private Pickers _gasolina;
        public Pickers Gasolina
        {
            get { return _gasolina; }
            set
            {
                _gasolina = value;
                OnPropertyChanged();
            }
        }

        private int _gasolinaIndex;
        public int GasolinaIndex
        {
            get { return _gasolinaIndex; }
            set
            {
                _gasolinaIndex = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Pickers> LLenaEstados()
        {
            var listaEstados = new ObservableCollection<Pickers>
            {
                new Pickers
                {
                    Codigo = "PUE",
                    Valor = "Puebla",
                    Imagen = "https://media.istockphoto.com/id/1128095909/es/foto/fuente-hist%C3%B3rica-puebla.jpg?s=612x612&w=0&k=20&c=Ql0wQCPqNW3Xzkc7Krw9gRspO3KeNKeFFOthMMgqgWg="
                },
                new Pickers
                {
                    Codigo = "TLAX",
                    Valor = "Tlaxcala",
                    Imagen = "https://i0.wp.com/www.turimexico.com/wp-content/uploads/2015/05/tlaxcala.jpg?fit=500%2C375&ssl=1"
                },
                new Pickers 
                {
                    Codigo = "NL",
                    Valor = "Nuevo León",
                    Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcStBV6M90HLL-VXkBFN6YNh6t8WcPDr6LQo9ia408y2&s"
                },
                new Pickers
                {
                    Codigo = "SIN",
                    Valor = "Sinaloa",
                    Imagen = "https://topadventure.com/__export/1625502680202/sites/laverdad/img/2021/07/05/sinaloa_portada.jpg_1103261913.jpg"
                },
                new Pickers
                {
                    Codigo = "MEX",
                    Valor = "Estado de México",
                    Imagen = "https://www.mexicodesconocido.com.mx/wp-content/uploads/2010/05/ciudad-de-mexico-angel-independencia-depositphotos-900x600.jpg"
                },
                new Pickers
                {
                    Codigo = "QRO",
                    Valor = "Querétaro",
                    Imagen = "https://amqueretaro.com/wp-content/uploads/2022/09/quereok.jpg"
                },
                new Pickers
                {
                    Codigo = "VER",
                    Valor = "Veracruz",
                    Imagen = "https://viajerosocultos.com/wp-content/uploads/2021/12/6169756721_0904d2e8ab_o.jpg"
                },
                new Pickers
                {
                    Codigo = "AGS",
                    Valor = "Aguascalientes",
                    Imagen = "https://a.travel-assets.com/findyours-php/viewfinder/images/res70/200000/200533-Aguascalientes.jpg"
                },
                new Pickers
                {
                    Codigo = "COL",
                    Valor = "Colima",
                    Imagen = "https://i1.wp.com/www.conocemanzanillo.com/wp-content/uploads/2020/06/Colima-Manzanillo.jpg?fit=925%2C540&ssl=1"
                },
                new Pickers
                {
                    Codigo = "HGO",
                    Valor = "Hidalgo",
                    Imagen = "https://upload.wikimedia.org/wikipedia/commons/d/d5/Reloj_Monumental%2C_Pachuca%2C_Hidalgo%2C_M%C3%A9xico%2C_2013-10-10%2C_DD_06.JPG"
                }
            };
            return listaEstados;
        }


        ObservableCollection<Pickers> LLenaGasolinas()
        {
            var listagasolinas = new ObservableCollection<Pickers>
            {
                new Pickers
                {
                    Codigo = "REG",
                    Valor = "Regular",
                },
                new Pickers
                {
                    Codigo = "PRE",
                    Valor = "Premium",
                },
                new Pickers
                {
                    Codigo = "DIE",
                    Valor = "Diésel",
                }
            };
            return listagasolinas;
        }


        public GasolinaViewModel()
        {
            CommandGasolina = new Command(Metodo_Gasolina);
            Estados =  LLenaEstados();
            Gasolinas = LLenaGasolinas();
        }

        async Task<bool> validador()
        {
            if (EstadoIndex == -1)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Seleccione un Estado", "Ok");
                return false ;
            }

            if (GasolinaIndex == -1)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Seleccione un Tipo", "Ok");
                return false;
            }
            return true;
        }

        async void Metodo_Gasolina()
        {
            if (await validador())
            {
                Sorce = urlApi + "api_precios.html?consulta=estado&estado="+Estado.Codigo+"&tipo="+ Gasolina.Codigo;
                Imagen = Estado.Imagen;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
