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
    public partial class ABMUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["id"] != null)
            {
                Session.Remove("id");
            }


            UsuarioNegocio lista = new UsuarioNegocio();
            dgvUsuarios.DataSource = lista.listar();
            dgvUsuarios.DataBind();

        }

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvUsuarios.SelectedDataKey.Value.ToString();
            Session.Add("id", id);
            Response.Redirect("FormularioUsuario.aspx");

        }

        protected void dgvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvUsuarios.PageIndex = e.NewPageIndex;
            dgvUsuarios.DataBind();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            GridView gv = clickedRow.NamingContainer as GridView;
            var id = gv.DataKeys[clickedRow.RowIndex].Values[0].ToString();
            Session.Add("id", id);
            Response.Redirect("FormularioUsuario.aspx");
        }
    }
}