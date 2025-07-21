using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using WEB_LBA.Models;

namespace WEB_LBA.Controllers
{
    public class SeccionController : Controller
    {
        private ISeccionLN objSecciones = new SeccionLN();

        //VISTAS

        public ActionResult ListSecciones()
        {
            List<SP_recSecciones_Result> IstSecciones = new List<SP_recSecciones_Result>();

            List<M_Seccion> lstModeloSeccion = new List<M_Seccion>();

            IstSecciones = objSecciones.recSeccionln();

            foreach (var seccion in IstSecciones)
            {
                M_Seccion objModeloSeccion = new M_Seccion();

                objModeloSeccion.id_seccion = seccion.id_seccion;
                objModeloSeccion.nombre_seccion = seccion.nombre_seccion;
                objModeloSeccion.id_ciclo = seccion.id_ciclo;


                lstModeloSeccion.Add(objModeloSeccion);

            }
            return View(lstModeloSeccion);


        }
        public ActionResult VerSeccionesPorCiclo(int id)
        {
            try
            {
                var lista = objSecciones.recSeccionesPorCicloLN(id);
                return View(lista);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Seccion", "VerSeccionesPorCiclo"));
            }
        }




        public ActionResult AgregarSecciones()
        {
            return View();
        }

        public ActionResult ModificaSecciones(int id)
        {
            SP_recSeccionPorId_Result objSeccion = new SP_recSeccionPorId_Result();

            M_Seccion objSeccionesEnt = new M_Seccion();

            objSeccion = objSecciones.recSeccionXIdln(id);

            objSeccionesEnt.id_seccion = objSeccion.id_seccion;

            objSeccionesEnt.nombre_seccion = objSeccion.nombre_seccion;

            objSeccionesEnt.id_ciclo = objSeccion.id_ciclo;


            return View(objSeccionesEnt);
        }
        public ActionResult EliminaSecciones(int id)
        {
            SP_recSeccionPorId_Result objSeccion = new SP_recSeccionPorId_Result();

            M_Seccion objSeccionesEnt = new M_Seccion();

            objSeccion = objSecciones.recSeccionXIdln(id);

            objSeccionesEnt.id_seccion = objSeccion.id_seccion;

            objSeccionesEnt.nombre_seccion = objSeccion.nombre_seccion;
            objSeccionesEnt.id_ciclo = objSeccion.id_ciclo;

            return View(objSeccionesEnt);
        }
       
        // METODOS 

        public ActionResult IngresarSeccion(Seccione objSeccion)
        {
            List<SP_recSecciones_Result> IstSecciones = new List<SP_recSecciones_Result>();

            List<M_Seccion> lstModeloSeccion = new List<M_Seccion>();
            try
            {
                if (objSecciones.insSeccionln(objSeccion))
                {
                    IstSecciones = objSecciones.recSeccionln();

                    foreach (var seccion in IstSecciones)
                    {
                        M_Seccion objModeloSeccion = new M_Seccion();

                        objModeloSeccion.id_seccion = seccion.id_seccion;
                        objModeloSeccion.nombre_seccion = seccion.nombre_seccion;
                        objModeloSeccion.id_ciclo = seccion.id_ciclo;


                        lstModeloSeccion.Add(objModeloSeccion);


                    }
                }

            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));


            }
            return View("ListSecciones", lstModeloSeccion);

        }
        public ActionResult ModificarSeccion(Seccione objSeccion)
        {
            List<SP_recSecciones_Result> IstSecciones = new List<SP_recSecciones_Result>();

            List<M_Seccion> lstModeloSeccion = new List<M_Seccion>();
            try
            {
                if (objSecciones.modSeccionln(objSeccion))
                {
                    IstSecciones = objSecciones.recSeccionln();

                    foreach (var seccion in IstSecciones)
                    {
                        M_Seccion objModeloSeccion = new M_Seccion();

                        objModeloSeccion.id_seccion = seccion.id_seccion;
                        objModeloSeccion.nombre_seccion = seccion.nombre_seccion;
                        objModeloSeccion.id_ciclo = seccion.id_ciclo;


                        lstModeloSeccion.Add(objModeloSeccion);


                    }
                }

            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));


            }
            return View("ListSecciones", lstModeloSeccion);

        }
        public ActionResult EliminarSeccion(Seccione objSeccion)
        {
            List<SP_recSecciones_Result> IstSecciones = new List<SP_recSecciones_Result>();

            List<M_Seccion> lstModeloSeccion = new List<M_Seccion>();
            try
            {
                if (objSecciones.delSeccionln(objSeccion))
                {
                    IstSecciones = objSecciones.recSeccionln();

                    foreach (var seccion in IstSecciones)
                    {
                        M_Seccion objModeloSeccion = new M_Seccion();

                        objModeloSeccion.id_seccion = seccion.id_seccion;

                        objModeloSeccion.nombre_seccion = seccion.nombre_seccion;

                        objModeloSeccion.id_ciclo = seccion.id_ciclo;



                        lstModeloSeccion.Add(objModeloSeccion);


                    }
                }

            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));


            }
            return View("ListSecciones", lstModeloSeccion);

        }
        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Seccion pSeccion)
        {
            try
            {
                Seccione objSecc = new Seccione
                {
                    id_seccion = pSeccion.id_seccion,
                    nombre_seccion = pSeccion.nombre_seccion,
                    id_ciclo = pSeccion.id_ciclo
                };

                switch (submitButton)
                {
                    case "Agregar":
                    case "Actualizar":
                        if (!ModelState.IsValid)
                            return View(submitButton == "Agregar" ? "AgregarSecciones" : "ModificaSecciones", pSeccion);
                        break;
                }

                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarSeccion(objSecc);

                    case "Actualizar":
                        return ModificarSeccion(objSecc);

                    case "Eliminar":
                        return EliminarSeccion(objSecc);

                    default:
                        return RedirectToAction("ListSecciones", "Seccion");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Seccion", "Acciones"));
            }
        }
    }
}