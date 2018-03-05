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
    public static class BarButtonsExtensions
    {
        public static string BeginBarButtons(this HtmlHelper html)
        {
            return @"<div class='Buttons'>";
        }
        public static string EndBarButtons(this HtmlHelper html)
        {
            return @"</div>";
        }

        public static string BarButtonsDetails(this HtmlHelper html)
        {
            return BarButtonsDetails(html, HelperBaseExtensions.ButtonJQuery.Edit.Text);
        }
        public static string BarButtonsDetails(this HtmlHelper html, String editText)
        {
            return BarButtonsDetails(html, editText, HelperBaseExtensions.ButtonJQuery.Back.Text);
        }
        public static string BarButtonsDetails(this HtmlHelper html, String editText, String backText)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            if (!String.IsNullOrEmpty(editText))
            {
                sb.Append(html.ActionLinkEdit(editText));
            }
            if (!String.IsNullOrEmpty(backText))
            {
                sb.Append(html.ActionLinkBack(backText));
            }
            return sb.ToString();
        }
        public static string BarButtonsDetails<TModel, TValue>(this HtmlHelper<TModel> html,
           Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            return BarButtonsDetails(html, expression, HelperBaseExtensions.ButtonJQuery.Edit.Text);
        }
        public static string BarButtonsDetails<TModel, TValue>(this HtmlHelper<TModel> html,
           Expression<Func<TModel, TValue>> expression, String editText) where TModel : class
        {
            return BarButtonsDetails(html, expression, editText, HelperBaseExtensions.ButtonJQuery.Back.Text);
        }
        public static string BarButtonsDetails<TModel, TValue>(this HtmlHelper<TModel> html,
           Expression<Func<TModel, TValue>> expression, String editText, String backText) where TModel : class
        {
            String actionName = ((LambdaExpression)expression).Compile().DynamicInvoke(html.ViewData.Model).ToString();
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            if (!String.IsNullOrEmpty(editText))
            {
                sb.Append(html.ActionLinkEdit(editText, new { id = actionName }));
            }
            if (!String.IsNullOrEmpty(backText))
            {
                sb.Append(html.ActionLinkBack(backText));
            }
            return sb.ToString();
        }

        public static string BarButtonsOK(this HtmlHelper html)
        {
            return BarButtonsOK(html, HelperBaseExtensions.ButtonJQuery.OK.Text);
        }
        public static string BarButtonsOK(this HtmlHelper html, String actionText)
        {
            return BarButtonsOK(html, actionText, null);
        }
        public static string BarButtonsOK(this HtmlHelper html, String actionText, String linkText)
        {
            return ButtonsDefault(html, actionText, HelperBaseExtensions.ButtonJQuery.OK.Icon1, HelperBaseExtensions.ButtonJQuery.OK.Icon2,
                linkText, null, null);
        }

        public static string BarButtonsCreate(this HtmlHelper html)
        {
            return BarButtonsCreate(html, HelperBaseExtensions.ButtonJQuery.Create.Text);
        }
        public static string BarButtonsCreate(this HtmlHelper html, String actionText)
        {
            return BarButtonsCreate(html, actionText, HelperBaseExtensions.ButtonJQuery.Back.Text);
        }
        public static string BarButtonsCreate(this HtmlHelper html, String actionText, String linkText)
        {
            return ButtonsDefault(html, actionText, HelperBaseExtensions.ButtonJQuery.Create.Icon1, HelperBaseExtensions.ButtonJQuery.Create.Icon2,
                linkText, HelperBaseExtensions.ButtonJQuery.Back.Icon1, HelperBaseExtensions.ButtonJQuery.Back.Icon2);
        }

        public static string BarButtonsEdit(this HtmlHelper html)
        {
            return BarButtonsEdit(html, HelperBaseExtensions.ButtonJQuery.Save.Text);
        }
        public static string BarButtonsEdit(this HtmlHelper html, String actionText)
        {
            return BarButtonsEdit(html, actionText, HelperBaseExtensions.ButtonJQuery.Back.Text);
        }
        public static string BarButtonsEdit(this HtmlHelper html, String actionText, String linkText)
        {
            return ButtonsDefault(html, actionText, HelperBaseExtensions.ButtonJQuery.Save.Icon1, HelperBaseExtensions.ButtonJQuery.Save.Icon2,
                linkText, HelperBaseExtensions.ButtonJQuery.Back.Icon1, HelperBaseExtensions.ButtonJQuery.Back.Icon2);
        }

        public static string BarButtonsDelete(this HtmlHelper html)
        {
            return BarButtonsDelete(html, HelperBaseExtensions.ButtonJQuery.OK.Text);
        }
        public static string BarButtonsDelete(this HtmlHelper html, String actionText)
        {
            return BarButtonsDelete(html, actionText, HelperBaseExtensions.ButtonJQuery.Back.Text);
        }
        public static string BarButtonsDelete(this HtmlHelper html, String actionText, String linkText)
        {
            return ButtonsDefault(html, actionText, HelperBaseExtensions.ButtonJQuery.Delete.Icon1, HelperBaseExtensions.ButtonJQuery.Delete.Icon2,
                linkText, HelperBaseExtensions.ButtonJQuery.Back.Icon1, HelperBaseExtensions.ButtonJQuery.Back.Icon2);
        }

        public static string ButtonsDefault(this HtmlHelper html,
            String actionText, String actionIconPrimary, String actionIconSecondary,
            String linkText, String linkIconPrimary, String linkIconSecondary)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            if (!String.IsNullOrEmpty(actionText))
            {
                sb.Append(html.ActionButton(actionText, actionIconPrimary, actionIconSecondary));
            }
            if (!String.IsNullOrEmpty(linkText))
            {
                sb.Append(html.ActionLinkBack(linkText, linkIconPrimary, linkIconSecondary));
            }
            return sb.ToString();
        }
    }

}
