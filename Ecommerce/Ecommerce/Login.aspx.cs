using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Ecommerce
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contra = txtContraseña.Text;

            Usuario login = new Usuario();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(Diccionario.LISTAR_USUARIOS + "WHERE U.Usuario = '" + usuario + "' AND U.Contrasena = '" + contra +"'");

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

                    Session.Add("user", aux);

                    Response.Redirect("Default.aspx");


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}