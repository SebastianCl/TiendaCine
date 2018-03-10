using libConexionBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCinema1
{
    public class clsProducto
    {
        #region "CONSTRUCTOR"
        public clsProducto(string strNomApp)
        {
            strNombreApp = strNomApp;
            strError = string.Empty;
            intRpta = -1;
        }
        #endregion

        #region "ATRIBUTOS"
        string strNombreApp;
        string strNombreProducto;
        string strPrecio;
        string strIdProducto;
        string strError;
        int intRpta;
        SqlParameter[] objParametrosSQL;
        SqlDataReader objReader;

        #endregion

        #region "PROPIEDADES"
        public string NombreProducto
        {
            set
            {
                strNombreProducto = value;
            }

            get
            {
                return strNombreProducto;
            }
        }

        public string Precio
        {
            set
            {
                strPrecio = value;
            }
            get
            {
                return strPrecio;
            }
        }

        public string IdProducto
        {
            set
            {
                strIdProducto = value;
            }
        }

        public string Error
        {
            get
            {
                return strError;
            }            
        }
        public int Respuesta
        {
            get
            {
                return intRpta;
            }
        }

        #endregion

        #region "METODOS PRIVADOS"
        private bool Validar(string strOpcion)
        {
            switch (strOpcion)
            {
                case "BUSCAR":
                    if (strIdProducto== string.Empty)
                    {
                        strError = "Debe ingresar un codigo de producto para realizar una busqueda";
                        return false;
                    }
                    break;
                case "REGISTRAR":
                    if (strNombreProducto == string.Empty)
                    {
                        strError = "Debe ingresar el nombre para registrar un nuevo producto";
                        return false;
                    }
                    if (strPrecio == string.Empty)
                    {
                        strError = "Debe ingresar el precio del producto";
                        return false;
                    }
                    if (strIdProducto == string.Empty)
                    {
                        strError = "Debe ingresar un codigo unico para el producto";
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
                        objParametrosSQL[0] = new SqlParameter("@idprod", strIdProducto);
                        break;
                    case "REGISTRAR":
                        objParametrosSQL = new SqlParameter[3];

                        objParametrosSQL[0] = new SqlParameter("@idprod", strIdProducto);
                        objParametrosSQL[1] = new SqlParameter("@precio", strPrecio);
                        objParametrosSQL[2] = new SqlParameter("@nombre", strNombreProducto);
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
        public bool CrearProducto()
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
                objConexion.SQL = "SP_crearProducto";
                objConexion.ParametrosSQL = objParametrosSQL;

                if (!objConexion.ConsultarValorUnico(true, true))
                {
                    strError = objConexion.Error;
                    objConexion.CerrarCnx();
                    objConexion = null;
                    return false;
                }
                intRpta = Convert.ToInt16(objConexion.Valor_Unico);
                objConexion.CerrarCnx();
                objConexion = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool BuscarProducto()
        {
            try
            {
                if (!CrearParametros("BUSCAR"))
                {
                    strError = "Hubo un error al crear los parametros SQL";
                    return false;
                }
                clsConexionBD objConexion = new clsConexionBD(strNombreApp);
                objConexion.SQL = "SP_BuscarProducto";
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
                    strError = "El producto con codigo " + strIdProducto + " no existe";
                    objReader.Close();
                    objConexion = null;
                    return false;
                }
                objReader.Read();
                strNombreProducto = objReader.GetString(0);
                strPrecio = objReader.GetString(1);
                objReader.Close();
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
