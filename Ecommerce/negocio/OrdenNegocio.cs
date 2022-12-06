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

        public List<Orden> listarPorUsuario(string id)
        {
            List<Orden> lista = new List<Orden>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta(Diccionario.LISTAR_ORDENES + "WHERE O.EstadoActivo = 1 AND U.Id = " + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Orden aux = new Orden();
                    aux.ID = (int)datos.Lector["idOrden"];
                    aux.User = new Usuario();
                    aux.User.Nombre = (string)datos.Lector["usuario"];
                    aux.User.Id = (int)datos.Lector["idUsuario"];
                    aux.MetPago = new MetodoPago();
                    aux.MetPago.ID = (int)datos.Lector["idMetodoPago"];
                    aux.MetPago.Nombre = (string)datos.Lector["metodoPago"];
                    if (!Convert.IsDBNull(datos.Lector["idDomicilio"]))
                    {
                        aux.Domicilio = new Domicilio();
                        aux.Domicilio.Id = (int)datos.Lector["idDomicilio"];
                        aux.Domicilio.Ciudad = (string)datos.Lector["ciudad"];
                        aux.Domicilio.Calle = (string)datos.Lector["calle"];
                        aux.Domicilio.Numero = (string)datos.Lector["numeroCalle"];
                        aux.Domicilio.CodPostal = (string)datos.Lector["codpos"];
                    }
                    aux.Total = Convert.ToDouble(datos.Lector["total"]);
                    aux.Envio = (bool)datos.Lector["envio"];
                    aux.Pagado = (bool)datos.Lector["pagado"];


                    if (!Convert.IsDBNull(datos.Lector["enviado"])) { aux.Enviado = (bool)datos.Lector["Enviado"]; }
                    aux.Recibido = (bool)datos.Lector["recibido"];

                    if (!Convert.IsDBNull(datos.Lector["EstadoActivo"])) { aux.EstadoActivo = (bool)datos.Lector["EstadoActivo"]; }

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

        public List<Orden> listarParaConteo(string id = "")
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
                    datos.setearConsulta(Diccionario.LISTAR_ORDENES + " WHERE idOrden = " + id);
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Orden aux = new Orden();
                    aux.ID = (int)datos.Lector["idOrden"];
                    aux.User = new Usuario();
                    aux.User.Nombre = (string)datos.Lector["usuario"];
                    aux.User.Id = (int)datos.Lector["idUsuario"];
                    aux.MetPago = new MetodoPago();
                    aux.MetPago.ID = (int)datos.Lector["idMetodoPago"];
                    aux.MetPago.Nombre = (string)datos.Lector["metodoPago"];
                    if (!Convert.IsDBNull(datos.Lector["idDomicilio"]))
                    {
                        aux.Domicilio = new Domicilio();
                        aux.Domicilio.Id = (int)datos.Lector["idDomicilio"];
                        aux.Domicilio.Ciudad = (string)datos.Lector["ciudad"];
                        aux.Domicilio.Calle = (string)datos.Lector["calle"];
                        aux.Domicilio.Numero = (string)datos.Lector["numeroCalle"];
                        aux.Domicilio.CodPostal = (string)datos.Lector["codpos"];
                    }
                    aux.Total = Convert.ToDouble(datos.Lector["total"]);
                    aux.Envio = (bool)datos.Lector["envio"];
                    aux.Pagado = (bool)datos.Lector["pagado"];


                    if (!Convert.IsDBNull(datos.Lector["enviado"])) { aux.Enviado = (bool)datos.Lector["Enviado"]; }
                    aux.Recibido = (bool)datos.Lector["recibido"];

                    if (!Convert.IsDBNull(datos.Lector["EstadoActivo"])) { aux.EstadoActivo = (bool)datos.Lector["EstadoActivo"]; }

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


        public List<Orden> listar(bool estado, string id = "")       
        {

            
            List<Orden> lista = new List<Orden>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                if (id == "")
                {
                    datos.setearConsulta(Diccionario.LISTAR_ORDENES + "WHERE O.EstadoActivo = " + Convert.ToInt32(estado) );
                }
                else
                {
                    datos.setearConsulta(Diccionario.LISTAR_ORDENES + "WHERE O.EstadoActivo = " + Convert.ToInt32(estado)  + " AND idOrden = " + id);
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Orden aux = new Orden();
                    aux.ID = (int)datos.Lector["idOrden"];
                    aux.User = new Usuario();
                    aux.User.Nombre = (string)datos.Lector["usuario"];
                    aux.User.Id = (int)datos.Lector["idUsuario"];
                    aux.MetPago = new MetodoPago();
                    aux.MetPago.ID = (int)datos.Lector["idMetodoPago"];
                    aux.MetPago.Nombre = (string)datos.Lector["metodoPago"];
                    if (!Convert.IsDBNull(datos.Lector["idDomicilio"])) 
                    {
                        aux.Domicilio = new Domicilio();
                        aux.Domicilio.Id = (int)datos.Lector["idDomicilio"];
                        aux.Domicilio.Ciudad = (string)datos.Lector["ciudad"];
                        aux.Domicilio.Calle = (string)datos.Lector["calle"];
                        aux.Domicilio.Numero = (string)datos.Lector["numeroCalle"];
                        aux.Domicilio.CodPostal = (string)datos.Lector["codpos"];
                    }
                    aux.Total = Convert.ToDouble(datos.Lector["total"]);
                    aux.Envio = (bool)datos.Lector["envio"];
                    aux.Pagado = (bool)datos.Lector["pagado"];
                    

                    if (!Convert.IsDBNull(datos.Lector["enviado"])) { aux.Enviado = (bool)datos.Lector["Enviado"]; }
                    aux.Recibido = (bool)datos.Lector["recibido"];

                    if (!Convert.IsDBNull(datos.Lector["EstadoActivo"])) { aux.EstadoActivo = (bool)datos.Lector["EstadoActivo"]; }

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
                datos.setearParametro("@idUsuario", nuevo.User.Id);
                datos.setearParametro("@idMetodoPago", nuevo.MetPago.ID);
                datos.setearParametro("@total", Convert.ToDecimal(nuevo.Total));
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
                datos.setearParametro("@idUsuario", nuevo.User.Id);
                datos.setearParametro("@idMetodoPago", nuevo.MetPago.ID);
                datos.setearParametro("@idDomicilio", nuevo.Domicilio.Id);
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
            if ((lista = listarParaConteo()).Count == 0)
            {
                return 1;
            }
            else
            {
                return (lista.Last().ID + 1);
            }
        }

        public void AltaBajaLogica(Orden aAlterar, bool cambio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.BAJA_ALTA_LOGICA_ORDEN);
                datos.setearParametro("@id", aAlterar.User.Id);
                datos.setearParametro("ed", cambio);
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
