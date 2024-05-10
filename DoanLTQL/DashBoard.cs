using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DashBoard : Form
    {

        SoDoPhongControl sodophong;
        DichVuControl dichvu;
        ThanhToanControl thanhtoan;
        NhanVienControl nhanvien;
        ThemPhongControl themphong;
        int LoaiDangNhap;
        public DashBoard(int loaiDangNhap)
        {
            InitializeComponent();

            LoaiDangNhap = loaiDangNhap;

            SetUp();
        }


        public void SetUp()
        {
            sodophong = new SoDoPhongControl();
            dichvu = new DichVuControl();
            thanhtoan = new ThanhToanControl();
            nhanvien = new NhanVienControl();
            themphong = new ThemPhongControl();

            panel_right.Controls.Add(sodophong);
            panel_right.Controls.Add(dichvu);
            panel_right.Controls.Add(thanhtoan);
            panel_right.Controls.Add(nhanvien);
            panel_right.Controls.Add(themphong);

            /* Đăng nhập bằng tài khoản nhân viên*/
            if (LoaiDangNhap == 2)
            {
                btn_dichvu.Hide();
                btn_nhanvien.Hide();
                btn_themphong.Hide();
            }

            Show(sodophong);
        }

        public void HiddenAllUserControl()
        {
            foreach (var p in panel_right.Controls.OfType<UserControl>())
            {
                p.Hide();
            }
        }


        public void Show(UserControl use)
        {
            HiddenAllUserControl();
            use.Show();
        }


        public void MouseEnter_Label(object sender, EventArgs e)
        {
            var obj = (Label)sender;
            obj.ForeColor = Color.FromArgb(130, 174, 255);
        }

        public void MouseLeave_Label(object sender, EventArgs e)
        {
            var obj = (Label)sender;
            obj.ForeColor = Color.White;
        }

        private void btn_dichvu_Click(object sender, EventArgs e)
        {
            Show(dichvu);
        }

        private void btn_sodophong_Click(object sender, EventArgs e)
        {
            Show(sodophong);
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Show(thanhtoan);
        }

        private void btn_nhanvien_Click(object sender, EventArgs e)
        {
            Show(nhanvien);
        }

        private void btn_themphong_Click(object sender, EventArgs e)
        {
            Show(themphong);
        }
    }
}
