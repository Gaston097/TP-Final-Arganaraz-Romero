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
            Session.Add("listaCategoria", lista.listar());
            dgvCategorias.DataSource = Session["listaCategoria"];
            dgvCategorias.DataBind();
        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvCategorias.SelectedDataKey.Value.ToString();
            Session.Add("id", id);
            Response.Redirect("FormularioCategoria.aspx");
        }

        protected void dgvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {          
                dgvCategorias.PageIndex= e.NewPageIndex;
                dgvCategorias.DataBind();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Categoria> lis = (List<Categoria>)Session["listaCategoria"];
            List<Categoria> listaFiltrada = lis.FindAll(x => x.Descripcion.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            dgvCategorias.DataSource = listaFiltrada;
            dgvCategorias.DataBind();
        }
    }
}