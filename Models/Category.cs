using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA3Last.Models
{
    public class Category
    {
        public int id { get; set; }
        public int brand_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
       
        public Category(int Id,int Brand_id,string Name,string Des)
        {
            this.id = Id;
            this.brand_id = Brand_id;
            this.name = Name;
            this.description = Des;
            
        }
        public Category() { }
    }
}