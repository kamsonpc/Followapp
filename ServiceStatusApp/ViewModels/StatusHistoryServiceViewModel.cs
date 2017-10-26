using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStatusApp.Models;

namespace ServiceStatusApp.ViewModels
{
    public class StatusHistoryServiceViewModel
    {
        public List<StatusHistory> StatusHistoryList { get; set; }
        public Service Service { get; set; }
    }
}