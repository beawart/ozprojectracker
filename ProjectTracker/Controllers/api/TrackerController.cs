using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTracker.Models;

namespace ProjectTracker.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackerController : ControllerBase
    {
        private ProjectTrackerContext _context;

        public TrackerController(ProjectTrackerContext context)
        {
            _context = context;
        }

        public JsonResult GetTrackers(string query = null)
        {
            return new JsonResult(_context.Trackers.Include(project => project.ProjectType).AsQueryable());
        }

        [HttpGet("{id}")]
        public JsonResult GetTracker(int id)
        {
            return new JsonResult
            (_context.Projects.FirstOrDefault(proj => proj.Id == id));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTracker(int id)
        {
            var projectInDatabase = _context.Projects.Single(m => m.Id == id);
            if (projectInDatabase == null)
                NotFound();
            _context.Projects.Remove(projectInDatabase);
            _context.SaveChanges();
            return Ok();
        }
    }
}