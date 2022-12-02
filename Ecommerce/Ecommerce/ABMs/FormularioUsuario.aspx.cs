using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;


namespace Ecommerce.ABMs
{
    public partial class FormularioUsuario : System.Web.UI.Page
    {
        public string id { get; set; }

        public bool Confirmacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            TipoUsuarioNegocio TUnegocio = new negocio.TipoUsuarioNegocio();

            try
            {
                if (!IsPostBack)
                {
                    ddlTipoUsuario.DataSource = TUnegocio.listar();
                    ddlTipoUsuario.DataBind();


                    id = Session["id"] != null ? Session["id"].ToString() : "";
                    if (id != "")
                    {

                        UsuarioNegocio negocio = new UsuarioNegocio();
                        Usuario selecta = (negocio.listar(id))[0];
                        txtContrasena.Text = selecta.Contrasena;
                        txtEmail.Text = selecta.eMail;
                        txtUsuario.Text = selecta.Nombre;
                        ddlTipoUsuario.SelectedIndex = (selecta.TipoUsuario.ID - 1);

                    }


                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            id = Session["id"] != null ? Session["id"].ToString() : "";
            if (id != "")
            {
                if (id != null)
                {
                    Usuario aModificar = new Usuario();
                    aModificar.TipoUsuario = new TipoUsuario();
                    aModificar.TipoUsuario.ID = (ddlTipoUsuario.SelectedIndex + 1);
                    aModificar.Nombre = txtUsuario.Text;
                    aModificar.eMail = txtEmail.Text;
                    aModificar.Contrasena = txtContrasena.Text;
                   
                    UsuarioNegocio a = new UsuarioNegocio();
                    a.modificar(aModificar, id);

                    id = "";
                    Session.Remove("id");
                    Response.Redirect("ABMUsuarios.aspx");
                }
            }
            else
            {
                Usuario aAgregar = new Usuario();
                aAgregar.TipoUsuario = new TipoUsuario();
                aAgregar.TipoUsuario.ID = (ddlTipoUsuario.SelectedIndex + 1);
                aAgregar.Nombre = txtUsuario.Text;
                aAgregar.eMail = txtEmail.Text;
                aAgregar.Contrasena = txtContrasena.Text;

                UsuarioNegocio a = new UsuarioNegocio();
                a.agregar(aAgregar);
                Response.Redirect("ABMUsuarios.aspx");
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Confirmacion = true;
        }

        protected void btnEliminarConfirma_Click(object sender, EventArgs e)
        {
              try
            {
                id = Session["id"] != null ? Session["id"].ToString() : "";
                int aux = int.Parse(id);
                UsuarioNegocio Negocio = new UsuarioNegocio();
                Negocio.eliminar(aux);
                Response.Redirect("ABMuSUARIOS.aspx");
            }
            catch ( Exception ex)
            {
                throw ex;
            }
        }
    }
}