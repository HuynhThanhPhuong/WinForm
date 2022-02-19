using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class HoaDon
    {
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        public float TongTienTra { get; set; }
        public string MaMH { get; set; }
        public HoaDon() { }
        public HoaDon(int mahd, DateTime ngaylap, int soluong, float tongtientra, string mamh)
        {
            this.MaHD = mahd;
            this.NgayLap = ngaylap;
            this.SoLuong = soluong;
            this.TongTienTra = tongtientra;
            this.MaMH = mamh;
        }
    }
}
