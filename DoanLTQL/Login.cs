using BUS;
using GUI;
using Guna.UI2.WinForms;

namespace DoanLTQL
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            SetUp();
        }

        public void SetUp()
        {
            //Chỉnh kích thước của form lại và ẩn panel đăng ký đi
            this.Size = new Size(this.Panel_dangnhap.Width, 659);
            Panel_dangky.Hide();

            //Chỉnh dấu panel_key và chỉ kích hoạt khi người dùng chọn tạo tài khoản cho admin | quản lý
            panel_key.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /* Nếu đăng ký với vai trò quản lý thì sẽ hiện panel yêu cầu người dùng nhập lisecne key */
        private void tgl_quanly_CheckedChanged(object sender, EventArgs e)
        {
            Guna2ToggleSwitch obj = (Guna2ToggleSwitch)sender;
            if (obj.Checked)
            {
                panel_key.Show();
            }
            else
            {
                panel_key.Hide();
            }
        }

        private void TextBox_Double_Click(object sender, EventArgs e)
        {
            Guna2TextBox txt = (Guna2TextBox)sender;
            txt.SelectAll();
        }


        /* Đổi sang form đăng ký hoặc ngược lại */
        public void ChuyenForm(int i)
        {
            if (i == 1)
            {
                Panel_dangnhap.Hide();
                Panel_dangky.Show();
            }
            else
            {
                Panel_dangnhap.Show();
                Panel_dangky.Hide();
            }

        }

        #region Liên Quan Đến Nút Đăng Ký

        private void btn_dangky_Click_1(object sender, EventArgs e)
        {
            ChuyenForm(1);
        }


        /* Đăng Ký Tài Khoản*/
        private void btn_dangky_dangky_Click(object sender, EventArgs e)
        {
            string tk = txt_dangky_taikhoan.Text;
            string mk = txt_dangky_matkhau.Text;
            string mk2 = txt_dangky_matkhau2.Text;

            if (tk.Length == 0)
            {
                MessageBox.Show(@"Vui lòng nhâp tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_dangky_taikhoan.Focus();
                return;
            }

            if (mk.Length == 0)
            {
                MessageBox.Show(@"Vui lòng nhâp mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_dangky_matkhau.Focus();
                return;
            }

            if (!mk.Equals(mk2))
            {
                MessageBox.Show(@"Xác nhận mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_dangky_matkhau2.Focus();
                return;
            }

            var kiemtra = BUS_Taikhoan.Select_By_TaiKhoan(tk);

            if (kiemtra != null)
            {
                MessageBox.Show(@"Tên tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_dangky_taikhoan.Focus();
                return;
            }


            /* Kiễm tra xem người dùng tạo tài khoản quản lý hay nhân viên */
            if (panel_key.Visible)
            {
                string liscence = txt_key.Text;
                if (liscence != "2444")/* Tài khoản quản lý phải nhập đúng lisence key */
                {
                    MessageBox.Show(@"Mã xác nhận không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_key.Focus();
                    return;
                }
                else
                {
                    BUS_Taikhoan.Insert(tk, mk, 1);
                }

            }
            else
            {
                BUS_Taikhoan.Insert(tk, mk, 2);
            }

            MessageBox.Show(@"Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ChuyenForm(2);
        }
        #endregion


        #region Liên Quan Đến Sự Kiện Hover
        private void lbl_quaylai_MouseEnter(object sender, EventArgs e)
        {
            Label obj = (Label)sender;
            lbl_quaylai.ForeColor = Color.FromArgb(250, 112, 112);

            ChuyenForm(2);
        }

        private void lbl_quaylai_MouseLeave(object sender, EventArgs e)
        {
            Label obj = (Label)sender;
            lbl_quaylai.ForeColor = Color.Black;

            ChuyenForm(2);
        }
        #endregion


        /*Xử lý khi click nút đăng nhập*/
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string tk = txt_dangnhap_account.Text;
            string mk = txt_dangnhap_matkhau.Text;

            /* Kiễm tra tài khoản */
            bool kiemtra = BUS_Taikhoan.KiemTraTaiKhoan(tk, mk);

            if (!kiemtra)
            {
                MessageBox.Show(@"Tài khoản hay mật khẩu không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_dangnhap_account.Focus();
                return;
            }
            else
            {
                MessageBox.Show(@"Đăng nhập thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                /* Lấy loại tài khoản để hiển thị */

                int LoaiDangNhap = (int)BUS_Taikhoan.Select_By_TaiKhoan(tk).MaCV;
                DashBoard dashBoard = new DashBoard(LoaiDangNhap);
                /* Ẩn form đăng nhập */
                this.Hide();
                if (dashBoard.ShowDialog() == DialogResult.Cancel) { this.Close(); }
            }
        }
    }
}