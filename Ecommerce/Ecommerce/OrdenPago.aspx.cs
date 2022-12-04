using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Ajax.Utilities;
using dominio;
using negocio;

namespace Ecommerce
{
    public partial class OrdenPago : System.Web.UI.Page
    {
  
        public bool validarDireccion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MetodoNegocio Mnegocio = new MetodoNegocio();
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

            ddlMetodoPago.DataSource = Mnegocio.listar();
            ddlMetodoPago.DataBind();

            ddlMetodoPago2.DataSource = Mnegocio.listar();
            ddlMetodoPago2.DataBind();


            
        }




        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Orden oCompra = new Orden();
            OrdenNegocio oNegocio = new OrdenNegocio();
            oCompra.ID = oNegocio.DevolverID();
            oCompra.ItemsCarro = new List<OrdenDetalle>();
            foreach (ItemCarrito a in (List<ItemCarrito>)Session["listaEnCarro"])
            {
                OrdenDetalle aAgregar = new OrdenDetalle();
                aAgregar.IDOrden = oCompra.ID;
                aAgregar.IDArticulo = a.Id;
                aAgregar.Detalles = a;
                oCompra.ItemsCarro.Add(aAgregar);
            }
            oCompra.IDMetodoPago = ddlMetodoPago.SelectedIndex;
            oCompra.IDUser = ((Usuario)Session["user"]).Id;
            oCompra.IDDomicilio = 1;



            Session.Add("orden", oCompra);

            

            Response.Redirect("ConfirmacionPedido.aspx");

        }

        protected void btnConfirmar2_Click(object sender, EventArgs e)
        {
            Orden oCompra = new Orden();
            OrdenNegocio oNegocio = new OrdenNegocio();
            oCompra.ID = oNegocio.DevolverID();
            oCompra.ItemsCarro = new List<OrdenDetalle>();
            foreach (ItemCarrito a in (List<ItemCarrito>)Session["listaEnCarro"])
            {
                OrdenDetalle aAgregar = new OrdenDetalle();
                aAgregar.IDOrden = oCompra.ID;
                aAgregar.IDArticulo = a.Id;
                aAgregar.Detalles = new dominio.ItemCarrito();
                aAgregar.Detalles = a;
                oCompra.ItemsCarro.Add(aAgregar);
            }
            oCompra.IDMetodoPago = ddlMetodoPago.SelectedIndex;
            if (oCompra.IDMetodoPago == 0)
            {
                oCompra.IDMetodoPago =ddlMetodoPago2.SelectedIndex;
            }
            oCompra.IDUser = ((Usuario)Session["user"]).Id;


            Session.Add("orden", oCompra);

            Response.Redirect("ConfirmacionPedido.aspx");
          
        }

    

    }
}