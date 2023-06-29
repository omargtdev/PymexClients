using Pymex.MVC.Filters;
using System.Web.Mvc;

namespace Pymex.MVC.Controllers.Admin
{
    public class UsuarioController : Controller
    {
        [ValidateSession]
        [ValidateAdministratorUser]
        public ActionResult Index()
        {
            return View();
        }
    }
}