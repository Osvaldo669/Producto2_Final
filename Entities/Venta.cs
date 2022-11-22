using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Venta
    {
        public int venta_id { get; set; }
        public int cantidad { get; set; }
        public decimal total_venta { get; set; }
        public DateTime fecha_venta { get; set; }
        public int producto_id { get; set; }

    }

    public class Venta2
    {
        public int venta_id { get; set; }
        public int cantidad { get; set; }
        public decimal total_venta { get; set; }
        public DateTime fecha_venta { get; set; }
        public Medicamentos producto { get; set; }

    }
}
