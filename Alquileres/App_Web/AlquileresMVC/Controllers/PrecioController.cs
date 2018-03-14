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
    public class PrecioController : Controller
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
            AlquileresMVC.Models.Precio precioDetail = db.PrecioSet.First(p => p.ID == id);
            return View(precioDetail);
        }

        public ActionResult Create()
        {
            AlquileresMVC.Models.Precio precio = new AlquileresMVC.Models.Precio();
            AlquileresMVC.Models.Precio precioToIDAdd = db.PrecioSet.ToList().LastOrDefault();
            Int32 _id = precioToIDAdd.ID + 1;
            precio.ID = _id;
            return View(precio);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            AlquileresMVC.Models.Precio precioToAdd = new AlquileresMVC.Models.Precio();

            string[] arreglo = new string[collection.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in collection.AllKeys)
            {
                var value = collection[key];
                arreglo[i] = value;
                i++;
            }

            precioToAdd.Codigo = arreglo[0];
            precioToAdd.Descripcion = arreglo[1];
            String precioUnitario = arreglo[2];
            Double precioUnit = Double.Parse(precioUnitario);
            precioToAdd.PrecioUnitario = precioUnit;
            String estatus = arreglo[3];
            Int32 iEstatus = Int32.Parse(estatus);
            precioToAdd.Estatus = iEstatus;

            TryUpdateModel(precioToAdd, "Precio");
            TryUpdateModel(precioToAdd, "Precio", collection.ToValueProvider());

            //valido claves primaria
            if (db.ClienteSet.FirstOrDefault(c => c.ID == precioToAdd.ID) != null)
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
                        // Guardar y confirmar el cliente.
                        db.AddToPrecioSet(precioToAdd);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                        /// cofirmación de que la operacion resulto exitosa
                        Precio _entidadToIDAdd = db.PrecioSet.ToList().LastOrDefault();
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

            return View(precioToAdd);
        }

        public ActionResult Edit(Int32 id)
        {
            AlquileresMVC.Models.Precio precioToUpdate = db.PrecioSet.First(p => p.ID == id);
            ViewData.Model = precioToUpdate;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Int32 id, FormCollection form)
        {
            AlquileresMVC.Models.Precio precioToUpdate = db.PrecioSet.First(p => p.ID == id);

            string[] arreglo = new string[form.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in form.AllKeys)
            {
                var value = form[key];
                arreglo[i] = value;
                i++;
            }

            precioToUpdate.Codigo = arreglo[0];
            precioToUpdate.Descripcion = arreglo[1];
            String precioUnitario = arreglo[2];
            Double precioUnit = Double.Parse(precioUnitario);
            precioToUpdate.PrecioUnitario = precioUnit;
            String estatus = arreglo[3];
            Int32 iEstatus = Int32.Parse(estatus);
            precioToUpdate.Estatus = iEstatus;

            TryUpdateModel(precioToUpdate, "Precio");
            TryUpdateModel(precioToUpdate, "Precio", form.ToValueProvider());

            // Si el modelo es valido, guardo en la BD
            if (ModelState.IsValid)
            {
                db.Connection.Open();
                DbTransaction dbTransaction = db.Connection.BeginTransaction();
                try
                {
                    // Guardar y confirmar el cliente.
                    db.SaveChanges();
                    dbTransaction.Commit();
                    /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                    /// cofirmación de que la operacion resulto exitosa
                    return RedirectToAction("Details/" + precioToUpdate.ID);
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

            return View(precioToUpdate);
        }

        public ActionResult Delete(int id)
        {
            AlquileresMVC.Models.Precio precioToDelete = db.PrecioSet.First(p => p.ID == id);
            ViewData.Model = precioToDelete;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Int32 id, FormCollection form)
        {
            AlquileresMVC.Models.Precio precioToDelete = db.PrecioSet.First(p => p.ID == id);

            String _Descripcion = precioToDelete.Descripcion;

            //valido si el descuento que se borra es de cabecera o de linea
            if (_Descripcion.Contains("Hora") || _Descripcion.Contains("Dia") || _Descripcion.Contains("Semana"))
            {
                ModelState.AddModelError("ID", String.Format("Ningun precio por hora, dia o semana puede ser eliminado."));
            }
            else
            {
                try
                {
                    // Delete 
                    db.DeleteObject(precioToDelete);
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

            return View(precioToDelete);
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
            var precioDetail = db.PrecioSet.First(p => p.ID == id);

            return Json(precioDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetJsonDetailsEdit(int id)
        {
            var precioDetail = db.PrecioSet.First(p => p.ID == id);

            return Json(precioDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetListData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            var precio = db.PrecioSet.ToList().AsQueryable();

            // Filter the list
            var filteredprecio = precio;

            filteredprecio = Utility.Filter<Precio>(precio, _search, searchField, searchOper, searchString);

            // Sort the list
            var sortedprecio = Utility.Sort<Precio>(filteredprecio, sidx, sord);

            sortedprecio = sortedprecio.Skip((page - 1) * rows).Take(rows);

            var totalRecords = filteredprecio.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Prepare the data to fit the requirement of jQGrid
            var data = (from s in sortedprecio
                        select new
                        {
                            id = s.ID,
                            cell = new object[] { 
                                s.ID, 
                                s.Codigo, 
                                s.Descripcion, 
                                s.PrecioUnitario, 
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
