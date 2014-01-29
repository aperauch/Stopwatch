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
        //[ForeignKey("MemberID")]
        public int MemberID { get; set; }
        //[ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        //[DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
        //[DataType(DataType.Date)]
        public DateTime StopTime { get; set; }
        public double EngagementHours { get; set; }

        public Engagement()
        {
            StartTime = DateTime.Now;
            StopTime = StartTime;
        }
    }
}