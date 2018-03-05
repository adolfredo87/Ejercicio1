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
    public class ClienteController : Controller
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
            var clienteDetail = db.ClienteSet.First(c => c.ID == id);
            return View(clienteDetail);
        }

        public ActionResult Create()
        {
            Cliente cliente = new Cliente();
            Cliente clienteToIDAdd = db.ClienteSet.ToList().LastOrDefault();
            Int32 _id = clienteToIDAdd.ID + 1;
            cliente.ID = _id;
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Cliente clienteToAdd = new Cliente();

            string[] arreglo = new string[collection.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in collection.AllKeys)
            {
                var value = collection[key];
                arreglo[i] = value;
                i++;
            }

            clienteToAdd.Nombre = arreglo[0];
            clienteToAdd.Telefono = arreglo[1];
            clienteToAdd.Correo = arreglo[2];

            TryUpdateModel(clienteToAdd, "Cliente");
            TryUpdateModel(clienteToAdd, "Cliente", collection.ToValueProvider());

            //valido claves primaria
            if (db.ClienteSet.FirstOrDefault(c => c.ID == clienteToAdd.ID) != null)
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
                        db.AddToClienteSet(clienteToAdd);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                        /// cofirmación de que la operacion resulto exitosa
                        Cliente _entidadToIDAdd = db.ClienteSet.ToList().LastOrDefault();
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
            
            return View(clienteToAdd);
        }

        public ActionResult Edit(Int32 id)
        {
            var clienteToUpdate = db.ClienteSet.First(c => c.ID == id);
            ViewData.Model = clienteToUpdate;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Int32 id, FormCollection form)
        {
            Cliente clienteToUpdate = db.ClienteSet.First(c => c.ID == id);
            
            string[] arreglo = new string[form.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in form.AllKeys)
            {
                var value = form[key];
                arreglo[i] = value;
                i++;
            }

            clienteToUpdate.Nombre = arreglo[0];
            clienteToUpdate.Telefono = arreglo[1];
            clienteToUpdate.Correo = arreglo[2];

            TryUpdateModel(clienteToUpdate, "Cliente");
            TryUpdateModel(clienteToUpdate, "Cliente", form.ToValueProvider());

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
                    return RedirectToAction("Details/" + clienteToUpdate.ID);
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

            return View(clienteToUpdate);
        }

        public ActionResult Delete(int id)
        {
            var clienteToDelete = db.ClienteSet.First(c => c.ID == id);
            ViewData.Model = clienteToDelete;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Int32 id, FormCollection form)
        {
            var clienteToDelete = db.ClienteSet.First(c => c.ID == id);

            //valido cliente tiene alquiler
            if (db.AlquilerSet.FirstOrDefault(a => a.IDCliente == id) != null)
            {
                ModelState.AddModelError("ID", String.Format("Esta intentando Borrar un cliente que tiene alquiler"));
            }
            else
            {
                try
                {
                    // Delete 
                    db.DeleteObject(clienteToDelete);
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

            return View(clienteToDelete);
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
            var clienteDetail = db.ClienteSet.First(c => c.ID == id);

            return Json(clienteDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetJsonDetailsEdit(int id)
        {
            var clienteDetail = db.ClienteSet.First(c => c.ID == id);

            return Json(clienteDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetListData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            var cliente = db.ClienteSet.ToList().AsQueryable();

            // Filter the list
            var filteredcliente = cliente;

            filteredcliente = Utility.Filter<Cliente>(cliente, _search, searchField, searchOper, searchString);

            // Sort the list
            var sortedcliente = Utility.Sort<Cliente>(filteredcliente, sidx, sord);

            sortedcliente = sortedcliente.Skip((page - 1) * rows).Take(rows);

            var totalRecords = filteredcliente.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Prepare the data to fit the requirement of jQGrid
            var data = (from s in sortedcliente
                        select new
                        {
                            id = s.ID,
                            cell = new object[] { 
                                s.ID, 
                                s.Nombre, 
                                s.Telefono, 
                                s.Correo, 
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
