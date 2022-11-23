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
    public partial class ABMDomicilio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string texto = txtCalle.Text.ToString();
            DomicilioNegocio a = new DomicilioNegocio();
          //  a.agregarCat(texto);
            Response.Redirect("ABMCategorias.aspx");

        
        }
    }
}