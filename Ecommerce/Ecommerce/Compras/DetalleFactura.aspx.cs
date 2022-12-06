using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Ecommerce.Compras
{
    public partial class DetalleFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Session["idd"].ToString();
            CompradoNegocio lista = new CompradoNegocio();
            dgvDetalle.DataSource = lista.listar(id);
            dgvDetalle.DataBind();

        }
    }
}