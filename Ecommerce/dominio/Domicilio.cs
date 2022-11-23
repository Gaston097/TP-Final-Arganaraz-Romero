using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Domicilio
    {
        public int Id { get; set; }

        public Usuario IdUsuario { get; set; }

        public string Calle { get; set; }

        public string Numero { get; set; }

        public string Ciudad { get; set; }

        public string CodPostal { get; set; }

    }
}
