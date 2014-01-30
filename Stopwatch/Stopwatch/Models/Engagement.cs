using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stopwatch.Models
{
    public class Engagement
    {
        [Key]
        public int EngagementID { get; set; }
        public int MemberID { get; set; }
        public int ProjectID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public TimeSpan TimeSpan { get; set; }

        public Engagement()
        {
            StartTime = DateTime.Now;
            StopTime = StartTime;
        }
    }
}