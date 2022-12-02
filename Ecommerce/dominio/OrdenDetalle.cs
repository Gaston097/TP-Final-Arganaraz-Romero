using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class OrdenDetalle
    {
        public int ID { get; set; }
        public int IDOrden { get; set; }
        public int IDArticulo { get; set; }
        public ItemCarrito Detalles { get; set; }

    }
}
