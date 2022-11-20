using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int Id { get; set; }

        public int IdTipo { get; set; }

        public string Nombre { get; set; }

        public string eMail { get; set; }

        public string Contrasena { get; set; }

        public string Fecha { get; set; }

    }
}
