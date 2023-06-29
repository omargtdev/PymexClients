using Pymex.MVC.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pymex.MVC.Filters
{
    public class ValidateAdministratorUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!UserLogged.Current.IsAdmin)
            {
                filterContext.Result = new RedirectResult("~/Home");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}