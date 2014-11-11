using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceForIOS.Model
{
    public enum Sex { 
        Man=0,
        Woman=1
    }
    public class Users
    {
        public string Username { get; set; }
        public Sex Sex { get; set; }
        public string UserId { get; set; }
        public List<Poster> UserPosters { get; set; }


    }
}