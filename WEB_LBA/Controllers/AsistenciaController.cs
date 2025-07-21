using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using WEB_LBA.Models;

namespace WEB_LBA.Controllers
{
    public class AsistenciaController : Controller
    {
        private readonly IAsistenciaLN objAsistencia = new AsistenciaLN();
        private readonly ProfesorLN l_profesor = new ProfesorLN();
        private readonly MateriaLN l_materia = new MateriaLN();
        private SeccionLN seccionLN = new SeccionLN();
        private ProfesorLN profesorLN = new ProfesorLN();
        private MateriaLN materiaLN = new MateriaLN();
        private void CargarCombos()
        {
            ViewBag.Estudiantes = new SelectList(new EstudianteLN().recEstudianteln(), "id_estudiante", "nombre");
            ViewBag.Materias = new SelectList(new MateriaLN().recMateriasln(), "id_materia", "nombre_materia");
            ViewBag.Profesores = new SelectList(new ProfesorLN().recProfesoresLN(), "id_profesor", "nombre");
            ViewBag.Estados = new SelectList(objAsistencia.obtenerEstadosDesdeTablAln(), "id_estado", "nombre_estado");
            ViewBag.Secciones = new SelectList(new SeccionLN().recSeccionln(), "id_seccion", "nombre_seccion");
        }

        private int ObtenerIdEstadoDesdeSimbolo(string simbolo)
        {
            switch (simbolo)
            {
                case "✔": return 1;
                case "❌": return 2;
                case "J": return 3;
                case "T": return 4;
                default: return 0;
            }
        }

        public ActionResult ListAsistencia()
        {
            var lista = objAsistencia.recAsistenciasln();
            var modelo = lista.Select(item => new M_Asistencia
            {
                id_asistencia = item.id_asistencia,
                id_estudiante = item.id_estudiante.Value,
                id_materia = item.id_materia.Value,
                id_profesor = item.id_profesor.Value,
                fecha = item.fecha.Value,
                id_estado = item.id_estado.Value,
                observaciones = item.observaciones
            }).ToList();

            return View(modelo);
        }

        public ActionResult ReporteMensual()
        {
            CargarCombos();
            return View(new M_AsistenciaReporte());
        }

        [HttpPost]
        public ActionResult ReporteMensual(M_AsistenciaReporte filtros)
        {
            CargarCombos();

            if (!ModelState.IsValid)
                return View(filtros);

            var resultado = objAsistencia.reporteMensualln(
                filtros.anio,
                filtros.mes,
                filtros.id_profesor,
                filtros.id_seccion,
                filtros.id_materia
            );

            filtros.resultado = resultado;
            return View(filtros);
        }

        public ActionResult VerAsistenciaPorSeccion(int id_seccion)
        {
            var estudiantes = new EstudianteLN().recEstudianteln()
                .Where(e => e.id_seccion == id_seccion).ToList();

            return View("ListAsistenciaPorSeccion", estudiantes);
        }

        public ActionResult TomarAsistencia(int id_seccion, int? mes, int? anio, int? idProfesor, int? idMateria)
        {
            AsistenciaLN ln = new AsistenciaLN();
            ProfesorLN profesorLN = new ProfesorLN();
            MateriaLN materiaLN = new MateriaLN();

            int mesSeleccionado = mes ?? DateTime.Now.Month;
            int anioSeleccionado = anio ?? DateTime.Now.Year;

            ViewBag.MesSeleccionado = mesSeleccionado;
            ViewBag.AnioSeleccionado = anioSeleccionado;
            ViewBag.IdProfesor = idProfesor;
            ViewBag.IdMateria = idMateria;
            ViewBag.IdSeccion = id_seccion;

            ViewBag.NombreProfesor = profesorLN.recProfesoresLN()
                .FirstOrDefault(p => p.id_profesor == idProfesor)?.nombre ?? "";

            ViewBag.NombreMateria = materiaLN.recMateriasln()
                .FirstOrDefault(m => m.id_materia == idMateria)?.nombre_materia ?? "";

            ViewBag.Asistencias = ln.obtenerAsistenciasPorFiltroLN(
                mesSeleccionado,
                anioSeleccionado,
                idProfesor.Value,
                idMateria.Value,
                id_seccion
            );

            var estudiantes = new EstudianteLN().recEstudianteln()
                .Where(e => e.id_seccion == id_seccion)
                .Select(e => new Entidades.Estudiante
                {
                    id_estudiante = e.id_estudiante,
                    nombre = e.nombre,
                    id_seccion = e.id_seccion
                }).ToList();

            return View(estudiantes);
        }
        public ActionResult SeleccionaPeriodoAsistenciaMensual()
        {
            ViewBag.Secciones = seccionLN.recSeccionln();
            ViewBag.Profesores = profesorLN.recProfesoresLN();
            ViewBag.Materias = materiaLN.recMateriasln();
            return View();
        }
        private string ObtenerSimboloDesdeIdEstado(int id_estado)
        {
            switch (id_estado)
            {
                case 1: return "✔";
                case 2: return "❌"; 
                case 3: return "J";
                case 4: return "T";
                default: return "";
            }
        }

        [HttpPost]
        public ActionResult GuardarAsistenciasMasivo(FormCollection form)
        {
            try
            {
                int mes = Convert.ToInt32(form["mes"]);
                int anio = Convert.ToInt32(form["anio"]);
                int idMateria = Convert.ToInt32(form["id_materia"]);
                int idProfesor = Convert.ToInt32(form["id_profesor"]);
                int idSeccion = Convert.ToInt32(form["id_seccion"]);

                foreach (string key in form.AllKeys)
                {
                    if (key.StartsWith("asistencias["))
                    {
                        var match = System.Text.RegularExpressions.Regex.Match(key, @"asistencias\[(\d+)\]\[(\d+)\]");
                        if (match.Success)
                        {
                            int idEstudiante = int.Parse(match.Groups[1].Value);
                            int dia = int.Parse(match.Groups[2].Value);
                            string estado = form[key];
                            DateTime fecha = new DateTime(anio, mes, dia);

                            // 🧨 Siempre eliminamos primero
                            objAsistencia.eliminarAsistenciaPorFechaLN(idEstudiante, idProfesor, idMateria, fecha);

                            // ✅ Si hay símbolo válido, insertamos de nuevo
                            if (!string.IsNullOrWhiteSpace(estado))
                            {
                                var asistencia = new Asistencia
                                {
                                    id_estudiante = idEstudiante,
                                    fecha = fecha,
                                    id_materia = idMateria,
                                    id_profesor = idProfesor,
                                    id_estado = ObtenerIdEstadoDesdeSimbolo(estado),
                                    observaciones = ""
                                };

                                objAsistencia.insAsistencialn(asistencia);
                            }
                        }
                    }
                }

                TempData["Mensaje"] = "Asistencia guardada correctamente.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al guardar la asistencia.";
            }

            // Siempre redirige para refrescar vista y ver cambios
            return RedirectToAction("TomarAsistencia", new
            {
                id_seccion = form["id_seccion"],
                mes = form["mes"],
                anio = form["anio"],
                idProfesor = form["id_profesor"],
                idMateria = form["id_materia"]
            });
        }

        public ActionResult SeleccionarPeriodoAsistencia(int id_seccion)
        {
            var model = new M_SeleccionPeriodoAsistencia
            {
                Anio = DateTime.Now.Year,
                Mes = DateTime.Now.Month,
                IdSeccion = id_seccion
            };

            ViewBag.Profesores = new SelectList(l_profesor.recProfesoresLN(), "id_profesor", "nombre");
            ViewBag.Materias = new SelectList(l_materia.recMateriasln(), "id_materia", "nombre_materia");

            return View(model);
        }

        [HttpPost]
        public ActionResult SeleccionarPeriodoAsistencia(M_SeleccionPeriodoAsistencia model)
        {
            return RedirectToAction("TomarAsistencia", new
            {
                id_seccion = model.IdSeccion,
                mes = model.Mes,
                anio = model.Anio,
                idProfesor = model.IdProfesor,
                idMateria = model.IdMateria
            });
        }

        public ActionResult AgregarAsistencia()
        {
            CargarCombos();
            return View(new M_Asistencia());
        }

        public ActionResult ModificaAsistencia(int id)
        {
            var item = objAsistencia.recAsistenciaXIdln(id);
            CargarCombos();

            var modelo = new M_Asistencia
            {
                id_asistencia = item.id_asistencia,
                id_estudiante = item.id_estudiante.Value,
                id_materia = item.id_materia.Value,
                id_profesor = item.id_profesor.Value,
                fecha = item.fecha.Value,
                id_estado = item.id_estado.Value,
                observaciones = item.observaciones
            };

            return View(modelo);
        }

        public ActionResult EliminaAsistencia(int id)
        {
            var item = objAsistencia.recAsistenciaXIdln(id);

            var modelo = new M_Asistencia
            {
                id_asistencia = item.id_asistencia,
                id_estudiante = item.id_estudiante.Value,
                id_materia = item.id_materia.Value,
                id_profesor = item.id_profesor.Value,
                fecha = item.fecha.Value,
                id_estado = item.id_estado.Value,
                observaciones = item.observaciones
            };

            return View(modelo);
        }


        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Asistencia asistencia)
        {
            try
            {
                if ((submitButton == "Agregar" || submitButton == "Actualizar") && !ModelState.IsValid)
                {
                    CargarCombos();
                    return View(submitButton == "Agregar" ? "AgregarAsistencia" : "ModificaAsistencia", asistencia);
                }

                var entidad = new Asistencia
                {
                    id_asistencia = asistencia.id_asistencia,
                    id_estudiante = asistencia.id_estudiante,
                    id_materia = asistencia.id_materia,
                    id_profesor = asistencia.id_profesor,
                    fecha = asistencia.fecha,
                    id_estado = asistencia.id_estado,
                    observaciones = asistencia.observaciones
                };

                switch (submitButton)
                {
                    case "Agregar":
                        if (!objAsistencia.insAsistencialn(entidad))
                        {
                            ModelState.AddModelError("", "Error al agregar la asistencia.");
                            CargarCombos();
                            return View("AgregarAsistencia", asistencia);
                        }
                        return RedirectToAction("ListAsistencia");

                    case "Actualizar":
                        if (!objAsistencia.modAsistencialn(entidad))
                        {
                            ModelState.AddModelError("", "Error al modificar la asistencia.");
                            CargarCombos();
                            return View("ModificaAsistencia", asistencia);
                        }
                        return RedirectToAction("ListAsistencia");

                    case "Eliminar":
                        if (!objAsistencia.delAsistencialn(entidad))
                        {
                            ModelState.AddModelError("", "Error al eliminar la asistencia.");
                            return View("EliminaAsistencia", asistencia);
                        }
                        return RedirectToAction("ListAsistencia");

                    default:
                        return RedirectToAction("ListAsistencia");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Asistencia", "Acciones"));
            }
        }
    }
}