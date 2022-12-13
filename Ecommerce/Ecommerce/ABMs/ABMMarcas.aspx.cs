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
            if (!IsPostBack) { 
            MarcaNegocio lista = new MarcaNegocio();
            Session.Add("listaMarca", lista.listar());
            dgvMarcas.DataSource = Session["listaMarca"];
            dgvMarcas.DataBind();
            }
        }


        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvMarcas.SelectedDataKey.Value.ToString();
            Session.Add("id", id);
            Response.Redirect("FormularioMarca.aspx");        
        }

        protected void dgvMarcas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMarcas.DataSource = Session["listaMarca"];
            dgvMarcas.DataBind();
            dgvMarcas.PageIndex = e.NewPageIndex;
            dgvMarcas.DataBind();
        }

        protected void txtfiltro_TextChanged(object sender, EventArgs e)
        {
            List<Marca> lis = (List<Marca>)Session["listaMarca"];
            List<Marca> listaFiltrada = lis.FindAll(x => x.Descripcion.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            dgvMarcas.DataSource = listaFiltrada;
            dgvMarcas.DataBind();
        }
    }
    }
   
