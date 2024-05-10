using BUS;
using DTO;
using Microsoft.EntityFrameworkCore.Query;
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
    public partial class DatPhong : UserControl
    {
        /* tạo delegate để tryền dữ liệu cho RoomItem */



        public RoomItem roomitem;
        public DatPhong()
        {
            InitializeComponent();

            /* Mặc định giới tính là nam */
            cbb_gioitinh.SelectedIndex = 0;



        }



        /*Hàm Click vào btn hủy đặt phòng*/
        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close(DialogResult.Cancel);
        }

        /*Hàm Click vào đặt phòng */
        private void btn_datphong_Click(object sender, EventArgs e)
        {
            /* Lấy thông tin */
           
            string hoten = txt_diachi.Text;
            string cccd = txt_cccd.Text;
            string sdt = txt_sdt.Text;
            string diachi = txt_diachi.Text;
            string gioitinh = cbb_gioitinh.SelectedItem as string;
            DateTime ngaydat = DateTime.Parse(DateTime.Now.ToString("D"));
            DateTime ngaynhan = dtp_ngaynhan.Value;
            int maphong = Convert.ToInt32(roomitem.Getlbl_sophong.Text);

          
            /* Lấy hoặc tạo khách hàng */

            KhachHang kh = BUS_KhachHangcs.TimKhachHang_OrCreate(hoten, cccd, sdt, diachi, gioitinh);
            
            if (kh == null) 
            {
                MessageBox.Show(@"Thất bại
Có lỗi khi tạo đặt phòng có thể do hoten để trống hoặc CCCD đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            /* Tạo PhieuDatPhong */

           BUS_PhieuDatPhong.Insert(kh.MaKH);

           /* Lấy PhieuDatPhong */
           PhieuDatPhong phieudatphg = BUS_PhieuDatPhong.Select_By_MaKH_Last(kh.MaKH);

           /* Tạo ChitietPhieuDatPhong */

            BUS_ChiTietDatPhong.Insert(maphong,phieudatphg.MaDatPHG,ngaydat, ngaynhan);
       
            this.Close(DialogResult.OK);
        }

        /*Hàm Click vào nút thoát*/
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            var choice = MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (choice == DialogResult.OK) { this.Close(DialogResult.Cancel); }
        }
    }
}
