using ExamenPrograA_2.Models;
using ExamenPrograA_2.Models.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ExamenPrograA_2.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdminController : Controller
    {
        private FincaAgricolaDBEntities db = new FincaAgricolaDBEntities();

        // GET: Admin/Usuarios
        public ActionResult Usuarios()
        {
            var usuarios = db.Usuarios.ToList();
            return View(usuarios);
        }
    }
}
