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
                    if (!Convert.IsDBNull(datos.Lector["IdDomicilio"])) { aux.IDDomicilio = (int)datos.Lector["IdDomicilio"]; }
                    aux.Total = Convert.ToDouble(datos.Lector["Total"]);
                    aux.Envio = (bool)datos.Lector["Envio"];
                    aux.Pagado = (bool)datos.Lector["Pagado"];
                    

                    if (!Convert.IsDBNull(datos.Lector["Enviado"])) { aux.Enviado = (bool)datos.Lector["Enviado"]; }
                    aux.Recibido = (bool)datos.Lector["Recibido"];
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

        public void agregarSinEnvio(Orden nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.AGREGAR_ORDEN_SIN_ENVIO);
                datos.setearParametro("@idUsuario", nuevo.IDUser);
                datos.setearParametro("@idMetodoPago", nuevo.IDMetodoPago);
                datos.setearParametro("@total", nuevo.Total);
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

        public void agregarConEnvio(Orden nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.AGREGAR_ORDEN_CON_ENVIO);
                datos.setearParametro("@idUsuario", nuevo.IDUser);
                datos.setearParametro("@idMetodoPago", nuevo.IDMetodoPago);
                datos.setearParametro("@idDomicilio", nuevo.IDMetodoPago);
                datos.setearParametro("@total", nuevo.Total);
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







        public int DevolverID()
        {
            List<Orden> lista = new List<Orden>();
            if ((lista = listar()).Count == 0)
            {
                return 1;
            }
            else
            {
                return (lista.Last().ID + 1);
            }
        }


    }
}
