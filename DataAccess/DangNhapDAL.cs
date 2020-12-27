using DA3Last.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DA3Last.DataAccess
{
    public class DangNhapDAL
    {
        DataHelper dth = new DataHelper(@"DESKTOP-7R75IKF", "TuLanShopDB", "sa", "1");
        public DangNhap checkDangNhap(string username, string matkhau)
        {
            string sql = "select * from dangnhap where username = '" + username + "' and matkhau = '" + matkhau + "'";
            DataTable dt = dth.laydulieu(sql);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                DangNhap dn = new DangNhap(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                return dn;
            }
        }
    }
}