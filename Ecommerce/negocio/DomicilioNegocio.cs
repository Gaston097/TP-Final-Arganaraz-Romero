using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class DomicilioNegocio
    {
       /* public void agregar(Domicilio nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.AGREGAR_DOMICILIO); //AGREGAR DICCIONARIO
           
                datos.setearParametro("@IdUsuario", nuevo.Usuario.ID);
                datos.setearParametro("@Calle", nuevo.Calle);
                datos.setearParametro("@Numero", nuevo.Numero);
                datos.setearParametro("@Ciudad", nuevo.Ciudad);
                datos.setearParametro("@CodPostal", nuevo.CodPostal);
              
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
       */
    }
}
