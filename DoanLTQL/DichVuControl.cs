using BUS;
using DAO;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.Logging;
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
    public partial class DichVuControl : UserControl
    {
        public DichVuControl()
        {
            InitializeComponent();
            UploadData();
        }

        public void UploadData()
        {
            /*HIỂN THỊ CỘT CHUẨN*/
            HienThiChuan();

            var data = BUS_DichVu.Select_All();

            //data.ForEach(x => x.Print());

            dgv_dichvu.DataSource = data;

            /*ĐỔ DỮ LIỆU VÔ COMBOBOX CỦA DATAGRID VÀ ĐIỀU CHỈNH CHO PHÙ HỢP*/
            var cbb_source = (from p in BUS.BUS_LoaiDV.Select_All()
                              select p).ToList();

            var combobox = (DataGridViewComboBoxColumn)dgv_dichvu.Columns["LoaiDV"];

            combobox.DataSource = cbb_source;
            combobox.DisplayMember = "TenLoaiDV";
            combobox.ValueMember = "MaLoaiDV";



        }


        /* HÀM HIỂN THỊ CỘT GIỐNG NHƯ BÊN DESIGN */
        public void HienThiChuan()
        {
            dgv_dichvu.AutoGenerateColumns = false;

            /*  ĐẶT LẠI NAME CHO TỪNG CỘT */
            foreach (var c in dgv_dichvu.Columns)
            {
                if (c is DataGridViewTextBoxColumn)
                {
                    DataGridViewColumn col = (DataGridViewColumn)c;
                    col.Name = col.DataPropertyName;
                }

                if (c is DataGridViewComboBoxColumn)
                {
                    DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)c;
                    col.Name = col.DataPropertyName;
                }
            }
        }


        /* CẬP NHẬT VÀ XÓA */
        private void dgv_dicvu_CellClick(object sender, DataGridViewCellEventArgs e)
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
                var check = MessageBox.Show("Bạn có muốn cập nhật dịch vụ này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    var dichvu = dgv_dichvu.Rows[e.RowIndex];

                    var result = BUS.BUS_DichVu.Update((int)dichvu.Cells["MaDV"].Value, dichvu.Cells["TenDV"].Value + "", Convert.ToInt32(dichvu.Cells["LoaiDV"].Value), float.Parse(dichvu.Cells["Dongia"].Value.ToString()));

                    if (result)
                    {
                        MessageBox.Show("Thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /* Cập nhật lại dữ liệu lên datagridview */
                        UploadData();
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
                var check = MessageBox.Show("Bạn có muốn xóa dịch vụ này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    var maphong = (int)reciver.Rows[e.RowIndex].Cells["MaDV"].Value;
                    var result = BUS.BUS_DichVu.Delete(maphong);
                    if (result)
                    {
                        MessageBox.Show("Thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*Cập nhật lại dữ liệu lên datagridview*/
                        UploadData();

                    }
                    else
                    {
                        MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /* Hàm xử lý khi click vào nút thêm nhân viên */
        private void btn_datphong_Click(object sender, EventArgs e)
        {
            /* Nhóm các thao tác mở form để thực hiện thêm nhân viên */
            var obj = new ThemDichVu();
            var form = new ShowUserControl();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Controls.Add(obj);
            form.Size = obj.Size;
            form.SetSuKien(obj);
            var result = form.ShowDialog();
            if (result == DialogResult.Yes) { UploadData(); }
        }
    }
}
