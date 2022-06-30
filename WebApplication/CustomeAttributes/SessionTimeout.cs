using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication.CustomeAttributes
{
    public class SessionTimeout : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {


            if (HttpContext.Current.Session["UserModel"] == null)
            {
                System.Web.Security.FormsAuthentication.SignOut();
                filterContext.Result =
               new RedirectToRouteResult(new RouteValueDictionary
                 {
                     { "action", "Index" },
                     { "controller", "User" },
                     { "returnUrl", filterContext.HttpContext.Request.RawUrl}
                  });

                return;
            }
        }

        //public class SessionTimeoutAttribute : ActionFilterAttribute
        //{
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    HttpContext ctx = HttpContext.Current;
        //    if (HttpContext.Current.Session["UserModel"] == null)
        //    {
        //        filterContext.Result = new RedirectResult("~/User/Index");
        //        return;
        //    }
        //    base.OnActionExecuting(filterContext);
        //}
        //}
    }
}