using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class OrdenPago : System.Web.UI.Page
    {
        public bool validarDireccion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            DomicilioNegocio lista = new DomicilioNegocio();
            if (Session["user"] != null)
            {
                dgvDomiciliosUsuario.DataSource = lista.listarPorUsuario((((dominio.Usuario)Session["user"]).Id).ToString());
                dgvDomiciliosUsuario.DataBind();
            }

            if (dgvDomiciliosUsuario.Rows.Count == 0)
            {
                validarDireccion = false;
            }
            else
            {
                validarDireccion = true;
            }


            
        }




    }
}