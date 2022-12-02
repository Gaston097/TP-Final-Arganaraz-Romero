using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Ecommerce
{
    public partial class ConfirmacionPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //   List<Usuario> aux = new List<Usuario>();
            //  aux = (List<Usuario>)Session["user"];
            //   dgvDatosUser.DataSource = aux;
            //  dgvDatosUser.DataBind();

            List<OrdenDetalle> ListSesion = ((Orden)Session["orden"]).ItemsCarro;
            dgvDetallesOrden.DataSource = ListSesion;
            dgvDetallesOrden.DataBind();
            contar();

            UsuarioNegocio lista = new UsuarioNegocio();
            dgvDatosUsuario.DataSource = lista.listar(((dominio.Usuario)Session["user"]).Id.ToString());
            dgvDatosUsuario.DataBind();



        }

        private List<ItemCarrito> ListaSessionCar()
        {
            List<ItemCarrito> ItemEnCarro = Session["listaEnCarro"] != null ?
                (List<ItemCarrito>)Session["listaEnCarro"] : new List<ItemCarrito>();
            return ItemEnCarro;
        }

        public void contar()
        {
            decimal a = 0;
            foreach (OrdenDetalle item in ((Orden)Session["orden"]).ItemsCarro) 
            {
                a += item.Detalles.Precio * item.Detalles.Cantidad;
            }
            lblTotal.Text = a.ToString();
        }


        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

    }
}