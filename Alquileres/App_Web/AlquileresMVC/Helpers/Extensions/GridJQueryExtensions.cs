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
    public static class GridJQueryExtensions
    {
        public static string GridJQuery(this HtmlHelper html, String uniqueID)
        {
            String nameTable = String.Format("MvcJqTable{0}", uniqueID);
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);

            //Agregar el Widget de Mensajes de Error del Grid
            sb.Append(String.Format("<div class='ItemGrid'><div id='{0}_Message' class='Hidden'>", nameTable));
            sb.Append(String.Format(HtmlTemplete.Html.WidgetError, "<label /> </div>"));
            //Agregar la tabla del Grid
            sb.Append(String.Format("<table id='{0}'></table>", nameTable));
            // Agregar el Pager del Grid
            sb.Append(String.Format("<div id='{0}_Pager'></div></div>", nameTable));

           return sb.ToString();
        }
        
        public static MvcHtmlString GridJQueryEditItem<TModel, TValue>(this HtmlHelper<TModel> html, 
            Expression<Func<TModel, TValue>> expression, String gridID, String selectGridID) where TModel : class
        {
            string jquerySelectGridID = String.Format("MvcJqTable{0}", selectGridID);
            StringBuilder sb = new StringBuilder("<div class='Item'>", HelperBaseExtensions.Capacity);
            sb.Append("<div class='MVCSectionLabel'>");
            sb.Append(html.LabelFor(expression));
            sb.Append("</div>");
            sb.Append("<div class='MVCSectionData'>");
            sb.Append("<a id='" + jquerySelectGridID + "Buttons' onclick=\"$('#" + jquerySelectGridID + "')[0].mvcUI.openDialog('" + jquerySelectGridID + "');\">Agregar&nbsp;");
            sb.Append(html.LabelFor(expression));
            sb.Append("</a>");

            sb.Append(HtmlTemplete.Html.BeginScript());
            sb.Append(@"$(function(){$($('#MvcSectionBox #");
            sb.Append(jquerySelectGridID + "Buttons");
            sb.Append(@"')[0]).button({icons:{");
            sb.Append(string.Format("primary: {0}, secondary: {1}", "null", "'ui-icon-plus'"));
            sb.Append(@"}});});");
            sb.Append(HtmlTemplete.Html.EndScript());
 
            sb.Append("</div>");
            sb.Append("</div>");

            sb.Append("<div class='Item'>");

            sb.Append(GridJQuery(html, gridID));
            sb.Append(GridJQuery(html, selectGridID));
            
            // fin de item's
            sb.Append("</div>");
            //sb.Append("</div>");

            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString GridJQueryDisplayItem<TModel, TValue>(this HtmlHelper<TModel> html, 
            Expression<Func<TModel, TValue>> expression, String gridID) where TModel : class
        {
            StringBuilder sb = new StringBuilder("<div class='Item'>", HelperBaseExtensions.Capacity);
            sb.Append("<div class='MVCSectionLabel'>");
            sb.Append(html.LabelFor(expression));
            sb.Append("</div>");
            sb.Append("<div class='MVCSectionData'>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("<div class='Item'>");

            sb.Append(GridJQuery(html, gridID));

            // fin de item's
            sb.Append("</div>");

            return MvcHtmlString.Create(sb.ToString());
        }
    }

}