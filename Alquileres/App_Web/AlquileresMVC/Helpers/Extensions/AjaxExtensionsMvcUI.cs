using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.Mvc.Ajax;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace AlquileresMVC.Helpers
{
    public static class AjaxExtensionsMvcUI
    {
        // Summary:
        //     Represents support for ASP.NET AJAX within an ASP.NET MVC application.

        #region ActionLink
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        //public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. This object
        //     is typically created by using object initializer syntax.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        //public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, object routeValues, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        //public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        //public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. This object
        //     is typically created by using object initializer syntax.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        //public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes);
        //
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        //public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes);
        //
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. This object
        //     is typically created by using object initializer syntax.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        //public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        //public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. This object
        //     is typically created by using object initializer syntax.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        //public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes);
        //
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        //public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes);
        //
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   protocol:
        //     The protocol for the URL, such as "http" or "https".
        //
        //   hostName:
        //     The host name for the URL.
        //
        //   fragment:
        //     The URL fragment name (the anchor name).
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. This object
        //     is typically created by using object initializer syntax.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        //public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes);
        //
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   protocol:
        //     The protocol for the URL, such as "http" or "https".
        //
        //   hostName:
        //     The host name for the URL.
        //
        //   fragment:
        //     The URL fragment name (the anchor name).
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        //public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes);

        public static MvcHtmlString ActionLinkImage(this AjaxHelper ajaxHelper, string urlImage, string linkText, string actionName, object routeValues, AjaxOptions ajaxOptions)
        {
            String mvc = AjaxExtensions.ActionLink(ajaxHelper, linkText, actionName, ajaxOptions).ToHtmlString();
            StringBuilder sb = new StringBuilder("", HelperBaseExtensions.Capacity);
            sb.Append(mvc.Substring(0, mvc.LastIndexOf(linkText)));
            sb.Append(String.Format("<img src='{0}'/>", urlImage));
            sb.Append("</a>");

            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString ActionLinkDelete(this AjaxHelper ajaxHelper, String uniqueID, string linkText, string actionName, object routeValues)
        {
            String table = String.Format("$('#MvcJqTable{0}')[0].mvcUI.ajax.", uniqueID);
            AjaxOptions ajaxOptions = new AjaxOptions(){
                OnBegin = table + "onBegin",
                OnComplete = table + "onComplete",
                OnFailure = table + "onFailure",
                OnSuccess = table + "onSuccess",
                LoadingElementId = table + "loadingElementId",
                UpdateTargetId = table + "updateTargetId",
            };
            return ActionLinkImage(ajaxHelper, HelperBaseExtensions.LinkButton.Delete.Image, linkText, actionName, routeValues, ajaxOptions);
        }

        #endregion

        #region BeginForm
        //
        // Summary:
        //     Writes an opening <form> tag to the response.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginForm(this AjaxHelper ajaxHelper, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Writes an opening <form> tag to the response.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   actionName:
        //     The name of the action method that will handle the request.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginForm(this AjaxHelper ajaxHelper, string actionName, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Writes an opening <form> tag to the response.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   actionName:
        //     The name of the action method that will handle the request.
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. This object
        //     is typically created by using object initializer syntax.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginForm(this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Writes an opening <form> tag to the response.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   actionName:
        //     The name of the action method that will handle the request.
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginForm(this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Writes an opening <form> tag to the response.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   actionName:
        //     The name of the action method that will handle the request.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginForm(this AjaxHelper ajaxHelper, string actionName, string controllerName, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Writes an opening <form> tag to the response.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   actionName:
        //     The name of the action method that will handle the request.
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. This object
        //     is typically created by using object initializer syntax.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginForm(this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes);
        //
        // Summary:
        //     Writes an opening <form> tag to the response.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   actionName:
        //     The name of the action method that will handle the request.
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element..
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginForm(this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes);
        //
        // Summary:
        //     Writes an opening <form> tag to the response.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   actionName:
        //     The name of the action method that will handle the request.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. This object
        //     is typically created by using object initializer syntax.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginForm(this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Writes an opening <form> tag to the response.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   actionName:
        //     The name of the action method that will handle the request.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginForm(this AjaxHelper ajaxHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Writes an opening <form> tag to the response.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   actionName:
        //     The name of the action method that will handle the request.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. This object
        //     is typically created by using object initializer syntax.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginForm(this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes);
        //
        // Summary:
        //     Writes an opening <form> tag to the response.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   actionName:
        //     The name of the action method that will handle the request.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginForm(this AjaxHelper ajaxHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes);
        //
        // Summary:
        //     Writes an opening <form> tag to the response using the specified routing
        //     information.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   routeName:
        //     The name of the route to use to obtain the form post URL.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginRouteForm(this AjaxHelper ajaxHelper, string routeName, AjaxOptions ajaxOptions);

        #endregion

        #region BeginRouteForm
        //
        // Summary:
        //     Writes an opening <form> tag to the response using the specified routing
        //     information.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   routeName:
        //     The name of the route to use to obtain the form post URL.
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. This object
        //     is typically created by using object initializer syntax.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginRouteForm(this AjaxHelper ajaxHelper, string routeName, object routeValues, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Writes an opening <form> tag to the response using the specified routing
        //     information.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   routeName:
        //     The name of the route to use to obtain the form post URL.
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginRouteForm(this AjaxHelper ajaxHelper, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions);
        //
        // Summary:
        //     Writes an opening <form> tag to the response using the specified routing
        //     information.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   routeName:
        //     The name of the route to use to obtain the form post URL.
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. This object
        //     is typically created by using object initializer syntax.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginRouteForm(this AjaxHelper ajaxHelper, string routeName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes);
        //
        // Summary:
        //     Writes an opening <form> tag to the response using the specified routing
        //     information.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   routeName:
        //     The name of the route to use to obtain the form post URL.
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An opening <form> tag.
        //public static MvcForm BeginRouteForm(this AjaxHelper ajaxHelper, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes);

        #endregion

    }
}
