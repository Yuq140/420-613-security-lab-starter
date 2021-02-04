using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers {
    public class InventoryController : Controller {
        // GET: Inventory
        public ActionResult Index() {
            return View();
        }

        protected override void OnException(ExceptionContext filterContext) {
            filterContext.ExceptionHandled = true;

            // Log the error
            using (StreamWriter sw = System.IO.File.AppendText("log.txt")) {
                Log(filterContext.Exception.Message, sw);
            }

            using (StreamReader sr = System.IO.File.OpenText("log.txt")) {
                DumpLog(sr);
            }

            // Redirect or return a view, but not both.
            filterContext.Result = RedirectToAction("Error", "Index");
        }

        private void Log(string logMessage, TextWriter tw) {
            tw.WriteLine("\r\nLog Entry: ");
            tw.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            tw.WriteLine("  :");
            tw.WriteLine($"  :{logMessage}");
            tw.WriteLine("----------------------------------");
        }

        private void DumpLog(StreamReader sr) {
            string line;
            while ((line = sr.ReadLine()) != null) {
                Console.WriteLine(line);
            }
        }
    }
}