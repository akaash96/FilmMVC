using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmMVC.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public bool IsUserBarred { get; set; }
    }
}