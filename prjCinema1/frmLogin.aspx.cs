using libCinema1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjCinema1
{
    public partial class frmLogin : System.Web.UI.Page
    {
        #region VAIABLES GLOBALES
        private static string strNombreApp;
        #endregion

        #region METODOS PRIVADOS
        private bool Validar()
        {
            if (this.txtUsuario.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar su nombre de usuario";
                this.lblMensaje.Visible = true;
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.txtContrasena.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar su contraseña";
                this.lblMensaje.Visible = true;
                this.pnlAlerta.Visible = true;
                return false;
            }
            return true;
        }

        private void Ingresar()
        {
            try
            {
                if (!Validar())
                {
                    return;
                }
                clsLogin objLog = new clsLogin(strNombreApp);
                objLog.Usuario = this.txtUsuario.Text;
                objLog.Clave = this.txtContrasena.Text;
                if (!objLog.Logueo())
                {
                    this.lblMensaje.Text = objLog.Error;
                    this.pnlAlerta.Visible = true;
                    objLog = null;
                    return;
                }

                if (objLog.Respuesta == 0)
                {
                    Response.Redirect("frmVentas.aspx");
                }
                else
                {
                    this.lblMensaje.Text = "Sus credenciales de acceso no son válidas. Verifíque nuevamente";                    
                    this.pnlAlerta.Visible = true;
                }
                objLog = null;
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
                this.pnlAlerta.Visible = true;
                return;
            }
        }
        #endregion

        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strNombreApp = Assembly.GetExecutingAssembly().GetName().Name;
            }
            this.pnlAlerta.Visible = false;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            Ingresar();            
        }
        #endregion
        
    }
}