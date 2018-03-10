using libConexionBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCinema1
{
    public class clsUsuario
    {
        #region "Constructor"
        public clsUsuario(String strNomApp)
        {
            strNombreApp = strNomApp;
            strError = string.Empty;
            intRpta = -1;
        }
        #endregion

        #region "Atributos"
        string strNombre;
        string strNickUsuario;
        string strContrasena;
        string strCedula;        
        string strError;
        string strNombreApp;
        int intRpta;
        SqlParameter[] objParameterSQL;
        SqlDataReader objReader;
        #endregion

        #region "Propiedades"

        public string Nombre
        {
            set
            {
                strNombre = value;
            }
        }

        public string NickUsuario
        {
            set
            {
                strNickUsuario = value;
            }
        }

        public string Contrasena
        {

            set
            {
                strContrasena = value;
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

        public string Cedula
        {
            set
            {
                strCedula = value;
            }
        }

        #endregion

        #region "Metodos Privados"
        private bool Validar(string strOpcion)
        {
            switch (strOpcion)
            {
                case "BUSCAR":
                    if (strCedula == string.Empty)
                    {
                        strError = "Debe ingresar un Codigo de Usuario para realizar una busqueda";
                        return false;
                    }
                    break;
                case "REGISTRAR":
                    if (strNickUsuario == string.Empty)
                    {
                        strError = "Debe ingresar un Nombre de Usuario para registrar un nuevo usuario";
                        return false;
                    }
                    if (strNombre == string.Empty)
                    {
                        strError = "Debe ingresar el nombre para registrar un nuevo usuario";
                        return false;
                    }
                    if (strContrasena == string.Empty)
                    {
                        strError = "Debe ingresar una contraseña para registrar un nuevo usuario";
                        return false;
                    }
                    if (strCedula == string.Empty)
                    {
                        strError = "Debe ingresar la cedula para registrar un nuevo usuario";
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

                        objParameterSQL[0] = new SqlParameter("@Id_vendedor", strCedula);
                        break;
                    case "REGISTRAR":
                        objParameterSQL = new SqlParameter[4];

                        objParameterSQL[0] = new SqlParameter("@Id_vendedor",strCedula);
                        objParameterSQL[1] = new SqlParameter("@nombre", strNombre);
                        objParameterSQL[2] = new SqlParameter("@usuario", strNickUsuario);
                        objParameterSQL[3] = new SqlParameter("@contrasena",strContrasena);
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
        public bool CrearUsuario()
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
                objConexion.SQL = "SP_CrearUsuario";
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
                objConexion = null;
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool BuscarUsuario()
        {
            try
            {
                if (!CrearParametros("BUSCAR"))
                {
                    strError = "Hubo un error al crear los parametros SQL";
                    return false;
                }
                clsConexionBD objConexion = new clsConexionBD(strNombreApp);
                objConexion.SQL = "SP_CrearUsuario";
                objConexion.ParametrosSQL = objParameterSQL;

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
                    strError = "El usuario con codigo " + strCedula + " no existe";
                    objReader.Close();
                    objConexion = null;
                    return false;
                }
                objReader.Read();
                strNombre = objReader.GetString(1);
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
