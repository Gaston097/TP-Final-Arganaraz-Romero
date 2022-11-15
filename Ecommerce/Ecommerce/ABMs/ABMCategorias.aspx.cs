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
    public partial class ABMCategorias : System.Web.UI.Page
    {
        public int id {get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {          
            CategoriaNegocio lista = new CategoriaNegocio();
            dgvCategorias.DataSource = lista.listar();
            dgvCategorias.DataBind();

        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvCategorias.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioCategoria.aspx?id=" + id);

        }




    }
}