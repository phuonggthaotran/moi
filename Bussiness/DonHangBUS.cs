using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA3Last.Models;
using DA3Last.DataAccess;

namespace DA3Last.Bussiness
{
    public class DonHangBUS
    {
        DonHangDAL dhd = new DonHangDAL();
        public string themdonhang(Donhang d)
        {
            return dhd.ThemDonHang(d);
        }
        public List<Donhang> getngaydat(string ngay, string thang, string nam)
        {
            return dhd.getngaydat(ngay, thang, nam);
        }
        public List<Donhang> gettrangthai(string trangthai)
        {
            return dhd.gettrangthai(trangthai);
        }
        public List<Donhang> getdonhang()
        {
            return dhd.getdonhang();
        }
        public string xoa()
        {
            return dhd.xoa();
        }
        public string xoadonhang(int id)
        {
            return dhd.xoadonhang(id);
        }
        public string suadonhang(Donhang d)
        {
            return dhd.suadonhang(d);
        }
    }
}