using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracker.Models
{
    public class Tracker
    {
        public int Id { get; set; }
        public Project ProjectType { get; set; }

        [Display(Name = "Project Type")]
        public int? ProjectTypeId { get; set; }
        public byte Count { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedOn { get; set; }
    }
}
