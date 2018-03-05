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
    public static class ValidationExtensions
    {
        //
        // Summary:
        //     Returns an unordered list (ul element) of validation messages that are in
        //     the System.Web.Mvc.ModelStateDictionary object.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        // Returns:
        //     A string that contains an unordered list (ul element) of validation messages.
        public static String ValidationSummaryWidget(this HtmlHelper htmlHelper)
        {
            MvcHtmlString mvcHtmlValidationSummary = htmlHelper.ValidationSummary(DefaultMessageSummary);
            return CreateValidationSummaryWidget(htmlHelper, mvcHtmlValidationSummary, "<span>");
            //return CreateValidationSummaryWidget(htmlHelper, mvcHtmlValidationSummary, "<ul>");
        }
        //
        // Summary:
        //     Returns an unordered list (ul element) of validation messages that are in
        //     the System.Web.Mvc.ModelStateDictionary object and optionally displays only
        //     model-level errors.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   excludePropertyErrors:
        //     true to have the summary display model-level errors only, or false to have
        //     the summary display all errors.
        //
        // Returns:
        //     A string that contains an unordered list (ul element) of validation messages.
        public static String ValidationSummaryWidget(this HtmlHelper htmlHelper, bool excludePropertyErrors)
        {
            MvcHtmlString mvcHtmlValidationSummary = htmlHelper.ValidationSummary(excludePropertyErrors, DefaultMessageSummary);
            return CreateValidationSummaryWidget(htmlHelper, mvcHtmlValidationSummary, "<span>");
            //return CreateValidationSummaryWidget(htmlHelper, mvcHtmlValidationSummary, "<ul>");
        }
        //
        // Summary:
        //     Returns an unordered list (ul element) of validation messages that are in
        //     the System.Web.Mvc.ModelStateDictionary object.
        //
        // Parameters:
        //   htmlHelper:
        //     The HMTL helper instance that this method extends.
        //
        //   message:
        //     The message to display if the specified field contains an error.
        //
        // Returns:
        //     A string that contains an unordered list (ul element) of validation messages.
        public static String ValidationSummaryWidget(this HtmlHelper htmlHelper, string message)
        {
            MvcHtmlString mvcHtmlValidationSummary = htmlHelper.ValidationSummary(message);
            return CreateValidationSummaryWidget(htmlHelper, mvcHtmlValidationSummary, "<span>");
        }
        //
        // Summary:
        //     Returns an unordered list (ul element) of validation messages that are in
        //     the System.Web.Mvc.ModelStateDictionary object and optionally displays only
        //     model-level errors.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   excludePropertyErrors:
        //     true to have the summary display model-level errors only, or false to have
        //     the summary display all errors.
        //
        //   message:
        //     The message to display with the validation summary.
        //
        // Returns:
        //     A string that contains an unordered list (ul element) of validation messages.
        public static String ValidationSummaryWidget(this HtmlHelper htmlHelper, bool excludePropertyErrors, string message)
        {
            MvcHtmlString mvcHtmlValidationSummary = htmlHelper.ValidationSummary(excludePropertyErrors, message);
            return CreateValidationSummaryWidget(htmlHelper, mvcHtmlValidationSummary, "<span>"); ;
        }
        //
        // Summary:
        //     Returns an unordered list (ul element) of validation messages that are in
        //     the System.Web.Mvc.ModelStateDictionary object.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   message:
        //     The message to display if the specified field contains an error.
        //
        //   htmlAttributes:
        //     A dictionary that contains the HTML attributes for the element.
        //
        // Returns:
        //     A string that contains an unordered list (ul element) of validation messages.
        public static String ValidationSummaryWidget(this HtmlHelper htmlHelper, string message, IDictionary<string, object> htmlAttributes)
        {
            MvcHtmlString mvcHtmlValidationSummary = htmlHelper.ValidationSummary(message, htmlAttributes);
            return CreateValidationSummaryWidget(htmlHelper, mvcHtmlValidationSummary, "<span>"); 
        }
        //
        // Summary:
        //     Returns an unordered list (ul element) of validation messages in the System.Web.Mvc.ModelStateDictionary
        //     object.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   message:
        //     The message to display if the specified field contains an error.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes for the element.
        //
        // Returns:
        //     A string that contains an unordered list (ul element) of validation messages.
        public static String ValidationSummaryWidget(this HtmlHelper htmlHelper, string message, object htmlAttributes)
        {
            MvcHtmlString mvcHtmlValidationSummary = htmlHelper.ValidationSummary(message, htmlAttributes);
            return CreateValidationSummaryWidget(htmlHelper, mvcHtmlValidationSummary, "<span>");
        }
        //
        // Summary:
        //     Returns an unordered list (ul element) of validation messages that are in
        //     the System.Web.Mvc.ModelStateDictionary object and optionally displays only
        //     model-level errors.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   excludePropertyErrors:
        //     true to have the summary display model-level errors only, or false to have
        //     the summary display all errors.
        //
        //   message:
        //     The message to display with the validation summary.
        //
        //   htmlAttributes:
        //     A dictionary that contains the HTML attributes for the element.
        //
        // Returns:
        //     A string that contains an unordered list (ul element) of validation messages.
        public static String ValidationSummaryWidget(this HtmlHelper htmlHelper, bool excludePropertyErrors, string message, IDictionary<string, object> htmlAttributes)
        {
            MvcHtmlString mvcHtmlValidationSummary = htmlHelper.ValidationSummary(excludePropertyErrors, message, htmlAttributes);
            return CreateValidationSummaryWidget(htmlHelper, mvcHtmlValidationSummary, "<span>");
        }
        //
        // Summary:
        //     Returns an unordered list (ul element) of validation messages that are in
        //     the System.Web.Mvc.ModelStateDictionary object and optionally displays only
        //     model-level errors.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   excludePropertyErrors:
        //     true to have the summary display model-level errors only, or false to have
        //     the summary display all errors.
        //
        //   message:
        //     The message to display with the validation summary.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes for the element.
        //
        // Returns:
        //     A string that contains an unordered list (ul element) of validation messages.
        public static String ValidationSummaryWidget(this HtmlHelper htmlHelper, bool excludePropertyErrors, string message, object htmlAttributes)
        {
            MvcHtmlString mvcHtmlValidationSummary = htmlHelper.ValidationSummary(excludePropertyErrors, message, htmlAttributes);
            return CreateValidationSummaryWidget(htmlHelper, mvcHtmlValidationSummary, "<span>");
        }
        
        internal static String CreateValidationSummaryWidget(this HtmlHelper htmlHelper, MvcHtmlString mvcHtmlValidationSummary, String tagNode)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            if (htmlHelper.ValidationSummary() != null)
            {
                String validationSummary = mvcHtmlValidationSummary.ToHtmlString();
                if (!String.IsNullOrEmpty(validationSummary))
                {
                    int index = validationSummary.IndexOf(tagNode);
                    sb.Append(validationSummary.Substring(0, index));
                    //sb.Append(PreWidget);
                    sb.Append(String.Format(HtmlTemplete.Html.WidgetError, validationSummary.Substring(index)));
                    //sb.Append(PostWidget);
                }
            }
            return sb.ToString();
        }
        //internal static String PreWidget = "" +
        //    "<div class='ui-widget'>" +
        //    "    <div class='ui-state-error ui-corner-all'>" +
        //    "        <span class='ui-icon ui-icon-alert'></span>".Trim();
        //internal static String PostWidget = "" +
        //    "    </div>" +
        //    "</div>".Trim();
        internal static String DefaultMessageSummary = "La acción ejecutada no pudo ser procesada, revise lo siguiente:";
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

    }
}
