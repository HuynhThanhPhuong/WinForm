using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class MatHangDAL
    {
        KetNoi kn = new KetNoi();
        SqlCommand cmd;
        SqlDataAdapter apt;
        public DataTable TatCaMatHang()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MatHang.MaMH,MatHang.TenMH,MatHang.NgaySX,MatHang.GiaMua,MatHang.GiaBan,MatHang.NgayNhap,LoaiHang.TenLH FROM MatHang INNER JOIN LoaiHang ON MatHang.MaLH=LoaiHang.MaLH";
            cmd = new SqlCommand(sql, kn.getKetNoi());
            apt = new SqlDataAdapter(cmd);
            apt.Fill(dt);
            return dt;
        }
        public void ThemMatHang(MatHang mh)
        {

            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "INSERT INTO MatHang VALUES(@MaMH,@TenMH,@NgaySX,@GiaMua,@GiaBan,@NgayNhap,@MaLH)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaMH", SqlDbType.NChar).Value = mh.MaMH;
                cmd.Parameters.Add("@TenMH", SqlDbType.NVarChar).Value = mh.TenMH;
                cmd.Parameters.Add("@NgaySX", SqlDbType.DateTime).Value = mh.NgaySX;
                cmd.Parameters.Add("@GiaMua", SqlDbType.Float).Value = mh.GiaMua;
                cmd.Parameters.Add("@GiaBan", SqlDbType.Float).Value = mh.GiaBan;
                cmd.Parameters.Add("@NgayNhap", SqlDbType.DateTime).Value = mh.NgayNhap;
                cmd.Parameters.Add("@MaLH", SqlDbType.Int).Value = mh.MaLH;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
        public void SuaMatHang(MatHang mh)
        {
            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "UPDATE MatHang SET TenMH=@TenMH,NgaySX=@NgaySX,GiaMua=@GiaMua,GiaBan=@GiaBan,NgayNhap=@NgayNhap,MaLH=@MaLH WHERE MaMH=@MaMH";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaMH", SqlDbType.NChar).Value = mh.MaMH;
                cmd.Parameters.Add("@TenMH", SqlDbType.NVarChar).Value = mh.TenMH;
                cmd.Parameters.Add("@NgaySX", SqlDbType.DateTime).Value = mh.NgaySX;
                cmd.Parameters.Add("@GiaMua", SqlDbType.Float).Value = mh.GiaMua;
                cmd.Parameters.Add("@GiaBan", SqlDbType.Float).Value = mh.GiaBan;
                cmd.Parameters.Add("@NgayNhap", SqlDbType.NVarChar).Value = mh.NgayNhap;
                cmd.Parameters.Add("@MaLH", SqlDbType.NVarChar).Value = mh.MaLH;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
        public void XoaMatHang(string mamh)
        {
            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = " DELETE FROM MatHang WHERE MaMH=@MaMH";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaMH", SqlDbType.NVarChar).Value = mamh;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
    }
}
