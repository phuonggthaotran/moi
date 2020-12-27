using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DA3Last.Models;

namespace DA3Last.DataAccess
{
    public class DonHangDAL
    {
        DataHelper dth = new DataHelper(@"DESKTOP-7R75IKF", "TuLanShopDB", "sa", "1");
        public string ThemDonHang(Donhang d)
        {
            string them = "INSERT into orders values('" + d.name + "','" + d.quantity + "','" + d.price + "','" + d.address_shipping + "',N'" + d.phone_number + "','" + d.email + "',N'" + d.total + "','" + d.status + "',N'" + d.date + "')";
            return dth.ExcuteNonQuery(them);
        }
        public string xoa()
        {
            string xoa = "delete from orders where name =''";
            return dth.ExcuteNonQuery(xoa);
        }
        public string xoadonhang(int id)
        {
            string xoa = "delete from orders where id ='" + id + "'";
            return dth.ExcuteNonQuery(xoa);
        }
        public List<Donhang> getdonhang()
        {
            DataTable dt = dth.laydulieu("select * from orders");
            return Tolist(dt);
        }
        public List<Donhang> getngaydat(string ngay, string thang, string nam)
        {
            DataTable dt = dth.laydulieu("select * from orders where date like '%" + nam + "-" + thang + "-" + ngay + "%'");
            return Tolist(dt);
        }
        public List<Donhang> gettrangthai(string trangthai)
        {
            DataTable dt = dth.laydulieu("select * from orders where status =N'" + trangthai + "'");
            return Tolist(dt);
        }
        public string suadonhang(Donhang dh)
        {
            string sua = "update orders set quantity ='" + dh.quantity + "',total ='" + dh.total + "'phone_number ='" + dh.phone_number + "',address_shipping =N'" + dh.address_shipping + "',status =N'" + dh.status + "' where id ='" + dh.id + "'";
            return dth.ExcuteNonQuery(sua);
        }
        public List<Donhang> Tolist(DataTable dt)
        {
            List<Donhang> dh = new List<Donhang>();
            foreach (DataRow dr in dt.Rows)
            {
                Donhang d = new Donhang();
                d.id = Convert.ToInt32(dr[0]);
                d.name = Convert.ToString(dr[1]);
                d.quantity = Convert.ToInt32(dr[2]);
                d.price = Convert.ToInt32(dr[3]);
                d.address_shipping = Convert.ToString(dr[4]);
                d.phone_number = Convert.ToString(dr[5]);
                d.email = Convert.ToString(dr[6]);
                d.total = Convert.ToInt32(dr[7]);
                d.status = Convert.ToString(dr[8]);
                d.date = Convert.ToString(dr[9]);
                dh.Add(d);
            }
            return dh;
        }
        public Users CheckAccount(string name, string Pass)
        {
            string sql = "SELECT * FROM users WHERE UserName = '" + name + "' AND Pass = '" + Pass + "'";
            DataTable dt = dth.laydulieu(sql);

            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                Users us = new Users(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
                return us;
            }
        }
    }
}