using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class DomicilioNegocio
    {
        public void agregarDom(Domicilio nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.AGREGAR_DOMICILIO);
                datos.setearParametro("@idUser", nuevo.IdUsuario.Id);
                datos.setearParametro("@calle", nuevo.Calle);
                datos.setearParametro("@numero", nuevo.Numero);
                datos.setearParametro("@ciudad", nuevo.Ciudad);
                datos.setearParametro("@codpos", nuevo.CodPostal);              
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
