using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmMVC.Models
{
    public class Director
    {

        public int DirectorID { get; set; }
        public string DirectorName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}