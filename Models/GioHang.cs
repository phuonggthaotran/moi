using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA3Last.Models
{
    public class GioHang
    {
        public string product_name{ get; set; }
        public string image { get; set; }
        public int price { get; set; }
        public GioHang() { }
        public GioHang(int Id, int Order_id, string Product_name,string Image, int Price)
        {
            this.product_name = Product_name;
            this.image = Image;
            this.price = Price;
        }
    }
}