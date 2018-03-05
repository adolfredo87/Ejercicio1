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
    public static class LabelDisplayExtensions
    {
        public static string LabelDisplayItemFor<TModel, TValue>(this HtmlHelper<TModel> html,
           Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItem());
            sb.Append(HtmlTemplete.Mvc.SectionEditorLabel(html.LabelFor(expression)));
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(html.DisplayFor(expression)));
            sb.Append(HtmlTemplete.Mvc.EndSectionItem());

            return sb.ToString();

        }

        public static string LabelDisplay(this HtmlHelper html, String label, String display)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItem());
            sb.Append(HtmlTemplete.Mvc.SectionDisplayLabel(label));
            sb.Append(HtmlTemplete.Mvc.SectionDisplayData(display));
            sb.Append(HtmlTemplete.Mvc.EndSectionItem());

            return sb.ToString();

        }

        public static string LabelDisplayItemForCell<TModel, TValue>(this HtmlHelper<TModel> html,
           Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItemCell());
            sb.Append(HtmlTemplete.Mvc.SectionDisplayLabel(html.LabelFor(expression)));
            sb.Append(HtmlTemplete.Mvc.SectionDisplayData(html.DisplayFor(expression)));
            sb.Append(HtmlTemplete.Mvc.EndSectionItemCell());

            return sb.ToString();

        }

        public static string LabelDisplayItemForCell<TModel, TValue>(this HtmlHelper<TModel> html,
           Expression<Func<TModel, TValue>> expression, int spanCell) where TModel : class
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItemCell(spanCell));
            sb.Append(HtmlTemplete.Mvc.SectionDisplayLabel(html.LabelFor(expression)));
            sb.Append(HtmlTemplete.Mvc.SectionDisplayData(html.DisplayFor(expression)));
            sb.Append(HtmlTemplete.Mvc.EndSectionItemCell());

            return sb.ToString();

        }

    }

}