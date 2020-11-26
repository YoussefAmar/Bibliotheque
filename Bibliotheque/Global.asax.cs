using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bibliotheque
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);


        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception lastErrorInfo = Server.GetLastError();

            bool isNotFound = false;
            if (lastErrorInfo != null)
            {
                var errorInfo = lastErrorInfo.GetBaseException();
                if (errorInfo is HttpException error)
                    isNotFound = error.GetHttpCode() == (int)HttpStatusCode.NotFound;
            }
            if (isNotFound)
            {
                Server.ClearError();
                Response.Redirect("~/Home/Error");// Do what you need to render in view
            }
        }

    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NoDirectAccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.UrlReferrer == null ||
                filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Home", action = "Error", area = "" }));
            }
        }
    }
}
