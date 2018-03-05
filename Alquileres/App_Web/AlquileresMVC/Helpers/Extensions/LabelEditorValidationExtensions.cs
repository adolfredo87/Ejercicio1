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
    public static class LabelEditorValidationExtensions
    {
        public static string LabelEditorValidationItemFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            return LabelEditorValidationItemFor(html, expression, HelperBaseExtensions.DefaultExcludePropertyErrors);
        }

        public static string LabelEditorValidationItemFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, bool excludePropertyErrors) where TModel : class
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItem());
            sb.Append(HtmlTemplete.Mvc.SectionEditorLabel(html.LabelFor(expression)));
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(html.EditorFor(expression)));            
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
            sb.Append(HtmlTemplete.Mvc.EndSectionItem());
            return sb.ToString();
        }
        
        public static string LabelEditorValidationItemCellFor<TModel, TValue>(this HtmlHelper<TModel> html, 
            Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            return LabelEditorValidationItemCellFor(html, expression, 1, HelperBaseExtensions.DefaultExcludePropertyErrors);
        }

        public static string LabelEditorValidationItemCellFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, int spanCells) where TModel : class
        {
            return LabelEditorValidationItemCellFor(html, expression, spanCells, HelperBaseExtensions.DefaultExcludePropertyErrors);
        }

        public static string LabelEditorValidationItemCellFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, bool excludePropertyErrors) where TModel : class
        {
            return LabelEditorValidationItemCellFor(html, expression, 1, excludePropertyErrors);
        }

        public static string LabelEditorValidationItemCellFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, int spanCells, bool excludePropertyErrors) where TModel : class
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItemCell(spanCells));
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
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(html.EditorFor(expression)));
            sb.Append(HtmlTemplete.Mvc.EndSectionItemCell());
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <param name="searchUrl">URL que debera ejecutar el control</param>
        /// <param name="queryStrings"></param>
        /// <param name="indexCell">indieces de las columas a mostrar separdas por comas</param>
        /// <param name="separator">String utilizdos para separar el valor de las columnas</param>
        /// <param name="excludePropertyErrors"></param>
        /// <returns></returns>
        public static MvcHtmlString LabelAutoCompleteValidationItemFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, String searchUrl, String queryStrings, String indexCell, 
            String separator, bool excludePropertyErrors) where TModel : class
        {
            MvcHtmlString label = html.LabelFor(expression);
            MvcHtmlString textBoxEditor = html.EditorFor(expression);
            String message = ValidationMessageExtensions.ValidationMessage(html.ValidationMessageFor(expression));

            String idTextBoxEditor = HtmlTemplete.Html.IDControl(textBoxEditor);
            String idLabelSelectedValue = idTextBoxEditor + "-selected-value";   
            
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(HtmlTemplete.Mvc.BeginSectionItem());
            sb.Append(HtmlTemplete.Mvc.SectionEditorLabel(label));
            sb.Append(HtmlTemplete.Mvc.BeginSectionEditorData());
            sb.Append(HtmlTemplete.Mvc.SectionWidget(textBoxEditor));
            sb.Append(HtmlTemplete.Mvc.EndSectionEditorData());
            sb.Append(HtmlTemplete.Mvc.BeginSectionValidation());

            sb.Append(String.Format("<div><label id='{0}'></div>", idLabelSelectedValue));

            sb.Append(!String.IsNullOrEmpty(message) && !excludePropertyErrors ? message: "");
            sb.Append(HtmlTemplete.Mvc.EndSectionValidation());
            

            sb.Append(HtmlTemplete.Html.BeginScript());
            sb.Append(HtmlTemplete.JQuery.BeginReadyFunction());

            sb.Append(HtmlTemplete.JQuery.FunctionParametersData(queryStrings));

            sb.Append(HtmlTemplete.JQuery.LoadControl(idTextBoxEditor));
            sb.Append(".autocomplete(mvcLocal.autocomplete.getConfig(");

            sb.Append(HtmlTemplete.JQuery.LoadControl(idLabelSelectedValue));
            sb.Append(",");
            sb.Append(HtmlTemplete.Html.EncloseComillaSimple(searchUrl));
            sb.Append(",");
            sb.Append("getParametersData");
            sb.Append(",");
            sb.Append(HtmlTemplete.Html.EncloseComillaSimple(indexCell));
            sb.Append(",");
            sb.Append(HtmlTemplete.Html.EncloseComillaSimple(separator));
            sb.Append("));");  //close mvcLocal.getAutocompleteConfig y Autocomplete

            sb.Append(HtmlTemplete.JQuery.EndReadyFunction());
            sb.Append(HtmlTemplete.Html.EndScript());

            sb.Append(HtmlTemplete.Mvc.EndSectionItem());
            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString LabelAutoCompleteValidationItemFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, String searchUrl, String queryStrings, String indexCell,
            String separator) where TModel : class
        {
            return LabelAutoCompleteValidationItemFor(html, expression, searchUrl, queryStrings, indexCell, separator, HelperBaseExtensions.DefaultExcludePropertyErrors);
        }

        public static MvcHtmlString LabelAutoCompleteValidationItemFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, String searchUrl, String queryStrings, String indexCell) 
            where TModel : class
        {
            return LabelAutoCompleteValidationItemFor(html, expression, searchUrl, queryStrings, indexCell, " - ", HelperBaseExtensions.DefaultExcludePropertyErrors);
        }

        public static MvcHtmlString LabelAutoCompleteValidationItemFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, String searchUrl, String indexCell) where TModel : class
        {
            return LabelAutoCompleteValidationItemFor(html, expression, searchUrl, "", indexCell, " - ", HelperBaseExtensions.DefaultExcludePropertyErrors);
        }

    }
}
