using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace Ecommerce
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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