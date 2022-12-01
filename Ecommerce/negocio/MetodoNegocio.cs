using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MetodoNegocio
    {
        
        public List<MetodoPago> listar()
        {
            List<MetodoPago> lista = new List<MetodoPago>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(Diccionario.LISTAR_MetodoPago);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    MetodoPago aux = new MetodoPago();
                    aux.ID = (int)datos.Lector["id"];
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
