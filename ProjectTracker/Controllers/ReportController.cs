using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTracker.Models;
using ProjectTracker.ViewModels;

namespace ProjectTracker.Controllers
{
    public class ReportController : Controller
    {
        ProjectTrackerContext _context;

        public ReportController(ProjectTrackerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult MonthEarning(string query = null)
        {
            var trackers = _context.Trackers.Include(project => project.ProjectType).AsQueryable();
            List<MonthlyEarningViewModel> listViewModel = new List<MonthlyEarningViewModel>();

            var trackersCompare = trackers.ToList();
            foreach (var tracker in trackers)
            {
                int currentMonth = tracker.CreatedOn.Month;
                int currentYear = tracker.CreatedOn.Year;
                decimal monthEarning = 0.0M;
                if (listViewModel.Any(view => view.Month == currentMonth && view.Year == currentYear))
                {
                    continue;
                }
                foreach (var track in trackersCompare)
                {
                    if (track.CreatedOn.Month == currentMonth
                        && track.CreatedOn.Year == currentYear)
                    {
                        monthEarning += track.ProjectType.TaskRate * track.Count;
                    }
                }
                listViewModel.Add(new MonthlyEarningViewModel()
                {
                    Month = currentMonth,
                    Year = currentYear,
                    Earning = monthEarning
                });
            }

            return new JsonResult(listViewModel);
        }
    }
}