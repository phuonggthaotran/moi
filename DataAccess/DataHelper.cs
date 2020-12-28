using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DA3Last.DataAccess
{
    public class DataHelper
    {
        string strcon;
        SqlConnection con;


        public DataHelper(string sever, string dataName, string id, string passw)
        {
            strcon = "Data Source=" + sever + " ;Initial Catalog=" +
            dataName + " ;User ID=" + id + " ;Password=" + passw;
            con = new SqlConnection(strcon);
        }
        public void moketnoi()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void dongketnoi()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public string ExcuteNonQuery(string sql)
        {
            moketnoi();
            try
            {
                SqlCommand cm = new SqlCommand(sql, con);
                cm.ExecuteNonQuery();
                return "";
            }
            catch (SqlException e)
            {
                return e.Message;
                //throw new Exception(e.Message);
                //if (e.Message.Contains("") )
            }
        }
        public DataTable laydulieu(string sqlselect)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
            da.Fill(dt);
            return dt;
        }
        public void UpdateDataTable(DataTable dt, string tenbang)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from " + tenbang + "", con);
            SqlCommandBuilder cm = new SqlCommandBuilder(da);
            da.Update(dt);
        }
        //Phan trang
        public SqlDataReader StoreReaders(string tenStore, params object[] giatri)
        {

            SqlCommand cm;

            moketnoi();
            try
            {
                cm = new SqlCommand(tenStore, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                SqlDataReader dr = cm.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;

            }

        }
    }
}