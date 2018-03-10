using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libConexionBD;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using libLlenarCombos;

namespace libCinema1
{
    public class clsVenta
    {
        #region "Constructor"
        public clsVenta(string strNomApp)
        {
            strNombreApp = strNomApp;
        }
        #endregion

        #region "Atributos"
        string strNombreApp;
        string strFecha;
        string strCodigoProducto;
        string strCantidad;
        string strError;
        DropDownList ddlGenerico;
        SqlParameter[] objParametrosSQL;
        SqlDataReader objReader;
        #endregion

        #region "Propiedades"        

        public string Fecha
        {
            set
            {
                strFecha = value;
            }
        }

        public string CodigoProducto
        {
            get
            {
                return strCodigoProducto;
            }

            set
            {
                strCodigoProducto = value;
            }
        }

        public string Cantidad
        {
            set
            {
                strCantidad = value;
            }
        }

        public string Error
        {
            get
            {
                return strError;
            }
            
        }

        public DropDownList Combo_A_Llenar
        {
            set
            {
                ddlGenerico = value;
            }
        }



        #endregion

        #region "METODOS PRIVADOS"
        private bool Validar(string strOpc)
        {
            switch (strOpc)
            {
                case "LLENAR":
                    if (ddlGenerico == null)
                    {
                        strError = "No enviaron el DropDownList para ser llenado";
                        return false;
                    }
                    break;
                case "REGISTRAR":
                    if (strCodigoProducto == string.Empty)
                    {
                        strError = "Debe indicar un codigo de producto";
                        return false;
                    }
                    if (strCantidad == string.Empty)
                    {
                        strError = "Debe indicar la cantidad del producto";
                        return false;
                    }
                    break;
            }
            return true;
        }

        private bool CrearParametros(string strTipo)
        {
            try
            {
                //objParametrosSQL = new SqlParameter[3];

                //objParametrosSQL[0] = new SqlParameter("@cod_encabezado", cod_encabezado);
                //objParametrosSQL[1] = new SqlParameter("@fechaventa",strFecha);
                //objParametrosSQL[2] = new SqlParameter("@id_cliente",idcliente);
                //objParametrosSQL[3] = new SqlParameter("@nombre_sucur", nombre_sucur);
                //objParametrosSQL[4] = new SqlParameter("@cod_vendedor", cod_vendedor);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "METODOS PUBLICOS"
        public bool LLenar_ListaProducto()
        {
            try
            {
                if (!Validar("LLENAR"))
                {
                    return false;
                }
                clsLlenarCombos _objLlenar = new clsLlenarCombos(strNombreApp);
                _objLlenar.SQL = "SP_ListarProductos";
                _objLlenar.CampoID = "Id_Producto";
                _objLlenar.CampoTexto = "nombre";

                if (!_objLlenar.LlenarCombo_Web(ddlGenerico))
                {
                    strError = _objLlenar.Error;
                    _objLlenar = null;
                    return false;
                }
                _objLlenar = null;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
