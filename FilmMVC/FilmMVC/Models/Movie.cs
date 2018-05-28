using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FilmMVC.Models
{
    public class Movie
    {

        public int MovieID { get; set; }

        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Display(Name = "Movie Description")]
        public string MovieDescription { get; set; }

        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }

        //public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Director> Directors { get; set; }

    }
}