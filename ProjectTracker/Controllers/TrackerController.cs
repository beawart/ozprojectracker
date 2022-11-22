using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Models;
using ProjectTracker.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace ProjectTracker.Controllers
{
    public class TrackerController : Controller
    {
        ProjectTrackerContext _context;

        public TrackerController(ProjectTrackerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View("List");
        }

        //public IActionResult MonthEarning()
        //{
        //    return View("MonthEarning");
        //}

        public IActionResult New()
        {
            var viewModel = new TrackerFormViewModel()
            {
                Projects = _context.Projects.ToList()
            };
            return View("TrackerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Tracker tracker)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TrackerFormViewModel(tracker);
                return View("TrackerForm", viewModel);
            }
            if (tracker.Id == 0)
            {
                tracker.CreatedOn = DateTime.Now;
                _context.Trackers.Add(tracker);
            }
            else
            {
                var trackerInDatabase = _context.Trackers.Single(m => m.Id == tracker.Id);
                trackerInDatabase.ProjectTypeId = tracker.ProjectTypeId;
                trackerInDatabase.Count = tracker.Count;
                trackerInDatabase.CreatedOn = DateTime.Now;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var tracker = _context.Trackers.SingleOrDefault(m => m.Id == id);
            var viewModel = new TrackerFormViewModel(tracker)
            {
                Projects = _context.Projects.ToList()
            };
            return View("TrackerForm", viewModel);
        }


    }
}