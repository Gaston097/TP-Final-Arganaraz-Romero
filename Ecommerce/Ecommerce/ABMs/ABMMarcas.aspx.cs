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
    public partial class ABMMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaNegocio lista = new MarcaNegocio();
            dgvMarcass.DataSource = lista.listar();
            dgvMarcass.DataBind();
        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}