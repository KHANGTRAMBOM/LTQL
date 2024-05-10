using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class ThemPhongControl : UserControl
    {

        public int Count_Update = 0;
        public ThemPhongControl()
        {
            InitializeComponent();
            UpLoadData();
        }

        private void ThemPhongControl_Load(object sender, EventArgs e)
        {
            /*  DO NOTTHING  */
        }


        /*PHƯƠNG THỨC ĐỔ DỮ LIỆU LÊN DATAGRIDVIEW*/
        private void UpLoadData()
        {
            /* Lấy dữ liệu phòng và loai phòng*/
            var data = BUS.BUS_Phong.Select_All();
            var loaiphg = BUS.BUS_LoaiPHG.Select_All();
            dgv_phong.DataSource = data;


            /*Điều chỉnh lại giá trị dữ liệu*/
            dgv_phong.Columns["Dongia"].DefaultCellStyle.Format = "C0";
            var combobox = (DataGridViewComboBoxColumn)dgv_phong.Columns["loai"];
            combobox.DisplayMember = "TenloaiPHG";
            combobox.ValueMember = "MaloaiPHG";
            combobox.DataSource = loaiphg;


            /*Đổ dữ liệu lên combobox*/
            UpLoadCombobox();

        }


        /*PHƯƠNG THỨC ĐỔ DỮ LIỆU LÊN COMBOBOX*/
        private void UpLoadCombobox()
        {
            var loaiphg = BUS.BUS_LoaiPHG.Select_All();
            cb_loaiphong.DisplayMember = "TenloaiPHG";
            cb_loaiphong.ValueMember = "MaloaiPHG";
            cb_loaiphong.DataSource = loaiphg;
            cb_loaiphong.SelectedIndex = 0;
        }



        /*PHƯƠNG THỨC BUTTON ĐỔ LẠI DỮ LIỆU LÊN DATAGRIDVIEW*/
        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            UpLoadData();
            UpdateButtonCapNhat(0);
        }



        private void UpdateButtonCapNhat(int sign)
        {
            if (sign == 0)
            {
                Count_Update = 0;
                btn_capnhat.Text = "Cập nhật";
            }
            else
            {
                Count_Update += 1;
                btn_capnhat.Text = $"({Count_Update}) Cập nhật";
            }
        }


        /*PHƯƠNG THỨC BUTTON THÊM MỘT PHÒNG */

        private void btn_them_Click(object sender, EventArgs e)
        {
            string tenphong = txt_tenphong.Text;
            string loaiphong = cb_loaiphong.SelectedValue.ToString();
            /*  Giả sử người sử dụng không nhập giá tiền thì sẽ mặc định gán dongia = 0  */
            float dongia = float.TryParse(txt_gia.Text, out dongia) ? dongia : 0;
            bool result = BUS.BUS_Phong.Insert(tenphong, loaiphong, dongia);
            if (result)
            {
                MessageBox.Show("Thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateButtonCapNhat(1);
            }
            else
            {
                MessageBox.Show("Thất Bại \nĐã có sự cố khi thêm phòng có thể là do 'tên phòng' đã trùng hoặc 'tên phòng' không hợp lệ xin hãy kiễm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tenphong.Focus();
            }

        }



        /*THAO TÁC XÓA VÀ CẬP NHẬT DỮ LIỆU*/
        private void dgv_phong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var reciver = (Guna2DataGridView)sender;

            /* KIỄM TRA XEM NGƯỜI DÙNG CÓ CLICK ĐÚNG DÒNG HAY CỘT TRONG DATAGRIDVIEW HAY KHÔNG */

            if (e.RowIndex < 0 || e.RowIndex >= reciver.RowCount)
            {
                return;
            }

            if (e.ColumnIndex < 0 || e.ColumnIndex >= reciver.ColumnCount)
            {
                return;
            }


            /*Kiễm tra click vào nut update*/

            if (reciver.Columns[e.ColumnIndex].Name == "Update")
            {
                var check = MessageBox.Show("Bạn có muốn cập nhật phòng này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    var phong = dgv_phong.Rows[e.RowIndex];
                    var result = BUS.BUS_Phong.Update((int)phong.Cells["Maphg"].Value, (string)phong.Cells["tenphong"].Value, (string)phong.Cells["Loai"].Value, (float)phong.Cells["Dongia"].Value);

                    if (result)
                    {
                        MessageBox.Show("Thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /* THÔNG BÁO CHO NGƯỜI DÙNG BIẾT LÀ DATAGRIDVIEW ĐÃ CÓ SỰ THAY ĐỔI CẦN CLICK VÀO BUTTON CẬP NHẬT ĐỂ THẤY RÕ */
                        UpdateButtonCapNhat(1);
                    }
                    else
                    {
                        MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            /*Kiễm tra click vào nut Delete*/
            if (reciver.Columns[e.ColumnIndex].Name == "Delete")
            {
                var check = MessageBox.Show("Bạn có muốn xóa phòng này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    var maphong = (int)reciver.Rows[e.RowIndex].Cells["Maphg"].Value;
                    var result = BUS.BUS_Phong.Delete(maphong);
                    if (result)
                    {
                        MessageBox.Show("Thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /* THÔNG BÁO CHO NGƯỜI DÙNG BIẾT LÀ DATAGRIDVIEW ĐÃ CÓ SỰ THAY ĐỔI CẦN CLICK VÀO BUTTON CẬP NHẬT ĐỂ THẤY RÕ */
                        UpdateButtonCapNhat(1);
                    }
                    else
                    {
                        MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

    }
}
