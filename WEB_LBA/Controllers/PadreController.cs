using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using WEB_LBA.Models;

namespace WEB_LBA.Controllers
{
    public class PadreController : Controller
    {
        private readonly IPadreLN objPadres = new PadreLN();
        private readonly IEstudianteLN objEstudiantes = new EstudianteLN(); // <- Agregado

        // ===============================
        // VISTAS
        // ===============================

        public ActionResult ListPadres()
        {
            var lista = objPadres.recPadresLN();
            List<M_Padre> modelo = new List<M_Padre>();

            foreach (var item in lista)
            {
                modelo.Add(new M_Padre
                {
                    id_padre = item.id_padre,
                    cedula = item.cedula,
                    nombre = item.nombre,
                    telefono = item.telefono
                });
            }

            return View(modelo);
        }

        public ActionResult AgregarPadres() => View();

        public ActionResult ModificaPadres(int id)
        {
            var dato = objPadres.recPadrePorIdLN(id);

            return View(new M_Padre
            {
                id_padre = dato.id_padre,
                cedula = dato.cedula,
                nombre = dato.nombre,
                telefono = dato.telefono
            });
        }

        public ActionResult EliminaPadres(int id)
        {
            var dato = objPadres.recPadrePorIdLN(id);

            return View(new M_Padre
            {
                id_padre = dato.id_padre,
                cedula = dato.cedula,
                nombre = dato.nombre,
                telefono = dato.telefono
            });
        }

        public ActionResult VerHijosPorPadre(int id)
        {
            var hijos = objPadres.obtenerHijosPorPadreLN(id);
            var modelo = new List<M_EstudianteConsulta>();

            foreach (var item in hijos)
            {
                modelo.Add(new M_EstudianteConsulta
                {
                    id_estudiante = item.id_estudiante,
                    cedula = item.cedula,
                    nombre = item.nombre,
                    direccion = item.direccion,
                    telefono = item.telefono,
                    seccion = item.seccion
                });
            }

            ViewBag.IdPadre = id; //  solución al error "no se puede convertir null en int"
            return View(modelo);
        }

        public ActionResult BuscarPorCedula() => View();

        [HttpPost]
        public ActionResult BuscarPorCedula(string cedula)
        {
            try
            {
                var resultado = objPadres.recPadrePorCedulaLN(cedula);

                if (resultado == null)
                {
                    ViewBag.Mensaje = "No se encontró ningún padre con esa cédula.";
                    return View();
                }

                return View("DetallePadrePorCedula", new M_PadreConsulta
                {
                    id_padre = resultado.id_padre,
                    cedula = resultado.cedula,
                    nombre = resultado.nombre,
                    telefono = resultado.telefono
                });
            }
            catch
            {
                return View("Error");
            }
        }

        // ===============================
        // MÉTODOS
        // ===============================

        public ActionResult IngresarPadre(Padre obj)
        {
            if (!objPadres.insPadreLN(obj))
                ModelState.AddModelError("", "Error al agregar el padre.");

            return RedirectToAction("ListPadres");
        }

        public ActionResult ModificarPadre(Padre obj)
        {
            if (!objPadres.modPadreLN(obj))
                ModelState.AddModelError("", "Error al modificar el padre.");

            return RedirectToAction("ListPadres");
        }

        public ActionResult EliminarPadre(Padre obj)
        {
            if (!objPadres.delPadreLN(obj))
                ModelState.AddModelError("", "Error al eliminar el padre.");

            return RedirectToAction("ListPadres");
        }

        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Padre pPadre)
        {
            Padre padre = new Padre
            {
                id_padre = pPadre.id_padre,
                cedula = pPadre.cedula,
                nombre = pPadre.nombre,
                telefono = pPadre.telefono
            };

            switch (submitButton)
            {
                case "Agregar":
                case "Actualizar":
                    if (!ModelState.IsValid)
                        return View(submitButton == "Agregar" ? "AgregarPadres" : "ModificaPadres", pPadre);
                    break;
            }

            switch (submitButton)
            {
                case "Agregar":
                    return IngresarPadre(padre);
                case "Actualizar":
                    return ModificarPadre(padre);
                case "Eliminar":
                    return EliminarPadre(padre);
                default:
                    return RedirectToAction("ListPadres");
            }
        }

        // ===============================
        // RELACIÓN PADRE - ESTUDIANTE
        // ===============================

        public ActionResult AsignarHijos(int idPadre) // <- Renombrado para evitar ambigüedad
        {
            ViewBag.IdPadre = idPadre;
            var estudiantes = objEstudiantes.recEstudianteln();
            var modelo = new List<M_EstudianteConsulta>();

            foreach (var item in estudiantes)
            {
                modelo.Add(new M_EstudianteConsulta
                {
                    id_estudiante = item.id_estudiante,
                    cedula = item.cedula,
                    nombre = item.nombre,
                    direccion = item.direccion,
                    telefono = item.telefono,
                    seccion = item.seccion
                });
            }

            return View(modelo);
        }

        public ActionResult AsignarHijo(int idPadre, int idEstudiante)
        {
            objPadres.asignarEstudianteALN(idPadre, idEstudiante);
            return RedirectToAction("ListPadres");
        }

        public ActionResult QuitarHijo(int idPadre, int idEstudiante)
        {
            objPadres.quitarEstudianteDeLN(idPadre, idEstudiante);
            return RedirectToAction("VerHijosPorPadre", new { id = idPadre });
        }
    }
}