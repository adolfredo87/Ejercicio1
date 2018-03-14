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
    public class ProductoController : Controller
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
            Producto productoDetail = db.ProductoSet.First(b => b.ID == id);
            productoDetail.TipoLoad();
            productoDetail.MarcaLoad();
            productoDetail.ModeloLoad();
            productoDetail.CategoriaLoad();
            return View(productoDetail);
        }

        public ActionResult Create()
        {
            Producto producto = new Producto();
            Producto ProductoToIDAdd = db.ProductoSet.ToList().LastOrDefault();
            Int32 _id = ProductoToIDAdd.ID + 1;
            producto.ID = _id;
            producto.Tipo = new Tipo();
            producto.Tipo.ToEntitySelectList();
            producto.Marca = new Marca();
            producto.Marca.ToEntitySelectList();
            producto.Modelo = new Modelo();
            producto.Modelo.ToEntitySelectList();
            producto.Categoria = new Categoria();
            producto.Categoria.ToEntitySelectList();
            return View(producto);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            AlquileresMVC.Models.Producto productoToAdd = new AlquileresMVC.Models.Producto();

            string[] arreglo = new string[collection.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in collection.AllKeys)
            {
                var value = collection[key];
                arreglo[i] = value;
                i++;
            }

            productoToAdd.Codigo = arreglo[0];
            productoToAdd.Descripcion = arreglo[1];

            AlquileresMVC.Models.Tipo tipoToAdd = db.TipoSet.ToList().LastOrDefault();
            Int32 iIDTipo = tipoToAdd.ID;
            productoToAdd.IDTipo = iIDTipo;

            String IDMarca = arreglo[2];
            Int32 iIDMarca = Int32.Parse(IDMarca);
            productoToAdd.IDMarca = iIDMarca;

            if (!String.IsNullOrEmpty(IDMarca))
            {
                productoToAdd.Marca = db.MarcaSet.FirstOrDefault(c => c.ID == iIDMarca);
            }

            if (productoToAdd.Marca == null)
            {
                ModelState.AddModelError("ID", String.Format("El número de IDMarca {0} no está registrado en la base de datos.", IDMarca));
            }

            String IDModelo = arreglo[3];
            Int32 iIDModelo = Int32.Parse(IDModelo);
            productoToAdd.IDModelo = iIDModelo;

            if (!String.IsNullOrEmpty(IDModelo))
            {
                productoToAdd.Modelo = db.ModeloSet.FirstOrDefault(c => c.ID == iIDModelo);
            }

            if (productoToAdd.Modelo == null)
            {
                ModelState.AddModelError("ID", String.Format("El número de IDModelo {0} no está registrado en la base de datos.", IDModelo));
            }

            String IDCategoria = arreglo[4];
            Int32 iIDCategoria = Int32.Parse(IDCategoria);
            productoToAdd.IDCategoria = iIDCategoria;

            if (!String.IsNullOrEmpty(IDCategoria))
            {
                productoToAdd.Categoria = db.CategoriaSet.FirstOrDefault(c => c.ID == iIDCategoria);
            }

            if (productoToAdd.Categoria == null)
            {
                ModelState.AddModelError("", String.Format("El número de IDCategoria {0} no está registrado en la base de datos.", IDCategoria));
            }

            TryUpdateModel(productoToAdd, "Producto");
            TryUpdateModel(productoToAdd, "Producto", collection.ToValueProvider());

            //valido claves primaria
            if (db.ProductoSet.FirstOrDefault(b => b.ID == productoToAdd.ID) != null)
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
                        db.AddToProductoSet(productoToAdd);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        /// Si la transaccion es exitosa nos redirigimos a la pagina de detalles como 
                        /// cofirmación de que la operacion resulto exitosa
                        Producto _entidadToIDAdd = db.ProductoSet.ToList().LastOrDefault();
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
            return View(productoToAdd);
        }

        public ActionResult Edit(Int32 id)
        {
            AlquileresMVC.Models.Producto productoToUpdate = db.ProductoSet.First(b => b.ID == id);
            productoToUpdate.CategoriaLoad();
            return View(productoToUpdate);
        }

        [HttpPost]
        public ActionResult Edit(Int32 id, FormCollection form)
        {
            AlquileresMVC.Models.Producto productoToUpdate = db.ProductoSet.First(b => b.ID == id);

            string[] arreglo = new string[form.AllKeys.ToList().Count];
            Int32 i = 0;

            foreach (var key in form.AllKeys)
            {
                var value = form[key];
                arreglo[i] = value;
                i++;
            }

            productoToUpdate.Codigo = arreglo[0];
            productoToUpdate.Descripcion = arreglo[1];

            AlquileresMVC.Models.Tipo tipoToUpdate = db.TipoSet.First(b => b.ID == productoToUpdate.IDTipo);
            Int32 iIDTipo = tipoToUpdate.ID;
            productoToUpdate.IDTipo = iIDTipo;

            String IDMarca = arreglo[2];
            Int32 iIDMarca = Int32.Parse(IDMarca);
            productoToUpdate.IDMarca = iIDMarca;

            if (!String.IsNullOrEmpty(IDMarca))
            {
                productoToUpdate.Marca = db.MarcaSet.FirstOrDefault(c => c.ID == iIDMarca);
            }

            if (productoToUpdate.Marca == null)
            {
                ModelState.AddModelError("ID", String.Format("El número de IDMarca {0} no está registrado en la base de datos.", IDMarca));
            }

            String IDModelo = arreglo[3];
            Int32 iIDModelo = Int32.Parse(IDModelo);
            productoToUpdate.IDModelo = iIDModelo;

            if (!String.IsNullOrEmpty(IDModelo))
            {
                productoToUpdate.Modelo = db.ModeloSet.FirstOrDefault(c => c.ID == iIDModelo);
            }

            if (productoToUpdate.Modelo == null)
            {
                ModelState.AddModelError("ID", String.Format("El número de IDModelo {0} no está registrado en la base de datos.", IDModelo));
            }

            String IDCategoria = arreglo[4];
            Int32 iIDCategoria = Int32.Parse(IDCategoria);
            productoToUpdate.IDCategoria = iIDCategoria;
            
            if (!String.IsNullOrEmpty(IDCategoria))
            {
                productoToUpdate.Categoria = db.CategoriaSet.FirstOrDefault(c => c.ID == iIDCategoria);
            }

            if (productoToUpdate.Categoria == null)
            {
                ModelState.AddModelError("ID", String.Format("El número de IDCategoria {0} no está registrado en la base de datos.", IDCategoria));
            }

            TryUpdateModel(productoToUpdate, "Producto");
            TryUpdateModel(productoToUpdate, "Producto", form.ToValueProvider());

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
                    return RedirectToAction("Details/" + productoToUpdate.ID);
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

            return View(productoToUpdate);
        }

        public ActionResult Delete(int id)
        {
            AlquileresMVC.Models.Producto productoToDelete = db.ProductoSet.First(b => b.ID == id);
            ViewData.Model = productoToDelete;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Int32 id, FormCollection form)
        {
            AlquileresMVC.Models.Producto productoToDelete = db.ProductoSet.First(b => b.ID == id);

            //valido si la Producto tiene alquiler
            if (db.AlquilerSet.FirstOrDefault(a => a.IDProducto == id) != null)
            {
                ModelState.AddModelError("ID", String.Format("Esta intentando Borrar un Producto que tiene alquiler"));
            }
            else
            {
                // Si el modelo es valido, guardo en la BD
                if (ModelState.IsValid)
                {
                    try
                    {
                        // Delete 
                        db.DeleteObject(productoToDelete);
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

            return View(productoToDelete);
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
            var ProductoDetail = db.ProductoSet.First(a => a.ID == id);

            return Json(ProductoDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetJsonDetailsEdit(int id)
        {
            var ProductoDetail = db.ProductoSet.First(a => a.ID == id);

            return Json(ProductoDetail, JsonRequestBehavior.AllowGet);
        }

        [JsonHandleError()]
        public JsonResult GetListData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString)
        {
            var producto = db.ProductoSet.ToList().AsQueryable();
            db.TipoSet.ToList();
            db.MarcaSet.ToList();
            db.ModeloSet.ToList();
            db.CategoriaSet.ToList();

            // Filter the list
            var filteredProducto = producto;

            filteredProducto = Utility.Filter<Producto>(producto, _search, searchField, searchOper, searchString);

            // Sort the list
            var sortedProducto = Utility.Sort<Producto>(filteredProducto, sidx, sord);

            var totalRecords = filteredProducto.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Take only rows the page
            // PERMITE OBTENER SOLO LOS QUE SE MOSTRARN EN PANTALLA SEGUN EL NUMERO DE LA PAGINA ESTABLECIDO
            // SE COLOCA AQUÍ PERA MEJORAR EL PERFORMANCE DE LOS DATOS LEIDOS EN LOS LOAD'S
            sortedProducto = sortedProducto.Skip((page - 1) * rows).Take(rows);

            // Prepare the data to fit the requirement of jQGrid
            var data = (from s in sortedProducto
                        select new
                        {
                            id = s.ID,
                            cell = new object[] { 
                                s.ID, 
                                s.Codigo, 
                                s.Descripcion, 
                                s.Marca == null ? "" : s.Marca.Descripcion,  
                                s.Modelo == null ? "" : s.Modelo.Descripcion, 
                                s.Categoria == null ? "" : s.Categoria.Descripcion,
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
