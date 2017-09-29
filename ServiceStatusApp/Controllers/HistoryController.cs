using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ServiceStatusApp.Models;
using AutoMapper;

namespace ServiceStatusApp.Controllers
{
    public class HistoryController : Controller
    {
        private ApplicationDbContext _contex;
        public HistoryController()
        {
            _contex = new ApplicationDbContext();
        }
        // GET: History
        public ActionResult Index()
        {
            var history = _contex.ServiceHistory.Include(h => h.Status).ToList();
            return View(history);

        }
        public ActionResult Restore(int Id)
        {
            var serviceHistory = _contex.ServiceHistory.SingleOrDefault(s => s.Id == Id);
            if(serviceHistory == null)
            {
                return HttpNotFound();
            }
            serviceHistory.StatusId = Status.unready;
            var service = Mapper.Map<ServiceHistory, Service>(serviceHistory);
            _contex.ServiceHistory.Remove(serviceHistory);
            _contex.Service.Add(service);
            _contex.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}