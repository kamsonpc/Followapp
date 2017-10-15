using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceStatusApp.Models;
using ServiceStatusApp.Dtos;
using Microsoft.AspNet.Identity;
using AutoMapper;

namespace ServiceStatusApp.Controllers.Api
{
    public class HistoryController : ApiController
    {
        private ApplicationDbContext _contex;
        public HistoryController()
        {
            _contex = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<HistoryDto> Index()
        {
            return _contex.ServiceHistory.ToList().Select(Mapper.Map<ServiceHistory, HistoryDto>);
        }
        [HttpGet]
        public void Restore(int Id)
        {
            var serviceHistory = _contex.ServiceHistory.SingleOrDefault(s => s.Id == Id);
            if (serviceHistory == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            serviceHistory.ApplicationUserId = User.Identity.GetUserId();
            serviceHistory.StatusId = Status.unready;
            var service = Mapper.Map<ServiceHistory, Service>(serviceHistory);
            _contex.ServiceHistory.Remove(serviceHistory);
            _contex.Service.Add(service);
            _contex.SaveChanges();

        }
        
    }
}
