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
    public partial class Carrito : Page
    {
        public List<int> cantidadArticulos { get; set; }
        public bool Confirmacion { get; set; }

        public bool ConfirLog { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Confirmacion = false;
            ConfirLog = false;  

            List<ItemCarrito> ListSesion = ListaSessionCar();
            dgvCarrito.DataSource = ListSesion;
            dgvCarrito.DataBind();
            if (dgvCarrito.Rows.Count > 0)
            {
                Confirmacion = true;
                dgvCarrito.HeaderRow.Style["background-color"] = "#f0f2f4";

            }
          
            contar();



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
            foreach (ItemCarrito item in ListaSessionCar())
            {
                a += item.Precio * item.Cantidad;
            }
            lblTotal.Text = a.ToString();
        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idd = dgvCarrito.SelectedRow.Cells[0].Text;
            foreach (ItemCarrito item in ListaSessionCar())
            {
                int itemid = Convert.ToInt32(item.Id);
                int id = Convert.ToInt32(idd);
                if (id == itemid)
                {
                    item.Cantidad--;
                    if (item.Cantidad == 0)
                    {
                        ListaSessionCar().Remove(item);

                    }
                    Response.Redirect("carrito.aspx");
                }

            }

        }

        protected void btn_Click(object sender, EventArgs e)
        {
          
             if (Session["user"] == null)
            {
                ConfirLog = true;
            }
            else
            {
                Response.Redirect("OrdenPago.aspx");
            }
            
        }

        protected void btnLogueo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}