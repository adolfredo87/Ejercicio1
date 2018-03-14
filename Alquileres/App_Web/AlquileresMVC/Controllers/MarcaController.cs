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
    public class MarcaController : Controller
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
            AlquileresMVC.Models.Marca marcaDetail = db.MarcaSet.First(cb => cb.ID == id);
            return View(marcaDetail);
        }

        public ActionResult Create()
        {
            AlquileresMVC.Models.Marca marca = new AlquileresMVC.Models.Marca();
            AlquileresMVC.Models.Marca marcaToIDAdd = db.MarcaSet.ToList().LastOrDefault();
            Int32 _id = marcaToIDAdd.ID + 1;
            marca.ID = _id;
            return View(marca);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            AlquileresMVC.Models.Marca marcaToAdd = new AlquileresMVC.Models.Marca();

            string[] arreglo = new string[collection.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in collection.AllKeys)
            {
                var value = collection[key];
                arreglo[i] = value;
                i++;
            }

            marcaToAdd.Codigo = arreglo[0];
            marcaToAdd.Descripcion = arreglo[1];
            String estatus = arreglo[2];
            Int32 iEstatus = Int32.Parse(estatus);
            marcaToAdd.Estatus = iEstatus;

            AlquileresMVC.Models.Tipo tipoToAdd = db.TipoSet.ToList().LastOrDefault();
            Int32 iIDTipo = tipoToAdd.ID;
            marcaToAdd.IDTipo = iIDTipo;

            TryUpdateModel(marcaToAdd, "Marca");
            TryUpdateModel(marcaToAdd, "Marca", collection.ToValueProvider());


            //valido claves primaria
            if (db.ProductoSet.FirstOrDefault(b => b.ID == marcaToAdd.ID) != null)
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
                        db.AddToMarcaSet(marcaToAdd);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                        /// cofirmación de que la operacion resulto exitosa
                        AlquileresMVC.Models.Marca _entidadToIDAdd = db.MarcaSet.ToList().LastOrDefault();
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

            return View(marcaToAdd);
        }

        public ActionResult Edit(Int32 id)
        {
            AlquileresMVC.Models.Marca marcaToUpdate = db.MarcaSet.First(cb => cb.ID == id);
            ViewData.Model = marcaToUpdate;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Int32 id, FormCollection form)
        {
            AlquileresMVC.Models.Marca marcaToUpdate = db.MarcaSet.First(cb => cb.ID == id);

            string[] arreglo = new string[form.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in form.AllKeys)
            {
                var value = form[key];
                arreglo[i] = value;
                i++;
            }

            marcaToUpdate.Codigo = arreglo[0];
            marcaToUpdate.Descripcion = arreglo[1];
            String estatus = arreglo[2];
            Int32 iEstatus = Int32.Parse(estatus);
            marcaToUpdate.Estatus = iEstatus;

            AlquileresMVC.Models.Tipo tipoToUpdate = db.TipoSet.First(b => b.ID == marcaToUpdate.IDTipo);
            Int32 iIDTipo = tipoToUpdate.ID;
            marcaToUpdate.IDTipo = iIDTipo;

            TryUpdateModel(marcaToUpdate, "Marca");
            TryUpdateModel(marcaToUpdate, "Marca", form.ToValueProvider());

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
                    return RedirectToAction("Details/" + marcaToUpdate.ID);
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

            return View(marcaToUpdate);
        }

        public ActionResult Delete(int id)
        {
            AlquileresMVC.Models.Marca marcaToDelete = db.MarcaSet.First(cb => cb.ID == id);
            ViewData.Model = marcaToDelete;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Int32 id, FormCollection form)
        {
            AlquileresMVC.Models.Marca marcaToDelete = db.MarcaSet.First(cb => cb.ID == id);

            //valido cliente tiene alquiler
            if (db.ProductoSet.FirstOrDefault(b => b.IDMarca == id) != null)
            {
                ModelState.AddModelError("ID", String.Format("Esta intentando Borrar una Marca que tiene un Producto"));
            }
            else
            {
                try
                {
                    // Delete 
                    db.DeleteObject(marcaToDelete);
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

            return View(marcaToDelete);
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
            var marcaDetail = db.MarcaSet.First(cb => cb.ID == id);

            return Json(marcaDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetJsonDetailsEdit(int id)
        {
            var marcaDetail = db.MarcaSet.First(cb => cb.ID == id);

            return Json(marcaDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetListData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            var marca = db.MarcaSet.ToList().AsQueryable();

            // Filter the list
            var filteredMarca = marca;

            filteredMarca = Utility.Filter<Marca>(marca, _search, searchField, searchOper, searchString);

            // Sort the list
            var sortedMarca = Utility.Sort<Marca>(filteredMarca, sidx, sord);

            sortedMarca = sortedMarca.Skip((page - 1) * rows).Take(rows);

            var totalRecords = filteredMarca.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Prepare the data to fit the requirement of jQGrid
            var data = (from s in sortedMarca
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
