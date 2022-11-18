using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar(string id = "")
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
              
                if(id == "")
                {
                    datos.setearConsulta(Diccionario.LISTAR_CATEGORIAS);
                }
                else
                {
                  datos.setearConsulta(Diccionario.LISTAR_CATEGORIAS +"WHERE id = " + id);
                }
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


        public void modificar(string id, string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.MODIFICAR_CATEGORIA);
                datos.setearParametro("@nombre", nombre);
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            } catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta(Diccionario.ELIMINAR_CATEGORIA);
                datos.setearParametro("id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
