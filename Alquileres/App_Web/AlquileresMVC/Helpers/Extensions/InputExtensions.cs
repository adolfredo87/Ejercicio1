using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;

namespace AlquileresMVC.Helpers
{
    public static class InputExtensions
    {
        //
        // Summary:
        //     Returns a check box input element for each property in the object that is
        //     represented by the specified expression.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to
        //     render.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        // Returns:
        //     An HTML input element whose type attribute is set to "checkbox" for each
        //     property in the object that is represented by the specified expression.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The expression parameter is null.
        public static MvcHtmlString CheckBoxItemFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);

            sb.Append(HtmlTemplete.Mvc.BeginSectionItem());
            sb.Append(HtmlTemplete.Mvc.SectionEditorLabel(html.LabelFor(expression)));
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(html.CheckBoxFor(expression)));
            sb.Append(HtmlTemplete.Mvc.EndSectionItem());

            return MvcHtmlString.Create(sb.ToString());
        }
        //
        // Summary:
        //     Returns a check box input element for each property in the object that is
        //     represented by the specified expression, using the specified HTML attributes.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to
        //     render.
        //
        //   htmlAttributes:
        //     A dictionary that contains the HTML attributes to set for the element.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        // Returns:
        //     An HTML input element whose type attribute is set to "checkbox" for each
        //     property in the object that is represented by the specified expression, using
        //     the specified HTML attributes.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The expression parameter is null.
        public static MvcHtmlString CheckBoxItemFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, IDictionary<string, object> htmlAttributes)
        {
            return MvcHtmlString.Create("");
        }
        public static MvcHtmlString CheckBoxItemFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, int>> expression, IDictionary<string, object> htmlAttributes)
        {
            return MvcHtmlString.Create("");
        }
        //
        // Summary:
        //     Returns a check box input element for each property in the object that is
        //     represented by the specified expression, using the specified HTML attributes.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to
        //     render.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        // Returns:
        //     An HTML input element whose type attribute is set to "checkbox" for each
        //     property in the object that is represented by the specified expression, using
        //     the specified HTML attributes.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The expression parameter is null.
        public static MvcHtmlString CheckBoxItemFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, object htmlAttributes)
        {
            return MvcHtmlString.Create("");
        }
        public static MvcHtmlString CheckBoxItemFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, int>> expression, object htmlAttributes)
        {
            return MvcHtmlString.Create("");
        }
        public static MvcHtmlString CheckBoxItemCell(this HtmlHelper html, String label, String text, String name)
        {
            return CheckBoxItemCell(html, label, text, name, false);
        }
        public static MvcHtmlString CheckBoxItemCell(this HtmlHelper html, String label, String text, String name, Boolean isChecked)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            MvcHtmlString mvcLabel = MvcHtmlString.Create("<label>" + label + "</label>");

            MvcHtmlString checkBox = html.CheckBox(name);
            String checkBoxID = HtmlTemplete.Html.IDControl(checkBox);

            sb.Append(HtmlTemplete.Mvc.BeginSectionItemCell());
            sb.Append(HtmlTemplete.Mvc.BeginSectionEditorLabel());
            sb.Append(mvcLabel);
            sb.Append(HtmlTemplete.Mvc.EndSectionEditorLabel());
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(checkBox));

            sb.Append(HtmlTemplete.Mvc.EndSectionItemCell());

            return MvcHtmlString.Create(sb.ToString());
        }
        public static MvcHtmlString CheckBoxItemCellFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, Boolean>> expression)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            MvcHtmlString label = html.LabelFor(expression);

            MvcHtmlString checkBox = html.CheckBoxFor(expression);
            String checkBoxID = HtmlTemplete.Html.IDControl(checkBox);

            sb.Append(HtmlTemplete.Mvc.BeginSectionItemCell());
            sb.Append(HtmlTemplete.Mvc.SectionEditorLabel(label));
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(checkBox));

            sb.Append(HtmlTemplete.Mvc.EndSectionItemCell());

            return MvcHtmlString.Create(sb.ToString());
        }
        //public static MvcHtmlString CheckBoxCell(this HtmlHelper htmlHelper, String name, Boolean isChecked, object htmlAttributes)
        //{
        //    return MvcHtmlString.Create("");
        //}
        public static MvcHtmlString ActivateLabelItemFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, int?>> expression, Boolean isChecked)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);

            MvcHtmlString mvcLabel = html.LabelFor(expression);
            MvcHtmlString checkBox = html.Label(isChecked ? "Activo" : "Inactivo");

            sb.Append(HtmlTemplete.Mvc.BeginSectionItem());
            sb.Append(HtmlTemplete.Mvc.SectionEditorLabel(mvcLabel));
            sb.Append(HtmlTemplete.Mvc.SectionEditorData("<span class='" + (isChecked ? "Activo" : "Inactivo") + "'>" + checkBox.ToHtmlString() + "</span>"));
            sb.Append(HtmlTemplete.Mvc.EndSectionItem());

            return MvcHtmlString.Create(sb.ToString());
        }

    }
}
