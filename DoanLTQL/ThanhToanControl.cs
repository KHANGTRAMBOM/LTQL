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
    public partial class ThanhToanControl : UserControl
    {

        public ThanhToanControl()
        {
            InitializeComponent();
            UpLoadData(GetData());
        }


        /*  HÀM CẬP NHẬT DOANH THU */
        public void CapNhatDoanhThu()
        {
            float doanhthu = BUS_HoaDon.GetDoanhSo();

            txt_doanhthu.Text = string.Format($"{doanhthu:C0}");


        }

        /* HÀM LẤY DỮ LIỆU  */

        public object GetData()
        {
            object data = BUS_HoaDon.DanhSachHoaDonDaThanhToan();
            return data;
        }

        /* ĐỔ DỮ LIỆU LÊN DATAGRIDVIEW */
        public void UpLoadData(object data)
        {
            HienThiChuan();
            CapNhatDoanhThu();
            dgv_chitiethoadon.DataSource = data;

        }


        /*  Hàm hiển thị đúng số cột như design  */
        public void HienThiChuan()
        {
            dgv_chitiethoadon.AutoGenerateColumns = false;

            foreach (DataGridViewColumn col in dgv_chitiethoadon.Columns)
            {
                if (col is DataGridViewTextBoxColumn) col.Name = col.DataPropertyName;

            }
        }


        /*Hàm Chức NĂNG TỰ ĐỘNG TÌM KIẾM THEO TÊN KHÁCH HÀNG*/
        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            if (txt_timkiem.Text.Length == 0)
            {
                UpLoadData(GetData());
                return;
            }

            var data = BUS.BUS_ChiTietHoaDon.TimKiemTheoTen(txt_timkiem.Text.Trim());

            if (data != null)
            {
                UpLoadData(data);
            }

        }

        /* CLICK VÀO BUTTON CHI TIẾT */
        private void dgv_chitiethoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var reciver = (Guna2DataGridView)sender;

            if (e.RowIndex < 0 || e.RowIndex >= reciver.RowCount)
            {
                return;
            }

            if (e.ColumnIndex < 0 || e.ColumnIndex >= reciver.ColumnCount)
            {
                return;
            }


            /*Kiễm tra click vào button chi tiết*/

            if (reciver.Columns[e.ColumnIndex].Name == "ChiTiet")
            {

                int MaChtietHD = Convert.ToInt32(dgv_chitiethoadon.Rows[e.RowIndex].Cells["MaHD"].Value.ToString());
                MoPhieuChiTietHoaDon(MaChtietHD);
            }
        }

        /* Xử lý khi người dùng click vào chi tiết hóa đơn */
        private void MoPhieuChiTietHoaDon(int MaHD)
        {
            var obj = new ChiTietHoaDonControl();
            obj.MaHD = MaHD;
            /*Cap nhat du lieu truoc khi them vao from*/
            obj.UpLoadData();
            var form = new ShowUserControl();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Controls.Add(obj);
            form.SetSuKien(obj);
            form.Size = obj.Size;
            form.ShowDialog();
        }

        /* Cập nhật lại dữ liệu */
        private void btn_capnhat_Click(object sender, EventArgs e)
        {

            UpLoadData(GetData());
        }
    }
}
