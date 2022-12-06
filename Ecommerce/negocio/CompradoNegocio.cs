using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CompradoNegocio
    {
        public List<Comprado> listar(string id = "")
        {
            List<Comprado> lista = new List<Comprado>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                    datos.setearConsulta(Diccionario.LISTAR_FACTURA + id);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Comprado aux = new Comprado();
                    aux.ID = (int)datos.Lector["id"];
                    aux.IdOrden = (int)datos.Lector["idOrden"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Cantidad =(int)datos.Lector["Cantidad"];
                    aux.Precio = (decimal)datos.Lector["Precio"];       
                    
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
