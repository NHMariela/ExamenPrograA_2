using ExamenPrograA_2.Models;
using ExamenPrograA_2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ExamenPrograA_2.Controllers
{
    public class MaquinariaController : Controller
    {
        // GET: Maquinaria
        public ActionResult IndexM()
        {
            try
            {
                using (FincaAgricolaDBEntities db = new FincaAgricolaDBEntities())
                {
                    var maquinaria = db.Maquinaria.ToList();
                    if (maquinaria.Any())
                    {
                        List<CListaMaquinaria> listaMaquinaria = maquinaria.Select(x => new CListaMaquinaria
                        {
                            MaquinariaID = x.MaquinariaID,
                            Nombre = x.Nombre,
                            Descripcion = x.Descripcion,
                            Marca = x.Marca,
                            Modelo = x.Modelo
                        }).ToList();
                        return View(listaMaquinaria);
                    }
                    else
                    {
                        return View(new List<CListaMaquinaria>());
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Maquinaria/Details/5
        public ActionResult DetailsM(int id)
        {
            try
            {
                CMaquinaria maquinaria = new CMaquinaria();
                using (FincaAgricolaDBEntities db = new FincaAgricolaDBEntities())
                {
                    var maquinariaX = db.Maquinaria.Find(id);
                    if (maquinariaX != null)
                    {
                        // Mapea las propiedades del maquinariaX a CMaquinaria
                        maquinaria.MaquinariaID = maquinariaX.MaquinariaID;
                        maquinaria.Nombre = maquinariaX.Nombre;
                        maquinaria.Descripcion = maquinariaX.Descripcion;
                        maquinaria.Marca = maquinariaX.Marca;
                        maquinaria.Modelo = maquinariaX.Modelo;

                        // Pasar el objeto CMaquinaria a la vista
                        return View(maquinaria);
                    }
                }
                return Json(new { mensaje = "No se encontró una maquina con el ID " + id }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Maquinaria/CreateM
        public ActionResult CreateM()
        {
            return View();
        }

        // POST: Maquinaria/CreateM
        [HttpPost]
        public ActionResult CreateM(CreateMaquinaria maquinaria)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(maquinaria);
                }
                using (FincaAgricolaDBEntities db = new FincaAgricolaDBEntities())
                {
                    Maquinaria nuevaMaquinaria = new Maquinaria
                    {
                        Nombre = maquinaria.Nombre,
                        Descripcion = maquinaria.Descripcion,
                        Marca = maquinaria.Marca,
                        Modelo = maquinaria.Modelo
                    };
                    db.Maquinaria.Add(nuevaMaquinaria);
                    db.SaveChanges();
                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProceso = "Maquina creada satisfactoriamente";
                    return View(maquinaria);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al crear la maquinaria: " + ex.Message;
                return View(maquinaria);
            }
        }

        // GET: Maquinaria/EditM/5
        public ActionResult EditM(int id)
        {
            try
            {
                EditMaquinaria maquinaria = new EditMaquinaria();
                using (FincaAgricolaDBEntities db = new FincaAgricolaDBEntities())
                {
                    var maquinariaX = db.Maquinaria.Find(id);
                    if (maquinariaX != null)

                    {
                        maquinaria.MaquinariaID = maquinariaX.MaquinariaID;
                        maquinaria.Nombre = maquinariaX.Nombre;
                        maquinaria.Descripcion = maquinariaX.Descripcion;
                        maquinaria.Marca = maquinariaX.Marca;
                        maquinaria.Modelo = maquinariaX.Modelo;
                        return View(maquinaria);
                    }
                }
                return View(maquinaria);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Maquinaria/EditM/5
        [HttpPost]

        public ActionResult EditM(EditMaquinaria maquinaria)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(maquinaria);
                }

                using (FincaAgricolaDBEntities db = new FincaAgricolaDBEntities())
                {
                    var maquinariaActual = db.Maquinaria.Find(maquinaria.MaquinariaID);
                    if (maquinariaActual != null)
                    {
                        maquinariaActual.Nombre = maquinaria.Nombre;
                        maquinariaActual.Descripcion = maquinaria.Descripcion;
                        maquinariaActual.Marca = maquinaria.Marca;
                        maquinariaActual.Modelo = maquinaria.Modelo;

                        db.Entry(maquinariaActual).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        ViewBag.ValorMensaje = 1;
                        ViewBag.MensajeProceso = "Maquinaria actualizado satisfactoriamente";
                        return View(maquinaria);
                    }

                    return Json(new { mensaje = "No se encontró un maquina con el ID " + maquinaria.MaquinariaID }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Error al actualizar la maquina: " + ex.Message;
                return View(maquinaria);
            }
        }
        public ActionResult DeleteM(int id)
        {
            try
            {
                using (FincaAgricolaDBEntities db = new FincaAgricolaDBEntities())
                {
                    var maquiriaActual = db.Maquinaria.Find(id);
                    if (maquiriaActual != null)
                    {
                        db.Maquinaria.Remove(maquiriaActual);
                        db.SaveChanges();

                        // Usar TempData para pasar el mensaje de éxito al Index
                        TempData["ValorMensaje"] = 1;
                        TempData["MensajeProceso"] = "Maquina eliminado satisfactoriamente";

                        // Redirigir a la acción Index para mostrar el mensaje
                        return RedirectToAction("IndexM");
                    }

                    // Si no se encuentra la maquina
                    TempData["ValorMensaje"] = 0;
                    TempData["MensajeProceso"] = "No se encontró una maquina con el ID " + id;

                    // Redirigir al Index en caso de error
                    return RedirectToAction("IndexM");
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error
                TempData["ValorMensaje"] = 0;
                TempData["MensajeProceso"] = "Error al eliminar la maquina: " + ex.Message;

                // Redirigir al Index en caso de error
                return RedirectToAction("IndexM");
            }
        }

    }
}