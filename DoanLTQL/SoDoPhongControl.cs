using BUS;
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

    public partial class SoDoPhongControl : UserControl
    {

        private List<RoomItem> room;
        int sl_phongtrong;
        int sl_cokhach;
        int sl_duocdat;

        public enum TypeofDisplay
        {
            All = 0,
            Empty = 1,
            Lived = 2,
            Booked = 3,
        }

        public SoDoPhongControl()
        {
            InitializeComponent();

            room = new List<RoomItem>();

            DisplayRoom(TypeofDisplay.All);
        }

        /* Hiển thị lên flowlayoutpanel */
        public void DisplayRoom(TypeofDisplay loai)
        {
            /* Xóa hết dữ liệu */
            panel_data_container.Controls.Clear();
            room.Clear();

            GetData();

            /* Gán lên flowlayoutpanel */
            foreach (RoomItem item in room)
            {
                if (loai == TypeofDisplay.All)
                {
                    panel_data_container.Controls.Add(item);
                }
                else if (loai == TypeofDisplay.Empty && item.Getlbl_trangthai.Text.Contains("trống"))
                {
                    panel_data_container.Controls.Add(item);
                }
                else if (loai == TypeofDisplay.Lived && item.Getlbl_trangthai.Text.Contains("khách"))
                {
                    panel_data_container.Controls.Add(item);
                }
                else if (loai == TypeofDisplay.Booked && item.Getlbl_trangthai.Text.Contains("đặt"))
                {
                    panel_data_container.Controls.Add(item);
                }
            }
        }

        /*Lấy dữ liệu*/
        public void GetData()
        {

            /* Lấy dữ liệu phòng */
            var phong = BUS_Phong.Select_All();

            /* Chỉnh lại số lượng */
            sl_phongtrong = 0;
            sl_cokhach = 0;
            sl_duocdat = 0;


            /* Đưa dữ liệu vào room */
            foreach (Phong phg in phong)
            {
                LoaiPHG loai = BUS_LoaiPHG.Select_By_MaLoai(phg.LoaiPHG);
                TinhTrangPHG tinhtrang = BUS_TinhTrangPHG.Select_By_MaTinhTrang((int)phg.TinhTrang);
                RoomItem roomItem = new RoomItem(phg.MaPHG, loai.TenloaiPHG, tinhtrang.TenTinhTrg, phg.Dongia);


                room.Add(roomItem);

                /* Đếm số lượng phòng theo tình trạng */

                if (tinhtrang.MaTinhTrg == 1)
                {
                    sl_phongtrong++;
                }
                else if (tinhtrang.MaTinhTrg == 2)
                {
                    sl_cokhach++;
                }
                else if (tinhtrang.MaTinhTrg == 3)
                {
                    sl_duocdat++;
                }

            }
            lbl_phongtrong.Text = string.Format($"Phòng trống ({sl_phongtrong.ToString()})");
            lbl_dango.Text = string.Format($"Có khách ({sl_cokhach.ToString()})");
            lbl_dattruoc.Text = string.Format($"Được đặt ({sl_duocdat.ToString()})");
        }

        /* Hàm hiển thị danh sách phòng theo loại tình trạng */
        private void btn_Click(object sender, EventArgs e)
        {
            var btn = (Guna2Button)sender;

            /* Click 2 lần vào một button */
            if (btn.BorderThickness == 4)
            {
                btn.BorderThickness = 0;
                DisplayRoom(TypeofDisplay.All);
                return;
            }

            /* Click 1 lần vào một button có thể khác nhau */
            foreach (Control control in panel_btn.Controls)
            {
                var button = (Guna2Button)control;

                /* Tắt chọn cho tât cả button */
                if (button.BorderThickness == 4)
                {
                    button.BorderThickness = 0;
                }
            }

            if (btn == btn_phgtrong)
            {
                btn.BorderThickness = 4;
                DisplayRoom(TypeofDisplay.Empty);
            }
            else if (btn == btn_cokhach)
            {
                btn.BorderThickness = 4;
                DisplayRoom(TypeofDisplay.Lived);
            }
            else if (btn == btn_dadat)
            {
                btn.BorderThickness = 4;
                DisplayRoom(TypeofDisplay.Booked);
            }
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            DisplayRoom(TypeofDisplay.All);
        }
    }
}
