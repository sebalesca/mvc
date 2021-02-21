using AplicationMVC2.Entidad;
using AplicationMVC2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicationMVC2.Controllers
{
    public class PersonasController : Controller
    {

        EntidadDB _db = new EntidadDB();


        public ActionResult Inicio()
        {

            var _listaPersonas = _db.Personas.ToList();

            return View(_listaPersonas);
        }

        public ActionResult Alta()
        {
            var _datosVista = new AltaPersonaVM();


            return View(_datosVista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta(AltaPersonaVM _persona)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var _nuevaPersona = new Personas()
                    {
                        Id = Guid.NewGuid(),
                        Nombre = _persona.Nombre,
                        Direccion = _persona.Direccion,
                        Edad = _persona.Edad
                    };

                    _db.Personas.Add(_nuevaPersona);
                    _db.SaveChanges();
                    TempData["Mensaje"] = "Persona agragada correctamente";
                    return RedirectToAction("inicio");

                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    return RedirectToAction("inicio");
                }
            }


            return View(_persona);
        }

        public ActionResult Editar(Guid Id)
        {
            var _persona = _db.Personas.Find(Id);

            var _datosVista = new AltaPersonaVM() {
                Id = _persona.Id,
                Direccion = _persona.Direccion,
                Edad = (int)_persona.Edad,
                Nombre = _persona.Nombre

            };

            return View(_datosVista);
        }

        [HttpPost]
        public ActionResult Editar( AltaPersonaVM _persona)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var _personaEditada = new Personas()
                    {
                        Nombre=_persona.Nombre,
                        Edad=_persona.Edad,
                        Direccion=_persona.Direccion,
                        Id=_persona.Id
                    };

                    _db.Entry(_personaEditada).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();

                    TempData["Mensaje"] = "Datos actualizados correctamente";
                    return RedirectToAction("inicio");

                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    return RedirectToAction("inicio");

                }
            }

            return View(_persona);
        }

        public ActionResult Eliminar(Guid Id)
        {
            try
            {
                var _persona = _db.Personas.Find(Id);

                _db.Personas.Remove(_persona);
                _db.SaveChanges();
                TempData["Mensaje"] = "Persona eliminada";


            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;

            }
            return RedirectToAction("inicio");

        }



    }
}