using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class LoaiHang
    {
        public int MaLH { get; set; }
        public string TenLH { get; set; }
        public LoaiHang() { }
        public LoaiHang(int malh,string tenlh)
        {
            this.MaLH = malh;
            this.TenLH = tenlh;
        }
    }
}
