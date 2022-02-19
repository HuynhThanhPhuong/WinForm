using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class ChucVuDAL
    {
        KetNoi kn = new KetNoi();
        SqlCommand cmd;
        SqlDataAdapter apt;
        public DataTable TatCaChucVu()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM ChucVu";
            cmd = new SqlCommand(sql, kn.getKetNoi());
            apt = new SqlDataAdapter(cmd);
            apt.Fill(dt);
            return dt;
        }
        public int LayMaChucVu(string tencv)
        {
            SqlConnection conn = kn.getKetNoi();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT MaCV FROM ChucVu WHERE TenCV=@TenCV";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@TenCV", SqlDbType.NVarChar).Value = tencv;
            int macv = int.Parse(cmd.ExecuteScalar().ToString());
            return macv;
        }
    }
}
