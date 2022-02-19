using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class CTHD
    {
        public int MaHD { get; set; }
        public string MaMH { get; set; }
        public int SoLuong { get; set; }
        public CTHD() { }
        public CTHD(int mahd,string mamh,int soluong)
        {
            this.MaHD = mahd;
            this.MaMH = mamh;
            this.SoLuong = soluong;
        }
    }
}
