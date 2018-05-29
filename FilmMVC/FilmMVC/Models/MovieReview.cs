using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmMVC.Models
{
    public class MovieReview
    {
        public int MovieReviewID { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public string Review { get; set; }

        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }

        [DataType(DataType.Date)]
        public DateTime Posted { get; set; }
    }
}