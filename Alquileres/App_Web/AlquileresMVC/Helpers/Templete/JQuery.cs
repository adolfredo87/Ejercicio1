using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace AlquileresMVC.Helpers
{
    internal partial class HtmlTemplete
    {
        public class JQuery
        {
            public static String FunctionParametersData(String queryStrings)
            {
                StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
                sb.Append("var getParametersData  = function() { ");
                sb.Append("var parametersData = {};");
                String[] parametros = queryStrings.Split('&');
                foreach (String p in parametros)
                {
                    String[] parValue = p.Split('=');
                    if (parValue.Count() == 2)
                    {
                        String pName = "parametersData." + parValue[0].Trim();                    //
                        String pId = parValue[1].Trim().Replace("model.", "").Replace(".", "_");
                        String pValue = String.Format("mvcLocal.autocomplete.getValue('{0}')", pId); ;
                        sb.Append(pName + "=" + pValue + ";");
                    }
                }
                sb.Append("return parametersData;};");

                return sb.ToString();
            }

            public static String BeginReadyFunction()
            {
                return "$(function() {";
            }
            public static String EndReadyFunction()
            {
                return "});";
            }

            public static String ReadyFunction(String functionBody)
            {
                return BeginReadyFunction() + functionBody + EndReadyFunction();
            }

            public static String LoadControl(String nameControl)
            {
                return "$('#" + nameControl + "')";
            }
        }
    }
}