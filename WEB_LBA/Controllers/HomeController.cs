using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace TuProyecto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Noticias()
        {
            return RedirectToAction("ListNoticias", "Noticia");
        }
        public ActionResult PanelAdministrativo()
        {
            if (Session["rol"] == null || Session["rol"].ToString() != "Administrativo")
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(string nombre, string correo, string mensaje)
        {
            try
            {
                var fromAddress = new MailAddress("lbamatriculaonline@gmail.com", "LBA Contacto");
                var toAddress = new MailAddress("lbamatriculaonline@gmail.com"); // o puedes poner otro
                const string fromPassword = "oapgemuhwungrkxf";
                string subject = "Mensaje de contacto desde la web";
                string body = $"Nombre: {nombre}\nCorreo: {correo}\nMensaje:\n{mensaje}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                ViewBag.Mensaje = "✅ ¡Mensaje enviado correctamente!";
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "❌ Error al enviar el mensaje. Intente más tarde.";
                // Opcional: log del error si quieres: ViewBag.Error = ex.Message;
            }

            return View();
        }
    }
}