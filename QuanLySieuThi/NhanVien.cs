using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class NhanVien
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public float Luong { get; set; }
        public int MaCV { get; set; }
        public NhanVien() { }
        public NhanVien(int manv, string tennv, DateTime ns, string cmnd, string diachi, string sdt, DateTime ngayvaolam,float luong, int macv)
        {
            this.MaNV = manv;
            this.HoTen = tennv;
            this.NgaySinh = ns;
            this.CMND = cmnd;
            this.DiaChi = diachi;
            this.SoDienThoai = sdt;
            this.NgayVaoLam = ngayvaolam;
            this.Luong = luong;
            this.MaCV = macv;
        }
    }
}
