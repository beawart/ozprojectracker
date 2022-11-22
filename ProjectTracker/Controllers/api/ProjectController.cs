using AutoMapper;
using DataTables.Queryable;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Dto;
using ProjectTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracker.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private ProjectTrackerContext _context;

        public ProjectController(ProjectTrackerContext context)
        {
            _context = context;
        }

        //Get api/projects
        public JsonResult GetProjects(string query=null)
        {
            return new JsonResult(_context.Projects.AsQueryable());
        }
        private JsonResult JsonDataTable<T>(IPagedList<T> model)
        {
            return new JsonResult(new
            {
                recordsTotal = model.TotalCount,
                recordsFiltered = model.TotalCount,
                data = model
            });
        }

        [HttpGet("{id}")]
        public JsonResult GetProject(int id)
        {
            return new JsonResult
            (_context.Projects.FirstOrDefault(proj => proj.Id == id));
        }

        //DELETE api/project/1
        [HttpDelete("{id}")]
        public ActionResult DeleteProject(int id)
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
