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
    public partial class fQuanlyLoaiHang : Form
    {
        LoaiHangDAL lhDAL = new LoaiHangDAL();
        public fQuanlyLoaiHang()
        {
            InitializeComponent();
        }
        int vt = -1;
        protected void loadDSLoaiHang()
        {
            dgvLoaiHang.DataSource = lhDAL.TatCaLoaiHang();
        }

        private void fQuanlyLoaiHang_Load(object sender, EventArgs e)
        {
            loadDSLoaiHang();
        }

        private void dgvLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt >= 0 && vt < dgvLoaiHang.Rows.Count)
            {
                txtMaLH.Text = dgvLoaiHang.Rows[vt].Cells[0].Value.ToString();
                txtTenLH.Text = dgvLoaiHang.Rows[vt].Cells[1].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaLH.Text == "" || txtTenLH.Text == "")
                    throw new Exception("Thông tin chưa đầy đủ");
                int malh =Int16.Parse( txtMaLH.Text);
                string tenlh = txtTenLH.Text;
                LoaiHang lh = new LoaiHang(malh, tenlh);
                lhDAL.ThemLoaiHang(lh);
                loadDSLoaiHang();
                MessageBox.Show("Thêm Loại hàng thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (vt < 0 || vt >= dgvLoaiHang.Rows.Count)
                    throw new Exception("Chưa chọn loại hàng cần sữa!");
                if (txtMaLH.Text == "" || txtTenLH.Text == "")
                    throw new Exception("Thông tin chưa đầy đủ");
                int malh = Int16.Parse(txtMaLH.Text);
                string tenlh = txtTenLH.Text;
                LoaiHang lh = new LoaiHang(malh, tenlh);
                lhDAL.SuaLoaiHang(lh);
                loadDSLoaiHang();
                MessageBox.Show("Cập nhật Loại hàng thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (vt < 0 || vt >= dgvLoaiHang.Rows.Count)
                    throw new Exception("Chưa chọn loại hàng cần xóa!");
                string malh = txtMaLH.Text.Trim();
                lhDAL.XoaLoaiHang(malh);
                loadDSLoaiHang();
                MessageBox.Show("Xóa Loại hàng thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thật sự muốn thoát?", "Cảnh báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

    }
}
