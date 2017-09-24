using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStatusApp.Models;
namespace ServiceStatusApp.Controllers
{
    public class ServicesController : Controller
    {
        private ApplicationDbContext _contex;
        public ServicesController()
        {
            _contex = new ApplicationDbContext();
        }
        // GET: Employee
        public ActionResult Index()
        {
            var Services = _contex.Service.ToList();
            return View(Services);
        }
        public ActionResult Create()
        {
            return View("ServiceForm");
        }
        // GET: Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Service service)
        {
            
            var key = new Key();

            service.Key = key.GenerateKey();
            service.AddDate = DateTime.Now;
            service.Status = false;
            if(!ModelState.IsValid)
            {
              
                return View("ServiceForm", service);
            }
            _contex.Service.Add(service);
            _contex.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var Service = _contex.Service.SingleOrDefault(t => t.Id == Id);
            if(Service == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                _contex.Service.Remove(Service);
                _contex.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}