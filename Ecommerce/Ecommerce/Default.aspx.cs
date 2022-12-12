using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Antlr.Runtime;
using dominio;
using negocio;

namespace Ecommerce
{
    public partial class _Default : Page
    {
        public List<Articulo> listaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio Cnegocio = new CategoriaNegocio();
            MarcaNegocio Mnegocio = new MarcaNegocio();
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar(true);

            if (!IsPostBack)
            {
                Repeter.DataSource = listaArticulos;
                Repeter.DataBind();

                ddlCategorias.Items.Insert(0, new ListItem("Buscar por Categoria"));
                List<Categoria> ddlC = new List<Categoria>();
                ddlC = Cnegocio.listar();
                int test = 1;
                foreach(Categoria c in ddlC)
                {
                    ddlCategorias.Items.Insert(test, c.Descripcion);
                    test++;
                }

                ddlMarcas.Items.Insert(0, new ListItem("Buscar por Marca"));
                List<Marca> ddlM = new List<Marca>();
                ddlM = Mnegocio.listar();
                test = 1;
                foreach (Marca m in ddlM)
                {
                    ddlMarcas.Items.Insert(test, m.Descripcion);
                    test++;
                }
            }
        }

        protected List<Articulo> listarArticulos()
        {
            List<Articulo> listaFiltrada = listaArticulos.FindAll((busqueda => (busqueda.Nombre.ToUpper().Contains(txtfiltro.Text.ToUpper())) || (busqueda.Codigo.ToUpper().Contains(txtfiltro.Text.ToUpper())) || (busqueda.Descripcion.ToUpper().Contains(txtfiltro.Text.ToUpper())) || (busqueda.Categoria.Descripcion.ToUpper().Contains(txtfiltro.Text.ToUpper())) || (busqueda.Marca.Descripcion.ToUpper().Contains(txtfiltro.Text.ToUpper()))));
            return listaFiltrada;
        }


        protected void ddlMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Articulo> filtro = listarArticulos();
            List<Articulo> listaFiltrada = new List<Articulo>();
            if (ddlMarcas.SelectedIndex != 0)
            {
                
                if (ddlCategorias.SelectedIndex != 0)
                {
                    listaFiltrada = listaArticulos.FindAll(busqueda => (busqueda.Categoria.Descripcion.ToUpper().Contains(ddlCategorias.SelectedValue.ToUpper())) && (busqueda.Marca.Descripcion.ToUpper().Contains(ddlMarcas.SelectedValue.ToUpper())) && filtro.Contains(busqueda));
                }
                else
                {
                    listaFiltrada = listaArticulos.FindAll(busqueda => (busqueda.Marca.Descripcion.ToUpper().Contains(ddlMarcas.SelectedValue.ToUpper())) && filtro.Contains(busqueda));
                }
                Repeter.DataSource = listaFiltrada;
                Repeter.DataBind();
            
            }
            else if (ddlCategorias.SelectedIndex != 0)
            {
                listaFiltrada = listaArticulos.FindAll(busqueda => (busqueda.Categoria.Descripcion.ToUpper().Contains(ddlCategorias.SelectedValue.ToUpper())) && filtro.Contains(busqueda));
                Repeter.DataSource = listaFiltrada;
                Repeter.DataBind();
            }
            else
            {
                Repeter.DataSource = listarArticulos();
                Repeter.DataBind();
            }
        }


        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Articulo> filtro = listarArticulos();
            List<Articulo> listaFiltrada = new List<Articulo>();
            if (ddlCategorias.SelectedIndex != 0)
            {
                if (ddlMarcas.SelectedIndex != 0)
                {
                    listaFiltrada = listaArticulos.FindAll(busqueda => (busqueda.Categoria.Descripcion.ToUpper().Contains(ddlCategorias.SelectedValue.ToUpper())) && (busqueda.Marca.Descripcion.ToUpper().Contains(ddlMarcas.SelectedValue.ToUpper())) && filtro.Contains(busqueda));
                }
                else
                {
                    listaFiltrada = listaArticulos.FindAll(busqueda => (busqueda.Categoria.Descripcion.ToUpper().Contains(ddlCategorias.SelectedValue.ToUpper())) && filtro.Contains(busqueda));
                }
                Repeter.DataSource = listaFiltrada;
                Repeter.DataBind();

            }
            else if (ddlMarcas.SelectedIndex != 0)
            {
                listaFiltrada = listaArticulos.FindAll(busqueda => (busqueda.Marca.Descripcion.ToUpper().Contains(ddlCategorias.SelectedValue.ToUpper())) && filtro.Contains(busqueda));
                Repeter.DataSource = listaFiltrada;
                Repeter.DataBind();
            }
            else
            {
                Repeter.DataSource = listarArticulos();
                Repeter.DataBind();
            }
        }

        protected void btnBuscar_OnClick(object sender, EventArgs e)
        {
            List<Articulo> filtro = listarArticulos();
            List<Articulo> listaFiltrada = new List<Articulo>();
            {
                if(ddlCategorias.SelectedIndex != 0)
                {
                    if(ddlMarcas.SelectedIndex != 0)
                    {
                        listaFiltrada = listaArticulos.FindAll(busqueda => (busqueda.Categoria.Descripcion.ToUpper().Contains(ddlCategorias.SelectedValue.ToUpper())) && (busqueda.Marca.Descripcion.ToUpper().Contains(ddlMarcas.SelectedValue.ToUpper())) && filtro.Contains(busqueda));
                    }
                    else
                    {
                        listaFiltrada = listaArticulos.FindAll(busqueda => (busqueda.Categoria.Descripcion.ToUpper().Contains(ddlCategorias.SelectedValue.ToUpper())) && filtro.Contains(busqueda));
                    }
                }
                else if(ddlMarcas.SelectedIndex != 0)
                {
                    listaFiltrada = listaArticulos.FindAll(busqueda => (busqueda.Marca.Descripcion.ToUpper().Contains(ddlMarcas.SelectedValue.ToUpper())) && filtro.Contains(busqueda));
                }
                else
                {
                    listaFiltrada = listaArticulos.FindAll(busqueda => (filtro.Contains(busqueda)));

                }
            }
            Repeter.DataSource = listaFiltrada;
            Repeter.DataBind();

        }



        public int CarritoVacio()
        {
            int aDevolver = 0;
            List<ItemCarrito> cantItems = Session["listaEnCarro"] != null ?
                (List<ItemCarrito>)Session["listaEnCarro"] : new List<ItemCarrito>();
            foreach (ItemCarrito item in cantItems)
            {
                aDevolver += item.Cantidad;
            }
            return aDevolver;
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            string idAgregar = (((Button)sender).CommandArgument).ToString();

            List<ItemCarrito> ListSesion = ListaSessionCar();
            ItemCarrito aAgregar;
            if ((aAgregar = ListSesion.Find(x => x.Id == int.Parse(idAgregar))) != null)
            {
                aAgregar.Cantidad++;
            }
            else
            {
                ItemCarrito nuevoItem = new ItemCarrito();
                Articulo nuevoArticulo = new Articulo();
                nuevoArticulo = negocio.listar(true, idAgregar)[0];
                nuevoItem.Id = nuevoArticulo.Id;
                nuevoItem.Nombre = nuevoArticulo.Nombre;
                nuevoItem.URLImagen = nuevoArticulo.Imagen;
                nuevoItem.Precio = nuevoArticulo.Precio;
                nuevoItem.Cantidad++;
                ListSesion.Add(nuevoItem);
            }

            Session.Add("listaEnCarro", ListSesion);

            Response.Redirect("Default.aspx");

        }



        protected void btnAgregarCarritoRedirect_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            string idAgregar = (((Button)sender).CommandArgument).ToString();

            List<ItemCarrito> ListSesion = ListaSessionCar();
            ItemCarrito aAgregar;
            if ((aAgregar = ListSesion.Find(x => x.Id == int.Parse(idAgregar))) != null)
            {
                aAgregar.Cantidad++;
            }
            else
            {
                ItemCarrito nuevoItem = new ItemCarrito();
                Articulo nuevoArticulo = new Articulo();
                nuevoArticulo = negocio.listar(true, idAgregar)[0];
                nuevoItem.Id = nuevoArticulo.Id;
                nuevoItem.Nombre = nuevoArticulo.Nombre;
                nuevoItem.URLImagen = nuevoArticulo.Imagen;
                nuevoItem.Precio = nuevoArticulo.Precio;
                nuevoItem.Cantidad++;
                ListSesion.Add(nuevoItem);
            }

            Session.Add("listaEnCarro", ListSesion);

            Response.Redirect("Carrito.aspx");
        }

        private List<ItemCarrito> ListaSessionCar()
        {
            List<ItemCarrito> ItemEnCarro = Session["listaEnCarro"] != null ?
                (List<ItemCarrito>)Session["listaEnCarro"] : new List<ItemCarrito>();
            return ItemEnCarro;
        }


    }
}