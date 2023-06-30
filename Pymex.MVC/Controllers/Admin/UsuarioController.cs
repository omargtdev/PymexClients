using Pymex.MVC.Filters;
using System.Web.Mvc;

namespace Pymex.MVC.Controllers.Admin
{
    [RoutePrefix("Admin/Usuario")]
    [ValidateSession]
    [ValidateAdministratorUser]
    public class UsuarioController : Controller
    {
        [Route]
        public ActionResult Index()
        {
            return View();
        }
    }
}