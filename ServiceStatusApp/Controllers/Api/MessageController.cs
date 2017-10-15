using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ComponentModel.DataAnnotations;
using ServiceStatusApp.Models;
using ServiceStatusApp.Dtos;
using AutoMapper;


namespace ServiceStatusApp.Controllers.Api
{
    public class MessageController : ApiController
    {
        private ApplicationDbContext _contex;
        public MessageController()
        {
            _contex = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<MessangeDto> GetMessage(int Id)
        {
            return _contex.Messange.Where(m => m.ServiceId == Id).ToList().Select(Mapper.Map<Messange,MessangeDto>);
        }
        [HttpPost]
        public IHttpActionResult CreateMessage(MessangeDto messangeDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var messange = Mapper.Map<MessangeDto, Messange>(messangeDto);
                messange.Client = false;
                messange.SendDate = DateTime.Now;
                _contex.Messange.Add(messange);
                _contex.SaveChanges();
                return Created(new Uri(Request.RequestUri.ToString()),messangeDto);

            }

        }

    }
}
