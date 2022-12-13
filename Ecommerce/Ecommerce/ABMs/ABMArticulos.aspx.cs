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
    public partial class ABMArticulos : System.Web.UI.Page
    {
        public int id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (Session["id"] != null)
            {
                Session.Remove("id");
            }

            if (!IsPostBack) { 
            ArticuloNegocio lista = new ArticuloNegocio();
            Session.Add("listaArticulo", lista.listar(true));
            dgvArticulos.DataSource = Session["listaArticulo"];
            dgvArticulos.DataBind();
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Session.Add("id", id);
            Response.Redirect("FormularioArticulo.aspx");

        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.DataSource = Session["listaArticulo"];
            dgvArticulos.DataBind();
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void txtfiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lis = (List<Articulo>)Session["listaArticulo"];
            List<Articulo> listaFiltrada = lis.FindAll(x => x.Nombre.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();


        }
    }
}