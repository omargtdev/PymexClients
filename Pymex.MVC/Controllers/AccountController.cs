using Pymex.MVC.Cache;
using Pymex.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return RedirectToAction("Index", "Login");
        }
    }
}