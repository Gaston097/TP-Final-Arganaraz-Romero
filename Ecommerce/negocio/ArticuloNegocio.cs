using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {





















    /*    public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta(Diccionario.LISTAR_ARTICULOS);
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.URLImagen = (string)datos.Lector["ImagenURL"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.ID = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.ID = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    
                    lista.Add(aux);

                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.AGREGAR_ARTICULO);
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca.ID);
                datos.setearParametro("@idCategoria", nuevo.Categoria.ID);
                datos.setearParametro("@imagen", nuevo.URLImagen);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.setearParametro("@estado", 1);
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

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(Diccionario.MODIFICAR_ARTICULO);
                datos.setearParametro("@codigo", articulo.Codigo);
                datos.setearParametro("@nombre", articulo.Nombre);
                datos.setearParametro("@descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.ID);
                datos.setearParametro("@IdCategoria", articulo.Categoria.ID);
                datos.setearParametro("@imagenUrl", articulo.URLImagen);
                datos.setearParametro("@precio", articulo.Precio);
                datos.setearParametro("@ID", articulo.Id);

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
        public List<Articulo> BuscarProduc(int id)
        {
            List<Articulo> list = new List<Articulo>();           
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta(Diccionario.Buscar);
                datos.setearParametro("ID", id);
                datos.ejecutarAccion();
                Articulo aux = new Articulo();
                aux.Id = (int)datos.Lector["Id"];
                aux.Codigo = (string)datos.Lector["Codigo"];
                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Descripcion = (string)datos.Lector["Descripcion"];
                aux.URLImagen = (string)datos.Lector["ImagenURL"];
                aux.Precio = (decimal)datos.Lector["Precio"];
                aux.Marca = new Marca();
                aux.Marca.ID = (int)datos.Lector["IdMarca"];
                aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                aux.Categoria = new Categoria();
                aux.Categoria.ID = (int)datos.Lector["IdCategoria"];
                aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                list.Add(aux);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
       
        }
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta(Diccionario.ELIMINAR_ARTICULO);
                datos.setearParametro("id", id);
                datos.ejecutarAccion(); 
            }
            catch ( Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta;
                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta = Diccionario.CONSULTA_FILTRO_AVANZADO + "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta = Diccionario.CONSULTA_FILTRO_AVANZADO + "Precio < " + filtro;
                            break;
                        default:
                            consulta = Diccionario.CONSULTA_FILTRO_AVANZADO + "Precio = " + filtro;
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta = Diccionario.CONSULTA_FILTRO_AVANZADO + campo + " like '"  + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta = Diccionario.CONSULTA_FILTRO_AVANZADO + campo + " like '%" + filtro + "' ";
                            break;
                        default:
                            consulta = Diccionario.CONSULTA_FILTRO_AVANZADO + campo + " like '%" + filtro + "%' ";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.URLImagen = (string)datos.Lector["ImagenURL"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.ID = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.ID = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(aux);

                }
                return lista;

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    */
    }
   
}
