using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceStatusApp.Models
{
    public class Messange
    {
        public int Id { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        public DateTime SendDate { get; set; }
        public bool Client { get; set; }
        public string Text { get; set; }
    }
}