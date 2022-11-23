using Contratos;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class MedicamentosController : ApiController
    {
        private readonly IMedicamentos Medi = new MedicamentosAccesoDatos();


        [HttpGet]
        public async Task<ObservableCollection<Medicamentos>> ObtenerMedicamentos()
        {
            var listMedicamento = await Medi.ObtenerMedicamentos();
            return listMedicamento;
        }

        [HttpGet]
        public async Task<ObservableCollection<Medicamentos>> ObtenerMedicamentosNombre(string id)
        {
            var response = await Medi.ObtenerMedicamentosNombre(id);

            return response;
        }

        [HttpGet]
        public async Task<ObservableCollection<Medicamentos>> ObtenerMedicamentosPresentacion(string id)
        {
            var response = await Medi.ObtenerMedicamentoPresentacion(id);
            return response;
        }

        [HttpGet]
        public async Task<ObservableCollection<Medicamentos>> ObtenerMedicamentosCaducidad(string id, string id2)
        {
            var response = await Medi.ObtenerMedicamentoCaducidad(id, id2);
            return response;
        }

        [HttpPost]
        public async Task<dynamic> Venta([FromBody] Venta Venta)
        {
            var response = await Medi.Venta(Venta);
            return response;
        }

        [HttpGet]
        public async Task<ObservableCollection<Venta2>> ObtenerVentas(string id)
        {
            ObservableCollection<Venta2> response = await Medi.ObtenerVentas(id);
            
            return response;
        }

    }
}
