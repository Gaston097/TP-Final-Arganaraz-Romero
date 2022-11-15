﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(Diccionario.LISTAR_CATEGORIAS);
                datos.ejecutarLectura();

                 while (datos.Lector.Read())
                {
                   Categoria aux = new Categoria();
                    aux.ID = (int)datos.Lector["id"];
                    aux.Descripcion = (String)datos.Lector["Nombre"];

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

        public void agregarCat(String nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.AGREGAR_CATEGORIA);               
                datos.setearParametro("@nombre", nuevo);                            
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
