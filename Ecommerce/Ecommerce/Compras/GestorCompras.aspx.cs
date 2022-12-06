using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.Compras
{
    public partial class GestorCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                Session.Remove("id");
            }

            OrdenNegocio lista = new OrdenNegocio();
            Session.Add("listaOrdenes", lista.listar());
            dgvOrdenes.DataSource = Session["listaOrdenes"];
            dgvOrdenes.DataBind();
        }

        protected void dgvOrdenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvOrdenes.SelectedDataKey.Value.ToString();
            Session.Add("idd", id);
            Response.Redirect("DetalleFactura.aspx");
            

          
        }

        protected void dgvOrdenes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvOrdenes.PageIndex = e.NewPageIndex;
            dgvOrdenes.DataBind();
        }



    }
}