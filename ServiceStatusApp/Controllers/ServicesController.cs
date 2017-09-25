using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStatusApp.Models;
using System.Data.Entity;

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
        [AllowAnonymous]
        public ActionResult Index()
        {
            var Services = _contex.Service.Include(m => m.Status).ToList();
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
            service.StatusId = 1;
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

        public ActionResult Complete(int Id)
        {
            var Service = _contex.Service.SingleOrDefault(t => t.Id == Id);
            if (Service == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                 Service.StatusId = 2;
                _contex.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}