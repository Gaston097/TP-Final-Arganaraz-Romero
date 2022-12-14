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
        public List<Articulo> listar(bool estado, string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (id == "")
                {
                    datos.setearConsulta(Diccionario.LISTAR_ARTICULOS);
                }
                else
                {
                    datos.setearConsulta(Diccionario.LISTAR_ARTICULOS + "WHERE A.id = " + id);
                }


                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    if ((bool)datos.Lector["EstadoActivo"] == estado)
                    {
                        Articulo aux = new Articulo();
                        aux.Id = (int)datos.Lector["Id"];
                        aux.Codigo = (string)datos.Lector["Codigo"];
                        aux.Nombre = (string)datos.Lector["Nombre"];
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                        aux.Imagen = (string)datos.Lector["Imagen"];
                        aux.Precio = (decimal)datos.Lector["Precio"];
                        aux.Marca = new Marca();
                        aux.Marca.ID = (int)datos.Lector["IdMarca"];
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                        aux.Categoria = new Categoria();
                        aux.Categoria.ID = (int)datos.Lector["IdCategoria"];
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                        aux.EstadoComer= new EstadoComercial();
                        aux.EstadoComer.ID = (int)datos.Lector["EstadoComercial"];
                        aux.EstadoComer.Nombre = (string)datos.Lector["NombreE"];
                        aux.Descuento = (int)datos.Lector["Descuento"];
                        aux.EstadoActivo = (bool)datos.Lector["EstadoActivo"];
                        lista.Add(aux);
                    }


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
                datos.setearParametro("@imagen", nuevo.Imagen);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.setearParametro("@idEstadoComercial", nuevo.EstadoComer.ID);
                datos.setearParametro("@descuento", nuevo.Descuento);
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

        public void modificar(Articulo articulo, string id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(Diccionario.MODIFICAR_ARTICULO);
                datos.setearParametro("@codigo", articulo.Codigo);
                datos.setearParametro("@nombre", articulo.Nombre);
                datos.setearParametro("@descripcion", articulo.Descripcion);
                datos.setearParametro("@idMarca", articulo.Marca.ID);
                datos.setearParametro("@idCategoria", articulo.Categoria.ID);
                datos.setearParametro("@imagen", articulo.Imagen);
                datos.setearParametro("@precio", articulo.Precio);
                datos.setearParametro("@idEstadoComercial", articulo.EstadoComer.ID);
                datos.setearParametro("@descuento", articulo.Descuento);
                datos.setearParametro("@estado", 1);
                datos.setearParametro("@ID", id);

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


        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta(Diccionario.ELIMINAR_ARTICULO);
                datos.setearParametro("id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /*     
        
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
