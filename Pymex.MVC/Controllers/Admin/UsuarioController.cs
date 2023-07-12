using Pymex.MVC.Cache;
using Pymex.MVC.Filters;
using Pymex.MVC.Models;
using Pymex.MVC.Models.Mapper;
using Pymex.MVC.Models.Mapper.Contracts;
using Pymex.MVC.UsuarioProxy;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Pymex.MVC.Controllers.Admin
{
    [RoutePrefix("Admin/Usuario")]
    [ValidateSession]
    [ValidateAdministratorUser]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioService _usuarioService = new UsuarioServiceClient();
        private readonly IGenericMapper<UsuarioDC, Usuario> _modelMapper = new UsuarioMapper();

        [Route]
        public ActionResult Index()
        {
            var response = _usuarioService.ObtenerUsuarios(UserLogged.Current.Login);

            if (!response.EsCorrecto)
            {
                return RedirectToAction("Index", "Home");
            }

            if (TempData["SuccessMessage"] != null) // Send message if exists
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            if (TempData["ErrorMessage"] != null) // Send message if exists
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();

            var usuarios = response.Data.Select(u => _modelMapper.ToModel(u));
            return View(usuarios);
        }

        [Route("CambiarPerfil")]
        [HttpPost]
        public ActionResult CambiarPerfil(FormCollection collection)
        {
            dynamic usuarioLogin = collection["login"];
            dynamic perfilId = collection["perfilId"];

            if (usuarioLogin == null || perfilId == null)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al tratar de cambiar el perfil.";
                return RedirectToAction("Index");
            }

            // Avoid change same user
            if((string)usuarioLogin == UserLogged.Current.Login)
            {
                TempData["ErrorMessage"] = "No puede cambiar el rol de su usuario, necesita de otro Administrador.";
                return RedirectToAction("Index");
            } 

            var dataContract = new UsuarioDC
            {
                Login = (string)usuarioLogin,
                Perfil = (UsuarioProxy.Perfil)Convert.ToInt16(perfilId)
            };

            var response = _usuarioService.CambiarPerfilUsuario(dataContract, UserLogged.Current.Login);

            if (!response.EsCorrecto)
            {
                TempData["ErrorMessage"] = response.Mensaje;
                return RedirectToAction("Index");
            }

            TempData["SuccessMessage"] = response.Mensaje;
            return RedirectToAction("Index");
        }
    }
}