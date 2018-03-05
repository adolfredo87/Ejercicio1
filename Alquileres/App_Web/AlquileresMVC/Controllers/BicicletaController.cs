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
    public class BicicletaController : Controller
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
            Bicicleta bicicletaDetail = db.BicicletaSet.First(b => b.ID == id);
            bicicletaDetail.CategoriaBicicletaLoad();
            return View(bicicletaDetail);
        }

        public ActionResult Create()
        {
            Bicicleta bicicleta = new Bicicleta();
            Bicicleta bicicletaToIDAdd = db.BicicletaSet.ToList().LastOrDefault();
            Int32 _id = bicicletaToIDAdd.ID + 1;
            bicicleta.ID = _id;
            bicicleta.CategoriaBici = new CategoriaBicicleta();
            bicicleta.CategoriaBici.ToEntitySelectList();
            return View(bicicleta);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Bicicleta bicicletaToAdd = new Bicicleta();

            string[] arreglo = new string[collection.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in collection.AllKeys)
            {
                var value = collection[key];
                arreglo[i] = value;
                i++;
            }

            bicicletaToAdd.Marca = arreglo[0];
            bicicletaToAdd.Modelo = arreglo[1];
            String IDCategoriaBici = arreglo[2];
            Int32 iIDCategoriaBici = Int32.Parse(IDCategoriaBici);
            bicicletaToAdd.IDCategoriaBici = iIDCategoriaBici;

            TryUpdateModel(bicicletaToAdd, "Bicicleta");
            TryUpdateModel(bicicletaToAdd, "Bicicleta", collection.ToValueProvider());

            if (!String.IsNullOrEmpty(IDCategoriaBici))
            {
                bicicletaToAdd.CategoriaBici = db.CategoriaBicicletaSet.FirstOrDefault(c => c.ID == iIDCategoriaBici);
            }

            if (bicicletaToAdd.CategoriaBici == null)
            {
                ModelState.AddModelError("", String.Format("El número de ID {0} no está registrado en la base de datos.", IDCategoriaBici));
            }

            //valido claves primaria
            if (db.BicicletaSet.FirstOrDefault(b => b.ID == bicicletaToAdd.ID) != null)
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
                        // Guardar y confirmo.
                        db.AddToBicicletaSet(bicicletaToAdd);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                        /// cofirmación de que la operacion resulto exitosa
                        Bicicleta _entidadToIDAdd = db.BicicletaSet.ToList().LastOrDefault();
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

            // Refresca el formulario con los datos guardados
            return View(bicicletaToAdd);
        }

        public ActionResult Edit(Int32 id)
        {
            Bicicleta bicicletaToUpdate = db.BicicletaSet.First(b => b.ID == id);
            bicicletaToUpdate.CategoriaBicicletaLoad();
            return View(bicicletaToUpdate);
        }

        [HttpPost]
        public ActionResult Edit(Int32 id, FormCollection form)
        {
            Bicicleta bicicletaToUpdate = db.BicicletaSet.First(b => b.ID == id);

            string[] arreglo = new string[form.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in form.AllKeys)
            {
                var value = form[key];
                arreglo[i] = value;
                i++;
            }

            bicicletaToUpdate.Marca = arreglo[0];
            bicicletaToUpdate.Modelo = arreglo[1];
            String IDCategoriaBici = arreglo[2];
            Int32 iIDCategoriaBici = Int32.Parse(IDCategoriaBici);
            bicicletaToUpdate.IDCategoriaBici = Int32.Parse(IDCategoriaBici);
            
            if (!String.IsNullOrEmpty(IDCategoriaBici))
            {
                bicicletaToUpdate.CategoriaBici = db.CategoriaBicicletaSet.FirstOrDefault(c => c.ID == iIDCategoriaBici);
            }

            if (bicicletaToUpdate.CategoriaBici == null)
            {
                ModelState.AddModelError("ID", String.Format("El número de IDCategoriaBici {0} no está registrado en la base de datos.", IDCategoriaBici));
            }

            TryUpdateModel(bicicletaToUpdate, "Bicicleta");
            TryUpdateModel(bicicletaToUpdate, "Bicicleta", form.ToValueProvider());

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
                    return RedirectToAction("Details/" + bicicletaToUpdate.ID);
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

            return View(bicicletaToUpdate);
        }

        public ActionResult Delete(int id)
        {
            Bicicleta bicicletaToDelete = db.BicicletaSet.First(b => b.ID == id);
            ViewData.Model = bicicletaToDelete;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Int32 id, FormCollection form)
        {
            Bicicleta bicicletaToDelete = db.BicicletaSet.First(b => b.ID == id);

            //valido si la bicicleta tiene alquiler
            if (db.AlquilerSet.FirstOrDefault(a => a.IDBicileta == id) != null)
            {
                ModelState.AddModelError("ID", String.Format("Esta intentando Borrar una bicicleta que tiene alquiler"));
            }
            else
            {
                // Si el modelo es valido, guardo en la BD
                if (ModelState.IsValid)
                {
                    try
                    {
                        // Delete 
                        db.DeleteObject(bicicletaToDelete);
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
            }

            return View(bicicletaToDelete);
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
            var bicicletaDetail = db.BicicletaSet.First(a => a.ID == id);

            return Json(bicicletaDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetJsonDetailsEdit(int id)
        {
            var bicicletaDetail = db.BicicletaSet.First(a => a.ID == id);

            return Json(bicicletaDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetListData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            var bicicleta = db.BicicletaSet.ToList().AsQueryable();
            db.CategoriaBicicletaSet.ToList();

            // Filter the list
            var filteredbicicleta = bicicleta;

            filteredbicicleta = Utility.Filter<Bicicleta>(bicicleta, _search, searchField, searchOper, searchString);

            // Sort the list
            var sortedbicicleta = Utility.Sort<Bicicleta>(filteredbicicleta, sidx, sord);

            var totalRecords = filteredbicicleta.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Take only rows the page
            // PERMITE OBTENER SOLO LOS QUE SE MOSTRARN EN PANTALLA SEGUN EL NUMERO DE LA PAGINA ESTABLECIDO
            // SE COLOCA AQUÍ PERA MEJORAR EL PERFORMANCE DE LOS DATOS LEIDOS EN LOS LOAD'S
            sortedbicicleta = sortedbicicleta.Skip((page - 1) * rows).Take(rows);

            // Prepare the data to fit the requirement of jQGrid
            var data = (from s in sortedbicicleta
                        select new
                        {
                            id = s.ID,
                            cell = new object[] { 
                                s.ID, 
                                s.Marca, 
                                s.Modelo,
                                s.CategoriaBici == null ? "" : s.CategoriaBici.Categoria,
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
