using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace AlquileresMVC.Helpers
{
    public static class HelperBaseExtensions
    {
        internal const int Capacity = 512;

        internal const bool DefaultExcludePropertyErrors = false;

        internal static class ButtonJQuery
        {
            public static class Save
            {
                public const String Text = "Guardar";
                public const String Icon1 = "ui-icon-disk";
                public const String Icon2 = "";
            }

            public static class Back
            {
                public const String Text = "Volver a la lista";
                public const String Icon1 = "ui-icon-arrowreturnthick-1-w";
                public const String Icon2 = "";
            }

            public static class Create
            {
                public const String Text = "Crear";
                public const String Icon1 = "ui-icon-document";
                public const String Icon2 = "";
            }

            public static class Delete
            {
                public const String Text = "Eliminar";
                public const String Icon1 = "ui-icon-trash";
                public const String Icon2 = "";
            }

            public static class Edit
            {
                public const String Text = "Editar";
                public const String Icon1 = "ui-icon-pencil";
                public const String Icon2 = "";
            }

            public static class OK
            {
                public const String Text = "Aceptar";
                public const String Icon1 = "ui-icon-pencil";
                public const String Icon2 = "";
            }

            public static class Home
            {
                public const String Text = "Página Inicio";
                public const String Icon1 = "ui-icon-home";
                public const String Icon2 = "";

            }

            public static class Print
            {
                public const String Text = "Imprimir";
                public const String Icon1 = "ui-icon-print";
                public const String Icon2 = "";
            }
        }

        internal static class LinkButton
        {
            public static class Delete{
                public const String Image = "../../Content/images/hbotons/delete.png";
            }

            public static class View
            {
                public const String Image = "";
            }

            public static class Edit
            {
                public const String Image = "";
            }

            public static class New
            {
                public const String Image = "";
            }

            public static class Find
            {
                public const String Image = "";
            }
        }

        internal static String DefaultMessageDelete = @"¡Esta acción eliminará permanentemente el ítem seleccionado, compruebe que es ítem correcto y pulse el botón Eliminar para completar la acción!.";
    
    }
}
