using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA3Last.Models
{
    public class Supplier
    {
       
        public int id { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public Supplier() {  }
        public Supplier(int Id, string Name, string Phone_number, string Email, string Address)
        {
            this.id = Id;
            this.name = Name;
            this.phone_number = Phone_number;
            this.email = Email;
            this.address = Address;
        }

    }
}