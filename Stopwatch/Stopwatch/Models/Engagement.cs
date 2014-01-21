using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stopwatch.Models
{
    public class Engagement
    {
        public int EngagementID { get; set; }
        public int MemberID { get; set; }
        public int ProjectID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StoptTime { get; set; }
        public double EngagementHours { get; set; }
    }
}