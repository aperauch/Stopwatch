using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stopwatch.Models
{
    public class Project
    {
        //Properties
        [Key]
        public int ID { get; set; }
        public bool Active { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayName("Start Date")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        //[InverseProperty("EProject")]
        public virtual ICollection<Engagement> Engagements { get; set; }
        public virtual ICollection<Member> Members { get; set; }

        //Constructor
        public Project()
        {
            Engagements = new List<Engagement>();
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(7);
        }
    }
}