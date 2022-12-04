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
        public bool validarDomicilio { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //   List<Usuario> aux = new List<Usuario>();
            //  aux = (List<Usuario>)Session["user"];
            //   dgvDatosUser.DataSource = aux;
            //  dgvDatosUser.DataBind();

            List<OrdenDetalle> ListSesion = ((Orden)Session["orden"]).ItemsCarro;
            dgvDetallesOrden.DataSource = ListSesion;
            dgvDetallesOrden.DataBind();

            lblTotal.Text = contar().ToString();

            UsuarioNegocio lista = new UsuarioNegocio();
            dgvDatosUsuario.DataSource = lista.listar(((Orden)Session["orden"]).User.Id.ToString());
            dgvDatosUsuario.DataBind();

            lblMetPago.Text = ((Orden)Session["orden"]).MetPago.ToString();

            if (((Orden)Session["orden"]).Domicilio != null)
            {
                validarDomicilio = true;
                DomicilioNegocio aListar = new DomicilioNegocio();
                dgvDomicilioUsuario.DataSource = aListar.listar(((Orden)Session["orden"]).Domicilio.Id.ToString());
                dgvDomicilioUsuario.DataBind();

            }
            else
            {
                validarDomicilio = false;
            }

        }


        public decimal contar()
        {
            decimal a = 0;
            foreach (OrdenDetalle item in ((Orden)Session["orden"]).ItemsCarro) 
            {
                a += item.Detalles.Precio * item.Detalles.Cantidad;
            }
            return a;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            OrdenNegocio oNegocio = new OrdenNegocio();
            Orden nuevo = new Orden();

            nuevo.ID = ((Orden)Session["orden"]).ID;
            nuevo.User = ((Orden)Session["orden"]).User;
            nuevo.ItemsCarro = ((Orden)Session["orden"]).ItemsCarro;
            nuevo.MetPago = ((Orden)Session["orden"]).MetPago;
            nuevo.Domicilio = ((Orden)Session["orden"]).Domicilio;
            nuevo.Total = Convert.ToDouble(lblTotal.Text);          
            nuevo.Envio = ((Orden)Session["orden"]).Envio;
            nuevo.Pagado = ((Orden)Session["orden"]).Pagado;
            nuevo.Enviado = ((Orden)Session["orden"]).Enviado;
            nuevo.Recibido = ((Orden)Session["orden"]).Recibido;
            if (validarDomicilio)
            {
                oNegocio.agregarConEnvio(nuevo);
            }
            else
            {
                oNegocio.agregarSinEnvio(nuevo);
            }

            foreach( OrdenDetalle orden in nuevo.ItemsCarro)
            {
                OrdenDetalleNegocio odNegocio = new OrdenDetalleNegocio();
                odNegocio.agregar(orden);
            }


        }

    }
}