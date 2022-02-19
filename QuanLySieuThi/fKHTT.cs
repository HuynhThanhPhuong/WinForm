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
    public partial class fKHTT : Form
    {
        KHTTDAL khDAL = new KHTTDAL();
        public fKHTT()
        {
            InitializeComponent();
        }
        int vt = -1;
        protected void loadDSKH()
        {
            dgvKHTT.DataSource = khDAL.TatCaKH();
        }

        private void fKHTT_Load(object sender, EventArgs e)
        {
            loadDSKH();
        }

        private void dgvKHTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt >= 0 && vt < dgvKHTT.Rows.Count)
            {
                txtMaKH.Text = dgvKHTT.Rows[vt].Cells[0].Value.ToString();
                txtHoTen.Text = dgvKHTT.Rows[vt].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvKHTT.Rows[vt].Cells[2].Value.ToString();
                dtNgayCapThe.Text = dgvKHTT.Rows[vt].Cells[3].Value.ToString();
                dtNgayMua.Text = dgvKHTT.Rows[vt].Cells[4].Value.ToString();
                txtDiemThuong.Text = dgvKHTT.Rows[vt].Cells[5].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text == "" || txtHoTen.Text == "" || txtDiaChi.Text == "" || dtNgayCapThe.Text == "" || dtNgayMua.Text == "" || txtDiemThuong.Text == "")
                    throw new Exception("Thông tin chưa đầy đủ");
                int malh = int.Parse(txtMaKH.Text);
                string hoten = txtHoTen.Text;
                string diachi = txtDiaChi.Text;
                DateTime nct = DateTime.Parse(dtNgayCapThe.Text);
                DateTime nmg = DateTime.Parse(dtNgayMua.Text);
                int diemthuong = int.Parse(txtDiemThuong.Text);
                KHTT kh = new KHTT(malh, hoten,diachi, nct, nmg,diemthuong);
                khDAL.ThemKH(kh);
                loadDSKH();
                MessageBox.Show("Thêm khách hàng thành công");

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
                if (vt < 0 || vt >= dgvKHTT.Rows.Count)
                    throw new Exception("Chưa chọn khách hàng cần sữa!");
                if (txtMaKH.Text == "" || txtHoTen.Text == "" || txtDiaChi.Text == "" || dtNgayCapThe.Text == "" || dtNgayMua.Text == "")
                    throw new Exception("Thông tin chưa đầy đủ");
                int malh = int.Parse(txtMaKH.Text);
                string hoten = txtHoTen.Text;
                string diachi = txtDiaChi.Text;
                int diemthuong = int.Parse(txtDiemThuong.Text);
                DateTime nct = DateTime.Parse(dtNgayCapThe.Text);
                DateTime nmg = DateTime.Parse(dtNgayMua.Text);
                KHTT kh = new KHTT(malh, hoten, diachi, nct, nmg, diemthuong);
                khDAL.SuaKH(kh);
                loadDSKH();
                MessageBox.Show("Sửa khách hàng thành công");

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
                if (vt < 0 || vt >= dgvKHTT.Rows.Count)
                    throw new Exception("Chưa chọn loại hàng cần xóa!");
                string malh = txtMaKH.Text.Trim();
                khDAL.XoaKH(malh);
                loadDSKH();
                MessageBox.Show("Xóa Khách hàng thành công");

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
