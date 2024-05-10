using BUS;
using DAO;
using DTO;
using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ChiTietPhong : UserControl
    {
        Color color;
        public RoomItem RoomItem { get; set; }
        ChiTietPhieuDatPhong chiTietphieudatphong;
        PhieuDatPhong phieudatphong;
        PhieuNhanPhong phieunhanphong;
        KhachHang khachhang;
        Phong phong;
        HoaDon hoadon = null;
        NhanVien nhanvien;
        private readonly int PhuThu = 10;

        public void SetUp()
        {
            int maphong = Convert.ToInt32(RoomItem.Getlbl_sophong.Text);

            /* Từ mã phòng lấy danh sách ai đã từng đặt phòng này */
            var list_ctphieudatphong = BUS_ChiTietDatPhong.Select_By_MaPHG(maphong);

            /* Lấy khách hàng đặt phòng mới nhất mới nhất */
            chiTietphieudatphong = list_ctphieudatphong[list_ctphieudatphong.Count - 1];

            /* Lấy phieudatphong */
            phieudatphong = BUS_PhieuDatPhong.Select_By_MaDatPHG(chiTietphieudatphong.MaDatPHG);

            /* Lấy khachang*/
            khachhang = BUS_KhachHangcs.Select_By_ID((int)phieudatphong.MaKH);

            /* Lấy phiếu nhận phòng */
            phieunhanphong = BUS_PhieuNhanPhong.Select_By_MaPhieuDat(phieudatphong.MaDatPHG);

            /* Lấy phòng */
            phong = BUS_Phong.Select_By_MaPHG(maphong);


            /* Load dữ liệu về dịch vụ lên datagrid dịch vụ */
            LoadDichVu();

            /* Load nhân viên */
            LoadNhanVien();

            /* Load dữ liệu về phòng ngày đặt ngày trả */
            LoadThongTinPhong();

        }

        public ChiTietPhong()
        {
            InitializeComponent();
        }

        /* Hàm tải danh sách dịch vụ lên */
        public void LoadDichVu()
        {
            var source = BUS_DichVu.Select_All();
            dgv_dichvu.AutoGenerateColumns = false;
            dgv_dichvu.DataSource = source;
        }

        public void LoadNhanVien()
        {
            var source = BUS_NhanVien.Select_LeTan();
            cbb_nhanvien.DataSource = source;
            cbb_nhanvien.DisplayMember = "TenNV";
            cbb_nhanvien.ValueMember = "Manv";
        }

        public void LoadThongTinPhong()
        {

            txt_sophong.Text = RoomItem.Getlbl_sophong.Text;
            btn_loaiphong.Text = RoomItem.Getlbl_loaiphong.Text;
            txt_ngaylap.Text = chiTietphieudatphong.NgayDat.ToString("D");
            dtp_ngaybatdau.Value = chiTietphieudatphong.NgayNhan;
            dtp_ngaytraphong.Value = chiTietphieudatphong.NgayNhan;

            /* Khách hàng chưa có phiếu nhận phòng (phòng vừa mới đặt) [Click lần 1] */

            if (phieunhanphong == null)
            {
                /* Tạo phiếu nhận phòng */
                BUS_PhieuNhanPhong.Insert(phieudatphong.MaDatPHG, khachhang.MaKH);
                phieunhanphong = BUS_PhieuNhanPhong.Select_By_MaPhieuDat(phieudatphong.MaDatPHG);
                txt_nhanvien.Hide();
                btn_thanhtoan.Hide();
                btn_thoat_2.Show();
            }
            else
            {
                /* Hiển thị danh sách sử dụng dịch vụ theo mã nhận phòng */

                UpdateBangSuDungDichVu(-1);

                /* Kiễm tra khách đã nhận phòng chưa [Click lần 2]  ( Có phiếu nhận phòng nhưng chua lấy ) */

                ChiTietPhieuNhanPhong ct = BUS_ChiTietNhanPhong.TimKiem(phieunhanphong.MaNhanPHG, phieudatphong.MaDatPHG, khachhang.MaKH);

                btn_thanhtoan.Hide();
                btn_thoat_2.Show();

                /* Khách hàng đã có phiếu nhận phòng nhưng chưa lấy phòng */

                if (ct == null) return;


                /* Khách hàng đã lấy phòng */

                hoadon = BUS_HoaDon.Select_By_MaNhanPHG(phieunhanphong.MaNhanPHG);

                nhanvien = BUS_NhanVien.Select_By_MaNV((int)hoadon.MaNV);

                /* Cập nhật hiển thị */
                txt_nhanvien.Text = nhanvien.TenNV;

                txt_nhanvien.Show();

                cbb_nhanvien.Hide();

                txt_mathue.Text = ct.MaNhanPHG.ToString();

                dtp_ngaybatdau.Value = ct.NgayNhan;
                dtp_ngaybatdau.Enabled = false;

                dtp_ngaytraphong.Value = ct.NgayTraDuKien;
                dtp_ngaytraphong.Enabled = false;

                /* Khách thanh toán mới được trả phòng */
                btn_thoat_2.Hide();
                btn_thanhtoan.Show();

                UpdateBangThanhTien();
            }

        }

        private void btn_thoat_2_Click(object sender, EventArgs e)
        {
            /* Nếu khách hàng muốn bỏ đặt thì xóa phiếu nhận phòng và xóa phiếu đặt phòng */
            BUS_PhieuNhanPhong.Delete_By_MaDatPHG(phieudatphong.MaDatPHG);
            BUS_PhieuDatPhong.Delete(phieudatphong.MaDatPHG);

            this.Close(DialogResult.No);
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            var choice = MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (choice == DialogResult.OK) this.Close(DialogResult.Cancel);
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            /* Kiễm tra khách hàng đã lấy phòng chưa [đã có phiếu nhận phòng] */

            /* Có phiếu nhận phòng nhưng lấy nhận phòng */
            if (hoadon == null)
            {

                /* Tạo chi tiết nhận phòng khi khách hàng lấy phòng */
                BUS_ChiTietNhanPhong.Insert(phieunhanphong.MaNhanPHG, phieudatphong.MaDatPHG, khachhang.MaKH, dtp_ngaybatdau.Value, dtp_ngaytraphong.Value, DateTime.MinValue);

                /* Tạo hóa đơn khi khách nhận phòng */
                int manv = (int)cbb_nhanvien.SelectedValue;

                /* tạo hóa đơn nhưng chưa bao gồm tổng tiền */
                BUS_HoaDon.Insert(manv, khachhang.MaKH, phieunhanphong.MaNhanPHG, dtp_ngaybatdau.Value);

                hoadon = BUS_HoaDon.Select_By_MaNhanPHG(phieunhanphong.MaNhanPHG);
                /* Tạo chi tiết hóa đơn khi khách nhận phòng  */


                /* Lấy danh sách sử dụng dịch vụ của phòng này */
                var list_sddv = BUS_SuDungDichVu.Select_By_MaNhanPHG(hoadon.MaNhanPHG);

                /* Thêm các chi tiết hóa đơn */

                list_sddv.ForEach(sd =>
                {
                    float tiendv = BUS_SuDungDichVu.GetTongTien_By_MaSDDV(sd.MaSuDungDV);
                    int songay = DAO_HoaDon.GetSoNgay(hoadon.MaHD);
                    BUS_ChiTietHoaDon.Insert(hoadon.MaHD, phong.MaPHG, sd.MaSuDungDV, phong.Dongia, tiendv, songay);
                });

                var data = BUS_ChiTietHoaDon.Select_All_By_MaHD(hoadon.MaHD);


                /*       Cập nhật lại tổng tiền của hóa đơn sau khi có chi tiết hóa đơn
                
                          tiền cùa chi tiết hóa đơn chưa bao gồm tiền phòng và đã có phụ thu 10%

                          tiền của hóa đơn sẽ là : (tiền phòng * số ngày) + tiền dịchvụ 
                 */

                float tiendv = BUS_SuDungDichVu.GetTongTien_By_MaNhanPHG_SauPhuThu(phieunhanphong.MaNhanPHG);

                BUS.BUS_HoaDon.Update_TongTien(phieunhanphong.MaNhanPHG, phong.MaPHG, tiendv);


                UpdateBangThanhTien();
            }
            else
            {
                /* Có phiếu nhận phòng và đã nhận phòng rồi */


                /* Cập nhật lại các thay đổi có thể có */


                /* Thay đổi về ngày trả phòng */


                /* Thay đổi về sử dụng dịch vụ*/


                /*  [Không cần phải sửa bởi vì nó đã được xử lý trước rồi] */

            }

            this.Close(DialogResult.OK);
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            /* Cập nhật lại ngày trả thực tế cho chi tiết nhận phòng */
            if (hoadon != null)
            {
                BUS_ChiTietNhanPhong.Update_NgayTraThucTe(phieunhanphong.MaNhanPHG, phieudatphong.MaDatPHG, khachhang.MaKH, DateTime.Now);

                /* Mở form in hóa đơn lên */
                Inhoadon form = new Inhoadon();
                form.MaHD = hoadon.MaHD;
                form.LoadData();
                form.StartPosition = FormStartPosition.CenterScreen;
                DialogResult kq = form.ShowDialog();
                if(kq == DialogResult.OK)this.Close(DialogResult.No);             
            }
        }

        /* Hàm thêm dịch vụ */
        private void dgv_dichvu_CellClick(object sender, DataGridViewCellEventArgs e)
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

            /*Kiễm tra click vào button thêm*/

            if (reciver.Columns[e.ColumnIndex].Name == "Them")
            {
                int madv_dachon = Convert.ToInt32(reciver.Rows[e.RowIndex].Cells["MaDV"].Value.ToString());

                int maphong = Convert.ToInt32(RoomItem.Getlbl_sophong.Text);

                /* Lấy mã SDDV */

                SuDungDV sudungdichvu = BUS_SuDungDichVu.Select_By_MaDV_MaNhanPHG(madv_dachon, phieunhanphong.MaNhanPHG);

                /* Kiễm tra xem là dịch vụ này được đặt chưa */

                if (sudungdichvu == null)/* Chưa đặt */
                {

                    BUS_SuDungDichVu.Insert(madv_dachon, phieunhanphong.MaNhanPHG, 1);

                    /* Kiễm tra xem đã có hóa đơn chưa */

                    if (hoadon != null)/* Nếu đã có rồi thì cập nhật lên chi tiêt hóa đơn rồi cập nhật lại tổng tiền của hóa đơn */
                    {
                        /* Lấy Sudungdichvu vừa mới thêm vào */
                        var SuDungDichVu = BUS_SuDungDichVu.Select_By_MaNhanPHG_Last_Element(hoadon.MaNhanPHG);

                        /* Lấy số ngày và tiền dv */
                        int songay = BUS_HoaDon.GetSoNgay(hoadon.MaHD);

                        float tiendv = BUS_DichVu.GetDichVu_By_MaDV(madv_dachon).Dongia;

                        /* Thêm chi tiết hóa đơn */
                        BUS_ChiTietHoaDon.Insert(hoadon.MaHD, phong.MaPHG, (int)SuDungDichVu.MaSuDungDV, phong.Dongia, tiendv, songay);

                        /* Cập nhật lại hóa đơn */
                        tiendv = BUS_SuDungDichVu.GetTongTien_By_MaNhanPHG_SauPhuThu(phieunhanphong.MaNhanPHG);

                        BUS.BUS_HoaDon.Update_TongTien(hoadon.MaNhanPHG, phong.MaPHG, tiendv);

                        UpdateBangThanhTien();
                    }
                }
                else
                {
                    /* Cập nhật lại số lượng */
                    BUS_SuDungDichVu.Update_SoLuong(sudungdichvu.MaSuDungDV, phieunhanphong.MaNhanPHG, 1);

                    /* Nếu khách đã lấy phòng rồi thì phải cập lại vào hóa đơn và chi tiết hóa đơn */
                    if (hoadon != null)
                    {

                        /*   Cập nhật lại chi tiết hóa đơn của mã sử dụng dịch vụ đó*/
                        BUS_ChiTietHoaDon.Update_TienDV(hoadon.MaHD, sudungdichvu.MaSuDungDV);

                        /* Cập nhật lại hóa đơn*/
                        float tiendv = BUS_SuDungDichVu.GetTongTien_By_MaNhanPHG_SauPhuThu(phieunhanphong.MaNhanPHG);

                        BUS.BUS_HoaDon.Update_TongTien(hoadon.MaNhanPHG, phong.MaPHG, tiendv);

                        UpdateBangThanhTien();
                    }
                }

                UpdateBangSuDungDichVu(-1);
            }
        }

        /* Cập nhật những dữ liệu đã được sử dụng lên datagridview */
        private void UpdateBangSuDungDichVu(int index)
        {

            var data_source = BUS_SuDungDichVu.Select_Display_MaNhanPHG(phieunhanphong.MaNhanPHG);

            dgv_dicvudasudung.AutoGenerateColumns = false;


            /*Xóa hết dự liệu rồi cập nhật lại datagridview*/
            dgv_dicvudasudung.DataSource = data_source;


            /* Chỉnh lại dòng được chọn là rỗng */
            dgv_dicvudasudung.ClearSelection();

            if (index >= 0 && index < dgv_dicvudasudung.Rows.Count)
            {
                dgv_dicvudasudung.Rows[index].Selected = true;
            }
            else
            {
                dgv_dicvudasudung.ClearSelection();
            }

        }


        /* Hàm Xóa bớt dịch vụ */
        private void dgv_dicvudasudung_CellClick(object sender, DataGridViewCellEventArgs e)
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

            /*Kiễm tra click vào button delete*/

            if (reciver.Columns[e.ColumnIndex].Name == "Delete")
            {
                int madv = Convert.ToInt32(reciver.Rows[e.RowIndex].Cells["MaDV1"].Value.ToString());

                /* Lấy mã SDDV vừa được chọn để xóa */
                SuDungDV sudungdichvu = BUS_SuDungDichVu.Select_By_MaDV_MaNhanPHG(madv, phieunhanphong.MaNhanPHG);


                /* Kiễm tra khách lấy phòng chưa */
                if (hoadon == null)
                {
                    /* Cập nhật lại số lượng bình thường không cần phải cập nhật lại hóa đơn  */
                    BUS_SuDungDichVu.Update_SoLuong(sudungdichvu.MaSuDungDV, phieunhanphong.MaDatPHG, -1);
                }
                else
                {

                    BUS_SuDungDichVu.Update_SoLuong(sudungdichvu.MaSuDungDV, hoadon.MaNhanPHG, -1);

                    UpdateBangThanhTien();
                }

                /*               Console.WriteLine("/n/n/n---------Danh sach su dung dich vu--------/n/n/n");
                               var dt1 = BUS_SuDungDichVu.Select_By_MaNhanPHG(phieunhanphong.MaNhanPHG);
                               dt1.ToList().ForEach(x => x.Print());

                               if (hoadon != null)
                               {
                                   Console.WriteLine("/n/n/nDanh sach chi tiet hoa don/n/n/n");
                                   var dt2 = BUS_ChiTietHoaDon.Select_All_By_MaHD(hoadon.MaHD);
                                   dt2.ToList().ForEach(x => x.Print());
                               }*/

                UpdateBangSuDungDichVu(e.RowIndex);
            }
        }
        /* Tới hạn nhưng khách chưa trả phòng */
        private void dtp_ngaytraphong_ValueChanged(object sender, EventArgs e)
        {
            /* Nếu ngày trả phòng nhỏ hơn ngày nhận thì báo lỗi*/
            if (hoadon == null)
            {
                var dtp = (Guna2DateTimePicker)sender;

                DateTime ngaykt = DateTime.Parse(dtp.Value.ToString("D"));
                DateTime ngaybd = DateTime.Parse(dtp_ngaybatdau.Value.ToString("D"));

                if (ngaykt < ngaybd)
                {
                    MessageBox.Show("Ngày trả phòng không thể bé hơn ngày nhận", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtp_ngaytraphong.Value = chiTietphieudatphong.NgayNhan;
                }
            }
            if (hoadon != null)
            {
                /* Kiễm tra tới hạn trả mà khách chưa trả phòng */

                ChiTietPhieuNhanPhong ct = BUS_ChiTietNhanPhong.TimKiem(phieunhanphong.MaNhanPHG, phieudatphong.MaDatPHG, khachhang.MaKH);

                DateTime ngayhientai = DateTime.Parse(DateTime.Now.ToString("D"));
                DateTime ngaytradukien = DateTime.Parse(dtp_ngaytraphong.Value.ToString("D"));


                if (ngaytradukien >= ngayhientai)
                {
                    /* Khách trả phòng trước hoặc đúng hạn */
                    lbl_traphong.ForeColor = Color.Green;
                }
                else
                {
                    /* Khách trả phòng quá hạn */
                    lbl_traphong.ForeColor = Color.Red;
                }
            }

        }

        private void dtp_ngaybatdau_ValueChanged(object sender, EventArgs e)
        {

            if (hoadon == null)
            {
                DateTime day1 = DateTime.Parse(dtp_ngaybatdau.Value.ToString("D"));
                DateTime day2 = DateTime.Parse(chiTietphieudatphong.NgayNhan.ToString("D"));

                if (day1 <= day2)
                {
                    /* Khách nhận phòng trước hoặc đúng hạn */
                    lbl_nhanphong.ForeColor = Color.Green;
                }
                else
                {
                    /* Khách nhận phòng quá hạn*/
                    lbl_nhanphong.ForeColor = Color.Red;
                }

                color = lbl_nhanphong.ForeColor;
            }
            else
            {
                lbl_nhanphong.ForeColor = color;
            }

        }


        /* Hiển thị liên quan đến tiền */
        public void UpdateBangThanhTien()
        {

            if (hoadon != null)
            {
                txt_tien_giaphong.Text = string.Format($"{phong.Dongia:C0} x {BUS_HoaDon.GetSoNgay(hoadon.MaHD)}");

                txt_tien_dichvu.Text = string.Format($"{BUS_SuDungDichVu.GetTongTien_By_MaNhanPHG(phieunhanphong.MaNhanPHG):C0}");

                txt_tien_phuthu.Text = PhuThu + "%";

                float tiendv = BUS_SuDungDichVu.GetTongTien_By_MaNhanPHG(phieunhanphong.MaNhanPHG);

                float tongtien = BUS_HoaDon.GetTongTienChuaPhuThu(phieunhanphong.MaNhanPHG, phong.MaPHG, tiendv);

                txt_tien_tongtien.Text = string.Format($"{tongtien:C0}");

                txt_tien_phaitra.Text = string.Format($"{hoadon.TongTien:C0}");
            }

        }
    }
}
