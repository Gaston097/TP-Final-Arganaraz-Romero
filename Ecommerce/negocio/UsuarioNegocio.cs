using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar(string id = "")
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (id == "")
                {
                    datos.setearConsulta(Diccionario.LISTAR_USUARIOS);
                }
                else
                {
                    datos.setearConsulta(Diccionario.LISTAR_USUARIOS + "WHERE U.id = " + id);
                }


                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                 
                        Usuario aux = new Usuario();
                        aux.TipoUsuario = new TipoUsuario();
                        aux.Id = (int)datos.Lector["Id"];
                        aux.TipoUsuario.ID = (int)datos.Lector["IdTipo"];
                        aux.TipoUsuario.Nombre = (string)datos.Lector["TipoUsuario"];
                        aux.Nombre = (string)datos.Lector["Usuario"];
                        aux.Contrasena = (string)datos.Lector["Contrasena"];
                        aux.eMail = (string)datos.Lector["Email"];
                        aux.Fecha = (DateTime)datos.Lector["Fecha"];
                        lista.Add(aux);


                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void agregar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.AGREGAR_USUARIO);
                datos.setearParametro("@idtipo", nuevo.TipoUsuario.ID);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@email", nuevo.eMail);
                datos.setearParametro("@contrasena", nuevo.Contrasena);
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



        public void modificar(Usuario usuario, string id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(Diccionario.MODIFICAR_USUARIO);
                datos.setearParametro("@idtipo", usuario.TipoUsuario.ID);
                datos.setearParametro("@usuario", usuario.Nombre);
                datos.setearParametro("@contrasena", usuario.Contrasena);
                datos.setearParametro("@email", usuario.eMail);
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
                datos.setearConsulta(Diccionario.ELIMINAR_USUARIO);
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
