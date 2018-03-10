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
    public class clsSucursal
    {
        #region "CONSTRUCTOR"
        public clsSucursal(string strNomApp)
        {
            strNombreApp = strNomApp;
            strError = string.Empty;
            intRpta = -1;
        }
        #endregion

        #region "ATRIBUTOS"
        string strNombreApp;
        string strCod_sucursal;
        string strNombreSucursal;
        string strDireccion;
        string strError;
        int intRpta;
        DropDownList ddlGenerico;
        SqlParameter[] objParametrosSQL;
        SqlDataReader objReader;

        #endregion

        #region "PROPIEDADES"
        public string CodidoSucursal
        {
            set
            {
                strCod_sucursal = value;
            }
        }

        public int Respuesta
        {
            get
            {
                return intRpta;
            }
        }

        public string NombreSucursal
        {
            set
            {
                strNombreSucursal = value;
            }
        }

        public string Direccion
        {
            set
            {
                strDireccion = value;
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
        private bool Validar(string strOpcion)
        {
            switch (strOpcion)
            {
                case "BUSCAR":
                    if (strNombreSucursal == string.Empty)
                    {
                        strError = "Debe ingresar el nombre para realizar una busqueda";
                        return false;
                    }
                    break;
                case "REGISTRAR":
                    if (strCod_sucursal == string.Empty)
                    {
                        strError = "Debe ingresar un codigo para registrar una sucursal";
                        return false;
                    }
                    if (strNombreSucursal == string.Empty)
                    {
                        strError = "Debe ingresar el documento para registrar un nuevo cliente";
                        return false;
                    }
                    if (strDireccion == string.Empty)
                    {
                        strError = "Debe ingresar la direccion para registrar un nuevo cliente";
                        return false;
                    }
                    break;
                case "LLENAR":
                    if (ddlGenerico == null)
                    {
                        strError = "No enviaron el DropDownList para ser llenado";
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
                switch (strTipo)
                {
                    case "BUSCAR":
                        objParametrosSQL = new SqlParameter[1];
                        objParametrosSQL[0] = new SqlParameter("@cod_cliente", strCod_sucursal);
                        break;
                    case "REGISTRAR":
                        objParametrosSQL = new SqlParameter[3];

                        objParametrosSQL[0] = new SqlParameter("@cod_sucur", strCod_sucursal);
                        objParametrosSQL[1] = new SqlParameter("@nombre", strNombreSucursal);
                        objParametrosSQL[2] = new SqlParameter("@direccion", strDireccion);
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "METODOS PUBLICOS"
        public bool CrearSucursal()
        {
            try
            {
                if (!Validar("REGISTRAR"))
                {
                    return false;
                }
                if (!CrearParametros("REGISTRAR"))
                {
                    strError = "Hubo un error al momento de crear los parametros SQL";
                    return false;
                }
                clsConexionBD objConexion = new clsConexionBD(strNombreApp);
                objConexion.SQL = "SP_crearSucursal";
                objConexion.ParametrosSQL = objParametrosSQL;

                if (!objConexion.ConsultarValorUnico(true, true))
                {
                    strError = objConexion.Error;
                    objConexion.CerrarCnx();
                    objConexion = null;
                    return false;
                }
                objConexion.CerrarCnx();
                objConexion = null;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool BuscarSucursal()
        {
            try
            {
                if (!CrearParametros("BUSCAR"))
                {
                    strError = "Hubo un error al crear los parametros SQL";
                    return false;
                }
                clsConexionBD objConexion = new clsConexionBD(strNombreApp);
                objConexion.SQL = "SP_BuscarSucursal";
                objConexion.ParametrosSQL = objParametrosSQL;

                if (!objConexion.Consultar(true, true))
                {
                    strError = objConexion.Error;
                    objConexion.CerrarCnx();
                    objConexion = null;
                    return false;
                }

                objReader = objConexion.DataReader_Lleno;

                if (!objReader.HasRows)
                {
                    strError = "La sucursal con documento " + strCod_sucursal + " no existe";
                    objReader.Close();
                    objConexion = null;
                    return false;
                }
                intRpta = Convert.ToInt16(objConexion.Valor_Unico);
                objReader.Read();
                strNombreSucursal = objReader.GetString(1);
                objReader.Close();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool LLenar_ListaSucursles()
        {
            try
            {
                if (!Validar("LLENAR"))
                {
                    return false;
                }
                clsLlenarCombos _objLlenar = new clsLlenarCombos(strNombreApp);
                _objLlenar.SQL = "SP_ListarSucursales";
                _objLlenar.CampoID = "Id_Sucursal";
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
