using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    public interface IMedicamentos
    {
        Task<ObservableCollection<Medicamentos>> ObtenerMedicamentos();
        Task<ObservableCollection<Medicamentos>> ObtenerMedicamentosNombre(string Nombre);
        Task<ObservableCollection<Medicamentos>> ObtenerMedicamentoPresentacion(string Presentacion);
        Task<ObservableCollection<Medicamentos>> ObtenerMedicamentoCaducidad(string Inicio, string Fin );
        Task<bool> Venta(Venta Venta);
        Task<ObservableCollection<Venta2>> ObtenerVentas(string fecha);
    }
}
