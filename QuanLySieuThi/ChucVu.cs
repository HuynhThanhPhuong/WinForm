using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class ChucVu
    {
        public int MaCONGCONG { get; set; }
        public string TenCV { get; set; }
        public ChucVu() { }
        public ChucVu(int macv,string tencv)
        {
            this.MaCV = macv;
            this.TenCV = tencv;
        }
    }
}
