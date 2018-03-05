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
    public static class MessageExtensions
    {
        internal static String DefaultMessageDelete = @"¡Esta acción eliminará permanentemente el ítem seleccionado, compruebe que es ítem correcto y pulse el botón Eliminar para completar la acción!.";
        internal static String DefaultMessageSuccessfulTitle = @"La acción fue ejecutada exitosamente!";
        internal static String DefaultMessageCreateSuccessfulText = @"El item ha sido creado en la base de datos.";
        internal static String DefaultMessageUpdateSuccessfulText = @"El item ha sido actualizado en la base de datos.";
        internal static String DefaultMessageDeleteSuccessfulText = @"El item ha sido eliminado permanentemente de la base de datos.";

        public static String MessageDeleteWidget(this HtmlHelper htmlHelper)
        {
            return MessageErrorWidget(htmlHelper, DefaultMessageDelete);
        }

        public static String MessageCreateSuccessfulWidget(this HtmlHelper htmlHelper)
        {
            return MessageSuccessfulWidget(htmlHelper, DefaultMessageSuccessfulTitle, DefaultMessageCreateSuccessfulText);
        }

        public static String MessageUpdateSuccessfulWidget(this HtmlHelper htmlHelper)
        {
            return MessageSuccessfulWidget(htmlHelper, DefaultMessageSuccessfulTitle, DefaultMessageUpdateSuccessfulText);
        }

        public static String MessageDeleteSuccessfulWidget(this HtmlHelper htmlHelper)
        {
            return MessageSuccessfulWidget(htmlHelper, DefaultMessageSuccessfulTitle, DefaultMessageDeleteSuccessfulText);
        }

        public static String MessageErrorWidget(this HtmlHelper htmlHelper, string message)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append("<div class='MVCSection'>");
            sb.Append("    <div class='ui-widget' >".Trim());
            sb.Append("        <div style='padding: 0 .7em;' class='ui-state-error ui-corner-all'>".Trim());
            sb.Append("	        <p><span style='float: left; margin-right: .3em;' class='ui-icon ui-icon-alert' id='ui-icon-alert'></span>".Trim());
            sb.Append(message);
            sb.Append("         </p>".Trim());
            sb.Append("        </div>".Trim());
            sb.Append("    </div>".Trim());
            sb.Append("</div>");
            return sb.ToString();
        }

        public static String MessageSuccessfulWidget(this HtmlHelper htmlHelper, String title, String message)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append("<div class='MVCSection'>");
            sb.Append("    <div class='ui-widget' >".Trim());
            sb.Append("        <div style='padding: 0 .7em;' class='ui-state-highlight ui-corner-all'>".Trim());
            sb.Append("	        <p><span class='ui-icon ui-icon-info' style='float: left; margin-right: .3em;'></span>".Trim());
            sb.Append(!String.IsNullOrEmpty(title) ? "<strong>" + title + "</strong>&nbsp;" : "");
            sb.Append(message);
            sb.Append("         </p>".Trim());
            sb.Append("        </div>".Trim());
            sb.Append("    </div>".Trim());
            sb.Append("</div>");
            return sb.ToString();
        }

    }

}
