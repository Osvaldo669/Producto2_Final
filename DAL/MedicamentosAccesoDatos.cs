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

namespace DAL
{
    public class MedicamentosAccesoDatos : IMedicamentos
    {

        readonly string Cadena;
        SqlConnection Conn;

        public MedicamentosAccesoDatos()
        {
            Cadena = ConfigurationManager.ConnectionStrings["SQl"].ConnectionString;
        }

        public async Task<ObservableCollection<Medicamentos>> ObtenerMedicamentoCaducidad(string Inicio, string Fin)
        {
            ObservableCollection<Medicamentos> medicamentos = null;

            using (Conn = new SqlConnection(Cadena))
            {
                try
                {
                    using (var command = Conn.CreateCommand())
                    {
                        command.CommandText = "ObtenerMedicamentoFecha";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@inicio", Inicio);
                        command.Parameters.AddWithValue("@fin", Fin);

                        await Conn.OpenAsync();
                        using (SqlDataReader render = await command.ExecuteReaderAsync())
                        {
                            if (render.HasRows)
                            {
                                medicamentos = new ObservableCollection<Medicamentos>();
                                while (render.Read())
                                {
                                    medicamentos.Add(new Medicamentos
                                    {
                                        Nombre = render["nombre"].ToString(),
                                        Fecha_cad = Convert.ToDateTime(render["fecha_cad"]),
                                        Imagen = render["imagen"].ToString(),
                                        Precio = Convert.ToDouble(render["precio"]),
                                        Presentacion = render["presentacion"].ToString(),
                                        Producto_id = Convert.ToInt32(render["producto_id"])
                                    });
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
                return medicamentos;
            }
        }

        public async Task<ObservableCollection<Medicamentos>> ObtenerMedicamentoPresentacion(string Presentacion)
        {
            ObservableCollection<Medicamentos> medicamentos = null;

            using (Conn = new SqlConnection(Cadena))
            {
                try
                {
                    using (var command = Conn.CreateCommand())
                    {
                        command.CommandText = "ObtenerMedicamentoPresentacion";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@presentacion", Presentacion);
                        await Conn.OpenAsync();
                        using (SqlDataReader render = await command.ExecuteReaderAsync())
                        {
                            if (render.HasRows)
                            {
                                medicamentos = new ObservableCollection<Medicamentos>();
                                while (render.Read())
                                {
                                    medicamentos.Add(new Medicamentos
                                    {
                                        Nombre = render["nombre"].ToString(),
                                        Fecha_cad = Convert.ToDateTime(render["fecha_cad"]),
                                        Imagen = render["imagen"].ToString(),
                                        Precio = Convert.ToDouble(render["precio"]),
                                        Presentacion = render["presentacion"].ToString(),
                                        Producto_id = Convert.ToInt32(render["producto_id"])
                                    });
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
                return medicamentos;
            }
        }

        public async  Task<ObservableCollection<Medicamentos>> ObtenerMedicamentos()
        {
            ObservableCollection<Medicamentos> medicamentos = null;

            using (Conn = new SqlConnection(Cadena))
            {
                try
                {
                    using (var command = Conn.CreateCommand())
                    {
                        command.CommandText = "ObtenerMedicamentos";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        await Conn.OpenAsync();
                        using (SqlDataReader render = await command.ExecuteReaderAsync())
                        {
                            if (render.HasRows)
                            {
                                medicamentos = new ObservableCollection<Medicamentos>();
                                while (render.Read())
                                {
                                    medicamentos.Add(new Medicamentos { 
                                       Nombre = render["nombre"].ToString(),
                                       Fecha_cad = Convert.ToDateTime(render["fecha_cad"]),
                                       Imagen = render["imagen"].ToString(),
                                       Precio = Convert.ToDouble(render["precio"]),
                                       Presentacion = render["presentacion"].ToString(),
                                       Producto_id = Convert.ToInt32(render["producto_id"])
                                    });
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
            return medicamentos;
        }

        public async Task<ObservableCollection<Medicamentos>> ObtenerMedicamentosNombre(string Nombre)
        {
            ObservableCollection<Medicamentos> medicamentos = null;

            using (Conn = new SqlConnection(Cadena))
            {
                try
                {
                    using (var command = Conn.CreateCommand())
                    {
                        command.CommandText = "ObtenerMedicamentosNombre";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@nombre", Nombre);
                        await Conn.OpenAsync();
                        using (SqlDataReader render = await command.ExecuteReaderAsync())
                        {
                            if (render.HasRows)
                            {
                                medicamentos = new ObservableCollection<Medicamentos>();
                                while (render.Read())
                                {
                                    medicamentos.Add(new Medicamentos
                                    {
                                        Nombre = render["nombre"].ToString(),
                                        Fecha_cad = Convert.ToDateTime(render["fecha_cad"]),
                                        Imagen = render["imagen"].ToString(),
                                        Precio = Convert.ToDouble(render["precio"]),
                                        Presentacion = render["presentacion"].ToString(),
                                        Producto_id = Convert.ToInt32(render["producto_id"])
                                    });
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
                return medicamentos;
            }
        }

        public async Task<ObservableCollection<Venta2>> ObtenerVentas(string fecha)
        {
            ObservableCollection<Venta2> ventas = null;

            using (Conn = new SqlConnection(Cadena))
            {
                try
                {
                    using (var command = Conn.CreateCommand())
                    {
                        command.CommandText = "ObtenerVenta";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@fecha", fecha);
                        await Conn.OpenAsync();
                        using (SqlDataReader render = await command.ExecuteReaderAsync())
                        {
                            if (render.HasRows)
                            {
                                ventas = new ObservableCollection<Venta2>();
                                while (render.Read())
                                {
                                    ventas.Add(new Venta2
                                    {
                                        venta_id = Convert.ToInt32(render["venta_id"]),
                                        cantidad = Convert.ToInt32(render["cantidad"]),
                                        fecha_venta = Convert.ToDateTime(render["fecha_venta"]),
                                        producto = new Medicamentos
                                        {
                                            Nombre = render["nombre"].ToString(),
                                            Fecha_cad = Convert.ToDateTime(render["fecha_cad"]),
                                            Imagen = render["imagen"].ToString(),
                                            Precio = Convert.ToDouble(render["precio"]),
                                            Presentacion = render["presentacion"].ToString(),
                                            Producto_id = Convert.ToInt32(render["producto_id"])
                                        },
                                        total_venta = Convert.ToDecimal(render["total_venta"])
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
                return ventas;
            }
        }

        public async Task<bool> Venta(Venta Venta)
        {
            bool bandera = false;

            using (Conn = new SqlConnection(Cadena))
            {
                try
                {
                    using (var command = Conn.CreateCommand())
                    {
                        command.CommandText = "CrearVenta";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@cantidad", Venta.cantidad);
                        command.Parameters.AddWithValue("@total_venta", Venta.total_venta);
                        command.Parameters.AddWithValue("@fecha_venta", Venta.fecha_venta);
                        command.Parameters.AddWithValue("@producto_id", Venta.producto_id);

                        await Conn.OpenAsync();
                        int count = await command.ExecuteNonQueryAsync();
                        if (count > 0)
                        {
                            bandera = true;
                        }

                        Conn.Close();
                    };
                }
                catch (Exception)
                {
                    Conn.Close();
                }
                return bandera;
            }
        }
    }
}



