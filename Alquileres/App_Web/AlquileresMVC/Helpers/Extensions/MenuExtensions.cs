using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AlquileresMVC.Helpers.Menu
{
    public static class MenuExtensions
    {
        public static MvcHtmlString BeginMenuItem(this HtmlHelper htmlHelper, String title)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append("<h3>");
            sb.Append(title);
            sb.Append("</h3>");
            sb.Append("<div>");

            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString EndMenuItem(this HtmlHelper htmlHelper)
        {
            return MvcHtmlString.Create("</div>");
        }

        public static MvcHtmlString MenuItemLink(this HtmlHelper htmlHelper, String urlImage, String linkText, String actionName, String controlerName)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append("<div class='itemMenu'>");
            sb.Append(string.Format("<img src='{0}' alt='{1}'></img>", urlImage, linkText));
            //sb.Append(htmlHelper.ActionLink(linkText, actionName, controlerName, null, new { onclick = "mvcLocal.utility.findParentForm(this).submit(); return true;" }));
            sb.Append(htmlHelper.ActionLink(linkText, actionName, controlerName));
            sb.Append("</div>");
            return MvcHtmlString.Create(sb.ToString());
        }

    }
}
