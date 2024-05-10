using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThemNhanVien : UserControl
    {
        public delegate void ThemNhanVienEventHandler();
        public ThemNhanVien()
        {
            InitializeComponent();
            UpLoadComboBoxLoaiNV();
        }

        /* Upload loại nhân viên lên combobox */
        public void UpLoadComboBoxLoaiNV()
        {
            var data = BUS.BUS_LoaiNV.Select_All();
            cbb_loainv.DataSource = data;
            cbb_loainv.DisplayMember = "TenLoai";
            cbb_loainv.ValueMember = "MaLoai";
            cbb_loainv.SelectedIndex = 0;
        }


        /* khi muốn thoát form đăng ký */
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            var choice = MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (choice == DialogResult.OK) this.Close(DialogResult.Cancel);

        }


        /* khi click vào nút ĐĂNG KÝ */
        private void btn_themnhanvien_Click(object sender, EventArgs e)
        {
            if (Insert())
            {
                MessageBox.Show("Thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(DialogResult.Yes);
            }
            else MessageBox.Show(@"Đã có sự cố khi thêm nhân viên
Hãy kiễm tra lại Tên và SĐT và Địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                          
        }

        /*Hàm thêm nhân viên*/
        public bool Insert()
        {
            /* Lấy dữ liệu và gán cho các biến */
            string tennv = txt_tennv.Text;
            string sdt = txt_sdt.Text;
            string diachi = txt_diachi.Text;
            int loainv = (int)cbb_loainv.SelectedValue;
            string gioitinh = rdb_nam.Checked ? "Nam" : "Nữ";

            /* Thực hiện thêm nhân viên */
            var result = BUS_NhanVien.Insert(tennv,sdt,diachi,gioitinh,loainv);

            return result;

        }

    }
}
