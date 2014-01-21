using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Microsoft.Office.Interop.Outlook;
using OVC = Microsoft.Office.Interop.OutlookViewCtl;

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

        //Methods
        public void getOutlookCalendar()
        {
            TotalHours = 0;

            Microsoft.Office.Interop.Outlook.Application oApp = null;
            Microsoft.Office.Interop.Outlook.NameSpace mapiNamespace = null;
            Microsoft.Office.Interop.Outlook.MAPIFolder CalendarFolder = null;
            Microsoft.Office.Interop.Outlook.Items outlookCalendarItems = null;

            oApp = new Microsoft.Office.Interop.Outlook.Application();
            mapiNamespace = oApp.GetNamespace("MAPI");
            CalendarFolder = mapiNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar); 
            outlookCalendarItems = CalendarFolder.Items;
            outlookCalendarItems.IncludeRecurrences = true;
            outlookCalendarItems.Sort("[Start]");
            outlookCalendarItems = outlookCalendarItems.Restrict("[Start] >= '1/6/2014 12:00 AM' AND [End] < '1/6/2014 11:00 PM'");

            foreach (Microsoft.Office.Interop.Outlook.AppointmentItem item in outlookCalendarItems)
            {
                long busy = 2;
                int dHours = 0;
                double dMins = 0.0;
                if ((long)item.BusyStatus == busy)
                {
                    dHours = item.Duration / 60;
                    dMins = (double)item.Duration % 60.0 / 100;
                }

                TotalHours += dHours + dMins;
                Debug.WriteLine(item.Subject + " -> " + item.Start.ToLongDateString());
            }
        }
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