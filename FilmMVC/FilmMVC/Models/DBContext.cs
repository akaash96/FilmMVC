using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FilmMVC.Models
{
    public class DBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DBContext() : base("name=DBContext")
        {

        }

        public System.Data.Entity.DbSet<FilmMVC.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<FilmMVC.Models.Actor> Actors { get; set; }

        public System.Data.Entity.DbSet<FilmMVC.Models.Director> Directors { get; set; }

        public System.Data.Entity.DbSet<FilmMVC.Models.Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<FilmMVC.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<FilmMVC.Models.MovieReview> MovieReviews { get; set; }

        public System.Data.Entity.DbSet<FilmMVC.Models.ActorComment> ActorComments { get; set; }

        public System.Data.Entity.DbSet<FilmMVC.Models.DirectorComment> DirectorComments { get; set; }

    }
}
