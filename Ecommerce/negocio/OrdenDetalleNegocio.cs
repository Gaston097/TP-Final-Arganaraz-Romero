using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class OrdenDetalleNegocio
    {

        public List<OrdenDetalle> listar(string id = "")
        {
            List<OrdenDetalle> lista = new List<OrdenDetalle>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                if (id == "")
                {
                    datos.setearConsulta(Diccionario.LISTAR_ORDENES_DETALLE);
                }
                else
                {
                    datos.setearConsulta(Diccionario.LISTAR_ORDENES_DETALLE + "WHERE id = " + id);
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    OrdenDetalle aux = new OrdenDetalle();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.IDOrden = (int)datos.Lector["IdOrden"];
                    aux.IDArticulo = (int)datos.Lector["IdArticulo"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Precio = (float)datos.Lector["Precio"];
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

        public List<OrdenDetalle> listarPorOrden(string id)
        {
            List<OrdenDetalle> lista = new List<OrdenDetalle>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta(Diccionario.LISTAR_ORDENES_DETALLE + "WHERE IdOrden = " + id);
                
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    OrdenDetalle aux = new OrdenDetalle();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.IDOrden = (int)datos.Lector["IdOrden"];
                    aux.IDArticulo = (int)datos.Lector["IdArticulo"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Precio = (float)datos.Lector["Precio"];
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
