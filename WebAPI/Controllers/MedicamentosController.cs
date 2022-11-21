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
        public async Task<dynamic> ObtenerMedicamentosNombre(string id)
        {
            var response = await Medi.ObtenerMedicamentosNombre(id);

            if (response == null)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent
                };
            }
            return response;
        }

        [HttpGet]
        public async Task<dynamic> ObtenerMedicamentosPresentacion(string id)
        {
            var response = await Medi.ObtenerMedicamentoPresentacion(id);

            if (response == null)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent
                };
            }
            return response;
        }

        [HttpGet]
        public async Task<dynamic> ObtenerMedicamentosCaducidad(string id, string id2)
        {
            var response = await Medi.ObtenerMedicamentoCaducidad(id, id2);

            if (response == null)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent
                };
            }
            return response;
        }
        [HttpPost]
        public async Task<dynamic> Venta([FromBody] Venta Venta)
        {
            var response = await Medi.Venta(Venta);
            return response;
        }
    }
}
