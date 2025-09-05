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
    public class CicloController : Controller
    {
        private ICicloLN objCiclos = new CicloLN();

        //VISTAS

        public ActionResult ListCiclos()
        {
            List<SP_recCiclos_Result> IstCiclos = new List<SP_recCiclos_Result>();

            List<M_Ciclo> lstModeloCiclo = new List<M_Ciclo>();

            IstCiclos = objCiclos.recCiclosln();

            foreach (var ciclo in IstCiclos)
            {
                M_Ciclo objModeloCiclo = new M_Ciclo();

                objModeloCiclo.id_ciclo = ciclo.id_ciclo;
                objModeloCiclo.nombre_ciclo = ciclo.nombre_ciclo;
                objModeloCiclo.descripcion = ciclo.descripcion;

                lstModeloCiclo.Add(objModeloCiclo);

            }
            return View(lstModeloCiclo);


        }
        public ActionResult AgregarCiclos()
        {
            return View();
        }
        public ActionResult ModificaCiclos(int id)
        {
            SP_recCicloPorId_Result objCiclo = new SP_recCicloPorId_Result();

            M_Ciclo objCiclosEnt = new M_Ciclo();

            objCiclo = objCiclos.recCiclosXIdln(id);

            objCiclosEnt.id_ciclo = objCiclo.id_ciclo;

            objCiclosEnt.nombre_ciclo = objCiclo.nombre_ciclo;

            objCiclosEnt.descripcion = objCiclo.descripcion;

            return View(objCiclosEnt);
        }
        public ActionResult EliminaCiclos(int id)
        {
            SP_recCicloPorId_Result objCiclo = new SP_recCicloPorId_Result();

            M_Ciclo objCiclosEnt = new M_Ciclo();

            objCiclo = objCiclos.recCiclosXIdln(id);

            objCiclosEnt.id_ciclo = objCiclo.id_ciclo;

            objCiclosEnt.nombre_ciclo = objCiclo.nombre_ciclo;

            objCiclosEnt.descripcion = objCiclo.descripcion;

            return View(objCiclosEnt);
        }


        // METODOS 

        public ActionResult IngresarCiclo(Ciclo objCiclo)
        {
            List<SP_recCiclos_Result> IstCiclos = new List<SP_recCiclos_Result>();

            List<M_Ciclo> lstModeloCiclo = new List<M_Ciclo>();
            try
            {
                if (objCiclos.insCiclosln(objCiclo))
                {
                    IstCiclos = objCiclos.recCiclosln();

                    foreach (var ciclo in IstCiclos)
                    {
                        M_Ciclo objModeloCiclo = new M_Ciclo();

                        objModeloCiclo.id_ciclo = ciclo.id_ciclo;
                        objModeloCiclo.nombre_ciclo = ciclo.nombre_ciclo;
                        objModeloCiclo.descripcion = ciclo.descripcion;

                        lstModeloCiclo.Add(objModeloCiclo);


                    }
                }

            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));


            }
            return View("ListCiclos", lstModeloCiclo);

        }
        public ActionResult ModificarCiclo(Ciclo objCiclo)
        {
            List<SP_recCiclos_Result> IstCiclos = new List<SP_recCiclos_Result>();

            List<M_Ciclo> lstModeloCiclo = new List<M_Ciclo>();
            try
            {
                if (objCiclos.modCiclosln(objCiclo))
                {
                    IstCiclos = objCiclos.recCiclosln();

                    foreach (var ciclo in IstCiclos)
                    {
                        M_Ciclo objModeloCiclo = new M_Ciclo();

                        objModeloCiclo.id_ciclo = ciclo.id_ciclo;
                        objModeloCiclo.nombre_ciclo = ciclo.nombre_ciclo;
                        objModeloCiclo.descripcion = ciclo.descripcion;

                        lstModeloCiclo.Add(objModeloCiclo);


                    }
                }

            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));


            }
            return View("ListCiclos", lstModeloCiclo);

        }
        public ActionResult EliminarCiclo(Ciclo objCiclo)
        {
            List<SP_recCiclos_Result> IstCiclos = new List<SP_recCiclos_Result>();

            List<M_Ciclo> lstModeloCiclo = new List<M_Ciclo>();
            try
            {
                if (objCiclos.delCiclosln(objCiclo))
                {
                    IstCiclos = objCiclos.recCiclosln();

                    foreach (var ciclo in IstCiclos)
                    {
                        M_Ciclo objModeloCiclo = new M_Ciclo();

                        objModeloCiclo.id_ciclo = ciclo.id_ciclo;
                        objModeloCiclo.nombre_ciclo = ciclo.nombre_ciclo;
                        objModeloCiclo.descripcion = ciclo.descripcion;

                        lstModeloCiclo.Add(objModeloCiclo);


                    }
                }

            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));


            }
            return View("ListCiclos", lstModeloCiclo);

        }

        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Ciclo pCiclo)
        {
            // Verificar si el modelo es válido
            if (!ModelState.IsValid)
            {
                // Si no es válido, regresar a la vista con los errores
                return View("AgregarCiclos", pCiclo);  // Regresamos a la vista AgregarCiclos con los errores
            }

            Ciclo objCiCLO = new Ciclo
            {
                id_ciclo = pCiclo.id_ciclo,
                nombre_ciclo = pCiclo.nombre_ciclo,
                descripcion = pCiclo.descripcion
            };

            switch (submitButton)
            {
                case "Agregar":
                    return IngresarCiclo(objCiCLO);
                case "Actualizar":
                    return ModificarCiclo(objCiCLO);
                case "Eliminar":
                    return EliminarCiclo(objCiCLO);
                default:
                    return RedirectToAction("ListCiclos", "Ciclo");
            }
        }

    }
}