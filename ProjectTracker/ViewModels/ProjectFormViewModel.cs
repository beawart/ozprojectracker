using ProjectTracker.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.ViewModels
{
    public class ProjectFormViewModel
    {
        public ProjectFormViewModel()
        {
            this.Id = 0;
        }

        public ProjectFormViewModel(Project project)
        {
            this.Id = project.Id;
            this.name = project.Name;
            this.description = project.Description;
            this.rate = project.TaskRate;
        }

        public int Id { get; set; }
        
        [Required]
        [DisplayName("Name")]
        [StringLength(150)]
        public string name { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(255)]
        public string description { get; set; }

        [DisplayName("Rate")]
        public decimal rate { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "New" : "Edit";
            }
        }

        [DisplayName("Counter")]
        public int Counter { get; set; }

        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }
    }
}
