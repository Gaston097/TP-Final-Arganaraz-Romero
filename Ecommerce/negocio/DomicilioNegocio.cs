using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class DomicilioNegocio
    {
        public List<Domicilio> listar(string id = "")
        {
            List<Domicilio> lista = new List<Domicilio>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (id == "")
                {
                    datos.setearConsulta(Diccionario.LISTAR_DOMICILIO);
                }
                else
                {
                    datos.setearConsulta(Diccionario.LISTAR_DOMICILIO + "WHERE D.Id = " + id);
                }


                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {

                    Domicilio aux = new Domicilio();
                    aux.IdUsuario = new Usuario();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdUsuario.Id = (int)datos.Lector["IdUser"];
                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Numero = (string)datos.Lector["Altura"];
                    aux.Ciudad = (string)datos.Lector["Ciudad"];
                    aux.CodPostal = (string)datos.Lector["Codpos"];
                    aux.IdUsuario.Nombre = (string)datos.Lector["Usuario"];
                    lista.Add(aux);

                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public List<Domicilio> listarPorUsuario(string id = "")
        {
            List<Domicilio> lista = new List<Domicilio>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (id == "")
                {
                    datos.setearConsulta(Diccionario.LISTAR_DOMICILIO);
                }
                else
                {
                    datos.setearConsulta(Diccionario.LISTAR_DOMICILIO + "WHERE D.IdUser = " + id);
                }


                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {

                    Domicilio aux = new Domicilio();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Numero = (string)datos.Lector["Altura"];
                    aux.Ciudad = (string)datos.Lector["Ciudad"];
                    aux.CodPostal = (string)datos.Lector["Codpos"];
                    lista.Add(aux);

                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }





        public void agregarDom(Domicilio nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(Diccionario.AGREGAR_DOMICILIO);
                datos.setearParametro("@idUser", nuevo.IdUsuario.Id);
                datos.setearParametro("@calle", nuevo.Calle);
                datos.setearParametro("@numero", nuevo.Numero);
                datos.setearParametro("@ciudad", nuevo.Ciudad);
                datos.setearParametro("@codpos", nuevo.CodPostal);              
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
