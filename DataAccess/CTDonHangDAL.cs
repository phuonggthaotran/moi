using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DA3Last.Models;

namespace DA3Last.DataAccess
{
    public class CTDonHangDAL
    {
        DataHelper dc = new DataHelper(@"DESKTOP-7R75IKF", "TuLanShopDB", "sa", "1");
        public void LuuCTDonHang(List<GioHang> lct)
        {
            // Chuyển list thành table
            DataTable dt = new DataTable();
            DataColumn c3 = new DataColumn("product_name");
            DataColumn c4 = new DataColumn("image");
            DataColumn c5 = new DataColumn("price");
           
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);
            
            for (int i = 0; i < lct.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = lct[i].product_name;
                dr[1] = lct[i].image;
                dr[2] = lct[i].price;
                
                dt.Rows.Add(dr);
            }
            dc.UpdateDataTable(dt, "CTDonHang");
        }
    }
}