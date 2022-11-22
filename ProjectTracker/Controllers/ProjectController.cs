using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Models;
using ProjectTracker.ViewModels;

namespace ProjectTracker.Controllers
{
    public class ProjectController : Controller
    {
        ProjectTrackerContext _context;
        public ProjectController(ProjectTrackerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View("List");
        }

        public IActionResult New()
        {
            var viewModel = new ProjectFormViewModel();
            return View("ProjectForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(ProjectFormViewModel projectViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = projectViewModel;
                return View("ProjectForm", viewModel);
            }
            if (projectViewModel.Id == 0)
            {

                var project = new Project()
                {
                    Name = projectViewModel.name,
                    Description = projectViewModel.description,
                    TaskRate = projectViewModel.rate,
                    CreatedOn = DateTime.Now
                    
                };
                _context.Projects.Add(project);
            }
            else
            {
                var projectInDatabase = _context.Projects.Single(m => m.Id == projectViewModel.Id);
                projectInDatabase.Name = projectViewModel.name;
                projectInDatabase.Description = projectViewModel.description;
                projectInDatabase.TaskRate = projectViewModel.rate;
                projectInDatabase.CreatedOn = DateTime.Now;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var project = _context.Projects.SingleOrDefault(m => m.Id == id);
            var viewModel = new ProjectFormViewModel(project);
            return View("ProjectForm", viewModel);
        }
    }
}