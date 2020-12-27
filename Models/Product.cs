using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA3Last.Models
{
    public class Product
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public int supplier_id { get; set; }
        public string product_name { get; set; }
        public int price { get; set; }
        public string image { get; set; }
       
        public int quantity { get; set; }
        public string screensize { get; set; }
        public string resolution { get; set; }
        public int number_of_HDMI_ports { get; set; }
        public int number_of_USB_ports { get; set; }
        public string voice_control { get; set; }
        public string wifi { get; set; }
        
        public string release_date { get; set; }
        public string isContinue { get; set; }
     
        public string description { get; set; }
       
        public Product() { }

        public Product(int Id, int Category_id, int Supplier_id, string Product_name, int Price, string Image, int Quantity, string Screensize, string Resolution, int Number_of_HDMI, int Number_of_USB, string Voice_control, string Wifi, string Release_date, string IsContinue, string Description)
        {
            this.id = Id;
            this.category_id = Category_id;
            this.supplier_id = Supplier_id;
            this.product_name = Product_name;
            this.price = Price;
            this.image = Image;
         
            this.quantity = Quantity;
            this.screensize = Screensize;
            this.resolution = Resolution;
            this.number_of_HDMI_ports = Number_of_HDMI;
            this.number_of_USB_ports = Number_of_USB;
            this.voice_control = Voice_control;
            this.wifi = Wifi;
            
            this.release_date = Release_date;
            this.isContinue = IsContinue;
           
            this.description = Description;
        }
    }
}