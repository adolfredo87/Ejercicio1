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
    public static class LabelEditorExtensions
    {
        public static string LableEditorForItem<TModel, TValue>(this HtmlHelper<TModel> html,
           Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItem());
            sb.Append(HtmlTemplete.Mvc.SectionEditorLabel(html.LabelFor(expression)));
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(html.EditorFor(expression)));
            sb.Append(HtmlTemplete.Mvc.EndSectionItem());

            return sb.ToString();
        }
    }

}