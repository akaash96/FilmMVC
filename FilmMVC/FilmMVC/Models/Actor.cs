using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmMVC.Models
{
    public class Actor
    {

        public int ActorID { get; set; }
        public string ActorName { get; set; }
        public int ActorCommentID { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}