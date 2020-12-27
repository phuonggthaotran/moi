using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA3Last.DataAccess;
using DA3Last.Models;

namespace DA3Last.Bussiness
{
    public class CategoriesBUS
    {
        CategoriesDAL dtd = new CategoriesDAL();
        public List<Category> layLoai(string name)
        {
            return dtd.layloai(name);
        }
        public List<Category> timLoai(string name)
        {
            return dtd.TimLoaiSP(name);
        }

        public List<Category> getAll()
        {
            return dtd.getAll();
        }

      
        public string ThemLoai(Category dt)
        {
            return dtd.ThemLoai(dt);
        }
        public string XoaLoai(int id)
        {
            return dtd.XoaLoai(id);
        }
        public string SuaLoai(Category dt)
        {
            return dtd.SuaLoai(dt);
        }
    }
}