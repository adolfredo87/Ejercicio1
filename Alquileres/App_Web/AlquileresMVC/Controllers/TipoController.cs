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
    public class TipoController : Controller
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
            AlquileresMVC.Models.Tipo tipoDetail = db.TipoSet.First(cb => cb.ID == id);
            return View(tipoDetail);
        }

        public ActionResult Create()
        {
            AlquileresMVC.Models.Tipo tipo = new AlquileresMVC.Models.Tipo();
            AlquileresMVC.Models.Tipo tipoToIDAdd = db.TipoSet.ToList().LastOrDefault();
            Int32 _id = tipoToIDAdd.ID + 1;
            tipo.ID = _id;
            return View(tipo);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            AlquileresMVC.Models.Tipo tipoToAdd = new AlquileresMVC.Models.Tipo();

            string[] arreglo = new string[collection.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in collection.AllKeys)
            {
                var value = collection[key];
                arreglo[i] = value;
                i++;
            }

            tipoToAdd.Codigo = arreglo[0];
            tipoToAdd.Descripcion = arreglo[1];
            String estatus = arreglo[2];
            Int32 iEstatus = Int32.Parse(estatus);
            tipoToAdd.Estatus = iEstatus;

            TryUpdateModel(tipoToAdd, "Tipo");
            TryUpdateModel(tipoToAdd, "Tipo", collection.ToValueProvider());


            //valido claves primaria
            if (db.ProductoSet.FirstOrDefault(b => b.ID == tipoToAdd.ID) != null)
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
                        db.AddToTipoSet(tipoToAdd);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                        /// cofirmación de que la operacion resulto exitosa
                        AlquileresMVC.Models.Tipo _entidadToIDAdd = db.TipoSet.ToList().LastOrDefault();
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

            return View(tipoToAdd);
        }

        public ActionResult Edit(Int32 id)
        {
            AlquileresMVC.Models.Tipo tipoToUpdate = db.TipoSet.First(cb => cb.ID == id);
            ViewData.Model = tipoToUpdate;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Int32 id, FormCollection form)
        {
            AlquileresMVC.Models.Tipo tipoToUpdate = db.TipoSet.First(cb => cb.ID == id);

            string[] arreglo = new string[form.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in form.AllKeys)
            {
                var value = form[key];
                arreglo[i] = value;
                i++;
            }

            tipoToUpdate.Codigo = arreglo[0];
            tipoToUpdate.Descripcion = arreglo[1];
            String estatus = arreglo[2];
            Int32 iEstatus = Int32.Parse(estatus);
            tipoToUpdate.Estatus = iEstatus;

            TryUpdateModel(tipoToUpdate, "Tipo");
            TryUpdateModel(tipoToUpdate, "Tipo", form.ToValueProvider());

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
                    return RedirectToAction("Details/" + tipoToUpdate.ID);
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

            return View(tipoToUpdate);
        }

        public ActionResult Delete(int id)
        {
            AlquileresMVC.Models.Tipo tipoToDelete = db.TipoSet.First(cb => cb.ID == id);
            ViewData.Model = tipoToDelete;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Int32 id, FormCollection form)
        {
            AlquileresMVC.Models.Tipo tipoToDelete = db.TipoSet.First(cb => cb.ID == id);

            //valido cliente tiene alquiler
            if (db.ProductoSet.FirstOrDefault(b => b.IDTipo == id) != null)
            {
                ModelState.AddModelError("ID", String.Format("Esta intentando Borrar un Tipo que tiene un Producto"));
            }
            else
            {
                try
                {
                    // Delete 
                    db.DeleteObject(tipoToDelete);
                    db.SaveChanges();
                    // Retorno a la vista del listar
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

            return View(tipoToDelete);
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
            var tipoDetail = db.TipoSet.First(cb => cb.ID == id);

            return Json(tipoDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetJsonDetailsEdit(int id)
        {
            var tipoDetail = db.TipoSet.First(cb => cb.ID == id);

            return Json(tipoDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetListData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            var tipo = db.TipoSet.ToList().AsQueryable();

            // Filter the list
            var filteredTipo = tipo;

            filteredTipo = Utility.Filter<Tipo>(tipo, _search, searchField, searchOper, searchString);

            // Sort the list
            var sortedTipo = Utility.Sort<Tipo>(filteredTipo, sidx, sord);

            sortedTipo = sortedTipo.Skip((page - 1) * rows).Take(rows);

            var totalRecords = filteredTipo.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Prepare the data to fit the requirement of jQGrid
            var data = (from s in sortedTipo
                        select new
                        {
                            id = s.ID,
                            cell = new object[] { 
                                s.ID, 
                                s.Codigo, 
                                s.Descripcion, 
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
