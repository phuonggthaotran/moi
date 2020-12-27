using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA3Last.Models
{
    public class Donhang
    {
        public int id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public string address_shipping { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public int total { get; set; }
        public string status { get; set; }
        public string date { get; set; }
        public Donhang() { }

        public Donhang(int Id, string Name, int Quantity, int Price, string Address_shipping, string Phone_number, string Email, int Total, string Status, string Date)
        {
            this.id = Id;
            this.name = Name;
            this.quantity = Quantity;
            this.price = Price;
            this.address_shipping = Address_shipping;
            this.phone_number = Phone_number;
            this.email = Email;
            this.total = Total;
            this.status = Status;
            this.date = Date;
        }
    }
}