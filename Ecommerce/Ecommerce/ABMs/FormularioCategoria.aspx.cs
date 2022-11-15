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
    public partial class FormularioCategoria : System.Web.UI.Page
    {
        public string id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                id = Session["id"] != null ? Session["id"].ToString() : "";
                if (id != null)
                {

                    CategoriaNegocio negocio = new CategoriaNegocio();
                    Categoria selecta = (negocio.listar(id))[0];

                    txtDesc.Text = selecta.Descripcion;
                }

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            id = Session["id"] != null ? Session["id"].ToString() : "";
            if (id != "")
            {
                if (id != null)
                {
                    string texto = txtDesc.Text.ToString();
                    CategoriaNegocio a = new CategoriaNegocio();
                    a.modificar(id, texto);

                    id = "";
                    Session.Remove("id");
                    Response.Redirect("ABMCategorias.aspx");
                }
            }
            else{
                string texto = txtDesc.Text.ToString();
                CategoriaNegocio a = new CategoriaNegocio();
                a.agregarCat(texto); 
                Response.Redirect("ABMCategorias.aspx");
            }

        }


    }
}