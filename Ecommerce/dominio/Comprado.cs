using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Comprado
    {
        public int ID { get; set; }

        public int IdOrden { get; set; }

        public string Nombre { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

    }
}
