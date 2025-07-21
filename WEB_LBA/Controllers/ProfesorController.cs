using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WEB_LBA.Models;

namespace WEB_LBA.Controllers
{
    public class ProfesorController : Controller
    {
        private readonly IProfesorLN objProfesorLN = new ProfesorLN();

        // VISTAS PRINCIPALES

        public ActionResult ListProfesores()
        {
            List<M_Profesor> listaModelo = new List<M_Profesor>();
            var lista = objProfesorLN.recProfesoresLN();

            foreach (var item in lista)
            {
                listaModelo.Add(new M_Profesor
                {
                    id_profesor = item.id_profesor,
                    cedula = item.cedula,
                    nombre = item.nombre
                });
            }

            return View(listaModelo);
        }

        public ActionResult AgregarProfesores()
        {
            return View();
        }

        public ActionResult ModificaProfesores(int id)
        {
            var dato = objProfesorLN.recProfesorXIdLN(id);

            M_Profesor modelo = new M_Profesor
            {
                id_profesor = dato.id_profesor,
                cedula = dato.cedula,
                nombre = dato.nombre
            };

            return View(modelo);
        }

        public ActionResult EliminaProfesores(int id)
        {
            var dato = objProfesorLN.recProfesorXIdLN(id);

            M_Profesor modelo = new M_Profesor
            {
                id_profesor = dato.id_profesor,
                cedula = dato.cedula,
                nombre = dato.nombre
            };

            return View(modelo);
        }

        // MÉTODOS

        public ActionResult IngresarProfesor(Profesore obj)
        {
            var resultado = objProfesorLN.insProfesorLN(obj);
            if (!resultado)
                ModelState.AddModelError("", "Error al agregar el profesor.");
            return RedirectToAction("ListProfesores");
        }

        public ActionResult ModificarProfesor(Profesore obj)
        {
            var resultado = objProfesorLN.modProfesorLN(obj);
            if (!resultado)
                ModelState.AddModelError("", "Error al modificar el profesor.");
            return RedirectToAction("ListProfesores");
        }

        public ActionResult EliminarProfesor(Profesore obj)
        {
            var resultado = objProfesorLN.delProfesorLN(obj);
            if (!resultado)
                ModelState.AddModelError("", "Error al eliminar el profesor.");
            return RedirectToAction("ListProfesores");
        }

        // ACCIONES POR BOTÓN
        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Profesor p)
        {
            Profesore profe = new Profesore
            {
                id_profesor = p.id_profesor,
                cedula = p.cedula,
                nombre = p.nombre
            };

            switch (submitButton)
            {
                case "Agregar":
                    return IngresarProfesor(profe);
                case "Actualizar":
                    return ModificarProfesor(profe);
                case "Eliminar":
                    return EliminarProfesor(profe);
                default:
                    return RedirectToAction("ListProfesores");
            }
        }

        // VISTAS DE CONSULTA

        public ActionResult VerMateriasPorProfesor(int id)
        {
            var lista = objProfesorLN.obtenerMateriasPorProfesorLN(id);
            List<M_MateriaPorProfesor> modelo = new List<M_MateriaPorProfesor>();

            foreach (var item in lista)
            {
                modelo.Add(new M_MateriaPorProfesor
                {
                    id_profesor = item.id_profesor,
                    nombre_profesor = item.nombre_profesor,
                    id_materia = item.id_materia,
                    nombre_materia = item.nombre_materia
                });
            }

            return View(modelo);
        }

        public ActionResult VerProfesoresPorMateria(int id)
        {
            var lista = objProfesorLN.obtenerProfesoresPorMateriaLN(id);
            List<M_ProfesorPorMateria> modelo = new List<M_ProfesorPorMateria>();

            foreach (var item in lista)
            {
                modelo.Add(new M_ProfesorPorMateria
                {
                    id_materia = item.id_materia,
                    nombre_materia = item.nombre_materia,
                    id_profesor = item.id_profesor,
                    nombre_profesor = item.nombre_profesor
                });
            }

            return View(modelo);
        }

        public ActionResult ListProfesoresConMaterias()
        {
            var lista = objProfesorLN.listarProfesoresConMateriasLN();
            List<M_MateriaPorProfesor> modelo = new List<M_MateriaPorProfesor>();

            foreach (var item in lista)
            {
                modelo.Add(new M_MateriaPorProfesor
                {
                    id_profesor = item.id_profesor,
                    nombre_profesor = item.nombre_profesor,
                    id_materia = item.id_materia,
                    nombre_materia = item.nombre_materia
                });
            }

            return View(modelo);
        }
    }
}
