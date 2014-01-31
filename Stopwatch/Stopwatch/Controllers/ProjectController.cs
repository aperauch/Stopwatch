using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stopwatch.Models;
using Stopwatch.DAL;

namespace Stopwatch.Controllers
{
    public class ProjectController : Controller
    {
        private WorkContext db = new WorkContext();

        public ActionResult List()
        {
            return View(db.Projects.ToList());
        }

        public ActionResult StartTimer(int id = 0)
        {
            Project project = db.Projects.Find(id);

            if (project == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                //Create new engagement and set attributes
                Engagement e = new Engagement();
                e.ProjectID = project.ID;
                e.MemberID = project.Owner.ID;
                e.StartTime = DateTime.Now;

                //Set project attributes
                project.Active = true;
                project.Engagements.Add(e);
                //db.Engagements.Add(e);

                //Save changes to db
                db.Entry(project).State = EntityState.Modified;
                //db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("List");
            }

            return View(project);
        }

        public ActionResult StopTimer(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                //Set project attributes
                project.Active = false;

                //Find the engagement with the correct project id and set attributes
                Engagement e = project.Engagements.LastOrDefault(a => a.ProjectID == project.ID);
                e.StopTime = DateTime.Now;
                e.TimeSpan = e.StopTime.Subtract(e.StartTime);
                project.TimeSpan += e.TimeSpan;

                //Save changes to db
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("List");
            }

            return View(project);
        }

        //
        // GET: /Project/

        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        //
        // GET: /Project/Details/5

        public ActionResult Details(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // GET: /Project/Create

        public ActionResult Create()
        {
            Project project = new Project();
            List<Member> members = db.Members.ToList();
            Member currentUser = new Member();
            Member owner = null;

            foreach (Member m in members)
            {
                if (m.ADName.Equals(currentUser.ADName))
                    owner = m;
            }

            if (owner == null)
                owner = currentUser;

            project.Owner = owner;

            List<SelectListItem> listSelectMembers = new List<SelectListItem>();
            foreach (Member m in db.Members)
            {
                SelectListItem sli = new SelectListItem()
                {
                    Text = m.ADName,
                    Value = m.ID.ToString(),
                    Selected = m.IsSelected
                };
                listSelectMembers.Add(sli);
            }
            project.SMembers = listSelectMembers;

            ViewData["Members"] = members;

            return View(project);
        }

        //[HttpPost]
        //public string Create(IEnumerable<string> selectedMembers)
        //{
        //    if (selectedMembers == null)
        //        return "Nothing select";
        //    else
        //    {
        //        return "You selected " + string.Join(", ", selectedMembers);
        //    }
        //}

        //
        // POST: /Project/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        //
        // GET: /Project/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // POST: /Project/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        //
        // GET: /Project/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // POST: /Project/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}