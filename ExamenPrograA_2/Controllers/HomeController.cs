using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenPrograA_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inventario()
        {
            return View();
        }

        public ActionResult Preguntas()
        {
            return View();
        }

        public ActionResult Administracion()
        {
            return View();
        }
        public ActionResult Agricultura()
        {
            return View();
        }

        // Acción para la página de Historia
        public ActionResult Historia()
        {
            return View();
        }

        // Acción para la página de Equipos
        public ActionResult Equipos()
        {
            return View();
        }
     }
  }