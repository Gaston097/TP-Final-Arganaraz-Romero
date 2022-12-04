﻿using System;
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
                    datos.setearConsulta(Diccionario.LISTAR_ORDENES + "WHERE idOrden = " + id);
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
