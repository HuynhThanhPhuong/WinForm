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
    public partial class fQuanLyMatHang : Form
    {
        MatHangDAL mhDAL = new MatHangDAL();
        LoaiHangDAL lhDAL = new LoaiHangDAL();
        public fQuanLyMatHang()
        {
            InitializeComponent();
        }
        int vt = -1;
        protected void loadDSMatHang()
        {
            dgvMatHang.DataSource = mhDAL.TatCaMatHang();
        }
        protected void loadDSLoaiHang()
        {
            cbLoaiHang.DataSource = lhDAL.TatCaLoaiHang();
            cbLoaiHang.DisplayMember = "TenLH";
            cbLoaiHang.ValueMember = "MaLH";
        }

        private void fQuanLyMatHang_Load(object sender, EventArgs e)
        {
            loadDSMatHang();
            loadDSLoaiHang();  
        }

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt >= 0 && vt < dgvMatHang.Rows.Count)
            {
                txtMaMH.Text = dgvMatHang.Rows[vt].Cells[0].Value.ToString();
                txtTenMH.Text = dgvMatHang.Rows[vt].Cells[1].Value.ToString();
                txtNgaySX.Text = dgvMatHang.Rows[vt].Cells[2].Value.ToString();
                txtGiaMua.Text = dgvMatHang.Rows[vt].Cells[3].Value.ToString();
                txtGiaBan.Text = dgvMatHang.Rows[vt].Cells[4].Value.ToString();
                txtNgayNhap.Text = dgvMatHang.Rows[vt].Cells[5].Value.ToString();
                string tenlh = dgvMatHang.Rows[vt].Cells[6].Value.ToString();
                int malh = lhDAL.LayMaLoaiHang(tenlh);
                cbLoaiHang.SelectedValue = malh;
                txtMaMH.Enabled = true;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaMH.Text == "" || txtTenMH.Text == "" || txtNgaySX.Text == "" || txtGiaMua.Text == "" || txtGiaBan.Text == "" || txtNgayNhap.Text == "" || cbLoaiHang.Text == "")
                    throw new Exception("Thông tin chưa đầy đủ");
                DateTime ngaysx = DateTime.Parse(txtNgaySX.Text);
                DateTime ngaynhap = DateTime.Parse(txtNgayNhap.Text);
                string mamh = txtMaMH.Text;
                string tenmh = txtTenMH.Text;
                float giamua=float.Parse( txtGiaMua.Text);
                float giaban = float.Parse(txtGiaBan.Text);
                int maloai = int.Parse(cbLoaiHang.SelectedValue.ToString());
                MatHang mh = new MatHang(mamh, tenmh, ngaysx, giamua, giaban, ngaynhap, maloai);
                mhDAL.ThemMatHang(mh);
                loadDSMatHang();
                MessageBox.Show("Thêm mặt hàng thành công");

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

                if (vt < 0 || vt >= dgvMatHang.Rows.Count)
                    throw new Exception("Chưa chọn mặt hàng cần sửa!");
                if (txtMaMH.Text == "" || txtTenMH.Text == "" || txtNgaySX.Text == "" || txtGiaMua.Text == "" || txtGiaBan.Text == "" || txtNgayNhap.Text == "" || cbLoaiHang.Text == "")
                    throw new Exception("Thông tin chưa đầy đủ");
                DateTime ngaysx = DateTime.Parse(txtNgaySX.Text);
                DateTime ngaynhap = DateTime.Parse(txtNgayNhap.Text);
                string mamh = txtMaMH.Text;
                string tenmh = txtTenMH.Text;
                float giamua = float.Parse(txtGiaMua.Text);
                float giaban = float.Parse(txtGiaBan.Text);
                int maloai = int.Parse(cbLoaiHang.SelectedValue.ToString());
                MatHang mh = new MatHang(mamh, tenmh, ngaysx, giamua, giaban, ngaynhap, maloai);
                mhDAL.SuaMatHang(mh);
                loadDSMatHang();
                MessageBox.Show("Cập nhật mặt hàng thành công");

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
                if (vt< 0 || vt >= dgvMatHang.Rows.Count)
                    throw new Exception("Chưa chọn sinh viên cần xóa!");
                string mamh = txtMaMH.Text.Trim();
                mhDAL.XoaMatHang(mamh);
                loadDSMatHang();
                MessageBox.Show("Xóa mặt hàng thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thật sự muốn thoát?", "Cảnh báo", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                this.Close();
            }
        }




    }
}
