using Pymex.MVC.Filters;
using System.Web.Mvc;

namespace Pymex.MVC.Controllers.Admin
{
    [RoutePrefix("Admin/Sistema")]
    [ValidateSession]
    [ValidateAdministratorUser]
    public class SistemaController : Controller
    {
        [Route]
        public ActionResult Index()
        {
            return View();
        }
    }
}