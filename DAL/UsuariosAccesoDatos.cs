using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Contratos;
using Entities;

namespace DAL
{
    public class UsuariosAccesoDatos : IUsuarios
    {
        readonly string Cadena;
        SqlConnection Conn;

        public UsuariosAccesoDatos()
        {
            Cadena = ConfigurationManager.ConnectionStrings["SQl"].ConnectionString;
        }


        public async Task<Usuarios> Login(string usuarios, string contrasena)
        {
            Usuarios user = null;

            using (Conn = new SqlConnection(Cadena))
            {
                try
                {
                    using (var command = Conn.CreateCommand())
                    {
                        command.CommandText = "Login";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@usuario", usuarios);
                        command.Parameters.AddWithValue("@contrasena", contrasena);
                        await Conn.OpenAsync();
                        using (SqlDataReader render = await command.ExecuteReaderAsync())
                        {
                            if (render.HasRows)
                            {
                                while (render.Read())
                                {
                                    user = new Usuarios
                                    {
                                        Estado = Convert.ToBoolean(render["estado"]),
                                        Usuario = render["usuario"].ToString()
                                    };
                                }
                                Conn.Close();
                            }
                            else
                            {
                                return null;
                            }
                        }
                    };
                }
                catch (Exception)
                {
                    Conn.Close();
                }
            }
            return user;
        }


    }
}
