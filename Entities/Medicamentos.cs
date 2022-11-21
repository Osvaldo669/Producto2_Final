using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entities
{
    public class Medicamentos
    {
        public int Producto_id { get; set; }
        public string Nombre { get; set; }
        public string Presentacion { get; set; }
        public DateTime Fecha_cad { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
    }
}
