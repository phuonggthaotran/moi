using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DA3Last.Models;

namespace DA3Last.DataAccess
{
    public class ProductDAL
    {
        DataHelper dth = new DataHelper(@"DESKTOP-7R75IKF", "TuLanShopDB", "sa", "1");
        public Product Get1SanPham(int masp)
        {
            Product sp = new Product();
            DataTable dt = dth.laydulieu("select * from products where id='" + masp + "'");
            DataRow dr = dt.Rows[0];
            if (dt.Rows.Count > 0)
            {
                sp.id = Convert.ToInt32(dr[0].ToString());
                sp.category_id = Convert.ToInt32(dr[1].ToString());
                sp.supplier_id = Convert.ToInt32(dr[2].ToString());
                sp.product_name = dr[3].ToString();
                sp.price = int.Parse(dr[4].ToString());
                sp.image = dr[5].ToString();
              
                sp.quantity = int.Parse(dr[6].ToString());
                sp.screensize = dr[7].ToString(); 
                sp.resolution = dr[8].ToString();
                sp.number_of_HDMI_ports = Convert.ToInt32(dr[9].ToString());
                sp.number_of_USB_ports = Convert.ToInt32(dr[10].ToString());
                sp.voice_control = dr[11].ToString();
                sp.wifi =dr[12].ToString();
                sp.release_date = dr[13].ToString();
                sp.isContinue = dr[14].ToString();
             
                sp.description = dr[15].ToString();
            }


            return sp;
        }
        public List<Product> TimProduct(string name)
        {
            DataTable dt = dth.laydulieu("select * from products where product_name like'%" + name + "%'");
            return Tolist(dt);
        }
        public List<Product> getSAnPhamLienQuan(int category_id)
        {
            DataTable dt = dth.laydulieu("select*from products where category_id ='" + category_id + "'");
            return Tolist(dt);
        }

        public List<Product> Tolist(DataTable dt)
        {
            List<Product> l = new List<Product>();
            foreach (DataRow dr in dt.Rows)
            {
                Product sp = new Product();
                sp.id = Convert.ToInt32(dr[0].ToString());
                sp.category_id = Convert.ToInt32(dr[1].ToString());
                sp.supplier_id = Convert.ToInt32(dr[2].ToString());
                sp.product_name = dr[3].ToString();
                sp.price = int.Parse(dr[4].ToString());
                sp.image = dr[5].ToString();

                sp.quantity = int.Parse(dr[6].ToString());
                sp.screensize = dr[7].ToString();
                sp.resolution = dr[8].ToString();
                sp.number_of_HDMI_ports = Convert.ToInt32(dr[9].ToString());
                sp.number_of_USB_ports = Convert.ToInt32(dr[10].ToString());
                sp.voice_control = dr[11].ToString();
                sp.wifi = dr[12].ToString();
                sp.release_date = dr[13].ToString();
                sp.isContinue = dr[14].ToString();

                sp.description = dr[15].ToString();
                l.Add(sp);
            }
            return l;
        }
        public List<Product> LayAllProduct()
        {
            DataTable dt = dth.laydulieu("select * from products");
            return Tolist(dt);
        }
       
        //Thêm sửa xóa Admin

        public string ThemProduct(Product tb)
        {
            string them = "INSERT into products values('" + tb.category_id + "','" + tb.supplier_id + "','" + tb.product_name + "','" + tb.price + "','" + tb.image +"','" + tb.quantity + "','" + tb.screensize + "','" + tb.resolution + "','" + tb.number_of_HDMI_ports + "','" + tb.number_of_USB_ports + "','" + tb.voice_control + "','" + tb.wifi + "','" + tb.release_date + "','" + tb.isContinue  + "','" + tb.description+ "')";
            return dth.ExcuteNonQuery(them);
        }
        public string XoaProduct(int id)
        {
            string st = "delete from products where id = '" + id + "'";
            return dth.ExcuteNonQuery(st);
        }
        public string SuaProduct(Product tb)
        {
            string st = "update products set category_id='"+tb.category_id+ "',supplier_id='" + tb.supplier_id + "'  product_name ='" + tb.product_name + "',price ='" + tb.price + "', image ='" + tb.image + "', quantity ='" + tb.quantity + "', screensize = '" + tb.screensize + "', resolution = '" + tb.resolution + "', number_of_HDMI_ports = '" + tb.number_of_HDMI_ports + "',number_of_USB_ports = '" + tb.number_of_USB_ports + "',voice_control = '" + tb.voice_control + "',wifi='" + tb.wifi+"',release_date = '" + tb.release_date + "',isContinue = '" + tb.isContinue + "',description = '" + tb.description + "'where id = '" + tb.id + "'";
            return dth.ExcuteNonQuery(st);
        }
        //Lấy về sản phẩm theo loại
        //theo loại TV
        #region
        public List<Product> TV4k()
        {
            DataTable dt = dth.laydulieu("select * from products where name like'%HD4K'");
            return Tolist(dt);
        }
        public List<Product> Qled()
        {
            DataTable dt = dth.laydulieu("select * from products where name like'%Qled'");
            return Tolist(dt);
        }
        public List<Product> TV8k()
        {
            DataTable dt = dth.laydulieu("select * from products where name like'%8K'");
            return Tolist(dt);
        }
        //theo mức giá
        public List<Product> giaduoi20()
        {
            DataTable dh = dth.laydulieu("select * from products where price <20000000 ");
            return Tolist(dh);
        }

        public List<Product> tu20den50()
        {
            DataTable dh = dth.laydulieu("select * from products where price >20000000 and price<50000000");
            return Tolist(dh);
        }
        public List<Product> tren50()
        {
            DataTable dh = dth.laydulieu("select * from products where price >50000000 ");
            return Tolist(dh);
        }
        //theo kích thước màn hình
        public List<Product> duoi55inch()
        {
            DataTable dh = dth.laydulieu("select * from products where screensize <55 ");
            return Tolist(dh);
        }
        public List<Product> tren55inch()
        {
            DataTable dh = dth.laydulieu("select * from products where screensize >55 ");
            return Tolist(dh);
        }
        #endregion

    }
}