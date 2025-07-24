using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_LBA.Models;
using Entidades;
using LogicaNegocio;

namespace WEB_LBA.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioLN usuarioLN = new UsuarioLN();

        // GET: Usuario/ListUsuarios
        public ActionResult ListUsuarios()
        {
            var usuarios = usuarioLN.recUsuariosLN();
            return View(usuarios);
        }

        // GET: Usuario/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Crear(M_Usuario model)
        {
            if (ModelState.IsValid)
            {
                usuarioLN.insUsuarioLN(model.usuario, model.contrasena, model.rol, model.id_estudiante, model.id_profesor);
                return RedirectToAction("ListUsuarios");
            }
            return View(model);
        }

        // GET: Usuario/Editar/5
        public ActionResult Editar(int id)
        {
            var usuario = usuarioLN.recUsuarioPorIdLN(id);
            if (usuario == null)
                return HttpNotFound();

            M_Usuario model = new M_Usuario
            {
                id_usuario = usuario.id_usuario,
                usuario = usuario.usuario,
                contrasena = usuario.contrasena,
                rol = usuario.rol,
                activo = usuario.activo ?? false
            };
            return View(model);
        }

        // POST: Usuario/Editar/5
        [HttpPost]
        public ActionResult Editar(M_Usuario model)
        {
            if (ModelState.IsValid)
            {
                usuarioLN.modUsuarioLN(model.id_usuario, model.usuario, model.contrasena, model.rol, model.activo);
                return RedirectToAction("ListUsuarios");
            }
            return View(model);
        }

        // GET: Usuario/Eliminar/5
        public ActionResult Eliminar(int id)
        {
            var usuario = usuarioLN.recUsuarioPorIdLN(id);
            if (usuario == null)
                return HttpNotFound();
            return View(usuario);
        }

        // POST: Usuario/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            usuarioLN.delUsuarioLN(id);
            return RedirectToAction("ListUsuarios");
        }

        // ====================
        // ==== LOGIN AREA ====
        // ====================

        // GET: Usuario/LoginAdministrativo
        public ActionResult LoginAdministrativo()
        {
            return View();
        }

        // POST: Usuario/LoginAdministrativo
        [HttpPost]
        public ActionResult LoginAdministrativo(string usuario, string contrasena)
        {
            var result = usuarioLN.loginUsuarioLN(usuario, contrasena);
            if (result != null && result.rol.ToLower() == "administrativo")
            {
                Session["usuario"] = result.usuario;
                Session["rol"] = result.rol;
                return RedirectToAction("PanelAdministrativo", "Home");
            }
            ViewBag.Mensaje = "Credenciales inválidas o sin permisos.";
            return View();
        }

        // GET: Usuario/LoginEstudiante
        public ActionResult LoginEstudiante()
        {
            return View();
        }

        // POST: Usuario/LoginEstudiante
        [HttpPost]
        public ActionResult LoginEstudiante(string usuario, string contrasena)
        {
            var result = usuarioLN.loginUsuarioLN(usuario, contrasena);
            if (result != null && result.rol == "estudiante")
            {
                Session["usuario"] = result.usuario;
                Session["rol"] = result.rol;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Mensaje = "Credenciales inválidas o sin permisos.";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}