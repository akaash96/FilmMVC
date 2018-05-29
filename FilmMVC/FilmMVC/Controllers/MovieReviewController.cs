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
    public class MovieReviewController : Controller
    {
        private DBContext db = new DBContext();

        // GET: /MovieReview/
        public ActionResult Index()
        {
            var moviereviews = db.MovieReviews;
            return View(moviereviews.ToList());
        }

        // GET: /MovieReview/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieReview moviereview = db.MovieReviews.Find(id);
            if (moviereview == null)
            {
                return HttpNotFound();
            }
            return View(moviereview);
        }

        // GET: /MovieReview/Create
        public ActionResult Create()
        {
            ViewBag.Users = db.Users.Where(user => user.IsUserBarred == false);
            ViewBag.Movies = db.Movies;
            return View();
        }

        // POST: /MovieReview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieReviewID,UserID,Review,MovieID,Posted")] MovieReview moviereview)
        {
            var moviereviews = new MovieReview();
            TryUpdateModel(moviereviews);

            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;
                db.MovieReviews.Add(moviereview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", moviereview.UserID);
            return View(moviereview);
        }

        // GET: /MovieReview/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieReview moviereview = db.MovieReviews.Find(id);
            if (moviereview == null)
            {
                return HttpNotFound();
            }
            ViewBag.Users = db.Users.Where(user => user.IsUserBarred == false);
            ViewBag.Movies = db.Movies;
            return View(moviereview);

        }

        // POST: /MovieReview/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieReviewID,UserID,Review,MovieID,Posted")] MovieReview moviereview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moviereview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", moviereview.UserID);
            return View(moviereview);
        }

        // GET: /MovieReview/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieReview moviereview = db.MovieReviews.Find(id);
            if (moviereview == null)
            {
                return HttpNotFound();
            }
            return View(moviereview);
        }

        // POST: /MovieReview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieReview moviereview = db.MovieReviews.Find(id);
            db.MovieReviews.Remove(moviereview);
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
