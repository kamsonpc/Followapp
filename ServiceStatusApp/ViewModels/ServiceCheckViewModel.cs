using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceStatusApp.ViewModels
{
    public class ServiceCheckViewModel
    {
        [Display(Name = "Klucz")]
        [MinLength(8)]
        [Required]
        public string Key { get; set; }
    }
}