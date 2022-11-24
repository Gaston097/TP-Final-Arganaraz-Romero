using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class OrdenNegocio
    {
        public List<Orden> listar(string id = "")
        {
            List<Orden> lista = new List<Orden>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                if (id == "")
                {
                    datos.setearConsulta(Diccionario.LISTAR_ORDENES);
                }
                else
                {
                    datos.setearConsulta(Diccionario.LISTAR_ORDENES + "WHERE id = " + id);
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Orden aux = new Orden();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.IDUser = (int)datos.Lector["IdUser"];
                    aux.IDMetodoPago = (int)datos.Lector["IdMetodoPago"];
                    aux.IDDomicilio = (int)datos.Lector["IdDomicilio"];
                    aux.Total = (float)datos.Lector["IdUser"];
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
