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
    public static class ButtonsExtensions
    {
        public static String ActionButton(this HtmlHelper html, String buttonText, String iconPrimary, String iconSecondary)
        {
            iconPrimary = String.IsNullOrEmpty(iconPrimary) ? "null" : String.Format("'{0}'", iconPrimary);
            iconSecondary = String.IsNullOrEmpty(iconSecondary) ? "null" : String.Format("'{0}'", iconSecondary);
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(string.Format(HtmlTemplete.Html.Button, buttonText));
            sb.Append(HtmlTemplete.Html.BeginScript());
            sb.Append(@"$(function(){$($(");
            sb.Append(HtmlTemplete.Html.ButtonSelector);
            sb.Append(@")[0]).button({ icons: {");
            sb.Append(string.Format("primary: {0}, secondary: {1}", iconPrimary, iconSecondary));
            sb.Append(@"}});});");
            sb.Append(HtmlTemplete.Html.EndScript());
            return sb.ToString();
        }

        public static String ActionLinkButton(this HtmlHelper html, String linkText, String actionName, String controllerName, String iconPrimary)
        {
            return ActionLinkButton(html, linkText, actionName, controllerName, null, "MvcLinkButton", iconPrimary, null);
        }

        public static String ActionLinkButton(this HtmlHelper html, String linkText, String actionName, String iconPrimary)
        {
            return ActionLinkButton(html, linkText, actionName, null, "MvcLinkButton", iconPrimary, null);
        }

        public static String ActionLinkButton(this HtmlHelper html, String linkText, String actionName, String controllerName, object routeValue, String iconPrimary)
        {
            return ActionLinkButton(html, linkText, actionName, controllerName, routeValue, "MvcLinkButton", iconPrimary, null);
        }

        public static String ActionLinkButton(this HtmlHelper html, String linkText, String actionName, object routeValue, String iconPrimary)
        {
            return ActionLinkButton(html, linkText, actionName, routeValue, "MvcLinkButton", iconPrimary, null);
        }

        public static String ActionLinkButton(this HtmlHelper html, String linkText, String actionName, object routeValues, String type, String iconPrimary, String iconSecondary)
        {
            MvcHtmlString actionLink = html.ActionLink(linkText, actionName, routeValues, new { @type = type });
            return ActionLinkButton(actionLink, type, iconPrimary, iconSecondary);
        }

        public static String ActionLinkButton(this HtmlHelper html, String linkText, String actionName, String controllerName, object routeValues, String type, String iconPrimary, String iconSecondary)
        {
            MvcHtmlString actionLink = html.ActionLink(linkText, actionName, controllerName, routeValues, new { @type = type });
            return ActionLinkButton(actionLink, type, iconPrimary, iconSecondary);
        }

        internal static String ActionLinkButton(MvcHtmlString actionLink, String type, String iconPrimary, String iconSecondary)
        {
            iconPrimary = String.IsNullOrEmpty(iconPrimary) ? "null" : String.Format("'{0}'", iconPrimary);
            iconSecondary = String.IsNullOrEmpty(iconSecondary) ? "null" : String.Format("'{0}'", iconSecondary);
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(actionLink);
            sb.Append(HtmlTemplete.Html.BeginScript());
            sb.Append(@"$(function(){$($('#");
            sb.Append(string.Format("MvcSectionBox a[type={0}]", type));
            sb.Append(@"')[0]).button({icons:{");
            sb.Append(string.Format("primary: {0}, secondary: {1}", iconPrimary, iconSecondary));
            sb.Append(@"}});});");
            sb.Append(HtmlTemplete.Html.EndScript());
            return sb.ToString();
        }

        public static String ActionLinkBack(this HtmlHelper html)
        {
            return html.ActionLinkBack(HelperBaseExtensions.ButtonJQuery.Back.Text);
        }

        public static String ActionLinkBack(this HtmlHelper html, String linkText)
        {
            return html.ActionLinkBack(linkText, HelperBaseExtensions.ButtonJQuery.Back.Icon1);
        }

        public static String ActionLinkBack(this HtmlHelper html, String linkText, String iconPrimary)
        {
            return html.ActionLinkBack(linkText, iconPrimary, HelperBaseExtensions.ButtonJQuery.Back.Icon2);
        }

        public static String ActionLinkBack(this HtmlHelper html, String linkText, String iconPrimary, String iconSecundary)
        {
            return html.ActionLinkBack(linkText, null, iconPrimary, iconSecundary);
        }

        public static String ActionLinkBack(this HtmlHelper html, String linkText, object routeValues, String iconPrimary, String iconSecundary)
        {
            return html.ActionLinkButton(linkText, "List", routeValues, "MvcButtonBack", iconPrimary, iconSecundary);
        }

        public static String ActionLinkEdit(this HtmlHelper html, object routeValues)
        {
            return html.ActionLinkEdit(HelperBaseExtensions.ButtonJQuery.Edit.Text, routeValues, HelperBaseExtensions.ButtonJQuery.Edit.Icon1, HelperBaseExtensions.ButtonJQuery.Edit.Icon2);
        }

        public static String ActionLinkEdit(this HtmlHelper html, String linkText, object routeValues)
        {
            return html.ActionLinkEdit(linkText, routeValues, HelperBaseExtensions.ButtonJQuery.Edit.Icon1, HelperBaseExtensions.ButtonJQuery.Edit.Icon2);
        }

        public static String ActionLinkEdit(this HtmlHelper html, String linkText, object routeValues, String iconPrimary)
        {
            return html.ActionLinkEdit(linkText, routeValues, iconPrimary, HelperBaseExtensions.ButtonJQuery.Edit.Icon2);
        }

        public static String ActionLinkEdit(this HtmlHelper html, String linkText, object routeValues, String iconPrimary, String iconSecundary)
        {
            return html.ActionLinkButton(linkText, "Edit", routeValues, "MvcButtonEdit", iconPrimary, iconSecundary);
        }

        public static String ActionLinkOK(this HtmlHelper html, object routeValues)
        {
            return html.ActionLinkOK(HelperBaseExtensions.ButtonJQuery.OK.Text, routeValues, HelperBaseExtensions.ButtonJQuery.OK.Icon1, HelperBaseExtensions.ButtonJQuery.OK.Icon2);
        }

        public static String ActionLinkOK(this HtmlHelper html, String linkText, object routeValues)
        {
            return html.ActionLinkOK(linkText, routeValues, HelperBaseExtensions.ButtonJQuery.OK.Icon1, HelperBaseExtensions.ButtonJQuery.OK.Icon2);
        }

        public static String ActionLinkOK(this HtmlHelper html, String linkText, object routeValues, String iconPrimary)
        {
            return html.ActionLinkOK(linkText, routeValues, iconPrimary, HelperBaseExtensions.ButtonJQuery.OK.Icon2);
        }

        public static String ActionLinkOK(this HtmlHelper html, String linkText, object routeValues, String iconPrimary, String iconSecundary)
        {
            return html.ActionLinkButton(linkText, "Consulta", routeValues, "MvcButtonOK", iconPrimary, iconSecundary);
        }

        public static String ActionLinkCreate(this HtmlHelper html)
        {
            return html.ActionLinkCreate(HelperBaseExtensions.ButtonJQuery.Create.Text);
        }

        public static String ActionLinkCreate(this HtmlHelper html, String linkText)
        {
            return html.ActionLinkCreate(linkText, HelperBaseExtensions.ButtonJQuery.Create.Icon1);
        }

        public static String ActionLinkCreate(this HtmlHelper html, String linkText, String iconPrimary)
        {
            return html.ActionLinkCreate(linkText, iconPrimary, HelperBaseExtensions.ButtonJQuery.Create.Icon2);
        }

        public static String ActionLinkCreate(this HtmlHelper html, String linkText, String iconPrimary, String iconSecundary)
        {
            return html.ActionLinkButton(linkText, "Create", null, "MvcButtonCreate", iconPrimary, iconSecundary);
        }

        public static String ActionLinkHome(this HtmlHelper html)
        {
            return html.ActionLinkHome(HelperBaseExtensions.ButtonJQuery.Home.Text);
        }

        public static String ActionLinkHome(this HtmlHelper html, String linkText)
        {
            return html.ActionLinkButton(linkText, "/Index", "Home", null, "MvcButtomHome", HelperBaseExtensions.ButtonJQuery.Home.Icon1, null);
        }

        public static String ActionLinkPrint(this HtmlHelper html)
        {
            return html.ActionLinkPrint(HelperBaseExtensions.ButtonJQuery.Print.Text);
        }

        public static String ActionLinkPrint(this HtmlHelper html, String linkText)
        {
            return html.ActionLinkButton(linkText, "", "", HelperBaseExtensions.ButtonJQuery.Print.Icon1);
        }

        public static String ActionLinkPrintGrid(this HtmlHelper html, String uniqueID)
        {
            return ActionLinkPrintGrid(html, uniqueID, HelperBaseExtensions.ButtonJQuery.Print.Text);
        }

        public static String ActionLinkPrintGrid(this HtmlHelper html, String uniqueID, String linkText)
        {
            string type = "MvcButtonPrint";
            MvcHtmlString actionLink = html.ActionLink(linkText, "", "", null, new { @type = type, onclick = String.Format("mvcLocal.jqGrid.print('MvcJqTable{0}'); return false;", uniqueID) });
            return ActionLinkButton(actionLink, type, HelperBaseExtensions.ButtonJQuery.Print.Icon1, HelperBaseExtensions.ButtonJQuery.Print.Icon2);
        }
    }

}