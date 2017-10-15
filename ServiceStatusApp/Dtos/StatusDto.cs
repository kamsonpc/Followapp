using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceStatusApp.Dtos
{
    public class StatusDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public static readonly int unready = 1;
        public static readonly int ready = 2;
    }
}