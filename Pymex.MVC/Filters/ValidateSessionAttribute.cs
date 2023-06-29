using Pymex.MVC.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pymex.MVC.Filters
{
    public class ValidateSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Si el usuario en la sesion es nulo, entonces anda al login
            if (UserLogged.Current == null)
            {
                filterContext.Result = new RedirectResult("~/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}