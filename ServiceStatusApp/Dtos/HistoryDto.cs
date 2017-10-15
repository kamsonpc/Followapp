using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceStatusApp.Dtos
{
    public class HistoryDto
    {
        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        [Required]
        [MaxLength(150)]
        [MinLength(2)]
        public string Name { get; set; }
   
        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Describe { get; set; }

        [MinLength(8)]
        public string Key { get; set; }

        public int StatusId { get; set; }

        [Required]
        [Display(Name = "Data Dodania")]
        public DateTime AddDate { get; set; }
    }

}