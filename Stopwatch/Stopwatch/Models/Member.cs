using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.DirectoryServices.AccountManagement;

namespace Stopwatch.Models
{
    public class Member
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ADName { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<Engagement> Engagements { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

        //Constructor
        public Member()
        {
            //Get the AD Username
            //Set up domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

            //Find the current user
            UserPrincipal user = UserPrincipal.Current;

            if (user != null)
            {
                //Get AD user properties
                ADName = user.SamAccountName.ToLower();
                Firstname = user.GivenName;
                Lastname = user.Surname;
                Email = user.EmailAddress.ToLower();
            }

            //Initialize the collections
            Engagements = new List<Engagement>();
            Projects = new List<Project>();
        }

    }
}