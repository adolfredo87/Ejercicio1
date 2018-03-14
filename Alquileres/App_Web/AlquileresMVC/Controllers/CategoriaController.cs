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
    public class CategoriaController : Controller
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
            AlquileresMVC.Models.Categoria categoriaDetail = db.CategoriaSet.First(cb => cb.ID == id);
            return View(categoriaDetail);
        }

        public ActionResult Create()
        {
            AlquileresMVC.Models.Categoria categoria = new AlquileresMVC.Models.Categoria();
            Categoria CategoriaToIDAdd = db.CategoriaSet.ToList().LastOrDefault();
            Int32 _id = CategoriaToIDAdd.ID + 1;
            categoria.ID = _id;
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            AlquileresMVC.Models.Categoria categoriaToAdd = new AlquileresMVC.Models.Categoria();

            string[] arreglo = new string[collection.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in collection.AllKeys)
            {
                var value = collection[key];
                arreglo[i] = value;
                i++;
            }

            categoriaToAdd.Codigo = arreglo[0];
            categoriaToAdd.Descripcion = arreglo[1];
            String estatus = arreglo[2];
            Int32 iEstatus = Int32.Parse(estatus);
            categoriaToAdd.Estatus = iEstatus;

            TryUpdateModel(categoriaToAdd, "Categoria");
            TryUpdateModel(categoriaToAdd, "Categoria", collection.ToValueProvider());


            //valido claves primaria
            if (db.ProductoSet.FirstOrDefault(b => b.ID == categoriaToAdd.ID) != null)
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
                        db.AddToCategoriaSet(categoriaToAdd);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                        /// cofirmación de que la operacion resulto exitosa
                        Categoria _entidadToIDAdd = db.CategoriaSet.ToList().LastOrDefault();
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

            return View(categoriaToAdd);
        }

        public ActionResult Edit(Int32 id)
        {
            AlquileresMVC.Models.Categoria categoriaToUpdate = db.CategoriaSet.First(cb => cb.ID == id);
            ViewData.Model = categoriaToUpdate;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Int32 id, FormCollection form)
        {
            AlquileresMVC.Models.Categoria categoriaToUpdate = db.CategoriaSet.First(cb => cb.ID == id);

            string[] arreglo = new string[form.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in form.AllKeys)
            {
                var value = form[key];
                arreglo[i] = value;
                i++;
            }

            categoriaToUpdate.Codigo = arreglo[0];
            categoriaToUpdate.Descripcion = arreglo[1];
            String estatus = arreglo[2];
            Int32 iEstatus = Int32.Parse(estatus);
            categoriaToUpdate.Estatus = iEstatus;

            TryUpdateModel(categoriaToUpdate, "Categoria");
            TryUpdateModel(categoriaToUpdate, "Categoria", form.ToValueProvider());

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
                    return RedirectToAction("Details/" + categoriaToUpdate.ID);
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

            return View(categoriaToUpdate);
        }

        public ActionResult Delete(int id)
        {
            AlquileresMVC.Models.Categoria categoriaToDelete = db.CategoriaSet.First(cb => cb.ID == id);
            ViewData.Model = categoriaToDelete;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Int32 id, FormCollection form)
        {
            AlquileresMVC.Models.Categoria categoriaToDelete = db.CategoriaSet.First(cb => cb.ID == id);

            //valido cliente tiene alquiler
            if (db.ProductoSet.FirstOrDefault(b => b.IDCategoria == id) != null)
            {
                ModelState.AddModelError("ID", String.Format("Esta intentando Borrar una categoria que tiene un Producto"));
            }
            else
            {
                try
                {
                    // Delete 
                    db.DeleteObject(categoriaToDelete);
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

            return View(categoriaToDelete);
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
            var CategoriaDetail = db.CategoriaSet.First(cb => cb.ID == id);

            return Json(CategoriaDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetJsonDetailsEdit(int id)
        {
            var CategoriaDetail = db.CategoriaSet.First(cb => cb.ID == id);

            return Json(CategoriaDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetListData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            var Categoria = db.CategoriaSet.ToList().AsQueryable();

            // Filter the list
            var filteredCategoria = Categoria;

            filteredCategoria = Utility.Filter<Categoria>(Categoria, _search, searchField, searchOper, searchString);

            // Sort the list
            var sortedCategoria = Utility.Sort<Categoria>(filteredCategoria, sidx, sord);

            sortedCategoria = sortedCategoria.Skip((page - 1) * rows).Take(rows);

            var totalRecords = filteredCategoria.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Prepare the data to fit the requirement of jQGrid
            var data = (from s in sortedCategoria
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
