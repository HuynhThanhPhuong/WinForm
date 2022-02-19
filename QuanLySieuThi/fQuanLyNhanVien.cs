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
    public partial class fQuanLyNhanVien : Form
    {
        NhanVienDAL nvDAL = new NhanVienDAL();
        ChucVuDAL cvDAL = new ChucVuDAL();
        public fQuanLyNhanVien()
        {
            InitializeComponent();
        }
        int vt = -1;
        protected void loadDSNhanVien()
        {
            dgvNhanVien.DataSource = nvDAL.TatCaNhanVien();
        }
        protected void loadDSChucVu()
        {
            cbChucVu.DataSource = cvDAL.TatCaChucVu();
            cbChucVu.DisplayMember = "TenCV";
            cbChucVu.ValueMember = "MaCV";
        }

        private void fQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            loadDSNhanVien();
            loadDSChucVu();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt >= 0 && vt < dgvNhanVien.Rows.Count)
            {
                txtMaNV.Text = dgvNhanVien.Rows[vt].Cells[0].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[vt].Cells[1].Value.ToString();
                txtNgaySinh.Text = dgvNhanVien.Rows[vt].Cells[2].Value.ToString();
                txtCMND.Text = dgvNhanVien.Rows[vt].Cells[3].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.Rows[vt].Cells[4].Value.ToString();
                txtSDT.Text = dgvNhanVien.Rows[vt].Cells[5].Value.ToString();
                txtNgayVaoLam.Text = dgvNhanVien.Rows[vt].Cells[6].Value.ToString();
                txtLuong.Text = dgvNhanVien.Rows[vt].Cells[7].Value.ToString();
                string tencv = dgvNhanVien.Rows[vt].Cells[8].Value.ToString();
                int macv = cvDAL.LayMaChucVu(tencv);
                cbChucVu.SelectedValue = macv;
                txtMaNV.Enabled = true;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtNgaySinh.Text == "" || txtCMND.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtNgayVaoLam.Text == "" || txtLuong.Text == "" || cbChucVu.Text == "")
                    throw new Exception("Thông tin chưa đầy đủ");
                DateTime ns = DateTime.Parse(txtNgaySinh.Text);
                DateTime ngayvaolam = DateTime.Parse(txtNgayVaoLam.Text);
                int manv = int.Parse(txtMaNV.Text);
                float luong = float.Parse(txtLuong.Text);
                string tennv = txtTenNV.Text;
                string cmnd = txtCMND.Text;
                string diachi = txtDiaChi.Text;
                string sdt = txtSDT.Text;
                int macv = int.Parse(cbChucVu.SelectedValue.ToString());
                NhanVien nv = new NhanVien(manv, tennv, ns, cmnd, diachi, sdt, ngayvaolam,luong, macv);
                nvDAL.ThemNhanVien(nv);
                loadDSNhanVien();
                MessageBox.Show("Thêm nhân viên thành công");

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
                if (vt < 0 || vt >= dgvNhanVien.Rows.Count)
                    throw new Exception("Chưa chọn nhân viên cần sửa!");
                if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtNgaySinh.Text == "" || txtCMND.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtNgayVaoLam.Text == "" || cbChucVu.Text == "")
                    throw new Exception("Thông tin chưa đầy đủ");
                DateTime ns = DateTime.Parse(txtNgaySinh.Text);
                DateTime ngayvaolam = DateTime.Parse(txtNgayVaoLam.Text);
                int manv = int.Parse(txtMaNV.Text);
                float luong = float.Parse(txtLuong.Text);
                string tennv = txtTenNV.Text;
                string cmnd = txtCMND.Text;
                string diachi = txtDiaChi.Text;
                string sdt = txtSDT.Text;
                int macv = int.Parse(cbChucVu.SelectedValue.ToString());
                NhanVien nv = new NhanVien(manv, tennv, ns, cmnd, diachi, sdt, ngayvaolam,luong, macv);
                nvDAL.SuaNhanVien(nv);
                loadDSNhanVien();
                MessageBox.Show("Cập nhật nhân viên thành công");

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
                if (vt < 0 || vt >= dgvNhanVien.Rows.Count)
                    throw new Exception("Chưa chọn sinh viên cần xóa!");
                string manv = txtMaNV.Text.Trim();
                nvDAL.XoaNhanVien(manv);
                loadDSNhanVien();
                MessageBox.Show("Xóa sinh viên thành công");
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
