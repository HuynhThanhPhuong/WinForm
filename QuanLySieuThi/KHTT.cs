using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class KHTT
    {
        public int MaKH { get; set; }
        public string HoTen { get; set; }
         public string DiaChi { get; set; }
         public DateTime NgayCapThe { get; set; }
         public DateTime NgayMuaGanNhat { get; set; }
         public int DiemThuong { get; set; }
        public KHTT() { }
        public KHTT(int makh,string hoten,string diachi,DateTime ngayct,DateTime ngaygn,int diemthuong)
        {
            this.MaKH = makh;
            this.HoTen = hoten;
            this.DiaChi = diachi;
            this.NgayCapThe = ngayct;
            this.NgayMuaGanNhat = ngaygn;
            this.DiemThuong = diemthuong;
        }
    }
}
