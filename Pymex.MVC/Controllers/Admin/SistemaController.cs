using Pymex.MVC.Filters;
using System.Web.Mvc;

namespace Pymex.MVC.Controllers.Admin
{
    [ValidateSession]
    [ValidateAdministratorUser]
    public class SistemaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}