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
    public partial class frmCrearCliente : System.Web.UI.Page
    {
        #region "VARIABLES"
        private static string strNombreApp;
        #endregion

        #region "METODOS PRIVADOS"
        private bool ValidarCampos()
        {
            if (this.txtDocumento.Text.Trim()==string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar el documento del cliente";                
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.txtNombre.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar el nombre del cliente";                
                this.pnlAlerta.Visible = true;
                return false;
            }
            if (this.txtEmail.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar el Email del cliente";                
                this.pnlAlerta.Visible = true;
                return false;
            }
            return true;
        }

        private bool validarBusqueda()
        {
            if (this.txtDocumento.Text.Trim() == string.Empty)
            {
                this.lblMensaje.Text = "Debe ingresar el documento del cliente para realizar una busqueda";
                this.pnlAlerta.Visible = true;
                return false;
            }
            return true;
        }

        private void Registrar() {
            try
            {
                if (!ValidarCampos())
                {
                    return;
                }
                clsCliente objCliente = new clsCliente(strNombreApp);
                objCliente.Documento = this.txtDocumento.Text;
                objCliente.Nombre = this.txtNombre.Text;
                objCliente.Email = this.txtEmail.Text;

                if (!objCliente.CrearCliente())
                {
                    this.lblMensaje.Text = objCliente.Error;
                    this.pnlAlerta.Visible = true;
                    objCliente = null;
                    return;
                }
                if (objCliente.Respuesta == 0)
                {
                    this.lblMensaje.Text = "El cliente ya se encuentra registrado";
                    this.pnlAlerta.Visible = true;
                    objCliente = null;
                    return;
                }
                else
                {
                    this.lblMensaje.Text = "Cliente registrado con exito";
                    this.pnlAlerta.Visible = true;
                    objCliente = null;
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

        private void Buscar()
        {
            try
            {
                if (!validarBusqueda())
                {
                    return;
                }
                clsCliente objCliente = new clsCliente(strNombreApp);
                objCliente.Documento = this.txtDocumento.Text;
                

                if (!objCliente.BuscarCliente())
                {
                    this.lblMensaje.Text = objCliente.Error;
                    this.pnlAlerta.Visible = true;
                    objCliente = null;
                    return;
                }
                this.txtNombre.Text = objCliente.Nombre;
                this.txtEmail.Text = objCliente.Email;
                this.txtNombre.Enabled = false;
                this.txtEmail.Enabled = false;
                this.pnlAlerta.Visible = false;

            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
                this.pnlAlerta.Visible = true;
                return;
            }
        }

        private void Limpiar()
        {
            this.txtDocumento.Text = string.Empty;            
            this.txtNombre.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.pnlAlerta.Visible = false;
            this.txtNombre.Enabled = true;
            this.txtEmail.Enabled = true;
        }
        #endregion

        #region "EVENTOS"
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.MostrarMenu();
            if (!IsPostBack)
            {
                strNombreApp = Assembly.GetExecutingAssembly().GetName().Name;
            }
            this.pnlAlerta.Visible = false;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        #endregion


    }
}