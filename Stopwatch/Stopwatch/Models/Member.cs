﻿using System;
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
        //Properties
        public int ID { get; set; }
        [ScaffoldColumn(false)]
        public string ADName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<Engagement> Engagements { get; set; }

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
        }

    }
}