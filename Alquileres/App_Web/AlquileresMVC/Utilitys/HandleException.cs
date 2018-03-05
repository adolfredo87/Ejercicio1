using System;
using System.IO;
using System.Xml;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace AlquileresMVC.Utilitys
{
    public class HandleException
    {
        #region << ATRIBUTOS PRIVADOS: Declaracion e Inicializacion >>
        private string appPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
        private string configFile = "";
        private string _nombreTraza = "AlquileresWeb.trace";
        private string _separador = "\\";
        private string _rutaTraza = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
        private void InicializarExcepcion()
        {
            appPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            configFile = Path.Combine(appPath, "Utilidad.HandleException.config");
            if (!string.IsNullOrEmpty(ObtenerNombreTraza()))
            {
                _nombreTraza = ObtenerNombreTraza();
            }
            else
            {
                _nombreTraza = "AlquileresWeb.trace";
            }
            if (!string.IsNullOrEmpty(ObtenerSeparador()))
            {
                _separador = ObtenerSeparador();
            }
            else
            {
                _separador = "\\";
            }
            if (!string.IsNullOrEmpty(ObtenerRutaTraza()))
            {
                _rutaTraza = ObtenerRutaTraza();
            }
            else
            {
                _rutaTraza = appPath + "\\Logs";
            }
        }
        #endregion

        #region << METODOS PUBLICOS: EscribirLogExcepcion - RegistrarExcepcion >>
        public void EscribirLogExcepcion(string valor)
        {
            InicializarExcepcion();
            CrearDirectorio();
            EscribirLinea(valor);
        }
        public String RegistrarExcepcion(Exception excepcion, String origen)
        {
            string mensaje = "";
            try
            {
                if (excepcion is System.ApplicationException)
                {
                    System.ApplicationException exc = (System.ApplicationException)excepcion;
                    mensaje = EscribirApplicationException(exc, origen);

                }
                else if (excepcion is System.IO.InvalidDataException)
                {
                    System.IO.InvalidDataException exc = (System.IO.InvalidDataException)excepcion;
                    mensaje = EscribirInvalidDataException(exc, origen);

                }
                else if (excepcion is System.IO.IOException)
                {
                    System.IO.IOException exc = (System.IO.IOException)excepcion;
                    mensaje = EscribirIOEx(exc, origen);

                }
                else if (excepcion is System.FormatException)
                {
                    System.FormatException exc = excepcion as System.FormatException;
                    mensaje = EscribirFormatException(exc, origen);

                }
                else if (excepcion is System.Data.SqlClient.SqlException)
                {
                    System.Data.SqlClient.SqlException exc = excepcion as System.Data.SqlClient.SqlException;
                    mensaje = EscribirSqlEx(exc, origen);

                }
                else if (excepcion is System.Data.OleDb.OleDbException)
                {
                    System.Data.OleDb.OleDbException exc = excepcion as System.Data.OleDb.OleDbException;
                    mensaje = EscribirOleDbEx(exc, origen);

                }
                else
                {
                    mensaje = EscribirGenericEx(excepcion, origen);
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error interno de la Aplicación. Por favor informar a Sopórte Técnico.\n\n";
                mensaje = mensaje + EscribirLocalEx(ex, this.ToString() + ".RegistrarExcepcion");
            }
            return mensaje;
        }
        #endregion

        #region << FUNCIONES PUBLICAS: HandleExceptionEx >>
        public String HandleExceptionEx(Exception ex)
        {
            /// ESCRIBIR CODIGO PARA EL MANEJO DE TODAS LAS EXCEPCIONES Y DE LOS MENSAJES EMITIDOS AL CLIENTE

            //String errorMessage = exception.InnerException.ToString();
            Console.WriteLine(ex.StackTrace);
            String errorMessage = ex.Message;
            return errorMessage;
        }
        public String HandleExceptionEx(String title, Exception ex)
        {
            /// ESCRIBIR CODIGO PARA EL MANEJO DE TODAS LAS EXCEPCIONES Y DE LOS MENSAJES EMITIDOS AL CLIENTE

            Console.WriteLine(ex.StackTrace);
            String error = ex.InnerException.ToString();
            return title + ":<b> " + error;
        }
        public String HandleExceptionEx(String title, String message, Exception ex)
        {
            /// ESCRIBIR CODIGO PARA EL MANEJO DE TODAS LAS EXCEPCIONES Y DE LOS MENSAJES EMITIDOS AL CLIENTE

            Console.WriteLine(ex.StackTrace);
            return title + ":<b> " + message;
        }
        #endregion

        #region << FUNCIONES PRIVADAS: Mensajes de Exceptiones >>
        private static String EscribirSqlEx(SqlException ex, string origenEx)
        {
            string Linea = "SQLEXCEPTION OCURRIDA EN: " + origenEx + "\n";
            Linea = Linea + "FECHA: " + System.DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + "\n";
            Linea = Linea + "FUENTE: " + ex.Source + "\n";
            Linea = Linea + "NÚMERO: " + ex.Number.ToString() + "\n";
            Linea = Linea + "LÍNEA: " + ex.LineNumber.ToString() + "\n";
            Linea = Linea + "MESAJE: " + ex.Message + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "SERVIDOR       : " + ex.Server + "\n";
            Linea = Linea + "PROCEDIMIENTO  : " + ex.Procedure + "\n";
            Linea = Linea + "STACK          : " + ex.StackTrace.ToString() + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "" + "\n";
            return Linea;
        }
        private static String EscribirOleDbEx(OleDbException ex, string origenEx)
        {
            string Linea = "SQLEXCEPTION OCURRIDA EN: " + origenEx + "\n";
            Linea = Linea + "FECHA: " + System.DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + "\n";
            Linea = Linea + "FUENTE: " + ex.Source + "\n";
            Linea = Linea + "MESAJE: " + ex.Message + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "CODE ERRORS    : " + ex.ErrorCode.ToString() + "\n";
            Linea = Linea + "ERRORS         : " + ex.Errors.ToString() + "\n";
            Linea = Linea + "STACK          : " + ex.StackTrace.ToString() + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "" + "\n";
            return Linea;
        }
        private static String EscribirIOEx(IOException ex, string origenEx)
        {
            string Linea = "IOEXCEPTION OCURRIDA EN: " + origenEx + "\n";
            Linea = Linea + "FECHA: " + System.DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + "\n";
            Linea = Linea + "FUENTE: " + ex.Source + "\n";
            Linea = Linea + "MESAJE: " + ex.Message + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "STACK          : " + ex.StackTrace.ToString() + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "" + "\n";
            return Linea;
        }
        private static String EscribirInvalidDataException(InvalidDataException ex, string origenEx)
        {
            string Linea = "INVALIDDATAEXCEPTION OCURRIDA EN: " + origenEx + "\n";
            Linea = Linea + "FECHA: " + System.DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + "\n";
            Linea = Linea + "FUENTE: " + ex.Source + "\n";
            Linea = Linea + "MESAJE: " + ex.Message + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "STACK          : " + ex.StackTrace.ToString() + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "" + "\n";
            return Linea;
        }
        private static String EscribirFormatException(FormatException ex, string origenEx)
        {
            string Linea = "FORMATEXCEPTION OCURRIDA EN: " + origenEx + "\n";
            Linea = Linea + "FECHA: " + System.DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + "\n";
            Linea = Linea + "FUENTE: " + ex.Source + "\n";
            Linea = Linea + "MESAJE: " + ex.Message + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "STACK          : " + ex.StackTrace.ToString() + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "" + "\n";
            return Linea;
        }
        private static String EscribirApplicationException(ApplicationException ex, string origenEx)
        {
            string Linea = "APLICATIONEXCEPTION OCURRIDA EN: " + origenEx + "\n";
            Linea = Linea + "FECHA: " + System.DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + "\n";
            if ((ex.InnerException != null))
            {
                Linea = Linea + "FUENTE: " + ex.InnerException.Message + "\n";
            }
            Linea = Linea + "MESAJE: " + ex.Message + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "STACK          : " + ex.StackTrace.ToString() + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "" + "\n";
            return Linea;
        }
        private static String EscribirGenericEx(Exception ex, string origenEx)
        {
            string Linea = "EXCEPTION OCURRIDA EN: " + origenEx + "\n";
            Linea = Linea + "FECHA          : " + System.DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + "\n";
            Linea = Linea + "FUENTE         : " + ex.Source + "\n";
            Linea = Linea + "MESAJE         : " + ex.Message + "\n";
            Linea = Linea + "TIPO EXCEPCION : " + ex.ToString() + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "STACK          : " + ex.StackTrace.ToString() + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "" + "\n";
            return Linea;
        }
        private static String EscribirLocalEx(Exception ex, string origenEx)
        {
            string Linea = "EXCEPTION OCURRIDA EN: " + origenEx + "\n";
            Linea = Linea + "FECHA: " + System.DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss") + "\n";
            Linea = Linea + "FUENTE: " + ex.Source + "\n";
            Linea = Linea + "MESAJE: " + ex.Message + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "STACK        : " + ex.StackTrace.ToString() + "\n";
            Linea = Linea + "-----------------------------------------------------------" + "\n";
            Linea = Linea + "" + "\n";
            return Linea;
        }
        #endregion

        #region << FUNCIONES PRIVADAS: Funciones >>
        private bool ExistFile()
        {
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException(string.Format("Application configuration file '{0}' not found.", configFile));
            }
            else
            {
                return true;
            }
        }
        private string CargarStringKeys(string str, string tagName)
        {
            string resul = "";
            if (ExistFile())
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(configFile);
                XmlNodeList nodeList = xmlDocument.GetElementsByTagName(tagName);
                foreach (XmlNode node in nodeList)
                {
                    foreach (XmlNode key in node.ChildNodes)
                    {
                        str = key.Attributes["value"].Value;
                        resul = str;
                    }
                }
            }
            return resul;
        }
        #endregion

        #region << FUNCIONES PRIVADAS: Nombre Traza >>
        private string nombreTraza;
        private string ObtenerNombreTraza()
        {
            nombreTraza = CargarStringKeys(nombreTraza, "nombreTraza");
            return nombreTraza;
        }        
        #endregion

        #region << FUNCIONES PRIVADAS: Separador >>
        private string separador;
        private string ObtenerSeparador()
        {
            separador = CargarStringKeys(separador, "separador");
            return separador;
        }
        #endregion

        #region << FUNCIONES PRIVADAS: Ruta Traza >>
        private string rutaTraza;
        private string ObtenerRutaTraza()
        {
            rutaTraza = CargarStringKeys(rutaTraza, "rutaTraza");
            return rutaTraza;
        }
        #endregion

        #region << METODOS PRIVADOS: Archivo - Directorio >>
        private void EscribirLinea(string valor)
        {
            StreamWriter objEscritor = default(StreamWriter);
            objEscritor = File.AppendText(_rutaTraza + _separador + _nombreTraza);
            objEscritor.WriteLine(valor);
            objEscritor.Close();
        }
        private void CrearArchivo()
        {
            //** Verificar si existe el archivo **
            if (!File.Exists(_rutaTraza + _separador + _nombreTraza))
            {
                FileStream archivo = default(FileStream);
                archivo = File.Create(_rutaTraza + _separador + _nombreTraza);
                archivo.Close();
            }
        }
        private void CrearDirectorio()
        {
            //** Verificar si existe el directorio **
            if (!Directory.Exists(_rutaTraza))
            {
                Directory.CreateDirectory(_rutaTraza);
            }

            //** Verificar si existe archivo Log **
            CrearArchivo();

            //** Verificar tamaño del archivo **
            FileInfo fInfo = new FileInfo(_rutaTraza + _separador + _nombreTraza);

            //** Si es mayor a 10MB ** 	10485760
            if ((fInfo.Length > 10240245))
            {
                //** Renombrar Log + Fecha y hora **
                fInfo.MoveTo(_rutaTraza + _separador + _nombreTraza + "_" + DateTime.Now.Day.ToString("D2") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Year.ToString("D4") + DateTime.Now.Hour.ToString("D2") + DateTime.Now.Minute.ToString("D2") + DateTime.Now.Second.ToString("D2"));

                //** Creacion nuevo archivo Log **
                CrearArchivo();
            }

        }
        private void EscribirSucesos(string sSource, string sLog, string sEvent)
        {
            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, sEvent, EventLogEntryType.Error, 234);
        }
        #endregion

    }
}