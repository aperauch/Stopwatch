using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTimer4.Models;

namespace WebTimer4.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectDBContext db = new ProjectDBContext();

        public ActionResult Start()
        {
            return View(db.Projects.ToList());
        }

        public ActionResult StartTimer(Project project)
        {
            if (ModelState.IsValid)
            {
                project.Active = true;
                project.StartTime = DateTime.Now;
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Start");
            }

            return View(project);     
        }

        public ActionResult Stop()
        {
            return View(db.Projects.ToList());
        }

        public ActionResult StopTimer(Project project)
        {
            if (ModelState.IsValid)
            {
                project.Active = false;
                project.StopTime = DateTime.Now;
                project.TotalHours += project.StopTime.Subtract(project.StartTime).TotalSeconds;
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Start");
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
            return View();
        }

        //
        // POST: /Project/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                project.StartTime = DateTime.Now;
                project.StopTime = DateTime.Now;
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