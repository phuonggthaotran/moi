using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA3Last.Models
{
    public class CTDonHang
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public string product_name{ get; set; }
        public string image { get; set; }
        public int price { get; set; }
        public CTDonHang() { }
        public CTDonHang(int Id, int Order_id, string Product_name,string Image, int Price)
        {
            this.id = Id;
            this.order_id = Order_id;
            this.product_name = Product_name;
            this.image = Image;
            this.price = Price;
        }
    }
}