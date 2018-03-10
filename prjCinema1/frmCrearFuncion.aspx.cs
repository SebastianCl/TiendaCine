using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libCinema1;
using System.Reflection;

namespace prjCinema1
{
    public partial class frmFuncionPelicula : System.Web.UI.Page
    {
        #region VARIABLES GOLABALES
        private static string strNombreApp;
        #endregion

        #region METODOS PRIVADOS
        private void LlenarListaSucursales()
        {
            try
            {
                clsSucursal objSuc = new clsSucursal(strNombreApp);
                objSuc.Combo_A_Llenar = this.ddlSucursal;
                if (!objSuc.LLenar_ListaSucursles())
                {
                    this.lblMensaje.Text = objSuc.Error;
                    this.pnlAlerta.Visible = true;
                    objSuc = null;
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

        private bool Validar()
        {
            if (this.txtPelicula.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar el nombre de la pelicula";
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.txtFecha.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar la fecha para la función";
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.ddlSucursal.SelectedValue == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar el nombre de la sucursal";
                this.pnlAlerta.Visible = true;
                return false;
            }
            return true;
        }

        private void CrearFuncion()
        {
            try
            {
                if (!Validar())
                {
                    this.lblMensaje.Visible = true;
                    return;
                }
                clsFuncion objFun = new clsFuncion(strNombreApp);
                objFun.Fecha = this.txtFecha.Text;
                objFun.Pelicula = this.txtPelicula.Text;
                objFun.IdSucursal = this.ddlSucursal.SelectedIndex;
                if (!objFun.CrearFuncion())
                {
                    this.lblMensaje.Text = objFun.Error;
                    this.lblMensaje.Visible = true;
                    objFun = null;
                    return;
                }
                if (objFun.Respuesta == 0)
                {
                    this.lblMensaje.Text = "La función ya se encuentra registrada";
                    this.pnlAlerta.Visible = true;
                    objFun = null;
                    return;
                }
                else
                {
                    this.txtFecha.Text = string.Empty;
                    this.txtPelicula.Text = string.Empty;
                    this.ddlSucursal.SelectedIndex = 0;
                    this.lblMensaje.Text = "Nueva función registrada con éxito";
                    this.pnlAlerta.Visible = true;
                    objFun = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
                this.pnlAlerta.Visible = true;
            }

        }
        #endregion

        #region "EVENTOS"

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.MostrarMenu();
            this.pnlAlerta.Visible = false;
            if (!IsPostBack)
            {
                strNombreApp = Assembly.GetExecutingAssembly().GetName().Name;
                LlenarListaSucursales();                
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CrearFuncion();
        }
        #endregion

    }
}