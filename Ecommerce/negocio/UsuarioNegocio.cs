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
                    datos.setearConsulta(Diccionario.LISTAR_USUARIOS + "WHERE A.id = " + id);
                }


                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                 
                        Usuario aux = new Usuario();
                        aux.Id = (int)datos.Lector["Id"];
                        aux.IdTipo = (int)datos.Lector["IdTipo"];
                        aux.Nombre = (string)datos.Lector["Usuario"];
                        aux.Contrasena = (string)datos.Lector["Contrasena"];
                        aux.eMail = (string)datos.Lector["Email"];
                        aux.Fecha = (string)datos.Lector["Fecha"];
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
                datos.setearParametro("@idtipo", nuevo.IdTipo);
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
                datos.setearConsulta(Diccionario.MODIFICAR_ARTICULO);
                datos.setearParametro("@idtipo", usuario.IdTipo);
                datos.setearParametro("@nombre", usuario.Nombre);
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

    }
}
