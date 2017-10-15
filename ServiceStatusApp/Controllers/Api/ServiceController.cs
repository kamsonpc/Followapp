using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ServiceStatusApp.Models;
using ServiceStatusApp.Dtos;
using System.Data.Entity;
using AutoMapper;


namespace ServiceStatusApp.Controllers.Api
{
    [RoutePrefix("api/service")]
    public class ServiceController : ApiController
    {
        private ApplicationDbContext _contex;
        public ServiceController()
        {
            _contex = new ApplicationDbContext();
        }
        [Route("")]
        //GET /api/service
        public IEnumerable<ServiceDto> GetService()
        {
            var userId = User.Identity.GetUserId();
            return _contex.Service.Include(m => m.Status).Where(m => m.ApplicationUserId == userId).OrderBy(m=> m.Priority).ToList().Select(Mapper.Map<Service,ServiceDto>);

        }
        [HttpDelete]
        [Route("{id:int}/completed")]
        public void Complete(int Id)
        {
            var userId = User.Identity.GetUserId();
            var service = _contex.Service.Where(m => m.ApplicationUserId == userId).SingleOrDefault(t => t.Id == Id);
            if (service == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                service.ApplicationUserId = User.Identity.GetUserId();
                service.StatusId = Status.ready;
                var serviceHistory = Mapper.Map<Service, ServiceHistory>(service);
                serviceHistory.CompleteDate = DateTime.Now;

                _contex.Service.Remove(service);
                _contex.ServiceHistory.Add(serviceHistory);
                _contex.SaveChanges();
     
            }
        }
        [HttpPut]
        [Route("{id:int}/changekey")]
        public IHttpActionResult ChangeKey(int Id)
        {
            var userId = User.Identity.GetUserId();
            var Service = _contex.Service.Where(m => m.ApplicationUserId == userId).SingleOrDefault(t => t.Id == Id);
            if (Service == null)
            {
                return NotFound();
            }
            else
            {
                Key key = new Key();
                Service.Key = key.GenerateKey();
                _contex.SaveChanges();
                return Ok();
            }   
        }

        [HttpDelete]
        [Route("{id:int}/remove")]
        public IHttpActionResult Delete(int Id)
        {
            var userId = User.Identity.GetUserId();
            var Service = _contex.Service.Where(m => m.ApplicationUserId == userId).SingleOrDefault(t => t.Id == Id);
            if (Service == null)
            {
                return NotFound();
            }
            else
            {
                _contex.Service.Remove(Service);
                _contex.SaveChanges();
                return Ok();
            }
        }
        [HttpGet]
        [Route("{id:int}/editform")]
        public ServiceDto EditForm(int Id)
        {
            var userId = User.Identity.GetUserId();
            var Service = _contex.Service.Include(m => m.Status).Where(m => m.ApplicationUserId == userId).SingleOrDefault(t => t.Id == Id);
            if (Service == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Service,ServiceDto>(Service);
        }
        //public ActionResult Edit(int Id)
        //{
        //    var viewmodel = new ServiceStatusViewModel
        //    {
        //        Service = _contex.Service.SingleOrDefault(s => s.Id == Id),
        //        Status = _contex.Status.ToList()

        //    };
        //    return View("ServiceFormEdit", viewmodel);
        //}

        //[HttpPost]
        //public IHttpActionResult CreateService(ServiceDto serviceDto)
        //{
        //    if(!ModelState.IsValid)
        //    return BadRequest();

        //    var service = new Service();
        //    service = Mapper.Map<ServiceDto,Service>(serviceDto);
        //    var key = new Key();
        //    service.Key = key.GenerateKey();
        //    service.AddDate = DateTime.Now;
        //    service.ApplicationUserId = User.Identity.GetUserId();
        //    service.StatusId = Status.unready;

        //    _contex.Service.Add(service);
        //    _contex.SaveChanges();

        //    return Created(new Uri(Request.RequestUri + "/" + serviceDto.Id.ToString()),serviceDto);

        //}
    }

}

