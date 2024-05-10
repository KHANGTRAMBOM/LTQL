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

    public partial class ShowUserControl : Form
    {

        private bool dragging = false;
        private Point CursorPoint;
        private Point FormPoint;
        public ShowUserControl()
        {
            InitializeComponent();
        }

        /*HÀM THIẾT LẬP GÁN CÁC SỰ KIỆN ĐỂ THẢ SỰ KIỆN CHO CÁC USERCONTROL KHI ĐƯỢC ADD VÀO FORM */
        public void SetSuKien(object b)
        {
            if(b  is ThemDichVu)
            {
                ThemDichVu a =  b as ThemDichVu;
                a.panel_toolbar.MouseDown += DropMouseDown;
                a.panel_toolbar.MouseMove += DropMouseMove;
                a.panel_toolbar.MouseUp += DropMouseUp;
            }

            if (b is ThemNhanVien)
            {
                ThemNhanVien a = b as ThemNhanVien;
                a.panel_toolbar.MouseDown += DropMouseDown;
                a.panel_toolbar.MouseMove += DropMouseMove;
                a.panel_toolbar.MouseUp += DropMouseUp;
            }

            if (b is ChiTietHoaDonControl)
            { 
                ChiTietHoaDonControl a = b as ChiTietHoaDonControl;
                a.panel_toolbar.MouseDown += DropMouseDown;
                a.panel_toolbar.MouseMove += DropMouseMove;
                a.panel_toolbar.MouseUp += DropMouseUp;
            }

            if (b is DatPhong)
            {
                DatPhong a = b as DatPhong;
                a.panel_toolbar.MouseDown += DropMouseDown;
                a.panel_toolbar.MouseMove += DropMouseMove;
                a.panel_toolbar.MouseUp += DropMouseUp;
            }


            if (b is ChiTietPhong)
            {
                ChiTietPhong a = b as ChiTietPhong;
                a.panel_toolbar.MouseDown += DropMouseDown;
                a.panel_toolbar.MouseMove += DropMouseMove;
                a.panel_toolbar.MouseUp += DropMouseUp;
            }

        }


        /*SỰ KIỆN KHI MouseDown SẼ THẢ SỰ KIỆN MouseDown*/
        private void DropMouseDown(object? sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }


        /*SỰ KIỆN KHI MouseMove SẼ THẢ SỰ KIỆN MouseMove*/
        private void DropMouseMove(object? sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        /*SỰ KIỆN KHI MouseUp SẼ THẢ SỰ KIỆN MouseUp*/
        private void DropMouseUp(object? sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }


        /* CHUỖI CÁC SỰ KIỆN DÙNG ĐỂ DI CHUYỂN FORM */
        private void MouseDownn(object sender, MouseEventArgs e)
        {

            dragging = true;
            CursorPoint = Cursor.Position;
            FormPoint = this.Location;
        }
        private void MouseMovee(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                var differ = Point.Subtract(CursorPoint, new Size(Cursor.Position));
                this.Location = Point.Subtract(FormPoint, new Size(differ));
            }
        }
        private void MouseUpp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

    }
}
