using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStatusApp.Models;

namespace ServiceStatusApp.ViewModels
{
    public class ServiceStatusViewModel
    {
        public Service Service { get; set; }
        public IEnumerable<Status> Status { get; set; }
    }
}