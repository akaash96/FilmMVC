using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmMVC.Models
{
    public class DirectorComment
    {
        public int DirectorCommentID { get; set; }
        public int DirectorID { get; set; }
        public string DirectorName { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
        public string Comment { get; set; }

        public virtual Director Director { get; set; }

        public DateTime Posted { get; set; }
        public virtual ICollection<DirectorComment> DirectorComments { get; set; }
    }
}