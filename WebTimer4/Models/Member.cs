using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebTimer4.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public double TotalHours { get; set; }
    }

    public class MemberDBContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        static MemberDBContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MemberDBContext>());
        }
    }
}