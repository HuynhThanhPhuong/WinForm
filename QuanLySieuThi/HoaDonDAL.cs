using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class HoaDonDAL
    {
        KetNoi kn = new KetNoi();
        SqlCommand cmd;
        SqlDataAdapter apt;
        public DataTable TatCaHoaDon()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT HoaDon.MaHD,HoaDon.NgayLap,HoaDon.SoLuong,HoaDon.TongTienTra,MatHang.TenMH FROM HoaDon INNER JOIN MatHang ON HoaDon.MaMH=MatHang.MaMH";
            cmd = new SqlCommand(sql, kn.getKetNoi());
            apt = new SqlDataAdapter(cmd);
            apt.Fill(dt);
            return dt;
        }
        public void ThemHoaDon(HoaDon hd)
        {

            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "INSERT INTO HoaDon VALUES(@MaHD,@NgayLap,@SoLuong,@TongTienTra,@MaMH)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaHD", SqlDbType.Int).Value = hd.MaHD;
                cmd.Parameters.Add("@NgayLap", SqlDbType.DateTime).Value = hd.NgayLap;
                cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = hd.SoLuong;
                cmd.Parameters.Add("@TongTienTra", SqlDbType.Float).Value = hd.TongTienTra;
                cmd.Parameters.Add("@MaMH", SqlDbType.NChar).Value = hd.MaMH;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
        public void XoaHoaDon(string mahd)
        {

            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "DELETE FROM HoaDon WHERE MaHD=@MaHD";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaHD", SqlDbType.Int).Value = mahd;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
    }
}
