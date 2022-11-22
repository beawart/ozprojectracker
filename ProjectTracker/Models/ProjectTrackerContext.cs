using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracker.Models
{
    public class ProjectTrackerContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tracker> Trackers { get; set; }


        public ProjectTrackerContext(DbContextOptions<ProjectTrackerContext> options) : base(options)
        { }
    }
}
