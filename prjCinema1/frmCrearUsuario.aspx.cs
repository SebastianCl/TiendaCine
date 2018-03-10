using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libCinema1;


namespace prjCinema1
{
    public partial class frmCrearUsuario : System.Web.UI.Page
    {
        #region "Variables Globales"
        private static string strNombreApp;
        #endregion

        #region "Metodos Privados"
        private bool ValidarCampos()
        {
            if (this.txtNomUsuario.Text.Trim()==string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar un nombre de usuario";
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.txtContrasena.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar una contraseña";
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.txtNombre.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar el nombre del usuario a registrar";
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.txtCedula.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar un codigo";
                this.pnlAlerta.Visible = true;
                return false;
            }
            return true;
        }

        private void Registrar()
        {
            try
            {
                if (!ValidarCampos())
                {
                    return;
                }
                clsUsuario objUsu = new clsUsuario(strNombreApp);
                objUsu.NickUsuario = this.txtNomUsuario.Text;
                objUsu.Contrasena = this.txtContrasena.Text;
                objUsu.Nombre = this.txtNombre.Text;
                objUsu.Cedula = this.txtCedula.Text;                

                if (!objUsu.CrearUsuario())
                {
                    this.lblMensaje.Text = objUsu.Error;
                    this.pnlAlerta.Visible = true;
                    objUsu = null;
                    return;
                }

                if (objUsu.Respuesta == 0)
                {
                    this.lblMensaje.Text = "El usuario ya se encuentra registrado";
                    this.pnlAlerta.Visible = true;
                    objUsu = null;
                    return;
                }
                else
                {
                    this.lblMensaje.Text = "Nuevo usuario registrado con exito";
                    this.pnlAlerta.Visible = true;
                    objUsu = null;
                    return;
                }

            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
                this.pnlAlerta.Visible = true;
                return;
            }
        }
        #endregion

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.MostrarMenu();
            if (!IsPostBack)
            {
                strNombreApp = Assembly.GetExecutingAssembly().GetName().Name;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar();
        }
        #endregion


    }
}