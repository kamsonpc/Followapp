using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStatusApp.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using ServiceStatusApp.ViewModels;
using AutoMapper;

namespace ServiceStatusApp.Controllers
{
    public class ServicesController : Controller
    {
        private ApplicationDbContext _contex;
        private string userId;
        public ServicesController()
        {
             userId = User.Identity.GetUserId();
            _contex = new ApplicationDbContext();
        }
        // GET: Employee
        [AllowAnonymous]
        public ActionResult Index()
        {
           
            var Services = _contex.Service.Include(m => m.Status).Where(m => m.ApplicationUserId == userId).ToList();
            return View(Services);
        }
        public ActionResult Create()
        {
            var service = new Service();
            return View("ServiceForm",service);
        }
        public ActionResult Edit(int Id)
        {
            var viewmodel = new ServiceStatusViewModel
            {
                Service = _contex.Service.SingleOrDefault(s => s.Id == Id),
                Status = _contex.Status.ToList()

            };
            return View("ServiceFormEdit",viewmodel);
        }
        // GET: Employee
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(Service service)
        {
            if(service.Id!=0)
            {
                if (!ModelState.IsValid)
                {
                    var viewmodel = new ServiceStatusViewModel
                    {
                        Service = service,
                        Status = _contex.Status.ToList()

                    };
                    return View("ServiceFormEdit", viewmodel);
                }
                var serviceInDb = _contex.Service.Where(m => m.ApplicationUserId == userId).SingleOrDefault(s => s.Id == service.Id);
                if(serviceInDb==null)
                {
                    return HttpNotFound();
                }
                else
                {
                    service.AddDate = serviceInDb.AddDate;
                    service.Key = serviceInDb.Key;
                    service.ApplicationUserId = serviceInDb.ApplicationUserId;
                    Mapper.Map(service, serviceInDb);
                    _contex.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            else
            {
                var key = new Key();
                service.Key = key.GenerateKey();
                service.AddDate = DateTime.Now;
                service.ApplicationUserId = User.Identity.GetUserId();
                service.StatusId = Status.unready;
                if (!ModelState.IsValid)
                {

                    return View("ServiceForm", service);
                }
                _contex.Service.Add(service);
                _contex.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {

            var Service = _contex.Service.Where(m => m.ApplicationUserId == userId).SingleOrDefault(t => t.Id == Id);
            if(Service == null)
            {
                return HttpNotFound();
            }
            else
            {
                _contex.Service.Remove(Service);
                _contex.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        public ActionResult ChangeKey(int Id)
        {

            var Service = _contex.Service.Where(m => m.ApplicationUserId == userId).SingleOrDefault(t => t.Id == Id);
            if (Service == null)
            {
                return HttpNotFound();
            }
            else
            {
                Key key = new Key();
                Service.Key = key.GenerateKey();
                _contex.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Complete(int Id)
        {

            var service = _contex.Service.Where(m => m.ApplicationUserId == userId).SingleOrDefault(t => t.Id == Id);
            if (service == null)
            {
                return HttpNotFound();
            }
            else
            {
                 service.StatusId = Status.ready;
                 var serviceHistory = Mapper.Map<Service, ServiceHistory>(service);
                 serviceHistory.CompleteDate = DateTime.Now;

                _contex.Service.Remove(service);
                _contex.ServiceHistory.Add(serviceHistory);
                _contex.SaveChanges();
                return RedirectToAction("Index");
            }
        }



    }
}