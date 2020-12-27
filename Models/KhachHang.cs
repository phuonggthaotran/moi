using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA3Last.Models
{
    public partial class KhachHang
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public KhachHang() { }

        public KhachHang(int Id, string Phone, string Address)
        {
            this.id = Id;
            this.phone = Phone;
            this.address = Address;
        }
    }
}