using libConexionBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libCinema1;

namespace libCinema1
{
    public class clsCliente
    {

        #region "Constructor"
        public clsCliente(string strNomApp)
        {
            strNombreApp = strNomApp;
            strError = string.Empty;
            intRpta = -1;
        }
        #endregion

        #region "Atributos"
        string strDocumento;
        string strNombreCliente;
        string strEmail;
        string strNombreApp;
        string strError;
        int intRpta;
        SqlParameter[] objParameterSQL;
        SqlDataReader objReader;

        #endregion

        #region "Propiedades"
        public string Documento
        {
            set
            {
                strDocumento = value;
            }
        }

        public string Nombre
        {
            set
            {
                strNombreCliente = value;
            }

            get
            {
                return strNombreCliente;
            }
        }

        public string Email
        {
            set
            {
                strEmail = value;
            }
            get
            {
                return strEmail;
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

        #region "Metodos Privados"
        private bool Validar(string strOpcion)
        {
            switch (strOpcion)
            {
                case "BUSCAR":
                    if (strDocumento==string.Empty)
                    {
                        strError = "Debe ingresar el documento para realizar una busqueda";
                        return false;
                    }
                    break;
                case "REGISTRAR":
                    if (strDocumento == string.Empty)
                    {
                        strError = "Debe ingresar el documento para registrar un nuevo cliente";
                        return false;
                    }
                    if (strNombreCliente == string.Empty)
                    {
                        strError = "Debe ingresar el nombre para registrar un nuevo cliente";
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
                        objParameterSQL = new SqlParameter[1];

                        objParameterSQL[0] = new SqlParameter("@id_cliente",strDocumento);                        
                        break;
                    case "REGISTRAR":
                        objParameterSQL = new SqlParameter[3];

                        objParameterSQL[0] = new SqlParameter("@id_cliente", strDocumento);
                        objParameterSQL[1] = new SqlParameter("@nombre", strNombreCliente);
                        objParameterSQL[2] = new SqlParameter("@email", strEmail);
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

        #region "Metodos Publicos"
        public bool CrearCliente()
        {
            try
            {
                if (!Validar("REGISTRAR"))
                {
                    return false;
                }
                if (!CrearParametros("REGISTRAR"))
                {
                    strError = "Hubo un error al momento de crear los parametros";
                    return false;
                }
                clsConexionBD objConexion = new clsConexionBD(strNombreApp);
                objConexion.SQL = "SP_crearCliente";
                objConexion.ParametrosSQL = objParameterSQL;

                if (!objConexion.ConsultarValorUnico(true, true))
                {
                    strError = objConexion.Error;
                    objConexion.CerrarCnx();
                    objConexion = null;
                    return false;
                }
                intRpta = Convert.ToInt16(objConexion.Valor_Unico);
                objConexion.CerrarCnx();
                objConexion= null;
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool BuscarCliente()
        {
            try
            {
                if (!CrearParametros("BUSCAR"))
                {
                    strError = "Hubo un error al crear los parametros SQL";
                    return false;
                }
                clsConexionBD objConexion = new clsConexionBD(strNombreApp);
                objConexion.SQL = "SP_BuscarCliente";
                objConexion.ParametrosSQL = objParameterSQL;

                if (!objConexion.Consultar(true,true))
                {
                    strError = objConexion.Error;
                    objConexion.CerrarCnx();
                    objConexion = null;
                    return false;
                }

                objReader = objConexion.DataReader_Lleno;

                if (!objReader.HasRows)
                {
                    strError = "El cliente con documento " + strDocumento + " no existe";
                    objReader.Close();
                    objConexion = null;
                    return false;
                }
                objReader.Read();
                strNombreCliente = objReader.GetString(0);
                strEmail = objReader.GetString(1);
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
