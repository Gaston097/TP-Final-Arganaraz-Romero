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
    public partial class AltaMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            string texto = txtDesc.Text;
            MarcaNegocio a = new MarcaNegocio();
            a.agregar(texto);
            Response.Redirect("ABMMarcas.aspx");

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }
    }
}