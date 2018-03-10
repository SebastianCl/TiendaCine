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
    public partial class frmCrearProdcutoaspx : System.Web.UI.Page
    {
        #region "VARIABLES"
        private static string strNombreApp;
        #endregion

        #region "METODOS PRIVADOS"
        private bool ValidarCampos()
        {
            if (this.txtCodigoProducto.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar un Codigo para registrar un producto";
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.txtNombre.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar el nombre del producto";
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.txtPrecio.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar el precio del producto";
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
                clsProducto objProd = new clsProducto(strNombreApp);
                objProd.IdProducto = this.txtCodigoProducto.Text;
                objProd.NombreProducto = this.txtNombre.Text;
                objProd.Precio = this.txtPrecio.Text;

                if (!objProd.CrearProducto())
                {
                    this.lblMensaje.Text = objProd.Error;
                    this.pnlAlerta.Visible = true;
                    objProd = null;
                    return;
                }
                if (objProd.Respuesta == 0)
                {
                    this.lblMensaje.Text = "Este producto ya se encuentra registrado";
                    this.pnlAlerta.Visible = true;                    
                    objProd = null;
                    return;
                }
                else
                {
                    this.lblMensaje.Text = "Nuevo Producto registrado con exito";
                    this.pnlAlerta.Visible = true;
                    objProd = null;
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

        #region "EVENTOS"
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.MostrarMenu();
            this.pnlAlerta.Visible = false;
            if (!IsPostBack)
            {
                strNombreApp = Assembly.GetExecutingAssembly().GetName().Name;
            }
        }
        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Registrar();
        }
        #endregion

    }
}