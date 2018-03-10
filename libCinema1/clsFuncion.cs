using libConexionBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCinema1
{
    public class clsFuncion
    {
        #region CONSTRUCTOR
        public clsFuncion(string strNombreAplicacion)
        {
            strNombreApp = strNombreAplicacion;
            strError = string.Empty;
            intRpta = -1;
        }
        #endregion

        #region ATRIBUTOS
        private string strNombreApp;
        private string strFecha;
        private string strPelicula;
        private int intIdSucursal;
        private string strError;
        private int? intIDFuncion;
        private int intRpta;
        private SqlParameter[] objParamSQL;
        private SqlDataReader objReader;
        #endregion

        #region PROPIEDADES
        public string Fecha
        {
            set
            {
                strFecha = value;
            }
        }


        public string Pelicula
        {
            set
            {
                strPelicula = value;
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

        public int IdSucursal
        {
            set
            {
                intIdSucursal = value;
            }
        }

        #endregion

        #region METODOS PRIVADOS
        private bool Validar()
        {
            if (string.IsNullOrEmpty(strFecha.Trim()))
            {
                strError = "Debe ingresar la fecha de la función";
                return false;
            }
            if (string.IsNullOrEmpty(strPelicula.Trim()))
            {
                strError = "Debe el nombre de la pelicula que sera proyectada en dicha fecha";
                return false;
            }
            if (intIdSucursal == 0)
            {
                strError = "Debe seleccionar la sucursal donde se realizara la funció";
                return false;
            }
            return true;
        }

        private bool CrearParametros()
        {
            try
            {
                objParamSQL = new SqlParameter[4];
                objParamSQL[0] = new SqlParameter("@cod_fun", intIDFuncion);
                objParamSQL[1] = new SqlParameter("@fecha", strFecha);
                objParamSQL[2] = new SqlParameter("@pelicula", strPelicula);
                objParamSQL[3] = new SqlParameter("@cod_sucur", intIdSucursal.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool AsignarPK_Funcion()
        {
            try
            {
                clsConexionBD objCnx = new clsConexionBD(strNombreApp);
                objCnx.SQL = "SP_ObtenerIDFuncion";
                if (!objCnx.Consultar(false, true))
                {
                    strError = objCnx.Error;
                    objCnx.CerrarCnx();
                    objCnx = null;
                    return false;
                }
                objReader = objCnx.DataReader_Lleno;
                if (!objReader.HasRows)
                {
                    strError = "No se genero una PK para esta función";
                    objReader.Close();
                    objCnx.CerrarCnx();
                    objCnx = null;
                    return false;
                }
                objReader.Read();
                intIDFuncion = objReader.GetInt32(0);
                if (intIDFuncion == 0)
                {
                    intIDFuncion = 1;
                }
                else
                {
                    intIDFuncion += 1;
                }
                objReader.Close();
                objCnx.CerrarCnx();
                objCnx = null;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region METODOS PUBLICOS
        public bool CrearFuncion()
        {
            try
            {
                if (!Validar())
                {
                    return false;
                }
                if (!AsignarPK_Funcion())
                {
                    return false;
                }
                if (!CrearParametros())
                {
                    strError = "Error en la creacion de parametros";
                    return false;
                }
                clsConexionBD objCnx = new clsConexionBD(strNombreApp);
                objCnx.SQL = "SP_RegistrarFuncion";
                objCnx.ParametrosSQL = objParamSQL;
                if (!objCnx.ConsultarValorUnico(true, true))
                {
                    strError = objCnx.Error;
                    objCnx.CerrarCnx();
                    objCnx = null;
                    return false;
                }
                intRpta = Convert.ToInt16(objCnx.Valor_Unico);
                objCnx.CerrarCnx();
                objCnx = null;
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


