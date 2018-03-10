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
    public partial class frmCrearSucursal : System.Web.UI.Page
    {
        #region "VARIABLES"
        private static string strNombreApp;
        #endregion

        #region "METODOS PRIVADOS"
        private bool ValidarCampos()
        {
            if (this.txtCodigoSucursal.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe especificar un codigo para la nueva sucursal";
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.txtSede.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar el nombre de la sede";
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.txtUbicacion.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar la ubicación";
                this.pnlAlerta.Visible = true;
                return false;
            }
            return true;
        }

        public void Registrar()
        {
            try
            {
                if (!ValidarCampos())
                {
                    return;
                }
                clsSucursal objSucur = new clsSucursal(strNombreApp);
                objSucur.CodidoSucursal = this.txtCodigoSucursal.Text;
                objSucur.NombreSucursal = this.txtSede.Text;
                objSucur.Direccion = this.txtUbicacion.Text;


                if (!objSucur.CrearSucursal())
                {
                    this.lblMensaje.Text = objSucur.Error;
                    this.pnlAlerta.Visible = true;
                    objSucur = null;
                    return;
                }
                if (objSucur.Respuesta== 0)
                {
                    this.lblMensaje.Text = "La sucursal que intenta registrar se encuentra registrada";
                    this.pnlAlerta.Visible = true;
                    objSucur = null;
                    return;
                }
                else
                {
                    this.lblMensaje.Text = "Nueva sucursal registrada con exito";
                    this.pnlAlerta.Visible = true;
                    objSucur = null;
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

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.MostrarMenu();
            this.pnlAlerta.Visible = false;
            if (!IsPostBack)
            {
                strNombreApp = Assembly.GetExecutingAssembly().GetName().Name;
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Registrar();
        }
        #endregion


    }
}