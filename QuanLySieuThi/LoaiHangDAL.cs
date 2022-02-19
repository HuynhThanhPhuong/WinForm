using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class LoaiHangDAL
    {
        KetNoi kn = new KetNoi();
        SqlCommand cmd;
        SqlDataAdapter apt;
        public DataTable TatCaLoaiHang()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM LoaiHang";
            cmd = new SqlCommand(sql, kn.getKetNoi());
            apt = new SqlDataAdapter(cmd);
            apt.Fill(dt);
            return dt;
        }
        public int LayMaLoaiHang(string tenlh)
        {
            SqlConnection conn = kn.getKetNoi();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string sql = "SELECT MaLH FROM LoaiHang WHERE TenLH=@TenLH";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@TenLH", SqlDbType.NVarChar).Value = tenlh;
            int malh = int.Parse(cmd.ExecuteScalar().ToString());
            return malh;
        }

        public void ThemLoaiHang(LoaiHang lh)
        {

            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "INSERT INTO LoaiHang VALUES(@MaLH,@TenLH)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaLH", SqlDbType.Int).Value = lh.MaLH;
                cmd.Parameters.Add("@TenLH", SqlDbType.NVarChar).Value = lh.TenLH;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
        public void SuaLoaiHang(LoaiHang lh)
        {
            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "UPDATE LoaiHang SET TenLH=@TenLH WHERE MaLH=@MaLH";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaLH", SqlDbType.Int).Value = lh.MaLH;
                cmd.Parameters.Add("@TenLH", SqlDbType.NVarChar).Value = lh.TenLH;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
        public void XoaLoaiHang(string malh)
        {
            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = " DELETE FROM LoaiHang WHERE MaLH=@MaLH";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaLH", SqlDbType.Int).Value = malh;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
    }
}
