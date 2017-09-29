using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceStatusApp.Models;
using ServiceStatusApp.Dtos;
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


    }
}
