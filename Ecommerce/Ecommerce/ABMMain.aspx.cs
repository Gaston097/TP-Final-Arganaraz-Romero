using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class ABMMain : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMs/ABMCategorias.aspx");
        }

        protected void btnAbmMarcas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMs/ABMMarcas.aspx");
        }
    }
}