using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlquileresMVC.Models;
using AlquileresMVC.Utilitys;
using System.Threading;
using System.Data.OleDb;
using System.Data.Common;

namespace AlquileresMVC.Controllers
{
    [HandleError()]
    public class AlquilerPagoController : Controller
    {
        private AlquileresMVC.Models.DemoAlquileresMVC_VWEntities dbVW = new AlquileresMVC.Models.DemoAlquileresMVC_VWEntities();

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View();
        }

        #region << METODOS JSON - AJAX , JQUERY>>

        [JsonHandleError()]
        public JsonResult GetListData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            var cantAlquilerPagos = dbVW.Cantidad_Alquileres_Pagados_VW_Set.ToList().AsQueryable();

            var filteredcantAlquilerPagos = cantAlquilerPagos;
            filteredcantAlquilerPagos = Utility.Filter<Cantidad_Alquileres_Pagados_VW>(cantAlquilerPagos, _search, searchField, searchOper, searchString);
            var sortedcantAlquilerPagos = Utility.Sort<Cantidad_Alquileres_Pagados_VW>(filteredcantAlquilerPagos, sidx, sord);

            var totalRecords = filteredcantAlquilerPagos.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Tomas las filas que se muestran en la pagina
            // PERMITE OBTENER SOLO LOS QUE SE MOSTRARN EN PANTALLA SEGUN EL NUMERO DE LA PAGINA ESTABLECIDO
            // SE COLOCA AQUÍ PERA MEJORAR EL PERFORMANCE DE LOS DATOS LEIDOS EN LOS LOAD'S
            sortedcantAlquilerPagos = sortedcantAlquilerPagos.Skip((page - 1) * rows).Take(rows);

            // prepara la data que se muestran en el jQGrid
            var data = (from s in sortedcantAlquilerPagos
                        select new
                        {
                            id = s.IDCliente,
                            cell = new object[] { 
                                s.IDCliente, 
                                s.Nombre,
                                s.Telefono,
                                s.Correo,
                                s.NumAlquiler, 
                                s.Fecha, 
                                s.MontoExento, 
                                s.Descuento, 
                                s.MontoTotal, 
                                s.Estatus,
                            }
                        });
            // envia la data al jQGrid
            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = data
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
