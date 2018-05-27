using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmMVC.Models
{
    public class ActorComment
    {
        public int ActorCommentID { get; set; }
        public int ActorID { get; set; }
        public string ActorName { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
        public string Comment { get; set; }

        public virtual Actor Actor { get; set; }

        public DateTime Posted { get; set; }
        public virtual ICollection<ActorComment> ActorComments { get; set; }

    }
}