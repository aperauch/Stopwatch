using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Stopwatch.Models;

namespace Stopwatch.DAL
{
    public class WorkContext : DbContext
    {
        public WorkContext() : base("WorkContext") { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Engagement> Engagements { get; set; }
        public DbSet<Project> Projects { get; set; }

        static WorkContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WorkContext>());
        }
    }
}