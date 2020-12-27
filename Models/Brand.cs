using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA3Last.Models
{
    public class Brand
    {
        public int id { set; get; }

        public string name { get; set; }

        public string image { set; get; }
        public string description { get; set; }
        public Brand(int iD,string Name,string Image,string Des)
        {
            this.id = iD;
            this.name = Name;
            this.image = Image;
            this.description = Des;
        }
        public Brand() {  }
    }
}