using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class KHTTDAL
    {
        KetNoi kn = new KetNoi();
        SqlCommand cmd;
        SqlDataAdapter apt;
        public DataTable TatCaKH()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM KHTT";
            cmd = new SqlCommand(sql, kn.getKetNoi());
            apt = new SqlDataAdapter(cmd);
            apt.Fill(dt);
            return dt;
        }
        public void ThemKH(KHTT kh)
        {

            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "INSERT INTO KHTT VALUES(@MaKH,@HoTen,@DiaChi,@NgayCapThe,@NgayMuaGanNhat,@DiemThuong)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = kh.MaKH;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = kh.HoTen;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = kh.DiaChi;
                cmd.Parameters.Add("@NgayCapThe", SqlDbType.DateTime).Value = kh.NgayCapThe;
                cmd.Parameters.Add("@NgayMuaGanNhat", SqlDbType.DateTime).Value = kh.NgayMuaGanNhat;
                cmd.Parameters.Add("@DiemThuong", SqlDbType.Int).Value = kh.DiemThuong;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
        public void SuaKH(KHTT kh)
        {

            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "UPDATE KHTT SET HoTen=@HoTen,DiaChi=@DiaChi,NgayCapThe=@NgayCapThe,NgayMuaGanNhat=@NgayMuaGanNhat,DiemThuong=@DiemThuong WHERE MaKH=@MaKH";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = kh.MaKH;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = kh.HoTen;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = kh.DiaChi;
                cmd.Parameters.Add("@NgayCapThe", SqlDbType.DateTime).Value = kh.NgayCapThe;
                cmd.Parameters.Add("@NgayMuaGanNhat", SqlDbType.DateTime).Value = kh.NgayMuaGanNhat;
                cmd.Parameters.Add("@DiemThuong", SqlDbType.Int).Value = kh.DiemThuong;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
        public void XoaKH(string makh)
        {

            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "DELETE FROM KHTT WHERE MaKH=@MaKH";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = makh;
               
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
    }
}
