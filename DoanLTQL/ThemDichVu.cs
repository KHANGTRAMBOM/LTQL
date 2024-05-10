using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThemDichVu : UserControl
    {
        public ThemDichVu()
        {
            InitializeComponent();
            UpLoadComBoBox();
        }


        /* ĐỔ DỮ LIỆU LÊN COMBOBOX   */
        public void UpLoadComBoBox()
        {
            var source = from p in BUS_LoaiDV.Select_All()
                         select p;

            cbb_loaidv.DataSource = source.ToList();
            cbb_loaidv.DisplayMember = "TenLoaiDV";
            cbb_loaidv.ValueMember = "MaLoaiDV";
            cbb_loaidv.SelectedIndex = 0;
        }


        private void btn_thoat_Click(object sender, EventArgs e)
        {
            var choice = MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (choice == DialogResult.OK) this.Close(DialogResult.Cancel);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (Insert())
            {
                MessageBox.Show("Thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(DialogResult.Yes);
            }
            else MessageBox.Show(@"Đã có sự cố khi thêm dịch vụ
Hãy kiễm tra lại Tên dịch vụ có trùng không", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /*Hàm thêm dịch vụ*/
        public bool Insert()
        {
            /* Lấy dữ liệu và gán cho các biến */
            string tendv = txt_tendichvu.Text;

            int loainv = (int)cbb_loaidv.SelectedValue;

            /* Đảm bảo giá trị của đơn giá là không thể bị null*/
            float dongia = float.TryParse(txt_dongia.Text, out dongia) ? dongia : 0;

            /* Thực hiện thêm nhân viên */
            var result = BUS_DichVu.Insert(tendv, loainv, dongia);

            return result;

        }

        /* Chỉnh hover cho button thoát */

        private void btn_thoat_MouseEnter(object sender, EventArgs e)
        {
            btn_thoat.FillColor = Color.Red;
        }

        private void btn_thoat_MouseLeave(object sender, EventArgs e)
        {
            btn_thoat.FillColor = Color.FromArgb(58, 61, 76);
        }


        /* Hàm nhập đơn giá nó sẽ tự động hiển thị kiểu tiện tệ  */
        private void txt_dongia_TextChanged(object sender, EventArgs e)
        {
            string text = txt_dongia.Text.ToString();

            /* Kiễm tra chuỗi đang rỗng */
            if (text.Length == 0) return;

            /* Kiễm tra người dùng có chỉ nhập số hay không */
            if (!Regex.IsMatch(text, "^[0-9]"))
            {
                MessageBox.Show("Vui Lòng Nhập Số");
                return;
            }           
        }
    }
}
