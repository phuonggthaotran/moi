using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DA3Last.Models;

namespace DA3Last.DataAccess
{
    public class UserDAL
    {
        DataHelper dth = new DataHelper(@"DESKTOP-7R75IKF", "TuLanShopDB", "sa", "1");
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


        public string SignUp(Users us)
        {
            string sql = "Insert into users values('" + us.UserName + "','" + us.Pass + "','" + us.Role + "','" + us.Active + "')";
            return dth.ExcuteNonQuery(sql);
        }

        public List<Users> ToList(DataTable dt)
        {
            List<Users> l = new List<Users>();
            foreach (DataRow dr in dt.Rows)
            {
                Users u = new Users();
                
                u.UserName = Convert.ToString(dr[0]);
                u.Pass = Convert.ToString(dr[1]);
                u.Role = Convert.ToString(dr[2]);
                u.Active = Convert.ToString(dr[3]);
                l.Add(u);
            }
            return l;
        }


        public List<Users> GetAllUser()
        {
            DataTable dt = dth.laydulieu("select * from users");
            return ToList(dt);
        }
    }
}