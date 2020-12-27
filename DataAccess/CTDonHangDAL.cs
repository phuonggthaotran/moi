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
        public void LuuCTDonHang(List<CTDonHang> lct)
        {
            // Chuyển list thành table
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("id");
            DataColumn c2 = new DataColumn("order_id");
            DataColumn c3 = new DataColumn("product_name");
            DataColumn c4 = new DataColumn("image");
            DataColumn c5 = new DataColumn("price");
           
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);
            
            for (int i = 0; i < lct.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[1] = lct[i].id;
                dr[2] = lct[i].order_id;
                dr[3] = lct[i].product_name;
                dr[4] = lct[i].image;
                dr[5] = lct[i].price;
                
                dt.Rows.Add(dr);
            }
            dc.UpdateDataTable(dt, "CTDonHang");
        }
    }
}