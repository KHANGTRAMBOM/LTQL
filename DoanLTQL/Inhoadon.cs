using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Inhoadon : Form
    {
        public int MaHD = 0;

        private bool dragging = false;
        private Point CursorPoint;
        private Point FormPoint;
        public Inhoadon()
        {
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Print()
        {
            getprintarea();
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }


        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.MarginBounds;

            // Vẽ header ở giữa trên trang
            int headerX = (pagearea.Width) / 2 - (pagearea.Width / 2) / 2;
            int headerY = pagearea.Top;
            e.Graphics.DrawImage(header, headerX, headerY);

            // Vẽ body ở giữa  trang
            int bodyX = (pagearea.Width) / 2 - (pagearea.Width / 2) / 2 + 20;
            int bodyY = headerY + header.Height - 100;
            e.Graphics.DrawImage(body, bodyX, bodyY);

            // Vẽ footer ở giữa dưới trang
            int minus = 0;
            if (dgv.Rows.Count > 5) minus = 40;
            else minus = 50;

            int footerX = (pagearea.Width) / 2 - (pagearea.Width / 2) / 2;
            int footerY = bodyY + body.Height / 2 - minus;
            e.Graphics.DrawImage(footer, footerX, footerY);

        }


        private Bitmap header;
        private Bitmap body;
        private Bitmap footer;
        private string row_header;
        private string row_data;

        private void getprintarea()
        {
            /* Vẽ hình footer */
            header = new Bitmap(this.panel_hoadon1.Width, this.panel_hoadon1.Height);
            this.panel_hoadon1.DrawToBitmap(header, new Rectangle(0, 0, this.panel_hoadon1.Width, this.panel_hoadon1.Height));


            /* Vẽ hình body */
            int Height = dgv.Height;
            dgv.Height = dgv.Rows.Count * dgv.RowTemplate.Height * 2;
            body = new Bitmap(this.dgv.Width, dgv.Height);
            this.dgv.DrawToBitmap(body, new Rectangle(0, 0, this.dgv.Width, dgv.Height));
            dgv.Height = Height;


            /* Vẽ hình footer */
            footer = new Bitmap(this.panel_hoadon2.Width, this.panel_hoadon2.Height);
            this.panel_hoadon2.DrawToBitmap(footer, new Rectangle(0, 0, this.panel_hoadon2.Width, this.panel_hoadon2.Height));


        }

        private void btn_in_Click(object sender, EventArgs e)
        {
            Print();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Inhoadon_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            dgv.AutoGenerateColumns = false;

            dgv.ReadOnly = true;

            if (MaHD != 0)
            {

                HoaDon hd = BUS_HoaDon.Select_By_MaHD(MaHD);

                NhanVien nv = BUS_NhanVien.Select_By_MaNV((int)hd.MaNV);

                ChiTietPhieuNhanPhong ct_phieunhan = BUS_ChiTietNhanPhong.Select_By_MaNhanPhong((int)hd.MaNhanPHG);

                ChiTietPhieuDatPhong ct_phieudat = BUS_ChiTietDatPhong.Select_By_MaDatPHG(ct_phieunhan.MaDatPHG);

                Phong phong = BUS_Phong.Select_By_MaPHG((int)ct_phieudat.MaPHG);

                LoaiPHG loaiphg = BUS_LoaiPHG.Select_By_MaLoai(phong.LoaiPHG);

                KhachHang kh = BUS_KhachHangcs.Select_By_ID((int)hd.MaKH);

                var datasource = BUS_SuDungDichVu.Select_Display_MaNhanPHG(hd.MaNhanPHG);

                txt_tenkh.Text = kh.TenKH;

                txt_ngaylap.Text = ct_phieudat.NgayDat.ToString("D");

                txt_mahd.Text = hd.MaHD.ToString();

                txt_nhanvien.Text = nv.TenNV;

                txt_sophong.Text = phong.MaPHG.ToString();

                txt_loaiphong.Text = loaiphg.TenloaiPHG;

                txt_songay.Text = BUS_HoaDon.GetSoNgay(hd.MaHD).ToString();

                dgv.DataSource = datasource;

                dgv.ClearSelection();

                txt_tongtien.Text = String.Format($"{hd.TongTien:C0}");

                lbl_ngaylaphoadon.Text = DateTime.Now.ToString("D");

            }
        }

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
