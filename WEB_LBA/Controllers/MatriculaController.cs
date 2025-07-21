using LogicaNegocio.Implementacion;
using System;
using System.IO;
using System.Net.Mail;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using WEB_LBA.Models;

namespace WEB_LBA.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly MatriculaLN objMatriculaLN = new MatriculaLN();

        public ActionResult Index()
        {
            return View(new M_MatriculaMEP());
        }

        [HttpPost]
        public ActionResult EnviarMatricula(M_MatriculaMEP m)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Revisá los campos obligatorios.";
                return View("Index", m);
            }

            try
            {
                objMatriculaLN.insMatriculaln(
                    m.nombre_estudiante, m.cedula_estudiante, m.fecha_nacimiento, m.genero, m.nacionalidad_estudiante,
                    m.lugar_nacimiento, m.tipo_agrupamiento, m.modalidad_ingreso, m.escuela_procedencia,
                    m.distrito_donde_vive, m.pueblo_donde_vive, m.telefono_estudiante, m.correo_electronico_estudiante,
                    m.nivel_academico, m.grado_academico, m.modalidad_academica, m.recibe_ayuda_economica,
                    m.tipo_ayuda, m.nombre_madre, m.cedula_madre, m.nacionalidad_madre, m.telefono_madre,
                    m.escolaridad_madre, m.direccion_madre, m.nombre_padre, m.cedula_padre, m.nacionalidad_padre,
                    m.telefono_padre, m.escolaridad_padre, m.direccion_padre, m.permiso_educacion_religiosa,
                    m.permiso_salidas_libres, m.permiso_imagenes, m.permiso_autoriza_otro_retirar,
                    m.comentario_adicional, m.firma_padre_madre, m.cedula_firma, m.nombre_funcionario, m.fecha_firma ?? DateTime.Now
                );

                var pdf = GenerarPDF(m);
                EnviarCorreoConPDF(pdf, m.correo_electronico_estudiante);

                TempData["PDF"] = pdf;
                return RedirectToAction("Confirmacion");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al procesar matrícula: " + ex.Message;
                return View("Index", m);
            }
        }

        public ActionResult Confirmacion()
        {
            return View();
        }

        public FileResult DescargarPDF()
        {
            byte[] pdf = TempData["PDF"] as byte[];
            return File(pdf, "application/pdf", "Matricula_LBA.pdf");
        }

        private byte[] GenerarPDF(M_MatriculaMEP m)
        {
            using (var ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                PdfWriter.GetInstance(doc, ms);
                doc.Open();

                doc.Add(new Paragraph("Formulario de Matrícula - LBA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)));
                doc.Add(new Paragraph("Fecha: " + DateTime.Now.ToShortDateString()));
                doc.Add(new Paragraph(" "));

                doc.Add(new Paragraph($"Estudiante: {m.nombre_estudiante} / Cédula: {m.cedula_estudiante}"));
                doc.Add(new Paragraph($"Grado: {m.grado_academico} / Modalidad: {m.modalidad_academica}"));
                doc.Add(new Paragraph($"Correo: {m.correo_electronico_estudiante} / Teléfono: {m.telefono_estudiante}"));
                doc.Add(new Paragraph(" "));

                doc.Add(new Paragraph($"Madre: {m.nombre_madre} / Tel: {m.telefono_madre}"));
                doc.Add(new Paragraph($"Padre: {m.nombre_padre} / Tel: {m.telefono_padre}"));
                doc.Add(new Paragraph(" "));

                doc.Add(new Paragraph("Comentario adicional:"));
                doc.Add(new Paragraph(m.comentario_adicional ?? ""));
                doc.Add(new Paragraph(" "));

                doc.Add(new Paragraph($"Firma del responsable: {m.firma_padre_madre}"));
                doc.Add(new Paragraph($"Funcionario que recibe: {m.nombre_funcionario}"));
                doc.Add(new Paragraph($"Fecha firma: {(m.fecha_firma.HasValue ? m.fecha_firma.Value.ToShortDateString() : "No registrada")}"));

                doc.Close();
                return ms.ToArray();
            }
        }

        private void EnviarCorreoConPDF(byte[] pdf, string correo)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("lbamatriculaonline@gmail.com");
            msg.To.Add("lbamatriculaonline2003@gmail.com");

            if (!string.IsNullOrWhiteSpace(correo) && correo.Contains("@"))
            {
                try
                {
                    msg.CC.Add(correo.Trim());
                }
                catch (Exception ex)
                {
                    // Error en agregar copia oculta, puede ignorarse
                }
            }

            msg.Subject = "Matrícula LBA enviada";
            msg.Body = "Adjunto encontrará el formulario de matrícula.";
            msg.Attachments.Add(new Attachment(new MemoryStream(pdf), "matricula.pdf"));

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("lbamatriculaonline@gmail.com", "oapgemuhwungrkxf");
            smtp.EnableSsl = true;
            smtp.Send(msg);
        }
    }
}