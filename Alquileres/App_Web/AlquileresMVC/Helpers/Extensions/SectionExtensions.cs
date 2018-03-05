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
    public static class SectionExtensions
    {
        public static string BeginSection(this HtmlHelper html, String imageUrl, String title)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(string.Format("<div id='MvcSectionBox' class='MVCSection'>"));
            sb.Append("<div class='Header'>");
            sb.Append(string.Format("<img src='{0}' alt='{1}' />{1}", imageUrl, title));
            sb.Append("</div>");
            return sb.ToString();
        }
        public static string EndSection(this HtmlHelper html)
        {
            return "</div>";
        }
        
        public static string BeginSectionBody(this HtmlHelper html)
        {
            return BeginSectionBody(html, false);
        }
        public static string BeginSectionBody(this HtmlHelper html, bool excludeBorder)
        {
            return string.Format("<div class='Border {0}'><div class='Body'>", excludeBorder ? "noBorder" : "");
        }
        public static string EndSectionBody(this HtmlHelper html)
        {
            return "</div></div>";
        }

        public static string BeginSectionItemHorizontal(this HtmlHelper html)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItemHorizontal());
            //sb.Append(Templete.Mvc.SectionLabelTitle(""));
            sb.Append(HtmlTemplete.Mvc.BeginSectionEditorData());

            return sb.ToString();
        }
        public static string BeginSectionItemHorizontal(this HtmlHelper html, String title)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItemHorizontal());
            if (String.IsNullOrEmpty(title))
            {
                //sb.Append(Templete.Mvc.SectionLabelTitle(""));
            }
            else
            {
                sb.Append(HtmlTemplete.Mvc.SectionLabelTitle(html.Label(title)));
            }
            
            sb.Append(HtmlTemplete.Mvc.BeginSectionEditorData());


            return sb.ToString();
        }
        public static string BeginSectionItemHorizontal<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItemHorizontal());
            sb.Append(HtmlTemplete.Mvc.SectionLabelTitle(html.LabelFor(expression)));
            sb.Append(HtmlTemplete.Mvc.BeginSectionEditorData());


            return sb.ToString();
        }

        public static string EndSectionItemHorizontal(this HtmlHelper html)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.EndSectionEditorData());
            sb.Append(HtmlTemplete.Mvc.EndSectionItemHorizontal());
            return sb.ToString();
        }
        public static string BeginSectionItemDataRow(this HtmlHelper html)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItemRow());
            return sb.ToString();
        }
        public static string EndSectionItemDataRow(this HtmlHelper html)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.EndSectionItemRow());
            return sb.ToString();
        }

    }

}
