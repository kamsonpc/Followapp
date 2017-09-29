using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceStatusApp.Models
{
    public class ServiceHistory
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Nazwa Zadania")]
        [Required]
        [MaxLength(150)]
        [MinLength(2)]
        public string Name { get; set; }


        [Display(Name = "Opis")]
        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Describe { get; set; }



        [Display(Name = "Klucz")]
        [MinLength(8)]
        public string Key { get; set; }


        public Status Status { get; set; }
        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [Required]
        [Display(Name = "Data Dodania")]
        public DateTime AddDate { get; set; }

        [Display(Name = "Data Ukończenia")]
        public DateTime? CompleteDate { get; set; }


    }
}
