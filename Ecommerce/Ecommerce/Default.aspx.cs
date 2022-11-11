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

            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();

            if (!IsPostBack)
            {
                Repeter.DataSource = listaArticulos;
                Repeter.DataBind();
            }
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
    }
}