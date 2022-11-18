using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class EstadoComercialNegocio
    {

        public List<EstadoComercial> listar(string id = "")
        {
            List<EstadoComercial> lista = new List<EstadoComercial>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                if (id == "")
                {
                    datos.setearConsulta(Diccionario.LISTAR_ESTADO_COMERCIAL);
                }
                else
                {
                    datos.setearConsulta(Diccionario.LISTAR_ESTADO_COMERCIAL + "WHERE id = " + id);
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    EstadoComercial aux = new EstadoComercial();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Nombre = (String)datos.Lector["Nombre"];

                    lista.Add(aux);
                }
                return lista;
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
