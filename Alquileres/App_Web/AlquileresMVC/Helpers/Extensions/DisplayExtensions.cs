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
    public static class DisplayExtensions
    {
        public static MvcHtmlString DisplayNameContainerFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            ModelMetadata metaData = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, html.ViewData);
            metaData = ModelMetadataProviders.Current.GetMetadataForType(null, metaData.ContainerType);
            return MvcHtmlString.Create(metaData.DisplayName ?? (metaData.PropertyName ?? ExpressionHelper.GetExpressionText(expression)));
        }

        public static MvcHtmlString DisplayNameFor<TModel, TProperty>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression) where TModel : class
        {
            ModelMetadata metaData = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, html.ViewData);
            return MvcHtmlString.Create(DisplayNameFromLambdaFor(html, expression));
        }

        public static MvcHtmlString DisplayNameFor<TModel>(this HtmlHelper<TModel> html)
        {
            return DisplayNameFor(html, "", "");
        }

        public static MvcHtmlString DisplayNameFor<TModel>(this HtmlHelper<TModel> html, String preText)
        {
            return DisplayNameFor(html, preText, "");
        }

        public static MvcHtmlString DisplayNameFor<TModel>(this HtmlHelper<TModel> html, String preText, String postText)
        {
            string value = "";
            try
            {
                value = DisplayNameForEntityObject(html.ViewData.GetType());
                value = preText + value + postText;
            }
            catch { }
            return MvcHtmlString.Create(value);
        }

        public static MvcHtmlString DisplayNameEditFor<TModel>(this HtmlHelper<TModel> html)
        {
            return DisplayNameFor(html, "Editar ");
        }

        public static MvcHtmlString DisplayNameCreateFor<TModel>(this HtmlHelper<TModel> html)
        {
            return DisplayNameFor(html, "Crear ");
        }

        public static MvcHtmlString DisplayNameDeleteFor<TModel>(this HtmlHelper<TModel> html)
        {
            return DisplayNameFor(html, "Eliminar ");
        }

        public static MvcHtmlString DisplayNameDetailsFor<TModel>(this HtmlHelper<TModel> html)
        {
            return DisplayNameFor(html, "Detalle ");
        }

        internal static String DisplayNameFromLambdaFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression) where TModel : class
        {
            ModelMetadata metaData = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, html.ViewData);
            return metaData.DisplayName ?? (metaData.PropertyName ?? ExpressionHelper.GetExpressionText(expression));
        }

        internal static String DisplayNameForEntityObject(Type type)
        {
            ModelMetadata metaData = ModelMetadataProviders.Current.GetMetadataForType(null, FindEntityObject(type));
            return metaData.DisplayName ?? (metaData.PropertyName ?? "");
        }

        internal static Type FindEntityObject(Type type)
        {
            if (type.GetGenericArguments().Length > 0)
            {
                if (type.GetGenericArguments()[0].BaseType != null && type.GetGenericArguments()[0].BaseType.Name == "EntityObject")
                {
                    return type.GetGenericArguments()[0];
                }
                return FindEntityObject(type.GetGenericArguments()[0]);
            }
            return type;
        }

    }
}
