using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ServiceStatusApp.Models;
using ServiceStatusApp.Dtos;

namespace ServiceStatusApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Service, ServiceHistory>().ForMember(c => c.Id,opt => opt.Ignore());
            Mapper.CreateMap<ServiceHistory, Service>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Status, StatusDto>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Service, Service>().ForMember(c =>  c.Id  , opt => opt.Ignore());

            Mapper.CreateMap<ServiceHistory, HistoryDto>();
            Mapper.CreateMap<HistoryDto,ServiceHistory>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Messange, MessangeDto>();
            Mapper.CreateMap<MessangeDto, Messange>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Service, ServiceDto>();
            Mapper.CreateMap<ServiceDto, Service>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}