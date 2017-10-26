using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStatusApp.Models
{
    public class StatusHistory
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public DateTime ChangeDate { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }

    }
}