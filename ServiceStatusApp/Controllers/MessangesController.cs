using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceStatusApp.Controllers
{
    public class MessangesController : Controller
    {
        // GET: Messanges
        public ActionResult Chat()
        {
            return View();
        }
    }
}