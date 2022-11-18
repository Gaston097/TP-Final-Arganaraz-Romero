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


            ArticuloNegocio lista = new ArticuloNegocio();
            dgvArticulos.DataSource = lista.listar(true);
            dgvArticulos.DataBind();



        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Session.Add("id", id);
            Response.Redirect("FormularioArticulo.aspx");

        }

    }
}