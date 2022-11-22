using ProjectTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Tracing;

namespace ProjectTracker.ViewModels
{
    public class TrackerFormViewModel
    {
        public TrackerFormViewModel()
        {
            this.Id = 0;
        }

        public TrackerFormViewModel(Tracker tracker)
        {
            this.Id = tracker.Id;
            this.ProjectTypeId = tracker.ProjectTypeId;
            this.Count = tracker.Count;
        }

        
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project Types")]
        public int? ProjectTypeId { get; set; }

        [DisplayName("Count")]
        public byte Count { get; set; }

        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }

        public IEnumerable<Project> Projects { get; set; }

        public int Rate { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "New" : "Edit";
            }
        }

    }
}
