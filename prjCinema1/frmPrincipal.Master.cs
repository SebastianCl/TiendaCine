using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjCinema1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        #region "Metodos Publicos"
        public void MostrarMenu()
        {
            this.pnlMenu.Visible = true;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}