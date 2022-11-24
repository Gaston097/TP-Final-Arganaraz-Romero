using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class SiteMaster : MasterPage
    {
        private bool firstLoad { get; set; }

    
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
        }



    }
}