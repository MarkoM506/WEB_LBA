using Entidades;
using LogicaNegocio.Interfaces;
using LogicaNegocio.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WEB_LBA.Models;

namespace WEB_LBA.Controllers
{
    public class MateriaController : Controller
    {
        private IMateriaLN objMateria = new MateriaLN();

        // ========================
        // MÉTODO AUXILIAR
        // ========================
        private void CargarProfesores()
        {
            ProfesorLN logica = new ProfesorLN();
            var lista = logica.recProfesoresLN();
            ViewBag.Profesores = new MultiSelectList(lista, "id_profesor", "nombre");
        }

        // ========================
        // VISTAS DE CONSULTA
        // ========================
        public ActionResult ListMaterias()
        {
            var lista = objMateria.recMateriasln();
            var modelo = lista.Select(item => new M_Materia
            {
                id_materia = item.id_materia,
                nombre_materia = item.nombre_materia
            }).ToList();

            return View(modelo);
        }

        public ActionResult ListMateriasConProfesores()
        {
            var lista = objMateria.recMateriasConProfesln();
            var modelo = lista.Select(item => new M_MateriaConsulta
            {
                id_materia = item.id_materia,
                nombre_materia = item.nombre_materia,
                profesores = item.profesores
            }).ToList();

            return View(modelo);
        }

        // ========================
        // VISTAS CRUD
        // ========================
        public ActionResult AgregarMateria()
        {
            CargarProfesores();
            return View(new M_Materia());
        }

        public ActionResult ModificaMateria(int id)
        {
            var item = objMateria.recMateriaXIdln(id);
            CargarProfesores();

            var modelo = new M_Materia
            {
                id_materia = item.id_materia,
                nombre_materia = item.nombre_materia,
                profesores_seleccionados = new ProfesorLN()
                    .obtenerProfesoresPorMateriaLN(id)
                    .Select(p => p.id_profesor).ToList()
            };

            return View(modelo);
        }

        public ActionResult EliminaMateria(int id)
        {
            var item = objMateria.recMateriaXIdln(id);

            var modelo = new M_Materia
            {
                id_materia = item.id_materia,
                nombre_materia = item.nombre_materia
            };

            return View(modelo);
        }

        // ========================
        // ACCIONES POST
        // ========================
        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Materia pMateria)
        {
            try
            {
                var profesorLN = new ProfesorLN();

                if ((submitButton == "Agregar" || submitButton == "Actualizar") && !ModelState.IsValid)
                {
                    CargarProfesores();
                    return View(submitButton == "Agregar" ? "AgregarMateria" : "ModificaMateria", pMateria);
                }

                var obj = new Materia
                {
                    id_materia = pMateria.id_materia,
                    nombre_materia = pMateria.nombre_materia
                };

                switch (submitButton)
                {
                    case "Agregar":
                        if (!objMateria.insMaterialn(obj))
                        {
                            ModelState.AddModelError("", "Error al agregar la materia.");
                            CargarProfesores();
                            return View("AgregarMateria", pMateria);
                        }

                        // Obtener ID insertado
                        int nuevoId = objMateria.recMateriasln().Last().id_materia;

                        // Asignar profesores
                        foreach (var idProf in pMateria.profesores_seleccionados)
                            profesorLN.vincularMateriaAProfesorLN(idProf, nuevoId);

                        return RedirectToAction("ListMaterias");

                    case "Actualizar":
                        if (!objMateria.modMaterialn(obj))
                        {
                            ModelState.AddModelError("", "Error al modificar la materia.");
                            CargarProfesores();
                            return View("ModificaMateria", pMateria);
                        }

                        // Eliminar relaciones existentes
                        var actuales = profesorLN.obtenerProfesoresPorMateriaLN(obj.id_materia);
                        foreach (var prof in actuales)
                            profesorLN.removerMateriaDeProfesorLN(prof.id_profesor, obj.id_materia);

                        // Reasignar seleccionados
                        foreach (var idProf in pMateria.profesores_seleccionados)
                            profesorLN.vincularMateriaAProfesorLN(idProf, obj.id_materia);

                        return RedirectToAction("ListMaterias");

                    case "Eliminar":
                        // Primero eliminar relaciones materia-profesor
                        var relacionados = profesorLN.obtenerProfesoresPorMateriaLN(obj.id_materia);
                        foreach (var prof in relacionados)
                            profesorLN.removerMateriaDeProfesorLN(prof.id_profesor, obj.id_materia);

                        // Ahora eliminar la materia
                        if (!objMateria.delMaterialn(obj))
                        {
                            ModelState.AddModelError("", "Error al eliminar la materia.");
                            return View("EliminaMateria", pMateria);
                        }

                        return RedirectToAction("ListMaterias");

                    default:
                        return RedirectToAction("ListMaterias");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Materia", "Acciones"));
            }
        }
    }
}
