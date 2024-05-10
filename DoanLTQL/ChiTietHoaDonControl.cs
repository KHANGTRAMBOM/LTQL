using BUS;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ChiTietHoaDonControl : UserControl
    {

        public int MaHD;
        public ChiTietHoaDonControl()
        {
            InitializeComponent();

        }

        /* ĐỔ DỮ LIỆU LÊN */
        public void UpLoadData()
        {
            HoaDon hd = BUS_HoaDon.Select_By_MaHD(MaHD);
            ChiTietHoaDon ct_hoadon = BUS_ChiTietHoaDon.Select_By_MaHD(MaHD);
            NhanVien nv = BUS_NhanVien.Select_By_MaNV((int)hd.MaNV);
            ChiTietPhieuNhanPhong ct_nhanphg = BUS_ChiTietNhanPhong.Select_By_MaNhanPhong(hd.MaNhanPHG);
            ChiTietPhieuDatPhong ct_datphg = BUS_ChiTietDatPhong.Select_By_MaDatPHG(ct_nhanphg.MaDatPHG);
            Phong phong = BUS_Phong.Select_By_MaPHG((int)ct_hoadon.MaPHG);
            LoaiPHG loaiphg = BUS_LoaiPHG.Select_By_MaLoai(phong.LoaiPHG);
            var ds_sudungdv = BUS_SuDungDichVu.Select_Display_MaNhanPHG(ct_nhanphg.MaNhanPHG);
            string MaNhanPHG = hd.MaNhanPHG + "";
            txt_sophong.Text = phong.TenPHG + "";
            txt_mathue.Text = hd.MaNhanPHG + "";
            btn_loaiphong.Text = loaiphg.TenloaiPHG;
            txt_nhanvien.Text = nv.TenNV;
            txt_ngaylap.Text = ct_datphg.NgayDat.ToString("D");
            txt_nhanphong.Text = ct_nhanphg.NgayNhan.ToString("D");
            txt_traphong.Text = ct_nhanphg.NgayTraThucTe.ToString("D");
            dgv_dicvudasudung.AutoGenerateColumns = false;
            dgv_dicvudasudung.DataSource = ds_sudungdv;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            var choice = MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (choice == DialogResult.OK) this.Close(DialogResult.Cancel);
        }
    }
}
