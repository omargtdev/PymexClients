using Pymex.MVC.Cache;
using Pymex.MVC.Models;
using Pymex.MVC.Models.Mapper;
using Pymex.MVC.Models.Mapper.Contracts;
using Pymex.MVC.UsuarioProxy;
using System.Web.Mvc;

namespace Pymex.MVC.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioService _usuarioService;
        private readonly IGenericMapper<UsuarioDC, Usuario> _modelMapper;

        public LoginController()
        {
            _usuarioService = new UsuarioServiceClient();
            _modelMapper = new UsuarioMapper();
        }

        public ActionResult Index()
        {
            // Si ya existe el usuario en la sesion, vuelve al inicio
            if (UserLogged.Current != null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (TempData["SuccessLogoutMessage"] != null)
                ViewBag.SuccessLogoutMessage = TempData["SuccessLogoutMessage"].ToString();

            return View();
        }

        [HttpPost]
        public ActionResult Authenticate(LoginAccount model)
        {
            // Validando el modelo
            if(!ModelState.IsValid)
            {
                // Devolviendo el mismo modelo con las validaciones respectivas
                return View("Index");
            }

            // Consultando al servicio
            var response = _usuarioService.Login(model.Username, model.Password);
            if(!response.EsCorrecto)
            {
                ViewBag.LoginErrorMessage = response.Mensaje;
                return View("Index");
            }

            UsuarioDC usuario = response.Data;
            UserLogged.Current = _modelMapper.ToModel(usuario);
            return RedirectToAction("Index", "Home");
        }
    }
}