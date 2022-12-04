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
using System.Reflection.Emit;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace Ecommerce
{
    public partial class OrdenPago : System.Web.UI.Page
    {
  
        public bool validarDireccion { get; set; }

        public bool validarSeleccionDomicilio { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
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

                if (Request.QueryString["noDom"] != null)
                {
                    validarSeleccionDomicilio = true;
                }
                else
                {
                    validarSeleccionDomicilio = false;
                }

                ddlMetodoPago.DataSource = Mnegocio.listar();
                ddlMetodoPago.DataBind();

                ddlMetodoPago2.DataSource = Mnegocio.listar();
                ddlMetodoPago2.DataBind();


            }

            
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
            oCompra.Domicilio = new Domicilio();
            bool validarDomicilio = false;
            foreach (GridViewRow row in dgvDomiciliosUsuario.Rows)
            {
                RadioButton rb = (RadioButton)row.FindControl("rbtSeleccionar");
                if (rb.Checked)
                {
                    oCompra.Domicilio.Id = Int32.Parse(row.Cells[0].Text);
                    oCompra.Domicilio.Calle = row.Cells[1].Text;
                    oCompra.Domicilio.Numero = row.Cells[2].Text;
                    oCompra.Domicilio.Ciudad = row.Cells[3].Text;
                    oCompra.Domicilio.CodPostal = row.Cells[4].Text;
                    validarDomicilio = true;
                }
            }

            if (validarDomicilio)
            {
                oCompra.MetPago = new MetodoPago();
                oCompra.MetPago.ID = ddlMetodoPago.SelectedIndex + 1;
                oCompra.MetPago.Nombre = ddlMetodoPago.SelectedValue;
                oCompra.User = ((Usuario)Session["user"]);

                Session.Add("orden", oCompra);
                Response.Redirect("ConfirmacionPedido.aspx");

            }
            else
            {
                Response.Redirect("OrdenPago.aspx?noDom=true");
            }


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
                aAgregar.Detalles = a;
                oCompra.ItemsCarro.Add(aAgregar);
            }
            oCompra.MetPago = new MetodoPago();
            oCompra.MetPago.ID = ddlMetodoPago2.SelectedIndex + 1;
            oCompra.MetPago.Nombre = ddlMetodoPago2.SelectedValue;
            oCompra.User = ((Usuario)Session["user"]);

            Session.Add("orden", oCompra);
            Response.Redirect("ConfirmacionPedido.aspx");



        }



    }
}