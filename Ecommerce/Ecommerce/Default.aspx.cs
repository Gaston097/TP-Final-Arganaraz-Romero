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


        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada = listaArticulos.FindAll((x => x.Nombre.ToUpper().Contains(txtfiltro.Text.ToUpper())));

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