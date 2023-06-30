using Pymex.MVC.Models;
using System.Web;

namespace Pymex.MVC.Cache
{
    public static class UserLogged
    {
        public static Usuario Current
        {
            get
            {
                var currentUserSession = HttpContext.Current.Session["user"];
                if (currentUserSession == null)
                    return null;

                return (Usuario)currentUserSession;
            }
            
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
        }

    }
}