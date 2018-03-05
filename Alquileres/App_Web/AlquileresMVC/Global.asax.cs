using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;
using AlquileresMVC.Utilitys;
using AlquileresMVC.Models;

namespace AlquileresMVC
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "Default", // Route name
               "{controller}/{action}/{id}/{subId1}/{subId2}/{subId3}/{subId4}/{subId5}", // URL with parameters
               new
               {
                   controller = "Home",
                   action = "Index",
                   id = UrlParameter.Optional,
                   subId1 = UrlParameter.Optional,
                   subId2 = UrlParameter.Optional,
                   subId3 = UrlParameter.Optional,
                   subId4 = UrlParameter.Optional,
                   subId5 = UrlParameter.Optional
               } // Parameter defaults
           );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}