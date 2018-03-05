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
    public static class DropDownListExtensions
    {
        //
        // Summary:
        //     Returns an HTML select element for each property in the object that is represented
        //     by the specified expression using the specified list items.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to
        //     render.
        //
        //   selectList:
        //     A collection of System.Web.Mvc.SelectListItem objects that are used to populate
        //     the drop-down list.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        //   TProperty:
        //     The type of the value.
        //
        // Returns:
        //     An HTML select element for each property in the object that is represented
        //     by the expression.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The expression parameter is null.
        public static MvcHtmlString DropDownListItemFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            MvcHtmlString label = html.LabelContainerFor(expression);
            MvcHtmlString dropDownList = html.DropDownListFor(expression, selectList);
            MvcHtmlString message = html.ValidationMessageFor(expression);
            String dropDownListID = HtmlTemplete.Html.IDControl(dropDownList);

            sb.Append(HtmlTemplete.Mvc.BeginSectionItem());
            sb.Append(HtmlTemplete.Mvc.SectionEditorLabel(label));
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(dropDownList));
            sb.Append(HtmlTemplete.Mvc.SectionValidation(message));

            sb.Append(HtmlTemplete.Html.BeginScript());
            sb.Append(HtmlTemplete.JQuery.BeginReadyFunction());
            sb.Append(HtmlTemplete.JQuery.LoadControl(dropDownListID) + ".combobox();");
            sb.Append(HtmlTemplete.JQuery.EndReadyFunction());
            sb.Append(HtmlTemplete.Html.EndScript());

            sb.Append(HtmlTemplete.Mvc.EndSectionItem());

            return MvcHtmlString.Create(sb.ToString());
        }
        //
        // Summary:
        //     Returns an HTML select element for each property in the object that is represented
        //     by the specified expression using the specified list items and HTML attributes.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to
        //     render.
        //
        //   selectList:
        //     A collection of System.Web.Mvc.SelectListItem objects that are used to populate
        //     the drop-down list.
        //
        //   htmlAttributes:
        //     A dictionary that contains the HTML attributes to set for the element.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        //   TProperty:
        //     The type of the value.
        //
        // Returns:
        //     An HTML select element for each property in the object that is represented
        //     by the expression.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The expression parameter is null.
        public static MvcHtmlString DropDownListItemFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            MvcHtmlString label = html.LabelContainerFor(expression);
            MvcHtmlString dropDownList = html.DropDownListFor(expression, selectList, htmlAttributes);
            MvcHtmlString message = html.ValidationMessageFor(expression);
            String dropDownListID = HtmlTemplete.Html.IDControl(dropDownList);

            sb.Append(HtmlTemplete.Mvc.BeginSectionItem());
            sb.Append(HtmlTemplete.Mvc.SectionEditorLabel(label));
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(dropDownList));
            sb.Append(HtmlTemplete.Mvc.SectionValidation(message));

            sb.Append(HtmlTemplete.Html.BeginScript());
            sb.Append(HtmlTemplete.JQuery.BeginReadyFunction());
            sb.Append(HtmlTemplete.JQuery.LoadControl(dropDownListID) + ".combobox();");
            sb.Append(HtmlTemplete.JQuery.EndReadyFunction());
            sb.Append(HtmlTemplete.Html.EndScript());

            sb.Append(HtmlTemplete.Mvc.EndSectionItem());

            return MvcHtmlString.Create(sb.ToString());
        }
        //
        // Summary:
        //     Returns an HTML select element for each property in the object that is represented
        //     by the specified expression using the specified list items and HTML attributes.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to
        //     render.
        //
        //   selectList:
        //     A collection of System.Web.Mvc.SelectListItem objects that are used to populate
        //     the drop-down list.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        //   TProperty:
        //     The type of the value.
        //
        // Returns:
        //     An HTML select element for each property in the object that is represented
        //     by the expression.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The expression parameter is null.
        public static MvcHtmlString DropDownListItemFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            MvcHtmlString label = html.LabelContainerFor(expression);
            MvcHtmlString dropDownList = html.DropDownListFor(expression, selectList, htmlAttributes);
            MvcHtmlString message = html.ValidationMessageFor(expression);
            String dropDownListID = HtmlTemplete.Html.IDControl(dropDownList);

            sb.Append(HtmlTemplete.Mvc.BeginSectionItem());
            sb.Append(HtmlTemplete.Mvc.SectionEditorLabel(label));            
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(dropDownList));
            sb.Append(HtmlTemplete.Mvc.SectionValidation(message));        

            sb.Append(HtmlTemplete.Html.BeginScript());
            sb.Append(HtmlTemplete.JQuery.BeginReadyFunction());
            sb.Append(HtmlTemplete.JQuery.LoadControl(dropDownListID) + ".combobox();");
            sb.Append(HtmlTemplete.JQuery.EndReadyFunction());
            sb.Append(HtmlTemplete.Html.EndScript());

            sb.Append(HtmlTemplete.Mvc.EndSectionItem());

            return MvcHtmlString.Create(sb.ToString());
        }
        //
        // Summary:
        //     Returns an HTML select element for each property in the object that is represented
        //     by the specified expression using the specified list items and option label.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to
        //     render.
        //
        //   selectList:
        //     A collection of System.Web.Mvc.SelectListItem objects that are used to populate
        //     the drop-down list.
        //
        //   optionLabel:
        //     The text for a default empty item. This parameter can be null.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        //   TProperty:
        //     The type of the value.
        //
        // Returns:
        //     An HTML select element for each property in the object that is represented
        //     by the expression.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The expression parameter is null.
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
        {
            return MvcHtmlString.Create("");
        }
        //
        // Summary:
        //     Returns an HTML select element for each property in the object that is represented
        //     by the specified expression using the specified list items, option label,
        //     and HTML attributes.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to
        //     render.
        //
        //   selectList:
        //     A collection of System.Web.Mvc.SelectListItem objects that are used to populate
        //     the drop-down list.
        //
        //   optionLabel:
        //     The text for a default empty item. This parameter can be null.
        //
        //   htmlAttributes:
        //     A dictionary that contains the HTML attributes to set for the element.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        //   TProperty:
        //     The type of the value.
        //
        // Returns:
        //     An HTML select element for each property in the object that is represented
        //     by the expression.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The expression parameter is null.
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            return MvcHtmlString.Create("");
        }
        //
        // Summary:
        //     Returns an HTML select element for each property in the object that is represented
        //     by the specified expression using the specified list items, option label,
        //     and HTML attributes.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to
        //     render.
        //
        //   selectList:
        //     A collection of System.Web.Mvc.SelectListItem objects that are used to populate
        //     the drop-down list.
        //
        //   optionLabel:
        //     The text for a default empty item. This parameter can be null.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        //   TProperty:
        //     The type of the value.
        //
        // Returns:
        //     An HTML select element for each property in the object that is represented
        //     by the expression.
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
        {
            return MvcHtmlString.Create("");
        }
        //
        // Summary:
        //     Returns an HTML select element for each property in the object that is represented
        //     by the specified expression using the specified list items.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to
        //     render.
        //
        //   selectList:
        //     A collection of System.Web.Mvc.SelectListItem objects that are used to populate
        //     the drop-down list.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        //   TProperty:
        //     The type of the value.
        //
        // Returns:
        //     An HTML select element for each property in the object that is represented
        //     by the expression.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The expression parameter is null.
        public static MvcHtmlString DropDownListItemCellFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            MvcHtmlString label = html.LabelFor(expression);
            MvcHtmlString dropDownList = html.DropDownListFor(expression, selectList);
            MvcHtmlString message = html.ValidationMessageFor(expression);
            String dropDownListID = HtmlTemplete.Html.IDControl(dropDownList);

            sb.Append(HtmlTemplete.Mvc.BeginSectionItemCell());
            sb.Append(HtmlTemplete.Mvc.BeginSectionEditorLabel());
            sb.Append(label);
            sb.Append(message);
            sb.Append(HtmlTemplete.Mvc.EndSectionEditorLabel());
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(dropDownList));

            sb.Append(HtmlTemplete.Html.BeginScript());
            sb.Append(HtmlTemplete.JQuery.BeginReadyFunction());
            sb.Append(HtmlTemplete.JQuery.LoadControl(dropDownListID) + ".combobox();");
            sb.Append(HtmlTemplete.JQuery.EndReadyFunction());
            sb.Append(HtmlTemplete.Html.EndScript());

            sb.Append(HtmlTemplete.Mvc.EndSectionItemCell());

            return MvcHtmlString.Create(sb.ToString());
        }
        //
        // Summary:
        //     Returns an HTML select element for each property in the object that is represented
        //     by the specified expression using the specified list items and HTML attributes.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to
        //     render.
        //
        //   selectList:
        //     A collection of System.Web.Mvc.SelectListItem objects that are used to populate
        //     the drop-down list.
        //
        //   htmlAttributes:
        //     A dictionary that contains the HTML attributes to set for the element.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        //   TProperty:
        //     The type of the value.
        //
        // Returns:
        //     An HTML select element for each property in the object that is represented
        //     by the expression.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The expression parameter is null.
        public static MvcHtmlString DropDownListItemCellFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            MvcHtmlString label = html.LabelFor(expression);
            MvcHtmlString dropDownList = html.DropDownListFor(expression, selectList, htmlAttributes);
            MvcHtmlString message = html.ValidationMessageFor(expression);
            String dropDownListID = HtmlTemplete.Html.IDControl(dropDownList);

            sb.Append(HtmlTemplete.Mvc.BeginSectionItemCell());
            sb.Append(HtmlTemplete.Mvc.BeginSectionEditorLabel());
            sb.Append(label);
            sb.Append(message);
            sb.Append(HtmlTemplete.Mvc.EndSectionEditorLabel());
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(dropDownList));

            sb.Append(HtmlTemplete.Html.BeginScript());
            sb.Append(HtmlTemplete.JQuery.BeginReadyFunction());
            sb.Append(HtmlTemplete.JQuery.LoadControl(dropDownListID) + ".combobox();");
            sb.Append(HtmlTemplete.JQuery.EndReadyFunction());
            sb.Append(HtmlTemplete.Html.EndScript());

            sb.Append(HtmlTemplete.Mvc.EndSectionItemCell());

            return MvcHtmlString.Create(sb.ToString());
        }
        //
        // Summary:
        //     Returns an HTML select element for each property in the object that is represented
        //     by the specified expression using the specified list items and HTML attributes.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to
        //     render.
        //
        //   selectList:
        //     A collection of System.Web.Mvc.SelectListItem objects that are used to populate
        //     the drop-down list.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        //   TProperty:
        //     The type of the value.
        //
        // Returns:
        //     An HTML select element for each property in the object that is represented
        //     by the expression.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The expression parameter is null.
        public static MvcHtmlString DropDownListItemCellFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            MvcHtmlString label = html.LabelFor(expression);
            MvcHtmlString dropDownList = html.DropDownListFor(expression, selectList, htmlAttributes);
            MvcHtmlString message = html.ValidationMessageFor(expression);
            String dropDownListID = HtmlTemplete.Html.IDControl(dropDownList);

            sb.Append(HtmlTemplete.Mvc.BeginSectionItemCell());
            sb.Append(HtmlTemplete.Mvc.BeginSectionEditorLabel());
            sb.Append(label);
            sb.Append(message);
            sb.Append(HtmlTemplete.Mvc.EndSectionEditorLabel());
            sb.Append(HtmlTemplete.Mvc.SectionEditorData(dropDownList));

            sb.Append(HtmlTemplete.Html.BeginScript());
            sb.Append(HtmlTemplete.JQuery.BeginReadyFunction());
            sb.Append(HtmlTemplete.JQuery.LoadControl(dropDownListID) + ".combobox();");
            sb.Append(HtmlTemplete.JQuery.EndReadyFunction());
            sb.Append(HtmlTemplete.Html.EndScript());

            sb.Append(HtmlTemplete.Mvc.EndSectionItemCell());

            return MvcHtmlString.Create(sb.ToString());
        }

    }

}
