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
    public class DescuentoController : Controller
    {
        private AlquileresMVC.Models.DemoAlquileresMVCEntities db = new AlquileresMVC.Models.DemoAlquileresMVCEntities();

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
            var descuentoDetail = db.DescuentoSet.First(d => d.ID == id);
            return View(descuentoDetail);
        }

        public ActionResult Create()
        {
            Descuento descuento = new Descuento();
            Descuento descuentoToIDAdd = db.DescuentoSet.ToList().LastOrDefault();
            Int32 _id = descuentoToIDAdd.ID + 1;
            descuento.ID = _id;
            return View(descuento);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Descuento descuentoToAdd = new Descuento();

            string[] arreglo = new string[collection.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in collection.AllKeys)
            {
                var value = collection[key];
                arreglo[i] = value;
                i++;
            }

            descuentoToAdd.Codigo = arreglo[0];
            descuentoToAdd.Descripcion = arreglo[1];
            String descuento = arreglo[2];
            Double dporcentajeDesc = Double.Parse(descuento);
            descuentoToAdd.PorcentajeDescuento = dporcentajeDesc;
            String estatus = arreglo[3];
            Int32 iEstatus = Int32.Parse(estatus);
            descuentoToAdd.Estatus = iEstatus;

            TryUpdateModel(descuentoToAdd, "Descuento");
            TryUpdateModel(descuentoToAdd, "Descuento", collection.ToValueProvider());

            //valido claves primaria
            if (db.DescuentoSet.FirstOrDefault(d => d.ID == descuentoToAdd.ID) != null)
            {
                ModelState.AddModelError("ID", String.Format("Violacion Clave primaria", "ID"));
            }
            else
            {
                // Si el modelo es valido, guardo en la BD
                if (ModelState.IsValid)
                {
                    db.Connection.Open();
                    DbTransaction dbTransaction = db.Connection.BeginTransaction();
                    try
                    {
                        // Guardar y confirmar.
                        db.AddToDescuentoSet(descuentoToAdd);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                        /// cofirmación de que la operacion resulto exitosa
                        Descuento _entidadToIDAdd = db.DescuentoSet.ToList().LastOrDefault();
                        Int32 _id = _entidadToIDAdd.ID;
                        _entidadToIDAdd.ID = _id;
                        return RedirectToAction("Details/" + _entidadToIDAdd.ID);
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
            }
            return View(descuentoToAdd);

        }

        public ActionResult Edit(Int32 id)
        {
            var descuentoToUpdate = db.DescuentoSet.First(d => d.ID == id);
            ViewData.Model = descuentoToUpdate;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Int32 id, FormCollection form)
        {
            Descuento descuentoToUpdate = db.DescuentoSet.First(d => d.ID == id);

            string[] arreglo = new string[form.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in form.AllKeys)
            {
                var value = form[key];
                arreglo[i] = value;
                i++;
            }

            descuentoToUpdate.Codigo = arreglo[0];
            descuentoToUpdate.Descripcion = arreglo[1];
            String descuento = arreglo[2];
            Double dporcentajeDesc = Double.Parse(descuento);
            descuentoToUpdate.PorcentajeDescuento = dporcentajeDesc;
            String estatus = arreglo[3];
            Int32 iEstatus = Int32.Parse(estatus);
            descuentoToUpdate.Estatus = iEstatus;

            TryUpdateModel(descuentoToUpdate, "Descuento");
            TryUpdateModel(descuentoToUpdate, "Descuento", form.ToValueProvider());

            // Si el modelo es valido, guardo en la BD
            if (ModelState.IsValid)
            {
                db.Connection.Open();
                DbTransaction dbTransaction = db.Connection.BeginTransaction();
                try
                {
                    // Guardar y confirmar.
                    db.SaveChanges();
                    dbTransaction.Commit();
                    /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                    /// cofirmación de que la operacion resulto exitosa
                    return RedirectToAction("Details/" + descuentoToUpdate.ID);
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

            return View(descuentoToUpdate);
        }

        public ActionResult Delete(int id)
        {
            var descuentoToDelete = db.DescuentoSet.First(d => d.ID == id);
            ViewData.Model = descuentoToDelete;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Int32 id, FormCollection form)
        {
            var descuentoToDelete = db.DescuentoSet.First(d => d.ID == id);

            String _Descripcion = descuentoToDelete.Descripcion;

            //valido si el descuento que se borra es de cabecera o de linea
            if (_Descripcion.Contains("Cabecera") || _Descripcion.Contains("Linea"))
            {
                ModelState.AddModelError("ID", String.Format("Ningun descuento de Cabecera o de Linea puede ser eliminado."));
            }
            else
            {
                // Si el modelo es valido, guardo en la BD
                if (ModelState.IsValid)
                {
                    db.Connection.Open();
                    try
                    {
                        // Delete 
                        db.DeleteObject(descuentoToDelete);
                        db.SaveChanges();
                        /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                        /// cofirmación de que la operacion resulto exitosa
                        return RedirectToAction("List");
                    }
                    catch (Exception ex)
                    {
                        HandleException excepcion = new HandleException();
                        String msjLog = "Error en " + ObtenerMetodoEnEjecucion(false).ToString() + ".\n" + excepcion.RegistrarExcepcion(ex, ObtenerMetodoEnEjecucion(false).ToString());
                        excepcion.EscribirLogExcepcion(msjLog); String clientMessage = excepcion.HandleExceptionEx(ex); excepcion = null;
                        ModelState.AddModelError("ID", clientMessage);
                    }
                }
            }

            // Retorno a la vista de listar
            return View(descuentoToDelete);
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
        public JsonResult GetJsonDetails(int id)
        {
            var descuentoDetail = db.DescuentoSet.First(d => d.ID == id);

            return Json(descuentoDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetJsonDetailsEdit(int id)
        {
            var descuentoDetail = db.DescuentoSet.First(d => d.ID == id);

            return Json(descuentoDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetListData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            var descuento = db.DescuentoSet.ToList().AsQueryable();

            // Filter the list
            var filtereddescuento = descuento;

            filtereddescuento = Utility.Filter<Descuento>(descuento, _search, searchField, searchOper, searchString);

            // Sort the list
            var sorteddescuento = Utility.Sort<Descuento>(filtereddescuento, sidx, sord);

            sorteddescuento = sorteddescuento.Skip((page - 1) * rows).Take(rows);

            var totalRecords = filtereddescuento.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Prepare the data to fit the requirement of jQGrid
            var data = (from s in sorteddescuento
                        select new
                        {
                            id = s.ID,
                            cell = new object[] { 
                                s.ID, 
                                s.Codigo, 
                                s.Descripcion, 
                                s.PorcentajeDescuento, 
                                s.Estatus, 
                            }
                        });
            // Send the data to the jQGrid
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
