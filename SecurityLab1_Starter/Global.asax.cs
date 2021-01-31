using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Diagnostics;
using NLog;

namespace SecurityLab1_Starter
{
    public class MvcApplication : System.Web.HttpApplication {

        //private static readonly Logger _Logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e) {
            Exception exception = Server.GetLastError();

            // Log the error            
            //_Logger.Error("Yeet" + exception);

            Debug.WriteLine(exception);


            //if (exception is HttpException httpException) {
            //    string action;

            //    switch (httpException.GetHttpCode()) {
            //        case 404:
            //            // page not found
            //            action = "NotFound";
            //            break;
            //        case 500:
            //            // server error
            //            action = "ServerError";
            //            break;
            //        default:
            //            action = "Index";
            //            break;
            //    }

            //    // clear error on server
            //    Server.ClearError();

            //    Response.Redirect($"~/Error/{action}?aspxerrorpath={HttpContext.Current.Request.Url}");
            //}
            //Response.Redirect("/Error");
    }
    }
}
