using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilmMVC.Models
{
    public class Genre
    {

        public int GenreID { get; set; }

        [Display(Name = "Genre Name")]
        public string GenreName { get; set; }

        // public virtual ICollection<Movie> Movies { get; set; }
    }
}