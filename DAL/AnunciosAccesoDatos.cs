using Contratos;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class AnunciosAccesoDatos : IAnuncios
    {

        readonly string Cadena;
        SqlConnection Conn;

        public AnunciosAccesoDatos()
        {
            Cadena = ConfigurationManager.ConnectionStrings["SQl"].ConnectionString;
        }

        public async Task<ObservableCollection<AnucioRecibo>> ObtenerAnuncios()
        {
            ObservableCollection<AnucioRecibo> anuncios = null;

            using (Conn = new SqlConnection(Cadena))
            {
                try
                {
                    using (var command = Conn.CreateCommand())
                    {
                        command.CommandText = "ObtenerAnuncios";
                        command.CommandType = CommandType.StoredProcedure;
                        await Conn.OpenAsync();
                        using (SqlDataReader render = await command.ExecuteReaderAsync())
                        {
                            if (render.HasRows)
                            {
                                anuncios = new ObservableCollection<AnucioRecibo>();
                                while (render.Read())
                                {
                                    anuncios.Add(new AnucioRecibo
                                    {
                                        Anuncio_id = Convert.ToInt32(render["anuncio_id"]),
                                        Descripcion = render["descripcion"].ToString(),
                                        Imagen = render["imagen"].ToString(),
                                        Titulo = render["titulo"].ToString()
                                    });
                                   
                                }
                                Conn.Close();
                            }
                        }
                    };
                }
                catch (Exception)
                {
                    Conn.Close();
                }
            }
            return anuncios;
        }
    }
}
