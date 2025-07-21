using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_LBA.Models;

namespace WEB_LBA.Controllers
{
    public class EstudianteController : Controller
    {
        private IEstudianteLN objEstudiantes = new EstudianteLN();

        // VISTAS

        public ActionResult ListEstudiantes()
        {
            List<SP_recEstudiantes_Result> IstEstudiantes = objEstudiantes.recEstudianteln();
            List<M_Estudiante> lstModeloEstudiante = new List<M_Estudiante>();

            foreach (var estudiante in IstEstudiantes)
            {
                M_Estudiante objModeloEstudiante = new M_Estudiante
                {
                    id_estudiante = estudiante.id_estudiante,
                    cedula = estudiante.cedula,
                    nombre = estudiante.nombre,
                    direccion = estudiante.direccion,
                    telefono = estudiante.telefono,
                    id_seccion = estudiante.id_seccion
                };

                lstModeloEstudiante.Add(objModeloEstudiante);
            }

            return View(lstModeloEstudiante);
        }

        public ActionResult AgregarEstudiantes()
        {
            return View();
        }

        public ActionResult ModificaEstudiantes(int id)
        {
            SP_recEstudiantePorId_Result objEstudiante = objEstudiantes.recEstudianteXIdln(id);

            M_Estudiante objEstudiantesEnt = new M_Estudiante
            {
                id_estudiante = objEstudiante.id_estudiante,
                cedula = objEstudiante.cedula,
                nombre = objEstudiante.nombre,
                direccion = objEstudiante.direccion,
                telefono = objEstudiante.telefono,
                id_seccion = objEstudiante.id_seccion
            };

            return View(objEstudiantesEnt);
        }

        public ActionResult EliminaEstudiantes(int id)
        {
            SP_recEstudiantePorId_Result objEstudiante = objEstudiantes.recEstudianteXIdln(id);

            M_Estudiante objEstudiantesEnt = new M_Estudiante
            {
                id_estudiante = objEstudiante.id_estudiante,
                cedula = objEstudiante.cedula,
                nombre = objEstudiante.nombre,
                direccion = objEstudiante.direccion,
                telefono = objEstudiante.telefono,
                id_seccion = objEstudiante.id_seccion
            };

            return View(objEstudiantesEnt);
        }

        public ActionResult VerEstudiantesPorSeccion(int id)
        {
            try
            {
                List<SP_recEstudiantesPorSeccion_Result> lista = objEstudiantes.recEstudiantesPorSeccionln(id);
                List<M_EstudianteConsulta> listaModelo = new List<M_EstudianteConsulta>();

                foreach (var estudiante in lista)
                {
                    M_EstudianteConsulta obj = new M_EstudianteConsulta
                    {
                        id_estudiante = estudiante.id_estudiante,
                        cedula = estudiante.cedula,
                        nombre = estudiante.nombre,
                        direccion = estudiante.direccion,
                        telefono = estudiante.telefono,
                        seccion = estudiante.seccion
                    };

                    listaModelo.Add(obj);
                }

                return View(listaModelo);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Estudiante", "VerEstudiantesPorSeccion"));
            }
        }

        public ActionResult BuscarPorCedula()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarPorCedula(string cedula)
        {
            try
            {
                var resultado = objEstudiantes.recEstudiantePorCedulaln(cedula);

                if (resultado == null)
                {
                    ViewBag.Mensaje = "No se encontró ningún estudiante con esa cédula.";
                    return View();
                }

                var modelo = new M_EstudianteConsulta
                {
                    id_estudiante = resultado.id_estudiante,
                    cedula = resultado.cedula,
                    nombre = resultado.nombre,
                    direccion = resultado.direccion,
                    telefono = resultado.telefono,
                    seccion = resultado.seccion
                };

                return View("DetalleEstudiantePorCedula", modelo);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Estudiante", "BuscarPorCedula"));
            }
        }

        public ActionResult VerPadresPorEstudiante(int id)
        {
            try
            {
                var lista = objEstudiantes.obtenerPadresPorEstudianteLN(id);
                List<M_PadreConsulta> modelo = new List<M_PadreConsulta>();

                foreach (var item in lista)
                {
                    modelo.Add(new M_PadreConsulta
                    {
                        id_padre = item.id_padre,
                        cedula = item.cedula,
                        nombre = item.nombre,
                        telefono = item.telefono
                    });
                }

                return View(modelo);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Estudiante", "VerPadresPorEstudiante"));
            }
        }

        // MÉTODOS

        public ActionResult IngresarEstudiante(Estudiante objEstudiante)
        {
            List<SP_recEstudiantes_Result> IstEstudiantes = new List<SP_recEstudiantes_Result>();
            List<M_Estudiante> lstModeloEstudiante = new List<M_Estudiante>();

            try
            {
                if (objEstudiantes.insEstudianteln(objEstudiante))
                {
                    IstEstudiantes = objEstudiantes.recEstudianteln();

                    foreach (var estudiante in IstEstudiantes)
                    {
                        M_Estudiante objModeloEstudiante = new M_Estudiante
                        {
                            id_estudiante = estudiante.id_estudiante,
                            cedula = estudiante.cedula,
                            nombre = estudiante.nombre,
                            direccion = estudiante.direccion,
                            telefono = estudiante.telefono,
                            id_seccion = estudiante.id_seccion
                        };

                        lstModeloEstudiante.Add(objModeloEstudiante);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Error al agregar el estudiante.");
                    return View("AgregarEstudiantes");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Estudiante", "IngresarEstudiante"));
            }

            return View("ListEstudiantes", lstModeloEstudiante);
        }

        public ActionResult ModificarEstudiante(Estudiante objEstudiante)
        {
            List<SP_recEstudiantes_Result> IstEstudiantes = new List<SP_recEstudiantes_Result>();
            List<M_Estudiante> lstModeloEstudiante = new List<M_Estudiante>();

            try
            {
                if (objEstudiantes.modEstudianteln(objEstudiante))
                {
                    IstEstudiantes = objEstudiantes.recEstudianteln();

                    foreach (var estudiante in IstEstudiantes)
                    {
                        M_Estudiante objModeloEstudiante = new M_Estudiante
                        {
                            id_estudiante = estudiante.id_estudiante,
                            cedula = estudiante.cedula,
                            nombre = estudiante.nombre,
                            direccion = estudiante.direccion,
                            telefono = estudiante.telefono,
                            id_seccion = estudiante.id_seccion
                        };

                        lstModeloEstudiante.Add(objModeloEstudiante);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Error al modificar el estudiante.");
                    return View("ModificaEstudiantes", objEstudiante);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Estudiante", "ModificarEstudiante"));
            }

            return View("ListEstudiantes", lstModeloEstudiante);
        }

        public ActionResult EliminarEstudiante(Estudiante objEstudiante)
        {
            try
            {
                bool eliminado = objEstudiantes.delEstudianteln(objEstudiante);

                if (!eliminado)
                {
                    ModelState.AddModelError("", "Error al eliminar el estudiante.");
                    // En este caso, no reconsultamos el estudiante eliminado
                    return View("EliminaEstudiantes", new M_Estudiante
                    {
                        id_estudiante = objEstudiante.id_estudiante,
                        cedula = objEstudiante.cedula,
                        nombre = objEstudiante.nombre,
                        direccion = objEstudiante.direccion,
                        telefono = objEstudiante.telefono,
                        id_seccion = objEstudiante.id_seccion
                    });
                }

                // Eliminado correctamente, redirige sin consultar más
                return RedirectToAction("ListEstudiantes");
            }
            catch (Exception ex)
            {
                // Ocurrió una excepción (por ejemplo, trató de acceder al estudiante después de borrado)
                return View("Error", new HandleErrorInfo(ex, "Estudiante", "EliminarEstudiante"));
            }
        }
        [HttpPost]
      
        public ActionResult Acciones(string submitButton, M_Estudiante pEstudiante)
        {
            try
            {
                Estudiante objest = new Estudiante
                {
                    id_estudiante = pEstudiante.id_estudiante,
                    cedula = pEstudiante.cedula,
                    nombre = pEstudiante.nombre,
                    direccion = pEstudiante.direccion,
                    telefono = pEstudiante.telefono,
                    id_seccion = pEstudiante.id_seccion
                };

                switch (submitButton)
                {
                    case "Agregar":
                    case "Actualizar":
                        if (!ModelState.IsValid)
                            return View(submitButton == "Agregar" ? "AgregarEstudiantes" : "ModificaEstudiantes", pEstudiante);
                        break;
                }

                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarEstudiante(objest);

                    case "Actualizar":
                        return ModificarEstudiante(objest);

                    case "Eliminar":
                        objEstudiantes.delEstudianteln(objest); // 🔁 Aquí se elimina
                        return RedirectToAction("ListEstudiantes"); // ✅ Redirige directamente a la lista

                    default:
                        return RedirectToAction("ListEstudiantes");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Estudiante", "Acciones"));
            }
        }
    }
}
