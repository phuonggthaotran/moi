using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DA3Last.Models;

namespace DA3Last.DataAccess
{
    public class CategoriesDAL
    {
        DataHelper dth = new DataHelper(@"DESKTOP-7R75IKF", "TuLanShopDB", "sa", "1");
       public List<Category> layloai(string name)
        {
            DataTable dh=dth.laydulieu("select* from categories where name = '" + name + "'");
            return Tolist(dh);
        }
        public List<Category> TimLoaiSP(string name)
        {
            DataTable dt = dth.laydulieu("select * from categories where name like'%" + name + "%'");
            return Tolist(dt);
        }
        public List<Category> Tolist(DataTable dt)
        {
            List<Category> l = new List<Category>();
            foreach (DataRow dr in dt.Rows)
            {
                Category lsp = new Category();
                lsp.id = Convert.ToInt32(dr[0].ToString());
                lsp.brand_id =Convert.ToInt32( dr[1].ToString());
                lsp.name = dr[2].ToString();
                lsp.description = dr[3].ToString();
                
                l.Add(lsp);
            }
            return l;
        }

      
        public List<Category> getAll()
        {
            DataTable dt = dth.laydulieu("select * from categories");
            return Tolist(dt);
        }
        public string ThemLoai(Category dt)
        {
            string them = "INSERT into categories values('" + dt.brand_id + "','" + dt.name + "','" + dt.description +"')";
            return dth.ExcuteNonQuery(them);
        }
        public string XoaLoai(int id)
        {
            string st = "delete from categories where id = '" + id + "'";
            return dth.ExcuteNonQuery(st);
        }
        public string SuaLoai(Category dt)
        {
            string st = "update categories set brand_id='" + dt.brand_id + "',name ='" + dt.name + "',description='" + dt.description +"' where id ='" + dt.id + "'";
            return dth.ExcuteNonQuery(st);
        }
    }
}