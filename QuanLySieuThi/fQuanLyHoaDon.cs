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
    public partial class fQuanLyHoaDon : Form
    {
        HoaDonDAL hdDAL = new HoaDonDAL();
        public fQuanLyHoaDon()
        {
            InitializeComponent();
        }
        int vt = -1;
        protected void loadDSHoaDon()
        {
            dgvHoaDon.DataSource = hdDAL.TatCaHoaDon();
        }
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt >= 0 && vt < dgvHoaDon.Rows.Count)
            {
                txtMaHD.Text = dgvHoaDon.Rows[vt].Cells[0].Value.ToString();
                dtNgayLap.Text = dgvHoaDon.Rows[vt].Cells[1].Value.ToString();
                txtSoLuong.Text = dgvHoaDon.Rows[vt].Cells[2].Value.ToString();
                txtTien.Text = dgvHoaDon.Rows[vt].Cells[3].Value.ToString();
                txtMaMH.Text = dgvHoaDon.Rows[vt].Cells[4].Value.ToString();

            }
        }

        private void fQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            loadDSHoaDon();
        }


        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtTien.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtTien.Text);
            tt =  dg* sl;
            txtTongTien.Text = tt.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaHD.Text == "" || dtNgayLap.Text == "" || txtSoLuong.Text == "" || txtTien.Text == "" || txtMaMH.Text == "")
                    throw new Exception("Thông tin chưa đầy đủ");
                DateTime ngaylap = DateTime.Parse(dtNgayLap.Text);
                int mahd=int.Parse(txtMaHD.Text);
                string mamh = txtMaMH.Text;
                float dongia = float.Parse(txtTien.Text);
                int soluong = int.Parse(txtSoLuong.Text);
                HoaDon hd = new HoaDon(mahd, ngaylap, soluong, dongia, mamh);
                hdDAL.ThemHoaDon(hd);
                loadDSHoaDon();
                MessageBox.Show("Thêm hóa đơn thành công");

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
                if (vt < 0 || vt >= dgvHoaDon.Rows.Count)
                    throw new Exception("Chưa chọn sinh viên cần xóa!");
                string mahd = txtMaHD.Text.Trim();
                hdDAL.XoaHoaDon(mahd);
                loadDSHoaDon();
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
