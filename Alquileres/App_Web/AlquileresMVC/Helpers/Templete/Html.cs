using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;

namespace AlquileresMVC.Helpers
{
    internal partial class HtmlTemplete
    {
        public partial class Html
        {
            public const String Button = @"<button type='submit'>{0}</button>";
            public const String ButtonSelector = @"'#MvcSectionBox button'";
            public const String WidgetError = "<div class='ui-widget'><div class='ui-state-error ui-corner-all'>" +
                "<span class='ui-icon ui-icon-alert'></span>{0}</div></div>";
            public const String WidgetWarning = "<div class='ui-widget'><div class='ui-state-error ui-corner-all'>" +
                "<span class='ui-icon ui-icon-alert'></span>{0}</div></div>";

            public static String EncloseComillaSimple(String nameControl)
            {
                return "'" + nameControl + "'";
            }

            public static String IDControl(String control)
            {
                int startIndex = control.ToLower().IndexOf("id=");
                String id = control.Substring(startIndex + 4);
                int endIndex = id.ToLower().IndexOf("\"") >= 0 ? id.ToLower().IndexOf("\"") : id.ToLower().IndexOf("'");
                return id.Substring(0, endIndex);
            }

            public static String IDControl(MvcHtmlString control)
            {
                return IDControl(control.ToHtmlString());
            }

            public static String ReplaceIDControl(String control, String newID, bool add)
            {
                String currentID = IDControl(control);
                return control.Replace("id=\"" + currentID, "id=\"" + (add ? currentID + newID : newID));
            }

            public static String ReplaceIDControl(String control, String newID)
            {
                return ReplaceIDControl(control, newID, true);
            }

            public static String ReplaceIDControl(MvcHtmlString control, String newID, bool add)
            {
                return ReplaceIDControl(control.ToHtmlString(), newID, add);
            }

            public static String ReplaceIDControl(MvcHtmlString control, String newID)
            {
                return ReplaceIDControl(control.ToHtmlString(), newID, true);
            }

            public static String BeginScript() { return "<script type='text/javascript'>//<![CDATA[\n"; }

            public static String EndScript() { return "//]]>\n</script>"; }

        }
    }
}
