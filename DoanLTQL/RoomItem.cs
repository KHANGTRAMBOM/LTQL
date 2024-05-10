using BUS;
using DAO;
using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class RoomItem : UserControl
    {
      

        /* get các controls trong roomitem thay vì sử dụng public */

        public Label Getlbl_gia => this.lbl_gia;
        public Label Getlbl_loaiphong => this.lbl_loaiphong;
        public Label Getlbl_sophong => this.lbl_sophong;
        public Label Getlbl_trangthai => this.lbl_trangthai;
        public Guna.UI2.WinForms.Guna2Panel Getpanel_container => panel_container;

        public Guna.UI2.WinForms.Guna2Button Getbtn_trangthai => btn_trangthai;

        enum TrangThaiPhong
        {
            Empty = 1,
            Lived = 2,
            Booked = 3
        }



        /* Constructor  không tham số user control */

        public RoomItem()
        {
            InitializeComponent();

        }

        /* Constructor co tham so cua user control */

        public RoomItem(int SoPhong, string LoaiPhong, string TrangThai, float Gia)
        {

            InitializeComponent();

            /* Chỉnh lại kích thước để hiện thị cho đẹp */
            this.Margin = new Padding(50, 10, 20, 10);

            if (LoaiPhong == "Phòng tổng thống")
            {
                this.lbl_loaiphong.Location = new Point(12, 53);
            }


            /* Gán giá trị */
            this.lbl_sophong.Text = SoPhong.ToString();
            this.lbl_loaiphong.Text = LoaiPhong;
            this.lbl_trangthai.Text = TrangThai;
            this.lbl_gia.Text = Gia.ToString("C0");
       

            UpdateTrangThai(TrangThai);


            
        }



        /* Cập nhật lại trạng thái của phòng (phòng trống, có khách, đã được đặt) */
        public void UpdateTrangThai(string TrangThai)
        {
            ChiTietPhieuDatPhong chiTietphieudatphong = null;

            ChiTietPhieuNhanPhong ct = null;

            /* Để lấy ngày nhận phòng hoặc ngày trả phòng */
            if (!TrangThai.Contains("Phòng trống"))
            {
                int sophong = Convert.ToInt32(Getlbl_sophong.Text);
                /* Từ mã phòng lấy danh sách ai đã từng đặt phòng này */
                var list_ctphieudatphong = BUS_ChiTietDatPhong.Select_By_MaPHG(sophong);

                /* Lấy chitietdatphong mới nhất */
                chiTietphieudatphong = list_ctphieudatphong[list_ctphieudatphong.Count - 1];

                /* Lấy phieudatphong */
                var phieudatphong = BUS_PhieuDatPhong.Select_By_MaDatPHG(chiTietphieudatphong.MaDatPHG);

                /* Lấy khachang*/
               var khachhang = BUS_KhachHangcs.Select_By_ID((int)phieudatphong.MaKH);

                /* Lấy phiếu nhận phòng */
               var phieunhanphong = BUS_PhieuNhanPhong.Select_By_MaPhieuDat(phieudatphong.MaDatPHG);

                if(TrangThai.Contains("khách")) ct = BUS_ChiTietNhanPhong.TimKiem(phieunhanphong.MaNhanPHG, phieudatphong.MaDatPHG, khachhang.MaKH);

            }



            switch (TrangThai)
            {
                case "Phòng trống":
                    {
                        this.panel_container.FillColor = Color.FromArgb(91, 164, 88);
                        this.btn_trangthai.Image = Properties.Resources.bed;
                        this.btn_trangthai.ImageSize = new Size(60, 57);
                        this.lbl_trangthai.Location = new Point(167, 53);
                        this.lbl_ngaynhan.Text = "";
                        break;
                    }

                case "Có khách":
                    {
                        this.panel_container.FillColor = Color.FromArgb(236, 97, 33);
                        this.btn_trangthai.Image = Properties.Resources.sleeping;
                        this.btn_trangthai.ImageSize = new Size(60, 57);
                        this.lbl_trangthai.Location = new Point(186, 53);
                        this.lbl_ngaynhan.Text = ct.NgayTraDuKien.ToString("D");

                        break;
                    }

                case "Được đặt":
                    {
                        this.panel_container.FillColor = Color.FromArgb(250, 163, 0);
                        this.btn_trangthai.Image = Properties.Resources.calendar;
                        this.btn_trangthai.ImageSize = new Size(30, 30);
                        this.lbl_trangthai.Location = new Point(185, 53);
                        this.lbl_ngaynhan.Text = chiTietphieudatphong.NgayNhan.ToString("D");

                        break;
                    }
            }

            this.lbl_trangthai.Text = TrangThai;

        }


        /* Cap nhat lai Phong */

        private void UpdatePhong(TrangThaiPhong trangthai)
        {

            int sophong = Convert.ToInt32(Getlbl_sophong.Text);

            Phong phong = BUS_Phong.Select_By_MaPHG(sophong);

            bool result = true;

            if (trangthai == TrangThaiPhong.Empty)
            {
                result = BUS_Phong.Update_With_tinhtrang(phong.MaPHG, phong.TenPHG, phong.LoaiPHG, phong.Dongia,1);
            }
            else if (trangthai == TrangThaiPhong.Lived)
            {
                result = BUS_Phong.Update_With_tinhtrang(phong.MaPHG, phong.TenPHG, phong.LoaiPHG, phong.Dongia,2);
            }
            else if (trangthai == TrangThaiPhong.Booked)
            {
                result = BUS_Phong.Update_With_tinhtrang(phong.MaPHG, phong.TenPHG, phong.LoaiPHG, phong.Dongia,3);
            }

        }






        /* Hàm xử lý sự kiện click vào room

          - Khi phòng đang trống thì mở  UserControlDatPhong

          - Còn phòng được đặt thì ConTrolChiTietPhong để tiến hành nhận phòng hoặc thêm dịch vụ      

        */

        public void OnClickRoomItem(object sender, MouseEventArgs e)
        {

            var selectd_item = (RoomItem)((Guna.UI2.WinForms.Guna2Panel)sender).Parent;

            switch (selectd_item.Getlbl_trangthai.Text)
            {
                case "Phòng trống":
                    {
                        DatPhong();
                        break;
                    }
                default:
                    {
                        ChiTietPhong();
                        break;
                    }
            }

            

        }


        /* Hàm dùng để đặt phòng*/
        public void DatPhong()
        {
            var result = MoControlDatPhong();
            switch (result)
            {
                case DialogResult.OK:
                    {
                        UpdateTrangThai("Được đặt");
                        UpdatePhong(TrangThaiPhong.Booked);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }


        /* Hàm dùng để xem chi tiết phòng*/
        public void ChiTietPhong()
        {
            var result = MoConTrolChiTietPhong();

            switch (result)
            {
                case DialogResult.OK:
                    {
                        /* Thay đổi tình trạng phòng*/
                        UpdatePhong(TrangThaiPhong.Lived);
                        UpdateTrangThai("Có khách");
                        break;
                    }
               case DialogResult.No:
                    {
                        /* Thay đổi tình trạng phòng*/
                        UpdatePhong(TrangThaiPhong.Empty);
                        UpdateTrangThai("Phòng trống");

                        break;
                    }         
            }


        }


        /* Mở UserControlDatPhong để tiến hành đặt phòng
          nếu trả về DialogResult.Oke là dặt thành công ngược lại thì không */

        public DialogResult MoControlDatPhong()
        {
            var obj = new DatPhong();
            obj.roomitem = this;

            var form = new ShowUserControl();

            /*Các thuộc tính chỉnh kích thước form vừa đúng với UserControlDatPhong*/
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = obj.Size;
            form.SetSuKien(obj);
            form.Controls.Add(obj);

            return form.ShowDialog();
        }


        /* Mở UserConTrolChiTietPhong để tiến hành nhận phòng hoặc thêm các dịch vụ và xem thông tin chi tiêt  */
        public DialogResult MoConTrolChiTietPhong()
        {
            var obj = new ChiTietPhong();
            obj.RoomItem = this;
            obj.SetUp();
            var form = new ShowUserControl();

            /*Các thuộc tính chỉnh kích thước form vừa đúng với UserConTrolChiTietPhong*/
            form.SetSuKien(obj);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Controls.Add(obj);
            form.Size = obj.Size;

            return form.ShowDialog();
   
        }


    }
}
