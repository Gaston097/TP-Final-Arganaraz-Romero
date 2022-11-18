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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio Cnegocio = new CategoriaNegocio();
            MarcaNegocio Mnegocio = new MarcaNegocio();
            EstadoComercialNegocio ECnegocio = new EstadoComercialNegocio();

            try
            {
                if (!IsPostBack)
                {
                    ddlCategorias.DataSource = Cnegocio.listar();
                    ddlCategorias.DataBind();

                    ddlMarcas.DataSource = Mnegocio.listar();
                    ddlMarcas.DataBind();

                    ddlEstadoComercial.DataSource = ECnegocio.listar();
                    ddlEstadoComercial.DataBind();


                }
            }
            catch(Exception ex)
            {
                Session.Add("error", ex);
            }



        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }


        }
}