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

            Domicilio dAgregar = new Domicilio();        
            dAgregar.IdUsuario = new Usuario();
            dAgregar.IdUsuario.Id = int.Parse(Session["id"].ToString());
            dAgregar.Calle = txtCalle.Text;
            dAgregar.Numero = txtNumero.Text;
            dAgregar.Ciudad = txtCiudad.Text;
            dAgregar.CodPostal = txtCodpos.Text;

            DomicilioNegocio a = new DomicilioNegocio();
            a.agregarDom(dAgregar);
            Response.Redirect("../OrdenPago.aspx");



        
        }
    }
}