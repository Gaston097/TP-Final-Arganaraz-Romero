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
    public partial class FormularioMarca : System.Web.UI.Page
    {      
        public string id { get; set; }

        public bool Confirmacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Confirmacion = false;
            if (!IsPostBack)
            {

                id = Session["id"] != null ? Session["id"].ToString() : "";
                if (id != null)
                {

                    MarcaNegocio negocio = new MarcaNegocio();
                    Marca selecta = (negocio.listar(id))[0];

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
                        MarcaNegocio a = new MarcaNegocio();
                        a.modificar(id, texto);

                        id = "";
                        Session.Remove("id");
                        Response.Redirect("ABMMarcas.aspx");
                    }
                }
                else
                {
                    string texto = txtDesc.Text.ToString();
                    MarcaNegocio a = new MarcaNegocio();
                    a.agregar(texto);
                    Response.Redirect("ABMMarcas.aspx");
                }

            

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Confirmacion = true;
        }

        protected void btnEliminarConfirma_Click(object sender, EventArgs e)
        {
            try
            {
                id = Session["id"] != null ? Session["id"].ToString() : "";
                int aux = int.Parse(id);
                MarcaNegocio Negocio = new MarcaNegocio();
                Negocio.eliminar(aux);
                Response.Redirect("ABMMarcas.aspx");
            }
            catch ( Exception ex)
            {

                throw ex;
            }
        }
    }

        
    }
