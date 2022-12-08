using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Ecommerce.Compras
{
    public partial class GestorCompras : System.Web.UI.Page
    {
        public bool edicion { get; set; }
        public bool listarBool { get; set; }
        protected void Page_Load(object sender, EventArgs e)         
        {
                           
            if (Session["edicion"] != null)
            {
                edicion = (bool)Session["edicion"];
            }
            else
            {
                edicion = false;
            }

            if (Session["listar"] != null)
            {
                listarBool = (bool)Session["listar"];

            }
            else
            {
                listarBool = true;
            }

            if (listarBool)
            {
                btnListar.Text = "Listar ordenes dadas de baja";
            }
            else
            {
                btnListar.Text = "Listar ordenes actualmente en alta";
            }



            if (Session["id"] != null)
            {
                Session.Remove("id");
            }

            if (!IsPostBack)
            {

                OrdenNegocio lista = new OrdenNegocio();

                if ((Session["user"] != null) && (((Usuario)Session["user"]).TipoUsuario.ID == 4))
                {
                    if (edicion)
                    {
                        Session.Add("listaOrdenes2", lista.listarParaConteo());
                        dgvOrdenes2.DataSource = Session["listaOrdenes2"];
                        dgvOrdenes2.DataBind();
                    }
                    else
                    {
                        Session.Add("listaOrdenes", lista.listar(listarBool));
                        dgvOrdenes.DataSource = Session["listaOrdenes"];
                        dgvOrdenes.DataBind();
                    }
                }

                if ((Session["user"] != null) && (((Usuario)Session["user"]).TipoUsuario.ID == 2))
                {
                    Session.Add("listaOrdenes", lista.listarPorUsuario(((Usuario)Session["user"]).Id.ToString()));
                    dgvOrdenesCliente.DataSource = Session["listaOrdenes"];
                    dgvOrdenesCliente.DataBind();

                }

            }
            if (IsPostBack && (Session["user"] != null) && (((Usuario)Session["user"]).TipoUsuario.ID == 2))
            {
                dgvOrdenesCliente.DataSource = Session["listaOrdenes"];
                dgvOrdenesCliente.DataBind();
            }
            if (IsPostBack && (Session["user"] != null) && (((Usuario)Session["user"]).TipoUsuario.ID == 4))
            {                  
                dgvOrdenes.DataSource = Session["listaOrdenes"];
                dgvOrdenes.DataBind();              
            }
           
        }


        /// ORDENES DE COMPRA DE UN CLIENTE ESPECIFICO
        protected void dgvOrdenesCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvOrdenesCliente.SelectedDataKey.Value.ToString();
            Session.Add("idd", id);
            Response.Redirect("DetalleFactura.aspx");
        }

        protected void dgvOrdenesCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvOrdenesCliente.PageIndex = e.NewPageIndex;
            dgvOrdenesCliente.DataBind();
        }

        /// ORDENES DE COMPRA SIN EDICION PERMITIDA
        protected void dgvOrdenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvOrdenes.SelectedDataKey.Value.ToString();
            Session.Add("idd", id);
            Response.Redirect("DetalleFactura.aspx");
        }

        protected void dgvOrdenes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvOrdenes.PageIndex = e.NewPageIndex;
            dgvOrdenes.DataBind();
        }

        /// ORDENES DE COMPRA CON EDICION PERMITIDA
        protected void dgvOrdenes2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvOrdenes2.SelectedDataKey.Value.ToString();
            Session.Add("idd", id);
        }
        protected void dgvOrdenes2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvOrdenes2.DataSource = Session["listaOrdenes2"];
            dgvOrdenes2.DataBind();
            dgvOrdenes2.PageIndex = e.NewPageIndex;
            dgvOrdenes2.DataBind();

        }

        protected void btnEdicion_Click(object sender, EventArgs e)
        {
            bool edit = true;
            Session.Add("edicion", edit);
            Response.Redirect("GestorCompras.aspx");
        }

        protected void btnCambios_Click(object sender, EventArgs e)
        {
            
            List<Orden> ordenes = new List<Orden> { };
            foreach (GridViewRow row in dgvOrdenes2.Rows)
            {
                Orden aAgregar = new Orden();
                OrdenNegocio oNegocio = new OrdenNegocio();

                aAgregar.ID = Int32.Parse(row.Cells[0].Text);

                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[8].FindControl("chbEnviado") as CheckBox);
                    aAgregar.Enviado = chkRow.Checked;
                }
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[9].FindControl("chbRecibido") as CheckBox);
                    aAgregar.Recibido = chkRow.Checked;
                }
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[10].FindControl("chbPagado") as CheckBox);
                    aAgregar.Pagado = chkRow.Checked;
                }
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[13].FindControl("chbEstado") as CheckBox);
                    aAgregar.EstadoActivo = chkRow.Checked;
                }

                oNegocio.gestionOrdenes(aAgregar);

            }

            

            Session["edicion"] = false;
            Response.Redirect("GestorCompras.aspx");
        }


        protected void btnListar_Click(object sender, EventArgs e)
        {
            if (Session["listar"] != null)
            {
                if ((bool)Session["listar"])
                {
                    Session["listar"] = false;
                }
                else
                {
                    Session["listar"] = true;
                }
            }
            else
            { 

                bool listar = false;
                Session.Add("listar", listar);

            }
            Response.Redirect("GestorCompras.aspx");
        }



    }
}