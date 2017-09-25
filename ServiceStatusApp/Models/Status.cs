using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceStatusApp.Models
{
    public class Status
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        [Required]
        public string Name { get; set; }
    }
}