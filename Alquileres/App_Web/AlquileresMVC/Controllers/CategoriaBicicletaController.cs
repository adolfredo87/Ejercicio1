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
    public class CategoriaBicicletaController : Controller
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
            CategoriaBicicleta categoriaBicicletaDetail = db.CategoriaBicicletaSet.First(cb => cb.ID == id);
            return View(categoriaBicicletaDetail);
        }

        public ActionResult Create()
        {
            CategoriaBicicleta categoriabicicleta = new CategoriaBicicleta();
            CategoriaBicicleta categoriabicicletaToIDAdd = db.CategoriaBicicletaSet.ToList().LastOrDefault();
            Int32 _id = categoriabicicletaToIDAdd.ID + 1;
            categoriabicicleta.ID = _id;
            return View(categoriabicicleta);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            CategoriaBicicleta categoriaBicicletaToAdd = new CategoriaBicicleta();

            string[] arreglo = new string[collection.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in collection.AllKeys)
            {
                var value = collection[key];
                arreglo[i] = value;
                i++;
            }

            categoriaBicicletaToAdd.Codigo = arreglo[0];
            categoriaBicicletaToAdd.Categoria = arreglo[1];

            TryUpdateModel(categoriaBicicletaToAdd, "CategoriaBicicleta");
            TryUpdateModel(categoriaBicicletaToAdd, "CategoriaBicicleta", collection.ToValueProvider());


            //valido claves primaria
            if (db.BicicletaSet.FirstOrDefault(b => b.ID == categoriaBicicletaToAdd.ID) != null)
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
                        db.AddToCategoriaBicicletaSet(categoriaBicicletaToAdd);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                        /// cofirmación de que la operacion resulto exitosa
                        CategoriaBicicleta _entidadToIDAdd = db.CategoriaBicicletaSet.ToList().LastOrDefault();
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

            return View(categoriaBicicletaToAdd);
        }

        public ActionResult Edit(Int32 id)
        {
            var categoriaBicicletaToUpdate = db.CategoriaBicicletaSet.First(cb => cb.ID == id);
            ViewData.Model = categoriaBicicletaToUpdate;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Int32 id, FormCollection form)
        {
            CategoriaBicicleta categoriaBicicletaToUpdate = db.CategoriaBicicletaSet.First(cb => cb.ID == id);

            string[] arreglo = new string[form.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in form.AllKeys)
            {
                var value = form[key];
                arreglo[i] = value;
                i++;
            }

            categoriaBicicletaToUpdate.Codigo = arreglo[0];
            categoriaBicicletaToUpdate.Categoria = arreglo[1];

            TryUpdateModel(categoriaBicicletaToUpdate, "CategoriaBicicleta");
            TryUpdateModel(categoriaBicicletaToUpdate, "CategoriaBicicleta", form.ToValueProvider());

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
                    return RedirectToAction("Details/" + categoriaBicicletaToUpdate.ID);
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

            return View(categoriaBicicletaToUpdate);
        }

        public ActionResult Delete(int id)
        {
            var categoriaBicicletaToDelete = db.CategoriaBicicletaSet.First(cb => cb.ID == id);
            ViewData.Model = categoriaBicicletaToDelete;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Int32 id, FormCollection form)
        {
            var categoriaBicicletaToDelete = db.CategoriaBicicletaSet.First(cb => cb.ID == id);

            //valido cliente tiene alquiler
            if (db.BicicletaSet.FirstOrDefault(b => b.IDCategoriaBici == id) != null)
            {
                ModelState.AddModelError("ID", String.Format("Esta intentando Borrar una categoria que tiene una bicicleta"));
            }
            else
            {
                try
                {
                    // Delete 
                    db.DeleteObject(categoriaBicicletaToDelete);
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

            return View(categoriaBicicletaToDelete);
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
            var categoriaBicicletaDetail = db.CategoriaBicicletaSet.First(cb => cb.ID == id);

            return Json(categoriaBicicletaDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetJsonDetailsEdit(int id)
        {
            var categoriaBicicletaDetail = db.CategoriaBicicletaSet.First(cb => cb.ID == id);

            return Json(categoriaBicicletaDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetListData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            var categoriaBicicleta = db.CategoriaBicicletaSet.ToList().AsQueryable();

            // Filter the list
            var filteredcategoriaBicicleta = categoriaBicicleta;

            filteredcategoriaBicicleta = Utility.Filter<CategoriaBicicleta>(categoriaBicicleta, _search, searchField, searchOper, searchString);

            // Sort the list
            var sortedcategoriaBicicleta = Utility.Sort<CategoriaBicicleta>(filteredcategoriaBicicleta, sidx, sord);

            sortedcategoriaBicicleta = sortedcategoriaBicicleta.Skip((page - 1) * rows).Take(rows);

            var totalRecords = filteredcategoriaBicicleta.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Prepare the data to fit the requirement of jQGrid
            var data = (from s in sortedcategoriaBicicleta
                        select new
                        {
                            id = s.ID,
                            cell = new object[] { 
                                s.ID, 
                                s.Codigo, 
                                s.Categoria, 
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
