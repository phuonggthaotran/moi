using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DA3Last.Models;


namespace DA3Last.DataAccess
{
    public class SupplierDAL
    {
        DataHelper dth = new DataHelper(@"DESKTOP-7R75IKF", "TuLanShopDB", "sa", "1");
        public List<Supplier> LayNCC(string name)
        {
            DataTable dt = dth.laydulieu("select * from suppliers where name = '" + name + "'");
            return Tolist(dt);
        }
        public List<Supplier> TimNCC(string name)
        {
            DataTable dt = dth.laydulieu("select * from suppliers where name like'%" + name + "%'");
            return Tolist(dt);
        }
        public List<Supplier> Tolist(DataTable dt)
        {
            List<Supplier> l = new List<Supplier>();
            foreach (DataRow dr in dt.Rows)
            {
                Supplier lsp = new Supplier();
                lsp.id = Convert.ToInt32(dr[0].ToString());
                lsp.name = dr[1].ToString();
                lsp.phone_number = dr[2].ToString();
                lsp.email = dr[3].ToString();
                lsp.address = dr[3].ToString();
                l.Add(lsp);
            }
            return l;
        }
        public List<Supplier> getAll()
        {
            DataTable dt = dth.laydulieu("select * from suppliers");
            return Tolist(dt);
        }
        public string ThemNCC(Supplier dt)
        {
            string them = "INSERT into suppliers values('" + dt.name + "','" + dt.phone_number + "','" + dt.email+ "','" + dt.address+ "')";
            return dth.ExcuteNonQuery(them);
        }
        public string XoaNCC(int id)
        {
            string st = "delete from suppliers where id = '" + id + "'";
            return dth.ExcuteNonQuery(st);
        }
        public string SuaNCC(Supplier dt)
        {
            string st = "update suppliers set name='" + dt.name + "',phone_number ='" + dt.phone_number + "',email='" + dt.email + "',address='" + dt.address + "' where id ='" + dt.id + "'";
            return dth.ExcuteNonQuery(st);
        }
    }
}