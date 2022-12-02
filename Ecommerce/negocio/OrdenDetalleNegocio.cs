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
                    aux.Detalles.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Detalles.Precio = (decimal)datos.Lector["Precio"];
                    aux.Detalles.Nombre = (string)datos.Lector["NombreArt"];
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
                    aux.Detalles.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Detalles.Precio = (decimal)datos.Lector["Precio"];
                    aux.Detalles.Nombre = (string)datos.Lector["NombreArt"];
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

        public void agregar(OrdenDetalle nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.AGREGAR_ORDEN_DETALLE);
                datos.setearParametro("@idOrden", nuevo.IDOrden);
                datos.setearParametro("@idArticulo", nuevo.IDArticulo);
                datos.setearParametro("@cantidad", nuevo.Detalles.Cantidad);
                datos.setearParametro("@idProducto", nuevo.IDArticulo);
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
