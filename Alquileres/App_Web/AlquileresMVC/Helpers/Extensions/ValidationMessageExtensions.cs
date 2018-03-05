using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;
using AlquileresMVC.Utilitys;
using System.Web.Mvc.Ajax;

namespace AlquileresMVC.Helpers
{
    public static class ValidationMessageExtensions
    {
        public static String ValidationMessage(MvcHtmlString validationMessage)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);

            //int index = validationMessage.IndexOf("</span>");
            //sb.Append(validationMessage.Substring(0, index));
            //sb.Append("        <div class='ui-widget'>".Trim());
            //sb.Append("            <div class='ui-state-error ui-corner-all'>".Trim());
            //sb.Append("                <span class='ui-icon ui-icon-alert'></span>".Trim());
            sb.Append(validationMessage);
            //sb.Append("            </div>".Trim());
            //sb.Append("         </div>".Trim());
            //sb.Append(validationMessage.Substring(index));

            return sb.ToString();
        }

        #region GetExpressionText
        internal static string GetExpressionText(LambdaExpression expression)
        {
            Stack<string> nameParts = new Stack<string>();
            Expression part = expression.Body;

            while (part != null)
            {
                if (part.NodeType == ExpressionType.MemberAccess)
                {
                    MemberExpression memberExpression = (MemberExpression)part;
                    nameParts.Push(memberExpression.Member.Name);
                    part = memberExpression.Expression;
                }
                else
                {
                    break;
                }
            }

            if (nameParts.Count > 0 && String.Equals(nameParts.Peek(), "model", StringComparison.OrdinalIgnoreCase))
            {
                nameParts.Pop();
            }

            if (nameParts.Count == 0)
            {
                return String.Empty;
            }

            return nameParts.Aggregate((left, right) => left + "." + right);
        }
        #endregion

    }
}
