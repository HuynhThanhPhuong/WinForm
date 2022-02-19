using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class MatHang
    {

        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public DateTime NgaySX { get; set; }
        public float GiaMua { get; set; }
        public float GiaBan { get; set; }
        public DateTime NgayNhap { get; set; }
        public int MaLH { get; set; }
        public MatHang() { }
        public MatHang(string mamh, string tenmh, DateTime ngaysx, float giamua, float giaban, DateTime ngaynhap, int malh)
        {
            this.MaMH = mamh;
            this.TenMH = tenmh;
            this.NgaySX = ngaysx;
            this.GiaMua = giamua;
            this.GiaBan = giaban;
            this.NgayNhap = ngaynhap;
            this.MaLH = malh;
        }
    }
}