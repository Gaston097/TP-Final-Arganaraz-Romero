using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TipoUsuarioNegocio
    {

        public List<TipoUsuario> listar(string id = "")
        {
            List<TipoUsuario> lista = new List<TipoUsuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                if (id == "")
                {
                    datos.setearConsulta(Diccionario.LISTAR_TIPOS_USUARIO);
                }
                else
                {
                    datos.setearConsulta(Diccionario.LISTAR_TIPOS_USUARIO + "WHERE id = " + id);
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoUsuario aux = new TipoUsuario();
                    aux.ID = (int)datos.Lector["id"];
                    aux.Nombre = (String)datos.Lector["Nombre"];

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



    }
}
