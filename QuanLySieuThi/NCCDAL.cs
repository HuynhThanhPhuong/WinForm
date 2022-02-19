using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class NCCDAL
    {
        KetNoi kn = new KetNoi();
        SqlCommand cmd;
        SqlDataAdapter apt;
        public DataTable TatCaMatHang()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM NCC";
            cmd = new SqlCommand(sql, kn.getKetNoi());
            apt = new SqlDataAdapter(cmd);
            apt.Fill(dt);
            return dt;
        }
        public void ThemNCC(NCC ncc)
        {

            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "INSERT INTO NCC VALUES(@MaNCC,@TenNCC,@DiaChi,@DienThoai)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaNCC", SqlDbType.Int).Value = ncc.MaNCC;
                cmd.Parameters.Add("@TenNCC", SqlDbType.NVarChar).Value = ncc.TenNCC;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = ncc.DiaChi;
                cmd.Parameters.Add("@DienThoai", SqlDbType.NChar).Value = ncc.DienThoai;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
        public void SuaNCC(NCC ncc)
        {
            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "UPDATE NCC SET TenNCC=@TenNCC,DiaChi=@DiaChi,DienThoai=@DienThoai WHERE MaNCC=@MaNCC";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaNCC", SqlDbType.Int).Value = ncc.MaNCC;
                cmd.Parameters.Add("@TenNCC", SqlDbType.NVarChar).Value = ncc.TenNCC;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = ncc.DiaChi;
                cmd.Parameters.Add("@DienThoai", SqlDbType.NChar).Value = ncc.DienThoai;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
        public void XoaNCC(string mancc)
        {
            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = " DELETE FROM NCC WHERE MaNCC=@MaNCC";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaNCC", SqlDbType.Int).Value = mancc;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
    }
}
