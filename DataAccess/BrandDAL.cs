using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DA3Last.Models;

namespace DA3Last.DataAccess
{
    public class BrandDAL
    {
        DataHelper dth = new DataHelper(@"DESKTOP-7R75IKF", "TuLanShopDB", "sa", "1");
        public List<Brand> LayThuongHieu(string name)
        {
            DataTable dt = dth.laydulieu("select * from brands where name = '" + name + "'");
            return Tolist(dt);
        }
        public List<Brand> TimThuongHieu(string name)
        {
            DataTable dt = dth.laydulieu("select * from brands where name like'%" + name + "%'");
            return Tolist(dt);
        }
        public List<Brand> Tolist(DataTable dt)
        {
            List<Brand> l = new List<Brand>();
            foreach (DataRow dr in dt.Rows)
            {
                Brand lsp = new Brand();
                lsp.id = Convert.ToInt32(dr[0].ToString());
                lsp.name = dr[1].ToString();
                lsp.image = dr[2].ToString();
                lsp.description = dr[3].ToString();
                l.Add(lsp);
            }
            return l;
        }
      
        public List<Brand> getAll()
        {
            DataTable dt = dth.laydulieu("select * from brands");
            return Tolist(dt);
        }
       

        public string ThemThuongHieu(Brand dt)
        {
            string them = "INSERT into brands values('" + dt.name + "','" + dt.image + "','" +dt.description+ "')";
            return dth.ExcuteNonQuery(them);
        }
        public string XoaThuongHieu(int id)
        {
            string st = "delete from brands where id = '" + id + "'";
            return dth.ExcuteNonQuery(st);
        }
        public string SuaThuongHieu(Brand dt)
        {
            string st = "update brands set name='" + dt.name + "',image ='" + dt.image + "',description='" + dt.description + "' where id ='" + dt.id + "'";
            return dth.ExcuteNonQuery(st);
        }
    }
}