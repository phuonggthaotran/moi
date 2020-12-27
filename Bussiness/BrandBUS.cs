using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA3Last.DataAccess;
using DA3Last.Models;

namespace DA3Last.Bussiness
{
    public class BrandBUS
    {
        BrandDAL dtd = new BrandDAL();
        public List<Brand> laythuonghieu(string name)
        {
            return dtd.LayThuongHieu(name);
        }
        public List<Brand> timthuonghieu(string name)
        {
            return dtd.TimThuongHieu(name);
        }

        public List<Brand> getAll()
        {
            return dtd.getAll();
        }
        //public List<ListCatg> getAllbyid( int id)
        //{
        //    return dtd.getAllbyid(id);
        //}
        public string ThemThuongHieu(Brand dt)
        {
            return dtd.ThemThuongHieu(dt);
        }
        public string XoaThuongHieu(int id)
        {
            return dtd.XoaThuongHieu(id);
        }
        public string SuaThuongHieu(Brand dt)
        {
            return dtd.SuaThuongHieu(dt);
        }
    }
}