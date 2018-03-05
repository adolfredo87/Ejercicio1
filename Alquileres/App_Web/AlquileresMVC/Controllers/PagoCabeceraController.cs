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
    public class PagoCabeceraController : Controller
    {
        private AlquileresMVC.Models.DemoAlquileresMVCEntities db = new AlquileresMVC.Models.DemoAlquileresMVCEntities();
        private AlquileresMVC.Models.DemoAlquileresMVC_VWEntities dbVW = new AlquileresMVC.Models.DemoAlquileresMVC_VWEntities();

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Cliente cliente = db.ClienteSet.First(c => c.ID == id);
            var listAlquiler = db.AlquilerSet.Where(c => c.IDCliente == id);
            Double _dMontoEstimado = 0; _dMontoEstimado = (from e in listAlquiler select e.PrecioEstimado).Sum().Value;
            PagoCabecera pagoCabeceraDetail = db.PagoCabeceraSet.ToList().LastOrDefault();
            Int32 _iID = pagoCabeceraDetail.ID; _iID = _iID + 1;
            Int32 _iIDCliente = cliente.ID;
            DateTime _dFecha = DateTime.Now;
            pagoCabeceraDetail.IDCliente = _iIDCliente;
            pagoCabeceraDetail.MontoTotal = _dMontoEstimado;
            pagoCabeceraDetail.Fecha = _dFecha;
            pagoCabeceraDetail.ClienteLoad();
            return View(pagoCabeceraDetail);
        }

        public ActionResult Edit(Int32 id)
        {
            Cliente cliente = db.ClienteSet.First(c => c.ID == id);
            var listAlquiler = db.AlquilerSet.Where(c => c.IDCliente == id);
            Double _dMontoEstimado = 0; _dMontoEstimado = (from e in listAlquiler select e.PrecioEstimado).Sum().Value;
            PagoCabecera pagoCabeceraToUpdate = db.PagoCabeceraSet.ToList().LastOrDefault();
            Int32 _iID = pagoCabeceraToUpdate.ID; _iID = _iID + 1;
            Int32 _iIDCliente = cliente.ID;
            DateTime _dFecha = DateTime.Now;
            pagoCabeceraToUpdate.IDCliente = _iIDCliente;
            pagoCabeceraToUpdate.MontoTotal = _dMontoEstimado;
            pagoCabeceraToUpdate.Fecha = _dFecha;
            pagoCabeceraToUpdate.ClienteLoad();
            return View(pagoCabeceraToUpdate);
        }

        [HttpPost]
        public ActionResult Edit(Int32 id, FormCollection form)
        {
            Cliente cliente = db.ClienteSet.First(c => c.ID == id);
            PagoCabecera pagoCabeceraToUpdate = new PagoCabecera();

            var listAlquiler = db.AlquilerSet.Where(c => c.IDCliente == id);
            Double _dMontoEstimado = 0; _dMontoEstimado = (from e in listAlquiler select e.PrecioEstimado).Sum().Value;

            Int32 _iIDCliente = cliente.ID;
            DateTime _dFecha = DateTime.Now;
            pagoCabeceraToUpdate.IDCliente = _iIDCliente;
            pagoCabeceraToUpdate.MontoTotal = _dMontoEstimado;
            pagoCabeceraToUpdate.Fecha = _dFecha;
            Int32 iEstatus = 1;
            pagoCabeceraToUpdate.Estatus = iEstatus;

            TryUpdateModel(pagoCabeceraToUpdate, "PagoCabecera");

            // Si el modelo es valido, guardo en la BD
            if (ModelState.IsValid)
            {
                db.Connection.Open();
                DbTransaction dbTransaction = db.Connection.BeginTransaction();
                try
                {
                    // Guardar y confirmar.
                    db.AddToPagoCabeceraSet(pagoCabeceraToUpdate);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                    /// cofirmación de que la operacion resulto exitosa
                    return RedirectToAction("List");
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    HandleException excepcion = new HandleException();
                    String msjLog = "Error en " + ObtenerMetodoEnEjecucion(false).ToString() + ".\n" + excepcion.RegistrarExcepcion(ex, ObtenerMetodoEnEjecucion(false).ToString());
                    excepcion.EscribirLogExcepcion(msjLog); String clientMessage = excepcion.HandleExceptionEx(ex); excepcion = null;
                    ModelState.AddModelError("ID", clientMessage);
                }
            }

            // Refresca el formulario con los datos guardados
            return View(pagoCabeceraToUpdate);
        }

        private System.String ObtenerMetodoEnEjecucion(bool nombreCorto)
        {
            if (nombreCorto)
            {
                return new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
            }
            else
            {
                return this.ToString() + "." + new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
            }
        }

        #region << METODOS JSON - AJAX , JQUERY>>

        [JsonHandleError()]
        public JsonResult GetListData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            var cantAlquiler = dbVW.Cantidad_Alquileres_Por_Pagar_VW_Set.ToList().AsQueryable();
            
            var filteredcantAlquiler = cantAlquiler;
            filteredcantAlquiler = Utility.Filter<Cantidad_Alquileres_Por_Pagar_VW>(cantAlquiler, _search, searchField, searchOper, searchString);
            var sortedcantAlquiler = Utility.Sort<Cantidad_Alquileres_Por_Pagar_VW>(filteredcantAlquiler, sidx, sord);

            var totalRecords = filteredcantAlquiler.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Tomas las filas que se muestran en la pagina
            // PERMITE OBTENER SOLO LOS QUE SE MOSTRARN EN PANTALLA SEGUN EL NUMERO DE LA PAGINA ESTABLECIDO
            // SE COLOCA AQUÍ PERA MEJORAR EL PERFORMANCE DE LOS DATOS LEIDOS EN LOS LOAD'S
            sortedcantAlquiler = sortedcantAlquiler.Skip((page - 1) * rows).Take(rows);

            // prepara la data que se muestran en el jQGrid
            var data = (from s in sortedcantAlquiler
                        select new
                        {
                            id = s.IDCliente,
                            cell = new object[] { 
                                s.IDCliente, 
                                s.Nombre,
                                s.Telefono,
                                s.Correo,
                                s.NumAlquiler, 
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

        [JsonHandleError()]
        public JsonResult GetListAlquileres(String id, string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            Int32 _iIDCliente = Int32.Parse(id);
            var alquileres = db.AlquilerSet.Where(a => a.IDCliente == _iIDCliente);
            
            var alquileresPorPagar = alquileres.Where(a => a.Estatus == 1).ToList().AsQueryable();
            
            var filteredAlquileres = Utility.Filter<Alquiler>(alquileresPorPagar, _search, searchField, searchOper, searchString);
            var sortedAlquileres = Utility.Sort<Alquiler>(filteredAlquileres, sidx, sord);

            var totalRecords = filteredAlquileres.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Tomas las filas que se muestran en la pagina
            // PERMITE OBTENER SOLO LOS QUE SE MOSTRARN EN PANTALLA SEGUN EL NUMERO DE LA PAGINA ESTABLECIDO
            // SE COLOCA AQUÍ PERA MEJORAR EL PERFORMANCE DE LOS DATOS LEIDOS EN LOS LOAD'S
            sortedAlquileres = sortedAlquileres.Skip((page - 1) * rows).Take(rows);

            // prepara la data que se muestran en el jQGrid
            var data = (from s in sortedAlquileres
                        select new
                        {
                            id = s.ID,
                            cell = new object[] { 
                                s.ID, 
                                s.ClienteLoad().Nombre, 
                                s.BicicletaLoad().Marca,
                                s.TiempoHora, 
                                s.TiempoDia, 
                                s.TiempoSemana, 
                                s.PrecioEstimado, 
                                s.Estatus, 
                            }
                        });

            // envia la data al jQGrid
            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = data.Skip((page - 1) * rows).Take(rows)
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
