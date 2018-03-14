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
    public class ModeloController : Controller
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
            AlquileresMVC.Models.Modelo modeloDetail = db.ModeloSet.First(cb => cb.ID == id);
            return View(modeloDetail);
        }

        public ActionResult Create()
        {
            AlquileresMVC.Models.Modelo modelo = new AlquileresMVC.Models.Modelo();
            AlquileresMVC.Models.Modelo modeloToIDAdd = db.ModeloSet.ToList().LastOrDefault();
            Int32 _id = modeloToIDAdd.ID + 1;
            modelo.ID = _id;
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            AlquileresMVC.Models.Modelo modeloToAdd = new AlquileresMVC.Models.Modelo();

            string[] arreglo = new string[collection.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in collection.AllKeys)
            {
                var value = collection[key];
                arreglo[i] = value;
                i++;
            }

            modeloToAdd.Codigo = arreglo[0];
            modeloToAdd.Descripcion = arreglo[1];
            String estatus = arreglo[2];
            Int32 iEstatus = Int32.Parse(estatus);
            modeloToAdd.Estatus = iEstatus;

            AlquileresMVC.Models.Tipo tipoToAdd = db.TipoSet.ToList().LastOrDefault();
            Int32 iIDTipo = tipoToAdd.ID;
            modeloToAdd.IDTipo = iIDTipo;

            TryUpdateModel(modeloToAdd, "Modelo");
            TryUpdateModel(modeloToAdd, "Modelo", collection.ToValueProvider());


            //valido claves primaria
            if (db.ProductoSet.FirstOrDefault(b => b.ID == modeloToAdd.ID) != null)
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
                        db.AddToModeloSet(modeloToAdd);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                        /// cofirmación de que la operacion resulto exitosa
                        Modelo _entidadToIDAdd = db.ModeloSet.ToList().LastOrDefault();
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

            return View(modeloToAdd);
        }

        public ActionResult Edit(Int32 id)
        {
            AlquileresMVC.Models.Modelo modeloToUpdate = db.ModeloSet.First(cb => cb.ID == id);
            ViewData.Model = modeloToUpdate;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Int32 id, FormCollection form)
        {
            AlquileresMVC.Models.Modelo modeloToUpdate = db.ModeloSet.First(cb => cb.ID == id);

            string[] arreglo = new string[form.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in form.AllKeys)
            {
                var value = form[key];
                arreglo[i] = value;
                i++;
            }

            modeloToUpdate.Codigo = arreglo[0];
            modeloToUpdate.Descripcion = arreglo[1];
            String estatus = arreglo[2];
            Int32 iEstatus = Int32.Parse(estatus);
            modeloToUpdate.Estatus = iEstatus;

            AlquileresMVC.Models.Tipo tipoToUpdate = db.TipoSet.First(b => b.ID == modeloToUpdate.IDTipo);
            Int32 iIDTipo = tipoToUpdate.ID;
            modeloToUpdate.IDTipo = iIDTipo;

            TryUpdateModel(modeloToUpdate, "Modelo");
            TryUpdateModel(modeloToUpdate, "Modelo", form.ToValueProvider());

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
                    return RedirectToAction("Details/" + modeloToUpdate.ID);
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

            return View(modeloToUpdate);
        }

        public ActionResult Delete(int id)
        {
            AlquileresMVC.Models.Modelo modeloToDelete = db.ModeloSet.First(cb => cb.ID == id);
            ViewData.Model = modeloToDelete;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Int32 id, FormCollection form)
        {
            AlquileresMVC.Models.Modelo modeloToDelete = db.ModeloSet.First(cb => cb.ID == id);

            //valido cliente tiene alquiler
            if (db.ProductoSet.FirstOrDefault(b => b.IDModelo == id) != null)
            {
                ModelState.AddModelError("ID", String.Format("Esta intentando Borrar un Modelo que tiene un Producto"));
            }
            else
            {
                try
                {
                    // Delete 
                    db.DeleteObject(modeloToDelete);
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

            return View(modeloToDelete);
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
            var modeloDetail = db.ModeloSet.First(cb => cb.ID == id);

            return Json(modeloDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetJsonDetailsEdit(int id)
        {
            var modeloDetail = db.ModeloSet.First(cb => cb.ID == id);

            return Json(modeloDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetListData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            var modelo = db.ModeloSet.ToList().AsQueryable();

            // Filter the list
            var filteredModelo = modelo;

            filteredModelo = Utility.Filter<Modelo>(modelo, _search, searchField, searchOper, searchString);

            // Sort the list
            var sortedModelo = Utility.Sort<Modelo>(filteredModelo, sidx, sord);

            sortedModelo = sortedModelo.Skip((page - 1) * rows).Take(rows);

            var totalRecords = filteredModelo.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Prepare the data to fit the requirement of jQGrid
            var data = (from s in sortedModelo
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