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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public string id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio Cnegocio = new CategoriaNegocio();
            MarcaNegocio Mnegocio = new MarcaNegocio();
            EstadoComercialNegocio ECnegocio = new EstadoComercialNegocio();

            try
            {
                if (!IsPostBack)
                {
                    ddlCategorias.DataSource = Cnegocio.listar();
                    ddlCategorias.DataBind();

                    ddlMarcas.DataSource = Mnegocio.listar();
                    ddlMarcas.DataBind();

                    ddlEstadoComercial.DataSource = ECnegocio.listar();
                    ddlEstadoComercial.DataBind();

                    id = Session["id"] != null ? Session["id"].ToString() : "";
                    if (id != null)
                    {

                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Articulo selecta = (negocio.listar(true, id))[0];
                        txtCodigo.Text = selecta.Codigo;
                        txtNombre.Text = selecta.Nombre;
                        txtPrecio.Text = selecta.Precio.ToString();
                        txtImagen.Text = selecta.Imagen;
                        txtDescuento.Text = selecta.Descuento.ToString();
                        ddlCategorias.SelectedValue = selecta.Categoria.ID.ToString();
                        ddlMarcas.SelectedValue = selecta.Marca.ID.ToString();
                        ddlEstadoComercial.SelectedValue = selecta.EstadoComer.ID.ToString();
                    }


                }
            }
            catch(Exception ex)
            {
                Session.Add("error", ex);
            }



        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            id = Session["id"] != null ? Session["id"].ToString() : "";
            if (id != "")
            {
                if (id != null)
                {
                    Articulo aAgregar = new Articulo();
                    aAgregar.Codigo = txtCodigo.Text;
                    aAgregar.Nombre = txtNombre.Text;
                    aAgregar.Precio = decimal.Parse(txtPrecio.Text);
                    aAgregar.Imagen = txtImagen.Text;
                    aAgregar.Descuento = int.Parse(txtDescuento.Text);
                    aAgregar.Marca = new Marca();
                    aAgregar.Marca.ID = int.Parse(ddlMarcas.SelectedValue);
                    aAgregar.Categoria = new Categoria();
                    aAgregar.Categoria.ID = int.Parse(ddlCategorias.SelectedValue);
                    aAgregar.EstadoComer = new EstadoComercial();
                    aAgregar.EstadoComer.ID = int.Parse(ddlEstadoComercial.SelectedValue);

                    ArticuloNegocio a = new ArticuloNegocio();
                    a.agregar(aAgregar);

                    id = "";
                    Session.Remove("id");
                    Response.Redirect("ABMCategorias.aspx");
                }
            }
            else
            {
                Articulo aModificar = new Articulo();
                aModificar.Codigo = txtCodigo.Text;
                aModificar.Nombre = txtNombre.Text;
                aModificar.Precio = decimal.Parse(txtPrecio.Text);
                aModificar.Imagen = txtImagen.Text;
                aModificar.Descuento = int.Parse(txtDescuento.Text);
                aModificar.Marca = new Marca();
                aModificar.Marca.ID = int.Parse(ddlMarcas.SelectedValue);
                aModificar.Categoria = new Categoria();
                aModificar.Categoria.ID = int.Parse(ddlCategorias.SelectedValue);
                aModificar.EstadoComer = new EstadoComercial();
                aModificar.EstadoComer.ID = int.Parse(ddlEstadoComercial.SelectedValue);

                ArticuloNegocio a = new ArticuloNegocio();
                a.modificar(aModificar, id);
                Response.Redirect("ABMCategorias.aspx");
            }

        }


    }
}