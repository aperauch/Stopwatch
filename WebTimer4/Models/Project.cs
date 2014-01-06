using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data.Entity;

namespace WebTimer4.Models
{
    public class Project
    {
        public int ID { get; set; }
        public Boolean Active { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public double TotalHours { get; set; }
    }

    public class ProjectDBContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        static ProjectDBContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProjectDBContext>());
        }
    }
}