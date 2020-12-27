using DA3Last.DataAccess;
using DA3Last.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA3Last.Bussiness
{
    public class DangNhapBUS
    {
        DangNhapDAL dnd = new DangNhapDAL();
        public DangNhap checkDangNhap(string username, string matkhau)
        {
            return dnd.checkDangNhap(username, matkhau);
        }
    }
}