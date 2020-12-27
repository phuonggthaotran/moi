using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA3Last.DataAccess;
using DA3Last.Models;

namespace DA3Last.Bussiness
{
    public class SupplierBUS
    {
        SupplierDAL dtd = new SupplierDAL();
        public List<Supplier> layNCC(string name)
        {
            return dtd.LayNCC(name);
        }
        public List<Supplier> timNCC(string name)
        {
            return dtd.TimNCC(name);
        }

        public List<Supplier> getAll()
        {
            return dtd.getAll();
        }
        public string ThemNCC(Supplier dt)
        {
            return dtd.ThemNCC(dt);
        }
        public string XoaNCC(int id)
        {
            return dtd.XoaNCC(id);
        }
        public string SuaNCC(Supplier dt)
        {
            return dtd.SuaNCC(dt);
        }
    }
}