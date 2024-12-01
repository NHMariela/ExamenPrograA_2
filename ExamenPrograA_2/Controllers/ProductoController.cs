using ExamenPrograA_2.Models;
using ExamenPrograA_2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ExamenPrograA_2.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            try
            {
                using (FincaAgricolaDBEntities db = new FincaAgricolaDBEntities())
                {
                    var productos = db.Productos.ToList();
                    if (productos.Any())
                    {
                        List<CListaProductos> listaProductos = productos.Select(x => new CListaProductos
                        {
                            ProductoID = x.ProductoID,
                            Nombre = x.Nombre,
                            Descripcion = x.Descripcion,
                            Precio = x.Precio,
                            Stock = x.Stock
                        }).ToList();
                        return View(listaProductos);
                    }
                    else
                    {
                        return View(new List<CListaProductos>());
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CProducto producto = new CProducto();
                using (FincaAgricolaDBEntities db = new FincaAgricolaDBEntities())
                {
                    var productoX = db.Productos.Find(id);
                    if (productoX != null)
                    {
                        // Mapea las propiedades del productoX a CProducto
                        producto.ProductoID = productoX.ProductoID;
                        producto.Nombre = productoX.Nombre;
                        producto.Descripcion = productoX.Descripcion;
                        producto.Precio = productoX.Precio;
                        producto.Stock = productoX.Stock;

                        // Pasar el objeto CProducto a la vista
                        return View(producto);
                    }
                }
                return Json(new { mensaje = "No se encontró un producto con el ID " + id }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(CreateProducto producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(producto);
                }
                using (FincaAgricolaDBEntities db = new FincaAgricolaDBEntities())
                {
                    Productos nuevoProducto = new Productos
                    {
                        Nombre = producto.Nombre,
                        Descripcion = producto.Descripcion,
                        Precio = producto.Precio,
                        Stock = producto.Stock
                    };
                    db.Productos.Add(nuevoProducto);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Producto creado satisfactoriamente";
                    return View(producto);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al crear el producto: " + ex.Message;
                return View(producto);
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                EditProducto producto = new EditProducto();
                using (FincaAgricolaDBEntities db = new FincaAgricolaDBEntities())
                {
                    var productoX = db.Productos.Find(id);
                    if (productoX != null)

                    {
                        producto.ProductoID = productoX.ProductoID;
                        producto.Nombre = productoX.Nombre;
                        producto.Descripcion = productoX.Descripcion;
                        producto.Precio = productoX.Precio;
                        producto.Stock = productoX.Stock;
                        return View(producto);
                    }
                }
                return View(producto);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Producto/Edit/5
        [HttpPost]

        public ActionResult Edit(EditProducto producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(producto);
                }

                using (FincaAgricolaDBEntities db = new FincaAgricolaDBEntities())
                {
                    var productoActual = db.Productos.Find(producto.ProductoID);
                    if (productoActual != null)
                    {
                        productoActual.Nombre = producto.Nombre;
                        productoActual.Descripcion = producto.Descripcion;
                        productoActual.Precio = producto.Precio;
                        productoActual.Stock = producto.Stock;

                        db.Entry(productoActual).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        ViewBag.ValorMensaje = 1;
                        ViewBag.MensajeProceso = "Producto actualizado satisfactoriamente";
                        return View(producto);
                    }

                    return Json(new { mensaje = "No se encontró un producto con el ID " + producto.ProductoID }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al actualizar el producto: " + ex.Message;
                return View(producto);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (FincaAgricolaDBEntities db = new FincaAgricolaDBEntities())
                {
                    var productoActual = db.Productos.Find(id);
                    if (productoActual != null)
                    {
                        db.Productos.Remove(productoActual);
                        db.SaveChanges();

                        // Usar TempData para pasar el mensaje de éxito al Index
                        TempData["ValorMensaje"] = 1;
                        TempData["MensajeProceso"] = "Producto eliminado satisfactoriamente" ;

                        // Redirigir a la acción Index para mostrar el mensaje
                        return RedirectToAction("Index");
                    }

                    // Si no se encuentra el producto
                    TempData["ValorMensaje"] = 0;
                    TempData["MensajeProceso"] = "No se encontró un producto con el ID " + id;

                    // Redirigir al Index en caso de error
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error
                TempData["ValorMensaje"] = 0;
                TempData["MensajeProceso"] = "Error al eliminar el producto: " + ex.Message;

                // Redirigir al Index en caso de error
                return RedirectToAction("Index");
            }
        }

    }
}