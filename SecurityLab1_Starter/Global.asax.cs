using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Diagnostics;

namespace SecurityLab1_Starter {
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
            EventLog(exception.Message);

            Debug.WriteLine(exception);
        }

        private void EventLog(string msg) {
            using (EventLog eventLog = new EventLog("Application")) {
                eventLog.Source = "Application";
                eventLog.WriteEntry($"An error has occured --> {msg}", EventLogEntryType.Warning, 101, 1);
            }
        }
    }
}
