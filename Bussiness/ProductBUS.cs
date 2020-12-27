using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA3Last.DataAccess;
using DA3Last.Models;

namespace DA3Last.Bussiness
{
    public class ProductBUS
    {
        ProductDAL dtd = new ProductDAL();
        public Product lay1sp(int id)
        {
            return dtd.Get1SanPham(id);
        }
        public List<Product> timSP(string name)
        {
            return dtd.TimProduct(name);
        }
        public List<Product> getSPLQ(int id)
        {
            return dtd.getSAnPhamLienQuan(id);
        }
        public List<Product> duoi20() { return dtd.giaduoi20(); }
       
        public List<Product> tu20den50() { return dtd.tu20den50(); }
        public List<Product> tren50() { return dtd.tren50(); }
        public List<Product> tivi4k() { return dtd.TV4k(); }
        public List<Product> tivi8k() { return dtd.TV8k(); }
        public List<Product> Qled() { return dtd.Qled(); }
        public List<Product> Duoi55inch() { return dtd.duoi55inch(); }
        public List<Product> tren55inch() { return dtd.tren55inch(); }

        //public DienThoaiList LayDienThoaiPT(int pageIndex, int pageSize,string productName)
        //{
        //    return dtd.GetDienThoai(pageIndex, pageSize,productName);
        //}
        public List<Product> LayAllSP()
        {
            return dtd.LayAllProduct();
        }
        public string ThemSP(Product dt)
        {
            return dtd.ThemProduct(dt);
        }
        public string XoaSP(int id)
        {
            return dtd.XoaProduct(id);
        }
        public string SuaSP(Product dt)
        {
            return dtd.SuaProduct(dt);
        }
    }
}