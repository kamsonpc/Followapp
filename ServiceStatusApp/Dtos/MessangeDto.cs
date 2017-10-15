using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStatusApp.Dtos
{
    public class MessangeDto
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }
        public DateTime SendDate { get; set; }
        public bool Client { get; set; }
        public string Text { get; set; }
    }
}