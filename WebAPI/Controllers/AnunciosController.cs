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
    public class AnunciosController : ApiController
    {

        private readonly IAnuncios anuncios = new AnunciosAccesoDatos();
        [HttpGet]
        public async Task<ObservableCollection<Anuncios>> ObtenerAnuncios()
        {
            var anunc = await anuncios.ObtenerAnuncios();
            return anunc;
        }
    }
}
