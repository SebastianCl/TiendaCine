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
    public partial class frmVentas : System.Web.UI.Page
    {
        #region Variables Globales
        private static string strNombreApp;
        #endregion

        #region "Metodos Privados"
        private bool ValidarDoc()
        {
            if (this.txtDocumento.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar el documento del cliente";
                this.pnlAlerta.Visible = true;
                return false;
            }
            return true;
        }

        private bool validarRegistro()
        {
            if (this.txtFecha.Text==string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar la fecha";
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.ddlProducto.SelectedValue == "Seleccione")
            {
                this.lblMensaje.Text = "Seleccione un producto";
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.txtCantidad.Text == string.Empty)
            {
                this.lblMensaje.Text = "Especifique la cantidad de productos";
                this.pnlAlerta.Visible = true;
                return false;
            }
            return true;
        }
        private void Buscar()
        {
            try
            {
                if (!ValidarDoc())
                {
                    return;
                }
                clsCliente objCliente = new clsCliente(strNombreApp);
                objCliente.Documento = this.txtDocumento.Text;

                if (!objCliente.BuscarCliente())
                {
                    this.lblMensaje.Text = objCliente.Error;
                    this.pnlAlerta.Visible = true;
                    this.pnlBotones.Visible = true;
                    objCliente = null;
                    return;
                }
                this.txtNombre.Text = objCliente.Nombre;
                this.txtNombre.Enabled = false;
                this.pnlVenta.Visible = true;
                this.pnlAlerta.Visible = false;
                this.txtDocumento.Enabled = false;
                this.btnContinuar.Visible = false;
                this.btnRegistrar.Visible = true;
                this.pnlBotones.Visible = false;                        
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
                this.pnlAlerta.Visible = true;
                return;
            }
        }

        private void LlenarListaProductos()
        {
            try
            {
                clsVenta objVen = new clsVenta(strNombreApp);
                objVen.Combo_A_Llenar = this.ddlProducto;

                if (!objVen.LLenar_ListaProducto())
                {
                    this.lblMensaje.Text = objVen.Error;
                    this.pnlAlerta.Visible = true;
                    objVen = null;
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
            
            this.pnlAlerta.Visible = false;
            if (this.txtNombre.Text==string.Empty)
            {
                this.pnlVenta.Visible = false;
            }
            else
            {
                this.pnlVenta.Visible = true;
            }

            if (!IsPostBack)
            {
                strNombreApp = Assembly.GetExecutingAssembly().GetName().Name;
                LlenarListaProductos();
            }            
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.pnlVenta.Visible = true;
            validarRegistro();
        }

        protected void btnRegistarCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmFactura.aspx");          
            
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCliente.aspx");
        }
        #endregion


    }
}