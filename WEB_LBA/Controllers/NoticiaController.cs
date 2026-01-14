using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Entidades;
using WEB_LBA.Models;
using System.Web;
using System.IO;

namespace WEB_LBA.Controllers
{
    public class NoticiaController : Controller
    {
        private INoticiaLN objNoticiaLN = new NoticiaLN();

        // VISTA: Lista de Noticias
        public ActionResult ListNoticias()
        {
            List<SP_recNoticias_Result> lstNoticias = objNoticiaLN.recNoticiasLN();
            List<M_Noticia> lstModeloNoticias = new List<M_Noticia>();

            foreach (var noticia in lstNoticias)
            {
                M_Noticia model = new M_Noticia
                {
                    id_noticia = noticia.id_noticia,
                    titulo = noticia.titulo,
                    contenido = noticia.contenido,
                    fecha_publicacion = noticia.fecha_publicacion,
                    imagen_url = noticia.imagen_url
                };

                lstModeloNoticias.Add(model);
            }

            var mensaje = TempData["Mensaje"] as string;
            ViewBag.Mensaje = mensaje;

            return View(lstModeloNoticias);
        }

        // VISTA: Agregar Noticia
        public ActionResult AgregarNoticias()
        {
            var model = new M_Noticia
            {
                fecha_publicacion = DateTime.Now // Asigna la fecha actual
            };
            return View(model);
        }

        // VISTA: Modificar Noticia
        public ActionResult ModificaNoticia(int id)
        {
            var noticia = objNoticiaLN.recNoticiaPorIdLN(id);
            M_Noticia model = new M_Noticia
            {
                id_noticia = noticia.id_noticia,
                titulo = noticia.titulo,
                contenido = noticia.contenido,
                fecha_publicacion = noticia.fecha_publicacion,
                imagen_url = noticia.imagen_url
            };

            return View(model);
        }

        // VISTA: Panel de Noticias
        public ActionResult PanelNoticias()
        {
            var noticias = objNoticiaLN.recNoticiasLN();
            return View(noticias);
        }

        // VISTA: Eliminar Noticia
        public ActionResult EliminaNoticia(int id)
        {
            var noticia = objNoticiaLN.recNoticiaPorIdLN(id);
            M_Noticia model = new M_Noticia
            {
                id_noticia = noticia.id_noticia,
                titulo = noticia.titulo,
                contenido = noticia.contenido,
                fecha_publicacion = noticia.fecha_publicacion,
                imagen_url = noticia.imagen_url
            };

            return View(model);
        }

        // MÉTODOS: Insertar
        public ActionResult IngresarNoticia(Noticia noticia)
        {
            try
            {
                if (objNoticiaLN.insNoticiaLN(noticia))
                {
                    TempData["Mensaje"] = "Noticia subida exitosamente. Ya puedes verla en el apartado de noticias.";
                    return RedirectToAction("PanelNoticias");  // Redirige al panel de noticias después de la operación
                }
                return View("Error");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Noticia", "IngresarNoticia"));
            }
        }

        // MÉTODOS: Modificar
        public ActionResult ModificarNoticia(Noticia noticia)
        {
            try
            {
                if (objNoticiaLN.modNoticiaLN(noticia))
                {
                    TempData["Mensaje"] = "Noticia actualizada exitosamente. Ya puedes verla en el apartado de noticias.";
                    return RedirectToAction("PanelNoticias");  // Redirige al panel de noticias después de la operación
                }
                return View("Error");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Noticia", "ModificarNoticia"));
            }
        }

        // MÉTODOS: Eliminar
        public ActionResult EliminarNoticia(Noticia noticia)
        {
            try
            {
                if (objNoticiaLN.delNoticiaLN(noticia))
                {
                    TempData["Mensaje"] = "Noticia eliminada exitosamente.";
                    return RedirectToAction("PanelNoticias");  // Redirige al panel de noticias después de la operación
                }
                return View("Error");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Noticia", "EliminarNoticia"));
            }
        }

        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Noticia model, HttpPostedFileBase imagen)
        {
            try
            {
                Noticia noticia = new Noticia
                {
                    id_noticia = model.id_noticia,
                    titulo = model.titulo,
                    contenido = model.contenido,
                    fecha_publicacion = model.fecha_publicacion,
                    imagen_url = model.imagen_url // mantener la anterior si no se cambia
                };

                if (imagen != null && imagen.ContentLength > 0)
                {
                    string nombreArchivo = Path.GetFileName(imagen.FileName);
                    string rutaFisica = Path.Combine(Server.MapPath("~/Content/ImagenesNoticias/"), nombreArchivo);
                    imagen.SaveAs(rutaFisica);
                    noticia.imagen_url = "/Content/ImagenesNoticias/" + nombreArchivo;
                }

                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarNoticia(noticia);

                    case "Actualizar":
                        return ModificarNoticia(noticia);

                    case "Eliminar":
                        return EliminarNoticia(noticia);

                    default:
                        return RedirectToAction("PanelNoticias");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Noticia", "Acciones"));
            }
        }
    }
}
