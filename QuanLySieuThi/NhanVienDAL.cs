using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class NhanVienDAL
    {
        KetNoi kn = new KetNoi();
        SqlCommand cmd;
        SqlDataAdapter apt;
        public DataTable TatCaNhanVien()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT NhanVien.MaNV,NhanVien.HoTen,NhanVien.NgaySinh,NhanVien.CMND,NhanVien.DiaChi,NhanVien.SoDienThoai,NhanVien.NgayVaoLam,NhanVien.Luong,ChucVu.TenCV FROM NhanVien INNER JOIN ChucVu ON NhanVien.MaCV=ChucVu.MaCV";
            cmd = new SqlCommand(sql, kn.getKetNoi());
            apt = new SqlDataAdapter(cmd);
            apt.Fill(dt);
            return dt;
        }
        public void ThemNhanVien(NhanVien nv)
        {

            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "INSERT INTO NhanVien VALUES(@MaNV,@HoTen,@NgaySinh,@CMND,@DiaChi,@SoDienThoai,@NgayVaoLam,@Luong,@MaCV)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = nv.MaNV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = nv.HoTen;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = nv.NgaySinh;
                cmd.Parameters.Add("@CMND", SqlDbType.NVarChar).Value = nv.CMND;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nv.DiaChi;
                cmd.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = nv.SoDienThoai;
                cmd.Parameters.Add("@NgayVaoLam", SqlDbType.DateTime).Value = nv.NgayVaoLam;
                cmd.Parameters.Add("@Luong", SqlDbType.Float).Value = nv.Luong;
                cmd.Parameters.Add("@MaCV", SqlDbType.Int).Value = nv.MaCV;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
        public void SuaNhanVien(NhanVien nv)
        {

            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "UPDATE NhanVien SET HoTen=@HoTen,NgaySinh=@NgaySinh,CMND=@CMND,DiaChi=@DiaChi,SoDienThoai=@SoDienThoai,NgayVaoLam=@NgayVaoLam,Luong=@Luong,MaCV=@MACV WHERE MaNV=@MaNV";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = nv.MaNV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = nv.HoTen;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = nv.NgaySinh;
                cmd.Parameters.Add("@CMND", SqlDbType.NVarChar).Value = nv.CMND;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nv.DiaChi;
                cmd.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = nv.SoDienThoai;
                cmd.Parameters.Add("@NgayVaoLam", SqlDbType.DateTime).Value = nv.NgayVaoLam;
                cmd.Parameters.Add("@Luong", SqlDbType.Float).Value = nv.Luong;
                cmd.Parameters.Add("@MaCV", SqlDbType.Int).Value = nv.MaCV;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
        public void XoaNhanVien(string manv)
        {

            {
                SqlConnection conn = kn.getKetNoi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string sql = "DELETE FROM NhanVien WHERE MaNV=@MaNV";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = manv;
                cmd.ExecuteNonQuery(); conn.Close();
            }
        }
    }
}
