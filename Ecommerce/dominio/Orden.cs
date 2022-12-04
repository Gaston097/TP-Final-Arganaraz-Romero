using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Orden
    {
        public int ID { get; set; }
        public int IDUser { get; set; }
        public int IDMetodoPago { get; set; }
        public int IDDomicilio { get; set; }
        public double Total { get; set; }
        public bool Envio { get; set; }
        public bool Pagado { get; set; }
        public bool Enviado { get; set; }
        public bool Recibido { get; set; }
        public List<OrdenDetalle> ItemsCarro { get; set; }

    }
}
