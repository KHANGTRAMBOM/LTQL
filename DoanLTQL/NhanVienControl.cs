using BUS;
using DAO;
using DTO;
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
    public partial class NhanVienControl : UserControl
    {

        public NhanVienControl()
        {
            InitializeComponent();
            UpLoadData(GetData());
        }

        /* Hàm lấy dữ liệu  */
        public List<NhanVien> GetData()
        {
            return BUS.BUS_NhanVien.Select_All();
        }


        /*Hàm Đổ dữ liệu nhân viên lên datagirdview*/
        private void UpLoadData(List<NhanVien> data)
        {
            /*Hiển thị đúng cột cho datagridview*/
            HienThiChuan();

            var cbb_source = BUS.BUS_LoaiNV.Select_All();
            dgv_nhanvien.DataSource = data;


            /*Hiển thị dữ liệu loại nhân viên lên cột combobox của datagridview*/
            var combobox = (DataGridViewComboBoxColumn)dgv_nhanvien.Columns["LoaiNV"];
            combobox.DisplayMember = "TenLoai";
            combobox.ValueMember = "MaLoai";
            combobox.DataSource = cbb_source;

        }

        /*Hàm Giúp Hiển thị đúng cột cho datagridview*/
        private void HienThiChuan()
        {
            dgv_nhanvien.AutoGenerateColumns = false;
        }


        /* Hàm xử lý khi click vào nút thêm nhân viên */
        private void btn_themnv_Click(object sender, EventArgs e)
        {
            /* Nhóm các thao tác mở form để thực hiện thêm nhân viên */
            var obj = new ThemNhanVien();
            var form = new ShowUserControl();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Controls.Add(obj);
            form.Size = obj.Size;
            form.SetSuKien(obj);
            var result = form.ShowDialog();
            if (result == DialogResult.Yes) { UpLoadData(GetData()); }
        }



        /*CẬP NHẬT VÀ XÓA NHÂN VIÊN*/
        private void dgv_nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /* KIỄM TRA XEM NGƯỜI DÙNG CÓ CLICK ĐÚNG DÒNG HAY CỘT TRONG DATAGRIDVIEW HAY KHÔNG */
            var reciver = (Guna2DataGridView)sender;

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
                var check = MessageBox.Show("Bạn có muốn cập nhật nhân viên này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    var phong = dgv_nhanvien.Rows[e.RowIndex];

                    var result = BUS.BUS_NhanVien.Update((int)phong.Cells["Manv1"].Value, phong.Cells["TenNV1"].Value + "", phong.Cells["SDT1"].Value + "", phong.Cells["Diachi"].Value + "", phong.Cells["Gioitinh"].Value + "", Convert.ToInt32(phong.Cells["LoaiNV"].Value));

                    if (result)
                    {
                        MessageBox.Show("Thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*Cập nhật lại dữ liệu lên datagridview*/
                        UpLoadData(GetData());
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
                var check = MessageBox.Show("Bạn có muốn xóa nhân viên này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    var maphong = (int)reciver.Rows[e.RowIndex].Cells["Manv1"].Value;
                    var result = BUS.BUS_NhanVien.Delete(maphong);
                    if (result)
                    {
                        MessageBox.Show("Thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*Cập nhật lại dữ liệu lên datagridview*/
                        UpLoadData(GetData());

                    }
                    else
                    {
                        MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /*  HÀM XỬ LÝ TÌM KIẾM NHÂN VIÊN THEO TÊN  */
        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            var data = BUS.BUS_NhanVien.TimNhanVien(txt_timkiem.Text.Trim());

            if (data != null)
            {
                UpLoadData(data);
            }
        }


    }
}
