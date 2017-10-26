using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ServiceStatusApp.Models;
using ServiceStatusApp.ViewModels;

namespace ServiceStatusApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext _contex;
        public HomeController()
        {
            _contex = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Check()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Check(ServiceCheckViewModel check)
        {
            
            var service = _contex.Service.Include(m => m.Status).SingleOrDefault(s => s.Key == check.Key);
            if(service != null)
            {
                var statuslist = _contex.StatusHistory.Include(m => m.Status).Where(ss => ss.ServiceId == service.Id).OrderBy(ss => ss.ChangeDate).ToList();
                var statushistoryobj = new StatusHistoryServiceViewModel
                {
                    Service = service,
                    StatusHistoryList = statuslist
                };
                return View("CheckResult",statushistoryobj);
            }
            ModelState.Clear();
            ViewBag.Message = "Nie znaleziono usługi o podanym kluczu";
            return View("Check");

            
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}