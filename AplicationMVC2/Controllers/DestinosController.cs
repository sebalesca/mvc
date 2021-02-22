using AplicationMVC2.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicationMVC2.Controllers
{
    public class DestinosController : Controller
    {
        // GET: Destinos
        EntidadDB _db = new EntidadDB();
        public ActionResult Inicio(Personas persona)
        {
            Personas _p = _db.Personas.Find(persona.Id);
            var _destinos = _p.Destinos;
            return View(_destinos);
        }
    }
}