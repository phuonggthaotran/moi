using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA3Last.Models
{
    public class DonDatHang
    {
        public KhachHang Khach { get; set; }
        public double TongTien { get; set; }
        public List<GioHang> LCtDonHang { get; set; }
    }
}