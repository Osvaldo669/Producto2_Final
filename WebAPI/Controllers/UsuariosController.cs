using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Contratos;
using DAL;
using Entities;
namespace WebAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly IUsuarios Users = new UsuariosAccesoDatos();

        [HttpPost]
        public async Task<dynamic> IniciarSesion([FromBody] Usuarios Credenciales)
        {
            var response =  await Users.Login(Credenciales.Usuario, Credenciales.Contrasena);
            if(response == null)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent
                };
            }
            return response;
        } 

    }
}
