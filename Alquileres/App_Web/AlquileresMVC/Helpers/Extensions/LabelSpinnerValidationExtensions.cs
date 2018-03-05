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
    public static class LabelSpinnerValidationExtensions
    {
        public static string LabelSpinnerValidationItemFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            return LabelSpinnerValidationItemFor(html, expression, HelperBaseExtensions.DefaultExcludePropertyErrors);
        }

        public static string LabelSpinnerValidationItemFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, bool excludePropertyErrors) where TModel : class
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItem());
            sb.Append(HtmlTemplete.Mvc.SectionEditorLabel(html.LabelFor(expression)));
            
            MvcHtmlString editorFor = html.EditorFor(expression);
            String idEditorFor = HtmlTemplete.Html.IDControl(editorFor);

            sb.Append(HtmlTemplete.Mvc.SectionEditorData(editorFor));            
            sb.Append(HtmlTemplete.Mvc.BeginSectionValidation());

            String message = ValidationMessageExtensions.ValidationMessage(html.ValidationMessageFor(expression));
            if (!String.IsNullOrEmpty(message))
            {
                if (!excludePropertyErrors)
                {
                    sb.Append(message);
                }
            }
            sb.Append(HtmlTemplete.Mvc.EndSectionValidation());
            
            sb.Append(HtmlTemplete.Html.BeginScript());
            sb.Append(HtmlTemplete.JQuery.BeginReadyFunction());
            sb.Append(HtmlTemplete.JQuery.LoadControl(idEditorFor) + ".spinner();");// {step: 0.01,numberFormat: 'n'}
            sb.Append(HtmlTemplete.JQuery.EndReadyFunction());
            sb.Append(HtmlTemplete.Html.EndScript());           

            sb.Append(HtmlTemplete.Mvc.EndSectionItem());
            return sb.ToString();
        }

        public static string LabelSpinnerValidationItemCellFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            return LabelSpinnerValidationItemCellFor(html, expression, HelperBaseExtensions.DefaultExcludePropertyErrors);
        }

        public static string LabelSpinnerValidationItemCellFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, bool excludePropertyErrors) where TModel : class
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            MvcHtmlString editorFor = html.EditorFor(expression);
            String idEditorFor = HtmlTemplete.Html.IDControl(editorFor);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItemCell());
            sb.Append(HtmlTemplete.Mvc.BeginSectionEditorLabel());
            sb.Append(html.LabelFor(expression));
            String message = ValidationMessageExtensions.ValidationMessage(html.ValidationMessageFor(expression));
            if (!String.IsNullOrEmpty(message))
            {
                if (!excludePropertyErrors)
                {
                    sb.Append(message);
                }
            }
            sb.Append(HtmlTemplete.Mvc.EndSectionEditorLabel());
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(editorFor));
            sb.Append(HtmlTemplete.Html.BeginScript());
            sb.Append(HtmlTemplete.JQuery.BeginReadyFunction());
            sb.Append(HtmlTemplete.JQuery.LoadControl(idEditorFor) + ".spinner();");// {step: 0.01,numberFormat: 'n'}
            sb.Append(HtmlTemplete.JQuery.EndReadyFunction());
            sb.Append(HtmlTemplete.Html.EndScript());  
            sb.Append(HtmlTemplete.Mvc.EndSectionItemCell());
            return sb.ToString();
        }

        public static string LabelGetPesoValidationItemCellFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, bool excludePropertyErrors) where TModel : class
        {
            MvcHtmlString editorFor = html.EditorFor(expression);
            String message = ValidationMessageExtensions.ValidationMessage(html.ValidationMessageFor(expression));
            String idEditorFor = HtmlTemplete.Html.IDControl(editorFor);
            String buttonId = idEditorFor + "_getpeso";

            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItemCell());
            sb.Append("<div class='peso'>");
            sb.Append(HtmlTemplete.Mvc.BeginSectionEditorLabel());
            sb.Append(html.LabelFor(expression));
            
            if (!String.IsNullOrEmpty(message))
            {
                if (!excludePropertyErrors)
                {
                    sb.Append(message);
                }
            }
            sb.Append(HtmlTemplete.Mvc.EndSectionEditorLabel());
            sb.Append(HtmlTemplete.Mvc.BeginSectionEditorData());
            sb.Append(editorFor);
            sb.Append("<a href='#' id='" + buttonId + "'>Leer Peso</a>");
            sb.Append(HtmlTemplete.Mvc.EndSectionEditorData());


            sb.Append(HtmlTemplete.Html.BeginScript());
            sb.Append(HtmlTemplete.JQuery.BeginReadyFunction());

            String jqControl = HtmlTemplete.JQuery.LoadControl(buttonId);
            sb.Append(jqControl + ".button();");

            sb.Append(jqControl + ".button().click(leerPeso);");
            //sb.Append(jqControl + ".button().click(function( event ) {");

            // SCRIPT PARA LLER PESO
            //sb.Append("var balanzaAX = new ActiveXObject('Heinz.PortSerial.ActiveX.Balanza'));");

            //sb.Append("});");
            
            sb.Append(HtmlTemplete.JQuery.EndReadyFunction());
            sb.Append(HtmlTemplete.Html.EndScript());
            sb.Append("</div>");
            sb.Append(HtmlTemplete.Mvc.EndSectionItemCell());
            return sb.ToString();
        }
    }
}
