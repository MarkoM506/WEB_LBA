using System;
using System.Web.Mvc;
using LogicaNegocio;
using WEB_LBA.Models;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WEB_LBA.Controllers
{
    public class MatriculaController : Controller
    {
        private MatriculaLN matriculaLN = new MatriculaLN();

        public ActionResult Index()
        {
            return View(new M_MatriculaMEP());
        }

        [HttpPost]
        public ActionResult Index(M_MatriculaMEP model, string accion)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string nombreArchivo = $"Matricula_{model.nombre_estudiante.Replace(" ", "")}{DateTime.Now.Ticks}.pdf";
            string rutaCompleta = Server.MapPath($"~/Content/PDFs/{nombreArchivo}");

            // Crear PDF
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(rutaCompleta, FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph("Matrícula - Liceo Boca de Arenal"));
            doc.Add(new Paragraph($"Estudiante: {model.nombre_estudiante}"));
            doc.Add(new Paragraph($"Cédula: {model.cedula_estudiante}"));
            doc.Add(new Paragraph($"Escuela: {model.escuela_procedencia}"));
            doc.Add(new Paragraph($"Nacimiento: {model.fecha_nacimiento.ToShortDateString()}"));
            doc.Add(new Paragraph($"Teléfono Estudiante: {model.telefono_estudiante}"));
            doc.Add(new Paragraph($"Nivel: {model.nivel}"));
            doc.Add(new Paragraph($"Encargado: {model.nombre_padre}"));
            doc.Add(new Paragraph($"Cédula Encargado: {model.cedula_padre}"));
            doc.Add(new Paragraph($"Teléfono Encargado: {model.telefono_padre}"));
            doc.Add(new Paragraph($"Dirección: {model.direccion_padre}"));
            doc.Add(new Paragraph($"Parentesco: {model.parentesco}"));
            doc.Add(new Paragraph($"Fecha de Cita: {model.fecha_cita.ToShortDateString()}"));
            doc.Add(new Paragraph($"Hora de Cita: {model.hora_cita}"));
            doc.Close();

            // Guardar en BD
            matriculaLN.insertarMatriculaLN(
                model.nombre_estudiante,
                model.cedula_estudiante,
                model.escuela_procedencia,
                model.fecha_nacimiento,
                model.telefono_estudiante,
                model.nivel,
                model.nombre_padre,
                model.cedula_padre,
                model.telefono_padre,
                model.direccion_padre,
                model.parentesco,
                model.fecha_cita,
                model.hora_cita
            );

            // WhatsApp
            if (accion == "EnviarWhatsapp")
            {
                string mensaje = $"Buenos días, estimada organización del Liceo Boca de Arenal. Esta es la matrícula de mi hijo: {model.nombre_estudiante}, {model.cedula_estudiante}. Por favor recuerde adjuntar el PDF anteriormente descargado." +
                    $"En caso de no ser adjuntado el PDF el proceso de Matricula no será tomado";
                string url = $"https://wa.me/50684800101?text={Uri.EscapeDataString(mensaje)}";
                return Redirect(url);
            }

            // Descargar PDF directamente si fue botón de Generar PDF
            return File(System.IO.File.ReadAllBytes(rutaCompleta), "application/pdf", nombreArchivo);
        }
    }
}