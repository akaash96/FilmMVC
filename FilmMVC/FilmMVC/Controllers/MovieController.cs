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
    public class MovieController : Controller
    {
        private DBContext db = new DBContext();

        // GET: /Movie/
        public ActionResult Index()
        {
            List<Movie> movies = db.Movies.ToList();
            return View(movies);
        }

        // GET: /Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: /Movie/Create
        public ActionResult Create()
        {

            ViewBag.Genres = db.Genres.ToList();

            // Make sure the ViewBag property is the same name as the Model property.
            this.ViewBag.Actors = new MultiSelectList(db.Actors.ToList(), "ActorID", "ActorName");
            this.ViewBag.Directors = new MultiSelectList(db.Directors.ToList(), "DirectorID", "DirectorName");
            return View();
        }

        // POST: /Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,MovieName,MovieDescription,GenreID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);


                var actorIds = Request.Form["Actors"];
                var directorIds = Request.Form["Directors"];
                addSelectedActorsToMovie(movie, actorIds);
                addSelectedDirectorsToMovie(movie, directorIds);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(movie);
        }

        // GET: /Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);

            ViewBag.Genres = db.Genres.ToList();

            var actorIds = movie.Actors.Select(c => c.ActorID).ToArray();
            var directorIds = movie.Directors.Select(d => d.DirectorID).ToArray();

            // Make sure the ViewBag property is the same name as the Model property.
            this.ViewBag.Actors = new MultiSelectList(db.Actors.ToList(), "ActorID", "ActorName", actorIds);
            this.ViewBag.Directors = new MultiSelectList(db.Directors.ToList(), "DirectorID", "DirectorName", directorIds);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        private void deleteAllActorsFromMovie(Movie movie)
        {
            db.Entry(movie).Collection(p => p.Actors).Load();
            var listActors = movie.Actors.ToList();
            foreach (var actor in listActors)
            {
                movie.Actors.Remove(actor);
                actor.Movies.Remove(movie);
            }
        }

        private void deleteAllDirectorsFromMovie(Movie movie)
        {
            db.Entry(movie).Collection(p => p.Directors).Load();
            var listDirectors = movie.Directors.ToList();
            foreach (var director in listDirectors)
            {
                movie.Directors.Remove(director);
                director.Movies.Remove(movie);
            }
        }
        private void addSelectedActorsToMovie(Movie movie, String actorIds)
        {
            foreach (var actorId in actorIds.Split(','))
            {
                var intActorId = int.Parse(actorId);
                Actor actor = db.Actors.Where(ct => ct.ActorID == intActorId).First();
                actor.Movies.Add(movie);
                if (movie.Actors != null)
                {
                    movie.Actors.Add(actor);
                }
            }

        }
        private void addSelectedDirectorsToMovie(Movie movie, String directorIds)
        {
            foreach (var directorId in directorIds.Split(','))
            {
                var intDirectorId = int.Parse(directorId);
                Director director = db.Directors.Where(ct => ct.DirectorID == intDirectorId).First();
                director.Movies.Add(movie);
                if (movie.Directors != null)
                {
                    movie.Directors.Add(director);
                }
            }

        }
        // POST: /Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,MovieName,MovieDescription,GenreID,DirectorID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;

                deleteAllActorsFromMovie(movie);
                deleteAllDirectorsFromMovie(movie);

                var actorIds = Request.Form["Actors"];
                addSelectedActorsToMovie(movie, actorIds);

                var directorIds = Request.Form["Directors"];
                addSelectedDirectorsToMovie(movie, directorIds);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: /Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: /Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
