using Pymex.MVC.Cache;
using Pymex.MVC.Filters;
using System.Web.Mvc;

namespace Pymex.MVC.Controllers
{
    [ValidateSession]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            UserLogged.Current = null;
            TempData["SuccessLogoutMessage"] = "Se cerró la sesión!";
            return RedirectToAction("Index", "Login");
        }
    }
}