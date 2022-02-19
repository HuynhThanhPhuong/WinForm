using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void quảnLýMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyMatHang f = new fQuanLyMatHang();
            f.ShowDialog();
        }

        private void quảnLýLoạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanlyLoaiHang f = new fQuanlyLoaiHang();
            f.ShowDialog();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyNhanVien f= new fQuanLyNhanVien();
            f.ShowDialog();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyHoaDon f = new fQuanLyHoaDon();
            f.ShowDialog();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhaCungCap f = new fNhaCungCap();
            f.ShowDialog();
        }

        private void kháchHàngThânThiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKHTT f = new fKHTT();
            f.ShowDialog();
        }
    }
}
