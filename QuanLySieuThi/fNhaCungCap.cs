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
    public partial class fNhaCungCap : Form
    {
        NCCDAL nccDAL = new NCCDAL();
        public fNhaCungCap()
        {
            InitializeComponent();
        }
        int vt = -1;
        protected void loadDSNCC()
        {
            dgvNCC.DataSource = nccDAL.TatCaMatHang();
        }
        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt >= 0 && vt < dgvNCC.Rows.Count)
            {
                txtMaNCC.Text = dgvNCC.Rows[vt].Cells[0].Value.ToString();
                txtTenNCC.Text = dgvNCC.Rows[vt].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvNCC.Rows[vt].Cells[2].Value.ToString();
                txtDienThoai.Text = dgvNCC.Rows[vt].Cells[3].Value.ToString();
            }
        }

        private void fNhaCungCap_Load(object sender, EventArgs e)
        {
            loadDSNCC();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNCC.Text == "" || txtTenNCC.Text == "" || txtDiaChi.Text == "" || txtDienThoai.Text == "")
                    throw new Exception("Thông tin chưa đầy đủ");
                int mancc = int.Parse(txtMaNCC.Text);
                string tenncc = txtTenNCC.Text;
                string diachi = txtDiaChi.Text;
                string dienthoai = txtDienThoai.Text;
                NCC ncc = new NCC(mancc, tenncc, diachi, dienthoai);
                nccDAL.ThemNCC(ncc);
                loadDSNCC();
                MessageBox.Show("Thêm nhà cung cấp thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (vt < 0 || vt >= dgvNCC.Rows.Count)
                    throw new Exception("Chưa chọn nhà cung cấp cần sửa!");
                if (txtMaNCC.Text == "" || txtTenNCC.Text == "" || txtDiaChi.Text == "" || txtDienThoai.Text == "")
                    throw new Exception("Thông tin chưa đầy đủ");
               int mancc = int.Parse(txtMaNCC.Text);
                string tenncc = txtTenNCC.Text;
                string diachi = txtDiaChi.Text;
                string dienthoai = txtDienThoai.Text;
                NCC ncc = new NCC(mancc, tenncc, diachi, dienthoai);
                nccDAL.SuaNCC(ncc);
                loadDSNCC();
                MessageBox.Show("Sửa cung cấp thành công thành công");

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
                if (vt < 0 || vt >= dgvNCC.Rows.Count)
                    throw new Exception("Chưa chọn loại hàng cần xóa!");
                string mancc = txtMaNCC.Text.Trim();
                nccDAL.XoaNCC(mancc);
                loadDSNCC();
                MessageBox.Show("Xóa nhà cung cấp thành công");

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
