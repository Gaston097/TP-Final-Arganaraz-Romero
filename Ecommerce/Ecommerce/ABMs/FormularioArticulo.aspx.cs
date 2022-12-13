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
        public bool Confirmacion { get; set; }
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
                    if (id != "")
                    {

                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Articulo selecta = (negocio.listar(true, id))[0];
                        txtCodigo.Text = selecta.Codigo;
                        txtNombre.Text = selecta.Nombre;
                        txtPrecio.Text = selecta.Precio.ToString();
                        txtImagen.Text = selecta.Imagen;
                        txtDescripcion.Text = selecta.Descripcion;
                        txtDescuento.Text = selecta.Descuento.ToString();
                        ddlCategorias.SelectedValue = selecta.Categoria.ToString();                      
                        ddlMarcas.SelectedValue = selecta.Marca.ToString();                       
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
                    Articulo aModificar = new Articulo();
                    aModificar.Codigo = txtCodigo.Text;
                    aModificar.Nombre = txtNombre.Text;
                    aModificar.Descripcion = txtDescripcion.Text;
                    aModificar.Precio = decimal.Parse(txtPrecio.Text);
                    aModificar.Imagen = txtImagen.Text;
                    aModificar.Descuento = int.Parse(txtDescuento.Text);
                    aModificar.Marca = new Marca();
                    aModificar.Marca.ID = ddlMarcas.SelectedIndex;
                    aModificar.Marca.Descripcion = ddlMarcas.SelectedValue;
                    aModificar.Categoria = new Categoria();
                    aModificar.Categoria.ID = ddlCategorias.SelectedIndex;
                    aModificar.Categoria.Descripcion = ddlCategorias.SelectedValue;
                    aModificar.EstadoComer = new EstadoComercial();
                    aModificar.EstadoComer.ID = ddlEstadoComercial.SelectedIndex;
                    aModificar.EstadoComer.Nombre = ddlEstadoComercial.SelectedValue;

                    ArticuloNegocio a = new ArticuloNegocio();
                    a.modificar(aModificar, id);

                    id = "";
                    Session.Remove("id");
                    Response.Redirect("ABMArticulos.aspx");
                }
            }
            else
            {
                Articulo aAgregar = new Articulo();
                aAgregar.Codigo = txtCodigo.Text;
                aAgregar.Nombre = txtNombre.Text;
                aAgregar.Descripcion = txtDescripcion.Text;
                aAgregar.Precio = decimal.Parse(txtPrecio.Text);
                aAgregar.Imagen = txtImagen.Text;
                aAgregar.Descuento = int.Parse(txtDescuento.Text);
                aAgregar.Marca = new Marca();
                aAgregar.Marca.ID = ddlMarcas.SelectedIndex;
                aAgregar.Marca.Descripcion = ddlMarcas.SelectedValue;
                aAgregar.Categoria = new Categoria();
                aAgregar.Categoria.ID = ddlCategorias.SelectedIndex;
                aAgregar.Categoria.Descripcion = ddlCategorias.SelectedValue;
                aAgregar.EstadoComer = new EstadoComercial();
                aAgregar.EstadoComer.ID = ddlEstadoComercial.SelectedIndex;
                aAgregar.EstadoComer.Nombre = ddlEstadoComercial.SelectedValue;

                ArticuloNegocio a = new ArticuloNegocio();
                a.agregar(aAgregar);
                Response.Redirect("ABMArticulos.aspx");
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
                ArticuloNegocio Negocio = new ArticuloNegocio();
                Negocio.eliminar(aux);
                Response.Redirect("ABMArticulos.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}