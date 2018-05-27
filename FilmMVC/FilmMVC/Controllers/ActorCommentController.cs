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
    public class ActorCommentController : Controller
    {
        private DBContext db = new DBContext();

        // GET: /ActorComment/
        public ActionResult Index()
        {
            var actorcomments = db.ActorComments.Include(a => a.Actor).Include(a => a.User);
            return View(actorcomments.ToList());
        }

        // GET: /ActorComment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActorComment actorcomment = db.ActorComments.Find(id);
            if (actorcomment == null)
            {
                return HttpNotFound();
            }
            return View(actorcomment);
        }

        // GET: /ActorComment/Create
        public ActionResult Create()
        {
            ViewBag.ActorID = new SelectList(db.Actors, "ActorID", "ActorName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: /ActorComment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActorCommentID,ActorID,ActorName,UserID,Comment,Posted")] ActorComment actorcomment)
        {
            if (ModelState.IsValid)
            {
                db.ActorComments.Add(actorcomment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorID = new SelectList(db.Actors, "ActorID", "ActorName", actorcomment.ActorID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", actorcomment.UserID);
            return View(actorcomment);
        }

        // GET: /ActorComment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActorComment actorcomment = db.ActorComments.Find(id);
            if (actorcomment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorID = new SelectList(db.Actors, "ActorID", "ActorName", actorcomment.ActorID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", actorcomment.UserID);
            return View(actorcomment);
        }

        // POST: /ActorComment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActorCommentID,ActorID,ActorName,UserID,Comment,Posted")] ActorComment actorcomment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actorcomment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorID = new SelectList(db.Actors, "ActorID", "ActorName", actorcomment.ActorID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", actorcomment.UserID);
            return View(actorcomment);
        }

        // GET: /ActorComment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActorComment actorcomment = db.ActorComments.Find(id);
            if (actorcomment == null)
            {
                return HttpNotFound();
            }
            return View(actorcomment);
        }

        // POST: /ActorComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActorComment actorcomment = db.ActorComments.Find(id);
            db.ActorComments.Remove(actorcomment);
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
