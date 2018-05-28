using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilmMVC.Models;

namespace FilmMVC.Controllers
{
    public class DirectorCommentController : Controller
    {
        private DBContext db = new DBContext();

        // GET: /DirectorComment/
        public ActionResult Index()
        {
            var directorcomments = db.DirectorComments.Include(d => d.Director).Include(d => d.User);
            return View(directorcomments.ToList());
        }

        // GET: /DirectorComment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectorComment directorcomment = db.DirectorComments.Find(id);
            if (directorcomment == null)
            {
                return HttpNotFound();
            }
            return View(directorcomment);
        }

        // GET: /DirectorComment/Create
        public ActionResult Create()
        {
            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "DirectorName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: /DirectorComment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DirectorCommentID,DirectorID,DirectorName,UserID,Comment,Posted")] DirectorComment directorcomment)
        {
            if (ModelState.IsValid)
            {
                db.DirectorComments.Add(directorcomment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "DirectorName", directorcomment.DirectorID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", directorcomment.UserID);
            return View(directorcomment);
        }

        // GET: /DirectorComment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectorComment directorcomment = db.DirectorComments.Find(id);
            if (directorcomment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "DirectorName", directorcomment.DirectorID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", directorcomment.UserID);
            return View(directorcomment);
        }

        // POST: /DirectorComment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DirectorCommentID,DirectorID,DirectorName,UserID,Comment,Posted")] DirectorComment directorcomment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directorcomment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "DirectorName", directorcomment.DirectorID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", directorcomment.UserID);
            return View(directorcomment);
        }

        // GET: /DirectorComment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectorComment directorcomment = db.DirectorComments.Find(id);
            if (directorcomment == null)
            {
                return HttpNotFound();
            }
            return View(directorcomment);
        }

        // POST: /DirectorComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DirectorComment directorcomment = db.DirectorComments.Find(id);
            db.DirectorComments.Remove(directorcomment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
