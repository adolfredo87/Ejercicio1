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
    // Summary:
    //     Represents support for the HTML label element in an ASP.NET MVC view.
    public static class LabelExtensions
    {
        //
        // Summary:
        //     Returns an HTML label element and the property name of the property that
        //     is represented by the specified expression.
        //
        // Parameters:
        //   html:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the property to display.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        //   TValue:
        //     The type of the value.
        //
        // Returns:
        //     An HTML label element and the property name of the property that is represented
        //     by the expression.
        public static MvcHtmlString LabelContainerFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            ModelMetadata metaData = ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData);
            metaData = ModelMetadataProviders.Current.GetMetadataForType(null, metaData.ContainerType);
            String label = HtmlTemplete.Mvc.Label(metaData.ModelType.Name, metaData.DisplayName);
            return MvcHtmlString.Create(label);
        }

    }
}