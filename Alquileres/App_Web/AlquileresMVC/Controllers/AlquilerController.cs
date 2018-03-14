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
    public class AlquilerController : Controller
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
            AlquileresMVC.Models.Alquiler alquilerDetail = db.AlquilerSet.First(a => a.ID == id);

            alquilerDetail.ClienteLoad();
            alquilerDetail.ProductoLoad();
            alquilerDetail.Producto.TipoLoad();
            alquilerDetail.Producto.MarcaLoad();
            alquilerDetail.Producto.ModeloLoad();
            alquilerDetail.Producto.CategoriaLoad();
            
            return View(alquilerDetail);
        }

        public ActionResult Create()
        {
            AlquileresMVC.Models.Alquiler alquiler = new AlquileresMVC.Models.Alquiler();

            alquiler.Cliente = new Cliente();
            alquiler.Cliente.ToEntitySelectList();
            alquiler.Producto = new Producto();
            alquiler.Producto.ToEntitySelectList();
            alquiler.Producto.Tipo = new Tipo();
            alquiler.Producto.Tipo.ToEntitySelectList();
            alquiler.Producto.Marca = new Marca();
            alquiler.Producto.Marca.ToEntitySelectList();
            alquiler.Producto.Modelo = new Modelo();
            alquiler.Producto.Modelo.ToEntitySelectList();
            alquiler.Producto.Categoria = new Categoria();
            alquiler.Producto.Categoria.ToEntitySelectList();
            alquiler.Producto.ToEntitySelectList();

            Alquiler alquilerToIDAdd = db.AlquilerSet.ToList().LastOrDefault();
            Int32 _id = alquilerToIDAdd.ID + 1;
            alquiler.ID = _id;

            alquiler.FechaDesde = DateTime.Now;
            alquiler.FechaHasta = DateTime.Now;
            alquiler.Estatus = 0;

            return View(alquiler);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            AlquileresMVC.Models.Alquiler alquilerToAdd = new AlquileresMVC.Models.Alquiler();

            string[] arreglo = new string[collection.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in collection.AllKeys)
            {
                var value = collection[key];
                arreglo[i] = value;
                i++;
            }

            String _sIDCliente = arreglo[0];
            Int32 iIDCliente = Int32.Parse(_sIDCliente);
            String _sIDProducto = arreglo[1];
            Int32 iIDProducto = Int32.Parse(_sIDProducto);
            String _sFechaDesde = arreglo[2];
            DateTime dFechaDesde = DateTime.Parse(_sFechaDesde);
            String _sFechaHasta = arreglo[3];
            DateTime dFechaHasta = DateTime.Parse(_sFechaHasta);
            Int32 iEstatus = 0;
            alquilerToAdd.IDCliente = iIDCliente;
            alquilerToAdd.IDProducto = iIDProducto;
            alquilerToAdd.FechaDesde = dFechaDesde;
            alquilerToAdd.FechaHasta = dFechaHasta;
            alquilerToAdd.Estatus = iEstatus;

            TryUpdateModel(alquilerToAdd, "Alquiler");
            TryUpdateModel(alquilerToAdd, "Alquiler", collection.ToValueProvider());

            if (!String.IsNullOrEmpty(_sIDCliente))
            {
                alquilerToAdd.Cliente = db.ClienteSet.FirstOrDefault(c => c.ID == iIDCliente);
            }

            if (!String.IsNullOrEmpty(_sIDProducto))
            {
                alquilerToAdd.Producto = db.ProductoSet.FirstOrDefault(c => c.ID == iIDProducto);
            }

            if (alquilerToAdd.Cliente == null)
            {
                ModelState.AddModelError("IDCliente", String.Format("El número de ID {0} no está registrado en la base de datos.", _sIDCliente));
            }

            if (alquilerToAdd.Producto == null)
            {
                ModelState.AddModelError("IDProducto", String.Format("El número de ID {0} no está registrado en la base de datos.", _sIDProducto));
            }

            //valido claves primaria
            if (db.AlquilerSet.FirstOrDefault(a => a.ID == alquilerToAdd.ID) != null)
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
                        db.AddToAlquilerSet(alquilerToAdd);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                        /// cofirmación de que la operacion resulto exitosa
                        Alquiler _entidadToIDAdd = db.AlquilerSet.ToList().LastOrDefault();
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
            return View(alquilerToAdd);
        }

        public ActionResult Edit(Int32 id)
        {
            AlquileresMVC.Models.Alquiler alquilerToUpdate = db.AlquilerSet.First(a => a.ID == id);

            alquilerToUpdate.ClienteLoad();
            alquilerToUpdate.ProductoLoad();
            alquilerToUpdate.Producto.TipoLoad();
            alquilerToUpdate.Producto.MarcaLoad();
            alquilerToUpdate.Producto.ModeloLoad();
            alquilerToUpdate.Producto.CategoriaLoad();
            alquilerToUpdate.Estatus = 1;

            return View(alquilerToUpdate);
        }

        [HttpPost]
        public ActionResult Edit(Int32 id, FormCollection form)
        {
            AlquileresMVC.Models.Alquiler alquilerToUpdate = db.AlquilerSet.First(a => a.ID == id);

            string[] arreglo = new string[form.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in form.AllKeys)
            {
                var value = form[key];
                arreglo[i] = value;
                i++;
            }

            String _sIDCliente = arreglo[0];
            Int32 iIDCliente = Int32.Parse(_sIDCliente);
            String _sIDProducto = arreglo[1];
            Int32 iIDProducto = Int32.Parse(_sIDProducto);
            String _sFechaDesde = arreglo[2];
            DateTime dFechaDesde = DateTime.Parse(_sFechaDesde);
            String _sFechaHasta = arreglo[3];
            DateTime dFechaHasta = DateTime.Parse(_sFechaHasta);
            Int32 iEstatus = 1;
            alquilerToUpdate.IDCliente = iIDCliente;
            alquilerToUpdate.IDProducto = iIDProducto;
            alquilerToUpdate.FechaDesde = dFechaDesde;
            alquilerToUpdate.FechaHasta = dFechaHasta;
            alquilerToUpdate.Estatus = iEstatus;

            TryUpdateModel(alquilerToUpdate, "Alquiler");
            TryUpdateModel(alquilerToUpdate, "Alquiler", form.ToValueProvider());

            if (!String.IsNullOrEmpty(_sIDCliente))
            {
                alquilerToUpdate.Cliente = db.ClienteSet.FirstOrDefault(c => c.ID == iIDCliente);
            }

            if (!String.IsNullOrEmpty(_sIDProducto))
            {
                alquilerToUpdate.Producto = db.ProductoSet.FirstOrDefault(c => c.ID == iIDProducto);
            }

            if (alquilerToUpdate.Cliente == null)
            {
                ModelState.AddModelError("IDCliente", String.Format("El número de ID {0} no está registrado en la base de datos.", _sIDCliente));
            }

            if (alquilerToUpdate.Producto == null)
            {
                ModelState.AddModelError("IDProducto", String.Format("El número de ID {0} no está registrado en la base de datos.", _sIDProducto));
            }

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
                    /// Si la transaccion es exitosa nos redirigimos a la pagina de List como 
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
            return View(alquilerToUpdate);
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
            var alquilerDetail = db.AlquilerSet.First(a => a.ID == id);

            return Json(alquilerDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetJsonDetailsEdit(int id)
        {
            var alquilerDetail = db.AlquilerSet.First(a => a.ID == id);

            return Json(alquilerDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetListData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            var alquiler = (from a in db.AlquilerSet.ToList() where a.Estatus >= 0 && a.Estatus <= 1 select a).AsQueryable();

            // Filter the list
            var filteredalquiler = alquiler;

            filteredalquiler = Utility.Filter<Alquiler>(alquiler, _search, searchField, searchOper, searchString);

            var sortedalquiler = Utility.Sort<Alquiler>(filteredalquiler, sidx, sord);

            var totalRecords = filteredalquiler.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Tomas las filas que se muestran en la pagina
            // PERMITE OBTENER SOLO LOS QUE SE MOSTRARN EN PANTALLA SEGUN EL NUMERO DE LA PAGINA ESTABLECIDO
            // SE COLOCA AQUÍ PERA MEJORAR EL PERFORMANCE DE LOS DATOS LEIDOS EN LOS LOAD'S
            sortedalquiler = sortedalquiler.Skip((page - 1) * rows).Take(rows);

            // prepara la data que se muestran en el jQGrid
            var data = (from s in sortedalquiler
                        select new
                        {
                            id = s.ID,
                            cell = new object[] { 
                                s.ID, 
                                s.ClienteLoad().Nombre, 
                                s.ProductoLoad().Descripcion,
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
                rows = data
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
